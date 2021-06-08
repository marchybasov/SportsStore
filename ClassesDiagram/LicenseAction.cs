using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseTracker.Utility.LicenseFileParser
{
    public class LicenseAction : LicenseLiteral<string>
    {
        public LicenseAction(string value) : base(value)
        {

        }
    }
}
