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
	public partial class TrainingTime
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
		
		private int? _semester;
		public virtual int? Semester
		{
			get
			{
				return this._semester;
			}
			set
			{
				this._semester = value;
			}
		}
		
		private string _hospital;
		public virtual string Hospital
		{
			get
			{
				return this._hospital;
			}
			set
			{
				this._hospital = value;
			}
		}
		
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
		
		private string _role;
		public virtual string Role
		{
			get
			{
				return this._role;
			}
			set
			{
				this._role = value;
			}
		}
		
		private DateTime? _trainingTime1;
		public virtual DateTime? TrainingTime1
		{
			get
			{
				return this._trainingTime1;
			}
			set
			{
				this._trainingTime1 = value;
			}
		}
		
		private decimal? _timeHour;
		public virtual decimal? TimeHour
		{
			get
			{
				return this._timeHour;
			}
			set
			{
				this._timeHour = value;
			}
		}
		
		private string _className;
		public virtual string ClassName
		{
			get
			{
				return this._className;
			}
			set
			{
				this._className = value;
			}
		}
		
		private string _classType;
		public virtual string ClassType
		{
			get
			{
				return this._classType;
			}
			set
			{
				this._classType = value;
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
		
	}
}
#pragma warning restore 1591
