using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Assignment.DB;

namespace Assignment.Models
{
    public class StudentViewModel
    {
        [Required]
        [StringLength(100)]
        public string StID { get; set; }
        public string Password { get; set; }
        public string PortalID { get; set; }
        public Class MyProperty { get; set; }
        public string ClassID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}