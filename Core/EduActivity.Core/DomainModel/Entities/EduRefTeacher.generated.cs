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
	public partial class EduRefTeacher
	{
		private int _eduRefTeacherID;
		public virtual int EduRefTeacherID
		{
			get
			{
				return this._eduRefTeacherID;
			}
			set
			{
				this._eduRefTeacherID = value;
			}
		}
		
		private string _teacherID;
		public virtual string TeacherID
		{
			get
			{
				return this._teacherID;
			}
			set
			{
				this._teacherID = value;
			}
		}
		
		private string _teacherType;
		public virtual string TeacherType
		{
			get
			{
				return this._teacherType;
			}
			set
			{
				this._teacherType = value;
			}
		}
		
		private string _refID;
		public virtual string RefID
		{
			get
			{
				return this._refID;
			}
			set
			{
				this._refID = value;
			}
		}
		
		private string _refTable;
		public virtual string RefTable
		{
			get
			{
				return this._refTable;
			}
			set
			{
				this._refTable = value;
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
		
		private string _createEmp;
		public virtual string CreateEmp
		{
			get
			{
				return this._createEmp;
			}
			set
			{
				this._createEmp = value;
			}
		}
		
		private DateTime? _createDate;
		public virtual DateTime? CreateDate
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
		
		private int? _teacherOrder;
		public virtual int? TeacherOrder
		{
			get
			{
				return this._teacherOrder;
			}
			set
			{
				this._teacherOrder = value;
			}
		}
		
	}
}
#pragma warning restore 1591
