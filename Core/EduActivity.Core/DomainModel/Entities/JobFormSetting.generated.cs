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
	public partial class JobFormSetting
	{
		private string _jobCode;
		public virtual string JobCode
		{
			get
			{
				return this._jobCode;
			}
			set
			{
				this._jobCode = value;
			}
		}
		
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
		
		private int? _dISPLAY_ORDER;
		public virtual int? DISPLAY_ORDER
		{
			get
			{
				return this._dISPLAY_ORDER;
			}
			set
			{
				this._dISPLAY_ORDER = value;
			}
		}
		
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
		
	}
}
#pragma warning restore 1591
