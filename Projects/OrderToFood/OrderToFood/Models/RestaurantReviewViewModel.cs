using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderToFood.Models
{
    public class RestaurantReviewViewModel
    {
        public int RestaurantID { get; set; }
        public String City { get; set; }
        public String Name { get; set; }
        public String Country { get; set; }
        public int ReviewsCount { get; set; }
    }
}