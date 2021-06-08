using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    public class AnyRow : LicenseLiteral<string>
    {
        public AnyRow(string value) : base(value)
        {

        }

        public override T GetValue<T>()
        {
            return (T)Convert.ChangeType(this, typeof(AnyRow));
        }

    }
}
