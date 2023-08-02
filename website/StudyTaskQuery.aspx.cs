using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

public partial class StudyTaskQuery : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnExport);
        AddPostbackControl(btnDownload);
        if (!IsPostBack)
        {
            if (DateTime.Now.Month >= 7)
            {
                tbEduYear.Text = (DateTime.Now.Year - 1911).ToString("000");
            }
            else
            {
                tbEduYear.Text = (DateTime.Now.Year - 1911 - 1).ToString("000");
            }

            rgData.DataSource = new List<FORM_DATA>();
            rgData.DataBind();

        }
    }

    private void ReadData()
    {
        if(tbTarget.Text.Trim() == "")
        {
            ShowMessage("請輸入職編或姓名");
            return;
        }
        
        List<FORM_DATA> list = service.GetStudyTaskFormData(Utility.GetNullString(tbEduYear.Text), rdpSendSDate.SelectedDate, rdpSendEDate.SelectedDate,
            Utility.GetNullString(tbTarget.Text), this.EmpCode);

        rgData.DataSource = list;
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        rgData.DataBind();
    }
    protected void rgData_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
    
    protected void rgData_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string instanceid = (e.Item as GridDataItem).GetDataKeyValue("INSTANCE_ID").ToString();
            HyperLink link = e.Item.FindControl("linkView") as HyperLink;
            if (link != null)
            {
                link.NavigateUrl = "InstanceDetial.aspx?instance_id=" + instanceid + "&mode=v";
                link.Target = "_blank";
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        rgData.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        rgData.ExportSettings.ExportOnlyData = true;
        rgData.ExportSettings.IgnorePaging = true;
        rgData.ExportSettings.OpenInNewWindow = true;
        rgData.MasterTableView.ExportToExcel();
    }
    protected void rgData_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        List<int> instanceids = new List<int>();
        foreach(GridDataItem item in rgData.Items)
        {
            int instanceid = Convert.ToInt32(item.GetDataKeyValue("PARENT_INSTANCE_ID"));
            if(!instanceids.Contains(instanceid))
            {
                instanceids.Add(instanceid);
            }
        }

        MemoryStream output = new MemoryStream();
        ZipOutputStream stream = new ZipOutputStream(output);
        stream.SetLevel(3);

        List<HtmlFormUtility.FORM_INSTANCES> instances = service.GetInstanceByInstanceIDs(instanceids);


        bool hasdata = false;

        foreach (HtmlFormUtility.FORM_INSTANCES ins in instances.Where(c => c.PARENT_INSTANCE_ID == null || instances.Count(d => d.INSTANCE_ID == c.PARENT_INSTANCE_ID) == 0))
        {

            if (instances.Where(c => c.PARENT_INSTANCE_ID == ins.INSTANCE_ID).Count() == 0)
            {
                //if (ins.Status != "0")
                //{

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
                //}
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
}