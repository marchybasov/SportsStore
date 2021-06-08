using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseParser.LicenseFolder;

namespace LicenseParser.Database_Layer
{
    public class Feature
    {
        public int Id { get; set; }

        //[Column(TypeName = "VARCHAR")]
        //[StringLength(100)]
        ////[Index(IsUnique = true)]
        
        public string FeatureName{ get; set; }
        public Feature()
        {

        }
        public Feature(LicenseFeature feature)
        {
            FeatureName = feature.Value;
        }
    }
}
