using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportInstanceList : AuthPage
{
    private List<EduPassportInstanceDto> CurrentInstances
    {
        get
        {
            return ViewState["CurrentInstances"] as List<EduPassportInstanceDto>;
        }
        set
        {
            ViewState["CurrentInstances"] = value;
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ReadData();
            rgList.DataBind();
        }
    }


    private void ReadData()
    {
        List<EduPassportInstanceDto> list = service.GetEduPassportInstanceByEmp(this.EmpCode);

        lbMsg.Text = string.Format("您有{0}本學習護照可領取", list.Count(c => c.IsGet == false).ToString());

        if(list.Count(c=> c.IsGet == false)>0)
        {
            lbMsg.Visible = true;
        }
        else
        {
            lbMsg.Visible = false;
        }

        rgList.DataSource = list;
        CurrentInstances = list;


    }

    protected void rgList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string id = (e.Item as GridDataItem).GetDataKeyValue("InstanceID").ToString();
            string tid = (e.Item as GridDataItem).GetDataKeyValue("TemplateID").ToString();

            EduPassportInstanceDto ins = CurrentInstances.Where(c => c.TemplateID == tid).FirstOrDefault();

            Button btnView = e.Item.FindControl("btnView") as Button;
            Button btnGet = e.Item.FindControl("btnGet") as Button;
            Button btnPrint = e.Item.FindControl("btnPrint") as Button;
            if (ins != null)
            {
                if(ins.IsGet)
                {
                    btnView.Visible = true;
                    btnGet.Visible = false;
                    btnPrint.Visible = true;
                    //btnPrint.Visible = false;
                }
                else
                {
                    btnView.Visible = false;
                    btnGet.Visible = true;
                    btnPrint.Visible = false;
                }
            }
            
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadData();
        rgList.DataBind();
    }
    protected void rgList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadData();
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("TemplateID").ToString();
        EduPassportInstanceDto ins = CurrentInstances.Where(c => c.TemplateID == id).FirstOrDefault();
        if (ins != null)
        {
            string msg = service.CreateEduPassportInstance(this.EmpCode, ins);

            if (msg == null)
            {
                ReadData();
                rgList.DataBind();
            }
            else
            {
                ShowMessage("領取護照失敗:" + msg);
            }
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("InstanceID").ToString();

        Response.Redirect("EduPassportInstanceViewV2.aspx?ID=" + id);
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("InstanceID").ToString();

        Response.Redirect("EduPassportInstancePrint.aspx?ID=" + id);

    }
}