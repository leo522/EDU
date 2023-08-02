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
	public partial class FORM_INSTANCE
	{
		private int _iNSTANCE_ID;
		public virtual int INSTANCE_ID
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
		
		private string _iNSTANCE_NAME;
		public virtual string INSTANCE_NAME
		{
			get
			{
				return this._iNSTANCE_NAME;
			}
			set
			{
				this._iNSTANCE_NAME = value;
			}
		}
		
		private DateTime _iNSTANCE_CREATE_DATETIME;
		public virtual DateTime INSTANCE_CREATE_DATETIME
		{
			get
			{
				return this._iNSTANCE_CREATE_DATETIME;
			}
			set
			{
				this._iNSTANCE_CREATE_DATETIME = value;
			}
		}
		
		private DateTime? _iNSTANCE_ALTER_DATETIME;
		public virtual DateTime? INSTANCE_ALTER_DATETIME
		{
			get
			{
				return this._iNSTANCE_ALTER_DATETIME;
			}
			set
			{
				this._iNSTANCE_ALTER_DATETIME = value;
			}
		}
		
		private string _iNSTANCE_REMARK;
		public virtual string INSTANCE_REMARK
		{
			get
			{
				return this._iNSTANCE_REMARK;
			}
			set
			{
				this._iNSTANCE_REMARK = value;
			}
		}
		
		private string _iNSTANCE_CONTENT;
		public virtual string INSTANCE_CONTENT
		{
			get
			{
				return this._iNSTANCE_CONTENT;
			}
			set
			{
				this._iNSTANCE_CONTENT = value;
			}
		}
		
		private string _iNHOSPID;
		public virtual string INHOSPID
		{
			get
			{
				return this._iNHOSPID;
			}
			set
			{
				this._iNHOSPID = value;
			}
		}
		
		private string _cREATER;
		public virtual string CREATER
		{
			get
			{
				return this._cREATER;
			}
			set
			{
				this._cREATER = value;
			}
		}
		
		private DateTime? _expireDate;
		public virtual DateTime? ExpireDate
		{
			get
			{
				return this._expireDate;
			}
			set
			{
				this._expireDate = value;
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
		
		private Char _status;
		public virtual Char Status
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
		
		private int? _pARENT_INSTANCE_ID;
		public virtual int? PARENT_INSTANCE_ID
		{
			get
			{
				return this._pARENT_INSTANCE_ID;
			}
			set
			{
				this._pARENT_INSTANCE_ID = value;
			}
		}
		
		private string _evalTargetID;
		public virtual string EvalTargetID
		{
			get
			{
				return this._evalTargetID;
			}
			set
			{
				this._evalTargetID = value;
			}
		}
		
		private bool? _isPass;
		public virtual bool? IsPass
		{
			get
			{
				return this._isPass;
			}
			set
			{
				this._isPass = value;
			}
		}
		
		private DateTime? _readDate;
		public virtual DateTime? ReadDate
		{
			get
			{
				return this._readDate;
			}
			set
			{
				this._readDate = value;
			}
		}
		
		private FORM_TEMPLATE _fORM_TEMPLATE;
		public virtual FORM_TEMPLATE FORM_TEMPLATE
		{
			get
			{
				return this._fORM_TEMPLATE;
			}
			set
			{
				this._fORM_TEMPLATE = value;
			}
		}
		
		private IList<FORM_INSTANCE_TARGET> _fORM_INSTANCE_TARGETs = new List<FORM_INSTANCE_TARGET>();
		public virtual IList<FORM_INSTANCE_TARGET> FORM_INSTANCE_TARGETs
		{
			get
			{
				return this._fORM_INSTANCE_TARGETs;
			}
		}
		
		private IList<FORM_INSTANCE_ATTACHMENT> _fORM_INSTANCE_ATTACHMENTs = new List<FORM_INSTANCE_ATTACHMENT>();
		public virtual IList<FORM_INSTANCE_ATTACHMENT> FORM_INSTANCE_ATTACHMENTs
		{
			get
			{
				return this._fORM_INSTANCE_ATTACHMENTs;
			}
		}
		
	}
}
#pragma warning restore 1591