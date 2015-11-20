using System.Web.Mvc;
using Html2MarkdownConverter.Web.Models;
using Html2MarkdownConverter.Web.Models.Converter;

namespace Html2MarkdownConverter.Web.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IConverter _converter;

	    public HomeController(IConverter converter)
		{
			_converter = converter;
		}

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
				var markdown = _converter.Convert(model.Html);
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
