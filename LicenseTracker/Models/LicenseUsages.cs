using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;



namespace LicenseTracker.Models
{
    public class LicenseUsages
    {

        public int Id { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public string Actor { get; set; }

        public string UserName { get; set; }
        public string UserPC { get; set; }
        public string LicenseAction { get; set; }
        public string LicenseFeature { get; set; }
        public int? SWLicenseInUse { get; set; }
        public int? PDMLicenseInUse { get; set; }
        public int? PDM_ViewerLicenseInUse { get; set; }
                  

    }
}
