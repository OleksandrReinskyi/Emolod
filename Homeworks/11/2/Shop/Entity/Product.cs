using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entity
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int CategoryId{ get; set; }

        public Product(int id, string name, int price, int categoryId)
        {
            Id = id;
            Name = name;
            Price = price;
            this.CategoryId = categoryId;
        }


    }
}
