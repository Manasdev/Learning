using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderToFood.Controllers
{
    public class CuisineController : Controller
    {
        //[Authorize]
        // GET: Cuisine
        public ActionResult Search(string name)
        {
            var message = Server.HtmlEncode(name);

            // throw new Exception("Something Happended");
            //This just returns a string if not a view
            return Content(message);
            //return RedirectToAction("Index", "Home", new { name = name });
            //return File(Server.MapPath("~/content/site.css"), "text");


        }


    }
}