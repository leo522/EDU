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
	public partial class EduStopActAttachment
	{
		private string _actAttachmentID;
		public virtual string ActAttachmentID
		{
			get
			{
				return this._actAttachmentID;
			}
			set
			{
				this._actAttachmentID = value;
			}
		}
		
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
		
		private byte[] _attachment;
		public virtual byte[] Attachment
		{
			get
			{
				return this._attachment;
			}
			set
			{
				this._attachment = value;
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
		
		private EduStopActSchedule _eduStopActSchedule;
		public virtual EduStopActSchedule EduStopActSchedule
		{
			get
			{
				return this._eduStopActSchedule;
			}
			set
			{
				this._eduStopActSchedule = value;
			}
		}
		
	}
}
#pragma warning restore 1591
