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
	public partial class FORM_TEMPLATE_ELEMENT
	{
		private string _tEMPLATE_ELEMENT_ID;
		public virtual string TEMPLATE_ELEMENT_ID
		{
			get
			{
				return this._tEMPLATE_ELEMENT_ID;
			}
			set
			{
				this._tEMPLATE_ELEMENT_ID = value;
			}
		}
		
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
		
		private string _iD;
		public virtual string ID
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
		
		private string _nAME;
		public virtual string NAME
		{
			get
			{
				return this._nAME;
			}
			set
			{
				this._nAME = value;
			}
		}
		
		private string _cONTROL_TYPE;
		public virtual string CONTROL_TYPE
		{
			get
			{
				return this._cONTROL_TYPE;
			}
			set
			{
				this._cONTROL_TYPE = value;
			}
		}
		
		private string _dATA_TYPE;
		public virtual string DATA_TYPE
		{
			get
			{
				return this._dATA_TYPE;
			}
			set
			{
				this._dATA_TYPE = value;
			}
		}
		
		private double? _pOINTS;
		public virtual double? POINTS
		{
			get
			{
				return this._pOINTS;
			}
			set
			{
				this._pOINTS = value;
			}
		}
		
		private string _dISPLAY_NAME;
		public virtual string DISPLAY_NAME
		{
			get
			{
				return this._dISPLAY_NAME;
			}
			set
			{
				this._dISPLAY_NAME = value;
			}
		}
		
		private int? _gROUP_ID;
		public virtual int? GROUP_ID
		{
			get
			{
				return this._gROUP_ID;
			}
			set
			{
				this._gROUP_ID = value;
			}
		}
		
		private double? _mAXPOINT;
		public virtual double? MAXPOINT
		{
			get
			{
				return this._mAXPOINT;
			}
			set
			{
				this._mAXPOINT = value;
			}
		}
		
		private bool _iSHIDE;
		public virtual bool ISHIDE
		{
			get
			{
				return this._iSHIDE;
			}
			set
			{
				this._iSHIDE = value;
			}
		}
		
		private string _bINDVALUE;
		public virtual string BINDVALUE
		{
			get
			{
				return this._bINDVALUE;
			}
			set
			{
				this._bINDVALUE = value;
			}
		}
		
		private string _bINDSQL;
		public virtual string BINDSQL
		{
			get
			{
				return this._bINDSQL;
			}
			set
			{
				this._bINDSQL = value;
			}
		}
		
		private bool _aLLOWOVER;
		public virtual bool ALLOWOVER
		{
			get
			{
				return this._aLLOWOVER;
			}
			set
			{
				this._aLLOWOVER = value;
			}
		}
		
		private int? _minTextCount;
		public virtual int? MinTextCount
		{
			get
			{
				return this._minTextCount;
			}
			set
			{
				this._minTextCount = value;
			}
		}
		
		private int? _maxTextCount;
		public virtual int? MaxTextCount
		{
			get
			{
				return this._maxTextCount;
			}
			set
			{
				this._maxTextCount = value;
			}
		}
		
	}
}
#pragma warning restore 1591
