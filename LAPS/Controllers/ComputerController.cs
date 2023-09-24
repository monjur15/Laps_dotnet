using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Azolution.Entities.Sale;
using Laps.Mobile.Service.Interface;
using Laps.Mobile.Service.Service;
using Utilities;

namespace LAPS.Controllers
{
    public class ComputerController : Controller
    {
        //
        // GET: /Computer/
        private IComputerRepository computerRepo = new ComputerService();
        public ActionResult Index()
        {
            if (Session["CurrentUser"] != null)
            {
                return View("~/Views/Sale/Computer/ComputerSettings.cshtml");
            }
            return RedirectToAction("Logoff", "Home");
        }

        public ActionResult PopulateColorCombo()
        {
            try
            {
                var data = computerRepo.PopulateColorCombo();
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
                var datas = computerRepo.PopulateBrandCombo();
                return Json(datas, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult SaveComputerInfo(ComputerInfo computer)
        {
            //var status = mobileRepo.SaveMobileInfo(mobile);
            //return JSON.stringify(status);

            return Json(computerRepo.SaveComputerInfo(computer), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ComputerInfoGrid(GridOptions options)
        {
            return Json(computerRepo.ComputerInfoGrid(options), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteComputerInfo(int id)
        {
            return Json(computerRepo.DeleteComputerInfo(id), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult ComputerBrandandColorMaping()
        //{
        //    try
        //    {
        //        var brandcolordata = computerRepo.ComputerBrandandColorMaping();
        //        return Json(brandcolordata, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}