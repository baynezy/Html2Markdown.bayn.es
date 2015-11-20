namespace Html2MarkdownConverter.Web.Models.Converter
{
	public interface IConverter
	{
		string Convert(string html);
	}
}
