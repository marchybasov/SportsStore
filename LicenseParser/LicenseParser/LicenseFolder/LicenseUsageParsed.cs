using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    public class LicenseUsageParsed : RowEntity
    {

        public int Id { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public MessageHost Actor { get; set; }

        public LicenseUser User { get; set; }
        public LicenseUserPC UserPC { get; set; }
        public LicenseAction LicenseAction { get; set; }
        public LicenseFeature LicenseFeature { get; set; }
        public DateTime FullTimeStamp { get; set; }
        public int OccupiedLicenseAmount { get; set;  }

        public LicenseUsageParsed(LicenseTimeStamp timeStamp, MessageHost actor, LicenseAction licenseAction, LicenseFeature licenseFeature, LicenseUser userName, LicenseUserPC pcName /*UserPC pcName*/)
        {
            TimeStamp = timeStamp.GetValue<TimeSpan>();
            Actor = actor;
            LicenseAction = licenseAction;
            LicenseFeature = licenseFeature;
            User = userName;
            UserPC = pcName;
        }
        public override T GetValue<T>()
        {
            return (T)Convert.ChangeType(this, typeof(LicenseUsageParsed));
        }

    }
}
