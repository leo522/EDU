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
	public partial class TeachTimeType
	{
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
		
		private bool _needAttachment;
		public virtual bool NeedAttachment
		{
			get
			{
				return this._needAttachment;
			}
			set
			{
				this._needAttachment = value;
			}
		}
		
		private bool _needMember;
		public virtual bool NeedMember
		{
			get
			{
				return this._needMember;
			}
			set
			{
				this._needMember = value;
			}
		}
		
		private string _disable;
		public virtual string Disable
		{
			get
			{
				return this._disable;
			}
			set
			{
				this._disable = value;
			}
		}
		
		private bool _loadFormData;
		public virtual bool LoadFormData
		{
			get
			{
				return this._loadFormData;
			}
			set
			{
				this._loadFormData = value;
			}
		}
		
		private bool _allowKPI;
		public virtual bool AllowKPI
		{
			get
			{
				return this._allowKPI;
			}
			set
			{
				this._allowKPI = value;
			}
		}
		
	}
}
#pragma warning restore 1591
