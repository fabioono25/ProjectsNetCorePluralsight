using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            this.context = context;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            //context.Restaurants.Add()
            context.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if (restaurant != null)
            {
                context.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return context.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in context.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = context.Restaurants.Attach(updatedRestaurant); //important
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public int GetCountOfRestaurants()
        {
            //cache
            return context.Restaurants.Count();
        }
    }
}
