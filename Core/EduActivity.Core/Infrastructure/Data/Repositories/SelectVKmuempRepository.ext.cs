using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Data.Common;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
  public partial class SelectVKmuempRepository
  {
      #region Overrides

      public override IQueryable<SelectVKmuemp> GetAll()
      {
          parameters.Add(new OAParameter("empcode", this.empcode));
          parameters.Add(new OAParameter("password", this.password));
          //this.FixWhereStatement();//remove parameters;
          //this.FixWhereStatement("Country in ('USA', 'Taiwan', 'China')");//replace where statement
          //this.FixWhereStatement("aParameter", "bParameter");//remove parameters;
          return this.GetAll(sql, parameters.ToArray()).AsQueryable();
      }
      #endregion Overrides
  }
}


