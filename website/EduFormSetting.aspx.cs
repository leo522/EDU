using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

public partial class EduFormSetting : AuthPage
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    private string EduTermID
    {
        get
        {
            return Request.QueryString["EduTermID"];
        }
    }

    private EduFormTemplateListDto QueryTemplateList
    {
        get
        {
            return ViewState["QueryTemplateList"] as EduFormTemplateListDto;
        }
        set
        {
            ViewState["QueryTemplateList"] = value;
        }
    }

    private EduTermDto CurrentEduTerm
    {
        get
        {
            return ViewState["EduFormSettingCurrentEduTerm"] as EduTermDto;
        }
        set
        {
            ViewState["EduFormSettingCurrentEduTerm"] = value;
        }
    }

    private List<FORM_TEMPLATEDto> CurrentTemplateList
    {
        get
        {
            return ViewState["FormSettingTemplateList"] as List<FORM_TEMPLATEDto>;
        }
        set
        {
            ViewState["FormSettingTemplateList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        TreeViewComboBox2.SelectedChanged += new EventHandler(TreeViewComboBox2_SelectedChanged);

        
        if (!IsPostBack)
        {
            LoadEduTerm();
            BindTeacherType();
            ReloadList();
            ClearFields();

            ReadAutoFtListSetting();
            RadGrid2.DataBind();
        }
        //AddPostbackControl(RadTreeView1);
    }

    private void ReadAutoFtListSetting()
    {
        RadGrid2.DataSource = null;
        RadGrid2.MasterTableView.DataKeyNames = new string[] { "AutoFTListID" };
        List<AutoEduFormTemplateListDto> list = service.GetAutoEduFormTemplateLists(CurrentEduTerm);
        RadGrid2.DataSource = list;
    }

    private void LoadEduTerm()
    {
        EduTermDto dto = service.ReadEduTermById(EduTermID);
        CurrentEduTerm = dto;
        
        TreeViewComboBox2.SelectedValue = dto.JobCode;

        TreeViewComboBox2.SelectedText = service.GetCodeRefs("EduAct_JobSerial").Where(c => c.Code == dto.JobCode).FirstOrDefault().Name;

    }

    protected void TreeViewComboBox2_SelectedChanged(object sender, EventArgs e)
    {
        ReloadList();
        ClearFields();
        RefreshRoleSetting();
        RadGrid1.DataBind();

        //RefreshHistory();
        //rgHistory.DataBind();

        ReadExpireData();
        rgExpireData.DataBind();

        btnPreview.NavigateUrl = "";
    }

    private void BindTeacherType()
    {
        List<EduTeacherTypeDto> list = service.GetTeacherTypes();
        ddlTeacherType.DataValueField = "code";
        ddlTeacherType.DataTextField = "name";
        ddlTeacherType.DataSource = list;
        ddlTeacherType.DataBind();
        ddlTeacherType.SelectedIndex = 0;

        EduTeacherTypeDto newitem = new EduTeacherTypeDto();
        newitem.Code = "S";
        newitem.Name = "學員";
        list.Add(newitem);

        ddlSendType.DataValueField = "code";
        ddlSendType.DataTextField = "name";
        ddlSendType.DataSource = list;
        ddlSendType.DataBind();
        ddlSendType.SelectedIndex = 0;
    }

    protected void ReloadList()
    {
        //BSC固定用EduActivity分類
        List<FORM_TEMPLATEDto> list = service.GetFormTemplatesByJobCode(TreeViewComboBox2.SelectedValue, this.HospCode);
            //vc.ListFormTemplatesByCategory("EduActivity").OrderByDescending(c => c.TEMPLATE_NAME).ToList();

        CurrentTemplateList = list;
        RadTreeView1.Nodes.Clear();
        RadTreeView1.DataSource = null;


        RadTreeView1.DataSource = list;

        RadTreeView1.DataBind();

        //RadTreeView1.ExpandAllNodes();
    }

    private List<FormTargetSetting> CurrentSetting
    {
        get
        {
            return ViewState["CurrentSetting"] as List<FormTargetSetting>;
        }
        set
        {
            ViewState["CurrentSetting"] = value;
        }
    }

    private void ClearFields()
    {
        QueryTemplateList = null;
        tbName.Text = "";
        rdpExecuteDate.MinDate = DateTime.Now.AddDays(1).Date;
        rdpExecuteDate.SelectedDate = null;
        rbNone.Checked = true;
        rntbDay.Value = null;
        cb1.Checked = false;
        cb2.Checked = false;
        cb3.Checked = false;
        cb4.Checked = false;
        cb5.Checked = false;
        cb6.Checked = false;
        cb7.Checked = false;
        ddlweek.SelectedIndex = 0;
        ddlspecweekday.SelectedIndex = 0;
        CurrentSetting = new List<FormTargetSetting>();
        RadGrid1.DataSource = null;
        RadGrid1.DataBind();
    }

    protected void RadTreeView1_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        ClearFields();
        RefreshRoleSetting();
        RadGrid1.DataBind();

        //RefreshHistory();
        //rgHistory.DataBind();

        ReadExpireData();
        rgExpireData.DataBind();

        btnSubmit.Visible = true;
        btnSave.Visible = false;

        btnPreview.NavigateUrl = "EduFormPreview.aspx?template_id=" + e.Node.Value;
    }


    private bool CheckInput()
    {
        if (rbSetDate.Checked && rdpExecuteDate.SelectedDate == null)
        {
            ShowMessage("未輸入執行日期!");
            return false;
        }

        if (rbMonth.Checked && rntbDay.Value == null)
        {
            ShowMessage("未設定每月日期");
            return false;
        }

        if (rbWeek.Checked && (!cb1.Checked && !cb2.Checked && !cb3.Checked && !cb4.Checked && !cb5.Checked && !cb6.Checked && !cb7.Checked))
        {
            ShowMessage("未選擇星期");
            return false;
        }

        if (CurrentSetting == null || CurrentSetting.Count == 0)
        {
            ShowMessage("未設定發送對象");
            return false;
        }


        if (CurrentParentNode.Nodes.Count == 0 && RadGrid1.SelectedItems.Count == 0)
        {
            ShowMessage("未選擇發送對象");
            return false;
        }

        if (CurrentParentNode.Nodes.Count > 0 && CurrentSetting.Count != CurrentParentNode.Nodes.Count)
        {
            ShowMessage("設定發送對象數與子表單數不符");
            return false;
        }

        return true;
    }


//    private void SetTeacherSql(string teachertype, ref string teachersqlsingle, ref string teachersqlmulti, string udteacherid)
//    {

//        switch (teachertype)
//        {
//            case "DeptTeacher":
//            case "EBM":
//            case "CR":
//            case "R":
//                if (cbEach.Checked)
//                {
//                    teachersqlsingle = @"select TeacherID,a.MemberID from EduTeamMemberRundown a inner join EduRefTeachers b on a.EduTermID = b.EduTermID 
//                                    and TeacherType = '" + teachertype + @"' and RefTable='EduTerm'
//                                    where b.EduTermID = '" + EduTermID + @"'";
//                    if (udteacherid != null)
//                    {
//                        teachersqlsingle = teachersqlsingle.Replace("TeacherID", "'" + udteacherid + "' as TeacherID");
//                    }
//                }
//                else
//                {
//                    teachersqlsingle = @"select distinct TeacherID,null
//                                    from EduRefTeachers
//                                    where TeacherType = '" + teachertype + "' and RefTable='EduTerm' and EduTermID = '" + EduTermID + @"'";
//                    if (udteacherid != null)
//                    {
//                        teachersqlsingle = teachersqlsingle.Replace("TeacherID", "'" + udteacherid + "' as TeacherID");
//                    }
//                }
//                teachersqlmulti = @"select distinct TeacherID
//                                    from EduRefTeachers
//                                    where TeacherType = '" + teachertype + "' and RefTable='EduTerm' and EduTermID = '" + EduTermID + @"'";
//                if (udteacherid != null)
//                {
//                    teachersqlmulti = teachersqlmulti.Replace("TeacherID", "'" + udteacherid + "' as TeacherID");
//                }
//                break;
//            case "VS":
//            case "Coach":
//                if (cbEach.Checked)
//                {

//                    teachersqlsingle = @"select TeacherID ,refid as MemberID from EduRefTeachers 
//                                    where TeacherType = '" + teachertype + "' and RefTable='EduTeamMemberRundown' and EduTermID = '" + EduTermID + @"'";
//                    if (udteacherid != null)
//                    {
//                        teachersqlsingle = teachersqlsingle.Replace("TeacherID", "'" + udteacherid + "' as TeacherID");
//                    }
//                }
//                else
//                {
//                    teachersqlsingle = @"select distinct TeacherID ,null from EduRefTeachers 
//                                    where TeacherType = '" + teachertype + "' and RefTable='EduTeamMemberRundown' and EduTermID = '" + EduTermID + @"'";
//                    if (udteacherid != null)
//                    {
//                        teachersqlsingle = teachersqlsingle.Replace("TeacherID", "'" + udteacherid + "' as TeacherID");
//                    }
//                }
//                teachersqlmulti = @"select max(TeacherID)
//                                    from EduRefTeachers 
//                                    where TeacherType = '" + teachertype + "' and RefTable='EduTeamMemberRundown' and edutermid='" + EduTermID + @"' and refid = (select max(a.MemberID) from [Member] a inner join EduTeamMemberRundown b on a.MemberID = b.MemberID
//                                    where a.isHospMember = @id and b.EduTermID = '" + EduTermID + "') ";
//                if (udteacherid != null)
//                {
//                    teachersqlmulti = "select '" + udteacherid + "'";
//                }
//                break;
//            case "xxx":

//                break;
//        }
//    }

//    private void SetTeacherSqlMultiTarget(string teachertype, ref string teachersqlsingle, string udid)
//    {
//        string teacherstr = "";
//        if (udid != null)
//        {
//            teacherstr = " distinct '" + udid + "' as TeacherID ";
//        }
//        else
//        {
//            teacherstr = " TeacherID ";
//        }

//        switch (teachertype)
//        {
//            case "DeptTeacher":
//            case "EBM":
//            case "CR":
//            case "R":
//                if (teachersqlsingle != "")
//                {
//                    teachersqlsingle += " union all ";
//                }

//                if (udid != null)
//                {
//                    teachersqlsingle += @"
//select distinct '" + udid + @"' as TeacherID
//  ,@instanceid as InstanceID
//  ,0 as TargetOrder
//  ,'0' as Status
//  ,'" + teachertype + @"' as TargetType
//";
//                }
//                else
//                {
//                    teachersqlsingle += @"
//select TeacherID
//  ,@instanceid as InstanceID
//  ,0 as TargetOrder
//  ,'0' as Status
//  ,'" + teachertype + @"' as TargetType
//
//from
//edurefteachers
//where edutermid='" + EduTermID + @"'
//and refid ='" + EduTermID + @"'
//and RefTable='EduTerm'
//and TeacherType = '" + teachertype + @"'
//";
//                }


//                break;
//            case "VS":
//            case "Coach":

//                if (teachersqlsingle != "")
//                {
//                    teachersqlsingle += " union all ";
//                }

//                if (udid != null)
//                {
//                    teachersqlsingle += @"
//select distinct '" + udid + @"' as TeacherID
//  ,@instanceid as InstanceID
//  ,0 as TargetOrder
//  ,'0' as Status
//  ,'" + teachertype + @"' as TargetType
//
//";
//                }
//                else
//                {
//                    teachersqlsingle += @"
//select TeacherID
//  ,@instanceid as InstanceID
//  ,0 as TargetOrder
//  ,'0' as Status
//  ,'" + teachertype + @"' as TargetType
//
//from
//edurefteachers
//where edutermid='" + EduTermID + @"'
//and refid = @idstudent
//and RefTable='EduTeamMemberRundown'
//and TeacherType = '" + teachertype + @"'
//";
//                }



//                break;
//        }
//    }


//    private string GenerateSql(string listid)
//    {


//        //用inhospid存edutermid
//        string tempparentsql = "";
//        string sql = @"
//BEGIN TRY
//BEGIN TRANSACTION
//declare @id varchar(20)
//declare @instanceid int
//";

//        string teachersqlmulti = "";
//        string teachersqlsingle = "";
//        string parentidstr = "";

//        if (palSettingFix.Visible)
//        {
//            #region 一般處理
//            string udteacherid = null;
//            foreach (GridDataItem item in RadGrid1.SelectedItems)
//            {
//                FormTargetSetting setting = CurrentSetting[item.DataSetIndex];
//                if (setting.SettingCode == "T")
//                {
//                    if ((item.FindControl("tbUDTarget") as TextBox).Text.Trim() != "")
//                    {
//                        udteacherid = (item.FindControl("tbUDTarget") as TextBox).Text.Trim();
//                    }
//                }
//            }


//            SetTeacherSql(ddlTeacherType.SelectedValue, ref teachersqlsingle, ref teachersqlmulti, udteacherid);

//            #region 單筆
//            //單筆
//            if (CurrentParentNode.Nodes.Count == 0)
//            {
//                //沒有parent
//                parentidstr = "null";

//                foreach (GridDataItem item in RadGrid1.SelectedItems)
//                {
//                    FormTargetSetting setting = CurrentSetting[item.DataSetIndex];
//                    #region 老師
//                    if (setting.SettingCode == "T") //教師
//                    {
//                        sql += @"
//declare @idstudent varchar(20)
//declare cur cursor local for " + teachersqlsingle
//    + @"open cur
//
//fetch next from cur into @id,@idstudent
//while(@@fetch_status <>-1)
//begin
//insert into FORM_INSTANCES (
//   TEMPLATE_ID
//  ,INSTANCE_NAME
//  ,INSTANCE_CREATE_DATETIME
//  ,INSTANCE_ALTER_DATETIME
//  ,INSTANCE_REMARK
//  ,INSTANCE_CONTENT
//  ,INHOSPID
//  ,CREATER
//  ,expireDate
//  ,TargetType
//  ,TargetID
//  ,Status
//  ,PARENT_INSTANCE_ID
//  ,EvalTargetID
//)
//(select 
//  TEMPLATE_ID as TEMPLATE_ID
//  ,TEMPLATE_NAME as INSTANCE_NAME
//  ,getdate() as INSTANCE_CREATE_DATETIME
//  ,null as INSTANCE_ALTER_DATETIME
//  ,'" + listid + @"' as INSTANCE_REMARK
//  ,TEMPLATE_CONTENT as INSTANCE_CONTENT
//  ,'" + EduTermID + @"' as INHOSPID
//  ,'" + this.EmpCode + @"' as CREATER
//  ," + (setting.ExpireDate.HasValue ? "'" + setting.ExpireDate.Value.ToString("yyyy/MM/dd") + "'" : "null") + @" as expireDate
//  ,'Teacher' as TargetType
//  ,@id as TargetID
//  ,'0' as Status
//  ," + parentidstr + @" as PARENT_INSTANCE_ID
//  ,@idstudent
//from FORM_TEMPLATES
//where TEMPLATE_ID = " + setting.TemplateID.ToString() + @")
//
//select @instanceid = max(scope_identity())
//
//insert into FORM_INSTANCE_TARGETS (
//   TargetID
//  ,INSTANCE_ID
//  ,TargetOrder
//  ,Status
//  ,TargetType
//) values (
//   @id
//  ,@instanceid
//  ,0
//  ,'0'
//  ,'Teacher')
//
//fetch next from cur into @id,@idstudent
//end
//close cur
//deallocate cur
//";
//                    }
//                    #endregion

//                    #region 學生
//                    else if (setting.SettingCode == "S") //學生
//                    {
//                        string studentfield = "";
//                        if ((item.FindControl("tbUDTarget") as TextBox).Text.Trim() != "")
//                        {
//                            studentfield = " distinct '"+ (item.FindControl("tbUDTarget") as TextBox).Text.Trim() + "' as ishospmember";
//                        }
//                        else
//                        {
//                            studentfield = "d.ishospmember";
//                        }
                        
                        

//                        sql += @"
//declare cur cursor local for 
//select " + studentfield + @" from EduTeamMember a 
//inner join eduteammemberrundown b 
//on a.EduTeamMemberID = b.EduTeamMemberID
//inner join eduterm c on b.EduTermID = c.EduTermID
//inner join member d on a.membercode = d.membercode
//where c.EduTermID = '" + EduTermID + @"'
//
//open cur
//
//fetch next from cur into @id
//while(@@fetch_status <>-1)
//begin
//insert into FORM_INSTANCES (
//   TEMPLATE_ID
//  ,INSTANCE_NAME
//  ,INSTANCE_CREATE_DATETIME
//  ,INSTANCE_ALTER_DATETIME
//  ,INSTANCE_REMARK
//  ,INSTANCE_CONTENT
//  ,INHOSPID
//  ,CREATER
//  ,expireDate
//  ,TargetType
//  ,TargetID
//  ,Status
//  ,PARENT_INSTANCE_ID
//)
//(select 
//  TEMPLATE_ID as TEMPLATE_ID
//  ,TEMPLATE_NAME as INSTANCE_NAME
//  ,getdate() as INSTANCE_CREATE_DATETIME
//  ,null as INSTANCE_ALTER_DATETIME
//  ,'" + listid + @"' as INSTANCE_REMARK
//  ,TEMPLATE_CONTENT as INSTANCE_CONTENT
//  ,'" + EduTermID + @"' as INHOSPID
//  ,'" + this.EmpCode + @"' as CREATER
//  ," + (setting.ExpireDate.HasValue ? "'" + setting.ExpireDate.Value.ToString("yyyy/MM/dd") + "'" : "null") + @" as expireDate
//  ,'Member' as TargetType
//  ,@id as TargetID
//  ,'0' as Status
//  ," + parentidstr + @" as PARENT_INSTANCE_ID
//from FORM_TEMPLATES
//where TEMPLATE_ID = " + setting.TemplateID.ToString() + @")
//
//select @instanceid = max(scope_identity())
//
//insert into FORM_INSTANCE_TARGETS (
//   TargetID
//  ,INSTANCE_ID
//  ,TargetOrder
//  ,Status
//  ,TargetType
//) values (
//   @id
//  ,@instanceid
//  ,0
//  ,'0'
//  ,'Member')
//
//
//fetch next from cur into @id
//end
//close cur
//deallocate cur
//";
//                    }
//                    #endregion
//                }

//            }
//            #endregion
//            #region 多筆
//            //多筆
//            else
//            {
//                #region 新增頭
//                parentidstr = "@parentid";

//                //insert parent
//                tempparentsql += @"
//insert into FORM_INSTANCES (
//   TEMPLATE_ID
//  ,INSTANCE_NAME
//  ,INSTANCE_CREATE_DATETIME
//  ,INSTANCE_ALTER_DATETIME
//  ,INSTANCE_REMARK
//  ,INSTANCE_CONTENT
//  ,INHOSPID
//  ,CREATER
//  ,expireDate
//  ,TargetType
//  ,TargetID
//  ,Status
//  ,PARENT_INSTANCE_ID
//)
//(select 
//  TEMPLATE_ID as TEMPLATE_ID
//  ,TEMPLATE_NAME as INSTANCE_NAME
//  ,getdate() as INSTANCE_CREATE_DATETIME
//  ,null as INSTANCE_ALTER_DATETIME
//  ,'" + listid + @"' as INSTANCE_REMARK
//  ,'' as INSTANCE_CONTENT
//  ,'" + EduTermID + @"' as INHOSPID
//  ,'" + this.EmpCode + @"' as CREATER
//  ,null as expireDate
//  ,null as TargetType
//  ,null as TargetID
//  ,'0' as Status
//  ,null as PARENT_INSTANCE_ID
//from FORM_TEMPLATES
//where TEMPLATE_ID = " + CurrentParentNode.Value + @");
//
//select @parentid = max(scope_identity())
//
//";

//                //parent id
//                sql += @"
//declare @parentid int
//";
//                #endregion

//                FormTargetSetting setting = CurrentSetting.Where(c => c.SettingCode == "S").FirstOrDefault();
//                FormTargetSetting settingt = CurrentSetting.Where(c => c.SettingCode == "T").FirstOrDefault();

//                string studentfield = "";

//                foreach (GridDataItem item in RadGrid1.Items)
//                {
//                    if (CurrentSetting[item.DataSetIndex].SettingCode == "S")
//                    {
//                        if ((item.FindControl("tbUDTarget") as TextBox).Text.Trim() != "")
//                        {
//                            studentfield = " distinct '" + (item.FindControl("tbUDTarget") as TextBox).Text.Trim() + "' as inhospmember";
//                        }
//                        else
//                        {
//                            studentfield = "d.ishospmember";
//                        }
//                    }

//                    if (CurrentSetting[item.DataSetIndex].SettingCode == "T")
//                    {
//                        if ((item.FindControl("tbUDTarget") as TextBox).Text.Trim() != "")
//                        {
//                            teachersqlmulti = teachersqlmulti.Replace("TeacherID", "'" + (item.FindControl("tbUDTarget") as TextBox).Text.Trim() + "'");
//                        }
//                    }
//                }

//                sql += @"
//declare cur cursor local for 
//select " + studentfield + @" from EduTeamMember a 
//inner join eduteammemberrundown b on a.EduTeamMemberID = b.EduTeamMemberID
//inner join eduterm c on b.EduTermID = c.EduTermID
//inner join member d on a.membercode = d.membercode
//where c.EduTermID = '" + EduTermID + @"'
//
//open cur
//
//fetch next from cur into @id
//while(@@fetch_status <>-1)
//begin";

//                sql += tempparentsql;
//                #region 學生
//                //新增學生
//                sql += @"
//insert into FORM_INSTANCES (
//   TEMPLATE_ID
//  ,INSTANCE_NAME
//  ,INSTANCE_CREATE_DATETIME
//  ,INSTANCE_ALTER_DATETIME
//  ,INSTANCE_REMARK
//  ,INSTANCE_CONTENT
//  ,INHOSPID
//  ,CREATER
//  ,expireDate
//  ,TargetType
//  ,TargetID
//  ,Status
//  ,PARENT_INSTANCE_ID
//)
//(select 
//  TEMPLATE_ID as TEMPLATE_ID
//  ,TEMPLATE_NAME as INSTANCE_NAME
//  ,getdate() as INSTANCE_CREATE_DATETIME
//  ,null as INSTANCE_ALTER_DATETIME
//  ,'" + listid + @"' as INSTANCE_REMARK
//  ,TEMPLATE_CONTENT as INSTANCE_CONTENT
//  ,'" + EduTermID + @"' as INHOSPID
//  ,'" + this.EmpCode + @"' as CREATER
//  ," + (setting.ExpireDate.HasValue ? "'" + setting.ExpireDate.Value.ToString("yyyy/MM/dd") + "'" : "null") + @" as expireDate
//  ,'Member' as TargetType
//  ,@id as TargetID
//  ,'0' as Status
//  ," + parentidstr + @" as PARENT_INSTANCE_ID
//from FORM_TEMPLATES
//where TEMPLATE_ID = " + CurrentParentNode.Nodes[0].Value + @")
//
//select @instanceid = max(scope_identity())
//
//insert into FORM_INSTANCE_TARGETS (
//   TargetID
//  ,INSTANCE_ID
//  ,TargetOrder
//  ,Status
//  ,TargetType
//) values (
//   @id
//  ,@instanceid
//  ,0
//  ,'0'
//  ,'Member')
//
//";
//                #endregion

//                #region 老師

//                //新增老師


//                sql += @"
//insert into FORM_INSTANCES (
//   TEMPLATE_ID
//  ,INSTANCE_NAME
//  ,INSTANCE_CREATE_DATETIME
//  ,INSTANCE_ALTER_DATETIME
//  ,INSTANCE_REMARK
//  ,INSTANCE_CONTENT
//  ,INHOSPID
//  ,CREATER
//  ,expireDate
//  ,TargetType
//  ,TargetID
//  ,Status
//  ,PARENT_INSTANCE_ID
//)
//(select 
//  TEMPLATE_ID as TEMPLATE_ID
//  ,TEMPLATE_NAME as INSTANCE_NAME
//  ,getdate() as INSTANCE_CREATE_DATETIME
//  ,null as INSTANCE_ALTER_DATETIME
//  ,'" + listid + @"' as INSTANCE_REMARK
//  ,TEMPLATE_CONTENT as INSTANCE_CONTENT
//  ,'" + EduTermID + @"' as INHOSPID
//  ,'" + this.EmpCode + @"' as CREATER
//  ," + (settingt.ExpireDate.HasValue ? "'" + settingt.ExpireDate.Value.ToString("yyyy/MM/dd") + "'" : "null") + @" as expireDate
//  ,'Teacher' as TargetType
//  ,(" + teachersqlmulti +
//                @") as TargetID
//  ,'0' as Status
//  ," + parentidstr + @" as PARENT_INSTANCE_ID
//from FORM_TEMPLATES
//where TEMPLATE_ID = " + CurrentParentNode.Nodes[1].Value + @")
//
//select @instanceid = max(scope_identity())
//
//insert into FORM_INSTANCE_TARGETS (
//   TargetID
//  ,INSTANCE_ID
//  ,TargetOrder
//  ,Status
//  ,TargetType
//) values (
//   (" + teachersqlmulti +
//                @")
//  ,@instanceid
//  ,0
//  ,'0'
//  ,'Teacher')
//
//
//";


//                #endregion

//                sql += @"
//fetch next from cur into @id
//end
//close cur
//deallocate cur
//";

//            }
//            #endregion
//            #endregion
//        }
//        else
//        {
//            #region 多target處理
//            //沒有parent
//            parentidstr = "null";

//            DateTime? expiredate = null;
//            string templateID = "";

//            string targetsql = "";

//            foreach (GridDataItem item in RadGrid1.Items)
//            {
//                FormTargetSetting setting = CurrentSetting[item.DataSetIndex];

//                string teacherid = null;
//                if ((item.FindControl("tbUDTarget") as TextBox).Text.Trim() != "")
//                {
//                    teacherid = (item.FindControl("tbUDTarget") as TextBox).Text.Trim();
//                }

//                SetTeacherSqlMultiTarget(setting.SettingCode, ref targetsql, teacherid);

//                expiredate = setting.ExpireDate;
//                templateID = setting.TemplateID.ToString();
//            }


//                sql += @"
//declare @idstudent varchar(20)
//declare cur cursor local for  
//select MemberID from EduTeamMemberRundown where edutermid = '"+EduTermID+@"'
//open cur
//
//fetch next from cur into @idstudent
//while(@@fetch_status <>-1)
//begin
//insert into FORM_INSTANCES (
//   TEMPLATE_ID
//  ,INSTANCE_NAME
//  ,INSTANCE_CREATE_DATETIME
//  ,INSTANCE_ALTER_DATETIME
//  ,INSTANCE_REMARK
//  ,INSTANCE_CONTENT
//  ,INHOSPID
//  ,CREATER
//  ,expireDate
//  ,TargetType
//  ,TargetID
//  ,Status
//  ,PARENT_INSTANCE_ID
//  ,EvalTargetID
//)
//(select 
//  TEMPLATE_ID as TEMPLATE_ID
//  ,TEMPLATE_NAME as INSTANCE_NAME
//  ,getdate() as INSTANCE_CREATE_DATETIME
//  ,null as INSTANCE_ALTER_DATETIME
//  ,'" + listid + @"' as INSTANCE_REMARK
//  ,TEMPLATE_CONTENT as INSTANCE_CONTENT
//  ,'" + EduTermID + @"' as INHOSPID
//  ,'" + this.EmpCode + @"' as CREATER
//  ," + (expiredate.HasValue ? "'" + expiredate.Value.ToString("yyyy/MM/dd") + "'" : "null") + @" as expireDate
//  ,null as TargetType
//  ,null as TargetID
//  ,'0' as Status
//  ," + parentidstr + @" as PARENT_INSTANCE_ID
//  ,@idstudent as EvalTargetID
//from FORM_TEMPLATES
//where TEMPLATE_ID = " + templateID + @")
//
//select @instanceid = max(scope_identity())
//
//insert into FORM_INSTANCE_TARGETS (
//   TargetID
//  ,INSTANCE_ID
//  ,TargetOrder
//  ,Status
//  ,TargetType
//) ("+targetsql+@")
//
//fetch next from cur into @idstudent
//end
//close cur
//deallocate cur
//";
            
//            #endregion
//        }



//        sql += @"
//COMMIT TRANSACTION;
// END TRY
// BEGIN CATCH
// 
// PRINT ERROR_NUMBER();
// PRINT ERROR_MESSAGE();
// ROLLBACK TRANSACTION;
// END CATCH;
//";
//        return sql;
//    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (CurrentParentNode != null)
            {
                if (!CheckInput())
                {
                    System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
                    ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "script" + new Guid().ToString(), "document.getElementById('btnSubmit').style.display='block';", true);
                    return;
                }

                int templateId = Convert.ToInt32(CurrentParentNode.Value);
                string name = CurrentParentNode.Text;
                string listid = service.GetSerialNo("EduAct_EduFTListID");
                EduFormTemplateListDto dto = new EduFormTemplateListDto();
                FORM_TEMPLATEDto temp = CurrentTemplateList.Where(c => c.TEMPLATE_ID == templateId).FirstOrDefault();
                dto.FTListID = listid;
                if (rbSetDate.Checked)
                {
                    dto.ExecuteDate = rdpExecuteDate.SelectedDate.Value;
                }
                else
                {
                    dto.ExecuteDate = DateTime.Now;
                }
                dto.TEMPLATE_ID = templateId;
                dto.EduTermID = EduTermID;
                dto.Name = tbName.Text;
                dto.Creater = this.EmpCode;
                dto.SendOrderSetting = rbSendOrderSetting.SelectedValue;
                dto.UDStudent = tbUDStudent.Text;
                //TempoType 
                //0 : 不重複
                //1 : 每日
                //2 : 每月__日
                //3 : 每星期__
                //4 : 每月第__週星期__

                if (rbNone.Checked)
                {
                    dto.TempoType = "0";
                }
                if (rbDay.Checked)
                {
                    dto.TempoType = "1";
                }
                if (rbMonth.Checked)
                {
                    dto.TempoType = "2";
                    dto.TempoSettings = rntbDay.Value.Value.ToString();
                }
                if (rbWeek.Checked)
                {
                    dto.TempoType = "3";
                    string weekstr = "";
                    if (cb1.Checked)
                    {
                        weekstr += "1,";
                    }
                    if (cb2.Checked)
                    {
                        weekstr += "2,";
                    }
                    if (cb3.Checked)
                    {
                        weekstr += "3,";
                    }
                    if (cb4.Checked)
                    {
                        weekstr += "4,";
                    }
                    if (cb5.Checked)
                    {
                        weekstr += "5,";
                    }
                    if (cb6.Checked)
                    {
                        weekstr += "6,";
                    }
                    if (cb7.Checked)
                    {
                        weekstr += "7,";
                    }
                    dto.TempoSettings = weekstr.Substring(0, weekstr.Length - 1);
                }
                if (rbSpecDay.Checked)
                {
                    dto.TempoType = "4";
                    dto.TempoSettings = ddlweek.SelectedValue;
                    dto.TempoSettings += "," + ddlspecweekday.SelectedValue;
                }
                AutoEduFormTemplateListDto atdto = new AutoEduFormTemplateListDto();
                atdto.Creater = this.EmpCode;
                atdto.MultiTarget = palSettingMultiTarget.Visible;
                atdto.TeacherType = ddlTeacherType.SelectedValue;
                atdto.TEMPLATE_ID = templateId;
                atdto.EachStudent = cbEach.Checked;
                List<AutoEduFormTemplateTargetDto> attdtolist = new List<AutoEduFormTemplateTargetDto>();

                GridItemCollection coll = new GridItemCollection();
                if (palSettingFix.Visible)
                {
                    if (CurrentParentNode.Nodes.Count == 0)
                    {
                        coll = RadGrid1.SelectedItems;
                    }
                    else
                    {
                        coll = RadGrid1.Items;
                    }
                }
                else
                {
                    coll = RadGrid1.Items;
                }
                int settingcount = 0;
                bool hasuserdefinestudent = false;

                foreach (GridDataItem item in coll)
                {
                    FormTargetSetting setting = CurrentSetting[item.DataSetIndex];
                    AutoEduFormTemplateTargetDto tdto = new AutoEduFormTemplateTargetDto();

                    RadDatePicker picker = item.FindControl("rdpExpireDate") as RadDatePicker;
                    TextBox tbtarget = item.FindControl("tbUDTarget") as TextBox;


                    tdto.AutoFTListID = listid;
                    if (picker.SelectedDate.HasValue)
                    {
                        TimeSpan ts = picker.SelectedDate.Value - dto.ExecuteDate;
                        tdto.ExpireDays = Convert.ToInt32(ts.TotalDays);
                        tdto.ExpireDaysType = "AfterSend";
                    }
                    tdto.RoleType = setting.SettingCode;
                    if ((CurrentParentNode.Nodes.Count > 2 || temp.IS_USER_DEFINE_TARGET) && CurrentParentNode.Nodes.Count > 0)
                    {
                        tdto.SubTEMPLATE_ID = Convert.ToInt32(CurrentParentNode.Nodes[settingcount].Value);
                    }
                    else
                    {
                        tdto.SubTEMPLATE_ID = setting.TemplateID;
                    }
                    tdto.UserDefineTargetID = tbtarget.Text.Trim() == "" ? null : tbtarget.Text.Trim();

                    if (setting.SettingCode == "S" && tdto.UserDefineTargetID != null)
                    {
                        hasuserdefinestudent = true;
                    }

                    if (setting.SettingCode == "T")
                    {
                        tdto.TeacherType = ddlTeacherType.SelectedValue;
                    }
                    attdtolist.Add(tdto);
                    settingcount++;
                }

                if (hasuserdefinestudent)
                {
                    dto.EachStudent = false;
                }

                dto.CreateSQL = service.GenerateSql(listid, dto.ExecuteDate, CurrentEduTerm, atdto, attdtolist);//GenerateSql(listid);
                if (rbNow.Checked)
                {
                    dto.Status = 'V';
                }

                List<EduFormTemplateTargetDto> tlist = new List<EduFormTemplateTargetDto>();


                coll = new GridItemCollection();
                if (palSettingFix.Visible)
                {
                    if (CurrentParentNode.Nodes.Count == 0)
                    {
                        coll = RadGrid1.SelectedItems;
                    }
                    else
                    {
                        coll = RadGrid1.Items;
                    }
                }
                else
                {
                    coll = RadGrid1.Items;
                }
                settingcount = 0;
                foreach (GridDataItem item in coll)
                {
                    string targetid = service.GetSerialNo("EduAct_EduFTTargetID");
                    FormTargetSetting setting = CurrentSetting[item.DataSetIndex];
                    EduFormTemplateTargetDto tdto = new EduFormTemplateTargetDto();

                    RadDatePicker picker = item.FindControl("rdpExpireDate") as RadDatePicker;
                    TextBox tbtarget = item.FindControl("tbUDTarget") as TextBox;

                    tdto.FTTargetID = targetid;
                    tdto.FTListID = listid;
                    tdto.ExpireDate = picker.SelectedDate;//setting.ExpireDate;
                    tdto.RoleType = setting.SettingCode;
                    if (CurrentParentNode.Nodes.Count > 2 || temp.IS_USER_DEFINE_TARGET)
                    {
                        tdto.SubTEMPLATE_ID = Convert.ToInt32(CurrentParentNode.Nodes[settingcount].Value);
                    }
                    else
                    {
                        tdto.SubTEMPLATE_ID = setting.TemplateID;
                    }
                    tdto.UserDefineTargetID = tbtarget.Text.Trim() == "" ? null : tbtarget.Text.Trim();
                    if (setting.SettingCode == "T")
                    {
                        tdto.TeacherType = ddlTeacherType.SelectedValue;
                    }
                    tlist.Add(tdto);
                    settingcount++;
                }


                foreach (EduFormTemplateTargetDto tar in tlist)
                {
                    if (tar.ExpireDate == null)
                    {
                        ShowMessageAndDoSomething("未設定逾期日", "document.getElementById('btnSubmit').style.display='block';");
                        return;
                    }
                }


                string msg = service.SaveEduFormSetting(dto, tlist, rbNow.Checked);


                if (msg != null)
                {
                    ShowMessageAndDoSomething(msg, "document.getElementById('btnSubmit').style.display='block';");
                }
                else
                {

                    CloseWindow(false);
                }
            }
            else
            {
                ShowMessageAndDoSomething("未選擇發送表單", "document.getElementById('btnSubmit').style.display='block';");
            }
        }
        catch(Exception ex)
        {
            ShowMessage("發送失敗:" + ex.Message);
        }
    }

    private RadTreeNode CurrentParentNode
    {
        get
        {
            RadTreeNode cnode = null;

            if (RadTreeView1.SelectedNode == null)
            {
                return cnode;
            }

            if (RadTreeView1.SelectedNode.ParentNode != null)
            {
                cnode = RadTreeView1.SelectedNode.ParentNode;
            }
            else
            {
                cnode = RadTreeView1.SelectedNode;
            }
            return cnode;
        }
    }

    private void RefreshRoleSetting()
    {
        if (RadTreeView1.SelectedNode != null)
        {
            RadTreeNode cnode = CurrentParentNode;

            List<RadTreeNode> coll = new List<RadTreeNode>();
            coll.Add(cnode.Clone());

            List<FormTargetSetting> list = new List<FormTargetSetting>();

            FORM_TEMPLATEDto temp = CurrentTemplateList.Where(c => c.TEMPLATE_ID == Convert.ToInt32(cnode.Value)).FirstOrDefault();

            if (temp.IsMultiTargetForm)
            {
                palSettingMultiTarget.Visible = true;
                palSettingFix.Visible = false;
                RadGrid1.Columns[0].Visible = false;
                RadGrid1.Columns[5].Visible = true;
                panEach.Visible = false;
            }
            else
            {
                palSettingMultiTarget.Visible = false;
                palSettingFix.Visible = true;

                if (cnode.Nodes.Count > 0)
                {
                    if (temp.IS_USER_DEFINE_TARGET || cnode.Nodes.Count > 2)
                    {
                        palSettingMultiTarget.Visible = true;
                        palSettingFix.Visible = false;
                        RadGrid1.Columns[0].Visible = false;
                        RadGrid1.Columns[5].Visible = true;
                        panEach.Visible = true;
                    }
                    else
                    {

                        RadGrid1.Columns[0].Visible = false;
                        RadGrid1.Columns[5].Visible = false;
                        foreach (RadTreeNode node in coll)
                        {
                            if (cnode.Nodes[0].Text.EndsWith("老師") || cnode.Nodes[0].Text.EndsWith("教師"))
                            {
                                FormTargetSetting setting = new FormTargetSetting();
                                setting.Group = node.Text;
                                setting.SettingCode = "T";
                                setting.SettingName = "教師";
                                setting.TemplateID = Convert.ToInt32(node.Nodes[0].Value);
                                list.Add(setting);
                                setting = new FormTargetSetting();
                                setting.Group = node.Text;
                                setting.SettingCode = "S";
                                setting.SettingName = "學生";
                                setting.TemplateID = Convert.ToInt32(node.Nodes[1].Value);
                                list.Add(setting);
                            }
                            else
                            {
                                FormTargetSetting setting = new FormTargetSetting();
                                setting.Group = node.Text;
                                setting.SettingCode = "S";
                                setting.SettingName = "學員";
                                setting.TemplateID = Convert.ToInt32(node.Nodes[0].Value);
                                list.Add(setting);
                                setting = new FormTargetSetting();
                                setting.Group = node.Text;
                                setting.SettingCode = "T";
                                setting.SettingName = "教師";
                                setting.TemplateID = Convert.ToInt32(node.Nodes[1].Value);
                                list.Add(setting);
                            }

                        }
                        panEach.Visible = false;
                    }
                }
                else
                {
                    RadGrid1.Columns[0].Visible = true;
                    RadGrid1.Columns[5].Visible = false;
                    foreach (RadTreeNode node in coll)
                    {

                        FormTargetSetting setting = new FormTargetSetting();
                        setting.Group = node.Text;
                        setting.SettingCode = "S";
                        setting.SettingName = "學員";
                        setting.TemplateID = Convert.ToInt32(node.Value);
                        list.Add(setting);
                        setting = new FormTargetSetting();
                        setting.Group = node.Text;
                        setting.SettingCode = "T";
                        setting.SettingName = "教師";
                        setting.TemplateID = Convert.ToInt32(node.Value);
                        list.Add(setting);
                    }
                    panEach.Visible = true;
                }


            }

            CurrentSetting = list;

            RadGrid1.DataSource = CurrentSetting;
        }
        else
        {
            List<FormTargetSetting> list = new List<FormTargetSetting>();
            CurrentSetting = list;
            RadGrid1.DataSource = CurrentSetting;
        }
    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "SettingCode", "Group" };
        RadGrid1.DataSource = CurrentSetting;

    }

    protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        FormTargetSetting setting = CurrentSetting[e.Item.DataSetIndex];

        GridEditableItem editedItem = e.Item as GridEditableItem;
        Dictionary<string, object> newValues = new Dictionary<string, object>();
        e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);

        List<FormTargetSetting> list = CurrentSetting;

        string setcode = e.Item.OwnerTableView.Items[e.Item.DataSetIndex].GetDataKeyValue("SettingCode").ToString();
        string group = e.Item.OwnerTableView.Items[e.Item.DataSetIndex].GetDataKeyValue("Group").ToString();

        if (palSettingFix.Visible)
        {

            FormTargetSetting sett = list.Where(c => c.SettingCode == setcode && c.Group == group).FirstOrDefault();
            if (sett != null)
            {
                //sett.IsChecked = Convert.ToBoolean(newValues["IsChecked"]);
                if (newValues["ExpireDate"] == null)
                {
                    sett.ExpireDate = null;
                }
                else
                {
                    sett.ExpireDate = Convert.ToDateTime(newValues["ExpireDate"]);
                }

                CurrentSetting = list;
                RadGrid1.DataSource = CurrentSetting;
                RadGrid1.DataBind();
            }
        }
        else
        {
            foreach (FormTargetSetting sett in list)
            {
                //sett.IsChecked = Convert.ToBoolean(newValues["IsChecked"]);
                if (newValues["ExpireDate"] == null)
                {
                    sett.ExpireDate = null;
                }
                else
                {
                    sett.ExpireDate = Convert.ToDateTime(newValues["ExpireDate"]);
                }
            }

            CurrentSetting = list;
            RadGrid1.DataSource = CurrentSetting;
            RadGrid1.DataBind();
        }
    }
        //修改group header

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridGroupHeaderItem)
        {
            (e.Item as GridGroupHeaderItem).DataCell.Text = (e.Item as GridGroupHeaderItem).DataCell.Text.Substring((e.Item as GridGroupHeaderItem).DataCell.Text.IndexOf("-") + 1);
        }
    }

    private void RefreshHistory()
    {
        //if (CurrentParentNode != null)
        //{
        //    List<EduFormTemplateListDto> list = service.GetEduFormSettingList(EduTermID, Convert.ToInt32(CurrentParentNode.Value));
        //    rgHistory.DataSource = list;

        //}
        //else
        //{
            List<EduFormTemplateListDto> list = service.GetEduFormSettingList(EduTermID, null, this.HospCode);
            rgHistory.DataSource = list;
        //}
    }

    protected void rgHistory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RefreshHistory();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        CloseWindow(false);
    }

    protected void lbtnNodeClick_Click(object sender, EventArgs e)
    {
        ClearFields();
        RefreshRoleSetting();
        RadGrid1.DataBind();

        //RefreshHistory();
        //rgHistory.DataBind();
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["category"] = "EduActivity";
    }
    protected void rgHistory0_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadExpireData();
    }

    private void ReadExpireData()
    {
        if (RadTreeView1.SelectedNode != null)
        {
            List<V_ExpireFormInstanceDto> list = service.GetExpireFormInstances(EduTermID, Convert.ToInt32(RadTreeView1.SelectedNode.Value), null);
            rgExpireData.DataSource = list;
        }
        else
        {
            rgExpireData.DataSource = null;
        }
    }
    protected void btnSetExpireDate_Click(object sender, EventArgs e)
    {
        if (!rdpExpireDate.SelectedDate.HasValue)
        {
            ShowMessage("未選擇日期!");
            return;
        }
        List<int> instanceids = new List<int>();
        foreach (GridDataItem item in rgExpireData.SelectedItems)
        {
            int instanceid = Convert.ToInt32(item.GetDataKeyValue("INSTANCE_ID"));
            instanceids.Add(instanceid);
        }

        service.UpdateFormInstanceExpireDate(instanceids, rdpExpireDate.SelectedDate.Value);

        ReadExpireData();
        rgExpireData.DataBind();
    }
    protected void btnDelHistory_Click(object sender, EventArgs e)
    {
        if (rgHistory.SelectedItems.Count > 0)
        {
            foreach (GridDataItem item in rgHistory.SelectedItems)
            {
                string listid = item.GetDataKeyValue("FTListID").ToString();
                var sett = service.GetEduFormTemplateListByID(listid);
                if (sett.Creater != this.EmpCode && !this.AuthRoles.Contains("Admin"))
                {
                    ShowMessage("您沒有刪除他人發送設定的權限");
                    return;
                }
                service.DeleteFormSetting(listid, this.EmpCode);
            }
            RefreshHistory();
            rgHistory.DataBind();
        }
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        List<FormTargetSetting> list = CurrentSetting;

        FormTargetSetting setting = new FormTargetSetting();
        setting.Group = CurrentParentNode.Text;
        setting.SettingCode = ddlSendType.SelectedValue;
        setting.SettingName = ddlSendType.SelectedItem.Text;
        if (CurrentParentNode.Nodes.Count > 0 && CurrentSetting.Count >= CurrentParentNode.Nodes.Count)
        {
            ShowMessage("設定發送對象數量超過表單數");
            return;
        }
        setting.TemplateID = Convert.ToInt32(CurrentParentNode.Value);
        list.Add(setting);

        CurrentSetting = list;
        RadGrid1.DataSource = CurrentSetting;
        RadGrid1.DataBind();
    }

    protected void btnQueryHistory_Click(object sender, EventArgs e)
    {
        if (rgHistory.SelectedItems.Count > 0)
        {
            
            foreach (GridDataItem item in rgHistory.SelectedItems)
            {
                ClearFields();
                string listid = item.GetDataKeyValue("FTListID").ToString();

                EduFormTemplateListDto ftlist = service.GetEduFormTemplateList(listid);
                QueryTemplateList = ftlist;
                btnSave.Visible = false;
                btnSubmit.Visible = false;

                List<EduFormTemplateTargetDto> ftts = service.GetEduFormTemplateTargets(listid);


                tbName.Text = ftlist.Name;
                rdpExecuteDate.MinDate = ftlist.ExecuteDate;
                rdpExecuteDate.SelectedDate = ftlist.ExecuteDate;


                List<FormTargetSetting> list = new List<FormTargetSetting>();
                foreach (EduFormTemplateTargetDto ftt in ftts)
                {
                    FormTargetSetting setting = new FormTargetSetting();
                    setting.IsChecked = true;
                    setting.ExpireDate = ftt.ExpireDate;
                    setting.Group = vc.GetFormTemplateById(ftt.SubTEMPLATE_ID).TEMPLATE_NAME;
                    setting.SettingCode = ftt.RoleType;
                    setting.UserDefineTargetID = ftt.UserDefineTargetID;
                    if (ftt.RoleType == "S")
                    {
                        setting.SettingName = "學員";
                    }
                    else if (ftt.RoleType == "T")
                    {
                        setting.SettingName = "老師";
                        ddlTeacherType.SelectedValue = ftt.TeacherType;
                        
                    }
                    else
                    {
                        ddlTeacherType.SelectedValue = ftt.RoleType;
                        
                        foreach (ListItem listitem in ddlSendType.Items)
                        {
                            if (listitem.Value == ftt.RoleType)
                            {
                                setting.SettingName = listitem.Text;
                            }
                        }
                    }
                    list.Add(setting);
                }

                rbSendOrderSetting.SelectedValue = ftlist.SendOrderSetting;
                CurrentSetting = list;
                RadGrid1.DataSource = CurrentSetting;
                RadGrid1.DataBind();

            }
        }
    }
    protected void btnAddTeacher_Click(object sender, EventArgs e)
    {
        SelectVKmuempData emp = service.ReadVKmuempData(tbTeacherEmpCode.Text);
        if (emp != null)
        {
            lbTeacher.Items.Add(new ListItem(emp.empname, emp.empcode));
            tbTeacherEmpCode.Text = "";
        }
        else
        {
            ShowMessage("員工編號錯誤");
        }
    }
    protected void ddlTeacherType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTeacherType.SelectedValue == "xxx")
        {
            panUserDefine.Visible = true;
            lbTeacher.Items.Clear();
            tbTeacherEmpCode.Text = "";
        }
        else
        {
            panUserDefine.Visible = false;
        }
    }
    protected void btnDelTeacher_Click(object sender, EventArgs e)
    {
        if (lbTeacher.SelectedItem != null)
        {
            lbTeacher.Items.Remove(lbTeacher.SelectedItem);
        }
    }
    protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            string id = null;
            if (item.GetDataKeyValue("AutoFTListID") != null)
            {
                id = item.GetDataKeyValue("AutoFTListID").ToString();
            }

            if (id != null)
            {
                LinkButton lbtnEditTerm = e.Item.FindControl("lbtnEditSetting") as LinkButton;
                if (lbtnEditTerm != null)
                {
                    lbtnEditTerm.OnClientClick = "openEditFormSettingWin('" + id + "');return false;";
                }

            }
        }
    }
    protected void RadGrid2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ReadAutoFtListSetting();
    }
    protected void btnNeedSend_Click(object sender, EventArgs e)
    {
        if (RadGrid2.SelectedItems.Count > 0)
        {
            foreach (GridDataItem item in RadGrid2.SelectedItems)
            {
                string listid = item.GetDataKeyValue("AutoFTListID").ToString();
                service.InsertAutoEduFormSettingExpectListEduTerm(listid, CurrentEduTerm.EduTermID);
            }
            ReadAutoFtListSetting();
            RadGrid2.DataBind();
        }
    }
    protected void btnDontSend_Click(object sender, EventArgs e)
    {
        if (RadGrid2.SelectedItems.Count > 0)
        {
            foreach (GridDataItem item in RadGrid2.SelectedItems)
            {
                string listid = item.GetDataKeyValue("AutoFTListID").ToString();
                service.DeleteAutoEduFormSettingExpectListEduTerm(listid, CurrentEduTerm.EduTermID);
            }
            ReadAutoFtListSetting();
            RadGrid2.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        QueryTemplateList.Name = tbName.Text;
        service.UpdateEduFormTemplateList(QueryTemplateList);
        RefreshHistory();
        rgHistory.DataBind();
    }
    protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
    {

        List<FormTargetSetting> list = CurrentSetting;

        list.RemoveAt(e.Item.ItemIndex);

        CurrentSetting = list;
        RadGrid1.DataSource = CurrentSetting;
        RadGrid1.DataBind();
    }
    protected void btnReSend_Click(object sender, EventArgs e)
    {
        if (rgHistory.SelectedItems.Count > 0)
        {
            foreach (GridDataItem item in rgHistory.SelectedItems)
            {
                string listid = item.GetDataKeyValue("FTListID").ToString();
                var sett = service.GetEduFormTemplateListByID(listid);
                sett.Status = null;
                service.UpdateEduFormTemplateList(sett);
            }
            RefreshHistory();
            rgHistory.DataBind();
        }
    }
}