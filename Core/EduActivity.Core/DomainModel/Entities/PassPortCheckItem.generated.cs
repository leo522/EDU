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
	public partial class PassPortCheckItem
	{
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
		
		private string _itemName;
		public virtual string ItemName
		{
			get
			{
				return this._itemName;
			}
			set
			{
				this._itemName = value;
			}
		}
		
		private string _createdMan;
		public virtual string CreatedMan
		{
			get
			{
				return this._createdMan;
			}
			set
			{
				this._createdMan = value;
			}
		}
		
		private DateTime? _createdTime;
		public virtual DateTime? CreatedTime
		{
			get
			{
				return this._createdTime;
			}
			set
			{
				this._createdTime = value;
			}
		}
		
		private string _topTeamCode;
		public virtual string TopTeamCode
		{
			get
			{
				return this._topTeamCode;
			}
			set
			{
				this._topTeamCode = value;
			}
		}
		
		private IList<PassPortStudentApplicationItem> _passPortStudentApplicationItems = new List<PassPortStudentApplicationItem>();
		public virtual IList<PassPortStudentApplicationItem> PassPortStudentApplicationItems
		{
			get
			{
				return this._passPortStudentApplicationItems;
			}
		}
		
		private IList<PassPortJobTitleItem> _passPortJobTitleItems = new List<PassPortJobTitleItem>();
		public virtual IList<PassPortJobTitleItem> PassPortJobTitleItems
		{
			get
			{
				return this._passPortJobTitleItems;
			}
		}
		
		private IList<PassPortStudentApplicationItemFailLog> _passPortStudentApplicationItemFailLogs = new List<PassPortStudentApplicationItemFailLog>();
		public virtual IList<PassPortStudentApplicationItemFailLog> PassPortStudentApplicationItemFailLogs
		{
			get
			{
				return this._passPortStudentApplicationItemFailLogs;
			}
		}
		
	}
}
#pragma warning restore 1591