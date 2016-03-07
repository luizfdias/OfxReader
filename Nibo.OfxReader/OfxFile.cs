using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nibo.OfxReader
{
    public static class OfxFile
    {
        private const string _OFX_STARTBLOCK = "<OFX>";
        private const string _OFX_ENDBLOCK = "</OFX>";

        public static BankStatementFile Read(string fullFileName)
        {
            BankStatementFile bankStatementFile = null;            

            using (var reader = new StreamReader(fullFileName))
            {                                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (line.Contains(_OFX_STARTBLOCK))
                    {
                        var bankTransactionListBlock = BuildBlock(_OFX_ENDBLOCK, line, reader);

                        bankStatementFile = new BankStatementFile(bankTransactionListBlock);
                    }
                }
            }

            return bankStatementFile;
        }

        private static List<string> BuildBlock(string blockName, string line, StreamReader reader)
        {
            var blockBuilder = new List<string>();

            do
            {
                blockBuilder.Add(line);
                line = reader.ReadLine();
            }
            while (!line.Contains(blockName));

            blockBuilder.Add(line);

            return blockBuilder;
        }
    }
}
