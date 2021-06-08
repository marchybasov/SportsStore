using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    public class LicenseTimeStamp : LicenseLiteral<TimeSpan>
    {
        public LicenseTimeStamp(TimeSpan value) : base(value) { }



        public override T GetValue<T>() => (T)Convert.ChangeType(Value, typeof(TimeSpan));
    }
}
