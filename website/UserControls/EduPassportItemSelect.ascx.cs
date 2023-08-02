using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class UserControls_EduPassportItemSelect : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        rwOpenBig.OnClientClose = "OnClientClose" + this.ClientID;
        RadWindowManager1.OnClientClose = "OnClientClose" + this.ClientID;
        btnFind.OnClientClick = "openNewWin" + this.ClientID + "(); return false;";
        
        string script =
   "<script type=\"text/javascript\"> " +

   "    function openNewWin" + this.ClientID + "() { " +
   "        var manager = $find(\""+RadWindowManager1.ClientID+"\"); "+
   "        manager.open(\"EduPassportItemFinder.aspx\", \"rwOpenBig\"); " +
   "    } " +
   "    function OnClientClose" + this.ClientID + "(oWnd, args) { " +
   "        try { " +
   "            var arg = args.get_argument(); " +
   "            if (arg != null) { " +
   "                var codes = document.getElementById('" + hidCodes.ClientID + "'); " +
   "                var names = document.getElementById('" + hidNames.ClientID + "'); " +
   "                codes.value = arg.SelectItemIDs; " +
   "                names.value = arg.SelectItemNames; " +
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
    public List<string> SelectedEduTermIDs
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

    public List<EduPassportItemDto> SelectedItems
    {
        get
        {
            List<EduPassportItemDto> result = new List<EduPassportItemDto>();
            if (SelectedEduTermIDs!=null)
            {
                for (int i = 0; i < SelectedEduTermIDs.Count; i++)
                {
                    EduPassportItemDto dto = new EduPassportItemDto();
                    dto.ItemID = SelectedEduTermIDs[i];
                    dto.ItemName = SelectedNames[i];
                    result.Add(dto);
                }
            }

            return result;
        }
    }

    public void Refresh()
    {
        tbSelect.Text = "未選擇項目";
        hidCodes.Value = "";
        hidNames.Value = "";
        RadWindowManager1.Windows[0].DataBind();
    }

    protected void lbtnRefresh_Click(object sender, EventArgs e)
    {
        if (SelectedNames == null || SelectedNames.Count == 0)
        {
            tbSelect.Text = "未選擇項目";
        }
        else if (SelectedNames.Count == 1)
        {
            tbSelect.Text = hidNames.Value.Replace("#spilter#", "");
        }
        else if (SelectedNames.Count > 1)
        {
            tbSelect.Text = "已選擇" + SelectedNames.Count.ToString() + "筆資料";
        }
        //Response.Write(hidCodes.Value);
    }
}