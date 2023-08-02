using System;
using System.Linq;
using System.Collections.Generic;
using AppFramework.Mapper.AutoMapper;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.ApplicationLayer.Assemblers
{

  public partial interface ISelectVKmuempAssembler : IAssembler<SelectVKmuempDto, SelectVKmuemp>
  {
  }

  public partial class SelectVKmuempAssemblerBase : Assembler<SelectVKmuempDto, SelectVKmuemp>
  {
      partial void OnDTOAssembled(SelectVKmuempDto dto);

      partial void OnEntityAssembled(SelectVKmuemp entity);

      public override SelectVKmuemp Assemble(SelectVKmuemp entity, SelectVKmuempDto dto)
      {
          entity = Mapper.Map<SelectVKmuempDto, SelectVKmuemp>(dto);
          this.OnEntityAssembled(entity);
          return entity;
      }

      public override SelectVKmuempDto Assemble(SelectVKmuemp entity)
      {
          SelectVKmuempDto dto = Mapper.Map<SelectVKmuemp, SelectVKmuempDto>(entity);
          this.OnDTOAssembled(dto);
          return dto;
      }
  }

  public partial class SelectVKmuempAssembler : SelectVKmuempAssemblerBase, ISelectVKmuempAssembler
  {
  }
}

