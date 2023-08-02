using System.Linq;
using NUnit.Framework;
using KMUH.EduForm.ApplicationLayer.DTO;
using KMUH.EduForm.ApplicationLayer.Services;

namespace KMUH.EduForm.UnitTests
{
  [TestFixture]
  public partial class EduFormAppServiceTests
  {
      private IEduFormAppService service;

      [TestFixtureSetUp]
      public void CreateService()
      {
          service = new EduFormAppService ();
      }

      [TestFixtureTearDown]
      public void DisposeService()
      {
          service.Dispose();
      }

      [Test]
      [Ignore()]
      [Category("EduForm Application Layer")]
      public void YourBusinessMethodTest()
      {

      }
  }
}