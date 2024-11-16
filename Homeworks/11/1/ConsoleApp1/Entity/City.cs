

namespace CityNamespace
{
    public class City
    {
        public int Id { get; }
        public string Name { get; set; }
        public string District { get; set; }
        public string CountryCode { get; set; }
        public int Population {  get; set; }

        public City(string name, string district, string countryCode, int population)
        {
            this.Name = name;
            this.District = district;
            this.CountryCode = countryCode;
            this.Population = population;
        }

        public City(int id, string name, string district, string countryCode, int population)
        {
            this.Id = id;
            this.Name = name;
            this.District = district;
            this.CountryCode = countryCode;
            this.Population = population;
        }

    }
}
