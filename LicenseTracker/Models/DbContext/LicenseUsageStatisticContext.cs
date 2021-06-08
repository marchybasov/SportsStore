using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LicenseTracker
{
    public partial class LicenseUsageStatisticContext : DbContext, ILicenseUsageStatisticContext
    {
        public LicenseUsageStatisticContext()
        {
           
        }

        public LicenseUsageStatisticContext(DbContextOptions<LicenseUsageStatisticContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<OtherLicenseUsage> OtherLicenseUsage { get; set; }
        public virtual DbSet<PdmlicenseUsage> PdmlicenseUsage { get; set; }
        public virtual DbSet<SolidworksLicenseUsage> SolidworksLicenseUsage { get; set; }
        public virtual DbSet<UsageAction> UsageAction { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPc> UserPc { get; set; }
        public virtual DbSet<ViewerLicenseUsage> ViewerLicenseUsage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=myserver\\MSSQL16;Initial Catalog=LicenseUsageStatistic;user id=sa;password=Ghjcnj123;Integrated Security=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<OtherLicenseUsage>(entity =>
            {
                entity.HasIndex(e => e.FeatureId)
                    .HasName("IX_Feature_Id");

                entity.HasIndex(e => e.UsageActionId)
                    .HasName("IX_UsageAction_Id");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User_Id");

                entity.HasIndex(e => e.UserPcId)
                    .HasName("IX_UserPC_Id");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FeatureId).HasColumnName("Feature_Id");

                entity.Property(e => e.UsageActionId).HasColumnName("UsageAction_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserPcId).HasColumnName("UserPC_Id");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.OtherLicenseUsage)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_dbo.OtherLicenseUsage_dbo.Feature_Feature_Id");

                entity.HasOne(d => d.UsageAction)
                    .WithMany(p => p.OtherLicenseUsage)
                    .HasForeignKey(d => d.UsageActionId)
                    .HasConstraintName("FK_dbo.OtherLicenseUsage_dbo.UsageAction_UsageAction_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OtherLicenseUsage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.OtherLicenseUsage_dbo.User_User_Id");

                entity.HasOne(d => d.UserPc)
                    .WithMany(p => p.OtherLicenseUsage)
                    .HasForeignKey(d => d.UserPcId)
                    .HasConstraintName("FK_dbo.OtherLicenseUsage_dbo.UserPC_UserPC_Id");
            });

            modelBuilder.Entity<PdmlicenseUsage>(entity =>
            {
                entity.ToTable("PDMLicenseUsage");

                entity.HasIndex(e => e.FeatureId)
                    .HasName("IX_Feature_Id");

                entity.HasIndex(e => e.UsageActionId)
                    .HasName("IX_UsageAction_Id");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User_Id");

                entity.HasIndex(e => e.UserPcId)
                    .HasName("IX_UserPC_Id");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FeatureId).HasColumnName("Feature_Id");

                entity.Property(e => e.UsageActionId).HasColumnName("UsageAction_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserPcId).HasColumnName("UserPC_Id");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.PdmlicenseUsage)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_dbo.PDMLicenseUsage_dbo.Feature_Feature_Id");

                entity.HasOne(d => d.UsageAction)
                    .WithMany(p => p.PdmlicenseUsage)
                    .HasForeignKey(d => d.UsageActionId)
                    .HasConstraintName("FK_dbo.PDMLicenseUsage_dbo.UsageAction_UsageAction_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PdmlicenseUsage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.PDMLicenseUsage_dbo.User_User_Id");

                entity.HasOne(d => d.UserPc)
                    .WithMany(p => p.PdmlicenseUsage)
                    .HasForeignKey(d => d.UserPcId)
                    .HasConstraintName("FK_dbo.PDMLicenseUsage_dbo.UserPC_UserPC_Id");
            });

            modelBuilder.Entity<SolidworksLicenseUsage>(entity =>
            {
                entity.HasIndex(e => e.FeatureId)
                    .HasName("IX_Feature_Id");

                entity.HasIndex(e => e.UsageActionId)
                    .HasName("IX_UsageAction_Id");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User_Id");

                entity.HasIndex(e => e.UserPcId)
                    .HasName("IX_UserPC_Id");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FeatureId).HasColumnName("Feature_Id");

                entity.Property(e => e.UsageActionId).HasColumnName("UsageAction_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserPcId).HasColumnName("UserPC_Id");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.SolidworksLicenseUsage)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_dbo.SolidworksLicenseUsage_dbo.Feature_Feature_Id");

                entity.HasOne(d => d.UsageAction)
                    .WithMany(p => p.SolidworksLicenseUsage)
                    .HasForeignKey(d => d.UsageActionId)
                    .HasConstraintName("FK_dbo.SolidworksLicenseUsage_dbo.UsageAction_UsageAction_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SolidworksLicenseUsage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.SolidworksLicenseUsage_dbo.User_User_Id");

                entity.HasOne(d => d.UserPc)
                    .WithMany(p => p.SolidworksLicenseUsage)
                    .HasForeignKey(d => d.UserPcId)
                    .HasConstraintName("FK_dbo.SolidworksLicenseUsage_dbo.UserPC_UserPC_Id");
            });

            modelBuilder.Entity<UserPc>(entity =>
            {
                entity.ToTable("UserPC");

                entity.HasIndex(e => e.Pcname)
                    .HasName("IX_PCName")
                    .IsUnique();

                entity.Property(e => e.Pcname)
                    .HasColumnName("PCName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewerLicenseUsage>(entity =>
            {
                entity.HasIndex(e => e.FeatureId)
                    .HasName("IX_Feature_Id");

                entity.HasIndex(e => e.UsageActionId)
                    .HasName("IX_UsageAction_Id");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User_Id");

                entity.HasIndex(e => e.UserPcId)
                    .HasName("IX_UserPC_Id");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FeatureId).HasColumnName("Feature_Id");

                entity.Property(e => e.UsageActionId).HasColumnName("UsageAction_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserPcId).HasColumnName("UserPC_Id");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.ViewerLicenseUsage)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_dbo.ViewerLicenseUsage_dbo.Feature_Feature_Id");

                entity.HasOne(d => d.UsageAction)
                    .WithMany(p => p.ViewerLicenseUsage)
                    .HasForeignKey(d => d.UsageActionId)
                    .HasConstraintName("FK_dbo.ViewerLicenseUsage_dbo.UsageAction_UsageAction_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ViewerLicenseUsage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.ViewerLicenseUsage_dbo.User_User_Id");

                entity.HasOne(d => d.UserPc)
                    .WithMany(p => p.ViewerLicenseUsage)
                    .HasForeignKey(d => d.UserPcId)
                    .HasConstraintName("FK_dbo.ViewerLicenseUsage_dbo.UserPC_UserPC_Id");
            });
        }
    }
}
