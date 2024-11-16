using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository
{
    public class ProductRepository
    {
        private string connectionString;
        public ProductRepository()
        {
            this.connectionString = $"Server=localhost;Port=3306;database=shop;uid=root;pwd=root;";
        }

        public int create(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"INSERT INTO product (name,category_id,price) VALUES({product.Name},{product.CategoryId},{product.Price}) "; // - чи можлива при такому підході SQL injection атака?

                using (var command = new MySqlCommand(query, connection))
                {

                    command.ExecuteNonQuery();

                    return (int)command.LastInsertedId;
                }
            }
        }

        public void update(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"UPDATE product SET name = '{product.Name}', category_id = {product.CategoryId}, price = {product.Price} WHERE ID={product.Id}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void delete(int productId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"DELETE FROM product WHERE ID = {productId}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void insert(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"INSERT INTO product (name,category_id,price) VALUES ('{product.Name}','{product.CategoryId}', '{product.Price}')";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> getAll(int offset = 10, int limit = 20)
        {
            List<Product> products = new List<Product>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM product ORDER BY name LIMIT {limit} OFFSET {offset}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product(
                                reader.GetInt32("id"),
                                reader.GetString("name"),
                                reader.GetInt32("price"),
                                reader.GetInt32("category_id")
                                ));
                        }
                    }
                }
            }
            return products;
        }


        public Product get(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM product WHERE id = {id}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product(
                                reader.GetInt32("id"),
                                reader.GetString("name"),
                                reader.GetInt32("price"),
                                reader.GetInt32("category_id")
                                );
                        }

                    }
                }
            }
            return null;
        }
    }
}
