using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sarawoot.Controllers
{
    public class SarawController : Controller
    {
        // GET: Saraw
        public ActionResult Index()
        {
            string[] arrayData = new string[] {"Name", "Age", "HiHeightgh", "weight" };

            ViewData["arrayData"] = arrayData;
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