using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class EduTeam : AuthPage
{
    private List<EduTeamDto> CurrentList
    {
        get
        {
            return ViewState["EduTeamList"] as List<EduTeamDto>;
        }
        set
        {
            ViewState["EduTeamList"] = value;
        }
    }

    private List<EduTeamDto> CurrentListAll
    {
        get
        {
            return ViewState["EduTeamListAll"] as List<EduTeamDto>;
        }
        set
        {
            ViewState["EduTeamListAll"] = value;
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
    
    protected void RadTreeView1_NodeDrop(object sender, Telerik.Web.UI.RadTreeNodeDragDropEventArgs e)
    {
        string parentID = null;
        if (e.DestDragNode != null)
        {
            parentID = e.DestDragNode.Value;
        }
        EduTeamDto dto = CurrentList.Where(c => c.EduTeamCode == e.SourceDragNode.Value).FirstOrDefault();
        dto.ParentEduTeamCode = parentID;
        service.UpdateEduTeam(dto);
        ReadData();
    }

    protected void RadTreeView1_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
    {
        switch (e.MenuItem.Text)
        {
            case "新增":
                if (tbTeamName.Text.Trim() != "")
                {
                    EduTeamDto newdto = new EduTeamDto();
                    newdto.EduTeamCode = service.GetSerialNo("EduAct_EduTeamCode");
                    newdto.EduTeamName = tbTeamName.Text;
                    newdto.TeamMemberType = tbTeamName.Text;
                    newdto.ParentEduTeamCode = e.Node.Value;
                    newdto.Status = 'V';
                    service.InsertEduTeam(newdto);
                    ReadData();
                }
                break;
            case "刪除":
                if (e.Node.Nodes.Count == 0)
                {
                    EduTeamDto dto = CurrentList.Where(c => c.EduTeamCode == e.Node.Value).FirstOrDefault();

                    service.DeleteEduTeam(dto);
                    ReadData();
                }
                else
                {
                    ShowMessage("尚有子項無法刪除");
                }
                break;

        }
    }
    protected void RadTreeView1_NodeEdit(object sender, RadTreeNodeEditEventArgs e)
    {
        EduTeamDto dto = CurrentList.Where(c => c.EduTeamCode == e.Node.Value).FirstOrDefault();
        dto.EduTeamName = e.Text;
        e.Node.Text = e.Text;

        if (dto.ParentEduTeamCode == null)
        {
            RadTreeNode node = tvcbQuery.TreeView.FindNodeByValue(dto.EduTeamCode);
            if (node != null && node.ParentNode!=null)
            {
                dto.ParentEduTeamCode = node.ParentNode.Value;
            }
        }
        service.UpdateEduTeam(dto);
        ReadData();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (tbTeamName.Text.Trim() != "")
        {
            EduTeamDto newdto = new EduTeamDto();
            newdto.EduTeamCode = service.GetSerialNo("EduAct_EduTeamCode");
            newdto.EduTeamName = tbTeamName.Text;
            newdto.TeamMemberType = tbTeamName.Text;
            if (RadTreeView1.SelectedNode != null)
            {
                newdto.ParentEduTeamCode = RadTreeView1.SelectedNode.Value;
            }
            newdto.Status = 'V';
            service.InsertEduTeam(newdto);
            ReadData();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (RadTreeView1.SelectedNode != null)
        {
            if (RadTreeView1.SelectedNode.Nodes.Count == 0)
            {
                EduTeamDto dto = CurrentList.Where(c => c.EduTeamCode == RadTreeView1.SelectedNode.Value).FirstOrDefault();

                service.DeleteEduTeam(dto);
                ReadData();
            }
            else
            {
                ShowMessage("尚有子項無法刪除");
            }
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        tvcbQuery.SelectedValue = null;
        tvcbQuery.SelectedText = "";
        ReadData();
    }
    protected void btnAddRoot_Click(object sender, EventArgs e)
    {
        if (tbTeamName.Text.Trim() != "")
        {
            EduTeamDto dto = new EduTeamDto();
            dto.EduTeamCode = service.GetSerialNo("EduAct_EduTeamCode");
            dto.EduTeamName = tbTeamName.Text;
            dto.TeamMemberType = tbTeamName.Text;
            dto.Status = 'V';
            service.InsertEduTeam(dto);
            ReadData();
        }
    }
}