using DistrictWebapp.Data;
using DistrictWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace DistrictWebapp.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly AppDbContext _context;

        public DistrictRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<District>> GetAllAsync()
        {
            return await _context.Districts.Include(d => d.City).ToListAsync();
        }

        public async Task<District?> GetByIdAsync(int id)
        {
            return await _context.Districts.Include(d => d.City).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<District>> GetByCityIdAsync(int cityId)
        {
            return await _context.Districts
                .Where(d => d.CityId == cityId)
                .ToListAsync();
        }

        public async Task AddAsync(District district)
        {
            _context.Districts.Add(district);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(District district)
        {
            _context.Districts.Update(district);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var district = await _context.Districts.FindAsync(id);
            if (district != null)
            {
                _context.Districts.Remove(district);
                await _context.SaveChangesAsync();
            }
        }
    }
}
