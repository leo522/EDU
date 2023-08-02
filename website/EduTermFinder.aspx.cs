﻿using System;
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

public partial class EduTermFinder : AuthPage
{
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
    protected void Page_Load(object sender, EventArgs e)
    {
        //AddPostbackControl(RadGrid1);
        if (!IsPostBack)
        {
            if (DateTime.Now.Month >= 3)
            {
                tbEduYear.Text = (DateTime.Now.Year - 1911).ToString("000");
            }
            else
            {
                tbEduYear.Text = (DateTime.Now.Year - 1911 - 1).ToString("000");
            }
            
            BindDept();
            if (!new string[] { "7102", "7101", "7100" }.Contains(DeptCode))
            {
                ddlUnit.SelectedValue = this.DeptCode;
                cbSelf.Checked = false;
            }
            else
            {
                ddlUnit.SelectedValue = null;
                cbSelf.Checked = true;
            }

        }
        lblMsg.Text = "";
    }
    protected void CloseWindow()
    {
        string codes = "";
        string names = "";
        foreach (GridDataItem item in RadGrid1.SelectedItems)
        {
            string id = item.GetDataKeyValue("EduTermID").ToString();
            string name = item.GetDataKeyValue("Name").ToString();

            codes += id + "#spilter#";
            names += name + "#spilter#";

        }

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID + "RunOpenWin", @"
var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            var oArg = new Object();
            oArg.SelectTermIDs = '"+codes+@"';
            oArg.SelectTermNames = '"+names+@"';
            oWindow.close(oArg);", true);
    }

    private void ReadData()
    {
        List<EduTermDto> list = service.FindEduTerms(tbEduStopCode.Text == "" ? null : tbEduStopCode.Text,
            tbName.Text == "" ? null : tbName.Text,
            rdpDateBegin.SelectedDate,
            rdpDateEnd.SelectedDate,
            cbSelf.Checked ? this.EmpCode : null,
            ddlUnit.SelectedValue,
            tbEduYear.Text,
            TreeViewComboBox1.SelectedValue);

        RadGrid1.DataSource = list;

    }

    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        SelectGroupTypeDto nullitem = new SelectGroupTypeDto();
        nullitem.code = null;
        nullitem.name = "";
        list.Insert(0, nullitem);
        ddlUnit.DataValueField = "code";
        ddlUnit.DataTextField = "Name";
        ddlUnit.DataSource = list;
        ddlUnit.DataBind();
    }

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        //ReadData();
    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        RadGrid1.DataBind();
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        CloseWindow();
    }
}