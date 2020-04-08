using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
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

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants;
        }
    }
}
