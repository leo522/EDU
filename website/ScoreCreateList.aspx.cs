using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;

public partial class ScoreCreateList : AuthPage
{
    private string CurrentSettingID
    {
        get
        {
            return Request.QueryString["ID"];
        }
    }

    private string CurrentInstanceID
    {
        get
        {
            return ViewState["InstanceID"] == null ? "" : ViewState["InstanceID"].ToString();
        }
        set
        {
            ViewState["InstanceID"] = value;
        }
    }

    private ScoreInstanceDto CurrentInstance
    {
        get
        {
            return ViewState["CurrentInstance"] as ScoreInstanceDto;
        }
        set
        {
            ViewState["CurrentInstance"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnExport);
        if (!IsPostBack)
        {
            if (CurrentSettingID != null)
            {
                ReadListData();
            }
        }

        if (CurrentInstance != null)
        {
            rgScore.DataSource = null;

            DynamicCreateColumn();

            rgScore.DataSource = CurrentInstance.DetailTableData;
            rgScore.DataBind();
        }


    }

    private void ReadListData()
    {
        List<ScoreInstanceDto> list = service.GetScoreInstances(CurrentSettingID);
        rgList.DataSource = list;
        rgList.DataBind();
    }


    protected void btnQueryInstance_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        if (item != null)
        {
            string instanceid = item.GetDataKeyValue("InstanceID").ToString();
            CurrentInstanceID = instanceid;

            CurrentInstance = service.GetScoreInstance(instanceid);
            rdpSDate.SelectedDate = CurrentInstance.DataSDate;
            rdpEDate.SelectedDate = CurrentInstance.DataEDate;

            DynamicCreateColumn();
            rgScore.DataSource = CurrentInstance.DetailTableData;
            rgScore.DataBind();

            pvScore.Selected = true;
            RadTabStrip1.SelectedIndex = 1;
        }
    }
    protected void btnAddScore_Click(object sender, EventArgs e)
    {
        CurrentInstanceID = "";
        rgScore.DataSource = null;
        rgScore.DataBind();
        pvScore.Selected = true;
        RadTabStrip1.SelectedIndex = 1;
    }

    private void ReadScoreData()
    {
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        if (rdpSDate.SelectedDate == null)
        {
            ShowMessage("未選擇時間範圍(起)");
            return;
        }
        if (rdpEDate.SelectedDate == null)
        {
            ShowMessage("未選擇時間範圍(迄)");
            return;
        }
        if (CurrentInstanceID == "")
        {
            ScoreInstanceDto dto = service.CreateScoreInstance(CurrentSettingID, rdpSDate.SelectedDate.Value.Date, rdpEDate.SelectedDate.Value.Date);
            CurrentInstance = dto;
            DynamicCreateColumn();
            rgScore.DataSource = CurrentInstance.DetailTableData;
            rgScore.DataBind();
        }
    }

