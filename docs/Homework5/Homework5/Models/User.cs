using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Homework5.Models
{
    public class User
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int DriversLicense { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(128)]
        public string MiddleName { get; set; }

        [Required, StringLength(128)]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required, StringLength(128)]
        public string UserAddress { get; set; }

        [Required, StringLength(128)]
        public string UserState { get; set; }

        [Required]
        public int ZIP { get; set; }

        [Required, StringLength(128)]
        public string County { get; set; }

        [Required]
        public int UpdateVoter { get; set; }
    }
}