using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Data.Common;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
  public partial class SelectKmuDoctorRepository
  {
      #region Overrides

      public override IQueryable<SelectKmuDoctor> GetAll()
      {
          parameters.Add(new OAParameter("empname", this.empname));
          parameters.Add(new OAParameter("empcode", this.empcode));
          //this.FixWhereStatement();//remove parameters;
          //this.FixWhereStatement("Country in ('USA', 'Taiwan', 'China')");//replace where statement
          //this.FixWhereStatement("aParameter", "bParameter");//remove parameters;
          return this.GetAll(sql, parameters.ToArray()).AsQueryable();
      }
      #endregion Overrides
  }
}


