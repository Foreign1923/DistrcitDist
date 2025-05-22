namespace DistrictWebapp.DTOs
{
    public class CitySeedDto
    {
        public string il_adi { get; set; }
        public string plaka_kodu { get; set; }
        public string alan_kodu { get; set; }
        public string nufus { get; set; }
        public string bolge { get; set; }
        public string yuzolcumu { get; set; }
        public string nufus_artisi { get; set; }
        public string erkek_nufus_yuzde { get; set; }
        public string erkek_nufus { get; set; }
        public string kadin_nufus_yuzde { get; set; }
        public string kadin_nufus { get; set; }
        public string nufus_yuzdesi_genel { get; set; }
        public List<DistrictSeedDto> ilceler { get; set; }
    }

}
