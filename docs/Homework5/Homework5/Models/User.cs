using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework5.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        public int DriversLicense { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(64)]
        public string MiddleName { get; set; }

        [Required, StringLength(64)]
        public string LastName { get; set; }
    }
}