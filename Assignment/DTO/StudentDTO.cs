using Assignment.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Assignment.DTO
{
    public class StudentDTO
    {
        [Required]
        [StringLength(100)]
        public string StID { get; set; }
        [Required]
        [StringLength(100)]
        public string StName { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string PortalID { get; set; }
        public string ClassID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ClassDTO Class { get; set; }
    }
}