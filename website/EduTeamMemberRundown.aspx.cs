using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class EduTeamMemberRundown : AuthPage
{
    private EduTermDto CurrentData
    {
        get
        {
            return Session["CurrentOpenCourseEduTerm"] as EduTermDto;
        }
        set
        {
            Session["CurrentOpenCourseEduTerm"] = value;
        }
    }

    private List<MemberDto> SelectionList
    {
        get
        {
            return Session["MemberSelectionList"] as List<MemberDto>;
        }
        set
        {
            Session["MemberSelectionList"] = value;
        }
    }

    private List<MemberDto> SelectedList
    {
        get
        {
            return Session["MemberSelectedList"] as List<MemberDto>;
        }
        set
        {
            Session["MemberSelectedList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!this.AuthRoles.Contains("DepSec")&&!this.AuthRoles.Contains("Admin") && !this.AuthRoles.Contains("SuperAdmin"))
            {
                panControl.Visible = false;
                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
                btnSaveAll.Visible = false;
                btnSubmit.Visible = false;
            }

            if (Request.QueryString["EduTermID"] != null)
            {
                BindDept();
                ddlJobCode.DataBind();
                ddlJobCode.SelectedIndex = 0;
                LoadEduTerm(Request.QueryString["EduTermID"].ToString());

                //ddlDept.SelectedValue = CurrentData.Department;
                EduTeamDto teaminfo = service.GetEduTeamByJobCode(CurrentData.JobCode);
                if (teaminfo != null)
                {
                    
                    TreeViewComboBox1.SelectedValue = teaminfo.EduTeamCode;
                    TreeViewComboBox1.SelectedText = teaminfo.EduTeamName;
                }

                //ddlTeamCdoe.DataBind();
                
                //ddlTeamCdoe.SelectedIndex = 0;

                ReadSelectedMembers();
                ReadSelectionMembers();
            }
            else
            {
                ShowMessage("參數錯誤");
                CloseWindow(false);
            }

        }
        TreeViewComboBox1.SelectedChanged += new EventHandler(TreeViewComboBox1_SelectedChanged);
    }

    void TreeViewComboBox1_SelectedChanged(object sender, EventArgs e)
    {
        ReadSelectionMembers();
    }

    private void ReadSelectedMembers()
    {
        List<MemberDto> list = service.GetSelectedMembers(CurrentData);

        SelectedList = list;

        lbSelected.DataTextField = "DisplayName";
        lbSelected.DataValueField = "MemberID";
        lbSelected.DataSource = list;

        lbSelected.DataBind();
        RefreshMemberCount();
    }


    private void ReadSelectionMembers()
    {
        List<string> ids = new List<string>();
        foreach (MemberDto dto in SelectedList)
        {
            ids.Add(dto.MemberID);
        }

        List<MemberDto> list = service.GetSelectionMembers(TreeViewComboBox1.SelectedValue, ddlJobCode.SelectedValue == "--" ? "" : ddlJobCode.SelectedValue, ddlDept.SelectedValue, ids, CurrentData.DateFrom, CurrentData.DateTo);
        SelectionList = list;

        lbSelection.DataTextField = "DisplayName";
        lbSelection.DataValueField = "MemberID";
        lbSelection.DataSource = list;

        lbSelection.DataBind();
    }


    private void BindDept()
    {
        List<SelectGroupTypeDto> list = service.GetTermUnit("EduAct_Dept");
        SelectGroupTypeDto newdto = new SelectGroupTypeDto();
        newdto.name = "";
        newdto.code = "";
        list.Insert(0, newdto);
        ddlDept.DataValueField = "code";
        ddlDept.DataTextField = "Name";
        ddlDept.DataSource = list;
        ddlDept.DataBind();
    }

    private void LoadEduTerm(string id)
    {
        try
        {
            CurrentData = service.GetEduTermByID(id);
            lblEduStopCode.Text = CurrentData.EduStopCode;
            lblName.Text = CurrentData.Name;
            lblDate.Text = CurrentData.DateFromToStr;
            lblMemberCount.Text = CurrentData.Capacity.ToString() + "人";
        }
        catch (Exception ex)
        {
            ShowMessage("資料錯誤:" + ex.Message);
            CloseWindow(false);
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        service.SaveEduTeamMemberRundown(CurrentData, SelectedList);
        CloseWindow(false);
    }


    protected void btnSaveAll_Click(object sender, EventArgs e)
    {
        service.SaveAllEduTeamMemberRundown(CurrentData, SelectedList);
        CloseWindow(false);
    }

    protected void ddlTeamCdoe_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReadSelectionMembers();
    }
    protected void ddlJobCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReadSelectionMembers();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int[] selected = lbSelection.GetSelectedIndices();
        foreach (int i in selected)
        {
            SelectedList.Add(SelectionList.Where(c => c.MemberID == lbSelection.Items[i].Value).FirstOrDefault());

        }

        ReadSelectionMembers();
        lbSelected.DataSource = SelectedList;
        lbSelected.DataBind();
        RefreshMemberCount();

        //SelectedList.Add(SelectionList.Where(c => c.MemberID == lbSelection.SelectedValue).FirstOrDefault());
        //ReadSelectionMembers();
        //lbSelected.DataSource = SelectedList;
        //lbSelected.DataBind();
        //RefreshMemberCount();
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        int[] selected = lbSelected.GetSelectedIndices();
        foreach (int i in selected)
        {
            SelectedList.Remove(SelectedList.Where(c => c.MemberID == lbSelected.Items[i].Value).FirstOrDefault());
        }
        ReadSelectionMembers();
        lbSelected.DataSource = SelectedList;
        lbSelected.DataBind();
        RefreshMemberCount();


        //SelectedList.Remove(SelectedList.Where(c => c.MemberID == lbSelected.SelectedValue).FirstOrDefault());
        //ReadSelectionMembers();
        //lbSelected.DataSource = SelectedList;
        //lbSelected.DataBind();
        //RefreshMemberCount();
    }

    private void RefreshMemberCount()
    {
        //lblMemberCount.Text = SelectedList.Count.ToString() + "人";
        lblChoiceCount.Text = SelectedList.Count.ToString() + "人";

    }
    protected void ddlDept_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ReadSelectionMembers();
    }

}