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
	public partial class RecordInstance
	{
		private string _instanceID;
		public virtual string InstanceID
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
		
		private int _templateID;
		public virtual int TemplateID
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
		
		private DateTime? _sdate;
		public virtual DateTime? Sdate
		{
			get
			{
				return this._sdate;
			}
			set
			{
				this._sdate = value;
			}
		}
		
		private DateTime? _edate;
		public virtual DateTime? Edate
		{
			get
			{
				return this._edate;
			}
			set
			{
				this._edate = value;
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
		
		private DateTime _createDate;
		public virtual DateTime CreateDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				this._createDate = value;
			}
		}
		
		private string _viewer;
		public virtual string Viewer
		{
			get
			{
				return this._viewer;
			}
			set
			{
				this._viewer = value;
			}
		}
		
		private DateTime? _viewDate;
		public virtual DateTime? ViewDate
		{
			get
			{
				return this._viewDate;
			}
			set
			{
				this._viewDate = value;
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
		
		private string _status;
		public virtual string Status
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
		
		private string _hospCode;
		public virtual string HospCode
		{
			get
			{
				return this._hospCode;
			}
			set
			{
				this._hospCode = value;
			}
		}
		
		private string _deptCode;
		public virtual string DeptCode
		{
			get
			{
				return this._deptCode;
			}
			set
			{
				this._deptCode = value;
			}
		}
		
		private string _recoder;
		public virtual string Recoder
		{
			get
			{
				return this._recoder;
			}
			set
			{
				this._recoder = value;
			}
		}
		
		private bool _isPublic;
		public virtual bool IsPublic
		{
			get
			{
				return this._isPublic;
			}
			set
			{
				this._isPublic = value;
			}
		}
		
		private string _signMethod;
		public virtual string SignMethod
		{
			get
			{
				return this._signMethod;
			}
			set
			{
				this._signMethod = value;
			}
		}
		
		private RecordTemplate _recordTemplate;
		public virtual RecordTemplate RecordTemplate
		{
			get
			{
				return this._recordTemplate;
			}
			set
			{
				this._recordTemplate = value;
			}
		}
		
		private IList<RecordInsDet> _recordInsDets = new List<RecordInsDet>();
		public virtual IList<RecordInsDet> RecordInsDets
		{
			get
			{
				return this._recordInsDets;
			}
		}
		
		private IList<RecordInsSignIn> _recordInsSignIns = new List<RecordInsSignIn>();
		public virtual IList<RecordInsSignIn> RecordInsSignIns
		{
			get
			{
				return this._recordInsSignIns;
			}
		}
		
		private IList<RecordEduActRef> _recordEduActRefs = new List<RecordEduActRef>();
		public virtual IList<RecordEduActRef> RecordEduActRefs
		{
			get
			{
				return this._recordEduActRefs;
			}
		}
		
		private IList<RecordInsReader> _recordInsReaders = new List<RecordInsReader>();
		public virtual IList<RecordInsReader> RecordInsReaders
		{
			get
			{
				return this._recordInsReaders;
			}
		}
		
		private IList<RecordInsViewer> _recordInsViewers = new List<RecordInsViewer>();
		public virtual IList<RecordInsViewer> RecordInsViewers
		{
			get
			{
				return this._recordInsViewers;
			}
		}
		
	}
}
#pragma warning restore 1591
