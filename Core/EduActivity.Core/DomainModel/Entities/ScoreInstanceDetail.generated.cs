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
	public partial class ScoreInstanceDetail
	{
		private int _instanceDetailID;
		public virtual int InstanceDetailID
		{
			get
			{
				return this._instanceDetailID;
			}
			set
			{
				this._instanceDetailID = value;
			}
		}
		
		private string _instanceID;
		public virtual string InstanceID
		{
			get
			{
				return this._instanceID;
			}
			set
			{
				this._instanceID = value;
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
		
		private string _valueType;
		public virtual string ValueType
		{
			get
			{
				return this._valueType;
			}
			set
			{
				this._valueType = value;
			}
		}
		
		private string _valueID;
		public virtual string ValueID
		{
			get
			{
				return this._valueID;
			}
			set
			{
				this._valueID = value;
			}
		}
		
		private string _targetID;
		public virtual string TargetID
		{
			get
			{
				return this._targetID;
			}
			set
			{
				this._targetID = value;
			}
		}
		
		private decimal? _score;
		public virtual decimal? Score
		{
			get
			{
				return this._score;
			}
			set
			{
				this._score = value;
			}
		}
		
		private string _modifier;
		public virtual string Modifier
		{
			get
			{
				return this._modifier;
			}
			set
			{
				this._modifier = value;
			}
		}
		
		private DateTime? _modifyDate;
		public virtual DateTime? ModifyDate
		{
			get
			{
				return this._modifyDate;
			}
			set
			{
				this._modifyDate = value;
			}
		}
		
		private decimal? _scorePercent;
		public virtual decimal? ScorePercent
		{
			get
			{
				return this._scorePercent;
			}
			set
			{
				this._scorePercent = value;
			}
		}
		
		private ScoreInstance _scoreInstance;
		public virtual ScoreInstance ScoreInstance
		{
			get
			{
				return this._scoreInstance;
			}
			set
			{
				this._scoreInstance = value;
			}
		}
		
	}
}
#pragma warning restore 1591