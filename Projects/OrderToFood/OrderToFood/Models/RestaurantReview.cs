using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderToFood.Models
{
    public class RestaurantReview
    {
        [Key]
        public int ReviewID { get; set; }

        [Range(1, 10)]
        [Required]
        public int Rating { get; set; }

        [StringLength(100)]
        public string ReviewBody { get; set; }
        public int RestaurantId { get; set; }
        [Display(Name = "Reviewer Name")]
        [DisplayFormat(NullDisplayText = "Anonymous")]
        public string ReviewerName { get; set; }
    }
}