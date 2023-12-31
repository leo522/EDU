﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using KMUH.EduForm.DomainModel.Entities;

namespace KMUH.EduForm.DomainModel.Entities	
{
	public partial class EduFormContext : OpenAccessContext, IEduFormContextUnitOfWork
	{
		private static string connectionStringName = @"EduForm";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EduFormDiagrams.rlinq");
		
		public EduFormContext()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public EduFormContext(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public EduFormContext(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public EduFormContext(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public EduFormContext(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<FORM_INSTANCE> FORM_INSTANCEs 
		{
			get
			{
				return this.GetAll<FORM_INSTANCE>();
			}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MsSql";
			backend.ProviderName = "System.Data.SqlClient";
			backend.Logging.MetricStoreSnapshotInterval = 0;
			backend.ConnectionPool.Pool = ConnectionPoolType.ADO;
			return backend;
		}
	}
	
	public interface IEduFormContextUnitOfWork : IUnitOfWork
	{
		IQueryable<FORM_INSTANCE> FORM_INSTANCEs
		{
			get;
		}
	}
}
#pragma warning restore 1591
