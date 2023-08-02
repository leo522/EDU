using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class DisplayRadEditor : System.Web.UI.UserControl
{
    public RadEditor CurrentEditor
    {
        get
        {
            return reEditor;
        }
        set
        {
            reEditor = value;
        }
    }

    private bool _readOnly = false;
    public bool ReadOnly
    {
        get
        {
            return _readOnly;
        }
        set
        {
            _readOnly = value;

            lbDisplay.Text = reEditor.Content;
            reEditor.Visible = !value;
            lbDisplay.Visible = value;
            
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}