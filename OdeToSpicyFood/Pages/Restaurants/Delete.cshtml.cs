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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if(restaurant == null)
            {
                RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} deleted.";
            return RedirectToPage("./List");
        }
    }
}