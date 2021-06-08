using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    public class LicenseUserPC : LicenseLiteral<string>
    {
        public LicenseUserPC(string value) : base(value.ToUpper())
        {
        }
    }
}
