using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4_Test2.Controllers
{
    public class HW4Controller : Controller
    {
        public double CalculateTemp(string type, string temp)
        {
            if (type != null)
            {
                //Pull the temp from the form and try to convert it to a double
                double dTemp = 0;
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
                else
                {
                    return 0.12345;
                }
            }
            else
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

        public ActionResult Awesome_Calculator()
        {
            return View();
        }
    }
}