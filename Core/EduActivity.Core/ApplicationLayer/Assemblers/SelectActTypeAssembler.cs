using System;
using System.Linq;
using System.Collections.Generic;
using AppFramework.Mapper.AutoMapper;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.ApplicationLayer.Assemblers
{

  public partial interface ISelectActTypeAssembler : IAssembler<SelectActTypeDto, SelectActType>
  {
  }

  public partial class SelectActTypeAssemblerBase : Assembler<SelectActTypeDto, SelectActType>
  {
      partial void OnDTOAssembled(SelectActTypeDto dto);

      partial void OnEntityAssembled(SelectActType entity);

      public override SelectActType Assemble(SelectActType entity, SelectActTypeDto dto)
      {
          entity = Mapper.Map<SelectActTypeDto, SelectActType>(dto);
          this.OnEntityAssembled(entity);
          return entity;
      }

      public override SelectActTypeDto Assemble(SelectActType entity)
      {
          SelectActTypeDto dto = Mapper.Map<SelectActType, SelectActTypeDto>(entity);
          this.OnDTOAssembled(dto);
          return dto;
      }
  }

  public partial class SelectActTypeAssembler : SelectActTypeAssemblerBase, ISelectActTypeAssembler
  {
  }
}

