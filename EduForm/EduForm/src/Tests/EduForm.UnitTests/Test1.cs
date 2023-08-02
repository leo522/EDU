using KMUH.EduForm.UnitTests.EduService;
using NUnit.Framework;
using KMU.EduActivity.ApplicationLayer.Services;

namespace KMUH.EduForm.UnitTests
{
	[TestFixture]
	public class Test1
	{
		[Test]
		public void ThisIsAnExampleTest()
		{
            using (var srv = new EduFormWCFServiceClient())
            {
                var time =  srv.Ping();


            }
		}
	}
}