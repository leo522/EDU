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
	public partial class EduTeamMemberRundown
	{
		private string _eduTeamMemberID;
		public virtual string EduTeamMemberID
		{
			get
			{
				return this._eduTeamMemberID;
			}
			set
			{
				this._eduTeamMemberID = value;
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
		
		private string _memberID;
		public virtual string MemberID
		{
			get
			{
				return this._memberID;
			}
			set
			{
				this._memberID = value;
			}
		}
		
		private string _memberCode;
		public virtual string MemberCode
		{
			get
			{
				return this._memberCode;
			}
			set
			{
				this._memberCode = value;
			}
		}
		
		private string _coachID;
		public virtual string CoachID
		{
			get
			{
				return this._coachID;
			}
			set
			{
				this._coachID = value;
			}
		}
		
	}
}
#pragma warning restore 1591