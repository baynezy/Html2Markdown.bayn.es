using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Html2MarkdownConverter.Web.Controllers;
using Html2MarkdownConverter.Web.Models;
using Html2MarkdownConverter.Web.Models.Converter;
using Moq;
using NUnit.Framework;

namespace Html2MarkdownConverter.Web.Test.Controllers
{
	[TestFixture]
	class HomeControllerTest
	{
		[Test]
		public void Index_WhenCalled_ThenReturnViewResult()
		{
			var controller = CreateController();

			var result = controller.Index();

			Assert.That(result, Is.InstanceOf<ViewResult>());
		}

		[Test]
		public void Index_WhenCalled_ThenReturnCorrectViewName()
		{
			var controller = CreateController();

			var result = controller.Index();

			Assert.That(result.ViewName, Is.EqualTo(""));
		}

		[Test]
		public void Index_WhenModelValid_ThenReturnViewResult()
		{
			var controller = CreateController();
			var model = ValidModel();

			ValidateModel(model, controller);

			var result = controller.Index(model);

			Assert.That(result, Is.InstanceOf<ViewResult>());
		}

		[Test]
		public void Index_WhenModelValid_ThenReturnCorrectView()
		{
			var controller = CreateController();
			var model = ValidModel();

			ValidateModel(model, controller);

			var result = controller.Index(model);

			Assert.That(result.ViewName, Is.EqualTo("Converted"));
		}

		[Test]
		public void Index_WhenModelValid_ThenCallIConverterConvert()
		{
			var model = ValidModel();
			var mockConverter = new Mock<IConverter>();
			mockConverter.Setup(m => m.Convert(model.Html)).Returns("some *markdown*");

			var controller = CreateController(mockConverter.Object);

			ValidateModel(model, controller);

			controller.Index(model);

			mockConverter.Verify(f => f.Convert(model.Html), Times.Once);
		}

		[Test]
		public void Index_WhenModelInvalid_ThenReturnViewResult()
		{
			var controller = CreateController();
			var model = InvalidModel();

			ValidateModel(model, controller);

			var result = controller.Index(model);

			Assert.That(result, Is.InstanceOf<ViewResult>());
		}

		[Test]
		public void Index_WhenModelInvalid_ThenReturnCorrectView()
		{
			var controller = CreateController();
			var model = InvalidModel();

			ValidateModel(model, controller);

			var result = controller.Index(model);

			Assert.That(result.ViewName, Is.EqualTo("Index"));
		}

		private static void ValidateModel(object model, Controller controller)
		{
			var validationContext = new ValidationContext(model, null, null);
			var validationResults = new List<ValidationResult>();
			Validator.TryValidateObject(model, validationContext, validationResults);

			foreach (var validationResult in validationResults)
			{
				controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
			}
		}

		private static HtmlConversionViewModel ValidModel()
		{
			return new HtmlConversionViewModel
				{
					Html = @"This needs <strong>converting</strong>."
				};
		}

		private static HtmlConversionViewModel InvalidModel()
		{
			return new HtmlConversionViewModel();
		}

		private static HomeController CreateController(IConverter converter = null)
		{
			return new HomeController(converter ?? new Mock<IConverter>().Object);
		}
	}
}
