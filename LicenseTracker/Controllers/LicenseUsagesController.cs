using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LicenseTracker.Models;
using LicenseTracker.Models.DbContext;
using LicenseTracker.Models.ViewModels;
using System;

namespace LicenseTracker.Controllers
{
    public class LicenseUsagesController : Controller
    {
        private ISolidworksUsageRepository swRepo;

        
        public LicenseUsagesController(ISolidworksUsageRepository rep)
        {
            swRepo = rep;
        }

        public ViewResult List(string category, int LicenseUsagesPage = 1) {

            if (category != null && category.StartsWith("s"))
            {
                return View(new LicenseUsagesStatisticListViewModel
                {
                    AvgUsage9_10 = (int)swRepo.solidworksLicenseUsages.Where(x => (x.CreatedAt.Hour >= 9 && x.CreatedAt.Hour < 10)&&x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),
                    AvgUsage10_11 = (int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 10 && x.CreatedAt.Hour < 11 &&x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),
                    AvgUsage11_12 = (int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 11 && x.CreatedAt.Hour < 12 &&x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),
                    AvgUsage12_13 = (int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 12 && x.CreatedAt.Hour < 13 &&x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),
                    AvgUsage13_14 = (int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 13 && x.CreatedAt.Hour < 14 &&x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),
                    AvgUsage14_15 = (int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 14 && x.CreatedAt.Hour < 15 &&x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),
                    AvgUsage15_16 = (int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 15 && x.CreatedAt.Hour < 16 &&x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),
                    AvgUsage16_17 = (int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 16 && x.CreatedAt.Hour < 17 &&x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),
                    AvgUsage17_18 = (int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 17 && x.CreatedAt.Hour < 18 &&x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),
                    AvgUsage18_19 = (int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 18 && x.CreatedAt.Hour < 19 && x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average(),

                    CurrentCategory = category
                });

            }
            // double avg9_10 = swRepo.solidworksLicenseUsages.Where(x => (x.CreatedAt.Hour >= 9 && x.CreatedAt.Hour < 10) && x.Feature.FeatureName == category).Select(x => x.CurrentlyOccupiedLicense).Average();
            return View(new LicenseUsagesStatisticListViewModel
            {
                AvgUsage9_10 = (int) swRepo.solidworksLicenseUsages.Where(x => (x.CreatedAt.Hour >= 9 && x.CreatedAt.Hour < 10)).Select(x => x.CurrentlyOccupiedLicense).Average(),
                AvgUsage10_11 =(int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 10 && x.CreatedAt.Hour < 11).Select(x => x.CurrentlyOccupiedLicense).Average(),
                AvgUsage11_12 =(int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 11 && x.CreatedAt.Hour < 12).Select(x => x.CurrentlyOccupiedLicense).Average(),
                AvgUsage12_13 =(int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 12 && x.CreatedAt.Hour < 13).Select(x => x.CurrentlyOccupiedLicense).Average(),
                AvgUsage13_14 =(int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 13 && x.CreatedAt.Hour < 14).Select(x => x.CurrentlyOccupiedLicense).Average(),
                AvgUsage14_15 =(int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 14 && x.CreatedAt.Hour < 15).Select(x => x.CurrentlyOccupiedLicense).Average(),
                AvgUsage15_16 =(int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 15 && x.CreatedAt.Hour < 16).Select(x => x.CurrentlyOccupiedLicense).Average(),
                AvgUsage16_17 =(int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 16 && x.CreatedAt.Hour < 17).Select(x => x.CurrentlyOccupiedLicense).Average(),
                AvgUsage17_18 =(int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 17 && x.CreatedAt.Hour < 18).Select(x => x.CurrentlyOccupiedLicense).Average(),
                AvgUsage18_19 =(int) swRepo.solidworksLicenseUsages.Where(x => x.CreatedAt.Hour >= 18 && x.CreatedAt.Hour < 19).Select(x => x.CurrentlyOccupiedLicense).Average(),

                CurrentCategory = category
            });
       
        } 
       






    }
}
