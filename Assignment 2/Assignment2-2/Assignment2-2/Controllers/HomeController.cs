 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2_2.Controllers
{
    public class HomeController : Controller
    {

        MvcAssigmentsEntities db = new MvcAssigmentsEntities(); 

        // GET: Home
        public ActionResult Index()
        {
            var data= db.BusInfoes.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(BusInfo bus)
        {
            if (ModelState.IsValid)
            {
                db.BusInfoes.Add(bus);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.Message = "Bus Details Added Succesfully!";
                }
                else
                {
                    ViewBag.Message = "Bus Details Not Added!";
                }
                
            }
            return View();
        }

    }
}