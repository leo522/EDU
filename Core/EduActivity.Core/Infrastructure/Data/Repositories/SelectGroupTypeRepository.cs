using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Data.Common;
using KMU.EduActivity.DomainModel.Contracts;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
  public partial class SelectGroupTypeRepository : Repository<SelectGroupType>, ISelectGroupTypeRepository
  {
      #region Private Fields

      private readonly string sql = @"select code,name from  sys_public.dbo.f_OrgGroup_GroupType(@type)";
      private List<OAParameter>  parameters = new List<OAParameter>();

      #endregion Private Fields

      #region Ctor

      /// <summary>
      /// Create a new instance
      /// </summary>
      /// <param name="unitOfWork">Associated unit of work</param>
      public SelectGroupTypeRepository (IEduActivityContextUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }

      #endregion Ctor

      #region Properties
      /// <summary>
      /// 
      /// </summary>
      public string type {get;set;}

      #endregion Properties

  }
}


