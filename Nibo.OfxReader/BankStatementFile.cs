using System.Collections.Generic;
using System.Text;

namespace Nibo.OfxReader
{
    public class BankStatementFile : OfxEntity
    {
        public BankStatementFile(List<string> entityBlock) : base(entityBlock)
        {
            this.StartDate = this.GetFieldValue("DTSTART").Trim();
            this.EndDate = this.GetFieldValue("DTEND").Trim();

            this.BankAccountFile = new BankAccountFile(entityBlock);
        }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public BankAccountFile BankAccountFile { get; set; }        
    }
}
