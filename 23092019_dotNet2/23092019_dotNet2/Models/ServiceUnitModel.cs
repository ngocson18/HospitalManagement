using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23092019_dotNet2.Models
{
    public class ServiceUnitModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public int priceVND { get; set; }

        public int priceUSD { get; set; }

        public string note { get; set; }

        public int status { get; set; }
    }
}