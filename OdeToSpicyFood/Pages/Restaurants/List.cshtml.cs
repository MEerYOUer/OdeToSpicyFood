﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToSpicyFood.Core;
using OdeToSpicyFood.Data;

namespace OdeToSpicyFood
{
    public class ListModel : PageModel
    {
        private IRestaurantData restaurantData;

        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}