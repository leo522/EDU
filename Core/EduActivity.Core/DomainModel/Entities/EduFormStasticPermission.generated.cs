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
	public partial class EduFormStasticPermission
	{
		private int _tEMPLATE_ID;
		public virtual int TEMPLATE_ID
		{
			get
			{
				return this._tEMPLATE_ID;
			}
			set
			{
				this._tEMPLATE_ID = value;
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
		
		private bool _enable;
		public virtual bool Enable
		{
			get
			{
				return this._enable;
			}
			set
			{
				this._enable = value;
			}
		}
		
	}
}
#pragma warning restore 1591
