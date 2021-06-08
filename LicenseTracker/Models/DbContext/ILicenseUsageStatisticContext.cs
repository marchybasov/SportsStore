using Microsoft.EntityFrameworkCore;

namespace LicenseTracker
{
    public interface ILicenseUsageStatisticContext
    {
        DbSet<Feature> Feature { get; set; }
        DbSet<PdmlicenseUsage> PdmlicenseUsage { get; set; }
        DbSet<SolidworksLicenseUsage> SolidworksLicenseUsage { get; set; }
        DbSet<UsageAction> UsageAction { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserPc> UserPc { get; set; }
        DbSet<ViewerLicenseUsage> ViewerLicenseUsage { get; set; }
    }
}