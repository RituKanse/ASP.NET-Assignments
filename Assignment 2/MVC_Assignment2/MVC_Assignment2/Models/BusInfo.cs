using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Assignment2.Models
{
    public class BusInfo
    {
        public int BusId { get; set; }
        public string BoardingPoint { get; set; }
        public DateTime TravelDate { get; set; }
        public double Amount { get; set; }
        public int Rating { get; set; }
    }
}