using Helpers;
using MySql.Data.MySqlClient;
using CityNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityRepositoryNamespace.Repository
{
    public class CityRepository
    {
        private string connectionString;
        public CityRepository(Connector connector)
        {
            this.connectionString = $"Server={connector.server};Port={connector.port};database={connector.database};uid={connector.user};pwd={connector.password};";
            Console.WriteLine(connectionString);

        }

        public int create(City city)
        {

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO city (Name, CountryCode, District, Population) VALUES (@Name, @CountryCode, @District, @Population)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Name", city.Name);
                    command.Parameters.AddWithValue("CountryCode", city.CountryCode);
                    command.Parameters.AddWithValue("District", city.District);
                    command.Parameters.AddWithValue("Population", city.Population);

                    command.ExecuteNonQuery();

                    return (int)command.LastInsertedId;
                }
            }
                
        }

        public void update(City city)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE city SET Name=@Name, CountryCode=@CountryCode, District=@District,Population=@Population WHERE ID=@Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Name", city.Name);
                    command.Parameters.AddWithValue("CountryCode", city.CountryCode);
                    command.Parameters.AddWithValue("District", city.District);
                    command.Parameters.AddWithValue("Population", city.Population);
                    command.Parameters.AddWithValue("Id", city.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        

        public void delete(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM city WHERE ID = @Id";

                using (MySqlCommand command = new MySqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }


        public City get(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM city WHERE ID = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("Id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new City(
                                reader.GetInt32("ID"), 
                                reader.GetString("Name"), 
                                reader.GetString("District"),
                                reader.GetString("CountryCode"),
                                reader.GetInt32("Population"));
                        }
                    }
                }
            }

            return null;
        }

        public List<City> getAll(int offset = 0, int limit = 25)
        {

            List<City> list = new List<City>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM city LIMIT @Limit OFFSET @Offset;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Offset", offset);
                    command.Parameters.AddWithValue("Limit", limit);


                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            list.Add(new City (
                                reader.GetInt32("ID"),
                                reader.GetString("Name"),
                                reader.GetString("District"),
                                reader.GetString("CountryCode"),
                                reader.GetInt32("Population")));
                        }
                        return list;

                    }
                }
            }
        }
    }
}
