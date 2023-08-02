using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using NPOI.HSSF.UserModel;
using Telerik.Web.UI;

public partial class EduStopActScheduleQuery : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnQuery);
        AddPostbackControl(btnExport);
        AddPostbackControl(btnDeptSum);
        if (!IsPostBack)
        {
            BindActType1();
            rcbType1_SelectedIndexChanged(rcbType1, null);

            BindDeptment();
        }

    }


    private void BindDeptment()
    {
        //DeptSelector1.Select(this.HospCode, "");
    }

    private void BindActType1()
    {
        List<EduActTypeDto> list = service.GetEduActType(0, -1);
        EduActTypeDto nullitem = new EduActTypeDto();
        rcbType1.DataValueField = "CLS_ID";
        rcbType1.DataTextField = "CLS_NAME";
        rcbType1.DataSource = list;
        rcbType1.DataBind();
        rcbType1.SelectedIndex = 0;
    }
    private void BindActType2()
    {
        List<EduActTypeDto> list = service.GetEduActType(1, Convert.ToInt32(rcbType1.SelectedValue));
        EduActTypeDto nullitem = new EduActTypeDto();
        nullitem.CLS_ID = -1;
        nullitem.CLS_NAME = "<不指定類型>";
        list.Insert(0, nullitem);

        rcbType2.DataValueField = "CLS_ID";
        rcbType2.DataTextField = "CLS_NAME";
        rcbType2.DataSource = list;
        rcbType2.DataBind();
        rcbType2.SelectedIndex = 0;
    }
    private void BindActType3()
    {
        List<EduActTypeDto> list = service.GetEduActType(2, Convert.ToInt32(rcbType2.SelectedValue));
        EduActTypeDto nullitem = new EduActTypeDto();
        nullitem.CLS_ID = -1;
        nullitem.CLS_NAME = "<不指定類型>";
        list.Insert(0, nullitem);

        rcbType3.DataValueField = "CLS_ID";
        rcbType3.DataTextField = "CLS_NAME";
        rcbType3.DataSource = list;
        rcbType3.DataBind();
        rcbType3.SelectedIndex = 0;
    }
    private void BindActType4()
    {
        List<EduActTypeDto> list = service.GetEduActType(3, Convert.ToInt32(rcbType3.SelectedValue));
        EduActTypeDto nullitem = new EduActTypeDto();
        nullitem.CLS_ID = -1;
        nullitem.CLS_NAME = "<不指定類型>";
        list.Insert(0, nullitem);

        rcbType4.DataValueField = "CLS_ID";
        rcbType4.DataTextField = "CLS_NAME";
        rcbType4.DataSource = list;
        rcbType4.DataBind();
        rcbType4.SelectedIndex = 0;
    }

    protected void rcbType1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindActType2();
        BindActType3();
        BindActType4();
    }
    protected void rcbType2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindActType3();
        BindActType4();
    }
    protected void rcbType3_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindActType4();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (rdpDateBegin.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(起)");
            return;
        }
        if (rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(訖)");
            return;
        }

        string acttypename = "";
        string acttype = "";
        if (rcbType4.Items.Count > 0 && rcbType4.SelectedValue != "-1")
        {
            acttype = rcbType4.SelectedValue;
            acttypename = rcbType4.Text;
        }
        else
        {
            if (rcbType3.Items.Count > 0 && rcbType3.SelectedValue != "-1")
            {
                acttype = rcbType3.SelectedValue;
                acttypename = rcbType3.Text;
            }
            else
            {
                if (rcbType2.Items.Count > 0 && rcbType2.SelectedValue != "-1")
                {
                    acttype = rcbType2.SelectedValue;
                    acttypename = rcbType2.Text;
                }
                else
                {
                    if (rcbType1.Items.Count > 0 && rcbType1.SelectedValue != "-1")
                    {
                        acttype = rcbType1.SelectedValue;
                        acttypename = rcbType1.Text;
                    }
                }
            }
        }
        List<string> roles = new List<string>();
        foreach (RadComboBoxItem item in rcbRole.CheckedItems)
        {
            roles.Add(item.Value);
        }


        List<string> emps = new List<string>();
        if (tbEmpCodes.Text.Trim() != "")
        {
            string[] empstr = tbEmpCodes.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string emp in empstr)
            {
                emps.Add(emp.Trim());
            }
        }


        List<EduStopActMemberList> list = service.GetEduStopActMemberList(acttype, rdpDateBegin.SelectedDate.Value, rdpDateEnd.SelectedDate.Value, roles, cbShowAllHosp.Checked ? null : DeptSelector1.SelectDept, cbShowAllHosp.Checked ? null : DeptSelector1.SelectHospCode, cbShowAll.Checked, emps, tbKeyWord.Text.Trim());

        Dictionary<string, string> map = new Dictionary<string, string>();
        map.Add("ActName", "公告主題");
        map.Add("DepCode", "公告科室代號");
        map.Add("DepName", "公告科室名稱");
        map.Add("HospName", "參與人院區");
        map.Add("EmpCode", "參與人職編");
        map.Add("EmpName", "參與人姓名");
        map.Add("JobName", "參與人職稱");
        map.Add("RoleName", "擔任角色");
        map.Add("ActTypeName", "公告類型");
        map.Add("Sdate", "開始時間");
        map.Add("Edate", "結束時間");
        map.Add("ActTimeCount", "公告時數");
        map.Add("HasAttachment", "附加檔");
        Utility uti = new Utility();
        DataTable dt = uti.ConvertToDataTable(list, map, "list");

        byte[] bytes = uti.ExportDataTableToExcel(dt);


        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(acttypename) + ".xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();

    }
    protected void rcbRole_DataBound(object sender, EventArgs e)
    {
        foreach (RadComboBoxItem item in rcbRole.Items)
        {
            item.Checked = true;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (rdpDateBegin.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(起)");
            return;
        }
        if (rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(訖)");
            return;
        }
        string acttypename = "";
        string acttype = "";
        if (rcbType4.Items.Count > 0 && rcbType4.SelectedValue != "-1")
        {
            acttype = rcbType4.SelectedValue;
            acttypename = rcbType4.Text;
        }
        else
        {
            if (rcbType3.Items.Count > 0 && rcbType3.SelectedValue != "-1")
            {
                acttype = rcbType3.SelectedValue;
                acttypename = rcbType3.Text;
            }
            else
            {
                if (rcbType2.Items.Count > 0 && rcbType2.SelectedValue != "-1")
                {
                    acttype = rcbType2.SelectedValue;
                    acttypename = rcbType2.Text;
                }
                else
                {
                    if (rcbType1.Items.Count > 0 && rcbType1.SelectedValue != "-1")
                    {
                        acttype = rcbType1.SelectedValue;
                        acttypename = rcbType1.Text;
                    }
                }
            }
        }

        List<string> emps = new List<string>();
        if (tbEmpCodes.Text.Trim() != "")
        {
            string[] empstr = tbEmpCodes.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string emp in empstr)
            {
                emps.Add(emp.Trim());
            }
        }

        List<EduStopActList> list = service.GetEduStopActList(acttype, rdpDateBegin.SelectedDate.Value, rdpDateEnd.SelectedDate.Value, cbShowAllHosp.Checked ? null : DeptSelector1.SelectDept, cbShowAllHosp.Checked ? null : DeptSelector1.SelectHospCode, cbShowAll.Checked, cbAttachment.Checked, emps, tbKeyWord.Text.Trim());



        int maxattcount = 0;
        foreach (EduStopActList d in list)
        {
            if (d.AttachmentsUrls.Count > maxattcount)
            {
                maxattcount = d.AttachmentsUrls.Count;
            }
        }

        HSSFWorkbook workbook = new HSSFWorkbook();
        HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("工作表1");
        //顯示 Table 0 的所有欄位名稱
        HSSFRow titleRow1 = (HSSFRow)sheet.CreateRow(0);
        string title = DeptSelector1.SelectHospName + " " + DeptSelector1.SelectDeptName;
        titleRow1.CreateCell(0).SetCellValue(title);
        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 16));

        HSSFRow titleRow2 = (HSSFRow)sheet.CreateRow(1);
        string title2 = acttypename + " " + rdpDateBegin.SelectedDate.Value.ToString("yyyy/MM/dd") + "-" + rdpDateEnd.SelectedDate.Value.ToString("yyyy/MM/dd");
        titleRow2.CreateCell(0).SetCellValue(title2);
        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 16));

        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(2);

        headerRow.CreateCell(0).SetCellValue("序號");
        headerRow.CreateCell(1).SetCellValue("公告主題");
        headerRow.CreateCell(2).SetCellValue("公告科室代號");
        headerRow.CreateCell(3).SetCellValue("公告科室名稱");
        headerRow.CreateCell(4).SetCellValue("建立人職編");
        headerRow.CreateCell(5).SetCellValue("建立人姓名");
        headerRow.CreateCell(6).SetCellValue("公告類型");
        headerRow.CreateCell(7).SetCellValue("開始日期");
        headerRow.CreateCell(8).SetCellValue("開始時間");
        headerRow.CreateCell(9).SetCellValue("結束日期");
        headerRow.CreateCell(10).SetCellValue("結束時間");
        headerRow.CreateCell(11).SetCellValue("公告時數");
        headerRow.CreateCell(12).SetCellValue("地點");
        headerRow.CreateCell(13).SetCellValue("主持人");
        headerRow.CreateCell(14).SetCellValue("主講者/授課演講者");
        headerRow.CreateCell(15).SetCellValue("附加檔");

        for (int i = 1; i <= maxattcount; i++)
        {
            headerRow.CreateCell(15 + i).SetCellValue("附件" + i.ToString());
        }

        string url = "http://www2.kmuh.org.tw/web/EduActivity";

        int rowIndex = 3;
        foreach (EduStopActList d in list)
        {
            HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
            dataRow.CreateCell(0).SetCellValue(d.SerialNo);
            dataRow.CreateCell(1).SetCellValue(d.ActName);
            dataRow.CreateCell(2).SetCellValue(d.DepCode);
            dataRow.CreateCell(3).SetCellValue(d.DepName);
            dataRow.CreateCell(4).SetCellValue(d.EmpCode);
            dataRow.CreateCell(5).SetCellValue(d.EmpName);
            dataRow.CreateCell(6).SetCellValue(d.ActTypeName);
            dataRow.CreateCell(7).SetCellValue(d.SdateStr);
            dataRow.CreateCell(8).SetCellValue(d.StimeStr);
            dataRow.CreateCell(9).SetCellValue(d.EdateStr);
            dataRow.CreateCell(10).SetCellValue(d.EtimeStr);
            dataRow.CreateCell(11).SetCellValue(d.ActTimeCount);
            dataRow.CreateCell(12).SetCellValue(d.Location);
            dataRow.CreateCell(13).SetCellValue(d.RoleName);
            dataRow.CreateCell(14).SetCellValue(d.TeacherName);
            dataRow.CreateCell(15).SetCellValue(d.HasAttachment);

            for (int i = 0; i < d.AttachmentsUrls.Count; i++)
            {
                HSSFHyperlink url_link = new HSSFHyperlink(NPOI.SS.UserModel.HyperlinkType.Url);
                url_link.Address = url + "/DownloadActAttachment.aspx?ID=" + d.AttachmentsUrls[i][0];

                HSSFCell cell = dataRow.CreateCell(15 + i + 1) as HSSFCell;
                cell.SetCellValue(d.AttachmentsUrls[i][1]);
                cell.Hyperlink = url_link;
            }

            dataRow = null;
            rowIndex++;
        }


        // 產生 Excel 資料流
        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        headerRow = null;
        sheet = null;
        workbook = null;


        byte[] bytes = ms.ToArray();



        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(acttypename) + ".xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();
    }
    protected void btnDeptSum_Click(object sender, EventArgs e)
    {
        if (rdpDateBegin.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(起)");
            return;
        }
        if (rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("未選擇舉辦日期(訖)");
            return;
        }

        DataTable dt = service.GetEduStopDeptSumList(rdpDateBegin.SelectedDate.Value, rdpDateEnd.SelectedDate.Value, cbShowAllHosp.Checked ? null : DeptSelector1.SelectHospCode, tbKeyWord.Text.Trim());


        Utility uti = new Utility();


        byte[] bytes = uti.ExportDataTableToExcel(dt);


        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("部門開課總表") + ".xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();
    }
}