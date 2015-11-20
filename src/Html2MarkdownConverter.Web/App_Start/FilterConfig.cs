using System.Web;
using System.Web.Mvc;

namespace Html2MarkdownConverter.Web
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}