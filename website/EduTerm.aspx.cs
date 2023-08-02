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

public partial class EduTerm : AuthPage
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

    public List<string> SelectedEdutermIDs
    {
        get
        {
            return ViewState["CurrentSelectedEduTermIDs"] as List<string>;
        }
        set
        {
            ViewState["CurrentSelectedEduTermIDs"] = value;
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
        //AddPostbackControl(RadGrid1);
        if (!IsPostBack)
        {
            if (DateTime.Now.Month > 7)
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
                ddlUnit.SelectedValue = null;
                cbSelf.Checked = false;
            }
            else
            {
                ddlUnit.SelectedValue = null;
                cbSelf.Checked = true;
            }
            //ReadData();
            //RadGrid1.DataBind();

        }
        lblMsg.Text = "";

        if (!this.AuthRoles.Contains("Admin"))
        {
            //ddlUnit.Visible = false;
            //Label9.Visible = false;
            //cbShowAllSub.Visible = false;
            //string[] AdminOnlyCols = new string[] { "Activity", "OpenCourse", "EditTerm" };
            string[] AdminOnlyCols = new string[] { "Activity", "OpenCourse", "FormReqSetting" };
            string[] allowcol = new string[] { "Students", "FormSetting" };

            foreach (GridColumn col in RadGrid1.Columns)
            {
                if (AdminOnlyCols.Contains(col.UniqueName))
                {
                    col.Visible = false;
                }
            }

            foreach(GridTableView grid in RadGrid1.MasterTableView.DetailTables)
            {
                foreach (GridColumn col in grid.Columns)
                {
                    if (AdminOnlyCols.Contains(col.UniqueName))
                    {
                        col.Visible = false;
                    }
                }

                foreach (GridTableView subgrid in grid.DetailTables)
                {
                    foreach (GridColumn col in subgrid.Columns)
                    {
                        if (AdminOnlyCols.Contains(col.UniqueName))
                        {
                            col.Visible = false;
                        }
                    }
                }
            }
            if ((this.AuthRoles.Contains("Coach") && !this.AuthRoles.Contains("DepSec")) || this.AuthRoles.Contains("FormS"))
            {
                foreach (GridColumn col in RadGrid1.Columns)
                {
                    if (col is GridTemplateColumn && !allowcol.Contains(col.UniqueName))
                    {
                        col.Visible = false;
                    }
                }
                foreach (GridTableView grid in RadGrid1.MasterTableView.DetailTables)
                {
                    foreach (GridColumn col in grid.Columns)
                    {
                        if (col is GridTemplateColumn && !allowcol.Contains(col.UniqueName))
                        {
                            col.Visible = false;
                        }
                    }

                    foreach (GridTableView subgrid in grid.DetailTables)
                    {
                        foreach (GridColumn col in subgrid.Columns)
                        {
                            if (col is GridTemplateColumn && !allowcol.Contains(col.UniqueName))
                            {
                                col.Visible = false;
                            }
                        }
                    }
                }
            }

        }
    }


    private void ReadData()
    {
        RadGrid1.DataBind();
        //dsLv0.Select();
    }

    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");

        if (!this.AuthRoles.Contains("Admin") && this.AuthRoles.Contains("DepSec"))
        {
            list = list.Where(c => this.DeptSecDep.Contains(c.code)).ToList();
        }

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

            service.DeleteEduTerms(list.Where(c => c.Creater == this.EmpCode).ToList());
        }
        //ReadData();
        RadGrid1.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        //ReadData();
        if(tbEduYear.Text.Trim() == "")
        {
            ShowMessage("請依學年度進行篩選");
            return;
        }

        RadGrid1.DataBind();
    }

    protected void btnCopyEduYear_Click(object sender, EventArgs e)
    {
        GridItem cmditem = RadGrid1.MasterTableView.GetItems(GridItemType.CommandItem)[0];
        TextBox tbCopyEduYear = cmditem.FindControl("tbCopyEduYear") as TextBox;
        if (tbCopyEduYear.Text == "")
        {
            ShowMessage("未輸入學年度");
            return;
        }
        int eduyear = 0;
        try
        {
            eduyear = Convert.ToInt32(tbCopyEduYear.Text);
        }
        catch
        {
            ShowMessage("學年度輸入格式錯誤");
            return;
        }

        try
        {
            foreach (GridItem item in RadGrid1.SelectedItems)
            {
                if (item.OwnerID == RadGrid1.MasterTableView.ClientID)
                {
                    string edutermid = (item as GridDataItem).GetDataKeyValue("EduTermID").ToString();
                    service.CopyEduTerm(edutermid, eduyear.ToString("000"), this.EmpCode, null);
                }
            }

            ReadData();
            RadGrid1.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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
                if (dto.Creater == this.EmpCode)
                {
                    list.Add(dto);
                    strlist.Add((item as GridDataItem).GetDataKeyValue("EduTermID").ToString());
                }
            }
            //service.DeleteEduTerms(list);
            service.DeleteEduTerms(strlist);
            RadGrid1.DataBind();
        }
        //ReadData();
        
    }

    //設定template column開啟radwindow動作
    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {

            if (!this.AuthRoles.Contains("Admin"))
            {
                GridItem cmdItem = e.Item;
                LinkButton lbtnInsert = cmdItem.FindControl("lbtnInsert") as LinkButton;
                LinkButton lbtnDelete = cmdItem.FindControl("lbtnDelete") as LinkButton;
                Panel panCopyCourse = cmdItem.FindControl("panCopyCourse") as Panel;

                
                if (lbtnInsert != null)
                {
                    lbtnInsert.Visible = false;
                }
                if (lbtnDelete != null)
                {
                    lbtnDelete.Visible = false;
                }

                if (panCopyCourse != null)
                {
                    panCopyCourse.Visible = false;
                }
            }
        }


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
                LinkButton lbtnEditTerm = e.Item.FindControl("lbtnEditTerm") as LinkButton;
                if (lbtnEditTerm != null)
                {
                    lbtnEditTerm.OnClientClick = "openEditWin('" + id + "');return false;";
                }
                LinkButton lbtnOpenCourse = e.Item.FindControl("lbtnOpenCourse") as LinkButton;
                if (lbtnOpenCourse != null)
                {
                    lbtnOpenCourse.OnClientClick = "openCourseWin('" + id + "');return false;";
                }

                LinkButton lbtnListStudent = e.Item.FindControl("lbtnListStudent") as LinkButton;
                if (lbtnListStudent != null)
                {
                    lbtnListStudent.OnClientClick = "openMemberWin('" + id + "');return false;";
                }

                LinkButton lbtnCorchSetting = e.Item.FindControl("lbtnCorchSetting") as LinkButton;
                if (lbtnCorchSetting != null)
                {
                    lbtnCorchSetting.OnClientClick = "openCorchSettingWin('" + id + "');return false;";
                }

                LinkButton lbtnActivity = e.Item.FindControl("lbtnActivity") as LinkButton;
                if (lbtnActivity != null)
                {
                    lbtnActivity.OnClientClick = "document.location.href=\"EduStopActScheduleCalendar.aspx?edutermid=" + id + "\";return false;";
                }
                
                LinkButton lbtnFormSetting = e.Item.FindControl("lbtnFormSetting") as LinkButton;
                if (lbtnFormSetting != null)
                {
                    lbtnFormSetting.OnClientClick = "openFormSettingWin('" + id + "');return false;";
                }

                LinkButton lbtnFormReqSetting = e.Item.FindControl("lbtnFormReqSetting") as LinkButton;
                if (lbtnFormReqSetting != null)
                {
                    lbtnFormReqSetting.OnClientClick = "openFormReqSettingWin('" + id + "');return false;";
                }

                LinkButton lbtnStatistic = e.Item.FindControl("lbtnStatistic") as LinkButton;
                if (lbtnStatistic != null)
                {

                    lbtnStatistic.OnClientClick = "window.open('EduStatistic.aspx?edutermid=" + id + "', '_blank');return false;";
                    //lbtnStatistic.OnClientClick = "document.location.href=\"EduStatistic.aspx?edutermid=" + id + "\";return false;";
                }

                bool hasmamber = Convert.ToBoolean(item.GetDataKeyValue("hasMember"));
                bool hasteacher = Convert.ToBoolean(item.GetDataKeyValue("hasTeacher"));


                if (!hasmamber)
                {
                    Image nomember = e.Item.FindControl("imgNoMember") as Image;
                    nomember.Visible = true;
                }

                if (!hasteacher)
                {
                    Image noteacher = e.Item.FindControl("imgNoTeacher") as Image;
                    noteacher.Visible = true;
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
        e.InputParameters["creater"] = cbSelf.Checked ? this.EmpCode : null;
        e.InputParameters["jobcode"] = TreeViewComboBox1.SelectedValue;

        if (ddlUnit.Visible)
        {
            if (ddlUnit.SelectedValue == "")
            {
                if (this.AuthRoles.Contains("Admin"))
                {
                    e.InputParameters["deptcode"] = ddlUnit.SelectedValue;
                    e.InputParameters["deptsecdeps"] = null;
                }
                else
                {
                    e.InputParameters["deptcode"] = null;
                    e.InputParameters["deptsecdeps"] = this.DeptSecDep;
                }
            }
            else
            {
                e.InputParameters["deptcode"] = ddlUnit.SelectedValue;
                e.InputParameters["deptsecdeps"] = null;
            }

            
            
        }
        else
        {
            e.InputParameters["deptcode"] = null;
            
            e.InputParameters["deptsecdeps"] = this.DeptSecDep;
        }

        if (cbShowAllSub.Visible)
        {
            e.InputParameters["showallsub"] = cbShowAllSub.Checked;
        }
        else
        {
            e.InputParameters["showallsub"] = false;
        }

    }


    protected void RadGrid1_DetailTableDataBind1(object sender, GridDetailTableDataBindEventArgs e)
    {
        
        //e.DetailTableView.CurrentPageIndex = e.DetailTableView.CurrentPageIndex;
        //if (e.DetailTableView.Parent is RadGrid)
        //{
        //    dsLv1.Select();
        //}
        //else
        //{
        //    dsLv2.Select();
        //}
    }
    protected void RadGrid1_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
    {
        //ReadData();
    }
    protected void btnBatchForm_Click(object sender, EventArgs e)
    {
        List<string> eduterms = new List<string>();
        foreach (GridItem item in RadGrid1.SelectedItems)
        {
            
            if (item.OwnerID == RadGrid1.MasterTableView.ClientID)
            {
                string edutermid = (item as GridDataItem).GetDataKeyValue("EduTermID").ToString();
                eduterms.Add(edutermid);
            }
            
        }



        foreach (GridTableView grid in RadGrid1.MasterTableView.DetailTables)
        {
            foreach (GridItem item in grid.ChildSelectedItems)
            {

                string edutermid = (item as GridDataItem).GetDataKeyValue("EduTermID").ToString();
                eduterms.Add(edutermid);
            }

            foreach (GridTableView subgrid in grid.DetailTables)
            {
                foreach (GridItem item in subgrid.ChildSelectedItems)
                {

                    string edutermid = (item as GridDataItem).GetDataKeyValue("EduTermID").ToString();
                    eduterms.Add(edutermid);
                }
            }
        }




        Session["BatchEduFormSettingCurrentEduTerm"] = eduterms.Distinct().ToList();
        Response.Redirect("BatchEduFormSetting.aspx");
    }
}