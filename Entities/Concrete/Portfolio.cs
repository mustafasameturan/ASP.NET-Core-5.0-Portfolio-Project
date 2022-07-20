using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        public string Title { get; set; }
        public string Tool { get; set; }
        public string ProjectUrl { get; set; }
        public string ImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public string ToolIconUrl { get; set; }

    }
}
