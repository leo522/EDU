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
	public partial class OSCECert
	{
		private int _iD;
		public virtual int ID
		{
			get
			{
				return this._iD;
			}
			set
			{
				this._iD = value;
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
		
		private DateTime _sdate;
		public virtual DateTime Sdate
		{
			get
			{
				return this._sdate;
			}
			set
			{
				this._sdate = value;
			}
		}
		
		private DateTime _edate;
		public virtual DateTime Edate
		{
			get
			{
				return this._edate;
			}
			set
			{
				this._edate = value;
			}
		}
		
		private string _creater;
		public virtual string Creater
		{
			get
			{
				return this._creater;
			}
			set
			{
				this._creater = value;
			}
		}
		
		private DateTime _createDate;
		public virtual DateTime CreateDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				this._createDate = value;
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
		
		private string _remark;
		public virtual string Remark
		{
			get
			{
				return this._remark;
			}
			set
			{
				this._remark = value;
			}
		}
		
	}
}
#pragma warning restore 1591
