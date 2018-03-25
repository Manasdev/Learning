using OrderToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderToFood.Controllers
{
    public class HomeController : Controller
    {
        OrderFoodDB _db = new OrderFoodDB();

        public ActionResult Index(string searchTerm = null)
        {
            // var model = _db.Restaurants.ToList();

            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select new
            //            RestaurantReviewViewModel
            //            { RestaurantID = r.RestaurantID, City = r.City, Name = r.Name, Country = r.Country, ReviewsCount = r.Reviews.Count() };


            var model = _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Take(10)
                .Select(r => new RestaurantReviewViewModel { City = r.City, Country = r.Country, Name = r.Name, RestaurantID = r.RestaurantID, ReviewsCount = r.Reviews.Count() });

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ResultsPartial", model);
            }
            return View(model);
        }

        public ActionResult About()
        {
            var modelAbout = new AboutModels();
            modelAbout.Name = "Manas";
            modelAbout.Location = "Mysore,India";

            //ViewBag.Message = "Your application description page.";
            //ViewBag.Location = "Mysore,India";
            return View(modelAbout);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}