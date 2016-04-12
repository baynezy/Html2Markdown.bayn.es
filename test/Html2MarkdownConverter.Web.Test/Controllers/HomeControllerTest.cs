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
		#region Index GET

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

		#endregion


		#region Converted POST

		#region Valid Model
		[Test]
		public void Converted_WhenModelValid_ThenReturnViewResult()
		{
			var controller = CreateController();
			var model = ValidModel();

			ValidateModel(model, controller);

			var result = controller.Converted(model);

			Assert.That(result, Is.InstanceOf<ViewResult>());
		}

		[Test]
		public void Converted_WhenModelValid_ThenReturnCorrectView()
		{
			var controller = CreateController();
			var model = ValidModel();

			ValidateModel(model, controller);

			var result = controller.Converted(model);

			Assert.That(result.ViewName, Is.EqualTo("Converted"));
		}

		[Test]
		public void Converted_WhenModelValid_ThenPassModelToView()
		{
			var controller = CreateController();
			var model = ValidModel();

			ValidateModel(model, controller);

			var result = controller.Converted(model);

			Assert.That(result.Model, Is.EqualTo(model));
		}

		[Test]
		public void Converted_WhenModelValid_ThenCallIConverterConvert()
		{
			var model = ValidModel();
			var mockConverter = new Mock<IConverter>();
			mockConverter.Setup(m => m.Convert(model.Html)).Returns("some *markdown*");

			var controller = CreateController(mockConverter.Object);

			ValidateModel(model, controller);

			controller.Converted(model);

			mockConverter.Verify(f => f.Convert(model.Html), Times.Once);
		}

		[Test]
		public void Converted_WhenModelValid_ThenPopulateMarkdownOfModelWithValueReturnedFromIConverterConvert()
		{
			var model = ValidModel();
			const string markdown = "some *markdown*";
			var mockConverter = new Mock<IConverter>();
			mockConverter.Setup(m => m.Convert(model.Html)).Returns(markdown);

			var controller = CreateController(mockConverter.Object);

			ValidateModel(model, controller);

			controller.Converted(model);

			Assert.That(model.Markdown, Is.EqualTo(markdown));
		}

		#endregion

		#region Invalid Model
		[Test]
		public void Converted_WhenModelInvalid_ThenReturnViewResult()
		{
			var controller = CreateController();
			var model = InvalidModel();

			ValidateModel(model, controller);

			var result = controller.Converted(model);

			Assert.That(result, Is.InstanceOf<ViewResult>());
		}

		[Test]
		public void Converted_WhenModelInvalid_ThenReturnCorrectView()
		{
			var controller = CreateController();
			var model = InvalidModel();

			ValidateModel(model, controller);

			var result = controller.Converted(model);

			Assert.That(result.ViewName, Is.EqualTo("Index"));
		}

		[Test]
		public void Converted_WhenModelInvalid_ThenPassModelToView()
		{
			var controller = CreateController();
			var model = InvalidModel();

			ValidateModel(model, controller);

			var result = controller.Converted(model);

			Assert.That(result.Model, Is.EqualTo(model));
		}

		#endregion

		#endregion

		#region About
		[Test]
		public void About_WhenCalled_ThenReturnViewResult()
		{
			var controller = CreateController();

			var result = controller.About();

			Assert.That(result, Is.InstanceOf<ViewResult>());
		}

		[Test]
		public void About_WhenCalled__ThenReturnCorrectView()
		{
			var controller = CreateController();

			var result = controller.About();

			Assert.That(result.ViewName, Is.EqualTo(""));
		}
		#endregion

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
