using System;
using System.Linq;
using System.Collections.Generic;
using AppFramework.Mapper.AutoMapper;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.ApplicationLayer.Assemblers
{

  public partial interface ISelectKmuVsAssembler : IAssembler<SelectKmuVsDto, SelectKmuVs>
  {
  }

  public partial class SelectKmuVsAssemblerBase : Assembler<SelectKmuVsDto, SelectKmuVs>
  {
      partial void OnDTOAssembled(SelectKmuVsDto dto);

      partial void OnEntityAssembled(SelectKmuVs entity);

      public override SelectKmuVs Assemble(SelectKmuVs entity, SelectKmuVsDto dto)
      {
          entity = Mapper.Map<SelectKmuVsDto, SelectKmuVs>(dto);
          this.OnEntityAssembled(entity);
          return entity;
      }

      public override SelectKmuVsDto Assemble(SelectKmuVs entity)
      {
          SelectKmuVsDto dto = Mapper.Map<SelectKmuVs, SelectKmuVsDto>(entity);
          this.OnDTOAssembled(dto);
          return dto;
      }
  }

  public partial class SelectKmuVsAssembler : SelectKmuVsAssemblerBase, ISelectKmuVsAssembler
  {
  }
}

