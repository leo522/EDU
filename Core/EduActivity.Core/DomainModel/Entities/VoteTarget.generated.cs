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
	public partial class VoteTarget
	{
		private int _mainID;
		public virtual int MainID
		{
			get
			{
				return this._mainID;
			}
			set
			{
				this._mainID = value;
			}
		}
		
		private string _targetType;
		public virtual string TargetType
		{
			get
			{
				return this._targetType;
			}
			set
			{
				this._targetType = value;
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
		
		private VoteMain _voteMain;
		public virtual VoteMain VoteMain
		{
			get
			{
				return this._voteMain;
			}
			set
			{
				this._voteMain = value;
			}
		}
		
	}
}
#pragma warning restore 1591
