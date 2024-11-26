using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1
{
    public enum PizzaToppings
    {
        Sauce,
        Cheese,
        Pepper,
        Salami
    }
    public enum PizzaBaseType
    {
        Thin,
        Thick
    }
    public class Pizza
    {

        public string name;
        public List<string> toppings;
        public string _base;

        public Pizza()
        {
            toppings = new List<string>();
        }

        public void showInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {this.name}");
            stringBuilder.AppendLine($"Base: {this._base}");
            stringBuilder.AppendLine($"Toppings: {String.Join(", ", this.toppings.ToArray())}");
            Console.WriteLine(stringBuilder.ToString());
        }

    }

    public class PizzaBuilder
    {
        private Pizza pizza;
        public PizzaBuilder()
        {
            reset();
        }
        public void reset()
        {
            this.pizza = new Pizza();
        }
        public void createBase<T>(T type)
        {
            this.pizza._base = type.ToString();
        }
        public void addTopping<T>(T topping)
        {
            
            this.pizza.toppings.Add(topping.ToString()); 
        }
        public void setName(string name) {
            this.pizza.name = name;
        }
        public Pizza getPizza()
        {
            Pizza product = this.pizza;
            reset();
            return product;
        }
    }

    public class PizzaDirector
    {
        public void buildPepperoni(PizzaBuilder builder)
        {
            builder.createBase(PizzaBaseType.Thick);

            builder.addTopping(PizzaToppings.Sauce);
            builder.addTopping(PizzaToppings.Salami);
            builder.addTopping(PizzaToppings.Pepper);

            builder.setName("Pepperoni");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PizzaBuilder builder = new PizzaBuilder();
            PizzaDirector director = new PizzaDirector();

            director.buildPepperoni(builder);
            Pizza pepperoni = builder.getPizza();

            pepperoni.showInfo();
        }
    }
}
