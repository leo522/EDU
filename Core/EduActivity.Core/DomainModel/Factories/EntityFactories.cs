using System;
using System.Collections.Generic;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.DomainModel.Factories
{
  /// <summary>
  /// This is the factory for EduTermCode creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduTermCodeFactory
  {
      public static EduTermCode Create(string edutermcode1)
      {
          var entity = new EduTermCode ();
          //entity.EduTermCode1 = edutermcode1;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for Member creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class MemberFactory
  {
      public static Member Create(string memberid,string membercode,string name,string membertype,string des,char? status,DateTime datefrom,DateTime dateto,string ishospmember,byte[] avatarsmall,byte[] avatar,IList<EduTeamMember> eduteammembers)
      {
          var entity = new Member ();
          //entity.MemberID = memberid;
          //entity.MemberCode = membercode;
          //entity.Name = name;
          //entity.MemberType = membertype;
          //entity.Des = des;
          //entity.Status = status;
          //entity.DateFrom = datefrom;
          //entity.DateTo = dateto;
          //entity.IsHospMember = ishospmember;
          //entity.AvatarSmall = avatarsmall;
          //entity.Avatar = avatar;
          //entity.EduTeamMembers = eduteammembers;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduTeamMember creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduTeamMemberFactory
  {
      public static EduTeamMember Create(string eduteammemberid,string eduteamcode,string membercode,string memberid,string tutor2,string tutor,Member member,EduTeam eduteam)
      {
          var entity = new EduTeamMember ();
          //entity.EduTeamMemberID = eduteammemberid;
          //entity.EduTeamCode = eduteamcode;
          //entity.MemberCode = membercode;
          //entity.MemberID = memberid;
          //entity.Tutor2 = tutor2;
          //entity.Tutor = tutor;
          //entity.Member = member;
          //entity.EduTeam = eduteam;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduTeamRundown creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduTeamRundownFactory
  {
      public static EduTeamRundown Create(string eduteamstopid,string edutermid,string eduteamcode,DateTime datefrom,DateTime dateto,EduTeam eduteam,EduTerm eduterm)
      {
          var entity = new EduTeamRundown ();
          //entity.EduTeamStopID = eduteamstopid;
          //entity.EduTermID = edutermid;
          //entity.EduTeamCode = eduteamcode;
          //entity.DateFrom = datefrom;
          //entity.DateTo = dateto;
          //entity.EduTeam = eduteam;
          //entity.EduTerm = eduterm;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduTeamMemberRundown creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduTeamMemberRundownFactory
  {
      public static EduTeamMemberRundown Create(string eduteammemberid,string edutermid,string memberid,string membercode,string coachid)
      {
          var entity = new EduTeamMemberRundown ();
          //entity.EduTeamMemberID = eduteammemberid;
          //entity.EduTermID = edutermid;
          //entity.MemberID = memberid;
          //entity.MemberCode = membercode;
          //entity.CoachID = coachid;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduTeam creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduTeamFactory
  {
      public static EduTeam Create(string eduteamcode,string teammembertype,char status,string parenteduteamcode,string eduteamname,int? displayorder,IList<EduTeamRundown> eduteamrundowns,IList<EduTeamMember> eduteammembers)
      {
          var entity = new EduTeam ();
          //entity.EduTeamCode = eduteamcode;
          //entity.TeamMemberType = teammembertype;
          //entity.Status = status;
          //entity.ParentEduTeamCode = parenteduteamcode;
          //entity.EduTeamName = eduteamname;
          //entity.DisplayOrder = displayorder;
          //entity.EduTeamRundowns = eduteamrundowns;
          //entity.EduTeamMembers = eduteammembers;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduActTopic creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduActTopicFactory
  {
      public static EduActTopic Create(string eduacttopicid,string eduacttopiccode,string eduacttopicname)
      {
          var entity = new EduActTopic ();
          //entity.EduActTopicID = eduacttopicid;
          //entity.EduActTopicCode = eduacttopiccode;
          //entity.EduActTopicName = eduacttopicname;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduStopActSchedule creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduStopActScheduleFactory
  {
      public static EduStopActSchedule Create(string edustopactscheduleid,string eduacttopicid,DateTime timefrom,DateTime timeto,string des,string acttype,string edutermid)
      {
          var entity = new EduStopActSchedule ();
          //entity.EduStopActScheduleID = edustopactscheduleid;
          //entity.EduActTopicID = eduacttopicid;
          //entity.TimeFrom = timefrom;
          //entity.TimeTo = timeto;
          //entity.Des = des;
          //entity.ActType = acttype;
          //entity.EduTermID = edutermid;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for Form_ToDo_List creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class Form_ToDo_ListFactory
  {
      public static Form_ToDo_List Create(int todolistid,string edutermid,int template_id,DateTime begin_time,DateTime end_time)
      {
          var entity = new Form_ToDo_List ();
          //entity.ToDoListID = todolistid;
          //entity.EduTermID = edutermid;
          //entity.TEMPLATE_ID = template_id;
          //entity.BEGIN_TIME = begin_time;
          //entity.END_TIME = end_time;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduTermFormInstance creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduTermFormInstanceFactory
  {
      public static EduTermFormInstance Create(string edutermid,int instance_id)
      {
          var entity = new EduTermFormInstance ();
          //entity.EduTermID = edutermid;
          //entity.INSTANCE_ID = instance_id;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduFormTemplateTarget creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduFormTemplateTargetFactory
  {
      public static EduFormTemplateTarget Create(string roletype,DateTime? expiredate,int subtemplate_id,string fttargetid,string ftlistid)
      {
          var entity = new EduFormTemplateTarget ();
          //entity.RoleType = roletype;
          //entity.ExpireDate = expiredate;
          //entity.SubTEMPLATE_ID = subtemplate_id;
          //entity.FTTargetID = fttargetid;
          //entity.FTListID = ftlistid;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduFormTemplateList creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduFormTemplateListFactory
  {
      public static EduFormTemplateList Create(int template_id,string createsql,string des,string name,DateTime executedate,string tempotype,string temposettings,string ftlistid,string edutermid)
      {
          var entity = new EduFormTemplateList ();
          //entity.TEMPLATE_ID = template_id;
          //entity.CreateSQL = createsql;
          //entity.Des = des;
          //entity.Name = name;
          //entity.ExecuteDate = executedate;
          //entity.TempoType = tempotype;
          //entity.TempoSettings = temposettings;
          //entity.FTListID = ftlistid;
          //entity.EduTermID = edutermid;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduStop creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduStopFactory
  {
      public static EduStop Create(string edustopid,string edustopcode,string name,string depid,string nstation,string corchid,char? status,string des,string yearcode,string parentedustopid)
      {
          var entity = new EduStop ();
          //entity.EduStopID = edustopid;
          //entity.EduStopCode = edustopcode;
          //entity.Name = name;
          //entity.DepID = depid;
          //entity.NStation = nstation;
          //entity.CorchID = corchid;
          //entity.Status = status;
          //entity.Des = des;
          //entity.YearCode = yearcode;
          //entity.ParentEduStopID = parentedustopid;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduTerm creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduTermFactory
  {
      public static EduTerm Create(string edutermid,string edustopcode,string name,string depcode,string nstation,string corchid,DateTime datefrom,DateTime dateto,char? isclass,string roundcode,char? status,string des,int capacity,string membertype,string edustopid,string teacher,string ebm,string creater,string parentedutermid,IList<EduTeamRundown> eduteamrundowns)
      {
          var entity = new EduTerm ();
          //entity.EduTermID = edutermid;
          //entity.EduStopCode = edustopcode;
          //entity.Name = name;
          //entity.DepCode = depcode;
          //entity.NStation = nstation;
          //entity.CorchID = corchid;
          //entity.DateFrom = datefrom;
          //entity.DateTo = dateto;
          //entity.IsClass = isclass;
          //entity.RoundCode = roundcode;
          //entity.Status = status;
          //entity.Des = des;
          //entity.Capacity = capacity;
          //entity.MemberType = membertype;
          //entity.EduStopID = edustopid;
          //entity.Teacher = teacher;
          //entity.EBM = ebm;
          //entity.Creater = creater;
          //entity.ParentEduTermID = parentedutermid;
          //entity.EduTeamRundowns = eduteamrundowns;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for V_ExpireFormInstance creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class V_ExpireFormInstanceFactory
  {
      public static V_ExpireFormInstance Create(string membername,string memberid,string ishospmember,string instance_name,int instance_id,DateTime instance_create_datetime,DateTime? expiredate,string edutermname,string edutermid,int template_id)
      {
          var entity = new V_ExpireFormInstance ();
          //entity.Membername = membername;
          //entity.MemberID = memberid;
          //entity.IsHospMember = ishospmember;
          //entity.INSTANCE_NAME = instance_name;
          //entity.INSTANCE_ID = instance_id;
          //entity.INSTANCE_CREATE_DATETIME = instance_create_datetime;
          //entity.ExpireDate = expiredate;
          //entity.Edutermname = edutermname;
          //entity.EduTermID = edutermid;
          //entity.TEMPLATE_ID = template_id;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduTeacherType creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduTeacherTypeFactory
  {
      public static EduTeacherType Create(string code,string name,int? display_order)
      {
          var entity = new EduTeacherType ();
          //entity.Code = code;
          //entity.Name = name;
          //entity.Display_order = display_order;
          return entity;
      }
  }

  /// <summary>
  /// This is the factory for EduRefTeacher creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class EduRefTeacherFactory
  {
      public static EduRefTeacher Create(int edurefteacherid,string teacherid,string teachertype,string refid,string reftable,string edutermid)
      {
          var entity = new EduRefTeacher ();
          //entity.EduRefTeacherID = edurefteacherid;
          //entity.TeacherID = teacherid;
          //entity.TeacherType = teachertype;
          //entity.RefID = refid;
          //entity.RefTable = reftable;
          //entity.EduTermID = edutermid;
          return entity;
      }
  }

}

