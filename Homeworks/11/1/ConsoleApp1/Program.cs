using CityNamespace;
using CityRepositoryNamespace.Repository;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{   
   
    class Program
    {
        static void Main(string[] args)
        {

            Connector connector = new Connector("localhost", "3306", "world","root","root");

            CityRepository cityRepository = new CityRepository(connector);

            cityRepository.delete(1);
            cityRepository.delete(2);

            List<City> firstTwentyCities = cityRepository.getAll(0, 20);

            foreach(City city in firstTwentyCities)
            { 
                Console.WriteLine(city.Name);
            }


        }
    }
}
