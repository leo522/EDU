using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using System.IO;
using Telerik.Web.UI;
using System.Globalization;
using System.Data;

public partial class EduStopActScheduleView : AuthPage
{
    private string ScheduleID
    {
        get
        {
            return Request.QueryString["ID"];
        }
    }

    private EduStopActScheduleDto CurrentSchedule
    {
        get
        {
            return Session["EduStopActScheduleAddCurrentSchedule"] as EduStopActScheduleDto;
        }
        set
        {
            Session["EduStopActScheduleAddCurrentSchedule"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        AddPostbackControl(rgAttachment);
        AddPostbackControl(btnBookingList);
        if (!IsPostBack)
        {
            if (ScheduleID != null)
            {
                ReadSchedule();
            }
            else
            {
                ShowMessageAndGo("參數傳遞錯誤!", "EduStopActScheduleCalendar.aspx");
            }
            if (CurrentSchedule.Creater == this.EmpCode)
            {
                btnEdit.Visible = true;
                
            }
            if (this.AuthRoles.Contains("Admin") || this.AuthRoles.Contains("DepSec") || this.AuthRoles.Contains("ActWriter"))
            {

                btnCopy.Visible = true;
                btnReturn.Visible = true;
            }
            if(this.AuthRoles.Contains("Admin"))
            {
                //btnBookingList.Visible = true;
                btnEdit.Visible = true;
            }

            if(this.AuthRoles.Contains("DepSec") )//&& CurrentSchedule.DeptCode == this.DeptCode)
            {
                btnEdit.Visible = true;
            }
        }
    }
    
    private void ReadSchedule()
    {
        EduStopActScheduleDto sche = service.GetEduStopActSchedulerByID(ScheduleID);
        CurrentSchedule = sche;

        lbDept.Text = sche.DeptCode;

        if (sche.ActType != null)
        {
            Dictionary<int, EduActTypeDto> acttypes = service.GetActTypeWithParent(Convert.ToInt32(sche.ActType));

            if (acttypes.ContainsKey(0))
            {
                lbActType.Text += acttypes[0].CLS_NAME;
            }

            if (acttypes.ContainsKey(1))
            {
                lbActType.Text += " - " + acttypes[1].CLS_NAME;
            }

            if (acttypes.ContainsKey(2))
            {
                lbActType.Text += " - " + acttypes[2].CLS_NAME;
            }

            if (acttypes.ContainsKey(3))
            {
                lbActType.Text += " - " + acttypes[3].CLS_NAME;
            }
        }

        lbActName.Text = sche.ActName;
        lbActRange.Text = sche.ActRange;
        lbActDate.Text = sche.TimeFrom.ToString("yyyy/MM/dd HH:mm") + "~" + sche.TimeTo.ToString("yyyy/MM/dd HH:mm");
        lbActLocation.Text = sche.Location;
        tbDes.Text = sche.Des;
        lbCreater.Text = sche.CreaterName;
        string teacher = "";
        foreach(EduActTargetDto target in service.GetEduActTargets(ScheduleID))
        {
            if (target.RoleType == "Teacher" || target.RoleType == "005" || target.RoleType == "speaker")
            {
                EduActTargetDto targetwithname = service.FillEduActTargetName(target);

                    teacher += target.TimeFrom.ToString("yyyy/MM/dd") + " " + target.TimeFrom.ToString("HH:mm") + "~" + target.TimeTo.ToString("HH:mm") + "  ";
                
                teacher +=  target.RoleName + "：" + targetwithname.TargetName + "<br/>";
            }
        }
        if (teacher != "")
        {
            teacher = teacher.Substring(0, teacher.Length - 5);
        }
        liTeacher.Text = teacher;

        if (sche.AllowBooking)
        {
            if (sche.Creater == this.EmpCode || this.AuthRoles.Contains("Admin"))
            {
                btnBookingList.Visible = true;
            }
            else
            {
                btnBooking.Visible = true;
                CheckBookStatus();
            }
        }

        panEditAttachment.Visible = true;
        //odsAttachment.Select();
        ReadAttachment();
    }

    private void CheckBookStatus()
    {
        bool isbooked = service.CheckIsBooked(this.EmpCode, CurrentSchedule.EduStopActScheduleID);
        if (isbooked)
        {
            btnBooking.Text = "取消報名";
        }
        else
        {
            btnBooking.Text = "報名";
        }
    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduStopActScheduleAdd.aspx?id=" + ScheduleID);
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduStopActScheduleAdd.aspx?copyby=" + ScheduleID);
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduStopActScheduleCalendar.aspx");
    }
    private void ReadAttachment()
    {
        List<EduStopActAttachmentDto> list = new List<EduStopActAttachmentDto>();
        //if (ViewState["CurrentEduAtt"] == null)
        //{
        list = service.GetEduActAttachmentsWithoutContent(ScheduleID, null);
            //ViewState["CurrentEduAtt"] = list;
        //}
        rgAttachment.DataSource = list;
    }
    protected void rgAttachment_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadAttachment();
    }
    protected void rgAttachment_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            //if (ViewState["CurrentEduAtt"] != null)
            //{
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;

                string id = item.GetDataKeyValue("ActAttachmentID").ToString();

                //List<EduStopActAttachmentDto> list = ViewState["CurrentEduAtt"] as List<EduStopActAttachmentDto>;

                //EduStopActAttachmentDto att = list.Where(c => c.ActAttachmentID == id).FirstOrDefault();

                HyperLink lbtn = item.FindControl("lbtnAtt") as HyperLink;

                //lbtn.Text = att.Name;
                lbtn.NavigateUrl = "DownloadActAttachment.aspx?ID=" + id;
            }
            //}

        }
    }
    protected void lbtnAtt_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as LinkButton).Parent.Parent as GridDataItem;
        string id = item.GetDataKeyValue("ActAttachmentID").ToString();

        List<EduStopActAttachmentDto> list = ViewState["CurrentEduAtt"] as List<EduStopActAttachmentDto>;

        EduStopActAttachmentDto att = list.Where(c => c.ActAttachmentID == id).FirstOrDefault();

        byte[] bytes = att.Attachment;


        HttpResponse response = Response;

        response.Clear();
        response.ClearContent();
        response.ClearHeaders();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.HtmlEncode(att.FileName) + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();
    }
    protected void btnBooking_Click(object sender, EventArgs e)
    {
        if (btnBooking.Text == "報名")
        {
            string result = service.BookEduAct(this.EmpCode, CurrentSchedule.EduStopActScheduleID);
            if (result == null)
            {
                ShowMessage("報名成功");
                CheckBookStatus();
            }
            else
            {
                ShowMessage("報名失敗:" + result);
            }
        }
        else
        {
            bool result = service.UnBookEduAct(this.EmpCode, CurrentSchedule.EduStopActScheduleID);
            if (result)
            {
                ShowMessage("取消成功");
                CheckBookStatus();
            }
            else
            {
                ShowMessage("取消失敗，請重試");
            }
        }
    }
    protected void btnBookingList_Click(object sender, EventArgs e)
    {
        ViewState["CurrentEduAtt"] = null;
        List<EduActBookingDto> list = service.GetBookingList(CurrentSchedule.EduStopActScheduleID);

        Utility uti = new Utility();
        Dictionary<string, string> map = new Dictionary<string, string>();
        map.Add("EmpCode", "職編");
        map.Add("EmpName", "姓名");









        byte[] bytes = uti.ExportDataTableToExcel(uti.ConvertToDataTable(list, map, "報名清單"));


        HttpResponse response = Response;

        response.Clear();
        response.ClearContent();
        response.ClearHeaders();

        //response.AppendCookie(new HttpCookie("fileDownloadToken", download_token_value_id.Value));

        response.AddHeader("Content-Type", "binary/octet-stream");

        response.AddHeader("Content-Disposition", "attachment; filename=data.xls" + "; size=" + bytes.Length.ToString());

        response.BinaryWrite(bytes);

        response.Flush();
        response.End();

    }
}