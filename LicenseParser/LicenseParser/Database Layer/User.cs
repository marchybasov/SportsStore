using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseParser.LicenseFolder;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LicenseParser.Database_Layer
{
    public class User
    {
        public int Id { get; set; }

        
        public string FullName { get; set; }

        public User()
        {

        }
        public User(LicenseUser user )
        {
            FullName = user.GetValue<string>();

        }
    }
}
