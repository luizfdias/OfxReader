using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nibo.OfxReader.Tests
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void BankAccount_DeveConstruirUmContaBancariaAPartirDeUmBloco_DeveRetornarUmaContaBancaria()
        {
            var bankAccount = new BankAccount(@"<BANKACCTFROM><BANKID>0341<ACCTID>7037300576<ACCTTYPE>CHECKING</BANKACCTFROM>");

            var bankIdExpected = 341;
            var accountIdExpected = 7037300576;

            bankAccount.BankId.Should().Be(bankIdExpected);
            bankAccount.Number.Should().Be(accountIdExpected);
        }
    }
}
