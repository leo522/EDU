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
	public partial class EduPassportInsItemRejectHi
	{
		private int _rejectID;
		public virtual int RejectID
		{
			get
			{
				return this._rejectID;
			}
			set
			{
				this._rejectID = value;
			}
		}
		
		private string _iItemID;
		public virtual string IItemID
		{
			get
			{
				return this._iItemID;
			}
			set
			{
				this._iItemID = value;
			}
		}
		
		private DateTime? _rejectTime;
		public virtual DateTime? RejectTime
		{
			get
			{
				return this._rejectTime;
			}
			set
			{
				this._rejectTime = value;
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
		
		private string _reason;
		public virtual string Reason
		{
			get
			{
				return this._reason;
			}
			set
			{
				this._reason = value;
			}
		}
		
	}
}
#pragma warning restore 1591
