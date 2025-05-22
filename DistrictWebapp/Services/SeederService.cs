using DistrictWebapp.Data;
using DistrictWebapp.DTOs;
using DistrictWebapp.Models;
using System.Text.Json;

namespace DistrictWebapp.Services
{
    public class SeederService
    {
        private readonly AppDbContext _context;

        public SeederService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedFromJsonAsync()
        {
            if (_context.Cities.Any()) return; // Zaten veri varsa ekleme

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "il-ilce.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("JSON dosyası bulunamadı.", filePath);

            var json = await File.ReadAllTextAsync(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var jsonData = JsonSerializer.Deserialize<JsonWrapper>(json, options);

            if (jsonData?.data == null) return;

            foreach (var cityDto in jsonData.data)
            {
                var city = new City
                {
                    Name = cityDto.il_adi.Trim(),
                    PlateCode = cityDto.plaka_kodu.Trim(),
                    AreaCode = cityDto.alan_kodu,
                    Population = cityDto.nufus,
                    Region = cityDto.bolge,
                    AreaSize = cityDto.yuzolcumu,
                    PopulationGrowth = cityDto.nufus_artisi,
                    MaleRatio = cityDto.erkek_nufus_yuzde,
                    MalePopulation = cityDto.erkek_nufus,
                    FemaleRatio = cityDto.kadin_nufus_yuzde,
                    FemalePopulation = cityDto.kadin_nufus,
                    PopulationRateNational = cityDto.nufus_yuzdesi_genel,
                    Districts = cityDto.ilceler.Select(d => new District
                    {
                        DistrictCode = d.ilce_kodu,
                        Name = d.ilce_adi,
                        Population = d.nufus,
                        MalePopulation = d.erkek_nufus,
                        FemalePopulation = d.kadin_nufus
                    }).ToList()
                };

                _context.Cities.Add(city);
            }

            await _context.SaveChangesAsync();
        }

        private class JsonWrapper
        {
            public List<CitySeedDto> data { get; set; }
        }
    }
}
