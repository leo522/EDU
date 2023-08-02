using System;
using System.Linq;
using System.Collections.Generic;
using AppFramework.Mapper.AutoMapper;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.ApplicationLayer.Assemblers
{

  public partial interface ISelectVKmuempDataAssembler : IAssembler<SelectVKmuempDataDto, SelectVKmuempData>
  {
  }

  public partial class SelectVKmuempDataAssemblerBase : Assembler<SelectVKmuempDataDto, SelectVKmuempData>
  {
      partial void OnDTOAssembled(SelectVKmuempDataDto dto);

      partial void OnEntityAssembled(SelectVKmuempData entity);

      public override SelectVKmuempData Assemble(SelectVKmuempData entity, SelectVKmuempDataDto dto)
      {
          entity = Mapper.Map<SelectVKmuempDataDto, SelectVKmuempData>(dto);
          this.OnEntityAssembled(entity);
          return entity;
      }

      public override SelectVKmuempDataDto Assemble(SelectVKmuempData entity)
      {
          SelectVKmuempDataDto dto = Mapper.Map<SelectVKmuempData, SelectVKmuempDataDto>(entity);
          this.OnDTOAssembled(dto);
          return dto;
      }
  }

  public partial class SelectVKmuempDataAssembler : SelectVKmuempDataAssemblerBase, ISelectVKmuempDataAssembler
  {
  }
}

