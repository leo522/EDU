using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class ElearningContent : AuthPage
{
    private List<ElearningItemDto> CurrentItemList
    {
        get
        {
            return ViewState["CurrentItemList"] as List<ElearningItemDto>;
        }
        set
        {
            ViewState["CurrentItemList"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ClassID"] == null)
        {
            ShowMessageAndGo("參數傳遞錯誤!", "EleaningList.aspx");
            return;
        }

        if (!IsPostBack)
        {
            ReadClassItem();
            rgContent.DataBind();
        }
    }

    private void ReadClassItem()
    {
        CurrentItemList = service.GetMyClassItem(Request.QueryString["ClassID"], this.EmpCode);
        rgContent.DataSource = CurrentItemList;
    }
    protected void rgContent_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        rgContent.DataSource = CurrentItemList;
    }
    protected void rgContent_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string itemid = (e.Item as GridDataItem).GetDataKeyValue("ItemID").ToString();
            ElearningItemDto dto = CurrentItemList.Where(c => c.ItemID == itemid).FirstOrDefault();
            if (dto != null)
            {
                Button btnGo = e.Item.FindControl("btnGo") as Button;
                switch (dto.ItemType)
                {
                    case "測驗":

                        if (dto.isFinished)
                        {
                            //btnGo.Enabled = false;
                            btnGo.Text = "查看內容";
                        }
                        else
                        {
                            btnGo.Text = "進行測驗";
                        }

                        break;
                    case "教材":
                        btnGo.Text = "開始閱讀";
                        break;
                }
            }

        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("ItemID").ToString();

        if ((sender as Button).Text == "開始閱讀")
        {
            Response.Redirect("ElearningVideo.aspx?ItemID=" + id);
        }
        if ((sender as Button).Text == "進行測驗")
        {
            ElearningItemDto itemdto = CurrentItemList.Where(c => c.ItemID == id).FirstOrDefault();
            if (item != null)
            {
                if (itemdto.isFinished)
                {
                    Response.Redirect("EleaningInstanceDetial.aspx?itemid=" + id + "&template_id=" + itemdto.RefID + "&classid=" + Request.QueryString["ClassID"] + "&mode=v");
                }
                else
                {
                    Response.Redirect("EleaningInstanceDetial.aspx?itemid=" + id + "&template_id=" + itemdto.RefID + "&classid=" + Request.QueryString["ClassID"]);
                }
            }
        }
        if ((sender as Button).Text == "查看內容")
        {
            ElearningItemDto itemdto = CurrentItemList.Where(c => c.ItemID == id).FirstOrDefault();
            if (item != null)
            {
                if (itemdto.isFinished)
                {
                    Response.Redirect("EleaningInstanceDetial.aspx?itemid=" + id + "&template_id=" + itemdto.RefID + "&classid=" + Request.QueryString["ClassID"] + "&mode=v");
                }
                else
                {
                    Response.Redirect("EleaningInstanceDetial.aspx?itemid=" + id + "&template_id=" + itemdto.RefID + "&classid=" + Request.QueryString["ClassID"]);
                }
            }
        }
        
    }
}