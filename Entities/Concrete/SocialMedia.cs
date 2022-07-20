using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string PlatformIconUrl { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
    }
}
