using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.OracleClient;
using NPOI.HSSF.UserModel;



public partial class MySentence : AuthPage
{
    private List<EduSentenceDto> CurrentList
    {
        get
        {
            return ViewState["EduSentenceDto"] as List<EduSentenceDto>;
        }
        set
        {
            ViewState["EduSentenceDto"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rgCategory.DataBind();
        }

    }


    private void ReadCategoryData()
    {
        List<EduSentenceDto> list = service.GetMySentences(this.EmpCode);

        rgCategory.DataSource = list;

    }
    


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (tbAddCategory.Text.Trim() == "")
        {
            ShowMessage("未輸入片語內容");
            return;
        }

        if (tbAddCategory.Text.Trim().Length > 250)
        {
            ShowMessage("片語內容過長");
            return;
        }

        string result = service.AddSentences(this.EmpCode, tbAddCategory.Text.Trim(), cbPublic.Checked);
        if (result != null)
        {
            ShowMessage(result);
            return;
        }
        ReadCategoryData();
        rgCategory.DataBind();

    }
    protected void rgCategory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadCategoryData();
    }
    protected void rgCategory_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.DeleteCommandName)
        {
            int id = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("ID"));
            

            string msg = service.DeleteSentences(id);

            if(msg == null)
            {
                rgCategory.DataBind();
            }
            else
            {
                ShowMessage("刪除失敗:" + msg);
            }
        }
    }
    protected void rgCategory_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.UpdateCommandName)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            int id = Convert.ToInt32(editedItem.GetDataKeyValue("ID"));

            string sent = (editedItem["Sentence"].Controls[0] as TextBox).Text;
            bool ispublic = (editedItem["isPublic"].Controls[0] as CheckBox).Checked;
            string msg = service.EditSentences(id, sent, ispublic);

            if (msg == null)
            {
                rgCategory.DataBind();
            }
            else
            {
                ShowMessage("修改失敗:" + msg);
            }
        }
    }

}