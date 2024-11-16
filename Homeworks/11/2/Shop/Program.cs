using Shop.Entity;
using Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductRepository productRepository = new ProductRepository();

            productRepository.delete(2);
            productRepository.insert(new Product(3,"Go",300,1));

            productRepository.update(new Product(3, "Go Game", 400, 1));

            List<Product> firstTwentyCities = productRepository.getAll(0, 20);

            foreach (Product city in firstTwentyCities)
            {
                Console.WriteLine(city.Name);
            }
        }
    }
}
