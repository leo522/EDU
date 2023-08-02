using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        (Master.FindControl("lbTitle") as Label).Text = "學術活動公告";
        if (!IsPostBack)
        {
            ReadAppointment();
        }
        
    }
    private void ReadAppointment()
    {        
        System.Data.DataTable data = new System.Data.DataTable();
        System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();
        System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
        sqlConnection.ConnectionString = getConnectionString();
        sqlCommand.Connection = sqlConnection;
        string commandText = "SELECT SeminarID, ThemeDes, SeminarWhere, convert(varchar(16),SeminarTimeFrom,120)+'~'+convert(varchar(5),SeminarTimeTo,108) as SeminarTimeAll, SeminarTimeFrom, SeminarTimeTo, convert(varchar(16),RegisterTimeFrom,120)+'~'+convert(varchar(16),RegisterTimeTo,120) as RegisterTimeAll, RegisterTimeFrom, RegisterTimeTo, convert(varchar(16),UploadTimeFrom,120)+'~'+convert(varchar(16),UploadTimeTo,120) as UploadTimeAll, UploadTimeFrom, UploadTimeTo, docurl FROM Seminar where ";
        commandText += " ( (@status='0') or (@status='1' and SeminarTimeTo > getdate()) or (@status='2' and SeminarTimeTo<= getdate())  ) ";
        commandText += " and ( @keyword='' or ThemeDes like '%'+@keyword+'%' )";
        sqlCommand.Parameters.AddWithValue("@status", ddlStatus.SelectedValue.ToString());
        sqlCommand.Parameters.AddWithValue("@keyword", tbName.Text.Trim());
        
        commandText += "ORDER BY SeminarTimeFrom DESC";
        sqlCommand.CommandText = commandText;
        sqlConnection.Open();
        System.Data.SqlClient.SqlDataReader sqlReader = sqlCommand.ExecuteReader();
        data.Load(sqlReader);
        sqlConnection.Close();

        GridView1.DataSource = data;
        Session["data"] = data;

        GridView1.DataBind();

    }
    private static string getConnectionString()
    {
        string returnVal = null;
        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["www_SeminarConnectionString"];
        if (settings != null)
            returnVal = settings.ConnectionString;
        return returnVal;
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
    }

    void btn_Click(object sender, EventArgs e)
    {

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string url = "AddEditSeminar.aspx";
        //    Session["ID"] = DataBinder.Eval(e.Row.DataItem, "SeminarID");
        //    System.Diagnostics.Debug.WriteLine(Session["ID"]);
        //    e.Row.Attributes["onDblClick"] = "location.href='" + url + "'";
        //}
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable dt = Session["data"] as DataTable;
        
        //e.Row.Cells[0].Visible = false;
        //e.Row.Cells[12].Visible = false;
        //e.Row.Cells[10].Visible = false;
        //e.Row.Cells[11].Visible = false;
        if (e.Row.RowIndex >= 0)
        {
            try
            {
                if (DateTime.Now > Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["RegisterTimeTo"]) || DateTime.Now < Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["RegisterTimeFrom"]))
                {
                    (e.Row.Cells[7].FindControl("Buttonapply") as Button).Enabled = false;
                }
            }
            catch
            {
                (e.Row.Cells[7].FindControl("Buttonapply") as Button).Enabled = false;
            }

            if (e.Row.Cells[5].Text == "&nbsp;" || DateTime.Now > Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["UploadTimeTo"]) || DateTime.Now < Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["UploadTimeFrom"]))
            {
                (e.Row.Cells[6].FindControl("Buttonsubmit") as Button).Enabled = false;
            }

            if (!File.Exists((dt.Rows[e.Row.RowIndex]["docurl"].ToString())))
            {
                //e.Row.Cells[10].Enabled = false;
                (e.Row.Cells[11].FindControl("Buttondownfile") as Button).Enabled = false;
                
            }
            //if (DateTime.Now > Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["RegisterTimeTo"]) || DateTime.Now < Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["SeminarTimeFrom"]))
            //{
            //    (e.Row.Cells[11].FindControl("Buttonfix") as Button).Enabled = false;

            //}
        }

    }
    protected void Buttonsubmit_Click(object sender, EventArgs e)
    {
        
        GridViewRow row = ((sender as Button).Parent as TableCell).Parent as GridViewRow;
        DataRow dr = (Session["data"] as DataTable).Rows[row.RowIndex];
        string url = "upload.aspx";
        Session["ID"] = dr["SeminarID"].ToString();
        System.Diagnostics.Debug.WriteLine(Session["ID"]);
        Response.Redirect(url);
    }

    protected void Buttonapply_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((sender as Button).Parent as TableCell).Parent as GridViewRow;
        DataRow dr = (Session["data"] as DataTable).Rows[row.RowIndex];
        //Response.Write(dr["SeminarID"].ToString());
        string url = "RegistSeminar.aspx";
        Session["ID"] = dr["SeminarID"].ToString();
        System.Diagnostics.Debug.WriteLine(Session["ID"]);
        Response.Redirect(url);
    }

    protected void ButtonQueryapply_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((sender as Button).Parent as TableCell).Parent as GridViewRow;
        DataRow dr = (Session["data"] as DataTable).Rows[row.RowIndex];
        //Response.Write(dr["SeminarID"].ToString());
        string url = "RegistSeminar.aspx?editmode=1";
        Session["ID"] = dr["SeminarID"].ToString();
        System.Diagnostics.Debug.WriteLine(Session["ID"]);
        Response.Redirect(url);
    }

    protected void Buttondownfile_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((sender as Button).Parent as TableCell).Parent as GridViewRow;
        DataRow dr = (Session["data"] as DataTable).Rows[row.RowIndex];
        Session["docurl"] = dr["docurl"].ToString();
        System.Net.WebClient wc = new System.Net.WebClient(); //呼叫 webclient 方式做檔案下載
        byte[] xfile = null;
        xfile = wc.DownloadData(Session["docurl"].ToString());
        string xfileName = Server.UrlPathEncode(System.IO.Path.GetFileName(Session["docurl"].ToString()));
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + HttpContext.Current.Server.UrlEncode(xfileName));
        HttpContext.Current.Response.ContentType = "application/octet-stream"; //二進位方式
        HttpContext.Current.Response.BinaryWrite(xfile); //內容轉出作檔案下載
        HttpContext.Current.Response.End(); 
    }
    //protected void Buttonfix_Click(object sender, EventArgs e)
    //{
    //    GridViewRow row = ((sender as Button).Parent as TableCell).Parent as GridViewRow;
    //    DataRow dr = (Session["data"] as DataTable).Rows[row.RowIndex];
    //    string url = "FixDefault.aspx";
    //    Session["ID"] = dr["SeminarID"].ToString();
    //    System.Diagnostics.Debug.WriteLine(Session["ID"]);
    //    Response.Redirect(url);
        
    //}
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadAppointment();
    }
}
