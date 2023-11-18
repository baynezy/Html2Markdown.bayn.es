using Html2MarkdownConverter.Web.Models;
using Html2MarkdownConverter.Web.Models.Converter;
using Microsoft.AspNetCore.Mvc;

namespace Html2MarkdownConverter.Web.Controllers;

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

    [HttpPost("converted")]
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