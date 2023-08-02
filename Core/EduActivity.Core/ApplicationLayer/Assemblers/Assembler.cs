using System;
using System.Linq;
using System.Collections.Generic;
using AppFramework.Mapper.AutoMapper;

namespace KMU.EduActivity.ApplicationLayer.Assemblers
{			
  public partial interface IAssembler<TDto, TEntity> where TEntity : class
  {
      TDto Assemble(TEntity entity);
      TEntity Assemble(TEntity entity, TDto dto);

      IEnumerable<TDto> Assemble(IEnumerable<TEntity> entityList);
      IEnumerable<TEntity> Assemble(IEnumerable<TDto> dtoList);
  }

  public abstract class Assembler<TDto, TEntity> : IAssembler<TDto, TEntity> where TEntity : class
  {
      public abstract TDto Assemble(TEntity domainEntity);
      public abstract TEntity Assemble(TEntity entity, TDto dto);

      public virtual IEnumerable<TDto> Assemble(IEnumerable<TEntity> domainEntityList)
      {
          List<TDto> dtos = Activator.CreateInstance<List<TDto>>();
          Mapper.CreateMap<TEntity, TDto>();
          foreach (TEntity domainEntity in domainEntityList)
          {
              dtos.Add(Assemble(domainEntity));
          }
          return dtos;
      }

      public virtual IEnumerable<TEntity> Assemble(IEnumerable<TDto> dtoList)
      {
          List<TEntity> domainEntities = Activator.CreateInstance<List<TEntity>>();
          Mapper.CreateMap<TDto, TEntity>();
          foreach (TDto dto in dtoList)
          {
              domainEntities.Add(Assemble(null, dto));
          }
          return domainEntities;
      }
  }
}

