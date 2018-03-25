namespace OrderToFood.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrderToFood.Models.OrderFoodDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OrderToFood.Models.OrderFoodDB context)
        {
            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.Add(new Models.Restaurant { City = "Mysore", Country = "India", Name = i + "_Nalpak_", Reviews = new List<RestaurantReview> { new RestaurantReview { Rating = 9, ReviewBody = "Awesome", ReviewerName = "Koole" } } });
                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
