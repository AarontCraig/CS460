﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW4_Test2.Controllers
{
    public class HW4Controller : Controller
    {
        //Function for calculating temperature for the first two pages
        public double CalculateTemp(string type, string temp)
        {
            if (type != null)
            {
                //Pull the temp from the form and try to convert it to a double
                double dTemp = 0;
                //Check to see if what the function is given is actually a number
                try
                {
                    dTemp = Convert.ToDouble(temp);
                }
                catch (FormatException)
                {
                    return 0.12345;
                }
                catch (OverflowException)
                {
                    return 0.12345;
                }
                //Convert the temperature defending on what type the user types in
                double newTemp;
                if (type.StartsWith("c") || type.StartsWith("C"))
                {
                    newTemp = (dTemp * 1.8) + 32;
                    return newTemp;
                }
                else if (type.StartsWith("f") || type.StartsWith("F"))
                {
                    newTemp = (dTemp - 32) * .5556;
                    return newTemp;
                }
                else //Returns something invalid, since it can't be null
                {
                    return 0.12345;
                }
            }
            else //My specific number, which is actually symbalizing a null
            {
                return 0.12345;
            }
        }
        public ActionResult Page_1()
        {
            string type = Request.Form["type"];
            string temp = Request.Form["temp"];

            ViewBag.newTemp = CalculateTemp(type, temp);

            return View();
        }

        [HttpGet]
        public ActionResult Page_2()
        {
            ViewBag.newTemp = 0.12345; //Sets it to the default, which is null (in this case)
            return View();
        }

        [HttpPost]
        public ActionResult Page_2(FormCollection form)
        {
            ViewBag.newTemp = CalculateTemp(form.Get("type"), form.Get("temp"));
            return View();
        }

        [HttpGet]
        public ActionResult Awesome_Calculator()
        {
            //Set the defaults for the input
            ViewBag.name = "";
            ViewBag.age = "";
            ViewBag.gamesBeaten = "";
            return View();
        }

        [HttpPost]
        public ActionResult Awesome_Calculator(string name, int? age, int? gamesBeaten)
        {
            //Error checking for all three types
            try
            {
                Convert.ToDouble(name);
                ViewBag.name = null;
            }
            catch
            {
                ViewBag.name = name;
            }

            if (age < 0 || age > 100)
                ViewBag.age = null;
            else
                ViewBag.age = age;

            if (gamesBeaten < 0 || gamesBeaten > 3)
                ViewBag.gamesBeaten = null;
            else
                ViewBag.gamesBeaten = gamesBeaten;
            //if (age == null)
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //Discern awewsomeness level
            ViewBag.aweLevel = (gamesBeaten * 10000) - (age * 50);
            return View();
        }
    }
}