using DistrictWebapp.Models;

namespace DistrictWebapp.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<City?> GetByIdAsync(int id);
        Task<IEnumerable<City>> SearchByNameAsync(string name);
        Task AddAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(int id);
    }
}
