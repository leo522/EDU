using System;

namespace KMU.EduActivity.ApplicationLayer.DTO
{
  public partial class SelectEduActJobCodeDto : BaseDTOEntity
  {
      #region Properties

      /// <summary>
      /// 
      /// </summary>
      public string Code {get;set;}
      /// <summary>
      /// 
      /// </summary>
      public string Name {get;set;}
      /// <summary>
      /// 
      /// </summary>
      public string Des {get;set;}
      /// <summary>
      /// 
      /// </summary>
      public int? ShowSeq {get;set;}
      /// <summary>
      /// 
      /// </summary>
      public string Des2 {get;set;}
        
      #endregion Properties
  }

}

