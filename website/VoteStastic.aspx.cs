using KMU.EduActivity.ApplicationLayer.DTO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class VoteStastic : AuthPage
{
    private VoteStasticMain CurrentMain
    {
        get
        {
            return ViewState["CurrentMain"] as VoteStasticMain;
        }
        set
        {
            ViewState["CurrentMain"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.AddPostbackControl(btnExport);
        if(!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                RadGrid1.DataBind();
            }
            else
            {
                ShowMessageAndGoBack("參數傳遞錯誤");
            }
        }
    }

    private void ReadVoteData()
    {
        if (CurrentMain == null)
        {
            VoteStasticMain main = service.GetVoteStastic(Convert.ToInt32(Request.QueryString["ID"]));

            CurrentMain = main;
        }
        lbVoteName.Text = CurrentMain.MainDto.VoteName;
        lbVoteRange.Text = CurrentMain.MainDto.Sdate.Value.ToString("yyyy/MM/dd") + "~" + CurrentMain.MainDto.Edate.Value.ToString("yyyy/MM/dd");
        lbVoteCount.Text = CurrentMain.VoteCount.ToString();
        RadGrid1.DataSource = CurrentMain.VoteItems;

    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadVoteData();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (CurrentMain.VoteCount != 0)
        {
            int row = 0;

            //建立Excel 2003檔案
            HSSFWorkbook wb = new HSSFWorkbook();
            ISheet ws = wb.CreateSheet("Sheet1");

            HSSFCellStyle cstyle = wb.CreateCellStyle() as HSSFCellStyle;
            cstyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightBlue.Index;

            ws.CreateRow(row);
            ws.GetRow(row).CreateCell(0).SetCellValue("投票項目");
            ws.GetRow(row).GetCell(0).CellStyle = cstyle;
            ws.GetRow(row).CreateCell(1).SetCellValue(lbVoteName.Text);
            row++;
            ws.CreateRow(row);
            ws.GetRow(row).CreateCell(0).SetCellValue("時間範圍");
            ws.GetRow(row).GetCell(0).CellStyle = cstyle;
            ws.GetRow(row).CreateCell(1).SetCellValue(lbVoteRange.Text);
            row++;
            ws.CreateRow(row);
            ws.GetRow(row).CreateCell(0).SetCellValue("投票人數");
            ws.GetRow(row).GetCell(0).CellStyle = cstyle;
            ws.GetRow(row).CreateCell(1).SetCellValue(lbVoteCount.Text);


            //空白行
            row++;
            ws.CreateRow(row);



            foreach (string group in CurrentMain.VoteItems.Select(c => c.GroupName).Distinct())
            {
                //空白行
                row++;
                ws.CreateRow(row);

                row++;
                ws.CreateRow(row);
                ws.GetRow(row).CreateCell(0).SetCellValue("Group");
                ws.GetRow(row).GetCell(0).CellStyle = cstyle;
                ws.GetRow(row).CreateCell(1).SetCellValue(group);

                //表頭
                row++;
                ws.CreateRow(row);
                ws.GetRow(row).CreateCell(0).SetCellValue("代碼");
                ws.GetRow(row).GetCell(0).CellStyle = cstyle;
                ws.GetRow(row).CreateCell(1).SetCellValue("項目");
                ws.GetRow(row).GetCell(1).CellStyle = cstyle;
                ws.GetRow(row).CreateCell(2).SetCellValue("得票數");
                ws.GetRow(row).GetCell(2).CellStyle = cstyle;


                foreach (VoteStasticItem item in CurrentMain.VoteItems.Where(c => c.GroupName == group))
                {
                    row++;
                    ws.CreateRow(row);
                    ws.GetRow(row).CreateCell(0).SetCellValue(item.ItemValue);
                    ws.GetRow(row).GetCell(0).CellStyle = cstyle;
                    ws.GetRow(row).CreateCell(1).SetCellValue(item.ItemName);
                    ws.GetRow(row).GetCell(1).CellStyle = cstyle;
                    ws.GetRow(row).CreateCell(2).SetCellValue(item.DataCount);
                    ws.GetRow(row).GetCell(2).CellStyle = cstyle;
                }

            }

            MemoryStream ms = new MemoryStream();
            wb.Write(ms);
            ws = null;
            wb = null;

            byte[] binaryData = ms.ToArray();


            Response.Clear();
            Response.AddHeader("Content-Length", binaryData.Length.ToString());
            Response.ContentType = "application/octet-stream";

            Response.AddHeader("content-disposition", "attachment; filename=output.xls");
            Response.OutputStream.Write(binaryData, 0, binaryData.Length);


            Response.Flush();
            Response.End();

        }
        else
        {
            ShowMessage("目前尚無人投票");
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("VoteManage.aspx");
    }
}