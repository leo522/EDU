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
	public partial class f_EduStopActScheduleResultSet01
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
		
		private DateTime? _timeFrom;
		public virtual DateTime? TimeFrom
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
		
		private DateTime? _timeto;
		public virtual DateTime? Timeto
		{
			get
			{
				return this._timeto;
			}
			set
			{
				this._timeto = value;
			}
		}
		
		private string _eduActTopicCode;
		public virtual string EduActTopicCode
		{
			get
			{
				return this._eduActTopicCode;
			}
			set
			{
				this._eduActTopicCode = value;
			}
		}
		
		private string _eduActTopicName;
		public virtual string EduActTopicName
		{
			get
			{
				return this._eduActTopicName;
			}
			set
			{
				this._eduActTopicName = value;
			}
		}
		
		private string _eduStopCode;
		public virtual string EduStopCode
		{
			get
			{
				return this._eduStopCode;
			}
			set
			{
				this._eduStopCode = value;
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
		
	}
}
#pragma warning restore 1591
