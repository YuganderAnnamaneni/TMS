using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Web.Client.Models
{
    public class Attendance
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

        public string Remarks { get; set; }
    }
}