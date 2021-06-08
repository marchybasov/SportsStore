using System;
using System.Collections.Generic;

namespace LicenseTracker
{
    public partial class ViewerLicenseUsage
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CurrentlyOccupiedLicense { get; set; }
        public int? FeatureId { get; set; }
        public int? UsageActionId { get; set; }
        public int? UserId { get; set; }
        public int? UserPcId { get; set; }

        public Feature Feature { get; set; }
        public UsageAction UsageAction { get; set; }
        public User User { get; set; }
        public UserPc UserPc { get; set; }
    }
}
