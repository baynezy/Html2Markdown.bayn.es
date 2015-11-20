using System.Web.Mvc;
using Html2MarkdownConverter.Web.Models;

namespace Html2MarkdownConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

		[HttpPost]
	    public ViewResult Index(HtmlConversionViewModel model)
		{
			string viewName;

			if (ModelState.IsValid)
			{
				viewName = "Converted";
			}
			else
			{
				viewName = "Index";
			}

			return View(viewName);
		}
    }
}
