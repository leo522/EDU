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
	public partial class IKASA_UploadFile
	{
		private string _iD;
		public virtual string ID
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
		
		private string _fileName;
		public virtual string FileName
		{
			get
			{
				return this._fileName;
			}
			set
			{
				this._fileName = value;
			}
		}
		
		private string _displayTitle;
		public virtual string DisplayTitle
		{
			get
			{
				return this._displayTitle;
			}
			set
			{
				this._displayTitle = value;
			}
		}
		
		private string _description;
		public virtual string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				this._description = value;
			}
		}
		
		private string _filePath;
		public virtual string FilePath
		{
			get
			{
				return this._filePath;
			}
			set
			{
				this._filePath = value;
			}
		}
		
		private string _fileCategory;
		public virtual string FileCategory
		{
			get
			{
				return this._fileCategory;
			}
			set
			{
				this._fileCategory = value;
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
		
		private DateTime? _deleteTime;
		public virtual DateTime? DeleteTime
		{
			get
			{
				return this._deleteTime;
			}
			set
			{
				this._deleteTime = value;
			}
		}
		
	}
}
#pragma warning restore 1591