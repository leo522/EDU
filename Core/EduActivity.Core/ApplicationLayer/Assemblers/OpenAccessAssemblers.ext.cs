using System;
using System.Linq;
using System.Collections.Generic;
using KMU.EduActivity.DomainModel.Entities;
using KMU.EduActivity.ApplicationLayer.DTO;

namespace KMU.EduActivity.ApplicationLayer.Assemblers
{
      //public partial class EduTermCodeAssembler : EduTermCodeAssemblerBase, IEduTermCodeAssembler
      //{
      //    public override EduTermCodeDto Assemble(EduTermCode entity)
      //    {
      //        var dto = base.Assemble(entity);
      //        return dto;
      //      }
      //}    

      //public partial class MemberAssembler : MemberAssemblerBase, IMemberAssembler
      //{
      //    public override MemberDto Assemble(Member entity)
      //    {
      //        var dto = base.Assemble(entity);
      //        return dto;
      //      }
      //}    

      //public partial class EduTermAssembler : EduTermAssemblerBase, IEduTermAssembler
      //{
      //    public override EduTermDto Assemble(EduTerm entity)
      //    {
      //        var dto = base.Assemble(entity);
      //        return dto;
      //      }
      //}    

      //public partial class EduTeamMemberAssembler : EduTeamMemberAssemblerBase, IEduTeamMemberAssembler
      //{
      //    public override EduTeamMemberDto Assemble(EduTeamMember entity)
      //    {
      //        var dto = base.Assemble(entity);
      //        return dto;
      //      }
      //}    



    public partial class MessageBoardAssembler : MessageBoardAssemblerBase, IMessageBoardAssembler
    {
        public override MessageBoardDto Assemble(MessageBoard entity)
        {
            var dto = base.Assemble(entity);

            dto.ReplyCount = entity.MessageBoards.Count(c => c.Status != 'X');

            return dto;
        }
    }

    public partial class EduStopActScheduleAssembler : EduStopActScheduleAssemblerBase, IEduStopActScheduleAssembler
    {
        public override EduStopActScheduleDto Assemble(EduStopActSchedule entity)
        {
            var dto = base.Assemble(entity);
            dto.HasTarget = entity.HasTargets;
            dto.HasAttachment = entity.HasAttachments;
            //if (entity.EduActTargets.Count > 0)
            //{
            //    dto.HasTarget = true;
            //}
            //else
            //{
            //    dto.HasTarget = false;
            //}

            //if (entity.EduStopActAttachments.Count() > 0)
            //{
            //    dto.HasAttachment = true;
            //}
            //else
            //{
            //    dto.HasAttachment = false;
            //}

            return dto;
        }
    }

    public partial class EduTermAssembler : EduTermAssemblerBase, IEduTermAssembler
    {
        public override EduTermDto Assemble(EduTerm entity)
        {
            var dto = base.Assemble(entity);
            string datefromstr = entity.DateFrom.ToString("yyyy.MM.dd");//(entity.DateFrom.Year - 1911).ToString() + entity.DateFrom.ToString(".MM.dd");
            if (entity.DateFrom.Hour != 0 && entity.DateFrom.Minute != 0)
            {
                datefromstr += " " + entity.DateFrom.ToString("HH:mm");
            }
            string datetostr = entity.DateTo.ToString("yyyy.MM.dd");//(entity.DateTo.Year - 1911).ToString() + entity.DateTo.ToString(".MM.dd");
            if (entity.DateTo.Hour != 0 && entity.DateTo.Minute != 0)
            {
                datetostr += " " + entity.DateTo.ToString("HH:mm");
            }
            dto.DateFromToStr = datefromstr + "~" + datetostr;

            string[] codelist = dto.RoundCode.Split('|');

            if (codelist.Length > 1)
            {
                for (int i = 0; i < codelist.Length - 1; i++)
                {
                    dto.ParentEduTermCode += codelist[i] + "|";
                }
                dto.ParentEduTermCode = dto.ParentEduTermCode.Substring(0, dto.ParentEduTermCode.Length - 1);
                    //dto.ParentEduTermCode = codelist[codelist.Length - 2];
                
            }

            return dto;
        }
    }  

    public partial class EduTeamRundownAssembler : EduTeamRundownAssemblerBase, IEduTeamRundownAssembler
    {
        public override EduTeamRundownDto Assemble(EduTeamRundown entity)
        {
            var dto = base.Assemble(entity);

            string datefromstr = entity.DateFrom.ToString("yyyy.MM.dd");//(entity.DateFrom.Year - 1911).ToString() + entity.DateFrom.ToString(".MM.dd");
            if (entity.DateFrom.Hour != 0 && entity.DateFrom.Minute != 0)
            {
                datefromstr += " " + entity.DateFrom.ToString("HH:mm");
            }
            string datetostr = entity.DateTo.ToString("yyyy.MM.dd");//(entity.DateTo.Year - 1911).ToString() + entity.DateTo.ToString(".MM.dd");
            if (entity.DateTo.Hour != 0 && entity.DateTo.Minute != 0)
            {
                datetostr += " " + entity.DateTo.ToString("HH:mm");
            }
            dto.DateFromToStr = datefromstr + "~" + datetostr;
            return dto;
        }
    }

    public partial class MemberAssembler : MemberAssemblerBase, IMemberAssembler
    {
        public override MemberDto Assemble(Member entity)
        {
            var dto = base.Assemble(entity);
            dto.DisplayName = dto.MemberCode + " - " + dto.Name;

            if (dto.IsHospMember != null)
            {
                dto.DisplayName += "(Â¾½s¡G" + dto.IsHospMember + ")";
            }
            return dto;
        }
    }    

}

