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
	public partial class EduPassportItemDet
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
		
		private string _fieldDesc;
		public virtual string FieldDesc
		{
			get
			{
				return this._fieldDesc;
			}
			set
			{
				this._fieldDesc = value;
			}
		}
		
		private string _fieldTarget;
		public virtual string FieldTarget
		{
			get
			{
				return this._fieldTarget;
			}
			set
			{
				this._fieldTarget = value;
			}
		}
		
		private int _seq;
		public virtual int Seq
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
		
		private string _fieldType;
		public virtual string FieldType
		{
			get
			{
				return this._fieldType;
			}
			set
			{
				this._fieldType = value;
			}
		}
		
		private bool _isNecessary;
		public virtual bool IsNecessary
		{
			get
			{
				return this._isNecessary;
			}
			set
			{
				this._isNecessary = value;
			}
		}
		
		private string _selectOptions;
		public virtual string SelectOptions
		{
			get
			{
				return this._selectOptions;
			}
			set
			{
				this._selectOptions = value;
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