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
	public partial class VoteGCond
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
		
		private int _groupID;
		public virtual int GroupID
		{
			get
			{
				return this._groupID;
			}
			set
			{
				this._groupID = value;
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
		
		private string _condType;
		public virtual string CondType
		{
			get
			{
				return this._condType;
			}
			set
			{
				this._condType = value;
			}
		}
		
		private VoteGroup _voteGroup;
		public virtual VoteGroup VoteGroup
		{
			get
			{
				return this._voteGroup;
			}
			set
			{
				this._voteGroup = value;
			}
		}
		
	}
}
#pragma warning restore 1591