using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LicenseTracker.Models;
using LicenseTracker.Models.DbContext;

namespace LicenseTracker.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        private readonly ISolidworksUsageRepository repository;
        public NavigationMenuViewComponent(ISolidworksUsageRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.solidworksLicenseUsages.Select(x => x.Feature.FeatureName).Distinct().OrderBy(x => x));
        }
    }
}
