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
	public partial class EduTermFormReq
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
		
		private string _eduTermID;
		public virtual string EduTermID
		{
			get
			{
				return this._eduTermID;
			}
			set
			{
				this._eduTermID = value;
			}
		}
		
		private string _reqType;
		public virtual string ReqType
		{
			get
			{
				return this._reqType;
			}
			set
			{
				this._reqType = value;
			}
		}
		
		private int _reqID;
		public virtual int ReqID
		{
			get
			{
				return this._reqID;
			}
			set
			{
				this._reqID = value;
			}
		}
		
		private int _reqCount;
		public virtual int ReqCount
		{
			get
			{
				return this._reqCount;
			}
			set
			{
				this._reqCount = value;
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
		
		private bool _needPass;
		public virtual bool NeedPass
		{
			get
			{
				return this._needPass;
			}
			set
			{
				this._needPass = value;
			}
		}
		
	}
}
#pragma warning restore 1591
