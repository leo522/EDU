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
	public partial class PassPortJobTitleItem
	{
		private string _jobTitleCode;
		public virtual string JobTitleCode
		{
			get
			{
				return this._jobTitleCode;
			}
			set
			{
				this._jobTitleCode = value;
			}
		}
		
		private int _itemCode;
		public virtual int ItemCode
		{
			get
			{
				return this._itemCode;
			}
			set
			{
				this._itemCode = value;
			}
		}
		
		private string _authorizeLevel;
		public virtual string AuthorizeLevel
		{
			get
			{
				return this._authorizeLevel;
			}
			set
			{
				this._authorizeLevel = value;
			}
		}
		
		private int? _authenticateFrequency;
		public virtual int? AuthenticateFrequency
		{
			get
			{
				return this._authenticateFrequency;
			}
			set
			{
				this._authenticateFrequency = value;
			}
		}
		
		private bool? _isNeedFinalCheck;
		public virtual bool? IsNeedFinalCheck
		{
			get
			{
				return this._isNeedFinalCheck;
			}
			set
			{
				this._isNeedFinalCheck = value;
			}
		}
		
		private string _exAuthorizeLevel;
		public virtual string ExAuthorizeLevel
		{
			get
			{
				return this._exAuthorizeLevel;
			}
			set
			{
				this._exAuthorizeLevel = value;
			}
		}
		
		private PassPortCheckItem _passPortCheckItem;
		public virtual PassPortCheckItem PassPortCheckItem
		{
			get
			{
				return this._passPortCheckItem;
			}
			set
			{
				this._passPortCheckItem = value;
			}
		}
		
	}
}
#pragma warning restore 1591
