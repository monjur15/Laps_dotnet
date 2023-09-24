using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azolution.Entities.Sale
{
    public class LaptopInfo
    {
        public int LaptopId { get; set; }

        // [Required]
        public string ModelName { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int Price { get; set; }
        public int IsW { get; set; }
        public int IsActive { get; set; }
    }
}
