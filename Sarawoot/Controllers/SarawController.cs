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
            humanData[3].human = new string[4] { "Bhubodin", "1.2", "76", "11" };

            ViewData["arrayData"] = arrayData;
            ViewData["humanData"] = humanData;
            ViewBag.humanData = humanData;
            return View(humanData);
        }

        public ActionResult About()
        {
            HumanModel myObj = new HumanModel();
            myObj.ID = 1;
            myObj.Name = "Sarawoot";
            myObj.Surname = "Thongchan";
            myObj.Gender = "Male";
            myObj.Age = 34;
            myObj.phone = 66851261221;


            return View(myObj);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SaveHumanInfo(int id, string name, string surname,
            string gender, int age, decimal phone)
        {
            HumanModel myObj = new HumanModel();
            myObj.ID = id;
            myObj.Name = name;
            myObj.Surname = surname;
            myObj.Gender = gender;
            myObj.Age = age;
            myObj.phone = phone;
            return View("About", myObj);
        }


    }
}