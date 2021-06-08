using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    public abstract class LicenseLiteral<TValue> : RowEntity
    {
        public TValue Value { get; }
        protected LicenseLiteral(TValue value) => Value = value;
        public override T GetValue<T>() => (T)Convert.ChangeType(Value, typeof(T));

    }
}
