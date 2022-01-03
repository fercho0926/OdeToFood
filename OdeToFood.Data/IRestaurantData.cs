using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() {
                new Restaurant { Id = 1, Name = "Milton Pizza",Location = "Colombia", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 2, Name = "Milton hamburguer", Location = "Henderson", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Milton patapas", Location = "EEUU", Cuisine = CuisineType.Italian }
            };
        }
        IEnumerable<Restaurant> IRestaurantData.GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }


}
