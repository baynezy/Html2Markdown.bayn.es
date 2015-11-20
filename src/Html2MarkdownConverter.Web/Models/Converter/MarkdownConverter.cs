namespace Html2MarkdownConverter.Web.Models.Converter
{
	public class MarkdownConverter : IConverter
	{
		private readonly Html2Markdown.Converter _converter;

		public MarkdownConverter()
		{
			_converter = new Html2Markdown.Converter();

		}
		public string Convert(string html)
		{
			return _converter.Convert(html);
		}
	}
}