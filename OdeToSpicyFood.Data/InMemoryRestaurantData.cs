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
                new Restaurant { Id = 1, Name = "Curry Up Indian Grill", Street = "6181 Sawmill Rd", City = "Dublin", State = "OH", Zip = 43215, Rating = 4.2, Cuisine = CuisineType.Indian },
                new Restaurant { Id = 1, Name = "Hot Chicken Takeover", Street = "59 Spruce St", City = "Columbus", State = "OH", Zip = 43212, Rating = 4.4, Cuisine = CuisineType.American },
                new Restaurant { Id = 1, Name = "Fukuryu Ramen", Street = "4540 Bridge Park Ave", City = "Dublin", State = "OH", Zip = 43017, Rating = 4.6, Cuisine = CuisineType.Japanese },
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
                restaurant.Street = updatedRestaurant.Street;
                restaurant.City = updatedRestaurant.City;
                restaurant.State = updatedRestaurant.State;
                restaurant.Zip = updatedRestaurant.Zip;
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

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
