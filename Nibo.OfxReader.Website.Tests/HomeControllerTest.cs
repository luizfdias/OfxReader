using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nibo.OfxReader.Website.Controllers;
using Nibo.OfxReader.Website.Services.Interfaces;
using System.Web;
using System.Web.Mvc;

namespace Nibo.OfxReader.Website.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IBankStatementFileService> _bankStatementFileServiceMock;

        private Mock<HomeController> _homeController;

        [TestInitialize]
        public void SetupTest()
        {
            this._bankStatementFileServiceMock = new Mock<IBankStatementFileService>();

            this._bankStatementFileServiceMock.Setup(x => x.ProcessFileAsync(It.IsAny<string>())).ReturnsAsync(true);

            this._homeController = new Mock<HomeController>() { CallBase = true };

            this._homeController.Setup(x => x.BankStatementFileService).Returns(this._bankStatementFileServiceMock.Object);
        }

        [TestMethod]
        public void Index_DeveRetornarErroSeArquivoForDeUmFormatoInvalido()
        {                        
            var homeController = this._homeController.Object;

            var fileMock = new Mock<HttpPostedFileBase>();
            fileMock.Setup(x => x.FileName).Returns("Teste.TXT");
            fileMock.Setup(x => x.ContentLength).Returns(100);

            var viewResult = homeController.Index(fileMock.Object).Result as ViewResult;
            
            viewResult.ViewData.ModelState[""].Errors.Count.Should().BeGreaterThan(0);
            viewResult.ViewData.ModelState[""].Errors[0].ErrorMessage.Should().Be("Formato de arquivo inválido");
        }
    }

    public class FileTest : HttpPostedFileBase
    {

    }
}

