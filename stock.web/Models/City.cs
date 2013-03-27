namespace stock.web.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string District { get; set; }
        public uint Population { get; set; }
    }
}