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
	public partial class TeachTimeRate
	{
		private int _settingID;
		public virtual int SettingID
		{
			get
			{
				return this._settingID;
			}
			set
			{
				this._settingID = value;
			}
		}
		
		private string _settingType;
		public virtual string SettingType
		{
			get
			{
				return this._settingType;
			}
			set
			{
				this._settingType = value;
			}
		}
		
		private string _settingCode;
		public virtual string SettingCode
		{
			get
			{
				return this._settingCode;
			}
			set
			{
				this._settingCode = value;
			}
		}
		
		private string _codeType;
		public virtual string CodeType
		{
			get
			{
				return this._codeType;
			}
			set
			{
				this._codeType = value;
			}
		}
		
		private int? _rate1;
		public virtual int? Rate1
		{
			get
			{
				return this._rate1;
			}
			set
			{
				this._rate1 = value;
			}
		}
		
		private int? _rate2;
		public virtual int? Rate2
		{
			get
			{
				return this._rate2;
			}
			set
			{
				this._rate2 = value;
			}
		}
		
		private string _unit;
		public virtual string Unit
		{
			get
			{
				return this._unit;
			}
			set
			{
				this._unit = value;
			}
		}
		
		private int? _refID;
		public virtual int? RefID
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
		
	}
}
#pragma warning restore 1591