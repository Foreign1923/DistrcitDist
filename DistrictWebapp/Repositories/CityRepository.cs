using DistrictWebapp.Data;
using DistrictWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace DistrictWebapp.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;
        public CityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities.Include(c=> c.Districts).ToListAsync();
        }

        public async Task<City?> GetByIdAsync(int id)
        {
            return await _context.Cities.Include(c => c.Districts).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<City>> SearchByNameAsync(string name)
        {
            return await _context.Cities
                    .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                    .ToListAsync();
        }

        public async Task UpdateAsync(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();

        }
        
    }
    
}
