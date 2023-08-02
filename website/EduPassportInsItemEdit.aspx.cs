using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EduPassportInsItemEdit : AuthPage
{


    private EduPassportInstanceDto CurrentInstance
    {
        get
        {
            return CurrentInstanceItem.EduPassportInstance;
        }

    }

    private EduPassportInsItemDto CurrentInstanceItem
    {
        get
        {
            return ViewState["CurrentInstanceItem"] as EduPassportInsItemDto;
        }
        set
        {
            ViewState["CurrentInstanceItem"] = value;
        }
    }

    private List<EduPassportInsItemDetDto> CurrentInsItemDets
    {
        get
        {
            return CurrentInstanceItem.EduPassportInsItemDets.ToList();
        }
    }

    private List<EduPassportInsItemDetDto> CurrentSInsItemDets
    {
        get
        {
            return CurrentInstanceItem.EduPassportInsItemDets.Where(c => c.FieldTarget == "S").ToList();
        }
    }

    private List<EduPassportInsItemDetDto> CurrentTInsItemDets
    {
        get
        {
            return CurrentInstanceItem.EduPassportInsItemDets.Where(c => c.FieldTarget == "T").ToList();
        }
    }

    private string CurrentIItemID
    {
        get
        {
            return Request.QueryString["ID"];
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        hfJobCode.Value = this.JobCode;
        if (CurrentInstanceItem != null)
        {
            EditContrlS.DataSource = CurrentSInsItemDets;
            EditContrlT.DataSource = CurrentTInsItemDets;
        }
        if (!IsPostBack)
        {
            ReadData();

            rCBHosp.SelectedValue = this.HospCode;
            
        }

        //更新資料
        string ctrlName = this.Request.Params.Get("__EVENTTARGET");
        if (!String.IsNullOrEmpty(ctrlName))
        {
            Control ctrl = this.FindControl(ctrlName);
            if (ctrl == btnSubmit || ctrl == btnPreSave)
            {


                if (panSelectTeacher.Visible)
                {
                    if ((rCBTeacherName.SelectedValue == "" || rCBTeacherName.SelectedValue == null) && !cbAdminConfirm.Checked && ctrl != btnPreSave)
                    {
                        ShowMessage("未選擇審核老師");
                        return;
                    }
                    if (cbAdminConfirm.Checked)
                    {
                        CurrentInstanceItem.TTarget = null;
                    }
                    else
                    {
                        CurrentInstanceItem.TTarget = rCBTeacherName.SelectedValue;
                    }
                }
                List<EduPassportInsItemDetDto> dets = new List<EduPassportInsItemDetDto>();
                if (EditContrlS.Visible && !EditContrlS.DisplayOnly)
                {
                    dets.AddRange(EditContrlS.EditedData);
                }

                if (EditContrlT.Visible && !EditContrlT.DisplayOnly)
                {
                    dets.AddRange(EditContrlT.EditedData);
                }

                string msg = service.UpdateEduPassportInsItem(CurrentInstanceItem, dets, this.EmpCode, ctrl == btnSubmit);

                if (msg != null)
                {
                    ShowMessage("送出失敗:" + msg);
                }
                else
                {
                    if (ctrl == btnSubmit)
                    {
                        Response.Redirect(BackUrl);
                    }
                    else
                    {
                        ShowMessage("儲存完成，暫存不會儲存您選擇的審核老師喔");
                    }
                }
                

            }

            if(ctrl == btnReject)
            {
                string msg = service.RejectEduPassportInsItem(CurrentInstanceItem, tbRejectReason.Text.Trim(), this.EmpCode, true);
                if (msg != null)
                {
                    ShowMessage("駁回失敗:" + msg);
                }
                else
                {
                    Response.Redirect(BackUrl);
                }
            }

            if(ctrl == btnCancel)
            {
                string msg = service.RejectEduPassportInsItem(CurrentInstanceItem, "", this.EmpCode);
                if (msg != null)
                {
                    ShowMessage("取消失敗:" + msg);
                }
                else
                {
                    Response.Redirect(Request.Url.ToString());
                }
            }

        }

    }


    private void ReadData()
    {
        if (CurrentIItemID == null)
        {
            ShowMessageAndGo("參數傳遞錯誤", BackUrl);
            return;
        }

        EduPassportInsItemDto iitem = service.GetEduPassportInsItemByID(CurrentIItemID);


        CurrentInstanceItem = iitem;

        if (CurrentInstanceItem.SubmitDate.HasValue)
        {
            lbSubmitTime.Text = CurrentInstanceItem.SubmitDate.Value.ToString("yyyy/MM/dd HH:mm");
        }
        else
        {
            lbSubmitTime.Text = "";
        }
        lbPassportName.Text = CurrentInstance.TemplateName;
        lbItemName.Text = CurrentInstanceItem.ItemName;
        lbTeacherName.Text = CurrentInstanceItem.TeacherName;
        lbCurrentStatus.Text = CurrentInstanceItem.StatusName;
        if (CurrentInstanceItem.ModifyDate.HasValue)
        {
            lbModifyDate.Text = CurrentInstanceItem.ModifyDate.Value.ToString("yyyy/MM/dd HH:mm");
        }
        else
        {
            lbModifyDate.Text = "";
        }

        EduPassportItemDto item = service.GetEduPassportItemWithDet(iitem.ItemID);
        if (item != null)
        {
            liDesc.Text = item.ItemDesc;
        }

        if (Request.QueryString["mode"] == "View")
        {
            EditContrlS.Visible = true;
            EditContrlS.DisplayOnly = true;
            EditContrlT.Visible = true;
            EditContrlT.DisplayOnly = true;
            panDisplayTeacher.Visible = true;
            panSelectTeacher.Visible = false;
            EditContrlT.DataSource = CurrentTInsItemDets;
            
            btnReject.Visible = false;
            btnSubmit.Visible = false;
            btnCancel.Visible = false;
            btnPreSave.Visible = false;
            panReject.Visible = false;
        }
        else
        {
            if (iitem.Status == "0")
            {
                EditContrlS.Visible = true;
                EditContrlS.DisplayOnly = false;
                EditContrlT.Visible = false;
                EditContrlT.DisplayOnly = true;
                panDisplayTeacher.Visible = false;
                btnSubmit.Visible = true;
                panReject.Visible = false;
                btnCancel.Visible = false;
                
                EduPassportTemplateDto template = service.GetEduPassportTemplateByID(CurrentInstance.TemplateID);
                if(template!=null)
                {
                    if(template.AllowAdminConfirm)
                    {
                        cbAdminConfirm.Visible = true;
                    }
                    else
                    {
                        cbAdminConfirm.Visible = false;
                    }
                }
            }
            else
            {
                panDisplayTeacher.Visible = true;
                panSelectTeacher.Visible = false;


                if (iitem.Status == "1")
                {
                    if (CurrentInstanceItem.TTarget == null || CurrentInstanceItem.TTarget.ToLower() == this.EmpCode.ToLower())
                    {
                        EditContrlS.Visible = true;
                        EditContrlS.DisplayOnly = true;
                        EditContrlT.Visible = true;
                        EditContrlT.DisplayOnly = false;
                        btnSubmit.Visible = true;
                        btnSubmit.Text = "確定審核";

                        panReject.Visible = true;
                        btnCancel.Visible = false;
                    }
                    else
                    {
                        EditContrlS.Visible = true;
                        EditContrlS.DisplayOnly = true;

                        EditContrlT.Visible = false;
                        EditContrlT.DisplayOnly = true;
                        btnSubmit.Visible = false;
                        panReject.Visible = false;
                        btnCancel.Visible = true;
                    }

                }

                if (iitem.Status == "V")
                {
                    EditContrlS.Visible = true;
                    EditContrlS.DisplayOnly = true;

                    EditContrlT.Visible = true;
                    EditContrlT.DisplayOnly = true;
                    btnSubmit.Visible = false;
                    panReject.Visible = false;
                    btnCancel.Visible = false;
                }

                EditContrlT.DataSource = CurrentTInsItemDets;
            }
        }

        EditContrlS.DataSource = CurrentSInsItemDets;

        List<EduPassportInsItemRejectHiDto> rejecthis = service.GetRejectHistory(CurrentIItemID);
        if (rejecthis.Count > 0)
        {
            panRejectHistory.Visible = true;
            rgRejectReason.DataSource = rejecthis;
            rgRejectReason.DataBind();
        }

    }


    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect(BackUrl);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    protected void tbReject_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}