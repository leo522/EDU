using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Data.Common;
using KMU.EduActivity.DomainModel.Contracts;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
  public partial class SelectKmuDoctorRepository : Repository<SelectKmuDoctor>, ISelectKmuDoctorRepository
  {
      #region Private Fields

      private readonly string sql = @"SELECT   a.empcode  AS code,
         a.empname  AS name,
         b.deptname AS deptname,
         b.deptcode AS deptcode,
         a.empcode + ' '+
         a.empname
           + '('
           + b.deptname
           + ')' AS displayname
FROM     v_kmuemp a
         INNER JOIN v_departments b
           ON a.deptcode = b.deptcode
              AND a.hospcode = b.hospcode
WHERE  (@empname = '' or empname like '%'+@empname+'%')
and (@empcode = '' or empcode like '%'+@empcode+'%')
ORDER BY a.empname";
      private List<OAParameter>  parameters = new List<OAParameter>();

      #endregion Private Fields

      #region Ctor

      /// <summary>
      /// Create a new instance
      /// </summary>
      /// <param name="unitOfWork">Associated unit of work</param>
      public SelectKmuDoctorRepository (IEduActivityContextUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }

      #endregion Ctor

      #region Properties
      /// <summary>
      /// 
      /// </summary>
      public string empname {get;set;}
      /// <summary>
      /// 
      /// </summary>
      public string empcode {get;set;}

      #endregion Properties

  }
}


