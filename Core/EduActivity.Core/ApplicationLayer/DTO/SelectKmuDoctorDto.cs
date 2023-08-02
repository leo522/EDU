using System;

namespace KMU.EduActivity.ApplicationLayer.DTO
{
  public partial class SelectKmuDoctorDto : BaseDTOEntity
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
      /// <summary>
      /// 
      /// </summary>
      public string deptname {get;set;}
      /// <summary>
      /// 
      /// </summary>
      public string deptcode {get;set;}
      /// <summary>
      /// 
      /// </summary>
      public string displayname {get;set;}
        
      #endregion Properties
  }

}

