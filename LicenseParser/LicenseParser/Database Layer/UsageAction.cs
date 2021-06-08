using LicenseParser.LicenseFolder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseParser.Database_Layer
{

    public class UsageAction
    {
        public int Id { get; set; }

        public string Action { get; set; }
        public UsageAction()
        {

        }
        public UsageAction(LicenseAction _action)
        {
            Action = _action.GetValue<string>();
        }
       

        //[Column (TypeName = "VARCHAR")]
        //[StringLength(100)]
        //[Index(IsUnique = true)]
        
    }
}
