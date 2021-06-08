using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace LicenseTracker.Utility.LicenseFileParser
{
    public class LicenseUsage : RowEntity
    {

        public int Id { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public string Actor { get; set; }

        public string UserName { get; set; }
        public string UserPC { get; set; }
        public string LicenseAction { get; set; }
        public string LicenseFeature { get; set; }


        public LicenseUsage(LicenseTimeStamp timeStamp, string actor, string licenseAction, string licenseFeature, string userName, string pcName)
        {
            TimeStamp = timeStamp.GetValue<TimeSpan>();
            Actor = actor;
            LicenseAction = licenseAction;
            LicenseFeature = licenseFeature;

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            UserName = textInfo.ToTitleCase(userName);
            UserPC = pcName;
        }
        public override T GetValue<T>()
        {
            return (T)Convert.ChangeType(this, typeof(LicenseUsage));
        }

    }
}
