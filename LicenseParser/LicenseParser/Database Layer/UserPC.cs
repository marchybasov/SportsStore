using LicenseParser.LicenseFolder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseParser.Database_Layer
{
    public class UserPC
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string PCName { get; set; }

        public UserPC()
        {

        }
        public UserPC(LicenseUserPC userPC)
        {
            PCName = userPC.GetValue<string>();
        }


    }
}
