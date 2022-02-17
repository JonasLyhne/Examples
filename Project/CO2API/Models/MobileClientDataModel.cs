using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CO2API.Models
{
    public class MobileClientDataModel
    {
        public int UserId { get; set; }
        public double[] StartLocationFormated { get; set; }
        public double[] EndLocationFormated { get; set; }
        public double Distance { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public int BreakCount { get; set; }
        public double AvgBreak { get; set; }
        public double AvgSpeed { get; set; } // km/s        
    }
}