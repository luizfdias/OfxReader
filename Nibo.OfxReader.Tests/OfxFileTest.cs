using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.IO;
using Nibo.OfxReader.Tests.Helpers;
using Nibo.OfxReader.Exceptions;

namespace Nibo.OfxReader.Tests
{
    [TestClass]
    public class OfxFileTest
    {
        private string _ofxFilePath;

        public OfxFileTest()
        {
            this._ofxFilePath = Path.Combine(Path.GetTempPath(), "OfxFiles");
        }

        [TestInitialize]
        public void SetupTest()
        {
            if (!Directory.Exists(this._ofxFilePath))
            {
                Directory.CreateDirectory(this._ofxFilePath);
            }
        }

        [TestMethod]
        public void Read_DeveLerArquivoOFXItau_DeveRetornarUmaBankAccount()
        {
            var fullFileName = Path.Combine(this._ofxFilePath, "Itau_OFX_" + Guid.NewGuid() + ".ofx");

            OfxFileCreater.Create(fullFileName, FileContent.GetItauFileContent());

            var bankAccount = OfxFile.Reader(fullFileName);

            var bankIdExpected = "0341";
            var accountNumberExpected = "7037300576";

            bankAccount.Should().NotBeNull();
            bankAccount.BankId.Should().Be(bankIdExpected);
            bankAccount.Number.Should().Be(accountNumberExpected);
        }

        [TestMethod]
        public void Read_DeveLerArquivoOFXSantander_DeveRetornarUmaBankAccount()
        {
            var fullFileName = Path.Combine(this._ofxFilePath, "Santander_OFX_" + Guid.NewGuid() + ".ofx");

            OfxFileCreater.Create(fullFileName, FileContent.GetSantanderFileContent());

            var bankAccount = OfxFile.Reader(fullFileName);

            var bankIdExpected = "033";
            var accountNumberExpected = "4360010011321";

            bankAccount.Should().NotBeNull();
            bankAccount.BankId.Should().Be(bankIdExpected);
            bankAccount.Number.Should().Be(accountNumberExpected);
        }

        [TestMethod]
        public void Read_DeveLerArquivoOFXExtrato1_DeveRetornarUmaBankAccount()
        {
            var fullFileName = Path.Combine(this._ofxFilePath, "Extrato1_OFX_" + Guid.NewGuid() + ".ofx");

            OfxFileCreater.Create(fullFileName, FileContent.GetExtrato1FileContent());

            var bankAccount = OfxFile.Reader(fullFileName);

            var bankIdExpected = "0341";
            var accountNumberExpected = "7037300576";

            bankAccount.Should().NotBeNull();
            bankAccount.BankId.Should().Be(bankIdExpected);
            bankAccount.Number.Should().Be(accountNumberExpected);
        }

        [TestMethod]
        public void Read_DeveLerArquivoOFXExtrato2_DeveRetornarUmaBankAccount()
        {
            var fullFileName = Path.Combine(this._ofxFilePath, "Extrato2_OFX_" + Guid.NewGuid() + ".ofx");

            OfxFileCreater.Create(fullFileName, FileContent.GetExtrato2FileContent());

            var bankAccount = OfxFile.Reader(fullFileName);

            var bankIdExpected = "0341";
            var accountNumberExpected = "0304407190";

            bankAccount.Should().NotBeNull();
            bankAccount.BankId.Should().Be(bankIdExpected);
            bankAccount.Number.Should().Be(accountNumberExpected);
        }

        [TestMethod]
        [ExpectedException(typeof(BankAccountNotFoundException))]
        public void Read_DeveLerExceptionCasoArquivoNaoTenhaDadosDaConta_DeveRetornarBankAccountNotFoundException()
        {
            var fullFileName = Path.Combine(this._ofxFilePath, "Extrato_OFX_" + Guid.NewGuid() + ".ofx");

            OfxFileCreater.Create(fullFileName, FileContent.GetExtratoWithoutAccountInformation());

            var bankAccount = OfxFile.Reader(fullFileName);            
        }

        [TestCleanup]
        public void Clean()
        {
            if (Directory.Exists(this._ofxFilePath))
            {
                Directory.Delete(this._ofxFilePath, true);
            }
        }
    }
}
