using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updateRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);

        int getCountOfRestaurants();
        int commit();

    }

}
