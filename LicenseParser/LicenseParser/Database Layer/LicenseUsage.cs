using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LicenseParser.DAL;
using LicenseParser.LicenseFolder;

namespace LicenseParser.Database_Layer
{
    public abstract class LicenseUsage
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }      
        public Feature Feature { get; set; }
       
        public UsageAction UsageAction { get; set; }
        
        public User User { get; set; }
    
        public UserPC UserPC { get; set; }

        public int CurrentlyOccupiedLicense { get; set; }





        public LicenseUsage (LicenseUsageParsed usageEntity, UnitOfWork unitOfWork)
        {
            CreatedAt = usageEntity.FullTimeStamp;
            Feature = unitOfWork.FeaturesRepository.Get( e=>e.FeatureName == usageEntity.LicenseFeature.Value).FirstOrDefault();
            UsageAction = unitOfWork.UsageActionRepository.Get(e=>e.Action == usageEntity.LicenseAction.Value).FirstOrDefault();
            User = unitOfWork.UserRepository.Get(e =>e.FullName == usageEntity.User.Value).FirstOrDefault();
            UserPC = unitOfWork.UserPCRepository.Get( e=> e.PCName == usageEntity.UserPC.Value).FirstOrDefault();
            CurrentlyOccupiedLicense = usageEntity.OccupiedLicenseAmount;
        }
    }
    public class SolidworksLicenseUsage : LicenseUsage
    {
        public SolidworksLicenseUsage(LicenseUsageParsed usageEntity, UnitOfWork unitOfWork):base(usageEntity, unitOfWork)
        {

        }
    }
    public class PDMLicenseUsage : LicenseUsage
    {
        public PDMLicenseUsage(LicenseUsageParsed usageEntity, UnitOfWork unitOfWork):base(usageEntity, unitOfWork)
        {
            
        }
    }
    public class ViewerLicenseUsage: LicenseUsage
    {
        public ViewerLicenseUsage(LicenseUsageParsed usageEntity, UnitOfWork unitOfWork):base(usageEntity, unitOfWork)
        {

        }
    }
    public class OtherLicenseUsage : LicenseUsage
    {
        public OtherLicenseUsage(LicenseUsageParsed usageEntity, UnitOfWork unitOfWork) : base(usageEntity, unitOfWork)
        {

        }
    }

}
