using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;
using Telerik.Web.UI;
using System.IO;
using NPOI.HSSF.UserModel;

public partial class TeachPointQuery : AuthPage
{
    protected List<TeachPointCalcTypeDto> CurrentTeachPointCalcTypes
    {
        get
        {
            return ViewState["CurrentTeachPointCalcTypes"] as List<TeachPointCalcTypeDto>;
        }
        set
        {
            ViewState["CurrentTeachPointCalcTypes"] = value;
        }
    }

    protected List<TeachPointCalcSumData> CurrentTeachPointCalcSumData
    {
        get
        {
            return ViewState["CurrentTeachPointCalcSumData"] as List<TeachPointCalcSumData>;
        }
        set
        {
            ViewState["CurrentTeachPointCalcSumData"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnExport);
        if (!IsPostBack)
        {
            BindCalcType();

            if (this.AuthRoles.Contains("Admin") || this.AuthRoles.Contains("DepSec"))
            {
                tbEmpCodes.Enabled = true;
                tbEmpCodes.Text = "";
            }
            else
            {
                tbEmpCodes.Enabled = false;
                tbEmpCodes.Text = this.EmpCode;
            }


            int cyear = DateTime.Now.Year - 1911;

            for (int i = 0; i < 10; i++)
            {
                ddlEduYear.Items.Add(new ListItem((cyear - i).ToString(), (cyear - i).ToString()));
            }
        }
    }



    private void BindCalcType()
    {
        List<TeachPointCalcTypeDto> list = service.GetTeachPointCalcTypes();
        CurrentTeachPointCalcTypes = list;
        rcbSettingType.DataSource = list;
        rcbSettingType.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if(rcbSettingType.SelectedValue == "" || rcbSettingType.SelectedValue == null)
        {
            ShowMessage("未選擇計算時機");
            return;
        }

        if (rbByEduYear.Checked && (ddlEduYear.SelectedValue == null || ddlEduYear.SelectedValue == "" || ddlEduYearSession.SelectedValue == null || ddlEduYearSession.SelectedValue == ""))
        {
            ShowMessage("請選擇學年度與學期");
            return;
        }

        if(rbByDate.Checked && rdpDateBegin.SelectedDate == null)
        {
            ShowMessage("未選擇開始時間");
            return;
        }

        if (rbByDate.Checked && rdpDateEnd.SelectedDate == null)
        {
            ShowMessage("未選擇結束時間");
            return;
        }
        if (tbEmpCodes.Text.Trim() == "")
        {
            ShowMessage("未輸入員工編號");
            return;
        }

        List<string> empcodes = new List<string>();
        foreach(string empcode in tbEmpCodes.Text.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries))
        {
            if (!empcodes.Contains(empcode))
            {
                empcodes.Add(empcode);
            }
        }

        DateTime? sdate = null;
        DateTime? edate = null;
        if (rbByDate.Checked)
        {
            sdate = rdpDateBegin.SelectedDate;
            edate = rdpDateEnd.SelectedDate;
        }
        else
        {
            int cyear = Convert.ToInt32(ddlEduYear.SelectedValue);
            int session = Convert.ToInt32(ddlEduYearSession.SelectedValue);
            sdate = new DateTime(1911 + cyear, 8, 1).AddMonths(session * 6);
            edate = sdate.Value.AddMonths(6).AddDays(-1);
        }

        List<TeachPointCalcSumData> list = service.GetTeachPointCalcData(Convert.ToInt32(rcbSettingType.SelectedValue), empcodes, sdate.Value, edate.Value);
        CurrentTeachPointCalcSumData = list;
        rgSum.DataSource = list;
        rgSum.DataBind();
        rgItem.DataSource = null;
        rgItem.DataBind();
        rgDetail.DataSource = null;
        rgDetail.DataBind();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if(CurrentTeachPointCalcSumData == null)
        {
            ShowMessage("請先查詢資料");
            return;
        }

        HSSFWorkbook workbook = new HSSFWorkbook();
        HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("總覽");
        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
        headerRow.CreateCell(0).SetCellValue("職編");
        headerRow.CreateCell(1).SetCellValue("姓名");
        headerRow.CreateCell(2).SetCellValue("點數");

        HSSFSheet sheetdet1 = (HSSFSheet)workbook.CreateSheet("明細1");
        HSSFRow headerRow2 = (HSSFRow)sheetdet1.CreateRow(0);
        headerRow2.CreateCell(0).SetCellValue("職編");
        headerRow2.CreateCell(1).SetCellValue("姓名");
        headerRow2.CreateCell(2).SetCellValue("點數項目");
        headerRow2.CreateCell(3).SetCellValue("點數");
        HSSFSheet sheetdet2 = (HSSFSheet)workbook.CreateSheet("明細2");
        HSSFRow headerRow3 = (HSSFRow)sheetdet2.CreateRow(0);
        headerRow3.CreateCell(0).SetCellValue("職編");
        headerRow3.CreateCell(1).SetCellValue("姓名");
        headerRow3.CreateCell(2).SetCellValue("明細內容");
        headerRow3.CreateCell(3).SetCellValue("時間");
        headerRow3.CreateCell(4).SetCellValue("點數");

        int rowcount1 = 1;
        int rowcount2 = 1;
        int rowcount3 = 1;
        foreach(TeachPointCalcSumData data in CurrentTeachPointCalcSumData)
        {

            HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowcount1);
            dataRow.CreateCell(0).SetCellValue(data.EmpCode);
            dataRow.CreateCell(1).SetCellValue(data.EmpName);
            dataRow.CreateCell(2).SetCellValue(data.SumPoint.ToString("0.0000"));
            rowcount1++;
            foreach(var datadet1 in data.ItemDatas)
            {
                HSSFRow dataRow2 = (HSSFRow)sheetdet1.CreateRow(rowcount2);
                dataRow2.CreateCell(0).SetCellValue(data.EmpCode);
                dataRow2.CreateCell(1).SetCellValue(data.EmpName);
                dataRow2.CreateCell(2).SetCellValue(datadet1.ItemName);
                dataRow2.CreateCell(3).SetCellValue(datadet1.SumPoint.ToString("0.0000"));
                rowcount2++;
                foreach(var datadet2 in datadet1.DetailData)
                {
                    HSSFRow dataRow3 = (HSSFRow)sheetdet2.CreateRow(rowcount3);
                    dataRow3.CreateCell(0).SetCellValue(data.EmpCode);
                    dataRow3.CreateCell(1).SetCellValue(data.EmpName);
                    dataRow3.CreateCell(2).SetCellValue(datadet2.PointDesc);
                    dataRow3.CreateCell(3).SetCellValue(datadet2.OrrcuTime.ToString("yyyy/MM/dd"));
                    dataRow3.CreateCell(4).SetCellValue(datadet2.DetailPoint.ToString("0.0000"));
                    rowcount3++;
                }

            }

        }


