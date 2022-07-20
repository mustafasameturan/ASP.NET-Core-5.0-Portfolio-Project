using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Discord { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
