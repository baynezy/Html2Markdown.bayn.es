using System.Reflection;

namespace Html2MarkdownConverter.Web.Models.MetaData
{
	public class Meta : IMeta
	{
		public string AppVersion()
		{
			var assembly = Assembly.GetCallingAssembly();
			var version = assembly.GetName().Version;
			return version.ToString();
		}
	}
}