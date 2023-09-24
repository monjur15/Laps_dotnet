using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _Laps_.Laptop.Service.Interface;
using Laps.Laptop.DataService;
using Azolution.Entities.Sale;
using Utilities;

namespace _Laps_.Laptop.Service.Service
{
    public class LaptopService : ILaptopRepository
    {
        private LaptopDataService laptopDataService = new LaptopDataService();
        public List<LaptopColor> PopulateColorCombo()
        {
            var data = laptopDataService.PopulateColorCombo();
            return data;
        }

        public List<LaptopBrand> PopulateBrandCombo()
        {
            
            var datas = laptopDataService.PopulateBrandCombo();
            return datas;
        }
        public string SaveLaptopInfo(LaptopInfo laptop)
        {
            return laptopDataService.SaveLaptopInfo(laptop);
        }

        public GridEntity<LaptopInfo> LaptopInfoGrid(GridOptions options)
        {
            return laptopDataService.LaptopInfoGrid(options);
            
        }
    }
}