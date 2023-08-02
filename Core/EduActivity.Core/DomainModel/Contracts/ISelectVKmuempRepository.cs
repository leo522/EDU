using System;
using System.Collections.Generic;
using KMU.EduActivity.DomainModel.Entities;
using KMU.EduActivity.Infrastructure.Data.Repositories;

namespace KMU.EduActivity.DomainModel.Contracts
{
  /// <summary>
  /// Base contract for SelectVKmuemp repository
  /// </summary>
  public partial interface ISelectVKmuempRepository : IRepository<SelectVKmuemp>
  {
      #region Properties

      /// <summary>
      /// 
      /// </summary>
      string empcode {get;set;}
      /// <summary>
      /// 
      /// </summary>
      string password {get;set;}
        
      #endregion Properties
  }

}

