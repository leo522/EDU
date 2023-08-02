using System;
using System.Linq;
using System.Collections.Generic;
using AppFramework.Mapper.AutoMapper;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.ApplicationLayer.Assemblers
{

  public partial interface ISelectKmuDoctorAssembler : IAssembler<SelectKmuDoctorDto, SelectKmuDoctor>
  {
  }

  public partial class SelectKmuDoctorAssemblerBase : Assembler<SelectKmuDoctorDto, SelectKmuDoctor>
  {
      partial void OnDTOAssembled(SelectKmuDoctorDto dto);

      partial void OnEntityAssembled(SelectKmuDoctor entity);

      public override SelectKmuDoctor Assemble(SelectKmuDoctor entity, SelectKmuDoctorDto dto)
      {
          entity = Mapper.Map<SelectKmuDoctorDto, SelectKmuDoctor>(dto);
          this.OnEntityAssembled(entity);
          return entity;
      }

      public override SelectKmuDoctorDto Assemble(SelectKmuDoctor entity)
      {
          SelectKmuDoctorDto dto = Mapper.Map<SelectKmuDoctor, SelectKmuDoctorDto>(entity);
          this.OnDTOAssembled(dto);
          return dto;
      }
  }

  public partial class SelectKmuDoctorAssembler : SelectKmuDoctorAssemblerBase, ISelectKmuDoctorAssembler
  {
  }
}

