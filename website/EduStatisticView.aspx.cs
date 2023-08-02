using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

public partial class EduStatisticView : AuthPage
{
    private string EduTermID
    {
        get
        {
            return Request.QueryString["edutermid"];
        }
    }

    private DataTable CurrentStatData
    {
        get
        {
            return ViewState["CurrentStatData"] as DataTable;
        }
        set
        {
            ViewState["CurrentStatData"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(rgHistory);
        AddPostbackControl(btnExport);
        AddPostbackControl(btnDepFinishRate);
        //AddPostbackControl(btnQuery);

        if (!IsPostBack)
        {
            BindHospital();
            BindDeptment();
            BindTemplate();
        }
    }

    private void BindHospital()
    {
        List<HospDto> list = service.GetShortHosp();
        HospDto alldto = new HospDto();
        alldto.HospCode = "";
        alldto.HospName = "全部";
        list.Insert(0, alldto);
        ddlHospital.DataTextField = "HospName";
        ddlHospital.DataValueField = "HospCode";
        ddlHospital.DataSource = list;

        ddlHospital.DataBind();

    }

    private void BindTemplate()
    {
        List<FORM_TEMPLATEDto> list = service.GetAllTemplates(this.HospCode);

        FORM_TEMPLATEDto nulldto = new FORM_TEMPLATEDto();

        rcbTemplateID.DataValueField = "TEMPLATE_ID";
        rcbTemplateID.DataTextField = "TEMPLATE_NAME";
        rcbTemplateID.DataSource = list;
        rcbTemplateID.DataBind();
    }

    private void RefreshHistory()
    {
        List<string> jobcodes = null;
        if (rddtJobCode.SelectedValue != "")
        {
            jobcodes = rddtJobCode.SelectedValue.Split(',').ToList();
        }
        List<string> hospcodes = new List<string>();
        foreach (RadComboBoxItem item in ddlHospital.CheckedItems)
        {
            hospcodes.Add(item.Value);
        }

        List<string> depids = new List<string>();

        foreach (RadComboBoxItem item in ddlUnit.CheckedItems)
        {
            depids.Add(item.Value);
        }


        List<int> templateids = new List<int>();

        foreach (RadComboBoxItem item in rcbTemplateID.CheckedItems)
        {
            templateids.Add(Convert.ToInt32(item.Value));
        }

        List<EduFormTemplateListDto> list = service.GetEvalStasticDataRange(hospcodes,depids, jobcodes, templateids, rdpSDate.SelectedDate.Value, rdpEDate.SelectedDate.Value, cbFinish.Checked);
        rgHistory.DataSource = list;
        ViewState["HistoryDataSource"] = list;
        if (list.Count > 0)
        {
            ViewState["ftlists"] = list[0].FTListIDs;
        }

    }

    private void BindDeptment()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");

        SelectGroupTypeDto dtoall = new SelectGroupTypeDto();
        dtoall.code = "";
        dtoall.name = "全部";
        list.Insert(0, dtoall);

        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();

        if (list.Count(c => c.code == this.DeptCode) > 0)
        {
            ddlUnit.SelectedValue = this.DeptCode;
        }

    }

    protected void rgHistory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RefreshHistory();
    }

