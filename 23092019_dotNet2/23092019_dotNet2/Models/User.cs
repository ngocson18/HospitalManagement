using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;


namespace _23092019_dotNet2.Models
{
    public class User
    {
        public string id { get; set; }

        public string name { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        [DataType(DataType.Date)]
        public DateTime dob { get; set; }

        public int departmentId { get; set; }

        public int gender { get; set; }

        public string phone { get; set; }

        public int groupId { get; set; }

        public string groupName { get; set; }

        public string email { get; set; }

        public int status { get; set; }
    }
}