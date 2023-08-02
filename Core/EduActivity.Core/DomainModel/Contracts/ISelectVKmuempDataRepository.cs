using System;
using System.Collections.Generic;
using KMU.EduActivity.DomainModel.Entities;
using KMU.EduActivity.Infrastructure.Data.Repositories;

namespace KMU.EduActivity.DomainModel.Contracts
{
  /// <summary>
  /// Base contract for SelectVKmuempData repository
  /// </summary>
  public partial interface ISelectVKmuempDataRepository : IRepository<SelectVKmuempData>
  {
      #region Properties

      /// <summary>
      /// 
      /// </summary>
      string empcode {get;set;}
        
      #endregion Properties
  }

}

