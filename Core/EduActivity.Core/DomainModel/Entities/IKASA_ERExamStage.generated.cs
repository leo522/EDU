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
	public partial class IKASA_ERExamStage
	{
		private string _examID;
		public virtual string ExamID
		{
			get
			{
				return this._examID;
			}
			set
			{
				this._examID = value;
			}
		}
		
		private int _stageNo;
		public virtual int StageNo
		{
			get
			{
				return this._stageNo;
			}
			set
			{
				this._stageNo = value;
			}
		}
		
		private string _stageName;
		public virtual string StageName
		{
			get
			{
				return this._stageName;
			}
			set
			{
				this._stageName = value;
			}
		}
		
		private decimal? _passScore;
		public virtual decimal? PassScore
		{
			get
			{
				return this._passScore;
			}
			set
			{
				this._passScore = value;
			}
		}
		
		private IKASA_ERExam _iKASA_ERExam;
		public virtual IKASA_ERExam IKASA_ERExam
		{
			get
			{
				return this._iKASA_ERExam;
			}
			set
			{
				this._iKASA_ERExam = value;
			}
		}
		
	}
}
#pragma warning restore 1591
