using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sarawoot.Models;

namespace Sarawoot.Controllers
{
    public class SarawController : Controller
    {

        // GET: Saraw
        public ActionResult Index()
        {
            string[] arrayData = new string[] { "Name", "Age", "Height", "weight" };
            //-------------
            List<HumanModel> humanData = new List<HumanModel>();
            humanData.Add(new HumanModel());
            humanData[0].human = new string[4] { "Name", "Age", "Height", "weight" };
            humanData.Add(new HumanModel());
            humanData[1].human = new string[4] { "Sarawoot", "34", "175", "66" };
            humanData.Add(new HumanModel());
            humanData[2].human = new string[4] { "Budsaba", "32", "150", "40" };
            humanData.Add(new HumanModel());
            humanData[3].human = new string[4] { "Sarawoot", "34", "175", "66" };

            ViewData["arrayData"] = arrayData;
            ViewData["humanData"] = humanData;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}