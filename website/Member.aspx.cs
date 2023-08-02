using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.OracleClient;
using NPOI.HSSF.UserModel;



public partial class Member : AuthPage
{
    private List<MemberDto> CurrentList
    {
        get
        {
            return Session["MemberList"] as List<MemberDto>;
        }
        set
        {
            Session["MemberList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(RadGrid1);
        AddPostbackControl(btnImport);
        AddPostbackControl(btnExport);
        if (!IsPostBack)
        {
            RadGrid1.DataSource = new List<MemberDto>();
            RadGrid1.DataBind();
        }
        lblMsg.Text = "";

    }


    private void ReadData()
    {
        RadGrid1.DataSource = null;
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "MemberCode" };

        List<string> jobcodes = new List<string>();
        foreach (RadComboBoxItem item in ddlJobCode.CheckedItems)
        {
            jobcodes.Add(item.Value);
        }

        List<MemberDto> list = service.SearchMembersWithExtraInfo(jobcodes, tbMemberCode.Text, rdpDateBegin.SelectedDate, rdpDateEnd.SelectedDate, TreeViewComboBox2.SelectedValue, tbMemberName.Text);
        CurrentList = list;
        RadGrid1.DataSource = list;


        List<string> empcodelist = new List<string>();
        foreach (MemberDto member in list)
        {
            empcodelist.Add(member.IsHospMember);
        }
        service.InsertInfoLog("Member.aspx", empcodelist, this.EmpCode, "查詢會員", "SELECT");

    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (IsPostBack)
        {
            ReadData();
        }
    }


    protected void RadGrid1_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridEditableItem editedItem = e.Item as GridEditableItem;

        string membercode = (editedItem.FindControl("tbMemberCode") as TextBox).Text;
        string membername = (editedItem.FindControl("tbName") as TextBox).Text;
        string jobcode = (editedItem.FindControl("ddlJobCode") as RadComboBox).SelectedValue;
        DateTime? datefrom = (editedItem.FindControl("rdpEditDateBegin") as RadDatePicker).SelectedDate;
        DateTime? dateto = (editedItem.FindControl("rdpEditDateEnd") as RadDatePicker).SelectedDate;
        string eduteamcode = (editedItem.FindControl("TreeViewComboBox1") as TreeViewComboBox).SelectedValue;
        string isHospMember = (editedItem.FindControl("tbisHospMember") as TextBox).Text.ToUpper();
        string Des = (editedItem.FindControl("tbDes") as TextBox).Text;
        string trainingprocess = (editedItem.FindControl("tbTrainingProcess") as TextBox).Text;

        if (membercode == null || membercode.Trim() == "")
        {
            ShowMessage("未輸入學號");
            e.Canceled = true;
            return;
        }
        if (membername==null || membername.Trim() == "")
        {
            ShowMessage("未輸入姓名");
            e.Canceled = true;
            return;
        }
        if (datefrom == null)
        {
            ShowMessage("未選擇訓練起始日");
            e.Canceled = true;
            return;
        }
        if (dateto == null)
        {
            ShowMessage("未選擇訓練結束日");
            e.Canceled = true;
            return;
        }

        if (eduteamcode == null || eduteamcode == "")
        {
            ShowMessage("未選擇組別");
            e.Canceled = true;
            return;
        }


        bool checkdto = service.CheckIsMemberExist(isHospMember, datefrom.Value, dateto.Value);
        if (checkdto)
        {
            ShowMessage("該學員在同一時段已存在資料");
            e.Canceled = true;
            return;
        }
        else
        {
            MemberDto newdto = new MemberDto();
            newdto.MemberCode = membercode;
            newdto.Name = membername;
            newdto.MemberType = jobcode;
            newdto.DateFrom = datefrom.Value;
            newdto.DateTo = dateto.Value;
            if (DateTime.Now.Date >= newdto.DateFrom.Date && DateTime.Now.Date <= newdto.DateTo.Date)
            {
                newdto.Status = null;
            }
            else
            {
                newdto.Status = 'Y';
            }
            newdto.IsHospMember = isHospMember;
            newdto.Des = Des;
            newdto.TrainingProcess = trainingprocess;
            newdto.CreateDate = DateTime.Now;
            newdto.Creater = this.EmpCode;
            newdto.EduTeamCode = eduteamcode;
            service.InsertMember(newdto);
            service.InsertInfoLog("Member.aspx", new List<string>() { isHospMember }, this.EmpCode, "新增會員", "INSERT");
        }

    }
    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName != RadGrid.DeleteSelectedCommandName)
        {
            List<MemberDto> list = new List<MemberDto>() { CurrentList[e.Item.DataSetIndex] };

            service.DeleteMembers(list);

            List<string> empcodelist = new List<string>();
            foreach (MemberDto member in list)
            {
                empcodelist.Add(member.IsHospMember);
            }
            service.InsertInfoLog("Member.aspx", empcodelist, this.EmpCode, "刪除會員", "DELETE");
        }
    }
    protected void RadGrid1_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        MemberDto dto = CurrentList[e.Item.DataSetIndex];
        GridEditableItem editedItem = e.Item as GridEditableItem;

        string membercode = (editedItem.FindControl("tbMemberCode") as TextBox).Text;
        string membername = (editedItem.FindControl("tbName") as TextBox).Text;
        string jobcode = (editedItem.FindControl("ddlJobCode") as RadComboBox).SelectedValue;
        DateTime? datefrom = (editedItem.FindControl("rdpEditDateBegin") as RadDatePicker).SelectedDate;
        DateTime? dateto = (editedItem.FindControl("rdpEditDateEnd") as RadDatePicker).SelectedDate;
        string eduteamcode = (editedItem.FindControl("TreeViewComboBox1") as TreeViewComboBox).SelectedValue;
        string isHospMember = (editedItem.FindControl("tbisHospMember") as TextBox).Text.ToUpper();
        string Des = (editedItem.FindControl("tbDes") as TextBox).Text;
        string trainingprocess = (editedItem.FindControl("tbTrainingProcess") as TextBox).Text;


        if (membercode == null || membercode.Trim() == "")
        {
            ShowMessage("未輸入學號");
            return;
        }
        if (membername == null || membername.Trim() == "")
        {
            ShowMessage("未輸入姓名");
            return;
        }
        if (datefrom == null)
        {
            ShowMessage("未選擇訓練起始日");
            return;
        }
        if (dateto == null)
        {
            ShowMessage("未選擇訓練結束日");
            return;
        }

        if (eduteamcode == null || eduteamcode == "")
        {
            ShowMessage("未選擇組別");
            e.Canceled = true;
            return;
        }

        if (dto.MemberCode != membercode)
        {
            MemberDto checkdto = service.ReadMemberByMemberCode(membercode);
            if (checkdto != null)
            {
                ShowMessage("學號已存在");
                e.Canceled = true;
                return;
            }
        }


        dto.MemberCode = membercode;
        dto.Name = membername;
        dto.MemberType = jobcode;
        dto.DateFrom = datefrom.Value;
        dto.DateTo = dateto.Value;
        if (DateTime.Now.Date >= dto.DateFrom.Date && DateTime.Now.Date <= dto.DateTo.Date)
        {
            dto.Status = null;
        }
        else
        {
            dto.Status = 'Y';
        }
        dto.IsHospMember = isHospMember;
        dto.Des = Des;
        dto.TrainingProcess = trainingprocess;
        dto.LastModifier = this.EmpCode;
        dto.LastModifyDate = DateTime.Now;
        dto.EduTeamCode = eduteamcode;
        service.UpdateMember(dto);


        List<string> empcodelist = new List<string>();

        empcodelist.Add(isHospMember);

        service.InsertInfoLog("Member.aspx", empcodelist, this.EmpCode, "修改會員資料", "UPDATE");

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        RadGrid1.DataBind();
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string filepath = Server.MapPath(".") + "\\temp\\";
            string filename = "(" + Guid.NewGuid().ToString() + ")" + FileUpload1.FileName;
            try
            {
                byte[] data = FileUpload1.FileBytes;
                FileStream fs = new FileStream(filepath + filename, FileMode.OpenOrCreate);
                fs.Write(data, 0, data.Length);
                fs.Close();

                DataTable dt = load_data(filepath, filename);



                List<string> result = service.ImportMembers(dt, this.EmpCode);

                foreach (string msg in result)
                {
                    lblMsg.Text += msg + "<br />";
                }


            }
            catch (Exception ex)
            {
                lblMsg.Text = "匯入失敗：" + ex.Message;
            }
            finally
            {
                if (File.Exists(filepath + filename))
                {
                    File.Delete(filepath + filename);
                }
                ReadData();
                RadGrid1.DataBind();
            }
        }
    }

    public DataTable TxtConvertToDataTable(string File, string TableName, string delimiter)
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        StreamReader s = new StreamReader(File, System.Text.Encoding.Default);
        //string ss = s.ReadLine();//skip the first line
        string[] columns = s.ReadLine().Split(delimiter.ToCharArray());
        ds.Tables.Add(TableName);
        foreach (string col in columns)
        {
            bool added = false;
            string next = "";
            int i = 0;
            while (!added)
            {
                string columnname = col + next;
                columnname = columnname.Replace("#", "");
                columnname = columnname.Replace("'", "");
                columnname = columnname.Replace("&", "");

                if (!ds.Tables[TableName].Columns.Contains(columnname))
                {
                    ds.Tables[TableName].Columns.Add(columnname.ToUpper());
                    added = true;
                }
                else
                {
                    i++;
                    next = "_" + i.ToString();
                }
            }
        }

        string AllData = s.ReadToEnd();
        string[] rows = AllData.Split("\n".ToCharArray());

        foreach (string r in rows)
        {
            string[] items = r.Split(delimiter.ToCharArray());
            ds.Tables[TableName].Rows.Add(items);
        }

        s.Close();

        dt = ds.Tables[0];

        return dt;
    }




    public DataTable load_data(string filepath, string filename)
    {
        if (filename.ToLower().EndsWith(".csv"))
        {
            return TxtConvertToDataTable(filepath + filename, filename, ",");
        }
        else
        {
            return Utility.ReadExcelAsTableNPOI(filepath + filename);
        }

        //string strCon = "";
        //string sheetname = "";
        //OleDbConnection oledb_con = null;
        //if (filename.ToLower().EndsWith(".csv"))
        //{
        //    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + "; Extended Properties='text;HDR=Yes;FMT=Delimited'";
        //    sheetname = "[" + filename + "]";
        //    oledb_con = new OleDbConnection(strCon);
        //    oledb_con.Open();
        //}
        //else
        //{
        //    strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + filepath + filename + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
        //    oledb_con = new OleDbConnection(strCon);
        //    oledb_con.Open();
        //    string tablename = oledb_con.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
        //    sheetname = "[" + tablename + "]";//"[Sheet1$]";
        //}
         
        
        
        //try
        //{

        //    OleDbDataAdapter adp = new OleDbDataAdapter(" SELECT * FROM " + sheetname, oledb_con);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    return dt;
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //finally
        //{
        //    oledb_con.Close();
        //}
    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.DeleteSelectedCommandName)
        {
            List<MemberDto> list = new List<MemberDto>();
            foreach (GridItem item in RadGrid1.SelectedItems)
            {
                MemberDto dto = CurrentList[item.DataSetIndex];
                list.Add(dto);
            }
            try
            {
                service.DeleteMembers(list);
            }
            catch(Exception ex)
            {
                ShowMessage("刪除資料失敗：" + ex.Message);
                return;
            }

            List<string> empcodelist = new List<string>();
            foreach (MemberDto member in list)
            {
                empcodelist.Add(member.IsHospMember);
            }
            service.InsertInfoLog("Member.aspx", empcodelist, this.EmpCode, "刪除會員", "DELETE");

        }
    }
    protected void ddlJobCode_DataBound(object sender, EventArgs e)
    {
        if (ddlJobCode.Items.Count > 0)
        {
            ddlJobCode.SelectedIndex = 0;
            foreach (RadComboBoxItem item in ddlJobCode.Items)
            {
                //item.Checked = true;
            }
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (CurrentList != null && CurrentList.Count > 0)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("學號");
            dt.Columns.Add("姓名");
            dt.Columns.Add("職稱");
            dt.Columns.Add("起始日");
            dt.Columns.Add("結束日");
            dt.Columns.Add("組別");
            dt.Columns.Add("說明");
            dt.Columns.Add("員工編號");
            dt.Columns.Add("訓練階段");

            foreach (MemberDto mem in CurrentList)
            {
                DataRow dr = dt.NewRow();
                dr["學號"] = mem.MemberCode;
                dr["姓名"] = mem.Name;
                dr["職稱"] = mem.MemberType;
                dr["起始日"] = mem.DateFrom.ToString("yyyy/MM/dd");
                dr["結束日"] = mem.DateTo.ToString("yyyy/MM/dd");
                dr["組別"] = mem.EduTeamCode;
                dr["說明"] = mem.Des;
                dr["員工編號"] = mem.IsHospMember;
                dr["訓練階段"] = mem.TrainingProcess;
                dt.Rows.Add(dr);
            }


            Utility uti = new Utility();

            byte[] bytes = uti.ExportDataTableToExcel(dt);


            HttpResponse response = Response;

            response.Clear();

            //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

            response.AddHeader("Content-Type", "binary/octet-stream");

            response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + bytes.Length.ToString());

            response.BinaryWrite(bytes);

            response.Flush();
            response.End();


        }
    }
}