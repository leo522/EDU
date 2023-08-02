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

public partial class EduStatistic : AuthPage
{
    private string EduTermID
    {
        get
        {
            return Request.QueryString["edutermid"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(rgHistory);
        AddPostbackControl(btnExport);
    }

    private void RefreshHistory()
    {
        if (EduTermID != null)
        {
            List<EduFormTemplateListDto> list = service.GetEvalStasticData(EduTermID, null, this.HospCode);
            rgHistory.DataSource = list;
            ViewState["HistoryDataSource"] = list;
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

            string FTListID = null;
            int templateid = 0;

            if (item.GetDataKeyValue("FTListID") != null)
            {
                FTListID = item.GetDataKeyValue("FTListID").ToString();
            }

            if (item.GetDataKeyValue("TEMPLATE_ID") != null)
            {
                templateid = Convert.ToInt32(item.GetDataKeyValue("TEMPLATE_ID").ToString());
            }

            EduFormTemplateListDto dto = datasoure.Where(c => c.FTListID == FTListID && c.TEMPLATE_ID == templateid).FirstOrDefault();
            if (dto != null)
            {
                if (dto.StasticPermissionRoles != null)
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
                        LinkButton lbtnStatistic = item.FindControl("lbtnStatistic") as LinkButton;
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
        
        string ftlistid = null;

        int templateid = 0;
        if (item.GetDataKeyValue("FTListID") != null)
        {
            ftlistid = item.GetDataKeyValue("FTListID").ToString();
        }

        if (item.GetDataKeyValue("TEMPLATE_ID") != null)
        {
            templateid = Convert.ToInt32(item.GetDataKeyValue("TEMPLATE_ID"));
        }

        EduFormTemplateListDto ftlist = service.GetEduFormTemplateList(EduTermID, templateid.ToString());

        List<HtmlFormUtility.FORM_INSTANCES> instances = service.GetInstanceByInhospid(EduTermID, templateid.ToString(), true);

        bool hasdata = false;

        foreach (HtmlFormUtility.FORM_INSTANCES ins in instances.Where(c => c.PARENT_INSTANCE_ID == null))
        {

            if (instances.Where(c => c.PARENT_INSTANCE_ID == ins.INSTANCE_ID).Count() == 0)
            {
                if (ins.Status != "0")
                {

                    hasdata = true;
                    byte[] space = new byte[] { 0xc2, 0xa0 };
                    string UTFSpace = System.Text.Encoding.GetEncoding("UTF-8").GetString(space);
                    byte[] binaryData = System.Text.Encoding.Default.GetBytes(ins.INSTANCE_CONTENT.Replace("charset=utf-8", "charset=big5").Replace(UTFSpace, "&nbsp;"));
                    //binaryData = System.Text.Encoding.Convert(System.Text.Encoding.Default, System.Text.Encoding.UTF8, binaryData);
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
                    //stream.PutNextEntry(new ZipEntry(targetname + ins.INSTANCE_NAME + evaltarget + ".pdf"));

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
        string ftlistid = null;
        if (item.GetDataKeyValue("FTListID") != null)
        {
            ftlistid = item.GetDataKeyValue("FTListID").ToString();
        }

        if (item.GetDataKeyValue("TEMPLATE_ID") != null)
        {
            templateid = Convert.ToInt32(item.GetDataKeyValue("TEMPLATE_ID"));
        }
        lbFtlistid.Text = ftlistid;
        lbTemplateid.Text = templateid.ToString();

        ReadStatisticData();
        rgDetailList.DataBind();

        RadTabStrip1.SelectedIndex = 1;
        RadMultiPage1.SelectedIndex = 1;
    }

    private void ReadStatisticData()
    {
        if (lbTemplateid.Text!="")
        {
            string ftlistid = lbFtlistid.Text;

            int templateid = Convert.ToInt32(lbTemplateid.Text);

            List<STATISTIC_EXPEND_DATA_LIST> list = service.GetStatisticDataListByTerm(templateid, EduTermID);


            DataTable dt = new DataTable();
            dt.Columns.Add("表單序號");
            dt.Columns.Add("填寫人職編");
            dt.Columns.Add("填寫人姓名");
            dt.Columns.Add("填寫狀態");
            dt.Columns.Add("考核對象");

            foreach (string group in list.Select(c => c.GroupName).Distinct())
            {
                dt.Columns.Add(group);
            }

            Dictionary<string, int> statuscount = new Dictionary<string, int>();

            foreach (STATISTIC_EXPEND_DATA_LIST data in list)
            {

                DataRow[] rows = dt.Select("填寫人職編 = '" + data.TargetID + "'  and 表單序號=" + data.InstanceID + " ");
                DataRow row;
                if (rows.Length > 0)
                {
                    row = rows[0];
                }
                else
                {
                    row = dt.NewRow();
                    row["表單序號"] = data.InstanceID;
                    row["填寫人職編"] = data.TargetID;
                    row["填寫人姓名"] = data.TargetName;
                    row["填寫狀態"] = data.StatusName;
                    row["考核對象"] = data.EvalTargetName;
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

            rgDetailList.DataSource = dt;
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        rgDetailList.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        rgDetailList.ExportSettings.ExportOnlyData = true;
        rgDetailList.ExportSettings.IgnorePaging = true;
        rgDetailList.ExportSettings.OpenInNewWindow = true;
        rgDetailList.MasterTableView.ExportToExcel();
    }
    protected void rgDetailList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadStatisticData();
    }

    private void ReadTermData()
    {
        List<EduTermDto> list = service.GetEduTerms(tbEduStopCode.Text, tbEduName.Text);
        rgTerm.DataSource = list;
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadTermData();
        rgTerm.DataBind();
    }
    protected void btnListQuery_Click(object sender, EventArgs e)
    {
        if (rgTerm.SelectedItems.Count > 0)
        {
            List<string> edutermlist = new List<string>();
            edutermlist.Add((rgTerm.SelectedItems[0] as GridDataItem).GetDataKeyValue("EduTermID").ToString());

        }
    }
}