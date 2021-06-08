using System.Linq;

namespace LicenseTracker.Models.DbContext
{
    public interface ISolidworksUsageRepository
    {
        IQueryable<SolidworksLicenseUsage> solidworksLicenseUsages { get; }
    }
}
