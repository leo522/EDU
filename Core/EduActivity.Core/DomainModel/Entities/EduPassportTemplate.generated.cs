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
	public partial class EduPassportTemplate
	{
		private string _templateID;
		public virtual string TemplateID
		{
			get
			{
				return this._templateID;
			}
			set
			{
				this._templateID = value;
			}
		}
		
		private string _templateName;
		public virtual string TemplateName
		{
			get
			{
				return this._templateName;
			}
			set
			{
				this._templateName = value;
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
		
		private DateTime? _createdate;
		public virtual DateTime? Createdate
		{
			get
			{
				return this._createdate;
			}
			set
			{
				this._createdate = value;
			}
		}
		
		private string _modifier;
		public virtual string Modifier
		{
			get
			{
				return this._modifier;
			}
			set
			{
				this._modifier = value;
			}
		}
		
		private DateTime? _modifydate;
		public virtual DateTime? Modifydate
		{
			get
			{
				return this._modifydate;
			}
			set
			{
				this._modifydate = value;
			}
		}
		
		private string _templateDesc;
		public virtual string TemplateDesc
		{
			get
			{
				return this._templateDesc;
			}
			set
			{
				this._templateDesc = value;
			}
		}
		
		private bool _allowAdminConfirm;
		public virtual bool AllowAdminConfirm
		{
			get
			{
				return this._allowAdminConfirm;
			}
			set
			{
				this._allowAdminConfirm = value;
			}
		}
		
		private IList<EduPassportTemplateItem> _eduPassportTemplateItems = new List<EduPassportTemplateItem>();
		public virtual IList<EduPassportTemplateItem> EduPassportTemplateItems
		{
			get
			{
				return this._eduPassportTemplateItems;
			}
		}
		
		private IList<EduPassportTemplateTarget> _eduPassportTemplateTargets = new List<EduPassportTemplateTarget>();
		public virtual IList<EduPassportTemplateTarget> EduPassportTemplateTargets
		{
			get
			{
				return this._eduPassportTemplateTargets;
			}
		}
		
	}
}
#pragma warning restore 1591