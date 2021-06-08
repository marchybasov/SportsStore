using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseParser.LicenseFolder
{
    public class DateStamp:RowEntity
    {
        public LicenseDateStamp Date { get; set; }
        public MessageHost Host { get; set; }
        public DateStamp(LicenseDateStamp _date, MessageHost _host )
        {
            Date = _date;
            Host = _host;
        }     

    }
}
