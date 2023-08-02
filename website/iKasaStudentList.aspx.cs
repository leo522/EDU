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
using System.Text;

public partial class iKasaStudentList : AuthPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AddPostbackControl(RadGrid1);
            int eduyeare = DateTime.Now.Year - 1911;
            int eduyears = eduyeare - 1;
            tbEduYearS.Text = eduyears.ToString();


            //rdpEDate.SelectedDate = DateTime.Now.Date;
            //rdpSDate.SelectedDate = DateTime.Now.Date.AddMonths(-1);
        }
    }


    private void ReadData()
    {
        RadGrid1.DataSource = null;


        List<EduStudentData> list = service.GetiKasaStudentListData(tbEduYearS.Text.Trim(), tbEduYearS.Text.Trim(), TreeViewComboBox1.SelectedValue, rdpSDate.SelectedDate, rdpEDate.SelectedDate, tbEmpCode.Text.Trim());

        ViewState["currentiKASAStudentlist"] = list;

        RadGrid1.DataSource = list;
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (ViewState["currentiKASAStudentlist"] != null)
        {
            RadGrid1.DataSource = ViewState["currentiKASAStudentlist"] as List<EduStudentData>;
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if(tbEduYearS.Text.Trim()== "")
        {
            ShowMessage("請指定學年度");
            return;
        }
        if (TreeViewComboBox1.SelectedValue == null || TreeViewComboBox1.SelectedValue == "")
        {
            ShowMessage("請選擇職稱");
            return;
        }

        ReadData();
        RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridGroupHeaderItem)
        {

            (e.Item as GridGroupHeaderItem).DataCell.Text = (e.Item as GridGroupHeaderItem).DataCell.Text.Substring((e.Item as GridGroupHeaderItem).DataCell.Text.IndexOf(":") + 1);

        }

        if (e.Item is GridDataItem)
        {
            string idno = (e.Item as GridDataItem).GetDataKeyValue("IDNo").ToString();
            string EmpCode = (e.Item as GridDataItem).GetDataKeyValue("EmpCode").ToString();
            
            Button btn = e.Item.FindControl("btniKasa") as Button;
            if (btn != null)
            {
                btn.OnClientClick = "post_to_url('iKASA/main.aspx',{'iKasaIdNo':'" + idno + "'}); return false;";
            }

            Button btntest = e.Item.FindControl("btniKasaTest") as Button;
            if (btntest != null)
            {
                AddPostbackControl(btntest);
                //btntest.OnClientClick = "post_to_url('http://172.18.8.43/Home/Index/" + EmpCode + "',{'iKasaIdNo':'" + idno + "','accessToken':'" + AccessToken + "','OAuthServer':'" + OAuthServer + "'}); return false;";
                if (this.DeptCode == "7000")
                {
                    btntest.Visible = true;
                }
                else
                {
                    btntest.Visible = false;
                }
            }

        }
    }

    protected void btntest_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;

        string idno = item.GetDataKeyValue("IDNo").ToString();
        string EmpCode = item.GetDataKeyValue("EmpCode").ToString();

        HttpResponse response = HttpContext.Current.Response;
        response.Clear();

        StringBuilder s = new StringBuilder();
        s.Append("<html>");
        s.AppendFormat("<body onload='document.forms[\"formred\"].submit()'>");
        s.AppendFormat("<form name='formred' action='{0}' method='post'>", "http://172.18.8.43/Home/Index/" + EmpCode);

        s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", "iKasaIdNo", idno);
        s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", "accessToken", AccessToken);
        s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", "OAuthServer", OAuthServer);
        
        s.Append("</form></body></html>");
        response.Write(s.ToString());
        response.End();
    }

}