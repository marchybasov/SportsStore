using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    enum SwFeatures
    {
        solidworks,
        swepdm_viewer,
        swepdm_cadeditorandweb,
        swofficepremium,
        swofficepro
    }
    public class LicenseFeature : LicenseLiteral<string>
    {
        public LicenseFeature(string value) : base(value)
        {

        }

        public override T GetValue<T>() => (T)Convert.ChangeType(this, typeof(SwFeatures));

    }

}
