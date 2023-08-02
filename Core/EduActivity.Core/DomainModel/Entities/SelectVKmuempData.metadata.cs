using System;
using System.ComponentModel.DataAnnotations;

namespace KMU.EduActivity.DomainModel.Entities
{
  [MetadataType(typeof(SelectVKmuempDataMetadata))]
  public partial class SelectVKmuempData
  {
  }

  public partial class SelectVKmuempDataMetadata
  {
      #region Properties

      /// <summary>
      /// empcode
      /// </summary>
      //[Display(Name = "empcode")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string empcode {get;set;}
      /// <summary>
      /// empcode7
      /// </summary>
      //[Display(Name = "empcode7")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string empcode7 {get;set;}
      /// <summary>
      /// empname
      /// </summary>
      //[Display(Name = "empname")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string empname {get;set;}
      /// <summary>
      /// pwd
      /// </summary>
      //[Display(Name = "pwd")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string pwd {get;set;}
      /// <summary>
      /// hospcode
      /// </summary>
      //[Display(Name = "hospcode")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string hospcode {get;set;}
      /// <summary>
      /// hospname
      /// </summary>
      //[Display(Name = "hospname")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string hospname {get;set;}
      /// <summary>
      /// deptcode
      /// </summary>
      //[Display(Name = "deptcode")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string deptcode {get;set;}
      /// <summary>
      /// loccode
      /// </summary>
      //[Display(Name = "loccode")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string loccode {get;set;}
      /// <summary>
      /// groupstatus
      /// </summary>
      //[Display(Name = "groupstatus")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string groupstatus {get;set;}
      /// <summary>
      /// groupdept
      /// </summary>
      //[Display(Name = "groupdept")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string groupdept {get;set;}
      /// <summary>
      /// jobcode
      /// </summary>
      //[Display(Name = "jobcode")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string jobcode {get;set;}
      /// <summary>
      /// servedate
      /// </summary>
      //[Display(Name = "servedate")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual DateTime? servedate {get;set;}
      /// <summary>
      /// enddate
      /// </summary>
      //[Display(Name = "enddate")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual DateTime? enddate {get;set;}
      /// <summary>
      /// email
      /// </summary>
      //[Display(Name = "email")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string email {get;set;}

      #endregion Properties
  }

}

