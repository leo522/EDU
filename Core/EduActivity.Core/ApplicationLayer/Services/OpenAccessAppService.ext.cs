using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using AppFramework.Specifications;
using KMU.EduActivity.DomainModel.Entities;
using KMU.EduActivity.ApplicationLayer.Assemblers;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.Infrastructure.Data.Repositories;

namespace KMU.EduActivity.ApplicationLayer.Services
{

  public partial class EduActivityContextService : IEduActivityContextService
  {
      //public IEnumerable<ERPatientDto> GetPatients()
      //{
      //    var repository = new ERPatientRepository(this.UnitOfWork);
      //    var list = repository.GetAll();
      //    var assembler = new ERPatientAssembler();
      //    return assembler.Assemble(list);
      //}




  }
}

