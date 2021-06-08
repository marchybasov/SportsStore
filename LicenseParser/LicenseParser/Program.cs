using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseParser.LicenseFolder;
using LicenseParser.Database_Layer;
using MoreLinq;
using System.Data.Entity;
using LicenseParser.DAL;


namespace LicenseParser
{
    class Program
    {
        static void Main(string[] args)
        {
            ILicenseUsageGetter usageGetter = new LicenseUsageGetter();
            List<LicenseUsageParsed> licenseUsages = usageGetter.ParseLicenseUsages(string.Empty).ToList<LicenseUsageParsed>();


            UnitOfWork unitOfWork = new UnitOfWork();
            var features = licenseUsages.Select(p => p.LicenseFeature).DistinctBy(p => p.Value);

            foreach (var item in features)
            {
                unitOfWork.FeaturesRepository.InsertOnlyNewEntity(new Feature(item), e => e.FeatureName == item.Value);
            }
            unitOfWork.Save();
            Console.WriteLine("Feature Saved");

            foreach (var item in licenseUsages.Select(p => p.User).DistinctBy(p => p.Value))
            {
                unitOfWork.UserRepository.InsertOnlyNewEntity(new User(item), e => e.FullName == item.Value);
            }
            unitOfWork.Save();
            Console.WriteLine("Users Saved");

            foreach (var item in licenseUsages.Select(p => p.LicenseAction).DistinctBy(p => p.Value))
            {
                unitOfWork.UsageActionRepository.InsertOnlyNewEntity(new UsageAction(item), e => e.Action == item.Value);
            }
            unitOfWork.Save();
            Console.WriteLine("Usage Action saved");

            var usersPCs = licenseUsages.Select(p => p.UserPC).DistinctBy(p => p.Value).ToList();
            foreach (var item in usersPCs)
            {
                unitOfWork.UserPCRepository.InsertOnlyNewEntity(new UserPC(item), e => e.PCName == item.Value);
            }
            unitOfWork.Save();
            Console.WriteLine("{0} user PCs detected", usersPCs.Count);
            Console.WriteLine("Users PC saved");

            
            var swLicenseUsage = licenseUsages.Where(p => p.LicenseFeature.Value ==  "solidworks").ToList();
            SetOccupiedLicensesAmount(ref swLicenseUsage, 4);

            var swPDM = licenseUsages.Where(p => p.LicenseFeature.Value == "swepdm_cadeditorandweb").ToList();
            SetOccupiedLicensesAmount(ref swPDM, 2);
            var pdmViewer= licenseUsages.Where(p => p.LicenseFeature.Value == "swepdm_viewer").ToList();
            SetOccupiedLicensesAmount(ref pdmViewer, 2);
          
            
            
            int counter = 0;
            var allLicenses = swLicenseUsage.Concat(swPDM).Concat(pdmViewer).ToList();
            int swLicenseUsagesAmount = allLicenses.Count;
            Console.WriteLine("{0} solidworks license usages detected", allLicenses.Count);

            foreach (var item in allLicenses)
            {
                unitOfWork.SwUsagesRepository.Insert(new SolidworksLicenseUsage(item, unitOfWork));
                Console.WriteLine("{0} out of {1} inserted into db", ++counter, swLicenseUsagesAmount);
            }


            unitOfWork.Save();
            Console.WriteLine("Solidworks License Usages saved");


            Console.WriteLine("done");
            Console.ReadLine();

        }

        static void SetOccupiedLicensesAmount(ref List<LicenseUsageParsed> licenseUsage, int startValue)
        {
            int i = startValue;
            foreach (var item in licenseUsage)
            {
                if (item.LicenseAction.Value == "License taken")
                {
                    i++;
                    item.OccupiedLicenseAmount = i;
                }
                else if (item.LicenseAction.Value == "License returned")
                {
                    i--;
                    item.OccupiedLicenseAmount = i;
                }

            }
        }
    }

}
