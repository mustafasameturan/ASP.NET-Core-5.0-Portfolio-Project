using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ContactInformation
    {
        [Key]
        public int ContactInformationID { get; set; }
        public string Header { get; set; }
        public string Email { get; set; }
        public string DiscordID { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
    }
}
