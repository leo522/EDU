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
	public partial class VoteInsDet
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
		
		private int _instanceID;
		public virtual int InstanceID
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
		
		private string _value;
		public virtual string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}
		
		private string _text;
		public virtual string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				this._text = value;
			}
		}
		
	}
}
#pragma warning restore 1591