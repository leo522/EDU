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
	public partial class PassPortDocGrade
	{
		private string _titleCode;
		public virtual string TitleCode
		{
			get
			{
				return this._titleCode;
			}
			set
			{
				this._titleCode = value;
			}
		}
		
		private int? _grade;
		public virtual int? Grade
		{
			get
			{
				return this._grade;
			}
			set
			{
				this._grade = value;
			}
		}
		
	}
}
#pragma warning restore 1591
