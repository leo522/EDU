using KMU.EduActivity.ApplicationLayer.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OutstandingPerformanceAdmin : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnSave);
        AddPostbackControl(btnAddPerson);
    }

    #region 圖片跟文件存檔

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string Source = RBSource.SelectedValue; //資料來源
            string Award = Request.Form["EventAward"]; //活動名稱
            string Organizer = Request.Form["Organization"]; //主辦單位
            string eventDate = Request.Form["EventDateTime"]; //發生日期
            DateTime activeDate = DateTime.Parse(eventDate); //字串轉型為DateTime型態
            string rbType = RBType.SelectedValue; //獎項類型

            if (FileSupportUpload.HasFile)
            {
                HttpPostedFile DataFiles = FileSupportUpload.PostedFile; //設定上傳檔案的變數

                string fileName = FileSupportUpload.FileName; //獲取上傳的文件名稱和類型
                string fileType = Path.GetExtension(fileName).ToLower();

                if (DataFiles.ContentLength <= 5 * 1024 * 1024) //限制檔案大小為5MB
                {
                    if (fileType == ".jpg" || fileType == ".jpeg" || fileType == ".png") //檢查圖片和文件格式
                    {
                        byte[] imageData = FileSupportUpload.FileBytes; //儲存圖片
                        string imageType = fileType;

                        SaveImageData(Source, Award, Organizer, eventDate, rbType, imageData, imageType); //將圖片和圖片格式存入DB

                        string script = "alert('圖片存檔成功！');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SaveSuccess", script, true);
                        ReviewStatusLabel.CssClass = "blueText";
                        //ReviewStatusLabel.Text = "審查中";
                    }
                    else if (fileType == ".pdf")
                    {
                        byte[] fileData = FileSupportUpload.FileBytes; //儲存文件
                        string FileType = fileType;

                        SaveFileData(Source, Award, Organizer, eventDate, rbType, fileData, FileType); //將文件和文件格式存入DB

                        string script = "alert('文件存檔成功！');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SaveSuccess", script, true);
                        ReviewStatusLabel.CssClass = "blueText";
                        //ReviewStatusLabel.Text = "審查中";
                    }
                    else
                    {
                        string script = "alert('存檔失敗，檔案類型不符合！');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidFileType", script, true);
                    }
                }
                else
                {
                    string script = "alert('存檔失敗，檔案超過5MB！');";
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

    #region 圖片存檔功能

    private void SaveImageData(string Source, string Award, string Organizer, string activeDates, string rbType, byte[] imageData, string imageType)
    {
        try
        {
            string sql = WebConfigurationManager.ConnectionStrings["CICEntities"].ConnectionString; // 本地端MS-SQL測試使用

            using (SqlConnection connection = new SqlConnection(sql))
            {
                string query = "INSERT INTO OutstandindData (RBsource, RBtype, Awards, Organization, ActiveDates, Images, ImagesType) " +
                "VALUES (@RBsource, @RBtype, @Awards, @Organization, @ActiveDates, @Images, @ImagesType)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RBsource", Source);
                    command.Parameters.AddWithValue("@RBtype", rbType);
                    command.Parameters.AddWithValue("@Awards", Award);
                    command.Parameters.AddWithValue("@Organization", Organizer);
                    command.Parameters.AddWithValue("@ActiveDates", activeDates);
                    command.Parameters.AddWithValue("@Images", imageData);
                    command.Parameters.AddWithValue("@ImagesType", imageType);

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

    private void SaveFileData(string Source, string Award, string Organizer, string activeDates, string rbType, byte[] fileData, string FileType)
    {
        try
        {
            string sql = WebConfigurationManager.ConnectionStrings["CICEntities"].ConnectionString; // 本地端MS-SQL測試使用

            using (SqlConnection connection = new SqlConnection(sql))
            {
                string query = "INSERT INTO OutstandindData (RBsource, RBtype, Awards, Organization, ActiveDates, FilesData, FilesType) " +
                "VALUES (@RBsource, @RBtype, @Awards, @Organization, @ActiveDates, @FilesData, @FilesType)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RBsource", Source);
                    command.Parameters.AddWithValue("@Awards", Award);
                    command.Parameters.AddWithValue("@Organization", Organizer);
                    command.Parameters.AddWithValue("@ActiveDates", activeDates);
                    command.Parameters.AddWithValue("@RBtype", rbType);
                    command.Parameters.AddWithValue("@FilesData", fileData);
                    command.Parameters.AddWithValue("@FilesType", FileType);

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
}