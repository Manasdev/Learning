using OrderToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OrderFoodDB _db = new OrderFoodDB();
        /*
        [ChildActionOnly]
        public ActionResult BestReview()
        {
            var bestReview = from r in _reviewList
                             orderby r.ReviewID descending
                             select r;

            return PartialView("_ResultsPartial", bestReview.First());
        }
        */

        // GET: Reviews
        public ActionResult Index([Bind(Prefix = "id")] int restaurantID)
        {

            var restaurant = _db.Restaurants.Find(restaurantID);
            //var model = from r in _reviewList
            //            orderby r.ReviewID
            //            select r;
            //return View(model);
            return View(restaurant);
        }
        /* Learning:  We need to keep the same naming convention as that of the restaurant ID as passed by index*/
        [HttpGet]
        public ActionResult Create(int restaurantID)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview restaurantReview)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(restaurantReview);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = restaurantReview.RestaurantId });
            }

            return View(restaurantReview);
        }
        [HttpGet]
        public ActionResult Edit([Bind(Prefix = "id")] int id)
        {
            var reviewData = _db.Reviews.Find(id);
            return View(reviewData);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview restaurantReview)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurantReview).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = restaurantReview.RestaurantId });
            }
            else
                return View(restaurantReview);
        }

        protected override void Dispose(bool disposing)
        {
            if (_db == null)
                _db.Dispose();
            base.Dispose(disposing);
        }
        /*
                // GET: Reviews/Details/5
                public ActionResult Details(int id)
                {
                    return View();
                }

                // GET: Reviews/Create
                public ActionResult Create()
                {
                    return View();
                }

                // POST: Reviews/Create
                [HttpPost]
                public ActionResult Create(FormCollection collection)
                {
                    try
                    {
                        // TODO: Add insert logic here

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: Reviews/Edit/5
                public ActionResult Edit(int id)
                {
                    //var review = _reviewList.Single(r => r.ReviewID == id);
                    //return View(review);
                    return View();
                }

                // POST: Reviews/Edit/5
                [HttpPost]
                public ActionResult Edit(int id, FormCollection collection)
                {
                    try
                    {
                        //var reviewSelected = _reviewList.Single(r => r.ReviewID == id);
                        //if (TryUpdateModel(reviewSelected))

                        //    return RedirectToAction("Index");
                        //else
                        //    return View(reviewSelected);
                        return View();
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: Reviews/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: Reviews/Delete/5
                [HttpPost]
                public ActionResult Delete(int id, FormCollection collection)
                {
                    try
                    {
                        // TODO: Add delete logic here

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }

                /*
                We had used this to populate data
                static List<RestaurantReview> _reviewList = new List<RestaurantReview>
                {
                    new RestaurantReview { ReviewID=1, Name="MTR", City="Mysore", Country="India",Rating=5},
                     new RestaurantReview {ReviewID=2, Name="Dosa Point", City="Mysore", Country="India",Rating=4 },
                      new RestaurantReview { ReviewID=3, Name="RR", City="Mysore", Country="India",Rating=3},
                       new RestaurantReview {ReviewID=4, Name="Hanmanthu", City="Mysore", Country="India",Rating=2 },

                };
                */
    }
}
