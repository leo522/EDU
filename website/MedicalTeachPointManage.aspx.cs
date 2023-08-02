using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MedicalTeachPointManage : AuthPage
{
    #region 主檔
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Page_Load(this, e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btn_Import);

        //if (IsPostBack)
        //{
        //    txtDept.Text = string.Empty; //如果是PostBack，則清空欄位
        //}
    }
    #endregion

    #region 自動完成_單位部門

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["www_EduActivityConnectionString"].ConnectionString))
            {
                string query = "SELECT deptcode, deptname FROM v_departments Where shorthospcode = 'H'"; //指定 附院 院區
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<string> deptList = new List<string>();
                while (reader.Read())
                {
                    deptList.Add(reader["deptcode"] + " - " + reader["deptname"]);
                }

                txtDept.Attributes.Add("autocomplete", "off");
                txtDept.Attributes.Add("placeholder", "請輸入科別代碼或單位名稱");
                txtDept.Attributes.Add("class", "ui-widget form-control");
                txtDept.Attributes.Add("onchange", "document.getElementById('" + hfDeptCode.ClientID + "').value = this.value.split(' - ')[0];");

                var jsSerializer = new JavaScriptSerializer();
                string deptJson = jsSerializer.Serialize(deptList);
                string script = "$(function() { " +
                    "$('#" + txtDept.ClientID + "').autocomplete({ " +
                        "source: " + deptJson + ", " +
                        "minLength: 2 " +
                    "}).focus(function() {" +
                        "$(this).autocomplete('search', $(this).val())" +
                    "});" +
                "});";
                ScriptManager.RegisterStartupScript(this, GetType(), "autocomplete", script, true);
            }
            ////新增表單驗證
            //btn_Import.Attributes.Add("onclick", "if ($('#" + txtDept.ClientID + "').val() == '') { Swal.fire({title: '請選擇單位！', icon: 'warning'}); return false; } else { return true; }");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '發生錯誤！', icon: 'error', text: '" + ex.Message.Replace("'", "\\'") + "'});", true);
        }
    }
    #endregion

    #region 日期
    private List<TeachPointEmpItemDatumDto> CurrentData
    {
        get
        {
            return ViewState["CurrentData"] as List<TeachPointEmpItemDatumDto>;
        }
        set
        {
            ViewState["CurrentData"] = value;
        }
    }

    private void ReadDate()
    {
        //List<TeachPointEmpItemDatumDto> data = service.QueryTeachPointEmpItemData(Convert.ToInt32(rcbItemQuery.SelectedValue), tbEmpCodeName.Text.Trim(), RdpSdate.SelectedDate, RdpEdate.SelectedDate);
        //CurrentData = data;
        //RadGrid1.DataSource = data;
        //RadGrid1.DataBind();
    }
    #endregion

    #region 判斷ID流水號最後一號_暫時不使用
    private bool CheckIdExists(string id, SqlConnection connection)
    {
        string query = "SELECT COUNT(*) FROM MedicalTeachPoint_Test WHERE ID = @Id"; //測試SQL DB
        //string query = "SELECT COUNT(*) FROM MedicalTeachPoint WHERE ID = @Id"; //正式SQL DB

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();
        int count = (int)command.ExecuteScalar();
        connection.Close();
        return count > 0;
    }
    #endregion

    #region 上傳醫事教師教學點數檔案

    protected void btn_Import_Click(object sender, EventArgs e)
    {
        try
        {
            string emp_Create = Session["EduAct_EmpCode"].ToString(); //登入者職編
            string emp_Hosp = Session["EduAct_HospCode"].ToString(); //登入者所屬院區
            if (string.IsNullOrEmpty(txtDept.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '請輸入科別代碼或單位名稱！', icon: 'warning'});", true);
                return;
            }
            if (!ExcelUpload.HasFile)
            {
                Session.Remove("isUploaded");
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '請選擇檔案！', icon: 'warning'});", true);
                return;
            }

            //if (string.IsNullOrEmpty(txtDept.Text.Trim()))
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '請選擇單位！', icon: 'warning'});", true);
            //    //return;
            //}

            if (ExcelUpload.HasFile)
            {
                string fileName = ExcelUpload.FileName;
                string fileExtension = Path.GetExtension(ExcelUpload.FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string filePath = Path.Combine(Server.MapPath("~/"), fileName);

                    ExcelUpload.SaveAs(filePath);

                    DateTimeOffset currentDateTime = DateTimeOffset.Now;
                    DateTime dTime = currentDateTime.LocalDateTime;

                    using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = null;
                        if (fileExtension == ".xls")
                        {
                            workbook = new HSSFWorkbook(stream);
                        }
                        else if (fileExtension == ".xlsx'")
                        {
                            workbook = new XSSFWorkbook(stream);
                        }

                        ISheet sheet = workbook.GetSheetAt(0);

                        int lastRow = sheet.LastRowNum;

                        int idNum = 1; //判斷ID流水號最後一號

                        //測試使用
                        //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CICEntities"].ConnectionString))
                        //{
                        //    connection.Open();
                        //    using (SqlCommand cmd = new SqlCommand("Select MAX(CAST(ID AS INT)) AS MaxID From MedicalTeachPoint_Test", connection))
                        //    {
                        //        using (SqlDataReader reader = cmd.ExecuteReader())
                        //        {
                        //            if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("MaxID")))
                        //            {
                        //                idNum = reader.GetInt32(reader.GetOrdinal("MaxID")) + 1;
                        //            }
                        //        }
                        //    }
                        //}

                        //正式DB，處理ID流水編號
                        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["www_EduActivityConnectionString"].ConnectionString))
                        {
                            connection.Open();
                            using (SqlCommand cmd = new SqlCommand("Select MAX(CAST(ID AS INT)) AS MaxID From MedicalTeachPoint", connection))
                            {
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("MaxID")))
                                    {
                                        //idNum = int.Parse(reader["ID"].ToString().Substring(0, 10)) + 1;
                                        idNum = reader.GetInt32(reader.GetOrdinal("MaxID")) + 1;
                                    }
                                }
                            }
                        }

                        DataTable dTs = new DataTable();
                        dTs.Columns.Add("ID", typeof(string));
                        dTs.Columns.Add("Emp_Code", typeof(string));
                        dTs.Columns.Add("Data_Date", typeof(DateTime));
                        dTs.Columns.Add("Dept_Code", typeof(string));
                        dTs.Columns.Add("Base_TeachPoint", typeof(decimal));
                        dTs.Columns.Add("Hosp_Code", typeof(string));
                        dTs.Columns.Add("Creater", typeof(string));
                        dTs.Columns.Add("CreateTime", typeof(DateTime));
                        dTs.Columns.Add("Base_Ratio", typeof(decimal));
                        dTs.Columns.Add("Teacher_Point", typeof(decimal));
                        dTs.Columns.Add("STrain_Point", typeof(decimal));
                        dTs.Columns.Add("Remark", typeof(string));

                        string emptyRows = ""; // 紀錄有空值的欄位資訊

                        for (int i = 5; i <= lastRow - 6; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = dTs.NewRow();

                            //string idStr = idNum.ToString().PadLeft(10, '0'); //產生10位數字的流水編號ID
                            string idStr = idNum.ToString().PadLeft(10, '0');
                            dataRow["ID"] = idStr;
                            //idNum++; //不使用，會造成錯誤累加

                            dataRow["Emp_Code"] = row.GetCell(3).ToString(); //職編

                            int year = int.Parse(sheet.SheetName.Split('.')[0]) + 1911;
                            int month = int.Parse(sheet.SheetName.Split('.')[1]);
                            DateTime date = new DateTime(year, month, 1);
                            dataRow["Data_Date"] = date;

                            //dataRow["Dept_Code"] = row.GetCell(1).ToString();
                            dataRow["Dept_Code"] = hfDeptCode.Value;
                            decimal baseTeachPoint;

                            if (decimal.TryParse(row.GetCell(4).ToString(), out baseTeachPoint))
                            {
                                dataRow["Base_TeachPoint"] = baseTeachPoint; //基本點數
                            }

                            dataRow["Hosp_Code"] = emp_Hosp;
                            dataRow["Creater"] = emp_Create;
                            dataRow["CreateTime"] = dTime;

                            decimal baseRatio;
                            if (decimal.TryParse(row.GetCell(5).ToString(), out baseRatio))
                            {
                                dataRow["Base_Ratio"] = baseRatio; //權數
                            }

                            decimal teacherPoint;
                            if (decimal.TryParse(row.GetCell(6).ToString(), out teacherPoint))
                            {
                                dataRow["Teacher_Point"] = teacherPoint; //導師點數
                            }

                            decimal sTrainPoint;
                            if (decimal.TryParse(row.GetCell(7).ToString(), out sTrainPoint))
                            {
                                dataRow["STrain_Point"] = sTrainPoint; //代訓點數
                            }

                            dataRow["Remark"] = row.GetCell(9).ToString(); //備註說明

                            bool hasEmptyValue = string.IsNullOrWhiteSpace(dataRow["Emp_Code"].ToString());

                            if (hasEmptyValue)
                            {
                                emptyRows += (i + 1).ToString() + ",";
                                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", string.Format("Swal.fire({{title: '第 <span style=\"color:red\">{0}</span> 行識別證號碼不能空白！', icon: 'warning'}});", i + 1), true);
                                //return;
                            }

                            dTs.Rows.Add(dataRow);
                        }

                        if (!string.IsNullOrEmpty(emptyRows))
                        {
                            emptyRows = emptyRows.Substring(0, emptyRows.Length - 1); //删除數字後的逗號
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", string.Format("Swal.fire({{title: '第 <span style=\"color:red\">{0}</span> 行欄位的識別證號碼不能空白！', icon: 'warning'}});", emptyRows), true);
                            return;
                        }

                        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["www_EduActivityConnectionString"].ConnectionString))
                        //www_EduActivityConnectionString，正式用連線字串--------------------************************
                        //CICEntities，測試用連線字串--------------------************************
                        {
                            connection.Open();

                            //檢查是否已經存在相同的Emp_Code和Data_Date
                            //string query = "SELECT COUNT(*) FROM MedicalTeachPoint_Test WHERE EmpCode = @empCode AND DataDate = @dataDate"; //測試使用
                            
                            string query = "SELECT COUNT(*) FROM MedicalTeachPoint WHERE EmpCode = @empCode AND DataDate = @dataDate"; //正式DB
                            
                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@empCode", SqlDbType.NVarChar);
                                cmd.Parameters.AddWithValue("@dataDate", SqlDbType.DateTime);

                                foreach (DataRow dataRow in dTs.Rows)
                                {
                                    string empCode = dataRow["Emp_Code"].ToString();
                                    DateTime dataDate = Convert.ToDateTime(dataRow["Data_Date"]);

                                    cmd.Parameters["@empCode"].Value = empCode;
                                    cmd.Parameters["@dataDate"].Value = dataDate;

                                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                                    if (count > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '警告', text: '匯入的職編與日期已存在相同資料，請勿重複匯入！', icon: 'warning'});", true);
                                        return;
                                    }
                                }
                            }

                            //如果資料沒有重複，則進行匯入
                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                            {
                                //bulkCopy.DestinationTableName = "MedicalTeachPoint_Test"; //測試db Table
                                bulkCopy.DestinationTableName = "MedicalTeachPoint"; //正式db Table

                                bulkCopy.ColumnMappings.Add("ID", "ID");
                                bulkCopy.ColumnMappings.Add("Emp_Code", "EmpCode");
                                bulkCopy.ColumnMappings.Add("Data_Date", "DataDate");
                                bulkCopy.ColumnMappings.Add("Dept_Code", "DeptCode");
                                bulkCopy.ColumnMappings.Add("Base_TeachPoint", "BaseTeachPoint");
                                bulkCopy.ColumnMappings.Add("Hosp_Code", "HospCode");
                                bulkCopy.ColumnMappings.Add("Creater", "Creater");
                                bulkCopy.ColumnMappings.Add("CreateTime", "CreateTime");
                                bulkCopy.ColumnMappings.Add("Base_Ratio", "BaseRatio");
                                bulkCopy.ColumnMappings.Add("Teacher_Point", "TeacherPoint");
                                bulkCopy.ColumnMappings.Add("STrain_Point", "STrainPoint");
                                bulkCopy.ColumnMappings.Add("Remark", "Remark");

                                bulkCopy.WriteToServer(dTs);
                            }
                        }
                    }

                    File.Delete(filePath); //刪除上傳的檔案
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '匯入成功！', icon: 'success'});", true);
                    Session.Remove("isUploaded");
                }
                else
                {
                    Session.Remove("isUploaded");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '請選擇正確的檔案格式！', icon: 'error'});", true);
                }
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '請選擇檔案！', icon: 'warning'});", true);
            //}
        }
        catch (Exception ex)
        {
            Session.Remove("isUploaded");
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire({title: '發生錯誤！', icon: 'error', text: '" + ex.Message.Replace("'", "\\'") + "'});", true);
        }
    }

    #endregion
}