using KMU.EduActivity.ApplicationLayer.Services;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ClinicalInstructorCertificate : AuthPage
{
    #region 主檔

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Page_Load(this, e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btn_DownLoad);
        AddPostbackControl(btnUpload);
        //避免發生無法下載圖片的錯誤(這項錯誤通常的原因是回應被 Response.Write()、回應篩選條件、HttpModules 的呼叫修改了，或是已啟用伺服器追蹤)，但要先繼承 AuthPage

        if (!IsPostBack)
        {
            if (Session["EduAct_EmpName"] != null) //讀取登入者Session
            {
                string empCode = Session["EduAct_EmpName"].ToString();
                string eID = Session["EduAct_EmpCode"].ToString();
                string cicList = GetCIC_List(empCode, eID);
                //GetCIC_List(empCode);

                if (string.IsNullOrWhiteSpace(cicList))
                {
                    cicList = "查無資料";
                    //CIC_ImagePreview.ImageUrl = "~/Images/CIC_Pic.jpg";
                }
                else
                {
                    SetTextOnImage(cicList);
                    CIC_ImagePreview.ImageUrl = "~/Images/臨床教師指導電子證.jpg";
                }
                //CIC_ImagePreview.ImageUrl = "~/Images/CIC_Pic.jpg";
            }
            //隱藏圖片
            //CIC_ImagePreview.Style["display"] = "none";

            // 禁用 btn_Download 按鈕
            //btn_DownLoad.Enabled = false;
        }
    }

    protected void HeadLoginStatus_LoggedOut(object sender, EventArgs e)
    {
        Session.Clear();
    }
    #endregion

    #region 下載圖片
    protected void btn_DownLoad_Click(object sender, EventArgs e)
    {
        //if (CIC_ImagePreview.Style["display"] == "none")
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '請先進行查詢!', icon: 'warning'});", true);
        //    return;
        //}
        Response.Clear();
        Response.ContentType = "image/jpeg";
        Response.AppendHeader("Content-Disposition", "attachment; filename = 臨床教師指導電子證.jpg"); //圖片下載預設檔名
        Response.TransmitFile(Server.MapPath("~/Images/臨床教師指導電子證.jpg")); //讀取要存取的圖片
        Response.End();
    }
    #endregion

    #region 讀取資料庫
    private string GetCIC_List(string EmpName, string EID)
    {
        //string sql = WebConfigurationManager.ConnectionStrings["CICEntities"].ConnectionString; // 本地端MS-SQL測試使用
        string sql = WebConfigurationManager.ConnectionStrings["www_EduActivityConnectionString"].ConnectionString; //正式機
        string result = "";
        
        using (SqlConnection connection = new SqlConnection(sql))
        {
            //string query = "Select * From CICReport Where EmpName = @EMPName"; // 本地端MS-SQL測試使用
            string query = "Select * From CICBook Where EmpName = @EMPName And EID = @Eid"; //正式機
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@EMPName", EmpName);
            cmd.Parameters.AddWithValue("@Eid", EID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                bool isNameMatched = false; //檢查是否有重複姓名

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string eid = reader.GetString(1); //職編
                        string name = reader.GetString(2); //姓名
                        string TeacherList = reader.GetString(3); //職別
                        string SerialNo = reader.GetString(4); //證書字號
                        DateTime StartDate = reader.GetDateTime(5); //開始日
                        DateTime EndDate = reader.GetDateTime(6); //結束日
                        string dept = reader.GetString(7); //核發單位

                        // **********local SQL測試使用**********
                        //string name = reader.GetString(1); //姓名
                        //string TeacherList = reader.GetString(2); //職別
                        //string SerialNo = reader.GetString(3); //證書字號
                        //DateTime StartDate = reader.GetDateTime(4); //開始日
                        //DateTime EndDate = reader.GetDateTime(5); //結束日
                        //string dept = reader.GetString(6); //核發單位
                        // **********local SQL測試使用**********

                        // 將日期轉換為民國年格式並串聯
                        string startYearTW = (StartDate.Year - 1911).ToString();
                        string endYearTW = (EndDate.Year - 1911).ToString();
                        string effectiveDate = string.Format("{0}.{1:MM.dd}-{2}.{3:MM.dd}", startYearTW, StartDate, endYearTW, EndDate);

                        // 到期日，判斷是否要顯示提醒
                        DateTime RemindDate = EndDate.AddMonths(-1); // 距離到期日前一個月的日期
                        if (DateTime.Today < EndDate && DateTime.Today >= RemindDate)
                        {
                            //string Reminder = string.Format("注意：證書 {0} 將在 {1} 到期。", SerialNo, RemindDate.ToString("yyyy/MM/dd"));
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "showReminder", "Swal.fire({title: '您的證書期將到期!', icon: 'warning'});", true);
                        }

                        if (name == EmpName)
                        {
                            isNameMatched = true;

                            result = string.Format("{0}\n{1}\n{2}\n{3}\n", name, TeacherList, SerialNo, effectiveDate);

                            SetTextOnImage(result);
                        }
                    }
                }
                else
                {
                    result = "查無資料";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("發生錯誤，請聯絡系統管理員處理。" + ex.Message);
            }
            return result;
        }
    }
    #endregion

    #region 讀取圖片並建立圖像物件
    private void SetTextOnImage(string objs)
    {
        using (System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/Images/CIC_Pic.jpg")))
        {
            using (Graphics pics = Graphics.FromImage(img))
            {
                // 設定文字大小、字型、位置和顏色
                Font fonts = new Font("微軟正黑體", 8);
                Brush brushs = Brushes.Black;

                // 設定文字繪製位置
                PointF points = new PointF(250, 252);
                float lineHeight = fonts.GetHeight() * 0.2f;

                // 設定文字渲染模式和畫質
                pics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                pics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                pics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                // 設定行間距
                string[] lines = objs.Split('\n');
                float totalHeight = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].TrimEnd('\r');
                    SizeF size = pics.MeasureString(line, fonts);
                    float x = points.X;
                    float y = points.Y + totalHeight;
                    pics.DrawString(line, fonts, brushs, x, y);
                    totalHeight += size.Height + lineHeight;
                }

                // 儲存繪製好的圖片
                img.Save(Server.MapPath("~/Images/臨床教師指導電子證.jpg"));
            }
        }
    }
    #endregion

    #region Excel檔案匯入db_暫不使用

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //// 檢查是否選擇了檔案
        //if (FileUpload.HasFile)
        //{
        //    // 取得檔案名稱和路徑
        //    string fileName = FileUpload.FileName;
        //    //string filePath = Server.MapPath("~/uploads/" + fileName);
        //    string filePath = Path.Combine(Server.MapPath("~/"), fileName);

        //    // 上傳檔案到伺服器
        //    FileUpload.SaveAs(filePath);

        //    // 讀取 Excel 檔案
        //    using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        //    {
        //        XSSFWorkbook workbook = new XSSFWorkbook(stream);
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        // 取得最後一列的索引
        //        int lastRow = sheet.LastRowNum;

        //        // 逐行讀取資料
        //        for (int i = 1; i <= lastRow; i++)
        //        {
        //            IRow row = sheet.GetRow(i);

        //            // 儲存資料的 List
        //            List<string> rowData = new List<string>();

        //            foreach (var cell in row)
        //            {
        //                string columnStr = string.Empty;
        //                columnStr = GetValueType(cell as ICell).ToString();
        //                rowData.Add(columnStr);
        //            }

        //            // 將資料寫入資料庫
        //            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["www_EduActivityConnectionString"].ConnectionString))
        //            {
        //                SqlCommand command = new SqlCommand("Insert Into CICBook (EID,EmpName,TeacherList,SerialNo,StartDate,EndDate,Dept) Values(@EID,@EmpName,@TeacherList,@SerialNo,@EFFECTIVE_STARTDATE,@EFFECTIVE_ENDDATE,@Dept)", connection);

        //                command.Parameters.AddWithValue("@EID", rowData[0]);
        //                command.Parameters.AddWithValue("@EmpName", rowData[1]);
        //                command.Parameters.AddWithValue("@TeacherList", rowData[2]);
        //                command.Parameters.AddWithValue("@SerialNo", rowData[3]);

        //                // 處理日期格式，將民國年轉換成西元年
        //                DateTime startDate;
        //                if (DateTime.TryParseExact(rowData[4], "yyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
        //                {
        //                    startDate = startDate.AddYears(1911);
        //                }
        //                command.Parameters.AddWithValue("@EFFECTIVE_STARTDATE", startDate);

        //                DateTime endDate;
        //                if (DateTime.TryParseExact(rowData[5], "yyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
        //                {
        //                    endDate = endDate.AddYears(1911);
        //                }
        //                command.Parameters.AddWithValue("@EFFECTIVE_ENDDATE", endDate);


        //                command.Parameters.AddWithValue("@Dept", rowData[6]);
        //                connection.Open();
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    // 刪除上傳的檔案
        //    File.Delete(filePath);

        //    // 顯示匯入成功的訊息
        //    Response.Write("<script>alert('匯入成功！');</script>");
        //}
        //else
        //{
        //    // 如果沒有選擇檔案，顯示錯誤訊息
        //    Response.Write("<script>alert('請選擇要匯入的Excel檔案！');</script>");
        //}
     }
    #endregion

    #region 查詢_圖片預覽_暫不使用
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        //CIC_ImagePreview.Style["display"] = "none";

        //string CIC_Name = Request.Form["CIC_Name"];

        //if (string.IsNullOrWhiteSpace(CIC_Name))
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '請輸入姓名!', icon: 'warning'})", true);
        //}
        //else
        //{
        //    string result = GetCIC_List(CIC_Name);
        //    if (string.IsNullOrEmpty(result))
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '查無資料!', icon: 'error'});", true);
        //    }
        //    else
        //    {
        //        SetTextOnImage(result);
        //        string imageURL = "~/Images/臨床教師指導證.jpg";

        //        //DateTime.Now.Ticks 作為時間戳，以確保每次圖片 URL 的唯一性，避免瀏覽器緩存問題。
        //        CIC_ImagePreview.ImageUrl = imageURL + "?timestamp=" + DateTime.Now.Ticks; 
        //        CIC_ImagePreview.Style["display"] = "block";

        //        // 啟用 btn_Download 按鈕
        //        //btn_DownLoad.Enabled = true;
        //    }
        //}
    }
    #endregion
}