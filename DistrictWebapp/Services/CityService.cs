using DistrictWebapp.Models;
using DistrictWebapp.Repositories;

namespace DistrictWebapp.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<City?> GetCityByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<City>> SearchCitiesByNameAsync(string name)
        {
            return await _repository.SearchByNameAsync(name);
        }

        public async Task AddCityAsync(City city)
        {
            await _repository.AddAsync(city);
        }

        public async Task UpdateCityAsync(City city)
        {
            await _repository.UpdateAsync(city);
        }

        public async Task DeleteCityAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
