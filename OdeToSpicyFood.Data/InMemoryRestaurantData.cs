using OdeToSpicyFood.Core;
using System;
using System.Linq;
using System.Collections.Generic;

namespace OdeToSpicyFood.Data
{
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

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }


        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Rating = updatedRestaurant.Rating;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) 
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }
}
