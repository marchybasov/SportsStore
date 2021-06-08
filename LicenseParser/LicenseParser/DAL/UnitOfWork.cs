using LicenseParser.Database_Layer;
using System;

namespace LicenseParser.DAL
{
    public class UnitOfWork : IDisposable
    {
        private LicenseUsagesContext context = new LicenseUsagesContext();

        private GenericRepository<User> userRepository;
        private GenericRepository<Feature> featuresRepository;
        private GenericRepository<UsageAction> usageActionRepository;
        private GenericRepository<UserPC> userPCRepository;
        private GenericRepository<OtherLicenseUsage> otherUsagesRepository;
        private GenericRepository<SolidworksLicenseUsage> swRepository;
        private GenericRepository<PDMLicenseUsage> pdmRepository;
        private GenericRepository<ViewerLicenseUsage> viewerRepository;

        public UnitOfWork()
        {

        }
        public UnitOfWork(LicenseUsagesContext ctx)
        {
            context = ctx;
        }
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }


        public GenericRepository<Feature> FeaturesRepository
        {
            get
            {
                if (this.featuresRepository == null)
                {
                    this.featuresRepository = new GenericRepository<Feature>(context);
                }
                return featuresRepository;
            }
        }

        public GenericRepository<UsageAction> UsageActionRepository
        {
            get
            {
                if (usageActionRepository == null)
                {
                    usageActionRepository = new GenericRepository<UsageAction>(context);
                }
                return usageActionRepository;
            }
        }


        public GenericRepository<UserPC> UserPCRepository
        {
            get
            {
                if (userPCRepository == null)
                {
                    userPCRepository = new GenericRepository<UserPC>(context);
                }
                return userPCRepository;
            }
        }

        public GenericRepository<OtherLicenseUsage> LicenseUsagesRepository
        {
            get
            {
                if (otherUsagesRepository == null)
                {
                    otherUsagesRepository = new GenericRepository<OtherLicenseUsage>(context);
                }
                return otherUsagesRepository;
            }
        }

        public GenericRepository<SolidworksLicenseUsage> SwUsagesRepository
        {
            get
            {
                if (swRepository == null)
                {
                    swRepository = new GenericRepository<SolidworksLicenseUsage>(context);
                }
                return swRepository;
            }
        }

        public GenericRepository<PDMLicenseUsage> PDMUsageRepository
        {
            get
            {
                if (pdmRepository == null)
                {
                    pdmRepository = new GenericRepository<PDMLicenseUsage>(context);
                }
                return pdmRepository;
            }
        }
        public GenericRepository<ViewerLicenseUsage> ViewerUsageRepository
        {
            get
            {
                if (viewerRepository == null)
                {
                    viewerRepository = new GenericRepository<ViewerLicenseUsage>(context);
                }
                return viewerRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
