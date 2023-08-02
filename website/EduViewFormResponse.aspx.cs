using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using Telerik.Web.UI;
using System.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Web.Configuration;
using System.Data.SqlClient;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class EduViewFormResponse : AuthPage
{
    private int CurrentInstanceID
    {
        get
        {
            return Convert.ToInt32(Request.QueryString["instance_id"]);
        }
    }

    private DataTable CurrentStatData
    {
        get
        {
            return ViewState["CurrentStatData"] as DataTable;
        }
        set
        {
            ViewState["CurrentStatData"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["instance_id"] == null)
            {
                ShowMessageAndGoBack("參數傳遞錯誤!");
                return;
            }

            int instanceId = int.Parse(Request.QueryString["instance_id"]);
            DateTime readDate = DateTime.Now;
            WriteReadDate(instanceId, readDate); //寫入SQL，已讀的日期時間

            ReadStatisticData();

            rgDetailList.DataBind();
        }
    }

    private void ReadStatisticData()
    {
        List<STATISTIC_EXPEND_DATA_LIST> list = service.GetStatisticDataListByInstanceID(CurrentInstanceID, true);

        DataTable dt = new DataTable();
        dt.Columns.Add("表單序號");
        dt.Columns.Add("填寫人姓名");
        dt.Columns.Add("課程名稱(完整)");
        dt.Columns.Add("受訓院區");
        dt.Columns.Add("受訓科別 ");
        dt.Columns.Add("受訓期間 ");

        foreach (string group in list.Select(c => c.GroupName).Distinct())
        {
            dt.Columns.Add(group);
        }

        Dictionary<string, int> statuscount = new Dictionary<string, int>();

        foreach (STATISTIC_EXPEND_DATA_LIST data in list)
        {
            DataRow[] rows = dt.Select("表單序號 = '" + data.InstanceID.ToString() + "'");
            DataRow row;
            if (rows.Length > 0)
            {
                row = rows[0];

                row["填寫人姓名"] = "";
                foreach (string val in list.Where(c => c.InstanceID == data.InstanceID).Select(c => c.TargetName).Distinct().ToList())
                {
                    row["填寫人姓名"] += "\r\n" + val;
                }
            }
            else
            {
                row = dt.NewRow();
                row["表單序號"] = data.InstanceID.ToString();
                row["填寫人姓名"] = data.TargetName;
                row["課程名稱(完整)"] = data.EduTermFullName;
                row["受訓院區"] = data.HospName;
                row["受訓科別 "] = data.DeptName;
                row["受訓期間 "] = data.EduTermTimeRange;

                dt.Rows.Add(row);

                if (statuscount.Keys.Contains(data.StatusName))
                {
                    statuscount[data.StatusName]++;
                }
                else
                {
                    statuscount.Add(data.StatusName, 1);
                }
            }

            row[data.GroupName] = data.Value;
        }

        CurrentStatData = dt;

        rgDetailList.DataSource = dt;
    }

    private void WriteReadDate(int instanceId, DateTime readDate) //個人首頁點擊"完成"列表的"回饋"，寫入日期時間
    {
        try
        {
            string conn = WebConfigurationManager.ConnectionStrings["www_EduActivityConnectionString"].ConnectionString;

            string dto = "Select ReadDate From FORM_INSTANCES Where INSTANCE_ID = @InstanceId";

            using (SqlConnection com = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand(dto, com))
                {
                    command.Parameters.AddWithValue("@InstanceId", instanceId);
                    com.Open();

                    object ReadDate = command.ExecuteScalar();

                    if (ReadDate == null || ReadDate == DBNull.Value)
                    {
                        string query = "Update FORM_INSTANCES Set ReadDate = @ReadDate WHERE INSTANCE_ID = @InstanceId";

                       using (SqlCommand updateComm = new SqlCommand(query, com))
                       {
                           updateComm.Parameters.AddWithValue("@ReadDate", readDate);
                           updateComm.Parameters.AddWithValue("@InstanceId", instanceId);
                           updateComm.ExecuteNonQuery();
                       }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage("發生錯誤：" + ex.Message);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e) //匯出
    {
        rgDetailList.NeedDataSource -= rgDetailList_NeedDataSource;
        rgDetailList.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        rgDetailList.ExportSettings.ExportOnlyData = true;
        rgDetailList.ExportSettings.IgnorePaging = true;
        rgDetailList.ExportSettings.OpenInNewWindow = true;
        rgDetailList.MasterTableView.ExportToExcel();
        rgDetailList.NeedDataSource += rgDetailList_NeedDataSource;
    }

    protected void rgDetailList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (CurrentStatData == null)
        {
            ReadStatisticData();
        }
        else
        {
            rgDetailList.DataSource = CurrentStatData;
        } 
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        //if (rddtJobCode.SelectedValue == "")
        //{
        //    ShowMessage("未選擇職稱");
        //    return;
        //}



        //if (ddlUnit.CheckedItems.Count == 0)
        //{
        //    ShowMessage("未選擇部門");
        //    return;
        //}

        //if (rcbTemplateID.SelectedValue == null || rcbTemplateID.SelectedValue == "")
        //{
        //    ShowMessage("未選擇表單");
        //    return;
        //}


        //if (rdpSDate.SelectedDate == null)
        //{
        //    ShowMessage("未選擇開始時間");
        //    return;
        //}

        //if (rdpEDate.SelectedDate == null)
        //{
        //    ShowMessage("未選擇結束時間");
        //    return;
        //}

        //RefreshHistory();
        //rgHistory.DataBind();
    }
}