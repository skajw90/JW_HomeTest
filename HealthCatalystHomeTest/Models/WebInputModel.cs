using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCatalystHomeTest.Models
{
    public class WebInputModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Interests { get; set; }
        public HttpPostedFile Image { get; }
    }
}