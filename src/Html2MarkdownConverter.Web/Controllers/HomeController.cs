using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
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

		[POST("converted")]
		[ValidateInput(false)]
	    public ViewResult Converted(HtmlConversionViewModel model)
		{
			string viewName;

			if (ModelState.IsValid)
			{
				var markdown = _converter.Convert(model.Html);
				model.Markdown = markdown;
				viewName = "Converted";
			}
			else
			{
				viewName = "Index";
			}

			return View(viewName, model);
		}

	    public ViewResult About()
	    {
		    return View();
	    }
    }
}
