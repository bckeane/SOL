using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSOL.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            //return HttpUtility.HtmlEncode("Hello " + name + ", NumTimes is: " + numTimes);
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();

        }

    }
}
