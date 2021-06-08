using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    public class LicenseUser : LicenseLiteral<string>
    {
        public LicenseUser(string val) : base(new CultureInfo("en-US", false).TextInfo.ToTitleCase(val))
        {

        }
    }
}
