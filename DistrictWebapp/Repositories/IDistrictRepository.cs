using DistrictWebapp.Models;

namespace DistrictWebapp.Repositories
{
    public interface IDistrictRepository 
    {
        Task<IEnumerable<District>> GetAllAsync();
        Task<District?> GetByIdAsync(int id);
        Task<IEnumerable<District>> GetByCityIdAsync(int cityId);
        Task AddAsync(District district);
        Task UpdateAsync(District district);
        Task DeleteAsync(int id);
    }
}
