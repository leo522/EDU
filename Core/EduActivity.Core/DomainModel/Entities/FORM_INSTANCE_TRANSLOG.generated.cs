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
	public partial class FORM_INSTANCE_TRANSLOG
	{
		private int _lOG_ID;
		public virtual int LOG_ID
		{
			get
			{
				return this._lOG_ID;
			}
			set
			{
				this._lOG_ID = value;
			}
		}
		
		private int? _iNSTANCE_ID;
		public virtual int? INSTANCE_ID
		{
			get
			{
				return this._iNSTANCE_ID;
			}
			set
			{
				this._iNSTANCE_ID = value;
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
		
		private string _modifyType;
		public virtual string ModifyType
		{
			get
			{
				return this._modifyType;
			}
			set
			{
				this._modifyType = value;
			}
		}
		
		private string _oldValue;
		public virtual string OldValue
		{
			get
			{
				return this._oldValue;
			}
			set
			{
				this._oldValue = value;
			}
		}
		
		private string _newValue;
		public virtual string NewValue
		{
			get
			{
				return this._newValue;
			}
			set
			{
				this._newValue = value;
			}
		}
		
	}
}
#pragma warning restore 1591
