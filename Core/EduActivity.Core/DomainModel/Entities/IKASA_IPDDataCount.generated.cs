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
	public partial class IKASA_IPDDataCount
	{
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
		
		private DateTime _sDATE;
		public virtual DateTime SDATE
		{
			get
			{
				return this._sDATE;
			}
			set
			{
				this._sDATE = value;
			}
		}
		
		private DateTime _eDATE;
		public virtual DateTime EDATE
		{
			get
			{
				return this._eDATE;
			}
			set
			{
				this._eDATE = value;
			}
		}
		
		private int? _iPDNoteCount;
		public virtual int? IPDNoteCount
		{
			get
			{
				return this._iPDNoteCount;
			}
			set
			{
				this._iPDNoteCount = value;
			}
		}
		
		private int? _primaryCareCount;
		public virtual int? PrimaryCareCount
		{
			get
			{
				return this._primaryCareCount;
			}
			set
			{
				this._primaryCareCount = value;
			}
		}
		
		private decimal? _workHour;
		public virtual decimal? WorkHour
		{
			get
			{
				return this._workHour;
			}
			set
			{
				this._workHour = value;
			}
		}
		
	}
}
#pragma warning restore 1591
