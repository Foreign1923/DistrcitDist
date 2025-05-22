using DistrictWebapp.Models;
using DistrictWebapp.Repositories;

namespace DistrictWebapp.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _repository;

        public DistrictService(IDistrictRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<District>> GetAllDistrictsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<District?> GetDistrictByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<District>> GetDistrictsByCityIdAsync(int cityId)
        {
            return await _repository.GetByCityIdAsync(cityId);
        }

        public async Task AddDistrictAsync(District district)
        {
            await _repository.AddAsync(district);
        }

        public async Task UpdateDistrictAsync(District district)
        {
            await _repository.UpdateAsync(district);
        }

        public async Task DeleteDistrictAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
