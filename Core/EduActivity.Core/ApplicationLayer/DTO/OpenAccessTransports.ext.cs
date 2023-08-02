using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AppFramework.Repository;
using KMU.EduActivity.Infrastructure.Data.Repositories;
using System.Web;
using System.Web.SessionState;
using KMU.EduActivity.ApplicationLayer.Assemblers;
using System.Data;
using System.Collections.Specialized;
using System.Linq.Expressions;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.ApplicationLayer.DTO
{
    [Serializable]
    public partial class EduActViewTargetDto
    {

    }
    [Serializable]
    public partial class JobFormSettingDto
    {
    }

    [Serializable]
    public partial class AutoEduFormTemplateListDto
    {

    }
    [Serializable]
    public partial class AccountDto
    {

    }
    [Serializable]
    public partial class IKASA_ERCaseDto
    {
        public string EmpName { get; set; }
        public string EvalType { get; set; }
        public int EvalID { get; set; }

        public string DOPSStatus { get; set; }
        public string EPAStatus { get; set; }
    }

    [Serializable]
    public partial class OSCEBlockTimeDto
    {
        public string EmpName
        {
            get;
            set;
        }
        public string CreateName
        {
            get;
            set;
        }
    }


    public partial class PassPortStudentApplicationItemDto
    {
        public virtual string TeacherName { get; set; }
        public virtual string ItemName { get; set; }

    }

    [Serializable]
    public partial class EduMemberTermPassDto
    {
        public string EduTermID
        {
            get;
            set;
        }
        public string ParentEduTermID
        {
            get;
            set;
        }

        public string TermName
        {
            get;
            set;
        }
        public string JobName
        {
            get;
            set;
        }

        public DateTime Sdate
        {
            get;
            set;
        }
        public DateTime Edate
        {
            get;
            set;
        }

        public string TermRange
        {
            get
            {
                if (ParentEduTermID == null)
                {
                    return "";
                }
                else
                {
                    return Sdate.ToString("yyyy/MM/dd") + "~" + Edate.ToString("yyyy/MM/dd");
                }
            }
        }

        public string DepName
        {
            get;
            set;
        }

        public List<EduTermFormReqDto> TermReqs
        {
            get;
            set;
        }

        public List<FORM_INSTANCEDto> OtherForms
        {
            get;
            set;
        }

        private string _UDLinkTemplate = null;
        public string UDLinkTemplate
        {
            get
            {
                if(_UDLinkTemplate == null)
                {
                    return @"<a href='InstanceDetial.aspx?instance_id={0}&edutermid={1}&mode=v' target='_blank'>{2}</a>";
                
                }
                else
                {
                    return _UDLinkTemplate;
                }
            }
            set
            {
                _UDLinkTemplate = value;
            }
        }

        public string DetStr
        {
            get
            {

                try
                {
                    //style='background-color:#30FFFF'
                    string template = @"
    <div >
        <ul>
            {0}
        </ul>
    </div>";

                    string contenttemplate = @"<li>{0}<ul>{1}</ul></li>";
                    string dettemplate = "<li>" + UDLinkTemplate + "</li>";
                    string dettemplatenolink = @"<li>{2}</li>";

                    string fullhtml = "";

                    string edutermid = this.EduTermID;
                    string eduname = "";
                    string content = "";
                    bool isfinish = true;
                    if (this.TermReqs != null)
                    {
                        foreach (var req in this.TermReqs)
                        {

                            string detstr = "";
                            foreach (var det in req.MemberPassForms)
                            {
                                if (det.DISPLAY_TO_EVALTARGET.HasValue && !det.DISPLAY_TO_EVALTARGET.Value)
                                {
                                    detstr += string.Format(dettemplatenolink, det.INSTANCE_ID.ToString(), edutermid, det.INSTANCE_NAME + "(發送時間:" + det.INSTANCE_CREATE_DATETIME.ToString("yyyy/MM/dd HH:mm") + ",完成時間:" + (det.INSTANCE_ALTER_DATETIME.HasValue ? det.INSTANCE_ALTER_DATETIME.Value.ToString("yyyy/MM/dd") : "") + ")");
                                }
                                else
                                {
                                    detstr += string.Format(dettemplate, det.INSTANCE_ID.ToString(), edutermid, det.INSTANCE_NAME + "(發送時間:" + det.INSTANCE_CREATE_DATETIME.ToString("yyyy/MM/dd HH:mm") + ",完成時間:" + (det.INSTANCE_ALTER_DATETIME.HasValue ? det.INSTANCE_ALTER_DATETIME.Value.ToString("yyyy/MM/dd") : "") + ")");
                                }
                            }

                            string finishstr = "";
                            if (req.MemberPassCount >= req.ReqCount)
                            {
                                finishstr = "<font color='blue'>(已完成)</font>";
                            }
                            content += string.Format(contenttemplate, "<b>課程需求：" + req.ReqName + "</b> (" + req.MemberPassCount.ToString() + "/" + req.ReqCount.ToString() + ")" + finishstr, detstr);
                            if (req.MemberPassCount < req.ReqCount)
                            {
                                isfinish = false;
                            }
                        }
                    }

                    string odetstr = "";
                    if (this.OtherForms != null)
                    {
                        foreach (var det in this.OtherForms)
                        {
                            if (det.DISPLAY_TO_EVALTARGET.HasValue && !det.DISPLAY_TO_EVALTARGET.Value)
                            {
                                odetstr += string.Format(dettemplatenolink, det.INSTANCE_ID.ToString(), edutermid, det.INSTANCE_NAME + "(發送時間:" + det.INSTANCE_CREATE_DATETIME.ToString("yyyy/MM/dd HH:mm") + ",完成時間:" + (det.INSTANCE_ALTER_DATETIME.HasValue ? det.INSTANCE_ALTER_DATETIME.Value.ToString("yyyy/MM/dd") : "") + ")");
                            }
                            else
                            {
                                odetstr += string.Format(dettemplate, det.INSTANCE_ID.ToString(), edutermid, det.INSTANCE_NAME + "(發送時間:" + det.INSTANCE_CREATE_DATETIME.ToString("yyyy/MM/dd HH:mm") + ",完成時間:" + (det.INSTANCE_ALTER_DATETIME.HasValue ? det.INSTANCE_ALTER_DATETIME.Value.ToString("yyyy/MM/dd") : "") + ")");
                            }
                        }
                    }
                    if (odetstr == "")
                    {
                        odetstr = "無";
                    }
                    content += string.Format(contenttemplate, "<b>已完成表單</b>", odetstr);

                    if (isfinish)
                    {
                        eduname += " - <font color='blue'>已完成</font>";
                    }

                    string html = string.Format(template, content);
                    fullhtml += html;

                    return fullhtml;
                }
                catch(Exception ex)
                {
                    return "";
                }
            }
        }

        public string PassStatus
        {
            get;
            set;
        }

    }


    [Serializable]
    public partial class OSCECertDto
    {
        public string EmpName
        {
            get;
            set;
        }
        public string CreateName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class FORM_INSTANCE_RETURN_LOGDto
    {
        public string EmpName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class AccountRoleDto
    {
        public string EmpName
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class FORM_TEMPLATEDto
    {
        public bool IsMultiTargetForm
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class MyListDetDto
    {
        public string EmpName
        {
            get;
            set;
        }
        public string JobCode
        {
            get;
            set;
        }
        public string JobName
        {
            get;
            set;
        }

    }

    [Serializable]
    public partial class SelectKmuVsDto
    {

    }

    [Serializable]
    public partial class EduTeamRundownDto
    {

    }

    public partial class EduPassportInsItemRejectHiDto
    {
        public string EmpName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class RecordInsViewerDto
    {
        public string EmpName
        {
            get;
            //{
            //KMU.EduActivity.ApplicationLayer.Services.EduActivityContextService service = new Services.EduActivityContextService();
            //V_KmuEmpDto emp = service.ReadV_KmuEmps(c => c.Empcode == this.Viewer).FirstOrDefault();
            //if (emp != null)
            //{
            //    return emp.Empname;
            //}
            //else
            //{
            //    return "查無此員工";
            //}
            //}
            set;

        }
    }

    [Serializable]
    public partial class RecordInsReaderDto
    {
        public string EmpName
        {
            get;
            //{
            //KMU.EduActivity.ApplicationLayer.Services.EduActivityContextService service = new Services.EduActivityContextService();
            //V_KmuEmpDto emp = service.ReadV_KmuEmps(c => c.Empcode == this.Reader).FirstOrDefault();
            //if (emp != null)
            //{
            //    return emp.Empname;
            //}
            //else
            //{
            //    return "查無此員工";
            //}
            //}
            set;
        }
    }

    [Serializable]
    public class TeachPointCalcSumData
    {
        public string EmpCode
        {
            get;
            set;
        }
        public string EmpName
        {
            get;
            set;
        }
        public List<TeachPointCalcItemData> ItemDatas
        {
            get;
            set;
        }
        public decimal SumPoint
        {
            get
            {
                decimal sump = 0;
                if(ItemDatas!=null)
                {
                    foreach(TeachPointCalcItemData i in ItemDatas)
                    {
                        sump += i.SumPoint;
                    }
                }

                return sump;
            }
        }

    }

    [Serializable]
    public partial class PassPortStudentApplicationItemFailLogDto
    {
        public string TeacherName
        {
            get;
            set;
        }
    }

    [Serializable]
    public class TeachPointCalcItemData
    {
        public int TypeID
        {
            get;
            set;
        }

        public int ItemID
        {
            get;
            set;
        }

        public string ItemName
        {
            get;
            set;
        }

        public string TrainingType
        {
            get;
            set;
        }

        public string EmpCode
        {
            get;
            set;
        }

        public string EmpName
        {
            get;
            set;
        }

        public decimal SumPoint
        {
            get;
            set;
        }

        public List<TeachPointCalcItemDetailData> DetailData
        {
            get;
            set;
        }

        
    }
    [Serializable]
    public class TeachPointCalcItemDetailData
    {
        public DateTime OrrcuTime
        {
            get;
            set;
        }

        public string PointDesc
        {
            get;
            set;
        }

        public decimal DetailPoint
        {
            get;
            set;
        }

        public string StatusMsg
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class TeachPointCalcTypeDto
    {

    }

    [Serializable]
    public partial class EduQuestionDto
    {

    }

    [Serializable]
    public partial class MyListDto
    {

    }

    [Serializable]
    public partial class RecordEduActRefDto
    {

    }

    [Serializable]
    public partial class MailListDto
    {
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string OtherParam1 { get; set; }
        public string OtherParam2 { get; set; }
        public string OtherParam3 { get; set; }
        public string OtherParam4 { get; set; }
        public string OtherParam5 { get; set; }

    }

    [Serializable]
    public partial class RecordTemplateDto
    {

    }

    [Serializable]
    public partial class RecordInstanceRejectLogDto
    {
        public string EmpName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class RecordInsSignInDto
    {
        public string EmpName
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }

        public virtual string TargetName { get; set; }
        public virtual string TargetTypeName { get; set; }

    }

    [Serializable]
    public partial class RecordInsDetDto
    {

    }

    [Serializable]
    public partial class RecordInstanceDto
    {
        public NameValueCollection DetNameValueData
        {
            get
            {
                NameValueCollection coll = new NameValueCollection();
                if (this.RecordInsDets != null)
                {
                    foreach(RecordInsDetDto dto in this.RecordInsDets)
                    {
                        coll.Add(dto.ControlID, dto.ControlValue);
                    }
                }

                return coll;
            }

            set
            {
                if (value != null)
                {
                    this.RecordInsDets = new List<RecordInsDetDto>();
                    foreach(string key in value.Keys)
                    {
                        RecordInsDetDto dto = new RecordInsDetDto();
                        dto.InstanceID = this.InstanceID;
                        dto.ControlID = key;
                        dto.ControlValue = value[key];
                        this.RecordInsDets.Add(dto);
                    }
                }
                else
                {
                    this.RecordInsDets = new List<RecordInsDetDto>();
                }
            }
        }

        public string StatusName
        {
            get
            {
                string statusname = "";
                switch (this.Status)
                {
                    case "0":
                        statusname = "暫存未送出";
                        break;
                    case "1":
                        statusname = "已完成未送審";
                        break;
                    case "2":
                        statusname = "審核中";
                        break;
                    case "V":
                        statusname = "審核完成";
                        break;
                }

                return statusname;
            }
        }

        public string RecordTime
        {
            get
            {
                string result = "";
                if(this.Sdate.HasValue)
                {
                    result += this.Sdate.Value.ToString("yyyy/MM/dd HH:mm");
                }
                else
                {
                    result += "----/--/--";
                }
                result += "~";
                if (this.Edate.HasValue)
                {
                    result += this.Edate.Value.ToString("yyyy/MM/dd HH:mm");
                }
                else
                {
                    result += "----/--/--";
                }

                return result;
            }
        }

        public string TemplateName
        {
            get;
            set;
        }

        public string CreaterName
        {
            get;
            set;
        }
        public string DeptName
        {
            get;
            set;
        }

        public bool AllowGetBack
        {
            get;
            set;
        }
    }


    [Serializable]
    public partial class V_KmuEmpDto
    {
        public string DisplayName
        {
            get
            {
                return this.Empcode + " " + this.Empname;
            }
        }
    }

    [Serializable]
    public partial class EduPassportPRefDto
    {
        public string itemName
        {
            get;
            set;
        }
    }
    
    [Serializable]
    public partial class TeachPointEmpItemDatumDto
    {
        public string ItemName
        {
            get;
            set;
        }
        public string EmpName
        {
            get;
            set;
        }
        public string CreateName
        {
            get;
            set;
        }
        
    }

    [Serializable]
    public partial class TrainingTimeDto
    {
        public string EmpName
        {
            get;
            set;
        }
        public string CreateName
        {
            get;
            set;
        }

        public string DepName
        {
            get;
            set;
        }

        public string TitleName
        {
            get;
            set;
        }
        
    }
    


    [Serializable]
    public partial class VoteStasticMain
    {
        public int VoteCount
        {
            get;
            set;
        }
        public VoteMainDto MainDto
        {
            get;
            set;
        }

        public List<VoteStasticItem> VoteItems
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class VoteStasticItem
    {
        public int GroupID
        {
            get;
            set;
        }

        public string GroupName
        {
            get;
            set;
        }

        public string ItemValue
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
        public int DataCount
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class TeachPointItemDto
    {
        public string FullItemName
        {
            get
            {
                string ttype = "";
                if (this.TrainingType != null)
                {
                    ttype = "(" + this.TrainingType + ")";
                }
                return this.ItemName + ttype;
            }
        }
    }

    [Serializable]
    public partial class VoteItemDto
    {
        public string Value
        {
            get;
            set;
        }
        public string Text
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class VoteTargetDto
    {

    }

    [Serializable]
    public partial class VoteMainDto
    {

    }

    [Serializable]
    public partial class VoteJobDto
    {

    }

    [Serializable]
    public partial class VoteInstanceDto
    {

    }

    [Serializable]
    public partial class VoteInsDetDto
    {

    }

    [Serializable]
    public partial class VoteGroupDto
    {
        public List<VoteItemDto> VoteItems
        {
            get;
            set;
        }

        public int CanCheckCount
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class VoteGCondDto
    {

    }

    [Serializable]
    public partial class AutoEduFormTemplateExceptDto
    {

    }

    [Serializable]
    public partial class FormSendSettingData
    {
        public string FTListID
        {
            get;
            set;
        }

        public string SettingName
        {
            get;
            set;
        }

        public string EduTermID
        {
            get;
            set;
        }

        public string EduTermName
        {
            get;
            set;
        }

        public string EduTermDate
        {
            get;
            set;
        }

        public string DeptCode
        {
            get;
            set;
        }
        public string DeptName
        {
            get;
            set;
        }

        public int TEMPLATE_ID
        {
            get;
            set;
        }

        public string TEMPLATE_NAME
        {
            get;
            set;
        }

        public DateTime ExecuteDate
        {
            get;
            set;
        }

        public string SettingStatus
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class EduStopActScheduleDto
    {
        public string CreaterName
        {
            get;
            set;
        }

        public string RecordInstanceID
        {
            get;
            set;
        }

        public string RecordInstanceStatus
        {
            get;
            set;
        }
    }
    [Serializable]
    public partial class PassPortSpecialListDto
    {
        public string EmpName
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class ElearningClassDto
    {
        public string ClassDateStr
        {
            get
            {
                string sdate = this.SDate.HasValue ? this.SDate.Value.ToString("yyyy/MM/dd") : "";
                string edate = this.EDate.HasValue ? this.EDate.Value.ToString("yyyy/MM/dd") : "";

                return sdate + "~" + edate;
            }
        }
    }

    [Serializable]
    public partial class ElearningItemDto
    {
        public bool isFinished
        {
            get
            {
                return this.ElearningEmpItems != null;
            }
        }
    }

    [Serializable]
    public partial class ElearningEmpItemDto
    {
    }

    [Serializable]
    public partial class EduActTypeDto
    {
    }

    [Serializable]
    public partial class V_CodeRefDto
    {
    }

    [Serializable]
    public partial class EduActTypeRefDto
    {
        public string CLS_NAME
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class SelectGroupTypeDto
    {
    }

    [Serializable]
    public partial class EduActBookingDto
    {
        public string EmpName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class HospDto
    {
        public string HospCode
        {
            get;
            set;
        }

        public string HospName
        {
            get;
            set;
        }
    }
    [Serializable]
    public partial class V_departmentDto
    {
        public string DisplayName
        {
            get
            {
                return this.Deptcode + " " + this.Deptname;
            }
        }
    }

    [Serializable]
    public partial class ScoreInstanceDto
    {

        public string CreaterName
        {
            get;
            set;
        }

        public string ModifierName
        {
            get;
            set;
        }
        private Dictionary<string, decimal> _scorePercents = null;
        public Dictionary<string, decimal> ScorePercents
        {
            get
            {
                if (_scorePercents != null)
                {
                    return _scorePercents;
                }
                
                if (this.ScoreInstanceDetails != null)
                {
                    _scorePercents = new Dictionary<string, decimal>();
                    foreach (ScoreInstanceDetailDto dto in this.ScoreInstanceDetails)
                    {
                        if (!_scorePercents.ContainsKey(dto.ValueID))
                        {
                            _scorePercents.Add(dto.ValueID, dto.ScorePercent.Value);
                        }
                    }
                }

                return _scorePercents;
            }
        }

        //攤平資料
        public DataTable DetailTableData
        {
            get
            {
                if (this.ScoreInstanceDetails != null)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("員工編號");
                    dt.Columns["員工編號"].Namespace = "員工編號";
                    dt.Columns["員工編號"].Caption = "true";
                    //dt.Columns["員工編號"].ReadOnly = true;
                    dt.Columns.Add("姓名");
                    dt.Columns["姓名"].Namespace = "姓名";
                    dt.Columns["姓名"].Caption = "true";
                    //dt.Columns["姓名"].ReadOnly = true;

                    foreach (ScoreInstanceDetailDto dto in this.ScoreInstanceDetails)
                    {
                        if (!dt.Columns.Contains(dto.ValueName + "(" + dto.ScorePercent.ToString() + "%)"))
                        {
                            dt.Columns.Add(dto.ValueName + "(" + dto.ScorePercent.ToString() + "%)");
                            dt.Columns[dto.ValueName + "(" + dto.ScorePercent.ToString() + "%)"].Namespace = dto.ValueID;

                            if (dto.ValueType == "自訂分數")
                            {
                                dt.Columns[dto.ValueName + "(" + dto.ScorePercent.ToString() + "%)"].Caption = "false";
                                //dt.Columns[dto.ValueName].ReadOnly = false;
                            }
                            else
                            {

                                dt.Columns[dto.ValueName + "(" + dto.ScorePercent.ToString() + "%)"].Caption = "true";
                                //dt.Columns[dto.ValueName].ReadOnly = true;
                            }
                        }
                    }

                    dt.Columns.Add("總平均");
                    dt.Columns["總平均"].Namespace = "總平均";
                    dt.Columns["總平均"].Caption = "true";
                    //dt.Columns["總平均"].ReadOnly = true;

                    foreach (ScoreInstanceDetailDto dto in this.ScoreInstanceDetails)
                    {
                        DataRow[] drs = dt.Select("員工編號 = '" + dto.TargetID + "'");
                        DataRow dr = null;
                        if (drs.Length > 0)
                        {
                            dr = drs[0];
                        }
                        else
                        {
                            dr = dt.NewRow();
                            dr["員工編號"] = dto.TargetID;
                            dr["姓名"] = dto.TargetName;
                            dt.Rows.Add(dr);
                        }

                        if (dto.Score.HasValue)
                        {
                            dr[dto.ValueName + "(" + dto.ScorePercent.ToString() + "%)"] = Math.Round(dto.Score.Value, 2);
                        }
                        //else
                        //{
                        //    dr[dto.ValueName + "(" + dto.ScorePercent.ToString() + "%)"] = dto.Score;
                        //}

                    }


                    foreach (DataRow dr in dt.Rows)
                    {
                        decimal avg = 0;
                        
                        for (int i = 2; i < dt.Columns.Count - 1; i++)
                        {
                            avg += (dr[i] == DBNull.Value ? 0 : Convert.ToDecimal(dr[i])) * this.ScorePercents[dt.Columns[i].Namespace] / 100;   
                        }
                        dr["總平均"] = Math.Round(avg, 2);
                    }

                    return dt;
                }
                else
                {
                    return null;
                }
            }
        }

    }
    [Serializable]
    public partial class EduScoreDto
    {
        public string EmpName { get; set; }
        public string CreateName { get; set; }
    }

    [Serializable]
    public partial class iKasaChartData
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }

    public partial class iKasaFormFinishObject
    {
        public int instanceid
        {
            get;
            set;
        }
        public DateTime expiredate
        {
            get;
            set;
        }
        public string status
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class ScoreInstanceDetailDto
    {
        public string TargetName
        {
            get;
            set;
        }

        public string ValueName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class FORM_INSTANCEDto
    {
        public bool? DISPLAY_TO_EVALTARGET
        {
            get;
            set;
        }
    }
    [Serializable]
    public partial class TeachTimeTypeDto
    {
    }
    [Serializable]
    public partial class News_AttachmentDto
    {
    }

    [Serializable]
    public partial class NewsViewTargetDto
    {
        public string TargetName
        {
            get;
            set;
        }
    }
    [Serializable]
    public partial class HealTeachTimeDto
    {
        public string EmpName
        {
            get;
            set;
        }
        public string TargetTypeName
        {
            get;
            set;
        }
        public string ActTypeName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class MedicalTeachPointDto
    {
        public string EmpName
        {
            get;
            set;
        }
        public string StatusName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class ScoreSettingDto
    {
        public string DeptName
        {
            get;
            set;
        }
        public string CreaterName
        {
            get;
            set;
        }
        public string ModifierName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class ScoreSettingJobDto
    {
        public string JobName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class ScoreSettingDetailDto
    {
        public string ValueIdName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class NewsDto
    {
    }
    [Serializable]
    public partial class EduTeamDto
    {
        #region Properties

        #endregion Properties
        

        public List<EduTeamDto> GetEduTeams()
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityContextService service = new Services.EduActivityContextService();
            
            
            List<EduTeamDto> list = service.ReadEduTeams(c => c.Status == 'V').OrderBy(c => c.EduTeamCode).ToList();
            //EduTeamDto nulldto = new EduTeamDto();
            //nulldto.EduTeamCode = null;
            //nulldto.DtoKey = null;
            //list.Insert(0, nulldto);
            return list;
        }


        public List<EduTeamDto> GetEduTeamsUsed()
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityContextService service = new Services.EduActivityContextService();
            EduTeamMemberRepository rep = new EduTeamMemberRepository(service.UnitOfWork);

            List<EduTeamDto> list = service.ReadEduTeams(c => c.Status == 'V' && rep.GetAll().Count(d => d.EduTeamCode == c.EduTeamCode) > 0).OrderBy(c => c.EduTeamCode).ToList();



            return list;
        }

    }

        public partial class MessageBoardDto : BaseDTOEntity, IDtoWithKey
        {
            public virtual string SendTimeStr
            {
                get
                {
                    return this.SendTime.ToString("yyyy/MM/dd HH:mm");
                }
            }

            public virtual int ReplyCount
            {
                get;
                set;
            }

            public virtual string EmpName
            {
                get;
                set;
            }

            public virtual string JobCodeName
            {
                get;
                set;
            }

            public virtual bool IsClose
            {
                get
                {
                    return this.Status == 'C';
                }
            }
        }


    public partial class NewsDto
    {
        public virtual string CREATERNAME { get; set; }
    }

    public partial class AutoEduFormTemplateExceptDto
    {
        public virtual string ExceptName { get; set; }
    }
    [Serializable]
    public partial class MemberDto
    {
        #region Properties
        public virtual string EduTeamCode { get; set; }
        public virtual string EduTeamName { get; set; }
        public virtual string StatusName { get; set; }
        public virtual string DisplayName { get; set; }
        #endregion Properties
    }

    public partial class V_kmujobDto
    {
        public string DisplayName
        {
            get
            {
                if (this.ENGLISH_NAME != null && this.ENGLISH_NAME.Trim() != "")
                {
                    return this.JOB_CODE_X + "-" + this.JOB_NAME.Trim() + "(" + this.ENGLISH_NAME.Trim() + ")";
                }
                else
                {
                    return this.JOB_CODE_X + "-" + this.JOB_NAME.Trim();
                }
            }
        }
    }
    [Serializable]
    public partial class EduTermDto
    {
        #region Properties
        public virtual string DateFromToStr { get; set; }
        public virtual string UnitStr { get; set; }
        public virtual string ParentEduTermCode { get; set; }
        public virtual string CR { get; set; }
        public virtual int MemberCount { get; set; }
        public virtual string ProjM { get; set; }
        public virtual string TMaster { get; set; }
        public virtual string NurseD { get; set; }

        #endregion Properties

        public List<EduTermDto> GetEduTermsLv0(
                    string EduStopCode, string name, DateTime? datebegin, DateTime? dateend, string creater, string deptcode, string EduYear, string jobcode
                    )
        {
            return GetEduTermsLv0(EduStopCode, name, datebegin, dateend, creater, deptcode, EduYear, jobcode, null, true);
        }


        //取得課程master資料(for objectdatasource使用)
        public List<EduTermDto> GetEduTermsLv0(
            string EduStopCode, string name, DateTime? datebegin, DateTime? dateend, string creater, string deptcode, string EduYear, string jobcode, List<string> deptsecdeps, bool showallsub
            )
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityContextService service = new Services.EduActivityContextService();

            EduTermRepository rep = new EduTermRepository(service.UnitOfWork);

            EduTermAssembler asm = new EduTermAssembler();


            var data = rep.Find(c => c.EduYear != "102");
            
            if(EduStopCode!= null)
            {
                

            }


            List<EduTermDto> list = asm.Assemble(rep.Find(c =>
                c.EduYear!="102"
                &&
                (
                EduStopCode == null
                ||
                c.EduStopCode.Contains(EduStopCode)
                ||
                rep.GetAll().Count(d => d.EduStopCode.Contains(EduStopCode) && d.RoundCode.Contains(c.EduTermID)) > 0
                )
                &&
                (
                creater == null
                ||
                c.Creater == creater
                )
                &&
                (
                EduYear == null
                ||
                EduYear == ""
                ||
                c.EduYear == EduYear
                )
                &&
                (
                jobcode == null
                ||
                jobcode == ""
                ||
                c.JobCode == jobcode
                )
                &&
                (
                name == null
                ||
                c.Name.Contains(name)
                ||
                c.EduTerms.Count(d => d.Name.Contains(name)) > 0
                //||
                //rep.GetAll().Count(d => d.Name.Contains(name) && d.RoundCode.Contains(c.EduTermID)) > 0
                )
                &&
                !c.RoundCode.Contains("|")
                &&
                (datebegin == null
                    || (c.DateFrom.Date <= datebegin && c.DateTo.Date >= datebegin && c.DateTo.Date <= dateend)
                    || (c.DateFrom.Date >= datebegin && c.DateTo.Date <= dateend)
                    || (c.DateFrom.Date <= dateend && c.DateTo.Date >= dateend))
                    && (deptcode == null
                    || deptcode == ""
                    || c.DepCode == deptcode
                    || c.Department == deptcode
                    || c.EduTerms.Count(d => d.DepCode == deptcode) > 0
                    || c.EduTerms.Count(d=> d.Department == deptcode)>0
        )
        && (deptsecdeps == null || deptsecdeps.Contains(c.DepCode) || deptsecdeps.Contains(c.Department)
        || (c.EduTerms.Count(d => deptsecdeps.Contains(d.DepCode) || deptsecdeps.Contains(d.Department)) > 0) 
        || (c.EduTerms.Count(d => d.EduTerms.Count(e => deptsecdeps.Contains(e.DepCode) || deptsecdeps.Contains(e.Department)) > 0) > 0)
        )

                    ).OrderBy(c => c.RoundCode).ThenBy(c => c.DateFrom).ToList()).ToList();

            EduActivity.ApplicationLayer.Services.EduActivityAppService appservice = new Services.EduActivityAppService();
            List<SelectGroupTypeDto> depts = appservice.GetTermUnit("EduAct_Dept");
            List<SelectGroupTypeDto> stations = appservice.GetTermUnit("EduAct_Station");
            List<SelectKmuVsDto> vss = EduActivity.ApplicationLayer.Services.EduActivityAppService.GetKmuVs(null);

            if (HttpContext.Current != null)
            {
                HttpSessionState session = HttpContext.Current.Session;

                if (session != null)
                {
                    //將資料帶到Lv1減少資料讀取次數
                    session["EduTermDepts"] = depts;
                    session["EduTermStations"] = stations;
                    session["EduTermVss"] = vss;
                    List<EduTermDto> sublist = asm.Assemble(rep.Find(c =>
                                        c.EduYear != "102"
                &&
                        c.RoundCode != null &&
                        (showallsub ||

(
                EduStopCode == null
                ||
                c.EduStopCode.Contains(EduStopCode)
                ||
                rep.GetAll().Count(d => d.EduStopCode.Contains(EduStopCode) && d.RoundCode.Contains(c.EduTermID)) > 0
                )
                &&
                (
                creater == null
                ||
                c.Creater == creater
                )
                &&
                (
                EduYear == null
                ||
                EduYear == ""
                ||
                c.EduYear == EduYear
                )
                &&
                (
                jobcode == null
                ||
                jobcode == ""
                ||
                c.JobCode == jobcode
                )
                &&
                (
                name == null
                ||
                c.Name.Contains(name)
                ||
                rep.GetAll().Count(d => d.Name.Contains(name) && d.RoundCode.Contains(c.EduTermID)) > 0
                )
                    && (deptcode == null
                    || deptcode == ""
                    || c.DepCode == deptcode
                    || c.Department == deptcode
                    || c.EduTerms.Count(d => d.DepCode == deptcode) > 0
                    || c.EduTerms.Count(d => d.Department == deptcode) > 0
        )
        && (deptsecdeps == null || deptsecdeps.Contains(c.DepCode) || deptsecdeps.Contains(c.Department) 
        || c.EduTerms.Count(d => deptsecdeps.Contains(d.DepCode) || deptsecdeps.Contains(d.Department)) > 0 
        || (c.EduTerm1 != null && (deptsecdeps.Contains(c.EduTerm1.DepCode) || deptsecdeps.Contains(c.EduTerm1.Department)))
        )
        )
        &&
            (datebegin == null
                || (c.DateFrom.Date <= datebegin && c.DateTo.Date >= datebegin && c.DateTo <= dateend)
                || (c.DateFrom.Date >= datebegin && c.DateTo.Date <= dateend)
                || (c.DateFrom.Date <= dateend && c.DateTo.Date >= dateend))).OrderBy(c => c.DateFrom).ThenBy(c => c.RoundCode).ToList()).ToList();
                    session["EduTermSubList"] = sublist;

                }
            }

            foreach (EduTermDto dto in list)
            {
                SelectGroupTypeDto dep = depts.Where(c => c.code == dto.DepCode).FirstOrDefault();
                if (dep != null)
                {
                    dto.UnitStr = dep.name;
                }

                SelectGroupTypeDto station = stations.Where(c => c.code == dto.NStation).FirstOrDefault();
                if (station != null)
                {
                    dto.UnitStr = station.name;
                }

                SelectKmuVsDto vs = vss.Where(c => c.code == dto.CorchID).FirstOrDefault();
                if (vs != null)
                {
                    dto.UnitStr = vs.name;
                }

            }


            

            return list;

        }

        public List<EduTermDto> GetEduTermsLv1(string ParentEduTermID)
        {
            List<SelectGroupTypeDto> depts = new List<SelectGroupTypeDto>();
            List<SelectGroupTypeDto> stations = new List<SelectGroupTypeDto>();
            List<SelectKmuVsDto> vss = new List<SelectKmuVsDto>();

            List<EduTermDto> list = new List<EduTermDto>();
            
            //直接取Lv0已經Select的資料來做篩選減少資料讀取次數
            HttpSessionState session = null;
            if (HttpContext.Current != null)
            {
                session = HttpContext.Current.Session;

                if (session != null)
                {
                    depts = session["EduTermDepts"] as List<SelectGroupTypeDto>;
                    stations = session["EduTermStations"] as List<SelectGroupTypeDto>;
                    vss = session["EduTermVss"] as List<SelectKmuVsDto>;
                    list = (session["EduTermSubList"] as List<EduTermDto>).Where(c => c.ParentEduTermID == ParentEduTermID).ToList();
                }
            }

            KMU.EduActivity.ApplicationLayer.Services.EduActivityContextService service = new Services.EduActivityContextService();

            foreach (EduTermDto dto in list)
            {
                SelectGroupTypeDto dep = depts.Where(c => c.code == dto.DepCode).FirstOrDefault();
                if (dep != null)
                {
                    dto.UnitStr = dep.name;
                }

                SelectGroupTypeDto station = stations.Where(c => c.code == dto.NStation).FirstOrDefault();
                if (station != null)
                {
                    dto.UnitStr = station.name;
                }

                SelectKmuVsDto vs = vss.Where(c => c.code == dto.CorchID).FirstOrDefault();
                if (vs != null)
                {
                    dto.UnitStr = vs.name;
                }

            }

            return list.OrderBy(c => c.DateFrom).ThenBy(c => c.RoundCode).ToList();
            
        }

    }


    [Serializable]
    public partial class EduTeamMemberRundownDto
    {
        public virtual string EmpCode { get; set; }
        public virtual string MemberName { get; set; }

        public virtual string CoachName { get; set; }
        public virtual string RName { get; set; }
        public virtual string CRName { get; set; }

        public virtual string RID { get; set; }
        public virtual string CRID { get; set; }

        public virtual DateTime? TeacherCreateDate { get; set; }

        public virtual List<V_KmuEmpDto> Teachers { get; set; }

        public virtual string TeacherNameStr 
        {
            get
            {
                if (Teachers != null)
                {
                    string namestr = "";
                    foreach (V_KmuEmpDto name in Teachers)
                    {
                        namestr += "(" + name.Empcode + ")" + name.Empname + ",";
                    }

                    if (namestr != "")
                    {
                        namestr = namestr.Substring(0, namestr.Length - 1);
                    }

                    return namestr;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public partial class EduTeamMemberDto
    {
        #region Properties

        #endregion Properties
    }

    public partial class EduTeamRundownDto
    {
        public virtual string DateFromToStr { get; set; }
    }

    public partial class EduStopActScheduleDto : BaseDTOEntity, IDtoWithKey
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public virtual string EduActTopicName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string EduActTopicCode { get; set; }

        public virtual string ActTypeName { get; set; }

        public virtual string EduTermName { get; set; }

        public virtual string Url { get; set; }

        public virtual bool HasTarget { get; set; }

        public virtual bool HasAttachment { get; set; }

        public virtual bool BookFull { get; set; }

        public virtual int? BookingID { get; set; }
        #endregion Properties
    }


    public partial class EduActTopicDto
    {
        public virtual string Url { get; set; }
        public virtual string DisplayName 
        {
            get
            {
                return this.EduActTopicCode + " - " + this.EduActTopicName;
            }
        }
    }

    public partial class AutoEduFormTemplateListDto
    {
        public virtual bool IsSend { get; set; }
        public virtual string JobName { get; set; }
        public virtual string TemplateName { get; set; }
        public virtual string ShiftStr 
        {
            get
            {
                return "課程" + this.DateShiftType.Replace("after", "開始後").Replace("before", "結束前") + this.DateShift.Value.ToString() + "天發送";
            }
        
        }
        public virtual string SendFloorStr {
            get
            {
                if (this.SendFloor == null)
                {
                    return "全部";
                }
                else
                {
                    return this.SendFloor.ToString();
                }
            }
        }
    }

    public partial class JobFormSettingDto
    {
        public virtual string JobName { get; set; }
        public virtual string TemplateName { get; set; }
    }

    [Serializable]
    public partial class ToDoListDto
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        /// 

        public virtual int INSTANCE_ID { get; set; }
        public virtual int TemplateID { get; set; }

        public virtual string TemplateName { get; set; }

        public virtual string EduTermID { get; set; }

        public virtual string EduTermName { get; set; }

        public virtual string DeptName { get; set; }

        public virtual DateTime BeginTime { get; set; }

        public virtual DateTime? EndTime { get; set; }

        public virtual string DateStr { get; set; }

        public virtual string ActionName { get; set; }

        public virtual string ActionUrl { get; set; }

        public virtual string ExTargetID { get; set; }

        public virtual string ExTargetName { get; set; }

        public virtual string EvalTargetID { get; set; }

        public virtual string EvalTargetName { get; set; }

        public virtual string NextTargetID { get; set; }
        
        public virtual string NextTargetName { get; set; }

        public virtual double? FinalScore { get; set; }

        public virtual string HaveRead { get; set; } //已讀狀態

        public virtual bool IsExecuted { get; set; } 

        #endregion Properties
    }

    [Serializable]
    public partial class FormTargetSetting
    {
        public virtual bool IsChecked { get; set; }
        public virtual string SettingCode { get; set; }
        public virtual string SettingName { get; set; }
        public virtual string Group { get; set; }
        public virtual int TemplateID { get; set; }
        public virtual DateTime? ExpireDate { get; set; }
        public virtual string UserDefineTargetID { get; set; }
        public virtual int? ExpireDays { get; set; }
        public virtual string ExpireDaysType { get; set; }
    }

    [Serializable]
    public partial class EduFormTemplateListDto
    {
        public virtual string CreaterName { get; set; }
        public virtual string TEMPLATE_NAME { get; set; }
        public virtual int AllFormCount { get; set; }
        public virtual int NotFinishCount { get; set; }
        public virtual int FinishCount { get; set; }
        public virtual int ExpireFinishCount { get;set; }
        public virtual int ExpireNotFinishCount { get;set; }
        public virtual int TFinishCount { get; set; }
        public virtual int SFinishCount { get; set; }
        public virtual int TAllCount { get; set; }
        public virtual int SAllCount { get; set; }

        public virtual int TAllCount2 { get; set; }
        public virtual int SAllCount2 { get; set; }


        public virtual List<string> FTListIDs { get; set; }
        public string FinishRateStr
        {
            get
            {
                string str = (FinishCount + ExpireFinishCount).ToString() + "/" + AllFormCount.ToString();
                if (AllFormCount != 0)
                {
                    str += " (" + ((Convert.ToDouble(FinishCount + ExpireFinishCount) / Convert.ToDouble(AllFormCount)) * 100.0).ToString("0.00") + "%)";
                }
                else
                {
                    str += " (--%)";
                }
                return str;
            }
        }

        public string TFinishRateStr
        {
            get
            {
                string str = (TFinishCount).ToString() + "/" + TAllCount.ToString();
                if (TAllCount != 0)
                {
                    str += " (" + ((Convert.ToDouble(TFinishCount) / Convert.ToDouble(TAllCount)) * 100.0).ToString("0.00") + "%)";
                }
                else
                {
                    str += " (--%)";
                }
                return str;
            }
        }
        public string SFinishRateStr
        {
            get
            {
                string str = (SFinishCount).ToString() + "/" + SAllCount.ToString();
                if (SAllCount != 0)
                {
                    str += " (" + ((Convert.ToDouble(SFinishCount) / Convert.ToDouble(SAllCount)) * 100.0).ToString("0.00") + "%)";
                }
                else
                {
                    str += " (--%)";
                }
                return str;
            }
        }

        public string TFinishRateStr2
        {
            get
            {
                string str = (TFinishCount).ToString() + "/" + TAllCount2.ToString();
                if (TAllCount2 != 0)
                {
                    str += " (" + ((Convert.ToDouble(TFinishCount) / Convert.ToDouble(TAllCount2)) * 100.0).ToString("0.00") + "%)";
                }
                else
                {
                    str += " (--%)";
                }
                return str;
            }
        }
        public string SFinishRateStr2
        {
            get
            {
                string str = (SFinishCount).ToString() + "/" + SAllCount2.ToString();
                if (SAllCount2 != 0)
                {
                    str += " (" + ((Convert.ToDouble(SFinishCount) / Convert.ToDouble(SAllCount2)) * 100.0).ToString("0.00") + "%)";
                }
                else
                {
                    str += " (--%)";
                }
                return str;
            }
        }


        public int ExpireAllCount 
        { 
            get
            {
                return ExpireFinishCount + ExpireNotFinishCount;
            }
        }

        public string ExpireFinishRateStr
        {
            get
            {
                string str = (ExpireFinishCount).ToString() + "/" + ExpireAllCount.ToString();
                if (AllFormCount != 0)
                {
                    str += " (" + ((Convert.ToDouble(ExpireFinishCount) / Convert.ToDouble(ExpireAllCount)) * 100.0).ToString("0.00") + "%)";
                }
                else
                {
                    str += " (--%)";
                }
                return str;
            }
        }


        public string CompleteDetailUrl
        {
            get
            {
                return "FormCompleteDetail.aspx?edutermid=" + this.RootEduTermID + "&templateid=" + this.TEMPLATE_ID.ToString();
            }
        }

        public string EduTermDetailUrl
        {
            get
            {
                return "EduStatisticView.aspx?edutermid=" + this.RootEduTermID;
            }
        }

        public virtual string RootEduTermID
        {
            get;
            set;
        }

        public virtual string RootEduTermName
        {
            get;
            set;
        }

        public virtual List<string> StasticPermissionRoles
        {
            get;
            set;
        }
    }
    [Serializable]
    public partial class EduActTargetDto
    {
        public virtual string TargetName { get; set; }
        public virtual string TargetTypeName { get; set; }
        public virtual string RoleName { get; set; }
        public virtual string TimeRangeStr
        {
            get
            {
                if (this.TimeFrom != null && this.TimeTo != null)
                {
                    return this.TimeFrom.ToString("HH:mm") + "~" + this.TimeTo.ToString("HH:mm");
                }
                else
                {
                    return "";
                }
            } 
        }
        public virtual string TargetJobName { get; set; }
    }


    public partial class EduActViewTargetDto
    {
        public virtual string TargetName { get; set; }
        public virtual string TargetTypeName { get; set; }
        public virtual string RoleName { get; set; }
        public virtual string TimeRangeStr
        {
            get
            {
                if (this.TimeFrom != null && this.TimeTo != null)
                {
                    return this.TimeFrom.Value.ToString("HH:mm") + "~" + this.TimeTo.Value.ToString("HH:mm");
                }
                else
                {
                    return "";
                }
            }
        }
    }

    [Serializable]
    public partial class EduStopActAttachmentDto
    {
        public virtual string FileName { get; set; }
    }

    //課程總表
    public class CourseReportDto
    {
        public virtual string ParentCourseName { get; set; }
        public virtual string ParentDateStr { get; set; }
        public virtual string ChildCourseName { get; set; }
        public virtual string ChildDateStr { get; set; }
        public virtual string MemberList { get; set; }
        
    }

    //完成明細資訊
    public class FORM_COMPLETE_STATUS
    {
        public virtual string emp_code { get; set; }
        public virtual string emp_name { get; set; }
        public virtual string statusname { get; set; }
    }


    //展開統計資料清單
    public class STATISTIC_EXPEND_DATA_LIST
    {
        public int InstanceID
        {
            get;
            set;
        }

        public DateTime CreateDate
        {
            get;
            set;
        }

        public string DeptCode
        {
            get;
            set;
        }
        public string DeptName
        {
            get;
            set;
        }
        public string TargetID
        {
            get;
            set;
        }

        public string TargetName
        {
            get;
            set;
        }

        public string TargetType
        {
            get;
            set;
        }

        public string EvalTargetID
        {
            get;
            set;
        }

        public string EvalTargetName
        {
            get;
            set;
        }
        public string EvalTargetMemberCode
        {
            get;
            set;
        }
        public string TargetMemberCode
        {
            get;
            set;

        }
        public string TargetCoach
        {
            get;
            set;
        }

        public string GroupName
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string StatusName
        {
            get;
            set;
        }

        public string EduTermTimeRange
        {
            get;
            set;
        }

        public string EduTermFullName
        {
            get;
            set;
        }
        public string HospName
        {
            get;
            set;
        }

        public string SchoolSeq1
        {
            get;
            set;
        }

        public string SchoolSeq2
        {
            get;
            set;
        }

    }

    //表單明細
    public class FORM_DATA
    {
        public virtual int INSTANCE_ID { get; set; }

        public virtual string INSTANCE_NAME { get; set; }

        public virtual string TargetID { get; set; }

        public virtual string TargetName { get; set; }

        public virtual string TargetType { get; set; }

        public virtual string TargetTypeName { get; set; }

        public virtual string EvalTargetID { get; set; }

        public virtual string EvalTargetName { get; set; }

        public virtual string EduTermID { get; set; }

        public virtual string RoundCode { get; set; }

        public virtual string EduTermName { get; set; }

        public virtual string Status { get; set; }

        public virtual int PARENT_INSTANCE_ID { get; set; }

        public virtual string StatusName
        {
            get
            {
                if (Status == "0")
                {
                    if (ExpireDate.HasValue && ExpireDate < DateTime.Now.Date)
                    {
                        return "逾期";
                    }
                    else
                    {
                        return "未完成";
                    }
                }
                else
                {
                    return "已完成";
                }
            }
        }

        public virtual string BeforeFormStatus { get; set; }

        public virtual DateTime? ExpireDate { get; set; }

        public virtual DateTime CreateDate { get; set; }
    }

    public class EduTeacherData
    {
        public virtual string EduTermName { get; set; }
        public virtual EduTermDto EduTerm { get; set; }
        public virtual DataTable TeacherInfo { get; set; }

    }

    [Serializable]
    public class EduStudentData
    {
        public virtual string EduTermID { get; set; }
        public virtual string EduTermName { get; set; }
        public virtual string StudentName { get; set; }
        public virtual string EmpCode { get; set; }
        public virtual string IDNo { get; set; }
        public virtual string MemberCode { get; set; }
        public virtual string UrlText { get { return "i-KASA"; } }
    }


    public class EduStopActMemberList
    {
        public virtual string DepCode
        {
            get;
            set;
        }
        public virtual string DepName
        {
            get;
            set;
        }
        public virtual string HospCode
        {
            get;
            set;
        }
        public virtual string HospName
        {
            get;
            set;
        }

        public virtual string EduStopActScheduleID
        {
            get;
            set;
        }

        public virtual string ActName
        {
            get;
            set;
        }

        public virtual string EmpName
        {
            get;
            set;
        }


        public virtual string EmpCode
        {
            get;
            set;
        }

        public virtual string JobCode
        {
            get;
            set;
        }

        public virtual string JobName
        {
            get;
            set;
        }


        public virtual string RoleID
        {
            get;
            set;
        }


        public virtual string RoleName
        {
            get;
            set;
        }


        public virtual string ActTypeCode
        {
            get;
            set;
        }


        public virtual string ActTypeName
        {
            get;
            set;
        }


        public virtual DateTime Sdate
        {
            get;
            set;
        }


        public virtual DateTime Edate
        {
            get;
            set;
        }


        public virtual double ActTimeCount
        {
            get
            {
                return (Edate - Sdate).TotalHours;
            }
        }

        public virtual string HasAttachment
        {
            get;
            set;
        }


    }


    public class EduStopActList
    {
        public virtual int SerialNo
        {
            get;
            set;
        }
        public virtual string DepCode
        {
            get;
            set;
        }
        public virtual string DepName
        {
            get;
            set;
        }
        public virtual string HospCode
        {
            get;
            set;
        }

        public virtual string EduStopActScheduleID
        {
            get;
            set;
        }

        public virtual string ActName
        {
            get;
            set;
        }

        public virtual string EmpName
        {
            get;
            set;
        }


        public virtual string EmpCode
        {
            get;
            set;
        }

        public virtual string ActTypeCode
        {
            get;
            set;
        }


        public virtual string ActTypeName
        {
            get;
            set;
        }


        public virtual DateTime Sdate
        {
            get;
            set;
        }

        public virtual string SdateStr
        {
            get;
            set;
        }
        public virtual string StimeStr
        {
            get;
            set;
        }


        public virtual DateTime Edate
        {
            get;
            set;
        }
        public virtual string EdateStr
        {
            get;
            set;
        }
        public virtual string EtimeStr
        {
            get;
            set;
        }

        public virtual double ActTimeCount
        {
            get
            {
                return (Edate - Sdate).TotalHours;
            }
        }

        public virtual string HasAttachment
        {
            get;
            set;
        }

        public virtual List<string[]> AttachmentsUrls
        {
            get;
            set;
        }

        public virtual string Location
        {
            get;
            set;
        }

        public virtual string RoleName
        {
            get;
            set;
        }

        public virtual string TeacherName
        {
            get;
            set;
        }
    }


    public class TeachTimeListData
    {


        public virtual string 時數來源
        {
            get;
            set;
        }

        public virtual string 序號
        {
            get;
            set;
        }
        public virtual string 活動名稱
        {
            get;
            set;
        }

        public virtual string 職編
        {
            get;
            set;
        }
        public virtual string 姓名
        {
            get;
            set;
        }
        public virtual string 科別
        {
            get;
            set;
        }
        public virtual string 單位
        {
            get;
            set;
        }

        public virtual string 職稱
        {
            get;
            set;
        }

        public virtual string 學校職稱
        {
            get;
            set;
        }
        public virtual decimal 總時數
        {
            get;
            set;
        }
        public virtual decimal 加權後時數
        {
            get;
            set;
        }

        public virtual string 起訖時間
        {
            get;
            set;
        }
        public virtual string 身分別
        {
            get;
            set;
        }

        public virtual string acttype
        {
            get;
            set;
        }
        public virtual string roleid
        {
            get;
            set;
        }
    }

    public class TeachTimeSumData
    {
        public virtual string 時數來源
        {
            get;
            set;
        }
        public virtual string 職編
        {
            get;
            set;
        }
        public virtual string 姓名
        {
            get;
            set;
        }
        public virtual string 科別
        {
            get;
            set;
        }

        public virtual string 單位
        {
            get;
            set;
        }
        public virtual string 職稱
        {
            get;
            set;
        }

        public virtual string 學校職稱
        {
            get;
            set;
        }

        public virtual decimal 總時數
        {
            get;
            set;
        }
        public virtual decimal 加權後時數
        {
            get;
            set;
        }
    }
    [Serializable]
    public partial class FORM_INSTANCE_ATTACHMENTDto
    {
    }

    [Serializable]
    public partial class EduPassportItemDto
    {
        public virtual string CreaterName
        {
            get;
            set;
        }
        public virtual string ModifierName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class EduPassportItemDetDto
    {

    }

    [Serializable]
    public partial class EduPassportItemTargetDto
    {

    }



    [Serializable]
    public partial class EduPassportTemplateDto
    {
        public virtual string CreaterName
        {
            get;
            set;
        }
        public virtual string ModifierName
        {
            get;
            set;
        }
    }


    [Serializable]
    public partial class EduPassportTemplateTargetDto
    {

    }

    [Serializable]
    public partial class EduPassportTemplateItemDto
    {
        public virtual string ItemName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class EduPassportInstanceDto
    {
        public virtual bool IsGet
        {
            get;
            set;
        }

        public virtual string FinishRate
        {
            get
            {
                if (ItemCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (FinishCount * 100 / ItemCount).ToString("0") + "%";
                }
            }
        }

        public virtual int FinishRateNumber
        {
            get
            {
                if (ItemCount == 0)
                {
                    return 100;
                }
                else
                {
                    return (FinishCount * 100 / ItemCount);
                }
            }
        }

        public virtual string WaitingRate
        {
            get
            {
                if (ItemCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (WaitingCount * 100 / ItemCount).ToString("0") + "%";
                }
            }
        }

        public virtual string NotFinishRate
        {
            get
            {
                if (ItemCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (100 - Convert.ToInt32(WaitingCount * 100 / ItemCount) - Convert.ToInt32(FinishCount * 100 / ItemCount)).ToString("0") + "%";
                    //return (NotFinishCount * 100 / ItemCount).ToString("0") + "%";
                }
            }
        }

        public virtual string NecessaryFinishRate
        {
            get
            {
                if (NecessaryCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (NecessaryFinishCount * 100 / NecessaryCount).ToString("0") + "%";
                }
            }
        }

        public virtual int NecessaryFinishRateNumber
        {
            get
            {
                if (NecessaryCount == 0)
                {
                    return 100;
                }
                else
                {
                    return (NecessaryFinishCount * 100 / NecessaryCount);
                }
            }
        }

        public virtual string NecessaryWaitingRate
        {
            get
            {
                if (NecessaryCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (NecessaryWaitingCount * 100 / NecessaryCount).ToString("0") + "%";
                }
            }
        }

        public virtual string NecessaryNotFinishRate
        {
            get
            {
                if (NecessaryCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (100 - Convert.ToInt32(NecessaryWaitingCount * 100 / NecessaryCount) - Convert.ToInt32(NecessaryFinishCount * 100 / NecessaryCount)).ToString("0") + "%";
                    //return (NecessaryNotFinishCount * 100 / NecessaryCount).ToString("0") + "%";
                }
            }
        }



        public virtual string NonNecessaryFinishRate
        {
            get
            {
                if (NonNecessaryCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (NonNecessaryFinishCount * 100 / NonNecessaryCount).ToString("0") + "%";
                }
            }
        }

        public virtual string NonNecessaryWaitingRate
        {
            get
            {
                if (NonNecessaryCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (NonNecessaryWaitingCount * 100 / NonNecessaryCount).ToString("0") + "%";
                }
            }
        }

        public virtual string NonNecessaryNotFinishRate
        {
            get
            {
                if (NonNecessaryCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (100 - Convert.ToInt32(NonNecessaryWaitingCount * 100 / NonNecessaryCount) - Convert.ToInt32(NonNecessaryFinishCount * 100 / NonNecessaryCount)).ToString("0") + "%";
                    //return (NonNecessaryNotFinishCount * 100 / NonNecessaryCount).ToString("0") + "%";
                }
            }
        }


        public virtual string StudentFinishRate
        {
            get
            {
                if (ItemCount == 0)
                {
                    return "--";
                }
                else
                {
                    return (Convert.ToInt32(StudentFinishCount * 100 / ItemCount)).ToString("0") + "%";
                    //return (NonNecessaryNotFinishCount * 100 / NonNecessaryCount).ToString("0") + "%";
                }
            }

        }

        public virtual int StudentFinishRateNumber
        {
            get
            {
                if (ItemCount == 0)
                {
                    return 100;
                }
                else
                {
                    return (Convert.ToInt32(StudentFinishCount * 100 / ItemCount));
                }
            }

        }

        public virtual string StudentFinishRateStr
        {
            get
            {
                if (ItemCount == 0)
                {
                    return "--";
                }
                else
                {
                    return StudentFinishCount.ToString() + "/" + ItemCount.ToString();
                }
            }

        }



        public virtual string FinishRateStr
        {
            get
            {
                if (ItemCount == 0)
                {
                    return "--";
                }
                else
                {
                    return FinishCount.ToString() + "/" + ItemCount.ToString();
                }
            }
        }



        public virtual string ThreeStepFinishRateStr
        {
            get
            {
                if (ItemCount == 0)
                {
                    return "--";
                }
                else
                {
                    return FinishCount.ToString() + "/" + WaitingCount.ToString() + "/" + NotFinishCount.ToString() + "/" + ItemCount.ToString();
                }
            }
        }


        public virtual string EmpName
        {
            get;
            set;
        }


        public virtual int ItemCount
        {
            get;
            set;
        }

        public virtual int StudentFinishCount
        {
            get;
            set;
        }



        public virtual int NotFinishCount
        {
            get;
            set;
        }

        public virtual int WaitingCount
        {
            get;
            set;
        }

        public virtual int FinishCount
        {
            get;
            set;
        }

        public virtual int NecessaryCount
        {
            get;
            set;
        }

        public virtual int NecessaryNotFinishCount
        {
            get;
            set;
        }

        public virtual int NecessaryWaitingCount
        {
            get;
            set;
        }

        public virtual int NecessaryFinishCount
        {
            get;
            set;
        }


        public virtual int NonNecessaryCount
        {
            get { return ItemCount - NecessaryCount; }
        }

        public virtual int NonNecessaryNotFinishCount
        {
            get { return NotFinishCount - NecessaryNotFinishCount; }
        }

        public virtual int NonNecessaryWaitingCount
        {
            get { return WaitingCount - NecessaryWaitingCount; }
        }

        public virtual int NonNecessaryFinishCount
        {
            get { return FinishCount - NecessaryFinishCount; }
        }



        public virtual string TemplateDesc
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class EduPassportInsItemDto
    {
        public virtual string StudentName
        {
            get;
            set;
        }

        public virtual string TemplateName
        {
            get;
            set;
        }

        public virtual string TeacherName
        {
            get;
            set;
        }
        public virtual string CurrentTeamName
        {
            get;
            set;
        }


        public virtual string StatusName
        {
            get
            {
                switch(this.Status)
                {
                    case "0":
                        return "未送出";
                    case "1":
                        return "等待審核中";
                    case "V":
                        return "已完成";
                    default:
                        return "";
                }
            }
        }

        public virtual string 類別
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class EduPassportInsItemDetDto
    {

    }

    [Serializable]
    public partial class EduTermFormReqDto
    {
        public virtual string ReqName
        {
            get;
            set;
        }

        public virtual string ReqTypeName
        {
            get;
            set;
        }

        public virtual string PassType
        {
            get
            {
                if (this.NeedPass)
                {
                    return "通過";
                }
                else
                {
                    return "完成";
                }
            }
        }

        public int MemberPassCount
        {
            get;
            set;
        }

        public List<FORM_INSTANCEDto> MemberPassForms
        {
            get;
            set;
        }

        public bool MemberIsPass
        {
            get
            {
                if(MemberPassCount >= ReqCount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }

    [Serializable]
    public partial class EduTermFormReqTemplateDto
    {
        public virtual string CreaterName
        {
            get;
            set;
        }

        public virtual string ModifierName
        {
            get;
            set;
        }
    }

    [Serializable]
    public partial class EduTermFormReqTemplateDetDto
    {
        public virtual string ReqName
        {
            get;
            set;
        }

        public virtual string ReqTypeName
        {
            get;
            set;
        }
        public virtual string PassType
        {
            get
            {
                if(this.NeedPass)
                {
                    return "通過";
                }
                else
                {
                    return "完成";
                }
            }
        }
    }


    [Serializable]
    public partial class FormCategoryDto
    {
        public virtual bool IsRel
        {
            get;
            set;
        }

        public virtual string CreaterName
        {
            get;
            set;
        }

    }


    public partial class EduPassportReportMain
    {
        public virtual string HOSPNAME
        {
            get;
            set;
        }

        public virtual string PASSPORTNAME
        {
            get;
            set;
        }

        public virtual string STUDENTNAME
        {
            get;
            set;
        }


        public virtual List<EduPassportReportGroup> REPORTGROUPS
        {
            get;
            set;
        }

        public virtual List<EduPassportReportItem> REPORTITEMS
        {
            get;
            set;
        }
    }

    public partial class EduPassportReportGroup
    {
        public virtual string ITEMGROUPNAME
        {
            get;
            set;
        }

        public virtual List<EduPassportReportItem> REPORTITEMS
        {
            get;
            set;
        }

        
    }

    public partial class EduPassportReportItem
    {
        public virtual string ITEMGROUPNAME
        {
            get;
            set;
        }

        public virtual string COLUMNTITLE
        {
            get;
            set;
        }

        public virtual string ITEMNAME
        {
            get;
            set;
        }

        public virtual string ITEMVALUE
        {
            get;
            set;
        }
    }
    [Serializable]
    public partial class iKASAPersonInfo
    {
        public virtual string empcode
        {
            get;
            set;
        }

        public virtual string membercode
        {
            get;
            set;
        }

        public virtual string memberid
        {
            get;
            set;
        }
        public virtual string membertype
        {
            get;
            set;
        }
        public virtual string membertypename
        {
            get;
            set;
        }

        public virtual DateTime dateform
        {
            get;
            set;
        }

        public virtual DateTime dateto
        {
            get;
            set;
        }

        public virtual string daterange
        {
            get
            {
                return dateform.ToString("yyyy/MM/dd") + "~" + dateto.ToString("yyyy/MM/dd");
            }
        }

        public virtual string teamcode
        {
            get;
            set;
        }

        public virtual List<string> allteamcodes
        {
            get;
            set;
        }

        public virtual string teamname
        {
            get;
            set;
        }

        public virtual string topteamcode
        {
            get;
            set;
        }



    }
    [Serializable]
    public partial class IKASA_OSCEExamStageDto
    {
    }


    [Serializable]
    public partial class IKASA_OSCEExamDto
    {
        public string HospName { get; set; }
        public string QEmpCode { get; set; }
        public string QEmpName { get; set; }
        public string QExamIdno { get; set; }
        public decimal QTotalScore { get; set; }
        public decimal QScoreRate { get; set; }
        public int QPassStageCount { get; set; }
        public string QScoreLevel { get; set; }
    }

    [Serializable]
    public partial class IKASA_OSCEExamScoreDto
    {
        public string StageName { get; set; }
        public decimal PassScore { get; set; }
        public string ScoreLevel { get; set; }
        public string TotalScoreLevel { get; set; }
        public int Rank { get; set; }
        public int TotalRank { get; set; }
        public string IsPassStr
        {
            get
            {
                if (this.IsPass)
                {
                    return "通過";
                }
                else
                {
                    return "未通過";
                }
            }

        }
        public bool IsPass { get; set; }
    }

    [Serializable]
    public partial class IKASA_ERExamStageDto
    {
    }


    [Serializable]
    public partial class IKASA_ERExamDto
    {
        public string HospName { get; set; }
        public string QEmpCode { get; set; }
        public string QEmpName { get; set; }
        public string QExamIdno { get; set; }
        public decimal QTotalScore { get; set; }
        public decimal QScoreRate { get; set; }
        public int QPassStageCount { get; set; }
        public string QScoreLevel { get; set; }
    }

    [Serializable]
    public partial class IKASA_ERExamScoreDto
    {
        public string StageName { get; set; }
        public decimal PassScore { get; set; }
        public string ScoreLevel { get; set; }
        public string TotalScoreLevel { get; set; }
        public int Rank { get; set; }
        public int TotalRank { get; set; }
        public string IsPassStr
        {
            get
            {
                if (this.IsPass)
                {
                    return "通過";
                }
                else
                {
                    return "未通過";
                }
            }

        }
        public bool IsPass { get; set; }
    }


    [Serializable]
    public partial class IPDNoteObject
    {
        public string SERIALNO { get; set; }
        public string CHARTNO { get; set; }
        public DateTime NOTE_DATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string NOTE_DATA { get; set; }
        public string DEPT_CODE { get; set; }
        public string DEPT_NAME { get; set; }

    }


    [Serializable]
    public partial class ERMemsObject
    {
        public string SERIALNO { get; set; }
        public string CHART_NO { get; set; }
        public int ENTER_DATE { get; set; }
        public string noon_no { get; set; }
        public string DEPT_NAME { get; set; }
        public string PATIENT_NAME { get; set; }
        public string DISEASE_CLASS { get; set; }
        public string icd_code { get; set; }
        public string chinese_name { get; set; }
        public string DEPT_CODE { get; set; }


    }


}

