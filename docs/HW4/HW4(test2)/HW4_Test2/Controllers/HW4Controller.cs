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
        public ActionResult Page_1()
        {
            string type = Request.Form["type"];
            string temp = Request.Form["temp"];
            if (type != null)
            {
                Debug.WriteLine(type);
                //Pull the temp from the form and try to convert it to a double
                double dTemp;
                try
                {
                    dTemp = Convert.ToDouble(temp);
                }
                catch (FormatException)
                {
                    ViewBag.newTemp = null;
                    return View();
                }
                catch (OverflowException)
                {
                    ViewBag.newTemp = null;
                    return View();
                }


                double newTemp;
                if (type.StartsWith("c") || type.StartsWith("C"))
                {
                    newTemp = (dTemp * 1.8) + 32;
                }
                else if (type.StartsWith("f") || type.StartsWith("F"))
                {
                    newTemp = (dTemp - 32) * .5556;
                }
                else
                {
                    ViewBag.newTemp = null;
                    return View();
                }

                ViewBag.newTemp = newTemp;

                return View();
            }
            else
                return View();
        }
    }
}