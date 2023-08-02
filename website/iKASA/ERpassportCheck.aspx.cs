using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class iKASA_ERpassportCheck : iKASAPageBase
{

    private List<IKASA_ERCaseDto> CurrentERCase
    {
        get
        {
            return ViewState["CurrentERCase"] as List<IKASA_ERCaseDto>;
        }
        set
        {
            ViewState["CurrentERCase"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadERCase();
            RadGrid3.DataBind();
        }
    }



    private void ReadERCase()
    {
        CurrentERCase = service.GetNeedSignERCase(this.CurrentPersonInfo.empcode);
        RadGrid3.DataSource = CurrentERCase;
        

    }

    protected void RadGrid3_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid3.DataSource = CurrentERCase;
    }
    
    protected void RadGrid3_ItemCommand(object sender, GridCommandEventArgs e)
    {
        int ID = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("ID"));
        int EvalID = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("EvalID"));
        var data = CurrentERCase.Where(c => c.ID == ID && c.EvalID == EvalID).FirstOrDefault();
        if (data != null)
        {
            if(e.CommandName == "SubmitItem")
            {
                Response.Redirect("ER" + data.EvalType + ".aspx?CaseID=" + ID.ToString() + "&EvalID=" + EvalID.ToString());
            }

        }
    }
}