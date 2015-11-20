using System.Web.Mvc;
using Html2MarkdownConverter.Web.Controllers;
using NUnit.Framework;

namespace Html2MarkdownConverter.Web.Test.Controllers
{
	[TestFixture]
	class HomeControllerTest
	{
		[Test]
		public void Index_WhenCalled_ThenReturnViewResult()
		{
			var controller = CreateController();

			var result = controller.Index() as ViewResult;

			Assert.That(result, Is.Not.Null);
		}

		private static HomeController CreateController()
		{
			return new HomeController();
		}
	}
}
