using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*--------------------------------------------------------------------------------------------
 Питання:
1) На Refactoring Guru в описі патерну "Builder" зазначається, що можна з ним використовувати класс Director, до якого можна додати функції, що створюватимуть
об'єкти зі вже готовими значеннями. Тоді питання - чим відрізнається Director від Abstract Factory?
2) Чи обов'язково треба використовувати Abstract Factory з Builder'ом?
----------------------------------------------------------------------------------------------
*/

namespace _1
{
    public enum PizzaTopping
    {
        Cheese,
        Ham,
        Sauce,
        Pepper,
        Ananas,
        Chicken
    }

    public enum PizzaTypes
    {
        Pepperoni,
        HawaiianPizza
    }

    public abstract class PizzaBase
    {
        static int idCount = 0;
        public int id = idCount++;
        public string name;

        public PizzaBase(string name)
        {
            this.name = name;
        }
    }

    public class ThinPizzaBase : PizzaBase
    {
        public ThinPizzaBase(string name):base(name) { }
    }

    public class ThickPizzaBase : PizzaBase
    {
        public ThickPizzaBase(string name) : base(name) { }
    }

    public class Pizza
    {
        public PizzaTypes name;
        public Dictionary<PizzaTopping, float> toppings; //topping - amount
        public PizzaBase _base;

        public Pizza()
        {
            toppings = new Dictionary<PizzaTopping, float>();
        }

        public string getInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {this.name.ToString()}");
            stringBuilder.AppendLine($"Base: {this._base.name}");
            stringBuilder.AppendLine($"Toppings: {String.Join(", ", this.toppings)}");
            return stringBuilder.ToString();
        }
    }


    public class PizzaBuilder
    {
        private Pizza pizza;

        public PizzaBuilder()
        {
            pizza = new Pizza();
        }

        public PizzaBuilder addTopping(PizzaTopping topping, float quantity)
        {
            this.pizza.toppings.Add(topping,quantity);
            return this;
        }
        public PizzaBuilder setBase(PizzaBase _base)
        {
            this.pizza._base = _base;
            return this;
        }
        public PizzaBuilder setName(PizzaTypes type)
        {
            this.pizza.name = type;
            return this;
        }
        public Pizza build()
        {
            try
            {
                return this.pizza;
            }
            finally
            {
                reset();
            }
        }
        public PizzaBuilder reset()
        {
            this.pizza = new Pizza();
            return this;
        }
    }

    public interface IPizzaFactory
    {
        Pizza Create(PizzaBuilder pb);
    }

    public class PepperoniFactory : IPizzaFactory
    {
        public Pizza Create(PizzaBuilder pb)
        {

            pb.setBase(new ThickPizzaBase("Thick"))
                .addTopping(PizzaTopping.Cheese, 100)
                .addTopping(PizzaTopping.Ham, 250)
                .addTopping(PizzaTopping.Sauce, 50)
                .setName(PizzaTypes.Pepperoni);
            return pb.build();
        }
    }
    public class HawaiianPizzaFactory : IPizzaFactory
    {
        public Pizza Create(PizzaBuilder pb)
        {

            pb.setBase(new ThickPizzaBase("Thin"))
                .addTopping(PizzaTopping.Cheese, 100)
                .addTopping(PizzaTopping.Chicken, 250)
                .addTopping(PizzaTopping.Sauce, 50)
                .addTopping(PizzaTopping.Ananas, 500)
                .setName(PizzaTypes.HawaiianPizza);
            return pb.build();
        }
    }


    public static class Helpers
    {
        static public string askUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        static public Pizza createPizza(IPizzaFactory factory, PizzaBuilder pb)
        {
            return factory.Create(pb);
        }
    }


    internal class Program
    {

        static void Main(string[] args)
        {
            PizzaBuilder pb = new PizzaBuilder();
            Dictionary<PizzaTypes, IPizzaFactory> nameFactoryPairs = new Dictionary<PizzaTypes, IPizzaFactory>();

            nameFactoryPairs.Add(PizzaTypes.HawaiianPizza, new HawaiianPizzaFactory());
            nameFactoryPairs.Add(PizzaTypes.Pepperoni, new PepperoniFactory());

            List<Pizza> pizzas = new List<Pizza>();

            foreach(PizzaTypes type in nameFactoryPairs.Keys) {
                pizzas.Add(Helpers.createPizza(nameFactoryPairs[type], pb));
            }
            
            while (true) {
                try
                {
                    Console.WriteLine("Choose the pizza: ");
                    for (int i = 0; i < pizzas.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) - {pizzas[i].name}");
                        Console.WriteLine();
                    }
                    int userChoice = Convert.ToInt32(Helpers.askUser(""));

                    Console.WriteLine(pizzas[userChoice - 1].getInfo());
                }
                catch (Exception ex) { 
                    Console.WriteLine("Error occured: " + "Ivalid index");
                
                }


            }

        }
    }
}
