using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Html2MarkdownConverter.Web.Models;

public class HtmlConversionViewModel
{
    [Required]
    [MinLength(10)]
    [Display(Name = "Html to Format")]
    [AllowHtml]
    public string Html { get; set; }

    public string Markdown { get; set; }
}