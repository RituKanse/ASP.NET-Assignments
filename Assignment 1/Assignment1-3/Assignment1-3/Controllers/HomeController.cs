using Assignment1_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1_3.Controllers
{
    public class HomeController : Controller
    {

        MvcAssigmentsEntities db = new MvcAssigmentsEntities();

        // GET: Home
        public ActionResult Index()
        {
            var data = db.FootBallLeagues.ToList();
            return View(data);
        }

        public ActionResult WinningList()
        {
            IEnumerable<FootBallLeague> list = db.FootBallLeagues.ToList().Where(result => result.MatchStatus == "Win");
            return View(list);
        }
    }
}