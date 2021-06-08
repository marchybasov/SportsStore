using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    class UnsupportedLicenseFeature:LicenseUsageParsed
    {
        public DenialReason Reason { get; set; }
        public UnsupportedLicenseFeature(LicenseTimeStamp timeStamp, MessageHost actor, LicenseAction licenseAction, LicenseFeature licenseFeature, LicenseUser userName, LicenseUserPC pcName, DenialReason _reason):base(timeStamp,  actor, licenseAction, licenseFeature, userName, pcName)
        {
            this.Reason = _reason;
        }
    }
}
