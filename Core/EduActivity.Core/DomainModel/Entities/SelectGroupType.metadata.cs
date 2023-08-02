using System;
using System.ComponentModel.DataAnnotations;

namespace KMU.EduActivity.DomainModel.Entities
{
  [MetadataType(typeof(SelectGroupTypeMetadata))]
  public partial class SelectGroupType
  {
  }

  public partial class SelectGroupTypeMetadata
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

      #endregion Properties
  }

}

