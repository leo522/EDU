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

public partial class TeacherSetting : AuthPage
{
    private List<EduTermDto> CurrentListAll
    {
        get
        {
            if (Session["EduTermListAll"] == null)
            {
                ReadData();
            }
            return Session["EduTermListAll"] as List<EduTermDto>;
        }
        set
        {
            Session["EduTermListAll"] = value;
        }
    }

    private List<EduTermDto> CurrentList
    {
        get
        {
            if (Session["EduTermList"] == null)
            {
                ReadData();
            }
            return Session["EduTermList"] as List<EduTermDto>;
        }
        set
        {
            Session["EduTermList"] = value;
        }
    }

    private List<EduTermDto> CurrentListChild1
    {
        get
        {
            if (Session["EduTermListChild1"] == null)
            {
                ReadData();
            }
            return Session["EduTermListChild1"] as List<EduTermDto>;
        }
        set
        {
            Session["EduTermListChild1"] = value;
        }
    }

    private List<EduTermDto> CurrentListChild2
    {
        get
        {
            if (Session["EduTermListChild2"] == null)
            {
                ReadData();
            }
            return Session["EduTermListChild2"] as List<EduTermDto>;
        }
        set
        {
            Session["EduTermListChild2"] = value;
        }
    }
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
    protected void Page_Load(object sender, EventArgs e)
    {
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
            BindTeacherType();
            //ReadData();
            //RadGrid1.DataBind();
            
        }
        lblMsg.Text = "";
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

    private void BindTeacherType()
    {
        List<EduTeacherTypeDto> list = service.GetTeacherTypes();
        list = list.Where(c => c.RefType == "EduTerm" || c.RefType == "All").ToList();
        rcbTeacherType.DataValueField = "code";
        rcbTeacherType.DataTextField = "name";
        rcbTeacherType.DataSource = list;
        rcbTeacherType.DataBind();
        rcbTeacherType.SelectedIndex = 0;
    }
    private void ReadData()
    {
        if (RadGrid1.DataSourceID == null || RadGrid1.DataSourceID == "")
        {
            RadGrid1.DataSourceID = "dsLv0";
        }
        dsLv0.Select();
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            //ReadData();
        }
    }

    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName != RadGrid.DeleteSelectedCommandName)
        {
            List<EduTermDto> list = new List<EduTermDto>() { CurrentList[e.Item.DataSetIndex] };

            service.DeleteEduTerms(list);
        }
        ReadData();
        //RadGrid1.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.DeleteSelectedCommandName)
        {
            List<string> strlist = new List<string>();
            List<EduTermDto> list = new List<EduTermDto>();
            foreach (GridItem item in RadGrid1.SelectedItems)
            {
                EduTermDto dto = service.GetEduTerm((item as GridDataItem).GetDataKeyValue("EduTermID").ToString());// CurrentList[item.DataSetIndex];
                list.Add(dto);
                strlist.Add((item as GridDataItem).GetDataKeyValue("EduTermID").ToString());
            }
            //service.DeleteEduTerms(list);
            service.DeleteEduTerms(strlist);
        }
        ReadData();
        //RadGrid1.DataBind();
    }

    //設定template column開啟radwindow動作
    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            string id = null;
            if (item.GetDataKeyValue("EduTermID") != null)
            {
                id = item.GetDataKeyValue("EduTermID").ToString();
            }

            
            // EduTermDto term = CurrentListAll.Where(c => c.EduTermID == id).First();

            if (id != null)
            {
                LinkButton lbtnTermTeacherSetting = e.Item.FindControl("lbtnTermTeacherSetting") as LinkButton;
                if (lbtnTermTeacherSetting != null)
                {
                    lbtnTermTeacherSetting.OnClientClick = "openTermWin('" + id + "');return false;";
                }

                LinkButton lbtnMemberTeacherSetting = e.Item.FindControl("lbtnMemberTeacherSetting") as LinkButton;
                if (lbtnMemberTeacherSetting != null)
                {
                    lbtnMemberTeacherSetting.OnClientClick = "openMemberWin('" + id + "');return false;";
                }
         
            }
        }
    }



    protected void RadGrid1_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
    {

    }

    //修改group header
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridGroupHeaderItem)
        {

            (e.Item as GridGroupHeaderItem).DataCell.Text = (e.Item as GridGroupHeaderItem).DataCell.Text.Substring((e.Item as GridGroupHeaderItem).DataCell.Text.IndexOf(":") + 1);

        }
    }
    #region 無資料時隱藏收合圖案
    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        HideExpandColumnRecursive(RadGrid1.MasterTableView);
    }
    public void HideExpandColumnRecursive(GridTableView tableView)
    {
        GridItem[] nestedViewItems = tableView.GetItems(GridItemType.NestedView);
        foreach (GridNestedViewItem nestedViewItem in nestedViewItems)
        {
            foreach (GridTableView nestedView in nestedViewItem.NestedTableViews)
            {
                if (nestedView.Items.Count == 0)
                {
                    TableCell cell = nestedView.ParentItem["ExpandColumn"];
                    cell.Controls[0].Visible = false;
                    cell.Text = " ";
                    nestedViewItem.Visible = false;
                }
                if (nestedView.HasDetailTables)
                {
                    HideExpandColumnRecursive(nestedView);
                }
            }
        }
    }
    #endregion

    protected void dsLv0_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

        e.InputParameters["EduYear"] = tbEduYear.Text;
        e.InputParameters["EduStopCode"] = tbEduStopCode.Text == "" ? null : tbEduStopCode.Text;
        e.InputParameters["name"] = tbName.Text == "" ? null : tbName.Text;
        e.InputParameters["datebegin"] = rdpDateBegin.SelectedDate;
        e.InputParameters["dateend"] = rdpDateEnd.SelectedDate;
        e.InputParameters["creater"] = null;
        e.InputParameters["deptcode"] = ddlUnit.SelectedValue;
        e.InputParameters["jobcode"] = TreeViewComboBox1.SelectedValue;

        e.InputParameters["deptsecdeps"] = null;

        
        e.InputParameters["showallsub"] = false;

    }


    protected void RadGrid1_DetailTableDataBind1(object sender, GridDetailTableDataBindEventArgs e)
    {
        
        e.DetailTableView.CurrentPageIndex = e.DetailTableView.CurrentPageIndex;
    }
    protected void RadGrid1_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
    {
    }

    protected void btnSet_Click(object sender, EventArgs e)
    {
        if (rcbVs.SelectedValue == "" || rcbVs.SelectedValue == null)
        {
            ShowMessage("未選擇指導老師");
            return;
        }

        string errorid = "";
        foreach (GridDataItem item in RadGrid1.SelectedItems)
        {
            string id = null;
            if (item.GetDataKeyValue("EduTermID") != null)
            {
                id = item.GetDataKeyValue("EduTermID").ToString();
            }
            if (!service.UpdateTermTeacher(id, rcbTeacherType.SelectedValue, rcbVs.SelectedValue, this.EmpCode, cbAll.Checked))
            {
                errorid += "課程代碼：" + id + "，更新教師資料失敗!\n";
            }
        }
        if (errorid != "")
        {
            ShowMessage(errorid);

        }
        else
        {
            ShowMessage("更新完成");
        }
    }
    protected void odsVs_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters.Add("deptcode", null);
    }
}