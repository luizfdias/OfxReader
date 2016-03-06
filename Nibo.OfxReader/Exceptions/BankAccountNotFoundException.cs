using System;

namespace Nibo.OfxReader.Exceptions
{
    public class BankAccountNotFoundException : Exception
    {
        public BankAccountNotFoundException() : base("Não foram encontradas as informações da conta bancária no arquivo.")
        {
            
        }
    }
}
