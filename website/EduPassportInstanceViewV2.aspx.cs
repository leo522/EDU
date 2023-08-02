using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportInstanceViewV2 : AuthPage
{
    private EduPassportInstanceDto CurrentInstance
    {
        get
        {
            return ViewState["CurrentInstance"] as EduPassportInstanceDto;
        }
        set
        {
            ViewState["CurrentInstance"] = value;
        }
    }

    private List<EduPassportInsItemDto> CurrentInstanceItems
    {
        get
        {
            return CurrentInstance.EduPassportInsItems.ToList();
        }
    }

    private List<EduPassportInsItemDto> CurrentSubInstanceItems
    {
        get
        {
            return CurrentInstance.EduPassportInsItems.Where(c => CurrentGroup == "全部顯示" || c.類別 == CurrentGroup || (CurrentGroup == "其他項目" && (c.類別 == null || c.類別 == ""))).OrderBy(c => c.Status).ThenBy(c => c.Seq).ToList();
        }
    }

    private List<EduPassportInsItemDto> CurrentSubInstanceUndoItems
    {
        get
        {
            return CurrentSubInstanceItems.Where(c => c.Status == "0").ToList();
        }
    }

    private List<EduPassportInsItemDto> CurrentSubInstanceWaitingItems
    {
        get
        {
            return CurrentSubInstanceItems.Where(c => c.Status == "1").ToList();
        }
    }

    private List<EduPassportInsItemDto> CurrentSubInstanceDoneItems
    {
        get
        {
            return CurrentSubInstanceItems.Where(c => c.Status == "V").ToList();
        }
    }  

    private string CurrentGroup
    {
        get
        {
            if (ViewState["CurrentGroup"] != null)
            {
                return ViewState["CurrentGroup"].ToString();
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["CurrentGroup"] = value;
        }
    }

    private string CurrentInstanceID
    {
        get
        {
            return Request.QueryString["ID"];
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string selgroup = Univar.Storage.Session.Get("IID" + CurrentInstanceID + "_SelectedGroup");
            
            if (selgroup != null)
            {
                CurrentGroup = selgroup;
            }
            ReadData();

        }
    }


    private void ReadData()
    {
        if (CurrentInstanceID == null)
        {
            ShowMessageAndGo("參數傳遞錯誤", "EduPassportInstanceList.aspx");
            return;
        }

        EduPassportInstanceDto ins = service.GetEduPassportInstanceByID(CurrentInstanceID);

        if (ins.EmpCode != this.EmpCode)
        {
            ShowMessageAndGo("不要偷看別人的護照阿!", "EduPassportInstanceList.aspx");
            return;
        }

        CurrentInstance = ins;
        lbPassportName.Text = ins.TemplateName;


        rlvUndoItems.DataSource = CurrentSubInstanceUndoItems;
        rlvUndoItems.DataBind();


        rlvWaitingItems.DataSource = CurrentSubInstanceWaitingItems;
        rlvWaitingItems.DataBind();


        rlvDoneItems.DataSource = CurrentSubInstanceDoneItems;
        rlvDoneItems.DataBind();
        List<string> groups = CurrentInstanceItems.Select(c=> c.類別).Distinct().ToList();
        rmGroups.Items.Clear();

        foreach(string group in groups)
        {
            if (group == "" || group == null)
            {
                rmGroups.Items.Add(new RadMenuItem("其他項目"));
            }
            else
            {
                rmGroups.Items.Add(new RadMenuItem(group));
            }
        }
        rmGroups.Items.Add(new RadMenuItem("全部顯示"));

        if (CurrentGroup != null)
        {
            foreach (RadMenuItem i in rmGroups.Items)
            {
                if(i.Text == CurrentGroup)
                {
                    i.Selected = true;
                }
            }
        }
        int datacount = ins.EduPassportInsItems.Count();
        int necessarycount = ins.EduPassportInsItems.Count(c => c.IsNecessary == true);
        int notnecessarycount = ins.EduPassportInsItems.Count(c => c.IsNecessary == false);
        int fincount = ins.EduPassportInsItems.Count(c => c.Status == "V");
        int finnecessarycount = ins.EduPassportInsItems.Count(c =>c.IsNecessary == true && c.Status == "V");
        int finnotnecessarycount = ins.EduPassportInsItems.Count(c =>c.IsNecessary == false && c.Status == "V");


        lbNecessaryFinishRate.Text = ins.NecessaryFinishRate;
        lbNecessaryNotFinishRate.Text = ins.NecessaryNotFinishRate;
        lbNecessaryWaitingRate.Text = ins.NecessaryWaitingRate;
        lbNonNecessaryFinishRate.Text = ins.NonNecessaryFinishRate;
        lbNonNecessaryNotFinishRate.Text = ins.NonNecessaryNotFinishRate;
        lbNonNecessaryWaitingRate.Text = ins.NonNecessaryWaitingRate;

        //if(datacount>0)
        //{
        //    lbAllRate.Text = (fincount * 100 / datacount).ToString("0") + "%";
        //}
        //else
        //{
        //    lbAllRate.Text = "N/A";
        //}

        //if (necessarycount > 0)
        //{
        //    lbNecessaryRate.Text = (finnecessarycount * 100 / necessarycount).ToString("0") + "%";
        //}
        //else
        //{
        //    lbNecessaryRate.Text = "N/A";
        //}

        //if (notnecessarycount > 0)
        //{
        //    lbChoiceRate.Text = (finnotnecessarycount * 100 / notnecessarycount).ToString("0") + "%";
        //}
        //else
        //{
        //    lbChoiceRate.Text = "N/A";
        //}

        liDesc.Text = ins.TemplateDesc;



    }

    protected void rgList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string id = (e.Item as GridDataItem).GetDataKeyValue("IItemID").ToString();

            EduPassportInsItemDto iitem = CurrentInstanceItems.Where(c => c.IItemID == id).FirstOrDefault();

            ImageButton btnEdit = e.Item.FindControl("btnEdit") as ImageButton;
            
            if (iitem != null)
            {
                switch(iitem.Status)
                {
                    case "0":
                        btnEdit.ToolTip = "填寫";
                        btnEdit.ImageUrl = "~/Images/edit.gif";
                        break;
                    case "1":
                        btnEdit.ToolTip = "等待審核中";
                        btnEdit.ImageUrl = "~/Images/Wait.png";
                        break;
                    case "V":
                        btnEdit.ToolTip = "已完成";
                        btnEdit.ImageUrl = "~/Images/fin.png";
                        break;
                }

            }
        }
    }

    protected void rgList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //GridDataItem item = (sender as ImageButton).Parent.Parent as GridDataItem;
        //string id = item.GetDataKeyValue("IItemID").ToString();

        //Response.Redirect("EduPassportInsItemEdit.aspx?ID=" + id);

        RadListViewDataItem item = (sender as ImageButton).Parent as RadListViewDataItem;
        string id = item.GetDataKeyValue("IItemID").ToString();

        Response.Redirect("EduPassportInsItemEdit.aspx?ID=" + id);

    }


    protected void RadMenu1_ItemClick(object sender, RadMenuEventArgs e)
    {
        
        CurrentGroup = e.Item.Text;
        Univar.Storage.Session.Set("IID" + CurrentInstanceID + "_SelectedGroup", CurrentGroup);

        rlvUndoItems.DataSource = CurrentSubInstanceUndoItems;
        rlvUndoItems.DataBind();


        rlvWaitingItems.DataSource = CurrentSubInstanceWaitingItems;
        rlvWaitingItems.DataBind();


        rlvDoneItems.DataSource = CurrentSubInstanceDoneItems;
        rlvDoneItems.DataBind();

    }

    protected void rlvItems_ItemDataBound(object sender, RadListViewItemEventArgs e)
    {
        if (e.Item is RadListViewDataItem)
        {
            string id = (e.Item as RadListViewDataItem).GetDataKeyValue("IItemID").ToString();

            EduPassportInsItemDto iitem = CurrentInstanceItems.Where(c => c.IItemID == id).FirstOrDefault();

            ImageButton btnEdit = e.Item.FindControl("btnEdit") as ImageButton;

            

            if (iitem != null)
            {
                string importantimgtag = "";
                

                if(iitem.IsNecessary)
                {
                    importantimgtag = "_i";
                }
                switch (iitem.Status)
                {
                    case "0":
                        btnEdit.ToolTip = "填寫";
                        btnEdit.ImageUrl = "~/Images/edit" + importantimgtag + ".gif";
                        break;
                    case "1":
                        btnEdit.ToolTip = "等待審核中";
                        btnEdit.ImageUrl = "~/Images/Wait" + importantimgtag + ".png";
                        break;
                    case "V":
                        btnEdit.ToolTip = "已完成";
                        btnEdit.ImageUrl = "~/Images/fin" + importantimgtag + ".png";
                        break;
                }

            }
        }
    }
}