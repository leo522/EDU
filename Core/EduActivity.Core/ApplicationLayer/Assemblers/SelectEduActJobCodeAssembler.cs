using System;
using System.Linq;
using System.Collections.Generic;
using AppFramework.Mapper.AutoMapper;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.ApplicationLayer.Assemblers
{

  public partial interface ISelectEduActJobCodeAssembler : IAssembler<SelectEduActJobCodeDto, SelectEduActJobCode>
  {
  }

  public partial class SelectEduActJobCodeAssemblerBase : Assembler<SelectEduActJobCodeDto, SelectEduActJobCode>
  {
      partial void OnDTOAssembled(SelectEduActJobCodeDto dto);

      partial void OnEntityAssembled(SelectEduActJobCode entity);

      public override SelectEduActJobCode Assemble(SelectEduActJobCode entity, SelectEduActJobCodeDto dto)
      {
          entity = Mapper.Map<SelectEduActJobCodeDto, SelectEduActJobCode>(dto);
          this.OnEntityAssembled(entity);
          return entity;
      }

      public override SelectEduActJobCodeDto Assemble(SelectEduActJobCode entity)
      {
          SelectEduActJobCodeDto dto = Mapper.Map<SelectEduActJobCode, SelectEduActJobCodeDto>(entity);
          this.OnDTOAssembled(dto);
          return dto;
      }
  }

  public partial class SelectEduActJobCodeAssembler : SelectEduActJobCodeAssemblerBase, ISelectEduActJobCodeAssembler
  {
  }
}

