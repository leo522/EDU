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
	public partial class ElearningEmpItemLog
	{
		private string _itemID;
		public virtual string ItemID
		{
			get
			{
				return this._itemID;
			}
			set
			{
				this._itemID = value;
			}
		}
		
		private string _empCode;
		public virtual string EmpCode
		{
			get
			{
				return this._empCode;
			}
			set
			{
				this._empCode = value;
			}
		}
		
		private string _refID;
		public virtual string RefID
		{
			get
			{
				return this._refID;
			}
			set
			{
				this._refID = value;
			}
		}
		
		private DateTime? _executeTime;
		public virtual DateTime? ExecuteTime
		{
			get
			{
				return this._executeTime;
			}
			set
			{
				this._executeTime = value;
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
		
		private int? _executeTimes;
		public virtual int? ExecuteTimes
		{
			get
			{
				return this._executeTimes;
			}
			set
			{
				this._executeTimes = value;
			}
		}
		
	}
}
#pragma warning restore 1591
