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
	public partial class EduSetting
	{
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
		
		private string _code;
		public virtual string Code
		{
			get
			{
				return this._code;
			}
			set
			{
				this._code = value;
			}
		}
		
		private string _name;
		public virtual string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		
		private string _settingValue;
		public virtual string SettingValue
		{
			get
			{
				return this._settingValue;
			}
			set
			{
				this._settingValue = value;
			}
		}
		
		private string _des;
		public virtual string Des
		{
			get
			{
				return this._des;
			}
			set
			{
				this._des = value;
			}
		}
		
	}
}
#pragma warning restore 1591
