using Azolution.Entities.Sale;
using Laps.Mobile.DataService;
using Laps.Mobile.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Laps.Mobile.Service.Service
{
    public class ComputerService : IComputerRepository
    {
        private ComputerDataService computerDataService = new ComputerDataService();
        public List<ComputerColor> PopulateColorCombo()
        {
            var data = computerDataService.PopulateColorCombo();
            return data;
        }
        public List<ComputerBrand>PopulateBrandCombo()
        {
            var datas = computerDataService.PopulateBrandCombo();
            return datas;
        }

        public string SaveComputerInfo(ComputerInfo computer)
        {
            return computerDataService.SaveComputerInfo(computer);
        }

        //public string UpdateMobileInfo(MobileInfo mobile)
        //{
        //    return mobileDataService.UpdateMobileInfo(mobile);
        //}

        public GridEntity<ComputerInfo> ComputerInfoGrid(GridOptions options)
        {
            return computerDataService.ComputerInfoGrid(options);
        }

        public string DeleteComputerInfo(int id)
        {
            return computerDataService.DeleteComputerInfo(id);
        }

        public List<ComputerBrandandColorMaping> ComputerBrandandColorMaping()
        {
            var brandcolordata = computerDataService.ComputerBrandandColorMaping();
            return brandcolordata;
        }

        public List<ComputerBrandandColorMaping> PopulateBrandandColorCombo()
        {
            throw new NotImplementedException();
        }
    }
}
