using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Web.Client.Data;

namespace TMS.Web.Client.Controllers
{
    public class DeviceController : Controller
    {
        // GET: Device
        public ActionResult Index()
        {
            ViewBag.Devices = new DataRepository().DeviceList();
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Devices = new DataRepository().DeviceList();
            return View();
        }
    }
}