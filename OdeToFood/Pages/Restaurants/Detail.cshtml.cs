using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {

        public Restaurant Restaurant { get; set; }
        public IRestaurantData RestauranData { get; }

        public DetailModel(IRestaurantData restauranData)
        {
            RestauranData = restauranData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = RestauranData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}

