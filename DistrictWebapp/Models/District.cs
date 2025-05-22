namespace DistrictWebapp.Models
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictCode { get; set; }
        public string Name { get; set; }
        public string Population { get; set; }
        public string MalePopulation { get; set; }
        public string FemalePopulation { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }

}
