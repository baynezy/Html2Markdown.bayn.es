using Html2MarkdownConverter.Web.Models.MetaData;
using NUnit.Framework;

namespace Html2MarkdownConverter.Web.Test.Models.MetaData
{
	[TestFixture]
	class MetaTest
	{
		[Test]
		public void Meta_Implements_IMeta()
		{
			var meta = CreateMeta();

			Assert.That(meta, Is.InstanceOf<IMeta>());
		}

		private static Meta CreateMeta()
		{
			return new Meta();
		}
	}
}
