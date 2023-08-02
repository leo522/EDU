using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class EduTeamQuery : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    private List<EduTeamDto> CurrentList
    {
        get
        {
            return Session["EduTeamList"] as List<EduTeamDto>;
        }
        set
        {
            Session["EduTeamList"] = value;
        }
    }

    private List<EduTeamDto> CurrentListAll
    {
        get
        {
            return Session["EduTeamListAll"] as List<EduTeamDto>;
        }
        set
        {
            Session["EduTeamListAll"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        tvcbQuery.SelectedChanged += new EventHandler(tvcbQuery_SelectedChanged);
        if (!IsPostBack)
        {
            ReadData();
        }

    }

    void tvcbQuery_SelectedChanged(object sender, EventArgs e)
    {
        ReadData();
    }

    private void ReadCombobox()
    {
        List<EduTeamDto> list = service.ReadEduTeams();
        CurrentListAll = list;

        tvcbQuery.TreeDataFieldID = "EduTeamCode";
        tvcbQuery.TreeDataFieldParentID = "parentEduTeamCode";
        tvcbQuery.TreeDataTextField = "EduTeamName";
        tvcbQuery.TreeDataSource = CurrentListAll;
        tvcbQuery.DataBind();
    }

    private void ReadData()
    {
        ReadCombobox();
        List<EduTeamDto> list = CurrentListAll;
        if (tvcbQuery.SelectedValue != null && tvcbQuery.SelectedValue != "")
        {
            RadTreeNode node = tvcbQuery.TreeView.FindNodeByValue(tvcbQuery.SelectedValue);

            List<string> codelist = new List<string>();
            codelist.Add(node.Value);
            foreach (RadTreeNode subnode in node.GetAllNodes())
            {
                codelist.Add(subnode.Value);
            }

            list = list.Where(c => codelist.Contains(c.EduTeamCode)).ToList();

            foreach (EduTeamDto dto in list)
            {
                if (dto.EduTeamCode == node.Value)
                {
                    dto.ParentEduTeamCode = null;
                }
            }
        }


        CurrentList = list;
        RadTreeView1.DataFieldID = "EduTeamCode";
        RadTreeView1.DataFieldParentID = "parentEduTeamCode";
        RadTreeView1.DataTextField = "EduTeamName";
        RadTreeView1.DataValueField = "EduTeamCode";
        RadTreeView1.DataSource = CurrentList;
        RadTreeView1.DataBind();
        RadTreeView1.ExpandAllNodes();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        tvcbQuery.SelectedValue = null;
        tvcbQuery.SelectedText = "";
        ReadData();
    }
}