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
	public partial class EduStopActSchedule
	{
		private string _eduStopActScheduleID;
		public virtual string EduStopActScheduleID
		{
			get
			{
				return this._eduStopActScheduleID;
			}
			set
			{
				this._eduStopActScheduleID = value;
			}
		}
		
		private string _eduActTopicID;
		public virtual string EduActTopicID
		{
			get
			{
				return this._eduActTopicID;
			}
			set
			{
				this._eduActTopicID = value;
			}
		}
		
		private DateTime _timeFrom;
		public virtual DateTime TimeFrom
		{
			get
			{
				return this._timeFrom;
			}
			set
			{
				this._timeFrom = value;
			}
		}
		
		private DateTime _timeTo;
		public virtual DateTime TimeTo
		{
			get
			{
				return this._timeTo;
			}
			set
			{
				this._timeTo = value;
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
		
		private string _actType;
		public virtual string ActType
		{
			get
			{
				return this._actType;
			}
			set
			{
				this._actType = value;
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
		
		private string _location;
		public virtual string Location
		{
			get
			{
				return this._location;
			}
			set
			{
				this._location = value;
			}
		}
		
		private string _corchID;
		public virtual string CorchID
		{
			get
			{
				return this._corchID;
			}
			set
			{
				this._corchID = value;
			}
		}
		
		private string _actTypeDes;
		public virtual string ActTypeDes
		{
			get
			{
				return this._actTypeDes;
			}
			set
			{
				this._actTypeDes = value;
			}
		}
		
		private string _lastModifier;
		public virtual string LastModifier
		{
			get
			{
				return this._lastModifier;
			}
			set
			{
				this._lastModifier = value;
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
		
		private string _actName;
		public virtual string ActName
		{
			get
			{
				return this._actName;
			}
			set
			{
				this._actName = value;
			}
		}
		
		private string _refUrl;
		public virtual string RefUrl
		{
			get
			{
				return this._refUrl;
			}
			set
			{
				this._refUrl = value;
			}
		}
		
		private DateTime? _displayTimeTo;
		public virtual DateTime? DisplayTimeTo
		{
			get
			{
				return this._displayTimeTo;
			}
			set
			{
				this._displayTimeTo = value;
			}
		}
		
		private DateTime? _displayTimeFrom;
		public virtual DateTime? DisplayTimeFrom
		{
			get
			{
				return this._displayTimeFrom;
			}
			set
			{
				this._displayTimeFrom = value;
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
		
		private string _actRange;
		public virtual string ActRange
		{
			get
			{
				return this._actRange;
			}
			set
			{
				this._actRange = value;
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
		
		private string _propertyType;
		public virtual string PropertyType
		{
			get
			{
				return this._propertyType;
			}
			set
			{
				this._propertyType = value;
			}
		}
		
		private bool _allowBooking;
		public virtual bool AllowBooking
		{
			get
			{
				return this._allowBooking;
			}
			set
			{
				this._allowBooking = value;
			}
		}
		
		private int? _bookingLimit;
		public virtual int? BookingLimit
		{
			get
			{
				return this._bookingLimit;
			}
			set
			{
				this._bookingLimit = value;
			}
		}
		
		private bool _hasOutSideStudent;
		public virtual bool HasOutSideStudent
		{
			get
			{
				return this._hasOutSideStudent;
			}
			set
			{
				this._hasOutSideStudent = value;
			}
		}
		
		private bool? _enableRec;
		public virtual bool? EnableRec
		{
			get
			{
				return this._enableRec;
			}
			set
			{
				this._enableRec = value;
			}
		}
		
		private int? _recTemplateID;
		public virtual int? RecTemplateID
		{
			get
			{
				return this._recTemplateID;
			}
			set
			{
				this._recTemplateID = value;
			}
		}
		
		private bool _hasTargets;
		public virtual bool HasTargets
		{
			get
			{
				return this._hasTargets;
			}
			set
			{
				this._hasTargets = value;
			}
		}
		
		private bool _hasAttachments;
		public virtual bool HasAttachments
		{
			get
			{
				return this._hasAttachments;
			}
			set
			{
				this._hasAttachments = value;
			}
		}
		
		private IList<EduActTarget> _eduActTargets = new List<EduActTarget>();
		public virtual IList<EduActTarget> EduActTargets
		{
			get
			{
				return this._eduActTargets;
			}
		}
		
		private IList<EduStopActAttachment> _eduStopActAttachments = new List<EduStopActAttachment>();
		public virtual IList<EduStopActAttachment> EduStopActAttachments
		{
			get
			{
				return this._eduStopActAttachments;
			}
		}
		
		private IList<EduActViewTarget> _eduActViewTargets = new List<EduActViewTarget>();
		public virtual IList<EduActViewTarget> EduActViewTargets
		{
			get
			{
				return this._eduActViewTargets;
			}
		}
		
		private IList<EduActTypeRef> _eduActTypeRefs = new List<EduActTypeRef>();
		public virtual IList<EduActTypeRef> EduActTypeRefs
		{
			get
			{
				return this._eduActTypeRefs;
			}
		}
		
	}
}
#pragma warning restore 1591