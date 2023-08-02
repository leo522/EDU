using System;
using System.Linq;
using System.Collections.Generic;
using AppFramework.Mapper.AutoMapper;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.ApplicationLayer.Assemblers
{

  public partial interface ISelectGroupTypeAssembler : IAssembler<SelectGroupTypeDto, SelectGroupType>
  {
  }

  public partial class SelectGroupTypeAssemblerBase : Assembler<SelectGroupTypeDto, SelectGroupType>
  {
      partial void OnDTOAssembled(SelectGroupTypeDto dto);

      partial void OnEntityAssembled(SelectGroupType entity);

      public override SelectGroupType Assemble(SelectGroupType entity, SelectGroupTypeDto dto)
      {
          entity = Mapper.Map<SelectGroupTypeDto, SelectGroupType>(dto);
          this.OnEntityAssembled(entity);
          return entity;
      }

      public override SelectGroupTypeDto Assemble(SelectGroupType entity)
      {
          SelectGroupTypeDto dto = Mapper.Map<SelectGroupType, SelectGroupTypeDto>(entity);
          this.OnDTOAssembled(dto);
          return dto;
      }
  }

  public partial class SelectGroupTypeAssembler : SelectGroupTypeAssemblerBase, ISelectGroupTypeAssembler
  {
  }
}

