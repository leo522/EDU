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

namespace KMU.EduActivity.DomainModel.Entities	
{
	public partial class EduActTypeRoleRef
	{
		private int _actType;
		public virtual int ActType
		{
			get
			{
				return this._actType;
			}
			set
			{
				this._actType = value;
			}
		}
		
		private string _roleID;
		public virtual string RoleID
		{
			get
			{
				return this._roleID;
			}
			set
			{
				this._roleID = value;
			}
		}
		
		private DateTime? _enableDate;
		public virtual DateTime? EnableDate
		{
			get
			{
				return this._enableDate;
			}
			set
			{
				this._enableDate = value;
			}
		}
		
		private DateTime? _disableDate;
		public virtual DateTime? DisableDate
		{
			get
			{
				return this._disableDate;
			}
			set
			{
				this._disableDate = value;
			}
		}
		
		private string _status;
		public virtual string Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}
		
	}
}
#pragma warning restore 1591
