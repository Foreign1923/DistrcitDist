namespace DistrictWebapp.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlateCode { get; set; }
        public string AreaCode { get; set; }
        public string Population { get; set; }
        public string Region { get; set; }
        public string AreaSize { get; set; }
        public string PopulationGrowth { get; set; }
        public string MaleRatio { get; set; }
        public string MalePopulation { get; set; }
        public string FemaleRatio { get; set; }
        public string FemalePopulation { get; set; }
        public string PopulationRateNational { get; set; }

        public ICollection<District> Districts { get; set; }
    }


}