        // 產生 Excel 資料流
        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        
        
        workbook = null;


        byte[] bytes = ms.ToArray();


        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();

    }
    protected void rgSum_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        rgSum.DataSource = CurrentTeachPointCalcSumData;
    }
    protected void rgSum_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindrgItem();
        rgItem.DataBind();
    }

    private void BindrgItem()
    {
        if (rgSum.SelectedItems.Count > 0)
        {
            GridDataItem sumitem = rgSum.SelectedItems[0] as GridDataItem;
            string empcode = sumitem.GetDataKeyValue("EmpCode").ToString();
            rgItem.DataSource = CurrentTeachPointCalcSumData.Where(c => c.EmpCode == empcode).FirstOrDefault().ItemDatas;
        }
        else
        {
            rgItem.DataSource = null;
        }
    }
    protected void rgItem_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        BindrgItem();
    }

    private void BindrgDetail()
    {
        if (rgSum.SelectedItems.Count > 0 && rgItem.SelectedItems.Count>0)
        {
            GridDataItem sumitem = rgSum.SelectedItems[0] as GridDataItem;
            string empcode = sumitem.GetDataKeyValue("EmpCode").ToString();
            GridDataItem itemitem = rgItem.SelectedItems[0] as GridDataItem;
            int itemid = Convert.ToInt32(itemitem.GetDataKeyValue("ItemID"));
            rgDetail.DataSource = CurrentTeachPointCalcSumData.Where(c => c.EmpCode == empcode).FirstOrDefault().ItemDatas.Where(c => c.ItemID == itemid).FirstOrDefault().DetailData;
        }
        else
        {
            rgItem.DataSource = null;
        }
    }
    protected void rgItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindrgDetail();
        rgDetail.DataBind();
    }
}