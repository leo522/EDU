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
	public partial class EduPassportTemplateItem
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
		
		private string _templateID;
		public virtual string TemplateID
		{
			get
			{
				return this._templateID;
			}
			set
			{
				this._templateID = value;
			}
		}
		
		private string _itemID;
		public virtual string ItemID
		{
			get
			{
				return this._itemID;
			}
			set
			{
				this._itemID = value;
			}
		}
		
		private int? _seq;
		public virtual int? Seq
		{
			get
			{
				return this._seq;
			}
			set
			{
				this._seq = value;
			}
		}
		
		private string _title;
		public virtual string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
			}
		}
		
		private string _groupName;
		public virtual string GroupName
		{
			get
			{
				return this._groupName;
			}
			set
			{
				this._groupName = value;
			}
		}
		
		private EduPassportTemplate _eduPassportTemplate;
		public virtual EduPassportTemplate EduPassportTemplate
		{
			get
			{
				return this._eduPassportTemplate;
			}
			set
			{
				this._eduPassportTemplate = value;
			}
		}
		
		private EduPassportItem _eduPassportItem;
		public virtual EduPassportItem EduPassportItem
		{
			get
			{
				return this._eduPassportItem;
			}
			set
			{
				this._eduPassportItem = value;
			}
		}
		
	}
}
#pragma warning restore 1591
