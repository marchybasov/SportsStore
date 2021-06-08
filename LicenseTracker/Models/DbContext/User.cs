using System;
using System.Collections.Generic;

namespace LicenseTracker
{
    public partial class User
    {
        public User()
        {
            OtherLicenseUsage = new HashSet<OtherLicenseUsage>();
            PdmlicenseUsage = new HashSet<PdmlicenseUsage>();
            SolidworksLicenseUsage = new HashSet<SolidworksLicenseUsage>();
            ViewerLicenseUsage = new HashSet<ViewerLicenseUsage>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<OtherLicenseUsage> OtherLicenseUsage { get; set; }
        public ICollection<PdmlicenseUsage> PdmlicenseUsage { get; set; }
        public ICollection<SolidworksLicenseUsage> SolidworksLicenseUsage { get; set; }
        public ICollection<ViewerLicenseUsage> ViewerLicenseUsage { get; set; }
    }
}
