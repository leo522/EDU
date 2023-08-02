using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iKASA_ERDOPS : iKASAPageBase
{
    private const string CaseType = "DOPS";

    private int CurrentCaseID
    {
        get
        {
            return Convert.ToInt32(ViewState["CurrentCaseID"]);
        }
        set
        {
            ViewState["CurrentCaseID"] = value;
        }
    }

    private int CurrentEvalID
    {
        get
        {
            return Convert.ToInt32(ViewState["CurrentEvalID"]);
        }
        set
        {
            ViewState["CurrentEvalID"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CaseID"] != null)
            {
                CurrentCaseID = Convert.ToInt32(Request.QueryString["CaseID"]);
            }
            else
            {
                ShowMessageAndGoBack("參數傳遞錯誤");
            }


            CurrentEvalID = Convert.ToInt32(Request.QueryString["CurrentEvalID"]);


            ReadCaseInfo();
        }


    }

    private void ReadCaseInfo()
    {
        var thecase = service.GetERCaseByID(CurrentCaseID);

        if(thecase!= null)
        {
            lbChartNo.Text = thecase.CHART_NO;
            lbDeptName.Text = thecase.DEPT_NAME;
            lbDiseaseClass.Text = thecase.DISEASE_CLASS;
            lbICDName.Text = thecase.ICD_NAME;
            lbInDate.Text = thecase.IN_DATE == null ? "" : thecase.IN_DATE.Value.ToString("yyyy/MM/dd");
            lbProcedure.Text = thecase.PROCEDURE;

            var caseeval = service.GetERCaseEval(CurrentCaseID, CaseType);
            if (caseeval == null)
            {
                if (CurrentPersonInfo != null && CurrentPersonInfo.empcode == thecase.EMPCODE)
                {
                    panStudent.Visible = true;
                    PanTeacher.Visible = false;
                }

            }
            else
            {
                CurrentEvalID = caseeval.ID;
                foreach (Control ctrl in PanTeacher.Controls)
                {
                    string ctrlid = ctrl.ID;
                    var evaldet = caseeval.IKASA_ERCase_EvalDets.Where(c => c.ControlID == ctrlid).FirstOrDefault();
                    if (evaldet != null)
                    {
                        if (ctrl is RadioButton)
                        {
                            (ctrl as RadioButton).Checked = Convert.ToBoolean(evaldet.ControlValue);
                        }

                        if (ctrl is TextBox)
                        {
                            (ctrl as TextBox).Text = evaldet.ControlValue;
                        }
                    }
                }

                if ((CurrentPersonInfo != null && CurrentPersonInfo.empcode == caseeval.TeacherID) || Session["EduAct_EmpCode"].ToString() == caseeval.TeacherID)
                {
                    panStudent.Visible = false;
                    PanTeacher.Visible = true;

                    if (caseeval.Status == "0")
                    {
                        PanTeacher.Enabled = true;
                        btnTeacherSubmit.Visible = true;
                    }
                    else
                    {
                        PanTeacher.Enabled = false;
                        btnTeacherSubmit.Visible = false;
                    }


                }
                else
                {
                    panStudent.Visible = false;
                    PanTeacher.Visible = true;
                    PanTeacher.Enabled = false;
                    btnTeacherSubmit.Visible = false;
                }
            }


        }
        else
        {
            ShowMessage("資料錯誤請重試");
        }
    }

    protected void btnStudentSubmit_Click(object sender, EventArgs e)
    {
        if (rcbTeacher.SelectedValue == null || rcbTeacher.SelectedValue == "")
        {
            ShowMessage("請選擇審核老師");
            return;
        }

        if(rcbTeacher.SelectedValue == CurrentPersonInfo.empcode)
        {
            ShowMessage("不可以選擇自己");
            return;
        }

        string result = service.CreateERCaseEval(CurrentCaseID, CaseType, rcbTeacher.SelectedValue);
        if(result == null)
        {
            ShowMessageAndGo("送審完成", "ERpassport.aspx");
        }
        else
        {
            ShowMessage("送出失敗:" + result);
        }

    }
    protected void btnTeacherSubmit_Click(object sender, EventArgs e)
    {
        List<IKASA_ERCase_EvalDetDto> detlist = new List<IKASA_ERCase_EvalDetDto>();

        foreach (Control ctrl in PanTeacher.Controls)
        {
            string ctrlid = ctrl.ID;

            if (ctrl is RadioButton || ctrl is TextBox)
            {
                IKASA_ERCase_EvalDetDto dto = new IKASA_ERCase_EvalDetDto();
                dto.EvalID = CurrentEvalID;
                dto.ControlID = ctrl.ID;

                if (ctrl is RadioButton)
                {

                    dto.ControlValue = (ctrl as RadioButton).Checked.ToString();

                }

                if (ctrl is TextBox)
                {
                    dto.ControlValue = (ctrl as TextBox).Text;
                }

                detlist.Add(dto);
            }
        }

        string result = service.SubmitERCaseEvalDet(CurrentCaseID, CurrentEvalID, detlist);
        if(result!= null)
        {
            ShowMessage("送出失敗:" + result);
        }
        else
        {
            ShowMessageAndGo("送出成功", "ERpassportCheck.aspx");
        }

    }
}