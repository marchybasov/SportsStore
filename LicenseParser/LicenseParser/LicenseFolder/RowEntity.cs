using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprache;
using System.Threading.Tasks;


namespace LicenseParser.LicenseFolder
{
    public abstract partial class RowEntity
    {
        public virtual RowEntity this[string name] => throw new InvalidOperationException($"{GetType().Name} doesn't support this operation.");

        public virtual RowEntity this[int index] => throw new InvalidOperationException($"{GetType().Name} doesn't support this operation.");
        public virtual T GetValue<T>() => throw new InvalidOperationException($"{GetType().Name} doesn't support this operation.");
    }

    public abstract partial class RowEntity
    {
       
        public static RowEntity Parse(string row) => ParserGrammar.RowEntity.Parse(row);
    }
}
