using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Data;
using HtmlFormUtility;
using System.Collections;

public partial class EditLibrary : AuthPage
{
    private List<FORM_TEMPLATE_LIBRARY> CurrentList
    {
        get
        {
            return Session["HtmlFormLibrary"] as List<FORM_TEMPLATE_LIBRARY>;
        }
        set
        {
            Session["HtmlFormLibrary"] = value;
        }
    }


    private int TemplateID
    {
        get
        {
            return Convert.ToInt32(Request.QueryString["template_id"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AddPostbackControl(RadWindowManager1);
            AddPostbackControl(RadGrid1);
            //RadGrid1.DataBind();

        }
        lblMsg.Text = "";
    }


    private void ReadData()
    {
        RadGrid1.DataSource = null;
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "FORM_TEMPLATE_LIBRARY_ID" };

        HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
        List<FORM_TEMPLATE_LIBRARY> list = vc.ListFormTemplateLibrary(TemplateID, tbKeyWord.Text.Trim());
        CurrentList = list;
        RadGrid1.DataSource = list;
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }
    protected void RadGrid1_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridEditableItem editedItem = e.Item as GridEditableItem;
        Hashtable newValues = new Hashtable();
        e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);


        string content = newValues["QUESTION_CONTENT"].ToString();

        HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        pc.InsertTemplateLibrary(TemplateID, content, null);

    }
    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        
        if (e.CommandName != RadGrid.DeleteSelectedCommandName)
        {
            pc.DeleteTemplateLibrary(CurrentList[e.Item.DataSetIndex].FORM_TEMPLATE_LIBRARY_ID);
        }
    }
    protected void RadGrid1_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridEditableItem editedItem = e.Item as GridEditableItem;

        //string content = (editedItem.FindControl("tbQuestion") as TextBox).Text;

        Dictionary<string, object> newValues = new Dictionary<string, object>();
        e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
        string content = newValues["QUESTION_CONTENT"].ToString();


        HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        FORM_TEMPLATE_LIBRARY lib = CurrentList[e.Item.DataSetIndex];

        pc.UpdateTemplateLibrary(lib.FORM_TEMPLATE_LIBRARY_ID, content, null, lib.DISPLAY);
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        if (e.CommandName == RadGrid.DeleteSelectedCommandName)
        {
            
            foreach (GridItem item in RadGrid1.SelectedItems)
            {
                pc.DeleteTemplateLibrary(CurrentList[item.DataSetIndex].FORM_TEMPLATE_LIBRARY_ID);
            }
            ReadData();
            RadGrid1.DataBind();
        }

        if(e.CommandName == "Display")
        {
            FORM_TEMPLATE_LIBRARY lib = CurrentList[e.Item.DataSetIndex];
            pc.UpdateTemplateLibrary(lib.FORM_TEMPLATE_LIBRARY_ID, lib.QUESTION_CONTENT, lib.QUESTION_TYPE, !lib.DISPLAY);
            ReadData();
            RadGrid1.DataBind();
        }

        if (e.CommandName == "OpenWin")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID + "RunOpenWin", "openWin(" + CurrentList[e.Item.DataSetIndex].FORM_TEMPLATE_LIBRARY_ID.ToString() + ");", true);
        }
    }
    
    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item.DataSetIndex >= 0)
        {
            LinkButton lbtn = e.Item.FindControl("lbtnOpenCourse") as LinkButton;
            if (lbtn != null)
            {
                lbtn.OnClientClick = "openWin('?library_id=" + CurrentList[e.Item.DataSetIndex].FORM_TEMPLATE_LIBRARY_ID.ToString() + "');return false;";
            }
        }
    }

}