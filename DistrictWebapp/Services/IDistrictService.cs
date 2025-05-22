using DistrictWebapp.Models;

namespace DistrictWebapp.Services
{
    public interface IDistrictService
    {
        Task<IEnumerable<District>> GetAllDistrictsAsync();
        Task<District?> GetDistrictByIdAsync(int id);
        Task<IEnumerable<District>> GetDistrictsByCityIdAsync(int cityId);
        Task AddDistrictAsync(District district);
        Task UpdateDistrictAsync(District district);
        Task DeleteDistrictAsync(int id);
    }
}
