using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LicenseParser.LicenseFolder;

namespace LicenseParser
{
    interface ILicenseUsageGetter
    {
        Stack<LicenseUsageParsed> ParseLicenseUsages(string logFile);

    }

}
