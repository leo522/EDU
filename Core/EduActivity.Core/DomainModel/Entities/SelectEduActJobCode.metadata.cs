using System;
using System.ComponentModel.DataAnnotations;

namespace KMU.EduActivity.DomainModel.Entities
{
  [MetadataType(typeof(SelectEduActJobCodeMetadata))]
  public partial class SelectEduActJobCode
  {
  }

  public partial class SelectEduActJobCodeMetadata
  {
      #region Properties

      /// <summary>
      /// Code
      /// </summary>
      //[Display(Name = "Code")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string Code {get;set;}
      /// <summary>
      /// Name
      /// </summary>
      //[Display(Name = "Name")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string Name {get;set;}
      /// <summary>
      /// Des
      /// </summary>
      //[Display(Name = "Des")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string Des {get;set;}
      /// <summary>
      /// ShowSeq
      /// </summary>
      //[Display(Name = "ShowSeq")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual int? ShowSeq {get;set;}
      /// <summary>
      /// Des2
      /// </summary>
      //[Display(Name = "Des2")]
      //[Editable(false)]
      //[DisplayFormat()]
      //[Required(ErrorMessage = "")]
      //[Range(0, 100)]
      //[StringLength(20, ErrorMessage = "")]
      public virtual string Des2 {get;set;}

      #endregion Properties
  }

}

