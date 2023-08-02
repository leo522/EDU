using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class UserControls_EduTermSelect : System.Web.UI.UserControl
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
   "        manager.open(\"EduTermFinder.aspx\", \"rwOpenBig\"); " +
   "    } " +
   "    function OnClientClose" + this.ClientID + "(oWnd, args) { " +
   "        try { " +
   "            var arg = args.get_argument(); " +
   "            if (arg != null) { " +
   "                var codes = document.getElementById('" + hidCodes.ClientID + "'); " +
   "                var names = document.getElementById('" + hidNames.ClientID + "'); " +
   "                codes.value = arg.SelectTermIDs; " +
   "                names.value = arg.SelectTermNames; " +
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

    public List<string> SelectedEduTermNames
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

    public List<EduTermDto> SelectedEduTerms
    {
        get
        {
            List<EduTermDto> result = new List<EduTermDto>();
            if (SelectedEduTermIDs!=null)
            {
                for (int i = 0; i < SelectedEduTermIDs.Count; i++)
                {
                    EduTermDto dto = new EduTermDto();
                    dto.EduTermID = SelectedEduTermIDs[i];
                    dto.Name = SelectedEduTermNames[i];
                    result.Add(dto);
                }
            }

            return result;
        }
    }

    public void Refresh()
    {
        tbSelect.Text = "未選擇課程";
        hidCodes.Value = "";
        hidNames.Value = "";
        RadWindowManager1.Windows[0].DataBind();
    }

    protected void lbtnRefresh_Click(object sender, EventArgs e)
    {
        if (SelectedEduTermNames == null || SelectedEduTermNames.Count == 0)
        {
            tbSelect.Text = "未選擇課程";
        }
        else if (SelectedEduTermNames.Count == 1)
        {
            tbSelect.Text = hidNames.Value.Replace("#spilter#", "");
        }
        else if (SelectedEduTermNames.Count > 1)
        {
            tbSelect.Text = "已選擇" + SelectedEduTermNames.Count.ToString() + "筆課程資料";
        }
        //Response.Write(hidCodes.Value);
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {

    }
}