    protected void rgHistory_ItemCreated(object sender, GridItemEventArgs e)
    {

        if (e.Item is GridDataItem)
        {
            List<EduFormTemplateListDto> datasoure = ViewState["HistoryDataSource"] as List<EduFormTemplateListDto>;

            GridDataItem item = e.Item as GridDataItem;

            string edutermid = null;
            int templateid = 0;

            if (item.GetDataKeyValue("RootEduTermID") != null)
            {
                edutermid = item.GetDataKeyValue("RootEduTermID").ToString();
            }

            if (item.GetDataKeyValue("TEMPLATE_ID") != null)
            {
                templateid = Convert.ToInt32(item.GetDataKeyValue("TEMPLATE_ID").ToString());
            }

            EduFormTemplateListDto dto = datasoure.Where(c => c.RootEduTermID == edutermid && c.TEMPLATE_ID == templateid).FirstOrDefault();
            if (dto != null)
            {
                if (dto.StasticPermissionRoles != null && dto.StasticPermissionRoles.Count > 0)
                {
                    bool permiss = false;

                    foreach (string role in this.AuthRoles)
                    {
                        if (dto.StasticPermissionRoles.Contains(role))
                        {
                            permiss = true;
                        }
                    }

                    if (!permiss)
                    {
                        LinkButton lbtnStatistic = item.FindControl("lbtnQuery") as LinkButton;
                        if (lbtnStatistic != null)
                        {
                            lbtnStatistic.Visible = false;
                        }

                        LinkButton lbtnDownload = item.FindControl("lbtnDownload") as LinkButton;
                        if (lbtnDownload != null)
                        {
                            lbtnDownload.Visible = false;
                        }

                    }
                }
            }



        }
    }

    protected void lbtnDownload_Click(object sender, EventArgs e)
    {

        MemoryStream output = new MemoryStream();
        ZipOutputStream stream = new ZipOutputStream(output);
        stream.SetLevel(3);




        GridDataItem item = (sender as LinkButton).Parent.Parent as GridDataItem;
        
        

        string edutermid = null;
        string templateid = null;

        if (item.GetDataKeyValue("RootEduTermID") != null)
        {
            edutermid = item.GetDataKeyValue("RootEduTermID").ToString();
        }

        if (item.GetDataKeyValue("TEMPLATE_ID") != null)
        {
            templateid = item.GetDataKeyValue("TEMPLATE_ID").ToString();
        }

        EduFormTemplateListDto dto = (ViewState["HistoryDataSource"] as List<EduFormTemplateListDto>).Where(c => c.TEMPLATE_ID == Convert.ToInt32(templateid)).FirstOrDefault();
        ViewState["ftlists"] = dto.FTListIDs;


        List<HtmlFormUtility.FORM_INSTANCES> instances = service.GetInstanceByFtlistIDs(ViewState["ftlists"] as List<string>, templateid);


        bool hasdata = false;

        foreach (HtmlFormUtility.FORM_INSTANCES ins in instances.Where(c => c.PARENT_INSTANCE_ID == null || instances.Count(d=> d.INSTANCE_ID == c.PARENT_INSTANCE_ID) == 0))
        {

            if (instances.Where(c => c.PARENT_INSTANCE_ID == ins.INSTANCE_ID).Count() == 0)
            {
                if (ins.Status != "0")
                {

                    hasdata = true;
                    byte[] space = new byte[] { 0xc2, 0xa0 };
                    string UTFSpace = System.Text.Encoding.GetEncoding("UTF-8").GetString(space);
                    byte[] binaryData = System.Text.Encoding.Default.GetBytes(ins.INSTANCE_CONTENT.Replace("charset=utf-8", "charset=big5").Replace(UTFSpace, "&nbsp;"));
                    //binaryData = System.Text.Encoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.Default, binaryData);
                    List<HtmlFormUtility.FORM_INSTANCE_TARGETS> targets = service.GetInstanceTargets(ins.INSTANCE_ID);

                    string evaltarget = "";
                    string targetname = "(";

                    if (ins.EvalTargetID != null && ins.EvalTargetID != "")
                    {
                        evaltarget = "-" + service.ReadMember(ins.EvalTargetID).Name;
                    }

                    foreach (HtmlFormUtility.FORM_INSTANCE_TARGETS tar in targets)
                    {
                        targetname += service.ReadVKmuempData(tar.TargetID).empname + ",";
                    }
                    targetname = targetname.Substring(0, targetname.Length - 1) + ")";


                    stream.PutNextEntry(new ZipEntry(ins.INSTANCE_ID.ToString() + targetname + ins.INSTANCE_NAME + evaltarget + ".html"));

                    stream.Write(binaryData, 0, binaryData.Length);
                }
            }
            else
            {
                List<HtmlFormUtility.FORM_INSTANCES> childlist = instances.Where(c => c.PARENT_INSTANCE_ID == ins.INSTANCE_ID).ToList();



                string evaltarget = "";
                string targetname = "(";

                foreach (HtmlFormUtility.FORM_INSTANCES child in childlist)
                {
                    if (child.Status != "0")
                    {
                        List<HtmlFormUtility.FORM_INSTANCE_TARGETS> targets = service.GetInstanceTargets(child.INSTANCE_ID);

                        if (child.EvalTargetID != null && child.EvalTargetID != "")
                        {
                            evaltarget = "-" + service.ReadMember(child.EvalTargetID).Name;
                        }

                        foreach (HtmlFormUtility.FORM_INSTANCE_TARGETS tar in targets)
                        {
                            targetname += service.ReadVKmuempData(tar.TargetID).empname + ",";
                        }
                        targetname = targetname.Substring(0, targetname.Length - 1) + ")";
                    }
                }
                stream.PutNextEntry(new ZipEntry(ins.INSTANCE_ID.ToString() + targetname + ins.INSTANCE_NAME + evaltarget + ".html"));

                foreach (HtmlFormUtility.FORM_INSTANCES child in childlist)
                {
                    if (child.Status != "0")
                    {
                        hasdata = true;
                        byte[] space = new byte[] { 0xc2, 0xa0 };
                        string UTFSpace = System.Text.Encoding.GetEncoding("UTF-8").GetString(space); 
                        
                        byte[] binaryData = System.Text.Encoding.Default.GetBytes(child.INSTANCE_CONTENT.Replace("charset=utf-8", "charset=big5").Replace(UTFSpace, "&nbsp;"));
                        //binaryData = System.Text.Encoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.Default, binaryData);

                        stream.Write(binaryData, 0, binaryData.Length);
                    }
                }

            }

        }


        stream.Finish();
        stream.Close();
        if (hasdata)
        {
            Response.Clear();
            Response.AddHeader("Content-Length", output.ToArray().Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=output.zip");
            Response.OutputStream.Write(output.ToArray(), 0, output.ToArray().Length);

            Response.Flush();
            Response.End();
        }
    }

    protected void lbtnStatistic_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as LinkButton).Parent.Parent as GridDataItem;
        int templateid = 0;
        string edutermid = null;
        if (item.GetDataKeyValue("RootEduTermID") != null)
        {
            edutermid = item.GetDataKeyValue("RootEduTermID").ToString();
        }

