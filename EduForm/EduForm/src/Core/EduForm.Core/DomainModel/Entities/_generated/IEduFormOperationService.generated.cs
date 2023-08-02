﻿

#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using AppFramework.Infrastructure.Data.Repositories;
using AppFramework.Specifications;
using KMUH.EduForm.ApplicationLayer.DTO;
using KMUH.EduForm.Infrastructure.Data.Repositories;
using KMUH.EduForm.DomainModel.Entities;

namespace KMUH.EduForm.ApplicationLayer.Services
{
	public partial interface IEduFormOperationService : IDisposable
	{


		IEduFormContextUnitOfWork UnitOfWork { get; set;}


		string ConnectionStringName { get; set; }


		EduFormContext DbContext { get; }


		int ExecuteNonQuery(string commandText, params System.Data.Common.DbParameter[] parameters);


		int ExecuteNonQuery(string commandText, System.Data.CommandType commandType, params System.Data.Common.DbParameter[] parameters);


		T ExecuteScalar<T>(string commandText, params System.Data.Common.DbParameter[] parameters);


		T ExecuteScalar<T>(string commandTextt, System.Data.CommandType commandType, params System.Data.Common.DbParameter[] parameters);


		IEnumerable<dynamic> ExecuteQuery(string commandText, params System.Data.Common.DbParameter[] parameters);


		IEnumerable<T> ExecuteQuery<T>(string commandText, params System.Data.Common.DbParameter[] parameters);


		IEnumerable<T> ExecuteQuery<T>(string commandText, System.Data.CommandType commandType, params System.Data.Common.DbParameter[] parameters);


		IEnumerable<T> ExecuteQueryByMultiSource<T>(List<DbConnectionSource> dbSources, string commandText, params System.Data.Common.DbParameter[] dbParameters) where T : class;


		IEnumerable<T> ExecuteQueryByMultiSource<T>(List<DbConnectionSource> dbSources, string dataSourcePropertyName, string commandText, params System.Data.Common.DbParameter[] dbParameters) where T : class;


		void FlushChanges();


		void FlushChanges(bool releaseMemory);


		string GenerateNewIdentity(string IdentityOwner);


		DateTime GetSysDate();


	}
}
#pragma warning restore 1591
