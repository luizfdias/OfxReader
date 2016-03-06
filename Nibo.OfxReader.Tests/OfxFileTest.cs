using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.IO;
using Nibo.OfxReader.Tests.Helpers;

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

            var bankStatementFile = OfxFile.Reader(fullFileName);

            var startDateExpected = "20140401100000[-03:EST]";
            var endDateExpected = "20140430100000[-03:EST]";
            var bankIdExpected = "0341";
            var accountNumberExpected = "7037300576";

            var transactionsCountExpected = 32;

            bankStatementFile.StartDate.Should().Be(startDateExpected);
            bankStatementFile.EndDate.Should().Be(endDateExpected);

            bankStatementFile.BankAccountFile.Should().NotBeNull();
            bankStatementFile.BankAccountFile.BankId.Should().Be(bankIdExpected);
            bankStatementFile.BankAccountFile.Number.Should().Be(accountNumberExpected);
            bankStatementFile.BankAccountFile.Transactions.Count.Should().Be(transactionsCountExpected);
        }

        [TestMethod]
        public void Read_DeveLerArquivoOFXSantander_DeveRetornarUmaBankAccount()
        {
            var fullFileName = Path.Combine(this._ofxFilePath, "Santander_OFX_" + Guid.NewGuid() + ".ofx");

            OfxFileCreater.Create(fullFileName, FileContent.GetSantanderFileContent());

            var bankStatementFile = OfxFile.Reader(fullFileName);

            var startDateExpected = "20140319105300[-3:GMT]";
            var endDateExpected = "20140319105300[-3:GMT]";
            var bankIdExpected = "033";
            var accountNumberExpected = "4360010011321";
            var transactionsCountExpected = 44;

            bankStatementFile.StartDate.Should().Be(startDateExpected);
            bankStatementFile.EndDate.Should().Be(endDateExpected);

            bankStatementFile.BankAccountFile.Should().NotBeNull();
            bankStatementFile.BankAccountFile.BankId.Should().Be(bankIdExpected);
            bankStatementFile.BankAccountFile.Number.Should().Be(accountNumberExpected);

            bankStatementFile.BankAccountFile.Transactions.Count.Should().Be(transactionsCountExpected);
        }

        [TestMethod]
        public void Read_DeveLerArquivoOFXExtrato1_DeveRetornarUmaBankAccount()
        {
            var fullFileName = Path.Combine(this._ofxFilePath, "Extrato1_OFX_" + Guid.NewGuid() + ".ofx");

            OfxFileCreater.Create(fullFileName, FileContent.GetExtrato1FileContent());

            var bankStatementFile = OfxFile.Reader(fullFileName);

            var startDateExpected = "20140102100000[-03:EST]";
            var endDateExpected = "20140318100000[-03:EST]";
            var bankIdExpected = "0341";
            var accountNumberExpected = "7037300576";
            var transactionsCountExpected = 94;

            bankStatementFile.StartDate.Should().Be(startDateExpected);
            bankStatementFile.EndDate.Should().Be(endDateExpected);

            bankStatementFile.BankAccountFile.Should().NotBeNull();
            bankStatementFile.BankAccountFile.BankId.Should().Be(bankIdExpected);
            bankStatementFile.BankAccountFile.Number.Should().Be(accountNumberExpected);

            bankStatementFile.BankAccountFile.Transactions.Count.Should().Be(transactionsCountExpected);
        }

        [TestMethod]
        public void Read_DeveLerArquivoOFXExtrato2_DeveRetornarUmaBankAccount()
        {
            var fullFileName = Path.Combine(this._ofxFilePath, "Extrato2_OFX_" + Guid.NewGuid() + ".ofx");

            OfxFileCreater.Create(fullFileName, FileContent.GetExtrato2FileContent());

            var bankStatementFile = OfxFile.Reader(fullFileName);

            var startDateExpected = "20140605100000[-03:EST]";
            var endDateExpected = "20140619100000[-03:EST]";
            var bankIdExpected = "0341";
            var accountNumberExpected = "0304407190";
            var transactionsCountExpected = 28;

            bankStatementFile.StartDate.Should().Be(startDateExpected);
            bankStatementFile.EndDate.Should().Be(endDateExpected);

            bankStatementFile.BankAccountFile.Should().NotBeNull();
            bankStatementFile.BankAccountFile.BankId.Should().Be(bankIdExpected);
            bankStatementFile.BankAccountFile.Number.Should().Be(accountNumberExpected);

            bankStatementFile.BankAccountFile.Transactions.Count.Should().Be(transactionsCountExpected);
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
