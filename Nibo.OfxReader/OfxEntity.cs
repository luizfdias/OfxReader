using System;
using System.Collections.Generic;
using System.Text;

namespace Nibo.OfxReader
{
    public abstract class OfxEntity
    {
        protected List<string> EntityBlock { get; set; }

        protected string EntityText { get; set; }

        public OfxEntity(List<string> entityBlock)
        {
            this.EntityBlock = entityBlock;
            entityBlock.ForEach(x => this.EntityText += x);
        }

        protected string GetFieldValue(string field)
        {
            var indexFound = EntityText.IndexOf(field, StringComparison.InvariantCultureIgnoreCase);

            if (indexFound == -1)
            {
                return string.Empty;
            }

            var startIndex = indexFound + field.Length + 1;

            var value = EntityText.Substring(startIndex, EntityText.IndexOf('<', indexFound) - startIndex);

            return value;
        }

        protected List<string> GetSpecificBlock(string blockName)
        {
            var result = new List<string>();

            bool mustAdd = false;
            var stringBuilder = new StringBuilder();

            EntityBlock.IndexOf(string.Format("<{0}>", blockName));

            foreach (var line in EntityBlock)
            {
                if (line.Contains(string.Format("<{0}>", blockName)))
                {
                    mustAdd = true;
                }

                if (mustAdd)
                {
                    stringBuilder.AppendLine(line);
                }

                if (line.Contains(string.Format("</{0}>", blockName)))
                {
                    mustAdd = false;
                    result.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }

            return result;
        }
    }
}
