using MVC_Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assignment2.Controllers
{
    public class BusInfoController : Controller
    {
        // GET: BusInfo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(BusInfo busdetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BusInfoDB busInfoDB = new BusInfoDB();
                    if (busInfoDB.InsertbusDetails(busdetails))
                    {
                        ViewBag.Message = "Bus Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BusDetails()
        {
            BusInfoDB busInfo = new BusInfoDB();
            ModelState.Clear();
            return View(busInfo.BusDetails());
        }
        public ActionResult BusDetailsbyAmount()
        {
            BusInfoDB busInfo = new BusInfoDB();
            ModelState.Clear();
            return View(busInfo.BusDetailsByAmount());
        }
        public ActionResult BusDetailsbyRating()
        {
            BusInfoDB busInfo = new BusInfoDB();
            ModelState.Clear();
            return View(busInfo.BusDetailsByRating());
        }
        public ActionResult BusDetailsbydate()
        {
            BusInfoDB busInfo = new BusInfoDB();
            ModelState.Clear();
            return View(busInfo.BusDetailsByDate());
        }
      

    }
}