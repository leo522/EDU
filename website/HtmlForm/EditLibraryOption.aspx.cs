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

public partial class EditLibraryOption : System.Web.UI.Page
{
    private List<FORM_TEMPLATE_LIBRARY_OPTION> CurrentList
    {
        get
        {
            return Session["HtmlFormLibraryOption"] as List<FORM_TEMPLATE_LIBRARY_OPTION>;
        }
        set
        {
            Session["HtmlFormLibraryOption"] = value;
        }
    }


    private int LibraryID
    {
        get
        {
            return Convert.ToInt32(Request.QueryString["library_id"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //RadGrid1.DataBind();

        }
        lblMsg.Text = "";
    }


    private void ReadData()
    {
        RadGrid1.DataSource = null;
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "OPTION_ID" };

        HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
        List<FORM_TEMPLATE_LIBRARY_OPTION> list = vc.ListFormTemplateLibraryOption(LibraryID);
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

        string type = (editedItem.FindControl("ddlType") as DropDownList).SelectedValue;
        string text = (editedItem.FindControl("tbText") as TextBox).Text;
        double? point = (editedItem.FindControl("rntbPoint") as RadNumericTextBox).Value;
        int order = Convert.ToInt32((editedItem.FindControl("rntbOrder") as RadNumericTextBox).Value);
        bool answer = (editedItem.FindControl("cbAnswer") as CheckBox).Checked;
        HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        pc.InsertTemplateLibraryOption(LibraryID, type, text, point, order, answer);

    }
    protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        
        if (e.CommandName != RadGrid.DeleteSelectedCommandName)
        {
            pc.DeleteTemplateLibraryOption(CurrentList[e.Item.DataSetIndex].OPTION_ID);
        }
    }
    protected void RadGrid1_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridEditableItem editedItem = e.Item as GridEditableItem;
        string type = (editedItem.FindControl("ddlType") as DropDownList).SelectedValue;
        string text = (editedItem.FindControl("tbText") as TextBox).Text;
        double? point = (editedItem.FindControl("rntbPoint") as RadNumericTextBox).Value;
        int order = Convert.ToInt32((editedItem.FindControl("rntbOrder") as RadNumericTextBox).Value);
        bool answer = (editedItem.FindControl("cbAnswer") as CheckBox).Checked;

        HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        FORM_TEMPLATE_LIBRARY_OPTION option = CurrentList[e.Item.DataSetIndex];
        pc.UpdateTemplateLibraryOption(option.OPTION_ID, type, text, point, order, answer);
    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.DeleteSelectedCommandName)
        {
            HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
            foreach (GridItem item in RadGrid1.SelectedItems)
            {
                pc.DeleteTemplateLibraryOption(CurrentList[item.DataSetIndex].OPTION_ID);
            }
            ReadData();
            RadGrid1.DataBind();
        }

    }
    
    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {

    }
}