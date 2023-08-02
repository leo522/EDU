using KMU.EduActivity.ApplicationLayer.Services;
using KMUH.FunctionLibrary.ApplicationLayer.DTO;
using KMUH.FunctionLibrary.ApplicationLayer.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OutstandingPerformance : AuthPage
{
    protected override void OnLoad(EventArgs e)
    {
        //base.OnLoad(e);
        //Page_Load(this, e);
        //避免發生無法使用btn的錯誤(這項錯誤通常的原因是回應被 Response.Write()、回應篩選條件、HttpModules 的呼叫修改了，或是已啟用伺服器追蹤)，但要先繼承AuthPage
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnSave);
        AddPostbackControl(btnAddPerson);
    }

    #region 上傳功能-暫不使用
    protected void Btn_Upload_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (FileUpload.HasFile)
        //    {
        //        HttpFileCollection UploadFile = Request.Files;

        //        for (int i = 0; i < UploadFile.Count; i++)
        //        {
        //            HttpPostedFile Files = UploadFile[i];
        //        }

        //        // 取得檔案名稱和路徑
        //        string fileName = FileUpload.FileName;
        //        string filePath = Path.Combine(Server.MapPath("~/"), fileName);

        //        // 上傳檔案到伺服器
        //        FileUpload.SaveAs(filePath);

        //        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["www_EduActivityConnectionString"].ConnectionString))
        //        {

        //        }

        //        LbMessage.Text = "檔案上傳成功"; // 顯示上傳成功訊息
        //    }
        //    else
        //    {
        //        LbMessage.Text = "請選擇檔案";
        //    }
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }
    #endregion

    #region 主要存檔功能 & 圖片跟文件存檔

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string Source = RBSource.SelectedValue; //資料來源
            string Award = Request.Form["Competition"]; //活動名稱
            string Organizer = Request.Form["Organization"]; //主辦單位
            string eventDate = Request.Form["EventDateTime"]; //發生日期
            DateTime activeDate = DateTime.Parse(eventDate); //字串轉型為DateTime型態
            string rbType = RBType.SelectedValue; //獎項類型

            //存檔前先處理參與人員的資料
            List<string> ParticipantList = new List<string>();


            if (FileSupportUpload.HasFile)
            {
                if (!string.IsNullOrEmpty(Participant.Text))
                {
                    //將參與人員以逗號分隔，拆分成單獨的參與人員
                    string[] Participants = Participant.Text.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    ParticipantList.AddRange(Participants);
                }

                //新增OutstandingPerformance的資料
                int insertedPerformanceID = 0;

                string emp = this.EmpName;

                if (SavePerformanceData(Source, Award, Organizer, eventDate, rbType, emp, out insertedPerformanceID))
                {
                    //新增OutstandingPerformance的資料成功後，再儲存參與人員資料
                    foreach (var dto in ParticipantList)
                    {
                        string empNo = GetEmpNoByName(dto); //取得人員的員編
                        if (!string.IsNullOrEmpty(empNo))
                        {
                            SaveAttendeeData(insertedPerformanceID, empNo, dto);
                        }
                    }
                }

                // 呼叫附加檔案上傳功能
                UploadAttachment();
            }
            else
            {
                string script = "alert('請選擇要上傳的檔案！');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotFile", script, true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region 附加檔案上傳功能

    private void UploadAttachment()
    {
        try
        {
            if (FileSupportUpload.HasFile)
            {
                HttpPostedFile DataFile = FileSupportUpload.PostedFile;
                string fileName = FileSupportUpload.FileName;
                string fileType = Path.GetExtension(fileName).ToLower();

                if (DataFile.ContentLength <= 5 * 1024 * 1024) // 限制檔案大小為 5MB
                {
                    if (fileType == ".jpg" || fileType == ".jpeg" || fileType == ".png")
                    {
                        // 圖片類型
                        byte[] imageData = new byte[DataFile.ContentLength];
                        DataFile.InputStream.Read(imageData, 0, DataFile.ContentLength);

                        int docID = 1;
                        var Creator = "a";
                        // 呼叫儲存圖片的方法
                        SaveImageData(RBSource.SelectedValue, Request.Form["Competition"], Request.Form["Organization"],
                            Request.Form["EventDateTime"], RBType.SelectedValue, Creator, docID);

                        string script = "alert('圖片存檔成功！');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SaveSuccess", script, true);
                        ReviewStatusLabel.CssClass = "blueText";
                    }
                    else if (fileType == ".pdf")
                    {
                        // PDF 文件類型
                        byte[] fileData = new byte[DataFile.ContentLength];
                        DataFile.InputStream.Read(fileData, 0, DataFile.ContentLength);

                        int docID = 1;
                        var Creator = "a";

                        // 呼叫儲存文件的方法
                        SaveFileData(RBSource.SelectedValue, Request.Form["Competition"], Request.Form["Organization"],
                            Request.Form["EventDateTime"], RBType.SelectedValue, Creator, docID);

                        string script = "alert('文件存檔成功！');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SaveSuccess", script, true);
                        ReviewStatusLabel.CssClass = "blueText";
                    }
                    else
                    {
                        string script = "alert('存檔失敗，檔案類型不符合！');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidFileType", script, true);
                    }
                }
                else
                {
                    string script = "alert('存檔失敗，檔案超過 5MB！');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidFileSize", script, true);
                }
            }
            else
            {
                string script = "alert('請選擇要上傳的檔案！');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotFile", script, true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region 主表存檔功能，不變動參數，只增加回傳插入的ID

    private bool SavePerformanceData(string Source, string Award, string Organizer, string activeDates, string rbType, string creator, out int insertedPerformanceID)
    {
        try
        {
            string sql = WebConfigurationManager.ConnectionStrings["CICEntities"].ConnectionString; // 本地端MS-SQL測試使用

            using (SqlConnection connection = new SqlConnection(sql))
            {
                string query = "INSERT INTO OutstandingPerformance (ApplicationSource, CompetitionTheme, Organizer, ActiveDates, ApplicationType, Creator, CreateTime) " +
                                "VALUES (@ApplicationSource, @CompetitionTheme, @Organizer, @ActiveDates, @ApplicationType, @Creator, @CreateTime); SELECT SCOPE_IDENTITY();"; 
                                // 使用SCOPE_IDENTITY()來取得插入的ID

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationSource", Source); //申請資料來源
                    command.Parameters.AddWithValue("@CompetitionTheme", Award); //活動名稱(參賽主題)
                    command.Parameters.AddWithValue("@Organizer", Organizer); //主辦單位
                    command.Parameters.AddWithValue("@ActiveDates", activeDates); //活動日期
                    command.Parameters.AddWithValue("@ApplicationType", rbType); //申請類型
                    command.Parameters.AddWithValue("@Creator", creator); //建立資料人員
                    command.Parameters.AddWithValue("@CreateTime", DateTime.Now); //建立時間

                    connection.Open();

                    var result = command.ExecuteScalar();

                    if (result != DBNull.Value) // 確認插入資料成功後再賦值
                    {
                        insertedPerformanceID = Convert.ToInt32(result);
                        return true; // 回傳成功
                    }
                    else
                    {
                        insertedPerformanceID = 0;
                        return false;
                        //throw new Exception("存入資料失敗。");
                    }
                    //int insertedID = Convert.ToInt32(command.ExecuteScalar()); // 執行插入並取得插入的ID
                    //connection.Close();

                    //return insertedID; // 回傳插入的ID
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region 新增SaveAttendeeData方法，用於儲存OutstandingAttendees子表資料

    private void SaveAttendeeData(int performanceID, string empNo, string empName)
    {
        try
        {
            string sql = WebConfigurationManager.ConnectionStrings["CICEntities"].ConnectionString; // 本地端MS-SQL測試使用

            using (SqlConnection connection = new SqlConnection(sql))
            {
                string query = "INSERT INTO OutstandingAttendees (OutstandingPerformanceID, EmpNo, EmpName, ModifyUser, ModifyDate) " +
           "VALUES (@OutstandingPerformanceID, @EmpNo, @EmpName, @ModifyUser, @ModifyDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OutstandingPerformanceID", performanceID);
                    command.Parameters.AddWithValue("@EmpNo", empNo);
                    command.Parameters.AddWithValue("@EmpName", empName);
                    command.Parameters.AddWithValue("@ModifyUser", ""); // 假設這裡需要填寫修改使用者的資料
                    command.Parameters.AddWithValue("@ModifyDate", DateTime.Now); // 假設這裡需要填寫修改日期的資料

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region 新增GetEmpNoByName方法，用於根據人員姓名取得員編

    private string GetEmpNoByName(string empName)
    {
        try
        {
            // 確認是否已經在 btnSearch_Click 方法中執行過 Linq 查詢
            if (query == null)
            {
                // 如果 query 是 null，表示還未進行過查詢，則在此處執行 Linq 查詢
                using (EduActivityContextService Service = new EduActivityContextService())
                {
                    var empCode = txtEmpCode.Value; // 員編

                    query = (from emp in Service.UnitOfWork.V_KmuEmps
                             where (!string.IsNullOrEmpty(empCode) && emp.Empcode == empCode)
                             || (!string.IsNullOrEmpty(empName) && emp.Empname == empName)
                             select emp.Empcode + " " + emp.Empname).ToList();
                }
            }

            // 使用 query 變數找到第一筆符合條件的紀錄
            string employeeRecord = query.FirstOrDefault(e => e.Contains(empName));

            // 如果找到符合條件的紀錄，從中取得員編
            if (!string.IsNullOrEmpty(employeeRecord))
            {
                string employeeCode = employeeRecord.Substring(0, employeeRecord.IndexOf(' '));
                return employeeCode;
            }

            // 若找不到對應的員編，回傳空字串
            return string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region 非Dicom(醫療)影像上傳
    //public string InsertNonDicomImg(NonDicomDataContent in_data_info)
    //{
    //    NonDicomStorageManage Service = new NonDicomStorageManage();

    //    FileStream fs = new FileStream("", FileMode.Open); //取得上傳的影像檔案
    //    byte[] data = new byte[fs.Length];
    //    //fs.Read(buffer, 0, buffer.Length); 
    //    fs.Close();

    //    var upload_data = new NonDicomDataContent(); //設定方法傳入參數
    //    upload_data.USER_ID = ""; //建立者
    //    upload_data.FILE_BYTE_INFO = data; //檔案內容 byt[]內容
    //    upload_data.FILE_TYPE = Path.GetExtension("").Substring(1); //檔案格式類型
    //    try
    //    {
    //        string file_sn = Service.InsertNonDicomImg(upload_data); //開始上傳影像
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return null;
    //}
    #endregion

    #region 多張群組非Dicom(醫療)影像處理方法
    //public string InsertNonDicomImgs(NonDicomGroupContent in_group_info)
    //{
    //    NonDicomStorageManage service = new NonDicomStorageManage();
    //    NonDicomGroupContent upload_group = new NonDicomGroupContent();

    //    var nondicom_img_list = FileSupportUpload.FileName; // nondicom_img_list為要上傳的影像資訊

    //    foreach (NonDicomDataContent img in nondicom_img_list)
    //    {
    //        upload_group.Add(img); //將影像檔案加到上傳資訊裡
    //    }

    //    try
    //    {
    //        string group_id = service.InsertNonDicomImgs(upload_group); //開始上傳影像
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    #endregion

    #region 檢查上傳文件類型

    private bool IsAllowedFileType(string contentType)
    {
        try
        {
            string[] allowedTypes = { "image/png", "image/jpeg", "image/jpg", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/pdf" }; // 可根據需求添加或修改允許的文件類型
            return allowedTypes.Contains(contentType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region 圖片存檔功能

    private void SaveImageData(string Source, string Award, string Organizer, string activeDates, string rbType, string creator, int docID)
    {
        try
        {
            string sql = WebConfigurationManager.ConnectionStrings["CICEntities"].ConnectionString; // 本地端MS-SQL測試使用

            using (SqlConnection connection = new SqlConnection(sql))
            {
                string query = "INSERT INTO OutstandingPerformance (ApplicationSource, CompetitionTheme, Organizer, ActiveDates, ApplicationType, Creator, CreateTime, DocumentID) " +
                                "VALUES (@ApplicationSource, @CompetitionTheme, @Organizer, @ActiveDates, @ApplicationType, @Creator, @CreateTime, @DocumentID); SELECT SCOPE_IDENTITY();"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationSource", Source); //申請資料來源
                    command.Parameters.AddWithValue("@CompetitionTheme", Award); //活動名稱(參賽主題)
                    command.Parameters.AddWithValue("@Organizer", Organizer); //主辦單位
                    command.Parameters.AddWithValue("@ActiveDates", activeDates); //活動日期
                    command.Parameters.AddWithValue("@ApplicationType", rbType); //申請類型
                    command.Parameters.AddWithValue("@Creator", creator); //建立資料人員
                    command.Parameters.AddWithValue("@CreateTime", DateTime.Now); //建立時間
                    command.Parameters.AddWithValue("@DocumentID", docID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    #endregion

    #region 文件存檔功能

    private void SaveFileData(string Source, string Award, string Organizer, string activeDates, string rbType, string creator, int docID)
    {
        try
        {
            string sql = WebConfigurationManager.ConnectionStrings["CICEntities"].ConnectionString; // 本地端MS-SQL測試使用

            using (SqlConnection connection = new SqlConnection(sql))
            {
                string query = "INSERT INTO OutstandingPerformance (ApplicationSource, CompetitionTheme, Organizer, ActiveDates, ApplicationType, Creator, CreateTime, DocumentID) " +
                               "VALUES (@ApplicationSource, @CompetitionTheme, @Organizer, @ActiveDates, @ApplicationType, @Creator, @CreateTime, @DocumentID); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationSource", Source); //申請資料來源
                    command.Parameters.AddWithValue("@CompetitionTheme", Award); //活動名稱(參賽主題)
                    command.Parameters.AddWithValue("@Organizer", Organizer); //主辦單位
                    command.Parameters.AddWithValue("@ActiveDates", activeDates); //活動日期
                    command.Parameters.AddWithValue("@ApplicationType", rbType); //申請類型
                    command.Parameters.AddWithValue("@Creator", creator); //建立資料人員
                    command.Parameters.AddWithValue("@CreateTime", DateTime.Now); //建立時間
                    command.Parameters.AddWithValue("@DocumentID", docID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    #endregion

    #region 讀取圖片

    private byte[] RetrieveImageData(string imageId)
    {
        try
        {
            byte[] imageData = null;

            string sql = WebConfigurationManager.ConnectionStrings["CICEntities"].ConnectionString; // 本地端MS-SQL測試使用

            using (SqlConnection connection = new SqlConnection(sql))
            {
                string query = "SELECT Images FROM OutstandingPerformance WHERE ID = @ImageId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ImageId", imageId); // 替換成圖片識別條件

                connection.Open();
                imageData = (byte[])command.ExecuteScalar();
                connection.Close();
            }
            return imageData;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region 查詢圖片
    //protected void btn_Serach_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string imageId = ImageId.Text;

    //        byte[] imageData = RetrieveImageData(imageId); //根據ID從DB尋找對應的圖片

    //        string base64String = Convert.ToBase64String(imageData); //將圖片轉換為Base64字符串

    //        string imageUrl = "data:image/jpeg;base64," + base64String; //建立圖片的Data URI

    //        ImageData.ImageUrl = imageUrl; //在前端顯示圖片
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //        //string errMes = "發生錯誤" + ex.Message;
    //    }
    //}
    #endregion

    #region 加入人員

    protected void btnAddPerson_Click(object sender, EventArgs e)
    {
        try
        {
            string SelectParticipant = PersonDropDownList.SelectedItem.Text;
            string empCodeToRemove = txtEmpCode.Value;

            // 取得參與人員的姓名部分
            string participantName = SelectParticipant.Substring(SelectParticipant.IndexOf(' ') + 1);

            // 判斷是否已加入參與人員
            bool isParticipantAdded = Participant.Text.Contains(participantName);

            if (!isParticipantAdded)
            {
                if (!string.IsNullOrEmpty(Participant.Text))
                {
                    Participant.Text += ", ";
                }
                Participant.Text += participantName;

                RemoveDropDownList.Items.Remove(""); //移除舊的空白項（如果有）

                // 添加新的參與人員選項
                RemoveDropDownList.Items.Add(new ListItem(participantName, participantName));

                // 添加新的空白項
                RemoveDropDownList.Items.Insert(0, new ListItem("", ""));

                //RemoveDropDownList.Items.Add(participantName);
            }
            else
            {
                // 顯示提示訊息
                string message = "此人員 <span style='color: red;'>" + participantName + "</span> 已有加入";
                AddPersonMsg.Text = message;
            }

            using (EduActivityContextService Service = new EduActivityContextService())
            {
                var query = from emp in Service.UnitOfWork.V_KmuEmps
                            where emp.Empcode != empCodeToRemove && (emp.Empcode == empCodeToRemove || emp.Empname == participantName)
                            select emp;

                //PersonDropDownList.Items.Clear();

                foreach (var employee in query)
                {
                    string employeeFullName = employee.Empcode + " " + employee.Empname;
                    PersonDropDownList.Items.Add(new ListItem(employeeFullName, employeeFullName));
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region 移除人員

    protected void btnRemovePerson_Click(object sender, EventArgs e)
    {
        try
        {
            string participantNameToRemove = RemoveDropDownList.SelectedItem.Text;

            // 檢查要移除的人員是否存在
            bool isParticipantExist = Participant.Text.Contains(participantNameToRemove);

            if (isParticipantExist)
            {
                // 移除要移除的人員
                Participant.Text = Participant.Text.Replace(participantNameToRemove + ", ", "").Replace(", " + participantNameToRemove, "").Replace(participantNameToRemove, "");

                // 移除選中的人員           
                RemoveDropDownList.Items.Remove(RemoveDropDownList.SelectedItem);

                // 顯示移除成功訊息
                string message = "所選擇的人員 <span style='color: red;'>" + participantNameToRemove + "</span> 已移除";
                RemovePersonMsg.Text = message;
            }
            else
            {
                // 顯示人員不存在訊息
                string message = "此人員" + participantNameToRemove + "不存在";
                RemovePersonMsg.Text = message;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region 查詢人員

    IEnumerable<string> query;
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            using (EduActivityContextService Service = new EduActivityContextService())
            {
                var empCode = txtEmpCode.Value; //員編
                var empName = txtEmpname.Value; //姓名

                var query = from emp in Service.UnitOfWork.V_KmuEmps
                            where (!string.IsNullOrEmpty(empCode) && emp.Empcode == empCode)
                                || (!string.IsNullOrEmpty(empName) && emp.Empname == empName)
                            select emp.Empcode + " " + emp.Empname;

                PersonDropDownList.Items.Clear(); //清空下拉列表中的項目

                foreach (var Emp in query)
                {
                    PersonDropDownList.Items.Add(new ListItem(Emp, Emp));
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region 查詢審查結果

    protected void btnSerachReview_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}