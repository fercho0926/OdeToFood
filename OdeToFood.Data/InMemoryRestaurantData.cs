using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
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
        IEnumerable<Restaurant> IRestaurantData.GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.Contains(name)
                   orderby r.Name
                   select r;
        }


        public Restaurant GetById(int id)
        {

            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);
        if (restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant) {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id + 1);
            return newRestaurant;

        }


        public int commit() {
            return 0;
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
