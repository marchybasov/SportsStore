using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    public class LicenseDateStamp:LicenseLiteral<DateTime>
    {
        public LicenseDateStamp(DateTime date):base(date)
        {

        }
    }
}
