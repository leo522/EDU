using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class iKASA_ERpassport : iKASAPageBase
{
    private List<IPDNoteObject> CurrentIPDNotes
    {
        get
        {
            return ViewState["currentIPDNotes"] as List<IPDNoteObject>;
        }
        set
        {
            ViewState["currentIPDNotes"] = value;
        }
    }

    private List<ERMemsObject> CurrentERMems
    {
        get
        {
            return ViewState["CurrentERMems"] as List<ERMemsObject>;
        }
        set
        {
            ViewState["CurrentERMems"] = value;
        }
    }
    
    private List<IKASA_ERCaseDto> CurrentERCase
    {
        get
        {
            return ViewState["CurrentERCase"] as List<IKASA_ERCaseDto>;
        }
        set
        {
            ViewState["CurrentERCase"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //RadGrid1.NeedDataSource += RadGrid1_NeedDataSource;
            rmp.SelectedIndex = 0;
            ReadERCase();
            RadGrid3.DataBind();
        }
    }

    protected void btnToGet_Click(object sender, EventArgs e)
    {
        rmp.SelectedIndex = 3;
    }
    protected void btnToList_Click(object sender, EventArgs e)
    {
        rmp.SelectedIndex = 0;
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if(rdpSdate.SelectedDate == null)
        {
            ShowMessage("請選擇開始時間");
            return;
        }
        if (rdpEdate.SelectedDate == null)
        {
            ShowMessage("請選擇結束時間");
            return;
        }
        ReadIPDNotes();
        RadGrid1.DataBind();
    }

    private void ReadIPDNotes()
    {
        var result = service.GetIPDNoteData(this.CurrentPersonInfo.empcode, rdpSdate.SelectedDate.Value, rdpEdate.SelectedDate.Value);
        CurrentIPDNotes = result;
        RadGrid1.DataSource = CurrentIPDNotes;
    }

    private void ReadERmems()
    {
        var result = service.GetERmems(this.CurrentPersonInfo.empcode, rdpSdate0.SelectedDate.Value, rdpEdate0.SelectedDate.Value, tbChartNo.Text.Trim());
        CurrentERMems = result;
        RadGrid2.DataSource = CurrentERMems;
    }

    private void ReadERCase()
    {
        CurrentERCase = service.GetERCase(this.CurrentPersonInfo.empcode);

        int count0100 = CurrentERCase.Count(c => c.DEPT_NAME == "急診內科");
        int count0200 = CurrentERCase.Count(c => c.DEPT_NAME == "急診外傷科");
        int count0300 = CurrentERCase.Count(c => c.DEPT_NAME == "急診兒科");
        int countall = CurrentERCase.Count();

        int req0100 = 0;
        int req0200 = Convert.ToInt32(lbReq0200.Text);
        int req0300 = Convert.ToInt32(lbReq0300.Text);
        int reqall = Convert.ToInt32(lbReqAll.Text);

        if(count0100 < req0100)
        {
            lbCount0100.ForeColor = Color.Red;
        }
        lbCount0100.Text = count0100.ToString();

        if (count0200 < req0200)
        {
            lbCount0200.ForeColor = Color.Red;
        }
        lbCount0200.Text = count0200.ToString();

        if (count0300 < req0300)
        {
            lbCount0300.ForeColor = Color.Red;
        }
        lbCount0300.Text = count0300.ToString();

        if (countall < reqall)
        {
            lbCountAll.ForeColor = Color.Red;
        }
        lbCountAll.Text = countall.ToString();


        RadGrid3.DataSource = CurrentERCase;
        

    }

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        //if (IsPostBack)
        //{
        //    if (rdpSdate.SelectedDate == null || rdpEdate.SelectedDate == null)
        //    {
        //        return;
        //    }
        //    if (CurrentIPDNotes == null)
        //    {
        //        ReadIPDNotes();
        //    }
        //    else
        //    {
        //        RadGrid1.DataSource = CurrentIPDNotes;
        //    }
        //}
    }

    protected void btnShowDetail_Click(object sender, EventArgs e)
    {
        Button Button = (Button)sender;
        GridDataItem item = (GridDataItem)Button.NamingContainer;
        string serialno = item.GetDataKeyValue("SERIALNO").ToString();
        var note = CurrentIPDNotes.Where(c => c.SERIALNO == serialno).FirstOrDefault();
        liDetail.Text = note.NOTE_DATA;
        rmp.SelectedIndex = 2;
        
    }
    protected void btnQuery0_Click(object sender, EventArgs e)
    {
        if (rdpSdate0.SelectedDate == null)
        {
            ShowMessage("請選擇開始時間");
            return;
        }
        if (rdpEdate0.SelectedDate == null)
        {
            ShowMessage("請選擇結束時間");
            return;
        }

        if(tbChartNo.Text.Trim().Length>0 && tbChartNo.Text.Trim().Length!= 8)
        {
            ShowMessage("病歷號碼錯誤");
            return;
        }

        ReadERmems();
            RadGrid2.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        List<IKASA_ERCaseDto> addlist = new List<IKASA_ERCaseDto>();
        foreach(var selitem in RadGrid2.SelectedItems)
        {
            GridDataItem di = selitem as GridDataItem;

            string procedure = (di.FindControl("ddlProcedure") as DropDownList).SelectedValue;
            //if(procedure == null || procedure == "")
            //{
            //    ShowMessage("勾選項目未選擇procedure");
            //    return;
            //}

            string id = di.GetDataKeyValue("SERIALNO").ToString();

            var mem = CurrentERMems.Where(c => c.SERIALNO == id).FirstOrDefault();
            if (mem != null)
            {
                IKASA_ERCaseDto dto = new IKASA_ERCaseDto();
                dto.CHART_NO = mem.CHART_NO;
                dto.DEPT_CODE = mem.DEPT_CODE;
                dto.DISEASE_CLASS = mem.DISEASE_CLASS;
                dto.DEPT_NAME = mem.DEPT_NAME;
                dto.EMPCODE = this.CurrentPersonInfo.empcode;
                dto.ICD_CODE = mem.icd_code;
                dto.ICD_NAME = mem.chinese_name;
                dto.IN_DATE = DateTime.ParseExact((mem.ENTER_DATE + 19110000).ToString(), "yyyyMMdd", null);
                dto.PROCEDURE = procedure;
                dto.SOURCE_ID = mem.SERIALNO;
                dto.SOURCE_SYSTEM = "ERMems";
                addlist.Add(dto);
            }
        }

        string result = service.CreateERCase(addlist);
        if(result!= null)
        {
            ShowMessage("勾選項目未選擇procedure");
            return;
        }
        else
        {
            ReadERmems();
            
            RadGrid2.DataBind();
            ReadERCase();
            RadGrid3.DataBind();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        RadGrid3.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        RadGrid3.ExportSettings.ExportOnlyData = true;
        RadGrid3.ExportSettings.IgnorePaging = true;
        RadGrid3.ExportSettings.OpenInNewWindow = true;
        RadGrid3.MasterTableView.ExportToExcel();
    }
    protected void RadGrid3_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid3.DataSource = CurrentERCase;
    }
    protected void RadGrid3_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        int id = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("ID"));
        IKASA_ERCaseDto ca = CurrentERCase.Where(c => c.ID == id).FirstOrDefault();

        string result = service.DeleteERCase(ca);
        if (result != null)
        {
            ShowMessage("刪除失敗:" + result);
        }
        else
        {
            ReadERCase();
            RadGrid3.DataBind();
        }
        
    }
    protected void RadGrid3_UpdateCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void RadGrid3_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int ID = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("ID"));
            var data = CurrentERCase.Where(c => c.ID == ID).FirstOrDefault();
            if (data != null)
            {
                
                TextBox tbicdname = e.Item.FindControl("tbICDName") as TextBox;
                if (tbicdname != null)
                {
                    if (data.ICD_NAME != null)
                    {
                        tbicdname.Text = data.ICD_NAME.Trim();
                    }
                    if(data.STATUS == "1" || data.STATUS == "V")
                    {
                        tbicdname.Enabled = false;
                    }
                }

                DropDownList ddlprocedure = e.Item.FindControl("ddlProcedure") as DropDownList;
                if (ddlprocedure != null)
                {
                    ddlprocedure.SelectedValue = data.PROCEDURE;
                    if (data.STATUS == "1" || data.STATUS == "V")
                    {
                        ddlprocedure.Enabled = false;
                    }
                }

                Button btnSave = e.Item.FindControl("btnSave") as Button;
                if (btnSave != null)
                {
                    if (data.STATUS == "1" || data.STATUS == "V")
                    {
                        btnSave.Enabled = false;
                    }
                }
                Button btnSubmit = e.Item.FindControl("btnSubmit") as Button;
                if (btnSubmit != null)
                {
                    if (data.STATUS == "1" || data.STATUS == "V")
                    {
                        btnSubmit.Enabled = false;
                    }
                }

                Button btnSubmitDOPS = e.Item.FindControl("btnSubmitDOPS") as Button;
                if (btnSubmitDOPS != null)
                {
                    if(data.DOPSStatus == "V")
                    {
                        btnSubmitDOPS.BackColor = Color.Green;
                    }
                    if(data.DOPSStatus == "0")
                    {
                        btnSubmitDOPS.BackColor = Color.Blue;
                    }
                }


                Button btnSubmitEPA = e.Item.FindControl("btnSubmitEPA") as Button;
                if (btnSubmitEPA != null)
                {
                    if (data.EPAStatus == "V")
                    {
                        btnSubmitEPA.BackColor = Color.Green;
                    }
                    if (data.EPAStatus == "0")
                    {
                        btnSubmitEPA.BackColor = Color.Blue;
                    }
                }
            }
        }
    }
    protected void RadGrid3_ItemCommand(object sender, GridCommandEventArgs e)
    {

        if (e.Item is GridDataItem)
        {
            int ID = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("ID"));
            var data = CurrentERCase.Where(c => c.ID == ID).FirstOrDefault();
            if (data != null)
            {
                //儲存
                if (e.CommandName == "SaveChange")
                {
                    TextBox tbicdname = e.Item.FindControl("tbICDName") as TextBox;
                    if (tbicdname != null)
                    {
                        data.ICD_NAME = tbicdname.Text;
                    }

                    DropDownList ddlprocedure = e.Item.FindControl("ddlProcedure") as DropDownList;
                    if (ddlprocedure != null)
                    {
                        data.PROCEDURE = ddlprocedure.SelectedValue;
                    }

                    string result = service.UpdateERCase(data);
                    if (result != null)
                    {
                        ShowMessage("儲存失敗:" + result);
                    }
                    else
                    {
                        ReadERCase();
                        RadGrid3.DataBind();
                    }
                }

                if (e.CommandName == "SubmitItemDOPS")
                {
                    Response.Redirect("ERDOPS.aspx?CaseID=" + ID.ToString());
                }

                if (e.CommandName == "SubmitItemEPA")
                {
                    Response.Redirect("EREPA.aspx?CaseID=" + ID.ToString());
                }

            }
        }
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        lbMsg.Text = "";
        try
        {
            if (!fuImport.HasFile)
            {
                ShowMessage("未選擇檔案");
                return;
            }

            string filename = Server.MapPath("~") + "\\temp\\" + Guid.NewGuid() + fuImport.FileName;
            fuImport.SaveAs(filename);

            DataTable dt = Utility.ReadExcelAsTableNPOI(filename);

            try
            {
                File.Delete(filename);
            }
            catch (Exception ex)
            {
            }
            List<IKASA_ERCaseDto> list = new List<IKASA_ERCaseDto>();

            foreach(DataRow dr in dt.Rows)
            {
                if (dr["職編"].ToString() != "")
                {
                    string[] pros = dr["procedure"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    if (pros.Length > 0)
                    {
                        foreach (string proc in pros)
                        {
                            IKASA_ERCaseDto dto = new IKASA_ERCaseDto();
                            dto.SOURCE_SYSTEM = "Import";
                            dto.CHART_NO = dr["病歷號"].ToString();
                            dto.DEPT_NAME = dr["科別"].ToString();
                            dto.DISEASE_CLASS = dr["檢傷級數"].ToString();
                            dto.EMPCODE = dr["職編"].ToString();
                            dto.IN_DATE = Convert.ToDateTime(dr["日期"]);
                            dto.ICD_NAME = dr["診斷"].ToString();
                            dto.PROCEDURE = proc;
                            list.Add(dto);
                        }
                    }
                    else
                    {

                        IKASA_ERCaseDto dto = new IKASA_ERCaseDto();
                        dto.SOURCE_SYSTEM = "Import";
                        dto.CHART_NO = dr["病歷號"].ToString();
                        dto.DEPT_NAME = dr["科別"].ToString();
                        dto.DISEASE_CLASS = dr["檢傷級數"].ToString();
                        dto.EMPCODE = dr["職編"].ToString();
                        dto.IN_DATE = Convert.ToDateTime(dr["日期"]);
                        dto.ICD_NAME = dr["診斷"].ToString();
                        list.Add(dto);
                    }
                }
            }

            string result = service.CreateERCase(list);

            if(result!= null)
            {
                lbMsg.Text += "<font color='red'>" + result + "</font><br/>";
            }
            else
            {
                ReadERCase();
                RadGrid3.DataBind();
            }
        }
        catch (Exception ex)
        {
            lbMsg.Text = "<font color='red'>匯入資料失敗:" + ex.Message + "</font><br/>";
        }
    }
    protected void btnSaveAll_Click(object sender, EventArgs e)
    {
        try
        {
            string result = null;
            int count = 0;
            foreach (GridDataItem item in RadGrid3.Items)
            {

                if (item is GridDataItem)
                {

                    int ID = Convert.ToInt32((item as GridDataItem).GetDataKeyValue("ID"));
                    var data = CurrentERCase.Where(c => c.ID == ID).FirstOrDefault();
                    if (data != null)
                    {
                        TextBox tbicdname = item.FindControl("tbICDName") as TextBox;
                        if (tbicdname != null)
                        {
                            data.ICD_NAME = tbicdname.Text;
                        }

                        DropDownList ddlprocedure = item.FindControl("ddlProcedure") as DropDownList;
                        if (ddlprocedure != null)
                        {
                            data.PROCEDURE = ddlprocedure.SelectedValue;
                        }

                        result = service.UpdateERCase(data);
                        if (result != null)
                        {
                            break;
                        }
                    }

                    count++;
                }
            }

            if (result != null)
            {
                ShowMessage("第" + (count + 1).ToString() + "筆資料儲存儲存失敗:" + result + "，請重試");
            }
            else
            {
                ShowMessage("儲存完成");
                ReadERCase();
                RadGrid3.DataBind();
            }
        }
        catch(Exception ex)
        {
            ShowMessage("儲存失敗:" + ex.Message + "，請重試");
        }
    }
    protected void btnDelAll_Click(object sender, EventArgs e)
    {
        string result = null;

        foreach(GridDataItem item in RadGrid3.SelectedItems)
        {

            int id = Convert.ToInt32((item as GridDataItem).GetDataKeyValue("ID"));
            IKASA_ERCaseDto ca = CurrentERCase.Where(c => c.ID == id).FirstOrDefault();

            result = service.DeleteERCase(ca);
            if (result != null)
            {
                break;
            }
        }

        if (result != null)
        {
            ShowMessage("刪除失敗:" + result);
        }
        else
        {
            ReadERCase();
            RadGrid3.DataBind();
        }

    }
}