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
	public partial class EduFormTemplateList
	{
		private int _tEMPLATE_ID;
		public virtual int TEMPLATE_ID
		{
			get
			{
				return this._tEMPLATE_ID;
			}
			set
			{
				this._tEMPLATE_ID = value;
			}
		}
		
		private string _createSQL;
		public virtual string CreateSQL
		{
			get
			{
				return this._createSQL;
			}
			set
			{
				this._createSQL = value;
			}
		}
		
		private string _des;
		public virtual string Des
		{
			get
			{
				return this._des;
			}
			set
			{
				this._des = value;
			}
		}
		
		private string _name;
		public virtual string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		
		private DateTime _executeDate;
		public virtual DateTime ExecuteDate
		{
			get
			{
				return this._executeDate;
			}
			set
			{
				this._executeDate = value;
			}
		}
		
		private string _tempoType;
		public virtual string TempoType
		{
			get
			{
				return this._tempoType;
			}
			set
			{
				this._tempoType = value;
			}
		}
		
		private string _tempoSettings;
		public virtual string TempoSettings
		{
			get
			{
				return this._tempoSettings;
			}
			set
			{
				this._tempoSettings = value;
			}
		}
		
		private string _fTListID;
		public virtual string FTListID
		{
			get
			{
				return this._fTListID;
			}
			set
			{
				this._fTListID = value;
			}
		}
		
		private string _eduTermID;
		public virtual string EduTermID
		{
			get
			{
				return this._eduTermID;
			}
			set
			{
				this._eduTermID = value;
			}
		}
		
		private bool? _eachStudent;
		public virtual bool? EachStudent
		{
			get
			{
				return this._eachStudent;
			}
			set
			{
				this._eachStudent = value;
			}
		}
		
		private string _autoFTListID;
		public virtual string AutoFTListID
		{
			get
			{
				return this._autoFTListID;
			}
			set
			{
				this._autoFTListID = value;
			}
		}
		
		private System.Nullable<System.Char> _status;
		public virtual System.Nullable<System.Char> Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}
		
		private string _creater;
		public virtual string Creater
		{
			get
			{
				return this._creater;
			}
			set
			{
				this._creater = value;
			}
		}
		
		private string _sendOrderSetting;
		public virtual string SendOrderSetting
		{
			get
			{
				return this._sendOrderSetting;
			}
			set
			{
				this._sendOrderSetting = value;
			}
		}
		
		private string _eduYear;
		public virtual string EduYear
		{
			get
			{
				return this._eduYear;
			}
			set
			{
				this._eduYear = value;
			}
		}
		
		private string _sendMonth;
		public virtual string SendMonth
		{
			get
			{
				return this._sendMonth;
			}
			set
			{
				this._sendMonth = value;
			}
		}
		
		private string _uDStudent;
		public virtual string UDStudent
		{
			get
			{
				return this._uDStudent;
			}
			set
			{
				this._uDStudent = value;
			}
		}
		
	}
}
#pragma warning restore 1591
