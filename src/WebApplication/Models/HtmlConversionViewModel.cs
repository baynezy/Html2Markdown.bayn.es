using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models;

public class HtmlConversionViewModel
{
    [Required]
    [MinLength(10)]
    public string Html { get; set; } = string.Empty;

    public string Markdown { get; set; } = string.Empty;
}