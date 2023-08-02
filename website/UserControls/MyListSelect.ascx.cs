using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class UserControls_MyListSelect : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        rwOpenBig.OnClientClose = "OnClientClose" + this.ClientID;
        RadWindowManager1.OnClientClose = "OnClientClose" + this.ClientID;
        btnFind.OnClientClick = "openNewWin" + this.ClientID + "(); return false;";

        string script =
   "<script type=\"text/javascript\"> " +

   "    function openNewWin" + this.ClientID + "() { " +
   "        var manager = $find(\"" + RadWindowManager1.ClientID + "\"); " +
   "        manager.open(\"MyListManage.aspx\", \"rwOpenBig\"); " +
   "    } " +
   "    function OnClientClose" + this.ClientID + "(oWnd, args) { " +
   "        try { " +
   "            var arg = args.get_argument(); " +
   "            if (arg != null) { " +
   "                var listid = document.getElementById('" + hidMyListID.ClientID + "'); " +
   "                var listname = document.getElementById('" + hidMyListName.ClientID + "'); " +
   "                listid.value = arg.SelectMyListID; " +
   "                listname.value = arg.SelectMyListName; " +
   "                var codes = document.getElementById('" + hidCodes.ClientID + "'); " +
   "                var names = document.getElementById('" + hidNames.ClientID + "'); " +
   "                codes.value = arg.SelectCodes; " +
   "                names.value = arg.SelectNames; " +
   "                var btn = document.getElementById('" + lbtnRefresh.ClientID + "'); " +
   "                if (btn) btn.click(); " +
   "            } " +
   "        } " +
   "        catch (e) { " +
   "        } " +
   "    } " +
   " </script>";
        System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "closeScript" + this.ClientID, script, false);

    }

    public string SelectedMyListID
    {
        get
        {
            return hidMyListID.Value;
        }
    }

    public string SelectedMyListName
    {

        get
        {
            return hidMyListName.Value;
        }
    }

    public List<string> SelectedCodes
    {
        get
        {
            List<string> result = new List<string>();
            if (hidCodes.Value != null && hidCodes.Value != "")
            {
                string[] codes = hidCodes.Value.Split(new string[] { "#spilter#" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string code in codes)
                {
                    result.Add(code);
                }

            }

            return result;
        }
    }

    public List<string> SelectedNames
    {
        get
        {
            List<string> result = new List<string>();
            if (hidNames.Value != null && hidNames.Value != "")
            {
                string[] names = hidNames.Value.Split(new string[] { "#spilter#" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string name in names)
                {
                    result.Add(name);
                }

            }

            return result;
        }
    }


    public void Refresh()
    {
        tbSelect.Text = "未選擇名單";
        hidMyListID.Value = "";
        hidMyListName.Value = "";
        hidCodes.Value = "";
        hidNames.Value = "";
        RadWindowManager1.Windows[0].DataBind();
    }

    protected void lbtnRefresh_Click(object sender, EventArgs e)
    {
        if (SelectedMyListID == null || SelectedMyListID == "")
        {
            tbSelect.Text = "未選擇名單";
        }
        else
        {
            tbSelect.Text = hidMyListName.Value;
        }

    }
    protected void btnFind_Click(object sender, EventArgs e)
    {

    }
}