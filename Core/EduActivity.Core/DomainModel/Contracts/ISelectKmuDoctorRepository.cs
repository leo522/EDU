using System;
using System.Collections.Generic;
using KMU.EduActivity.DomainModel.Entities;
using KMU.EduActivity.Infrastructure.Data.Repositories;

namespace KMU.EduActivity.DomainModel.Contracts
{
  /// <summary>
  /// Base contract for SelectKmuDoctor repository
  /// </summary>
  public partial interface ISelectKmuDoctorRepository : IRepository<SelectKmuDoctor>
  {
      #region Properties

      /// <summary>
      /// 
      /// </summary>
      string empname {get;set;}
      /// <summary>
      /// 
      /// </summary>
      string empcode {get;set;}
        
      #endregion Properties
  }

}

