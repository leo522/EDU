using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class HealTeachTimeUpload : AuthPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        AddPostbackControl(rauTeachTime);
        AddPostbackControl(btnSubmit);

        if (!IsPostBack)
        {
            BindYear();
            BindMonth();
            BindDept();

        }
    }

    private void BindYear()
    {
        NameValueCollection coll = new NameValueCollection();
        for (int i = DateTime.Now.Year - 4; i < DateTime.Now.Year + 2; i++)
        {
            coll.Add(i.ToString(), i.ToString());
        }
        ddlYear.DataSource = coll;
        ddlYear.DataBind();

        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    }

    private void BindMonth()
    {
        NameValueCollection coll = new NameValueCollection();
        for (int i = 1; i <= 12; i++)
        {
            coll.Add(i.ToString(), i.ToString());
        }
        ddlMonth.DataSource = coll;
        ddlMonth.DataBind();

        ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

    }

    private void BindDept()
    {
        DeptSelector1.Select(this.HospCode, this.LocCode);

        //List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");

        //SelectGroupTypeDto nullitem = new SelectGroupTypeDto();
        //nullitem.code = null;
        //nullitem.name = "";
        //list.Insert(0, nullitem);
        //ddlUnit.DataValueField = "code";
        //ddlUnit.DataTextField = "Name";
        //ddlUnit.DataSource = list;
        //ddlUnit.DataBind();

        
        //ddlUnit.SelectedValue = this.LocCode;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        liResult.Text = "";
        if (ddlYear.SelectedValue == "" || ddlYear.SelectedValue == null)
        {
            ShowMessage("未選擇年份");
            return;
        }

        if (ddlMonth.SelectedValue == "" || ddlMonth.SelectedValue == null)
        {
            ShowMessage("未選擇月份");
            return;
        }

        if ((Convert.ToInt32(ddlYear.SelectedValue) == DateTime.Now.Year && Convert.ToInt32(ddlMonth.SelectedValue) > DateTime.Now.Month) || Convert.ToInt32(ddlYear.SelectedValue) > DateTime.Now.Year)
        {
            ShowMessage("不可上傳未來日期的資料");
            return;
        }

        if (DeptSelector1.SelectDept == null)
        {
            ShowMessage("未選擇部門");
            return;
        }

        if (rauTeachTime.UploadedFiles.Count == 0)
        {
            ShowMessage("未選擇檔案");
            return;
        }
        string filename = Server.MapPath(".") + "\\temp\\" + Guid.NewGuid() + rauTeachTime.UploadedFiles[0].FileName;
        rauTeachTime.UploadedFiles[0].SaveAs(filename);

        DataTable dt = Utility.ReadExcelAsTableNPOI(filename);

        try
        {
            File.Delete(filename);
        }
        catch (Exception ex)
        {
        }

        List<string[]> result = service.UploadHealTeachTime(dt, ddlYear.SelectedValue, ddlMonth.SelectedValue, DeptSelector1.SelectDept.Hospcode, DeptSelector1.SelectDept.Deptcode, this.EmpCode);

        foreach (string[] r in result)
        {
            liResult.Text += "<font color='" + r[1] + "'>" + r[0] + "</font><br/>";
        }

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        liResult.Text = "";
        if (ddlYear.SelectedValue == "" || ddlYear.SelectedValue == null)
        {
            ShowMessage("未選擇年份");
            return;
        }
        if (ddlMonth.SelectedValue == "" || ddlMonth.SelectedValue == null)
        {
            ShowMessage("未選擇月份");
            return;
        }
        if (DeptSelector1.SelectDept == null)
        {
            ShowMessage("未選擇部門");
            return;
        }


        ReadData();
    }

    private void ReadData()
    {
        List<HealTeachTimeDto> list = service.ReadHealTeachTime(ddlYear.SelectedValue, ddlMonth.SelectedValue,DeptSelector1.SelectDept.Hospcode,DeptSelector1.SelectDept.Deptcode);
        rgTime.DataSource = list;
        rgTime.DataBind();
    }

    protected void btnClean_Click(object sender, EventArgs e)
    {
        if (DeptSelector1.SelectDept == null)
        {
            ShowMessage("未選擇部門");
            return;
        }

        string msg = service.CleanHealTeachTime(ddlYear.SelectedValue, ddlMonth.SelectedValue, DeptSelector1.SelectDept.Hospcode, DeptSelector1.SelectDept.Deptcode);
        if (msg != null)
        {
            ShowMessage(msg);
        }
        else
        {
            ShowMessage("清除完成");
            rgTime.DataSource = null;
            rgTime.DataBind();
        }
    }
    protected void rgTime_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if(e.Item is GridDataItem)
        {
            int id = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("ID"));
            string result = service.DeleteHealTeachTime(id);
            if (result != null)
            {
                ShowMessage("刪除失敗：" + result);
            }
            else
            {
                ReadData();
            }
        }
    }
}