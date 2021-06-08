using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseTracker.Utility.LicenseFileParser
{
    public class AnyRow : LicenseLiteral<string>
    {
        public AnyRow(string value ) : base(value)
        {

        }

        public override T GetValue<T>()
        {
            return (T)Convert.ChangeType(this, typeof(AnyRow));
        }

    }
}
