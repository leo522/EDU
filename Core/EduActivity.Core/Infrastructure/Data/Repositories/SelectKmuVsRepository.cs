using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Data.Common;
using KMU.EduActivity.DomainModel.Contracts;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
  public partial class SelectKmuVsRepository : Repository<SelectKmuVs>, ISelectKmuVsRepository
  {
      #region Private Fields

      private readonly string sql = @"SELECT   a.empcode  AS code,
         a.empname  AS name,
         b.deptname AS deptname,
         b.deptcode AS deptcode,
         a.empname
           + '('
           + b.deptname
           + ')' AS displayname
FROM     v_kmuemp a
         left JOIN v_departments b
           ON a.deptcode = b.deptcode
              AND a.hospcode = b.hospcode
ORDER BY a.empname";
      private List<OAParameter>  parameters = new List<OAParameter>();

      #endregion Private Fields

      #region Ctor

      /// <summary>
      /// Create a new instance
      /// </summary>
      /// <param name="unitOfWork">Associated unit of work</param>
      public SelectKmuVsRepository (IEduActivityContextUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }

      #endregion Ctor

      #region Properties

      #endregion Properties

  }
}


