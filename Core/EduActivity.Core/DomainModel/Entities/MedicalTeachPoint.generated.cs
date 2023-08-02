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
	public partial class MedicalTeachPoint
	{
		private string _empCode;
		public virtual string EmpCode
		{
			get
			{
				return this._empCode;
			}
			set
			{
				this._empCode = value;
			}
		}
		
		private DateTime _dataDate;
		public virtual DateTime DataDate
		{
			get
			{
				return this._dataDate;
			}
			set
			{
				this._dataDate = value;
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
		
		private decimal? _baseTeachPoint;
		public virtual decimal? BaseTeachPoint
		{
			get
			{
				return this._baseTeachPoint;
			}
			set
			{
				this._baseTeachPoint = value;
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
		
		private DateTime? _createTime;
		public virtual DateTime? CreateTime
		{
			get
			{
				return this._createTime;
			}
			set
			{
				this._createTime = value;
			}
		}
		
		private decimal? _baseRatio;
		public virtual decimal? BaseRatio
		{
			get
			{
				return this._baseRatio;
			}
			set
			{
				this._baseRatio = value;
			}
		}
		
		private decimal? _teacherPoint;
		public virtual decimal? TeacherPoint
		{
			get
			{
				return this._teacherPoint;
			}
			set
			{
				this._teacherPoint = value;
			}
		}
		
		private decimal? _sTrainPoint;
		public virtual decimal? STrainPoint
		{
			get
			{
				return this._sTrainPoint;
			}
			set
			{
				this._sTrainPoint = value;
			}
		}
		
		private string _remark;
		public virtual string Remark
		{
			get
			{
				return this._remark;
			}
			set
			{
				this._remark = value;
			}
		}
		
		private string _reviewStatus;
		public virtual string ReviewStatus
		{
			get
			{
				return this._reviewStatus;
			}
			set
			{
				this._reviewStatus = value;
			}
		}
		
	}
}
#pragma warning restore 1591