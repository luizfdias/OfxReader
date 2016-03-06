using System;

namespace Nibo.OfxReader
{
    public abstract class OfxEntity
    {
        protected string EntityBlock { get; set; }

        public OfxEntity(string entityBlock)
        {
            this.EntityBlock = entityBlock;
        }

        protected string GetFieldValue(string field)
        {
            var indexFound = EntityBlock.IndexOf(field, StringComparison.InvariantCultureIgnoreCase);

            var startIndex = indexFound + field.Length + 1;

            var value = EntityBlock.Substring(startIndex, EntityBlock.IndexOf('<', indexFound) - startIndex);

            return value;
        }
    }
}
