using System;
using System.ComponentModel.DataAnnotations;

namespace KMU.EduActivity.DomainModel.Entities
{
  [MetadataType(typeof(SelectKmuDoctorMetadata))]
  public partial class SelectKmuDoctor
  {
  }

  public partial class SelectKmuDoctorMetadata
  {
      #region Properties

      /// <summary>
      /// code
      /// </summary>
      //[Display(Name = "code")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string code {get;set;}
      /// <summary>
      /// name
      /// </summary>
      //[Display(Name = "name")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string name {get;set;}
      /// <summary>
      /// deptname
      /// </summary>
      //[Display(Name = "deptname")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string deptname {get;set;}
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
      /// displayname
      /// </summary>
      //[Display(Name = "displayname")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string displayname {get;set;}

      #endregion Properties
  }

}

