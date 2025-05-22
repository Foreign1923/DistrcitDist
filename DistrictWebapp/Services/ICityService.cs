using DistrictWebapp.Models;

namespace DistrictWebapp.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City?> GetCityByIdAsync(int id);
        Task<IEnumerable<City>> SearchCitiesByNameAsync(string name);
        Task AddCityAsync(City city);
        Task UpdateCityAsync(City city);
        Task DeleteCityAsync(int id);

    }
}
