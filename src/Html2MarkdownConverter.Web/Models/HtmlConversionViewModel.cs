using System.ComponentModel.DataAnnotations;

namespace Html2MarkdownConverter.Web.Models
{
	public class HtmlConversionViewModel
	{
		[Required]
		[MinLength(10)]
		public string Html { get; set; }
	}
}