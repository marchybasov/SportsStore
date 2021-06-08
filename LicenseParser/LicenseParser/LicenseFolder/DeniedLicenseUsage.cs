namespace LicenseParser.LicenseFolder
{
    internal class DeniedLicenseUsage : UnsupportedLicenseFeature
    {
        public DeniedLicenseUsage(LicenseTimeStamp timeStamp, MessageHost actor, LicenseAction licenseAction, LicenseFeature licenseFeature, LicenseUser userName, LicenseUserPC pcName, DenialReason _reason) : base(timeStamp, actor, licenseAction, licenseFeature, userName, pcName, _reason)
        {
          
        }
    }
}
