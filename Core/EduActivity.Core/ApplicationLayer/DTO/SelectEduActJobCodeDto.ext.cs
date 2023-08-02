using System;
using System.Collections.Generic;
using System.Linq;

namespace KMU.EduActivity.ApplicationLayer.DTO
{
    [Serializable]
  public partial class SelectEduActJobCodeDto
  {
      #region Properties
        
      #endregion Properties

      public List<SelectEduActJobCodeDto> GetJobCodes()
      {
          KMU.EduActivity.ApplicationLayer.Services.EduActivityContextService service = new Services.EduActivityContextService();
          KMU.EduActivity.Infrastructure.Data.Repositories.SelectEduActJobCodeRepository rep = new Infrastructure.Data.Repositories.SelectEduActJobCodeRepository(service.UnitOfWork);
          KMU.EduActivity.ApplicationLayer.Assemblers.SelectEduActJobCodeAssembler asm = new Assemblers.SelectEduActJobCodeAssembler();


          List<SelectEduActJobCodeDto> list = asm.Assemble(rep.GetAll().OrderBy(c => c.ShowSeq).ToList()).ToList();

          SelectEduActJobCodeDto dto = new SelectEduActJobCodeDto();
          dto.Code = "";
          dto.Name = "--";
          list.Insert(0, dto);

          return list;
      }
  }

}