        if (item.GetDataKeyValue("TEMPLATE_ID") != null)
        {
            templateid = Convert.ToInt32(item.GetDataKeyValue("TEMPLATE_ID"));
        }

        EduFormTemplateListDto dto = (ViewState["HistoryDataSource"] as List<EduFormTemplateListDto>).Where(c => c.TEMPLATE_ID == templateid).FirstOrDefault();
        ViewState["ftlists"] = dto.FTListIDs;

        lbEduTermID.Text = edutermid;
        lbTemplateid.Text = templateid.ToString();

        ReadStatisticData();
        //rgDetailList.DataBind();

        //RadTabStrip1.SelectedIndex = 1;
        //RadMultiPage1.SelectedIndex = 1;


    }

    private void ReadStatisticData()
    {
        if (lbTemplateid.Text!="")
        {
            string edutermid = lbEduTermID.Text;

            int templateid = Convert.ToInt32(lbTemplateid.Text);

            List<STATISTIC_EXPEND_DATA_LIST> list = service.GetStatisticDataListByFTListIDs(templateid, ViewState["ftlists"] as List<string>);


            DataTable dt = new DataTable();
            dt.Columns.Add("表單序號");
            dt.Columns.Add("發送時間");
            dt.Columns.Add("填寫人職編");
            dt.Columns.Add("填寫人姓名");
            dt.Columns.Add("填寫人學號");
            dt.Columns.Add("填寫人身分");
            dt.Columns.Add("填寫人臨床老師職編");
            dt.Columns.Add("填寫狀態");
            dt.Columns.Add("考核對象");
            dt.Columns.Add("課程名稱(完整)");
            dt.Columns.Add("受訓院區");
            dt.Columns.Add("受訓科別代碼");
            dt.Columns.Add("受訓科別 ");
            dt.Columns.Add("受訓期間 ");
            if (list.Count(c => c.SchoolSeq1 != null && c.SchoolSeq1 != "") > 0)
            {
                dt.Columns.Add("醫學系開課序號");
            }
            if (list.Count(c => c.SchoolSeq2 != null && c.SchoolSeq2 != "") > 0)
            {
                dt.Columns.Add("後醫系開課序號");
            }



            foreach (string group in list.Select(c => c.GroupName).Distinct())
            {
                dt.Columns.Add(group);
            }

            Dictionary<string, int> statuscount = new Dictionary<string, int>();

            foreach (STATISTIC_EXPEND_DATA_LIST data in list)
            {
                
                DataRow[] rows = dt.Select("表單序號 = '" + data.InstanceID.ToString() + "'");
                DataRow row;
                if (rows.Length > 0)
                {
                    row = rows[0];

                    row["填寫人職編"] = "";
                    foreach (string val in list.Where(c => c.InstanceID == data.InstanceID).Select(c => c.TargetID).Distinct().ToList())
                    {
                        row["填寫人職編"] += "\r\n" + val;
                    }

                    row["填寫人姓名"] = "";
                    foreach (string val in list.Where(c => c.InstanceID == data.InstanceID).Select(c => c.TargetName).Distinct().ToList())
                    {
                        row["填寫人姓名"] += "\r\n" + val;
                    }

                    row["考核對象"] = "";
                    foreach (string val in list.Where(c => c.InstanceID == data.InstanceID).Select(c => c.EvalTargetName).Distinct().ToList())
                    {
                        row["考核對象"] += "\r\n" + val;
                    }


                    row["填寫狀態"] = list.Count(c => c.InstanceID == data.InstanceID && c.StatusName == "未完成") > 0 ? "未完成" : "已完成";

                }
                else
                {
                    row = dt.NewRow();
                    row["發送時間"] = data.CreateDate.ToString("yyyy/MM/dd HH:mm");
                    row["表單序號"] = data.InstanceID.ToString();
                    row["填寫人職編"] = data.TargetID;
                    row["填寫人姓名"] = data.TargetName;
                    row["填寫人身分"] = data.TargetType;
                    row["填寫人學號"] = data.TargetMemberCode;
                    row["填寫人臨床老師職編"] = data.TargetCoach;
                    row["填寫狀態"] = data.StatusName;
                    row["考核對象"] = data.EvalTargetName;
                    row["課程名稱(完整)"] = data.EduTermFullName;
                    row["受訓科別代碼"] = data.DeptCode;
                    row["受訓院區"] = data.HospName;
                    row["受訓科別 "] = data.DeptName;
                    row["受訓期間 "] = data.EduTermTimeRange;
                    if (dt.Columns.Contains("醫學系開課序號"))
                    {
                        row["醫學系開課序號"] = data.SchoolSeq1;
                    }
                    if (dt.Columns.Contains("後醫系開課序號"))
                    {
                        row["後醫系開課序號"] = data.SchoolSeq2;
                    }
                    
                    dt.Rows.Add(row);

                    if (statuscount.Keys.Contains(data.StatusName))
                    {
                        statuscount[data.StatusName]++;
                    }
                    else
                    {
                        statuscount.Add(data.StatusName, 1);
                    }
                }

                row[data.GroupName] = data.Value;
            }

            BulletedList1.Items.Clear();
            foreach (string key in statuscount.Keys)
            {
                BulletedList1.Items.Add(key + "：" + statuscount[key].ToString());
            }

            DataRow drsum = dt.NewRow();
            DataRow dravg = dt.NewRow();
            DataRow drmax = dt.NewRow();
            DataRow drmin = dt.NewRow();
            foreach (DataColumn col in dt.Columns)
            {
                drsum[col.ColumnName] = 0.0;
                dravg[col.ColumnName] = 0.0;
                drmax[col.ColumnName] = 0.0;
                drmin[col.ColumnName] = 999.0;

                foreach (DataRow dr in dt.Rows)
                {

                    try
                    {
                        double tempvalue = Convert.ToDouble(dr[col.ColumnName]);
                        drsum[col.ColumnName] = Convert.ToDouble(drsum[col.ColumnName]) + tempvalue;
                        if (tempvalue > Convert.ToDouble(drmax[col.ColumnName]))
                        {
                            drmax[col.ColumnName] = tempvalue;
                        }

                        if (tempvalue < Convert.ToDouble(drmin[col.ColumnName]))
                        {
                            drmin[col.ColumnName] = tempvalue;
                        }

                    }
                    catch
                    {
                    }
                }

                dravg[col.ColumnName] = Convert.ToDouble(drsum[col.ColumnName]) / Convert.ToDouble(dt.Rows.Count);
            }
            
            drsum["填寫人職編"] = "";
            drsum["填寫人姓名"] = "";
            drsum["填寫狀態"] = "合計";
            dravg["填寫人職編"] = "";
            dravg["填寫人姓名"] = "";
            dravg["填寫狀態"] = "平均";
            drmax["填寫人職編"] = "";
            drmax["填寫人姓名"] = "";
            drmax["填寫狀態"] = "最大值";
            drmin["填寫人職編"] = "";
            drmin["填寫人姓名"] = "";
            drmin["填寫狀態"] = "最小值";

            dt.Rows.Add(drsum);
            dt.Rows.Add(dravg);
            dt.Rows.Add(drmax);
            dt.Rows.Add(drmin);


            Utility uti = new Utility();

            byte[] bytes = uti.ExportDataTableToExcel(dt);


            HttpResponse response = Response;

            response.Clear();

            //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

            response.AddHeader("Content-Type", "binary/octet-stream");

            response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + bytes.Length.ToString());

            response.BinaryWrite(bytes);

            response.Flush();
            response.End();

            //CurrentStatData = dt;

            //rgDetailList.DataSource = dt;
            
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        rgDetailList.NeedDataSource -= rgDetailList_NeedDataSource;
        rgDetailList.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        rgDetailList.ExportSettings.ExportOnlyData = true;
        rgDetailList.ExportSettings.IgnorePaging = true;
        rgDetailList.ExportSettings.OpenInNewWindow = true;
        rgDetailList.MasterTableView.ExportToExcel();
        rgDetailList.NeedDataSource += rgDetailList_NeedDataSource;
    }
    protected void rgDetailList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (CurrentStatData == null)
        {
            ReadStatisticData();
        }
        else
        {
            rgDetailList.DataSource = CurrentStatData;
        }
        
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (rddtJobCode.SelectedValue == "")
        {
            ShowMessage("未選擇職稱");
            return;
        }
        if (ddlHospital.CheckedItems.Count == 0)
        {
            ShowMessage("未選擇院區");
            return;
        }


        if (ddlUnit.CheckedItems.Count == 0)
        {
            ShowMessage("未選擇部門");
            return;
        }

        if (rcbTemplateID.CheckedItems.Count == 0) //rcbTemplateID.SelectedValue == null || rcbTemplateID.SelectedValue == "")
        {
            ShowMessage("未選擇表單");
            return;
        }


        if (rdpSDate.SelectedDate == null)
        {
            ShowMessage("未選擇開始時間");
            return;
        }

        if (rdpEDate.SelectedDate == null)
        {
            ShowMessage("未選擇結束時間");
            return;
        }

        RefreshHistory();
        rgHistory.DataBind();
    }
    protected void btnDepFinishRate_Click(object sender, EventArgs e)
    {
        List<string> jobcodes = new List<string>();
        if (rddtJobCode.SelectedValue != "")
        {
            jobcodes = rddtJobCode.SelectedValue.Split(',').ToList();
        }

        List<string> depids = new List<string>();

        foreach (RadComboBoxItem item in ddlUnit.CheckedItems)
        {
            depids.Add(item.Value);
        }


        List<int> templateids = new List<int>();

        foreach (RadComboBoxItem item in rcbTemplateID.CheckedItems)
        {
            templateids.Add(Convert.ToInt32(item.Value));
        }

        List<EduFormTemplateListDto> list = service.GetDeptEvalStasticDataRange(depids, jobcodes, templateids, rdpSDate.SelectedDate.Value, rdpEDate.SelectedDate.Value, cbSplit.Checked, cbExpireOnly.Checked);

        DataTable dt = new DataTable();

        dt.Columns.Add("單位");

        List<int> alltemplateids = list.Select(c => c.TEMPLATE_ID).Distinct().ToList();
        List<int> havedatatemplateids = new List<int>();

        foreach (int id in alltemplateids)
        {
            if (list.Where(c => c.TEMPLATE_ID == id).Sum(c => c.AllFormCount) > 0)
            {
                havedatatemplateids.Add(id);
            }
        }

        list = list.Where(c => havedatatemplateids.Contains(c.TEMPLATE_ID)).ToList();

        foreach (string templatename in list.Select(c => c.TEMPLATE_NAME).Distinct())
        {
            dt.Columns.Add(templatename + " 已完成");
            dt.Columns.Add(templatename + " 逾期已完成");
            dt.Columns.Add(templatename + " 未完成");
            dt.Columns.Add(templatename + " 逾期未完成");
            dt.Columns.Add(templatename + " 應完成");
        }

        dt.Columns.Add("總已完成");
        dt.Columns.Add("總逾期已完成");
        dt.Columns.Add("總未完成");
        dt.Columns.Add("總逾期未完成");
        dt.Columns.Add("總應完成");
        dt.Columns.Add("總完成率(未逾期)");
        dt.Columns.Add("總完成率");

        dt.Columns.Add("總已完成-學生");
        dt.Columns.Add("總未完成-學生");
        dt.Columns.Add("總應完成-學生");
        dt.Columns.Add("總完成率-學生");

        dt.Columns.Add("總已完成-老師");
        dt.Columns.Add("總未完成-老師");
        dt.Columns.Add("總未完成-老師(不算學生未完成)");
        dt.Columns.Add("總應完成-老師");
        dt.Columns.Add("總應完成-老師(不算學生未完成)");
        dt.Columns.Add("總完成率-老師");
        dt.Columns.Add("總完成率-老師(不算學生未完成)");


        foreach(var i in list.OrderBy(c=> c.Des ))
        {
            DataRow[] drs = dt.Select("單位 = '" + i.Name + "'");

            DataRow dr;
            if (drs.Length == 0)
            {
                dr = dt.NewRow();
                dr["單位"] = i.Name;

                dr["總已完成-學生"] = 0;
                dr["總未完成-學生"] = 0 ;
                dr["總應完成-學生"] = 0;
                dr["總完成率-學生"] = 0;

                dr["總已完成-老師"] = 0;
                dr["總未完成-老師"] = 0;
                dr["總未完成-老師(不算學生未完成)"] = 0;
                dr["總應完成-老師"] = 0;
                dr["總應完成-老師(不算學生未完成)"] = 0;
                dr["總完成率-老師"] = 0;
                dr["總完成率-老師(不算學生未完成)"] = 0;

                dt.Rows.Add(dr);

            }
            else
            {
                dr = drs[0];
            }

            dr[i.TEMPLATE_NAME + " 已完成"] = i.FinishCount;
            dr[i.TEMPLATE_NAME + " 逾期已完成"] = i.ExpireFinishCount;
            dr[i.TEMPLATE_NAME + " 未完成"] = i.NotFinishCount;
            dr[i.TEMPLATE_NAME + " 逾期未完成"] = i.ExpireNotFinishCount;
            dr[i.TEMPLATE_NAME + " 應完成"] = i.AllFormCount;

            dr["總已完成-學生"] = Convert.ToInt32(dr["總已完成-學生"]) + i.SFinishCount;
            dr["總應完成-學生"] = Convert.ToInt32(dr["總應完成-學生"]) + i.SAllCount;
            dr["總已完成-老師"] = Convert.ToInt32(dr["總已完成-老師"]) + i.TFinishCount;
            dr["總應完成-老師"] = Convert.ToInt32(dr["總應完成-老師"]) + i.TAllCount;
            dr["總應完成-老師(不算學生未完成)"] = Convert.ToInt32(dr["總應完成-老師(不算學生未完成)"]) + i.TAllCount2;
        }

        DataRow drsum = dt.NewRow();

        if (depids.Count == 1)
        {
            drsum["單位"] = ddlUnit.Text + " 總計";
        }

        foreach (string templatename in list.Select(c => c.TEMPLATE_NAME).Distinct())
        {
            drsum[templatename + " 已完成"] = 0;
            drsum[templatename + " 逾期已完成"] = 0;
            drsum[templatename + " 未完成"] = 0;
            drsum[templatename + " 逾期未完成"] = 0;
            drsum[templatename + " 應完成"] = 0;
        }
        drsum["總已完成"] = 0;
        drsum["總逾期已完成"] = 0;
        drsum["總未完成"] = 0;
        drsum["總逾期未完成"] = 0;
        drsum["總應完成"] = 0;

        foreach (DataRow dr in dt.Rows)
        {
            dr["總已完成"] = 0;
            dr["總逾期已完成"] = 0;
            dr["總未完成"] = 0;
            dr["總逾期未完成"] = 0;
            dr["總應完成"] = 0;
            foreach (string templatename in list.Select(c => c.TEMPLATE_NAME).Distinct())
            {
                if (dr[templatename + " 已完成"] == DBNull.Value)
                {
                    dr[templatename + " 已完成"] = 0;
                }
                if (dr[templatename + " 逾期已完成"] == DBNull.Value)
                {
                    dr[templatename + " 逾期已完成"] = 0;
                }
                if (dr[templatename + " 未完成"] == DBNull.Value)
                {
                    dr[templatename + " 未完成"] = 0;
                }
                if (dr[templatename + " 逾期未完成"] == DBNull.Value)
                {
                    dr[templatename + " 逾期未完成"] = 0;
                }
                if (dr[templatename + " 應完成"] == DBNull.Value)
                {
                    dr[templatename + " 應完成"] = 0;
                }
                drsum[templatename + " 已完成"] = Convert.ToInt32(drsum[templatename + " 已完成"]) + Convert.ToInt32(dr[templatename + " 已完成"]);
                drsum[templatename + " 逾期已完成"] = Convert.ToInt32(drsum[templatename + " 逾期已完成"]) + Convert.ToInt32(dr[templatename + " 逾期已完成"]);
                drsum[templatename + " 未完成"] = Convert.ToInt32(drsum[templatename + " 未完成"]) + Convert.ToInt32(dr[templatename + " 未完成"]);
                drsum[templatename + " 逾期未完成"] = Convert.ToInt32(drsum[templatename + " 逾期未完成"]) + Convert.ToInt32(dr[templatename + " 逾期未完成"]);
                drsum[templatename + " 應完成"] = Convert.ToInt32(drsum[templatename + " 應完成"]) + Convert.ToInt32(dr[templatename + " 應完成"]);
                drsum["總已完成"] = Convert.ToInt32(drsum["總已完成"]) + Convert.ToInt32(dr[templatename + " 已完成"]);
                drsum["總逾期已完成"] = Convert.ToInt32(drsum["總逾期已完成"]) + Convert.ToInt32(dr[templatename + " 逾期已完成"]);
                drsum["總未完成"] = Convert.ToInt32(drsum["總未完成"]) + Convert.ToInt32(dr[templatename + " 未完成"]);
                drsum["總逾期未完成"] = Convert.ToInt32(drsum["總逾期未完成"]) + Convert.ToInt32(dr[templatename + " 逾期未完成"]);
                drsum["總應完成"] = Convert.ToInt32(drsum["總應完成"]) + Convert.ToInt32(dr[templatename + " 應完成"]);

                dr["總已完成"] = Convert.ToInt32(dr["總已完成"]) + Convert.ToInt32(dr[templatename + " 已完成"]);
                dr["總逾期已完成"] = Convert.ToInt32(dr["總逾期已完成"]) + Convert.ToInt32(dr[templatename + " 逾期已完成"]);
                dr["總未完成"] = Convert.ToInt32(dr["總未完成"]) + Convert.ToInt32(dr[templatename + " 未完成"]);
                dr["總逾期未完成"] = Convert.ToInt32(dr["總逾期未完成"]) + Convert.ToInt32(dr[templatename + " 逾期未完成"]);
                dr["總應完成"] = Convert.ToInt32(dr["總應完成"]) + Convert.ToInt32(dr[templatename + " 應完成"]);
            }

            if (dr["總應完成"] == DBNull.Value || Convert.ToInt32(dr["總應完成"]) == 0)
            {
                dr["總完成率(未逾期)"] = "N/A";
                dr["總完成率"] = "N/A";
                
            }
            else
            {
                dr["總完成率(未逾期)"] = Math.Round((Convert.ToDouble(dr["總已完成"]) / Convert.ToDouble(dr["總應完成"])) * 100, 2).ToString("0.00") + "%";
                dr["總完成率"] = Math.Round(((Convert.ToDouble(dr["總已完成"]) + Convert.ToDouble(dr["總逾期已完成"])) / Convert.ToDouble(dr["總應完成"])) * 100, 2).ToString("0.00") + "%";
            }

            dr["總未完成-學生"] = Convert.ToInt32(dr["總應完成-學生"]) - Convert.ToInt32(dr["總已完成-學生"]);
            if (Convert.ToInt32(dr["總應完成-學生"]) == 0)
            {
                dr["總完成率-學生"] = "N/A";

            }
            else
            {
                dr["總完成率-學生"] = Math.Round((Convert.ToDouble(dr["總已完成-學生"]) / Convert.ToDouble(dr["總應完成-學生"])) * 100, 2).ToString("0.00") + "%";
            }

            dr["總未完成-老師"] = Convert.ToInt32(dr["總應完成-老師"]) - Convert.ToInt32(dr["總已完成-老師"]);
            dr["總未完成-老師(不算學生未完成)"] = Convert.ToInt32(dr["總應完成-老師(不算學生未完成)"]) - Convert.ToInt32(dr["總已完成-老師"]);

            if (Convert.ToInt32(dr["總應完成-老師"]) == 0)
            {
                dr["總完成率-老師"] = "N/A";

            }
            else
            {
                dr["總完成率-老師"] = Math.Round((Convert.ToDouble(dr["總已完成-老師"]) / Convert.ToDouble(dr["總應完成-老師"])) * 100, 2).ToString("0.00") + "%";
                
            }

            if (Convert.ToInt32(dr["總應完成-老師(不算學生未完成)"]) == 0)
            {
                dr["總完成率-老師(不算學生未完成)"] = "N/A";

            }
            else
            {
                dr["總完成率-老師(不算學生未完成)"] = Math.Round((Convert.ToDouble(dr["總已完成-老師"]) / Convert.ToDouble(dr["總應完成-老師(不算學生未完成)"])) * 100, 2).ToString("0.00") + "%";

            }
        }

        if (Convert.ToInt32(drsum["總應完成"]) == 0)
        {
            drsum["總完成率(未逾期)"] = "N/A";
            drsum["總完成率"] = "N/A";
        }
        else
        {
            drsum["總完成率(未逾期)"] = Math.Round((Convert.ToDouble(drsum["總已完成"]) / Convert.ToDouble(drsum["總應完成"])) * 100, 2).ToString("0.00") + "%";
            drsum["總完成率"] = Math.Round(((Convert.ToDouble(drsum["總已完成"]) + Convert.ToDouble(drsum["總逾期已完成"])) / Convert.ToDouble(drsum["總應完成"])) * 100, 2).ToString("0.00") + "%";
        }

        dt.Rows.InsertAt(drsum, 0);

        Utility uti = new Utility();

        byte[] bytes = uti.ExportDataTableToExcel(dt);


        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();
    }
}