using System;
using System.Collections.Generic;
using KMU.EduActivity.DomainModel.Entities;

namespace KMU.EduActivity.DomainModel.Factories
{
  /// <summary>
  /// This is the factory for SelectActType creation, which means that the main purpose
  /// is to encapsulate the creation knowledge.
  /// What is created is a transient entity instance, with nothing being said about persistence as yet
  /// </summary>
  public static class SelectActTypeFactory
  {
      public static SelectActType Create()
      {
          var instance = new SelectActType ();

          return instance;
      }

  }
}

