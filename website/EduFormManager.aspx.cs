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

public partial class EduFormManager : AuthPage
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

            BindDept();
            if (!new string[] { "7102", "7101", "7100" }.Contains(DeptCode))
            {
                ddlUnit.SelectedValue = this.DeptCode;
            }
            else
            {
                ddlUnit.SelectedValue = null;
            }
            BindTemplate();
            rgData.DataSource = new List<FORM_DATA>();
            rgData.DataBind();

            if (this.AuthRoles.Contains("Admin") || this.AuthRoles.Contains("DepSec"))
            {
                panAdmin.Visible = true;
            }
            else
            {
                panAdmin.Visible = false;
            }

            if (this.AuthRoles.Contains("SuperAdmin") || this.AuthRoles.Contains("Admin"))
            {
                btnDelete.Visible = true;
                Label17.Visible = true;
                rdpChangeExpireDate.Visible = true;
                btnChangeExpireDate.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
                Label17.Visible = false;
                rdpChangeExpireDate.Visible = false;
                btnChangeExpireDate.Visible = false;
            }

        }
    }

    private void BindTemplate()
    {
        List<FORM_TEMPLATEDto> list = service.GetTemplates(this.HospCode);

        FORM_TEMPLATEDto nulldto = new FORM_TEMPLATEDto();
        nulldto.TEMPLATE_ID = -1;
        nulldto.TEMPLATE_NAME = "全部";

        list.Insert(0, nulldto);

        rcbTemplateID.DataValueField = "TEMPLATE_ID";
        rcbTemplateID.DataTextField = "TEMPLATE_NAME";
        rcbTemplateID.DataSource = list;
        rcbTemplateID.DataBind();
    }

    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        SelectGroupTypeDto nullitem = new SelectGroupTypeDto();
        nullitem.code = null;
        nullitem.name = "";
        list.Insert(0, nullitem);
        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();
    }

    private void ReadData()
    {
        List<string> jobcodes = null;
        if (rddtJobCode.SelectedValue != "")
        {
            jobcodes = rddtJobCode.SelectedValue.Split(',').ToList();
        }

        int? templateid = null;
        if (rcbTemplateID.SelectedValue != null && rcbTemplateID.SelectedValue != "-1")
        {
            templateid = Utility.GetNullInt(rcbTemplateID.SelectedValue);
        }

        List<FORM_DATA> list = service.GetFormData(Utility.GetNullString(tbEduYear.Text), jobcodes, Utility.GetNullString(ddlUnit.SelectedValue),
            Utility.GetNullString(tbEduTermName.Text), Utility.GetNullInt(tbInstaneID.Text), templateid,
            rdpExpireSDate.SelectedDate, rdpExpireEDate.SelectedDate, rdpSendSDate.SelectedDate, rdpSendEDate.SelectedDate,
            Utility.GetNullString(tbTarget.Text), Utility.GetNullString(tbEvalTarget.Text), rcbStatus.SelectedValue, cbDisplaySelf.Checked, cbOverLimit.Checked, this.EmpCode);

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
    protected void btnToNotFinish_Click(object sender, EventArgs e)
    {
        List<FORM_INSTANCE_TARGETDto> list = new List<FORM_INSTANCE_TARGETDto>();
        foreach (GridDataItem item in rgData.SelectedItems)
        {
            int instanceid = Convert.ToInt32(item.GetDataKeyValue("INSTANCE_ID"));
            string targettype = item.GetDataKeyValue("TargetType").ToString();
            string targetid = item.GetDataKeyValue("TargetID").ToString();

            FORM_INSTANCE_TARGETDto dto = new FORM_INSTANCE_TARGETDto();
            dto.INSTANCE_ID = instanceid;
            dto.TargetType = targettype;
            dto.TargetID = targetid;

            dto.Status = '0';
            list.Add(dto);
        }
        bool success = service.UpdateFormInstanceTargetStatus(list);
        if (!success)
        {
            ShowMessage("更新失敗,請重試");
            return;
        }
        else
        {
            ReadData();
            rgData.DataBind();
        }
    }
    protected void btnChangeExpireDate_Click(object sender, EventArgs e)
    {
        if (rdpChangeExpireDate.SelectedDate == null)
        {
            ShowMessage("請選擇逾期日期");
            return;
        }

        List<int> instanceids = new List<int>();

        foreach (GridDataItem item in rgData.SelectedItems)
        {
            int instanceid = Convert.ToInt32(item.GetDataKeyValue("INSTANCE_ID"));
            string targettype = item.GetDataKeyValue("TargetType").ToString();
            string targetid = item.GetDataKeyValue("TargetID").ToString();

            instanceids.Add(instanceid);
        }


        service.UpdateFormInstanceExpireDate(instanceids, rdpChangeExpireDate.SelectedDate.Value);

        foreach (int instid in instanceids)
        {
            service.WriteFormInstanceTransLog(instid, this.EmpCode, "更改逾期日", null, rdpChangeExpireDate.SelectedDate.Value.ToString("yyyy/MM/dd"));
        }


        ReadData();
        rgData.DataBind();


    }
    protected void btnChangeTargetID_Click(object sender, EventArgs e)
    {
        if (VsSelector1.SelectedValue == "" || VsSelector1.SelectedValue == null)
        {
            ShowMessage("請選擇更改對象");
            return;
        }
        List<FORM_INSTANCE_TARGETDto> list = new List<FORM_INSTANCE_TARGETDto>();
        foreach (GridDataItem item in rgData.SelectedItems)
        {
            int instanceid = Convert.ToInt32(item.GetDataKeyValue("INSTANCE_ID"));
            string targettype = item.GetDataKeyValue("TargetType").ToString();
            string targetid = item.GetDataKeyValue("TargetID").ToString();
            
            FORM_INSTANCE_TARGETDto dto = new FORM_INSTANCE_TARGETDto();
            dto.INSTANCE_ID = instanceid;
            dto.TargetType = targettype;
            dto.TargetID = targetid;
            list.Add(dto);

        }
        bool success = service.UpdateFormInstanceTarget(list, VsSelector1.SelectedValue);

        if (!success)
        {
            ShowMessage("更新失敗,請重試");
            return;
        }
        else
        {
            foreach(FORM_INSTANCE_TARGETDto dto in list)
            {
                service.WriteFormInstanceTransLog(dto.INSTANCE_ID, this.EmpCode, "更改對像(" + dto.TargetType + ")", dto.TargetID, VsSelector1.SelectedValue);
            }


            ReadData();
            rgData.DataBind();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in rgData.SelectedItems)
        {
            int instanceid = Convert.ToInt32(item.GetDataKeyValue("INSTANCE_ID"));
            string targettype = item.GetDataKeyValue("TargetType").ToString();
            string targetid = item.GetDataKeyValue("TargetID").ToString();

            HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
            pc.DeleteInstance(instanceid);

            service.WriteFormInstanceTransLog(instanceid, this.EmpCode, "刪除表單", "", "");

        }

        ReadData();
        rgData.DataBind();

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
            int instanceid = Convert.ToInt32(item.GetDataKeyValue("INSTANCE_ID"));
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
}