using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseTracker.Models.DbContext
{
    public class EFSolidworksLicenseUsagesRepository:ISolidworksUsageRepository
    {
        private ILicenseUsageStatisticContext context;
        public EFSolidworksLicenseUsagesRepository(LicenseUsageStatisticContext context)
        {
            this.context = context;
        }
       public IQueryable<SolidworksLicenseUsage> solidworksLicenseUsages => context.SolidworksLicenseUsage;
    }
}
