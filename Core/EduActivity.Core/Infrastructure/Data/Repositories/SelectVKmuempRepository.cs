using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Data.Common;
using KMU.EduActivity.DomainModel.Contracts;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
  public partial class SelectVKmuempRepository : Repository<SelectVKmuemp>, ISelectVKmuempRepository
  {
      #region Private Fields

      private readonly string sql = @"SELECT empcode,
       empcode7,
       empname,
       pwd,
       hospcode,
       hospname,
       deptcode,
       loccode,
       groupstatus,
       groupdept,
       jobcode,
       servedate,
       enddate,
       email
FROM   V_KmuEmp
WHERE  empcode = @empcode
       AND @password = @password
";
      private List<OAParameter>  parameters = new List<OAParameter>();

      #endregion Private Fields

      #region Ctor

      /// <summary>
      /// Create a new instance
      /// </summary>
      /// <param name="unitOfWork">Associated unit of work</param>
      public SelectVKmuempRepository (IEduActivityContextUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }

      #endregion Ctor

      #region Properties
      /// <summary>
      /// 
      /// </summary>
      public string empcode {get;set;}
      /// <summary>
      /// 
      /// </summary>
      public string password {get;set;}

      #endregion Properties

  }
}


