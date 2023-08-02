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

public partial class EduQuestionStatistic : AuthPage
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
        AddPostbackControl(btnQuery);

        if (!IsPostBack)
        {
            BindTemplate();
        }
    }

    private void BindTemplate()
    {
        List<FORM_TEMPLATEDto> list = service.GetQuestionTemplates();

        FORM_TEMPLATEDto nulldto = new FORM_TEMPLATEDto();

        rcbTemplateID.DataValueField = "TEMPLATE_ID";
        rcbTemplateID.DataTextField = "TEMPLATE_NAME";
        rcbTemplateID.DataSource = list;
        rcbTemplateID.DataBind();
    }

    private void RefreshHistory()
    {
        List<EduQuestionDto> list = service.GetEduQuestion(Convert.ToInt32(rcbTemplateID.SelectedValue));

        rgHistory.DataSource = list;
        ViewState["HistoryDataSource"] = list;

    }


    protected void rgHistory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RefreshHistory();
    }

    protected void rgHistory_ItemCreated(object sender, GridItemEventArgs e)
    {

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
        string id = null;
        if (item.GetDataKeyValue("ID") != null)
        {
            id = item.GetDataKeyValue("ID").ToString();
        }

        lbID.Text = id;


        ReadStatisticData();
        rgDetailList.DataBind();

        RadTabStrip1.SelectedIndex = 1;
        RadMultiPage1.SelectedIndex = 1;


    }

    private void ReadStatisticData()
    {
        if (lbID.Text != "")
        {
            string id = lbID.Text;
            int intid = Convert.ToInt32(id);

            List<EduQuestionDto> qlist = ViewState["HistoryDataSource"]  as List<EduQuestionDto>;

            EduQuestionDto q = qlist.Where(c => c.ID == intid).FirstOrDefault();


            List<STATISTIC_EXPEND_DATA_LIST> list = service.GetQuestionStatisticDataListByTemplateID(q.TEMPLATE_ID, q.Sdate, q.Edate);


            DataTable dt = new DataTable();
            dt.Columns.Add("表單序號");
            dt.Columns.Add("填寫時間");
            dt.Columns.Add("填寫人職編");
            dt.Columns.Add("填寫人姓名");


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

                }
                else
                {
                    row = dt.NewRow();
                    row["填寫時間"] = data.CreateDate.ToString("yyyy/MM/dd HH:mm");
                    row["表單序號"] = data.InstanceID.ToString();
                    row["填寫人職編"] = data.TargetID;
                    row["填寫人姓名"] = data.TargetName;

                    dt.Rows.Add(row);

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
            
            drsum[0] = "";
            drsum[1] = "";
            drsum[2] = "合計";
            dravg[0] = "";
            dravg[1] = "";
            dravg[2] = "平均";
            drmax[0] = "";
            drmax[1] = "";
            drmax[2] = "最大值";
            drmin[0] = "";
            drmin[1] = "";
            drmin[2] = "最小值";

            dt.Rows.Add(drsum);
            dt.Rows.Add(dravg);
            dt.Rows.Add(drmax);
            dt.Rows.Add(drmin);

            CurrentStatData = dt;

            rgDetailList.DataSource = dt;
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

        if (rcbTemplateID.SelectedValue == null || rcbTemplateID.SelectedValue == "")
        {
            ShowMessage("未選擇表單");
            return;
        }


        RefreshHistory();
        rgHistory.DataBind();
    }
}