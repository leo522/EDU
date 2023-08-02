using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Data.Common;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
  public partial class SelectActTypeRepository
  {
      #region Overrides

      public override IQueryable<SelectActType> GetAll()
      {
          //this.FixWhereStatement();//remove parameters;
          //this.FixWhereStatement("Country in ('USA', 'Taiwan', 'China')");//replace where statement
          return this.GetAll(sql).AsQueryable(); 
      }
      #endregion Overrides
  }
}


