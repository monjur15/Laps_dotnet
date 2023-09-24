using Azolution.Entities.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace _Laps_.Laptop.Service.Interface
{
    public interface ILaptopRepository 
    {
        List<LaptopBrand> PopulateBrandCombo();
        List<LaptopColor> PopulateColorCombo();
        string SaveLaptopInfo(LaptopInfo laptop);
        GridEntity<LaptopInfo> LaptopInfoGrid(GridOptions options);
        
    }
}