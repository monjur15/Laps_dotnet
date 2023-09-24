using Azolution.Entities.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Laps.Mobile.Service.Interface
{
    public interface IComputerRepository
    {
        List<ComputerColor> PopulateColorCombo();
        List<ComputerBrand> PopulateBrandCombo();
        string SaveComputerInfo(ComputerInfo computer);
        GridEntity<ComputerInfo> ComputerInfoGrid(GridOptions options);

        //string UpdateMobileInfo(MobileInfo mobile);  
        string DeleteComputerInfo(int id);
        List<ComputerBrandandColorMaping> PopulateBrandandColorCombo();
    }
}
