using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _Laps_.Laptop.Service.Interface;
using _Laps_.Laptop.Service.Service;
using Azolution.Entities.Sale;
using Utilities;

namespace LAPS.Controllers
{
    public class LaptopController : Controller
    {
        // GET: Laptop
        private ILaptopRepository LapRepo = new LaptopService();
        public ActionResult LaptopSettings()
        {
            if (Session["CurrentUser"] != null)
            {
               



                return View("~/Views/Laptop/LaptopSettings.cshtml");
            }
            return RedirectToAction("Logoff", "Home");
        }
        public ActionResult PopulateColorCombo()
        {
            try
            {
                var data = LapRepo.PopulateColorCombo();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult PopulateBrandCombo()
        {
            try
            {
                var datas = LapRepo.PopulateBrandCombo();
                return Json(datas, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult SaveLaptopInfo(LaptopInfo laptop)
        {
            //var status = mobileRepo.SaveMobileInfo(mobile);
            //return JSON.stringify(status);

            return Json(LapRepo.SaveLaptopInfo(laptop), JsonRequestBehavior.AllowGet);
        }
        public ActionResult LaptopInfoGrid(GridOptions options)
        {
            return Json(LapRepo.LaptopInfoGrid(options), JsonRequestBehavior.AllowGet);
        }

    }


   
}