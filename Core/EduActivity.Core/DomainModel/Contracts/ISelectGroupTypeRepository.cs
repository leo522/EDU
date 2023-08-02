using System;
using System.Collections.Generic;
using KMU.EduActivity.DomainModel.Entities;
using KMU.EduActivity.Infrastructure.Data.Repositories;

namespace KMU.EduActivity.DomainModel.Contracts
{
  /// <summary>
  /// Base contract for SelectGroupType repository
  /// </summary>
  public partial interface ISelectGroupTypeRepository : IRepository<SelectGroupType>
  {
      #region Properties

      /// <summary>
      /// 
      /// </summary>
      string type {get;set;}
        
      #endregion Properties
  }

}

