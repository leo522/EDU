using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using System.Globalization;
using KMU.EduActivity.ApplicationLayer.Services;
using Telerik.Web.UI;
using System.IO;
//using AppFramework.Utilities;
using System.Data;
using AppFramework.ComLib;

public partial class ERScoreEdit : AuthPage
{
    private string CurrentID
    {
        get
        {
            return Request.QueryString["examid"];
        }
    }

    private List<IKASA_ERExamStageDto> CurrentStage
    {
        get
        {
            return ViewState["CurrentStage"] as List<IKASA_ERExamStageDto>;
        }
        set
        {
            ViewState["CurrentStage"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(btnUpload);
        if (!IsPostBack)
        {
            BindHosp();
            if (Request.QueryString["examid"] != null)
            {
                lbScore.Visible = true;
                panScore.Visible = true;
                ReadData();
            }
            else
            {
                lbScore.Visible = false;
                panScore.Visible = false;
                CurrentStage = new List<IKASA_ERExamStageDto>();
            }
        }
    }


    private void BindHosp()
    {
        var hosps = service.GetFullHosp();
        ddlHosp.DataValueField = "HospCode";
        ddlHosp.DataTextField = "HospName";
        ddlHosp.DataSource = hosps;
        ddlHosp.DataBind();

    }

    private void ReadData()
    {
        IKASA_ERExamDto dto = service.GetiKasaERExam(CurrentID);
        rdpExamDate.SelectedDate = dto.ExamDate;
        tbExamName.Text = dto.ExamName;
        ddlHosp.SelectedValue = dto.HospCode;
        CurrentStage = dto.IKASA_ERExamStages.ToList();
        rgStage.DataSource = dto.IKASA_ERExamStages;
        rgStage.DataBind();
        rgScore.DataSource = dto.IKASA_ERExamScores;
        rgScore.DataBind();
        if(dto.IKASA_ERExamStages.Count >0)
        {
            rntbStageNo.Value = dto.IKASA_ERExamStages.Max(c => c.StageNo) + 1;
        }
        else
        {
            rntbStageNo.Value = 1;
        }
        
    }


    private bool CheckInput()
    {
        if (tbExamName.Text.Trim() == "")
        {
            ShowMessage("未輸入 考試名稱");
            return false;
        }


        if (rdpExamDate.SelectedDate == null)
        {
            ShowMessage("未選擇 考試日期");
            return false;
        }

        if(rntbPassStage.Value == null)
        {
            ShowMessage("未設定 及格站數");
            return false;
        }

        if(ddlHosp.SelectedValue == null || ddlHosp.SelectedValue == "")
        {
            ShowMessage("未選擇 考試院區");
            return false;
        }

        return true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!CheckInput())
        {
            return;
        }
        BoolMessage result = null;
        if (CurrentID == null)
        {
            result = service.CreateiKasaERExam(tbExamName.Text, this.EmpCode, rdpExamDate.SelectedDate.Value, ddlHosp.SelectedValue, CurrentStage);

        }
        else
        {
            result = service.SaveiKasaERExam(CurrentID, tbExamName.Text, rdpExamDate.SelectedDate.Value, ddlHosp.SelectedValue, CurrentStage);
        }

        if (result.Success)
        {
            Response.Redirect("ERScoreEdit.aspx?examid=" + (CurrentID == null ? result.Message : CurrentID));
        }
        else
        {
            ShowMessage("儲存失敗:" + result.Message);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ERScoreManager.aspx");
    }


    protected void btnAddStage_Click(object sender, EventArgs e)
    {
        if (tbStageName.Text.Trim() == "")
        {
            ShowMessage("未輸入 項目名稱");
            return;
        }


        if (rntbStageNo.Value == null)
        {
            ShowMessage("未設定 項目順序");
            return;
        }

        int stagno = Convert.ToInt32(rntbStageNo.Value.Value);
        if (CurrentStage.Count(c => c.StageNo == stagno) > 0)
        {
            ShowMessage("設定的項目順序已存在");
            return;
        }

        List<IKASA_ERExamStageDto> list = CurrentStage;

        list.Add(new IKASA_ERExamStageDto() { StageName = tbStageName.Text.Trim(), StageNo = Convert.ToInt32(rntbStageNo.Value.Value) });
        CurrentStage = list;
        rgStage.DataSource = CurrentStage;
        rgStage.DataBind();

        rntbStageNo.Value = rntbStageNo.Value.Value + 1;
        tbStageName.Text = "";

    }
    protected void rgStage_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int stageno = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("StageNo"));
            List<IKASA_ERExamStageDto> list = CurrentStage;
            var remove = list.Where(c => c.StageNo == stageno).FirstOrDefault();
            list.Remove(remove);
            CurrentStage = list;
            rgStage.DataSource = CurrentStage;
            rgStage.DataBind();

        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (!FileUpload1.HasFile)
            {
                ShowMessage("未選擇檔案");
                return;
            }

            string filename = Server.MapPath(".") + "\\temp\\" + Guid.NewGuid() + FileUpload1.FileName;
            FileUpload1.SaveAs(filename);

            DataTable dt = Utility.ReadExcelAsTableNPOI(filename);

            try
            {
                File.Delete(filename);
            }
            catch (Exception ex)
            {
            }

            List<IKASA_ERExamScoreDto> scores = new List<IKASA_ERExamScoreDto>();
            int rowcount = 1;
            foreach(DataRow dr in dt.Rows)
            {
                rowcount++;
                IKASA_ERExamScoreDto dto = new IKASA_ERExamScoreDto();
                dto.ExamID = CurrentID;
                if (dr["准考證編號"] == DBNull.Value || dr["准考證編號"].ToString() == "")
                {
                    ShowMessage("第" + rowcount.ToString() + "行資料未輸入准考證編號");
                    return;
                }
                dto.ExamIDNo = dr["准考證編號"].ToString();

                if (dr["職編"] == DBNull.Value || dr["職編"].ToString() == "")
                {
                    ShowMessage("第" + rowcount.ToString() + "行資料未輸入職編");
                    return;
                }
                dto.EmpCode = dr["職編"].ToString();

                if (dr["項目"] == DBNull.Value || dr["項目"].ToString() == "")
                {
                    ShowMessage("第" + rowcount.ToString() + "行資料未輸入項目");
                    return;
                }
                dto.StageNo = Convert.ToInt32(dr["項目"]);

                if (dr["分數"] == DBNull.Value || dr["分數"].ToString() == "")
                {
                    ShowMessage("第" + rowcount.ToString() + "行資料未輸入分數");
                    return;
                }
                dto.Score = Convert.ToDecimal(dr["分數"]);
                scores.Add(dto);
            } 

            BoolMessage result = service.UploadiKasaERScore(CurrentID, scores);
            if(!result.Success)
            {
                throw new Exception(result.Message);
            }
            ReadData();
        }
        catch (Exception ex)
        {
            ShowMessage("匯入資料失敗:" + ex.Message);
        }
    }
}