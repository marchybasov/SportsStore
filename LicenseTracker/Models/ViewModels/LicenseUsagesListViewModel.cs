
using System.Collections.Generic;
using LicenseTracker.Models;

namespace LicenseTracker.Models.ViewModels
{
    public class LicenseUsagesListViewModel
    {
        public IEnumerable<LicenseUsages> LicenseUsages { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public int LicenseFeature { get; set; }

    }


}
