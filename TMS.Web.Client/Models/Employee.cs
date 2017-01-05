using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Web.Client.Models
{
    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public bool Status { get; set; }

        public bool TagId { get; set; }
    }
}