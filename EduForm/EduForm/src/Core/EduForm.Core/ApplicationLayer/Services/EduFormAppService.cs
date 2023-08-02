using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;  
using System.Transactions;
using Telerik.OpenAccess;
using AppFramework.Logging;
using AppFramework.Logging.TraceSource;
using AppFramework.Validation;
using AppFramework.Validation.DataAnnotations;
//using KMUH.EduForm.ApplicationLayer.Assemblers;
using KMUH.EduForm.ApplicationLayer.DTO;
//using KMUH.EduForm.DomainModel.Contracts;
using KMUH.EduForm.DomainModel.Entities;
using KMUH.EduForm.DomainModel.Factories;
using KMUH.FunctionLibrary.ApplicationLayer.Services;

namespace KMUH.EduForm.ApplicationLayer.Services
{
    

  public class EduFormAppService : IEduFormAppService
  {
      #region Private Members

      private IEntityValidator validator;
      private ILogger logger;

	private IApConnHelper _apConnHelper;
      #endregion Private Members

      #region Ctor

      public EduFormAppService ()
      {
          //Set Validator
          EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
          validator = EntityValidatorFactory.CreateValidator();
          //Set Logger
          LoggerFactory.SetCurrent(new TraceSourceLogFactory());
          logger = LoggerFactory.CreateLog();
      }
      public EduFormAppService (IApConnHelper apConnHelper)
      {
          //Set Validator
          EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
          validator = EntityValidatorFactory.CreateValidator();
          //Set Logger
          LoggerFactory.SetCurrent(new TraceSourceLogFactory());
          logger = LoggerFactory.CreateLog();
          _apConnHelper = apConnHelper;
      }

      #endregion Ctor

      public string Ping()
      {
          return DateTime.Now.ToString();
      }

      #region IDisposable Members

      public void Dispose()
      {
          //dispose all resources
      }

      #endregion IDisposable Members

      #region IEduFormAppService Members

      // TODO: 1. Add your application service layer operations here

      //public IEnumerable<CustomerDto> GetCustomers()
      //{
      //  using (IEduFormOperationService opService = new EduFormOperationService())
      //  {
      //    return opService.ReadCustomers();
      //  }
      //}


      #endregion IEduFormAppService Members
  }	

}