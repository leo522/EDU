using System;

namespace KMU.EduActivity.ApplicationLayer.DTO
{
    [Serializable]
  public partial class SelectActTypeDto : BaseDTOEntity
  {
      #region Properties

      /// <summary>
      /// 
      /// </summary>
      public string code {get;set;}
      /// <summary>
      /// 
      /// </summary>
      public string name {get;set;}
        
      #endregion Properties
  }

}

