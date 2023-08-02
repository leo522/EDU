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

public partial class OSCEScoreEdit : AuthPage
{
    private string CurrentID
    {
        get
        {
            return Request.QueryString["examid"];
        }
    }

    private List<IKASA_OSCEExamStageDto> CurrentStage
    {
        get
        {
            return ViewState["CurrentStage"] as List<IKASA_OSCEExamStageDto>;
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
                CurrentStage = new List<IKASA_OSCEExamStageDto>();
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
        IKASA_OSCEExamDto dto = service.GetiKasaOSCEExam(CurrentID);
        rdpExamDate.SelectedDate = dto.ExamDate;
        tbExamName.Text = dto.ExamName;
        rntbPassStage.Value = dto.PassStage;
        ddlHosp.SelectedValue = dto.HospCode;
        CurrentStage = dto.IKASA_OSCEExamStages.ToList();
        rgStage.DataSource = dto.IKASA_OSCEExamStages;
        rgStage.DataBind();
        rgScore.DataSource = dto.IKASA_OSCEExamScores;
        rgScore.DataBind();
        if(dto.IKASA_OSCEExamStages.Count >0)
        {
            rntbStageNo.Value = dto.IKASA_OSCEExamStages.Max(c => c.StageNo) + 1;
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
            result = service.CreateiKasaOSCEExam(tbExamName.Text, this.EmpCode, rdpExamDate.SelectedDate.Value, Convert.ToDecimal(0), Convert.ToInt32(rntbPassStage.Value.Value), ddlHosp.SelectedValue, CurrentStage);

        }
        else
        {
            result = service.SaveiKasaOSCEExam(CurrentID, tbExamName.Text, rdpExamDate.SelectedDate.Value, Convert.ToDecimal(0), Convert.ToInt32(rntbPassStage.Value.Value), ddlHosp.SelectedValue, CurrentStage);
        }

        if (result.Success)
        {
            Response.Redirect("OSCEScoreEdit.aspx?examid=" + (CurrentID == null ? result.Message : CurrentID));
        }
        else
        {
            ShowMessage("儲存失敗:" + result.Message);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OSCEScoreManager.aspx");
    }


    protected void btnAddStage_Click(object sender, EventArgs e)
    {
        if (tbStageName.Text.Trim() == "")
        {
            ShowMessage("未輸入 關卡名稱");
            return;
        }

        if (rntbPassScore.Value == null)
        {
            ShowMessage("未設定 及格分數");
            return;
        }

        if (rntbStageNo.Value == null)
        {
            ShowMessage("未設定 關卡順序");
            return;
        }

        int stagno = Convert.ToInt32(rntbStageNo.Value.Value);
        if (CurrentStage.Count(c => c.StageNo == stagno) > 0)
        {
            ShowMessage("設定的關卡順序已存在");
            return;
        }

        List<IKASA_OSCEExamStageDto> list = CurrentStage;

        list.Add(new IKASA_OSCEExamStageDto() { PassScore = Convert.ToDecimal(rntbPassScore.Value.Value), StageName = tbStageName.Text.Trim(), StageNo = Convert.ToInt32(rntbStageNo.Value.Value) });
        CurrentStage = list;
        rgStage.DataSource = CurrentStage;
        rgStage.DataBind();

        rntbStageNo.Value = rntbStageNo.Value.Value + 1;
        tbStageName.Text = "";
        rntbPassScore.Value = null;

    }
    protected void rgStage_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int stageno = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("StageNo"));
            List<IKASA_OSCEExamStageDto> list = CurrentStage;
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

            List<IKASA_OSCEExamScoreDto> scores = new List<IKASA_OSCEExamScoreDto>();
            int rowcount = 1;
            foreach(DataRow dr in dt.Rows)
            {
                rowcount++;
                IKASA_OSCEExamScoreDto dto = new IKASA_OSCEExamScoreDto();
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

                if (dr["關卡"] == DBNull.Value || dr["關卡"].ToString() == "")
                {
                    ShowMessage("第" + rowcount.ToString() + "行資料未輸入關卡");
                    return;
                }
                dto.StageNo = Convert.ToInt32(dr["關卡"]);

                if (dr["分數"] == DBNull.Value || dr["分數"].ToString() == "")
                {
                    ShowMessage("第" + rowcount.ToString() + "行資料未輸入分數");
                    return;
                }
                dto.Score = Convert.ToDecimal(dr["分數"]);
                scores.Add(dto);
            } 

            BoolMessage result = service.UploadiKasaOSCEScore(CurrentID, scores);
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