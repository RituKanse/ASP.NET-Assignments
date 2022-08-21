using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assignment2_3.Controllers
{
    public class BusInfoController : Controller
    {
        MvcAssigmentsEntities db = new MvcAssigmentsEntities(); 

        // GET: BusInfo
        public ActionResult Index()
        {
            return View(db.BusInfoes.ToList());
        }

        public ActionResult BusInfoByBoardingPoint()
        {
            IEnumerable<BusInfo> list = db.BusInfoes.ToList().Where(result => result.BoardingPoint == "MUM");
            return View(list);
        }

    }
}