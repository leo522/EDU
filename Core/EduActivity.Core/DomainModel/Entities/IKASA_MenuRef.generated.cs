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
	public partial class IKASA_MenuRef
	{
		private string _menuid;
		public virtual string Menuid
		{
			get
			{
				return this._menuid;
			}
			set
			{
				this._menuid = value;
			}
		}
		
		private string _topteamcode;
		public virtual string Topteamcode
		{
			get
			{
				return this._topteamcode;
			}
			set
			{
				this._topteamcode = value;
			}
		}
		
		private string _dept_code;
		public virtual string Dept_code
		{
			get
			{
				return this._dept_code;
			}
			set
			{
				this._dept_code = value;
			}
		}
		
		private int _refid;
		public virtual int Refid
		{
			get
			{
				return this._refid;
			}
			set
			{
				this._refid = value;
			}
		}
		
		private string _membertype;
		public virtual string Membertype
		{
			get
			{
				return this._membertype;
			}
			set
			{
				this._membertype = value;
			}
		}
		
	}
}
#pragma warning restore 1591