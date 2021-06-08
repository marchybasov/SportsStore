using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseTracker.Utility.LicenseFileParser
{
    public class LicenseTimeStamp : LicenseLiteral<TimeSpan>
    {
        public LicenseTimeStamp(TimeSpan value) : base(value) { }

        public override T GetValue<T>() => (T)Convert.ChangeType(Value, typeof(TimeSpan));
    }
}
