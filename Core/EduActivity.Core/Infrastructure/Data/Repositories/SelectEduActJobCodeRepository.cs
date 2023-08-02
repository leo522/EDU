using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Data.Common;
using KMU.EduActivity.DomainModel.Contracts;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
  public partial class SelectEduActJobCodeRepository : Repository<SelectEduActJobCode>, ISelectEduActJobCodeRepository
  {
      #region Private Fields

      private readonly string sql = @"select * From sys_public.dbo.f_coderef_codetype('EduAct_JobCode')";
      private List<OAParameter>  parameters = new List<OAParameter>();

      #endregion Private Fields

      #region Ctor

      /// <summary>
      /// Create a new instance
      /// </summary>
      /// <param name="unitOfWork">Associated unit of work</param>
      public SelectEduActJobCodeRepository (IEduActivityContextUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }

      #endregion Ctor

      #region Properties

      #endregion Properties

  }
}


