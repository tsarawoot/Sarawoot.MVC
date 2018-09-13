using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sarawoot.Models
{
    public class HumanModel
    {
        public string[] human;// Test passing data from controller to View

        //Human property: ID, Name, Surname, Gender, Age
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set;}

        public int Age { get; set; }

        public decimal phone { get; set; }

    }
}