using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LicenseParser.Database_Layer;

namespace LicenseParser.DAL
{
    public class LicenseUsagesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<UsageAction> UsageActions { get; set; }
        public DbSet<UserPC> UsersPCs { get; set; }
        public DbSet<OtherLicenseUsage> OtherLicenseUsages { get; set; }
        public DbSet<SolidworksLicenseUsage> SolidworksLicenseUsages { get; set; }
        public DbSet<PDMLicenseUsage> PDMLicenseUsages { get; set; }
        public DbSet<ViewerLicenseUsage> ViewerLicenseUsages { get; set; }
        
        public LicenseUsagesContext() : base("DbConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
