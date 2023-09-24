using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azolution.Entities.Sale
{
    public class ComputerInfo
    {
        public int ComputerId { get; set; }
        public string ModelName { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public string Is5G { get; set; }
        public int BrandandColorMapingId { get; set; }
    }
}
