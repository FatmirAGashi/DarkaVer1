using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darka.Core;
using Darka.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Darka.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant> Restaurants {get; set;}

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public string Message { get; set; }
       

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {

            
            Message = "Message";
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}