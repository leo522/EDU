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
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.DomainModel.Entities	
{
	public partial class ScoreSettingScoreType
	{
		private int _typeID;
		public virtual int TypeID
		{
			get
			{
				return this._typeID;
			}
			set
			{
				this._typeID = value;
			}
		}
		
		private string _settingID;
		public virtual string SettingID
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
		
		private string _typeName;
		public virtual string TypeName
		{
			get
			{
				return this._typeName;
			}
			set
			{
				this._typeName = value;
			}
		}
		
		private decimal? _typePercent;
		public virtual decimal? TypePercent
		{
			get
			{
				return this._typePercent;
			}
			set
			{
				this._typePercent = value;
			}
		}
		
		private ScoreSetting _scoreSetting;
		public virtual ScoreSetting ScoreSetting
		{
			get
			{
				return this._scoreSetting;
			}
			set
			{
				this._scoreSetting = value;
			}
		}
		
	}
}
#pragma warning restore 1591