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
	public partial class VoteMain
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
		
		private string _voteName;
		public virtual string VoteName
		{
			get
			{
				return this._voteName;
			}
			set
			{
				this._voteName = value;
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
		
		private string _voteType;
		public virtual string VoteType
		{
			get
			{
				return this._voteType;
			}
			set
			{
				this._voteType = value;
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
		
		private string _header;
		public virtual string Header
		{
			get
			{
				return this._header;
			}
			set
			{
				this._header = value;
			}
		}
		
		private IList<VoteGroup> _voteGroups = new List<VoteGroup>();
		public virtual IList<VoteGroup> VoteGroups
		{
			get
			{
				return this._voteGroups;
			}
		}
		
		private IList<VoteJob> _voteJobs = new List<VoteJob>();
		public virtual IList<VoteJob> VoteJobs
		{
			get
			{
				return this._voteJobs;
			}
		}
		
		private IList<VoteTarget> _voteTargets = new List<VoteTarget>();
		public virtual IList<VoteTarget> VoteTargets
		{
			get
			{
				return this._voteTargets;
			}
		}
		
	}
}
#pragma warning restore 1591
