using MVC_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assignment1.Controllers
{
    public class MatchController : Controller
    {

        // GET: Match
        public ActionResult Index()
        {
            MatchDetails matchDB = new MatchDetails();

            return View(matchDB.GetMatchDetails());
        }



        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FootBallLeague Match)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MatchDetails matchDB = new MatchDetails();
                    if (matchDB.InsertFootballDetails(Match))
                    {
                        ViewBag.Message = "Match Details Added Successfully";
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

        public ActionResult WinningTeamDetails()
        {
            MatchDetails matchDetails = new MatchDetails();

            return View(matchDetails.WinningMatchDetails());
        }

        public ActionResult Match_View()
        {
            MatchDetails matchDetails = new MatchDetails();

            return View(matchDetails.DrawMatchDetails());
        }

        public ActionResult JapanMatchDetails()
        {
            MatchDetails matchDetails = new MatchDetails();

            return View(matchDetails.JapanMatchDetails());
        }
    }
}