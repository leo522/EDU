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
	public partial class OutstandindPerformance
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
		
		private string _applicationSource;
		public virtual string ApplicationSource
		{
			get
			{
				return this._applicationSource;
			}
			set
			{
				this._applicationSource = value;
			}
		}
		
		private string _competitionTheme;
		public virtual string CompetitionTheme
		{
			get
			{
				return this._competitionTheme;
			}
			set
			{
				this._competitionTheme = value;
			}
		}
		
		private string _organizer;
		public virtual string Organizer
		{
			get
			{
				return this._organizer;
			}
			set
			{
				this._organizer = value;
			}
		}
		
		private DateTime? _activeDates;
		public virtual DateTime? ActiveDates
		{
			get
			{
				return this._activeDates;
			}
			set
			{
				this._activeDates = value;
			}
		}
		
		private string _applicationType;
		public virtual string ApplicationType
		{
			get
			{
				return this._applicationType;
			}
			set
			{
				this._applicationType = value;
			}
		}
		
		private string _documentID;
		public virtual string DocumentID
		{
			get
			{
				return this._documentID;
			}
			set
			{
				this._documentID = value;
			}
		}
		
		private string _creator;
		public virtual string Creator
		{
			get
			{
				return this._creator;
			}
			set
			{
				this._creator = value;
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
		
		private string _reviewer;
		public virtual string Reviewer
		{
			get
			{
				return this._reviewer;
			}
			set
			{
				this._reviewer = value;
			}
		}
		
		private string _reviewSuggestion;
		public virtual string ReviewSuggestion
		{
			get
			{
				return this._reviewSuggestion;
			}
			set
			{
				this._reviewSuggestion = value;
			}
		}
		
		private string _result;
		public virtual string Result
		{
			get
			{
				return this._result;
			}
			set
			{
				this._result = value;
			}
		}
		
		private DateTime? _reviewTime;
		public virtual DateTime? ReviewTime
		{
			get
			{
				return this._reviewTime;
			}
			set
			{
				this._reviewTime = value;
			}
		}
		
		private string _lastEditor;
		public virtual string LastEditor
		{
			get
			{
				return this._lastEditor;
			}
			set
			{
				this._lastEditor = value;
			}
		}
		
		private DateTime? _lastEditorTime;
		public virtual DateTime? LastEditorTime
		{
			get
			{
				return this._lastEditorTime;
			}
			set
			{
				this._lastEditorTime = value;
			}
		}
		
		private IList<OutstandindAttendee> _outstandindAttendees = new List<OutstandindAttendee>();
		public virtual IList<OutstandindAttendee> OutstandindAttendees
		{
			get
			{
				return this._outstandindAttendees;
			}
		}
		
	}
}
#pragma warning restore 1591
