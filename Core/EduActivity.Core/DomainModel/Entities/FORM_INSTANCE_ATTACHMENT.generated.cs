#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
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
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.DomainModel.Entities	
{
	public partial class FORM_INSTANCE_ATTACHMENT
	{
		private string _aTTACHMENT_ID;
		public virtual string ATTACHMENT_ID
		{
			get
			{
				return this._aTTACHMENT_ID;
			}
			set
			{
				this._aTTACHMENT_ID = value;
			}
		}
		
		private int? _iNSTANCE_ID;
		public virtual int? INSTANCE_ID
		{
			get
			{
				return this._iNSTANCE_ID;
			}
			set
			{
				this._iNSTANCE_ID = value;
			}
		}
		
		private byte[] _aTTACHMENT;
		public virtual byte[] ATTACHMENT
		{
			get
			{
				return this._aTTACHMENT;
			}
			set
			{
				this._aTTACHMENT = value;
			}
		}
		
		private string _name;
		public virtual string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		
		private string _fileName;
		public virtual string FileName
		{
			get
			{
				return this._fileName;
			}
			set
			{
				this._fileName = value;
			}
		}
		
		private FORM_INSTANCE _fORM_INSTANCE;
		public virtual FORM_INSTANCE FORM_INSTANCE
		{
			get
			{
				return this._fORM_INSTANCE;
			}
			set
			{
				this._fORM_INSTANCE = value;
			}
		}
		
	}
}
#pragma warning restore 1591