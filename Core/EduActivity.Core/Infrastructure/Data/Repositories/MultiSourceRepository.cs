using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Telerik.OpenAccess;
using KMU.EduActivity.DomainModel.Entities;


namespace KMU.EduActivity.Infrastructure.Data.Repositories
{
      internal class DbConnectionSource
      {
          public string Name { get; set; }
          public string ConnectionString { get; set; }
          public bool Enabled { get; set; }
      }

      public partial class MultiSourceRepository<TEntity> : IRepository<TEntity> where TEntity : class
      {
          protected IUnitOfWork unitOfWork;

          public MultiSourceRepository(IUnitOfWork unitOfWork)
          {
              this.unitOfWork = unitOfWork;
          }

          public void Add(TEntity entity)
          {
              throw new NotImplementedException();
          }

          public void Remove(TEntity entity)
          {
              throw new NotImplementedException();
          }

          public virtual IQueryable<TEntity> GetAll()
          {
              throw new NotImplementedException();
          }

          public TEntity Get(ObjectKey objectKey)
          {
              throw new NotImplementedException();
          }

          public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
          {
              throw new NotImplementedException();
          }

          public IEnumerable<TEntity> GetAll(string commandText, params System.Data.Common.DbParameter[] dbParameters)
          {
              List<DbConnectionSource> connectionSources = new List<DbConnectionSource>();
              var conn1 = new DbConnectionSource() { Name = "Id1", ConnectionString = "", Enabled = false };
              var conn2 = new DbConnectionSource() { Name = "Id2", ConnectionString = "", Enabled = false };
              connectionSources.Add(conn1);
              connectionSources.Add(conn2);

              List<TEntity> list = new List<TEntity>();
              foreach (var connectionSource in connectionSources)
              {
                  if (!connectionSource.Enabled)
                      continue;

                  using (var context = new EduActivityContext (connectionSource.ConnectionString))
                  {
                      if (dbParameters.Length == 0)
                          list.AddRange(context.ExecuteQuery<TEntity>(commandText));
                      else
                          list.AddRange(context.ExecuteQuery<TEntity>(commandText, dbParameters));
                  }
              }
              return list;
          }

          public bool Exists()
          {
              bool success = true;
              return success;
          }
      }
}

