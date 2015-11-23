using System.ComponentModel.DataAnnotations;

namespace Html2MarkdownConverter.Web.Models
{
	public class HtmlConversionViewModel
	{
		[Required]
		[MinLength(10)]
		[Display(Name = "Html to Format")]
		public string Html { get; set; }

		public string Markdown { get; set; }
	}
}