    private void FillValueToColl()
    {
        foreach (GridDataItem item in rgScore.Items)
        {
            string empcode = item.GetDataKeyValue("員工編號").ToString();
            List<string> valueids = CurrentInstance.ScoreInstanceDetails.Select(c => c.ValueID).Distinct().ToList();

            foreach (string valueid in valueids)
            {
                RadNumericTextBox rntb = item.FindControl("rntbValue" + valueid) as RadNumericTextBox;
                if (rntb != null)
                {
                    ScoreInstanceDetailDto dto = CurrentInstance.ScoreInstanceDetails.Where(c => c.TargetID == empcode && c.ValueID == valueid).FirstOrDefault();
                    if (dto != null)
                    {
                        if (rntb.Value == null)
                        {
                            dto.Score = null;
                        }
                        else
                        {
                            dto.Score = Convert.ToDecimal(rntb.Value);
                        }

                    }
                }
            }

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FillValueToColl();

        string msg = service.SaveScoreInstance(CurrentInstance, this.EmpCode);
        if (msg == null)
        {
            ShowMessage("儲存完成");
            CurrentInstance = service.GetScoreInstance(CurrentInstanceID);
            rdpSDate.SelectedDate = CurrentInstance.DataSDate;
            rdpEDate.SelectedDate = CurrentInstance.DataEDate;

            DynamicCreateColumn();
            rgScore.DataSource = CurrentInstance.DetailTableData;
            rgScore.DataBind();

            ReadListData();
        }
        else
        {
            ShowMessage("儲存失敗：" + msg);
        }
    }
    protected void rgScore_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            for (int i = 0; i < CurrentInstance.DetailTableData.Columns.Count; i++)
            {
                string columnname = CurrentInstance.DetailTableData.Columns[i].ColumnName;


                string valueid = CurrentInstance.DetailTableData.Columns[i].Namespace;
                RadNumericTextBox rntb = item.FindControl("rntbValue" + valueid) as RadNumericTextBox;
                if (rntb != null)
                {
                    //rntb.AutoPostBack = true;
                    //rntb.TextChanged += rntb_TextChanged;

                    string empcode = item.GetDataKeyValue("員工編號").ToString();
                    if (empcode != null)
                    {
                        DataRow dr = CurrentInstance.DetailTableData.Select("員工編號='" + empcode + "'")[0];
                        if (dr[columnname] == DBNull.Value)
                        {
                            rntb.Value = null;
                        }
                        else
                        {
                            rntb.Value = Convert.ToDouble(dr[columnname]);
                        }

                    }

                }

            }
        }
    }

    void rntb_TextChanged(object sender, EventArgs e)
    {
        RadNumericTextBox rntb = (sender as RadNumericTextBox);
        GridDataItem item = rntb.Parent.Parent as GridDataItem;
        string empcode = item.GetDataKeyValue("員工編號").ToString();

        string valueid = rntb.ID.Replace("rntbValue", "");
        ScoreInstanceDetailDto det = CurrentInstance.ScoreInstanceDetails.Where(c => c.TargetID == empcode && c.ValueID == valueid).FirstOrDefault();

        if (det != null)
        {
            if (rntb.Value == null)
            {
                det.Score = null;
            }
            else
            {
                det.Score = Convert.ToDecimal(rntb.Value);
            }
        }
        rgScore.DataSource = CurrentInstance.DetailTableData;
        rgScore.DataBind();
    }
    private void DynamicCreateColumn()
    {
        rgScore.Columns.Clear();

        for (int i = 0; i < CurrentInstance.DetailTableData.Columns.Count; i++)
        {
            string columnname = CurrentInstance.DetailTableData.Columns[i].ColumnName;
            string ns = CurrentInstance.DetailTableData.Columns[i].Namespace;
            if (CurrentInstance.DetailTableData.Columns[i].Caption == "true")
            {
                GridBoundColumn col = new GridBoundColumn();
                col.UniqueName = ns;
                col.HeaderText = columnname;
                col.DataField = columnname;
                col.DataFormatString = "{0:C2}";
                rgScore.MasterTableView.Columns.Add(col);
            }
            else
            {

                GridTemplateColumn col = new GridTemplateColumn();
                col.UniqueName = ns;
                col.HeaderText = columnname;
                col.DataField = columnname;


                col.ItemTemplate = new EdTemplate(ns);

                rgScore.MasterTableView.Columns.Add(col);

            }
        }
    }

    protected void rgScore_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (CurrentInstance != null)
        {
            rgScore.DataSource = null;

            DynamicCreateColumn();

            rgScore.DataSource = CurrentInstance.DetailTableData;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        FillValueToColl();
        Utility util = new Utility();
        byte[] bytes = util.ExportDataTableToExcel(CurrentInstance.DetailTableData);

        HttpResponse response = Response;

        response.Clear();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();
    }
}
public class EdTemplate : ITemplate
{
    protected RadNumericTextBox rntbValue = new RadNumericTextBox();
    private string colname;
    public EdTemplate(string cName)
    {
        colname = cName;
    }
    public void InstantiateIn(System.Web.UI.Control container)
    {
        rntbValue = new RadNumericTextBox();
        rntbValue.ID = "rntbValue" + colname;
        rntbValue.Width = new Unit(40);
        rntbValue.NumberFormat.DecimalDigits = 0;
        
        container.Controls.Add(rntbValue);
    }

}