using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
1) Class Product:
-- Price
-- Quantity 
-- Name
-- Set quanitity func
2) Class Shop:
-- List with products
-- Buy function 
--- Check if that quantity is present
--- Subtract from 
3) While loop
-- Print the catalogue
-- Ask to choose the product and insert the cash

 */


namespace _2
{
    class Product
    {
        private string _name;
        private int _quantity;
        private int _price;

        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public int quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; }
        }
        public int price
        {
            get { return this._price; }
            set { this._price = value; }
        }
        public Product(string name,int price, int quantity) {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

    }

    class Shop
    {
        private List<Product> products = null;
        public Shop(List<Product> products)
        {
            this.products = products;
        }
        public List<Product> getProducts() {
            return products;
        }
        public void addProduct(Product item) {
            products.Add(item);
        }
        public List<string> buyProduct(string name, int cash)
        {
            Product product = products.Find(item=>item.name==name.ToLower());
            if(product == null)
            {
                throw new Exception("Invalid product name!");
            }
            int quantity = (cash * 100) / (product.price * 100);
            if(quantity > product.quantity)
            {
                throw new Exception("Not enough products in the shop!");
            }
            if(quantity < 0)
            {
                throw new Exception("Not enough money provided!");
            }
            product.quantity = product.quantity - quantity;
            int cashLeft = ((cash*100) - (product.price*quantity*100))/100;
            return new List<string>() { product.name, Convert.ToString(quantity), Convert.ToString(cashLeft)};
        }
    }



    internal class Program
    {
        static public string askUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>() { new Product("soap",12,34), new Product("toothpaste", 52, 56) , new Product("shampoo", 70, 12)};
            Console.WriteLine("Welcome to the Shop application.");

            Shop shop = new Shop(products);

            while (true)
            {
                try
                {
                    Console.WriteLine("Available products: ");
                    foreach (Product item in shop.getProducts())
                    {
                        Console.WriteLine($"{item.name}: {item.quantity}x{item.price} ");
                    }
                    string name = askUser("\nInsert the name of the product: ");
                    int money = Convert.ToInt32(askUser("Insert the available money: "));

                    List<string> answer = shop.buyProduct(name,money);

                    Console.WriteLine($"You bought {answer[0]}x{answer[1]}. And your change is: {answer[2]}");
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine();
                }

            }

        }
    }
}
