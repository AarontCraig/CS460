using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Homework5.Models
{
    //A user from my DB
    public class User
    {
        //This is the PK, and it will auto increment, I don't need to set it
        public int ID { get; set; }
        //Change the display for many of these, so it looks better in the display forms
        [Display(Name = "Drivers License #")]
        public int DriversLicense { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Street Address")]
        public string UserAddress { get; set; }

        public string City { get; set; }

        [Display(Name = "State")]
        public string UserState { get; set; }

        [Display(Name = "ZIP Code")]
        public int ZIP { get; set; }

        public string County { get; set; }

        [Display(Name = "Update your voting preferences?")]
        public int UpdateVoter { get; set; }
    }
}