using OdeToSpicyFood.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OdeToSpicyFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Spice R Us", Location = "Ohio", Rating = 4.5, Cuisine = CuisineType.American },
                new Restaurant { Id = 2, Name = "Sunflower", Location = "California", Rating = 4.2, Cuisine = CuisineType.Chinese },
                new Restaurant { Id = 3, Name = "Three Fat Indians", Location = "New York", Rating = 4.7, Cuisine = CuisineType.Indian },
                new Restaurant { Id = 4, Name = "Jalapenoooo", Location = "Alabama", Rating = 3.2, Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 5, Name = "Numi Numi", Location = "Oregon", Rating = 4.6, Cuisine = CuisineType.Japanese },
                new Restaurant { Id = 6, Name = "Lorenzo's Pizzeria", Location = "Ohio", Rating = 4.8, Cuisine = CuisineType.Italian }
            };
        }

        public IEnumerable<Restaurant> GetAll() 
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
