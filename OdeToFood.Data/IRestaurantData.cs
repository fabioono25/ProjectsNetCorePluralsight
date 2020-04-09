using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        //a List is not thread safe: cannot process multiple requests
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Japan Food", Cuisine = Restaurant.CuisineType.Japanese, Location = "Jp Street" },
                new Restaurant { Id = 2, Name = "Italian Food", Cuisine = Restaurant.CuisineType.Italian, Location = "Ita Street" },
                new Restaurant { Id = 3, Name = "Indian Food", Cuisine = Restaurant.CuisineType.Indian, Location = "Indian Street" }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
