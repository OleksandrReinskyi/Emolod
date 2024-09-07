using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{

    // --------------------------------------- 1. -------------------------------------------


    //    class MyList<T>
    //    {


    //        private List<T> _list = new List<T>();

    //        public MyList() { }

    //        public void create(T elem)
    //        {

    //            this._list.Add(elem);
    //        }
    //        public T read(int index) {
    //            CheckIndex(index);
    //            return _list[index];
    //        }
    //        public void update(int index,T elem)
    //        {

    //            CheckIndex(index);
    //            this._list[index] = elem;
    //        }
    //        public void delete(int index) 
    //        {
    //            CheckIndex(index);
    //            this._list.RemoveAt(index);
    //        }

    //        private void CheckIndex(int index)
    //        {
    //            if (index < 0 || index >= this._list.Count)
    //            {
    //                throw new Exception("The index passed is out of bounds!");
    //            }
    //        }

    //    }


    //internal class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //            try
    //            {
    //                MyList<string> list = new MyList<string>();
    //                list.create("a");

    //                Console.WriteLine(list.read(0));

    //                list.update(0, "asb");
    //                Console.WriteLine(list.read(0));
    //                list.delete(0);
    //            } catch (Exception e) { 
    //                Console.WriteLine(e.ToString());

    //            }
    //        }
    //    }


    //----------------------------------- 2. -----------------------------------------

    class TelBook
    {
        private Dictionary<string, string>  _dict = new Dictionary<string, string>();

        public TelBook() { }

        public void add(string name, string tel) {
            this._dict[name] = tel;
            Console.WriteLine($"Added: {name}: {tel}");
        }

        public void delete(string name)
        {
            CheckElement(name);
            this._dict.Remove(name);
            Console.WriteLine($"Removed: {name}: {this._dict[name]}");
        }

        public void showAll()
        {
            foreach (string name in this._dict.Keys) {
                Console.WriteLine($"{name}: {this._dict[name]}");
            }
        }

        public string getContact(string name)
        {
            CheckElement(name);
            return this._dict[name];
        }

        private void CheckElement(string name) { 
            if (!this._dict.ContainsKey(name))
            {
                throw new Exception("The specified key doesn't exist yet!");
            }
        }

    }

    class Helper
    {

        public static string askUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of supported operations: add, delete, showAll, get.");
            TelBook book = new TelBook();
            string[] messages = new string[2] {"Inser a name: ", "Insert a number: "};
            while (true) {
                try {
                    string operation = Helper.askUser("Insert an operation: ");

                    switch (operation.ToLower().Trim()) {
                        case "add":
                            book.add(Helper.askUser(messages[0]), Helper.askUser(messages[1]));
                            break;
                        case "delete":
                            book.delete(Helper.askUser(messages[0]));
                            break;
                        case "showall":
                            book.showAll();
                            break;
                        case "get":
                            Console.WriteLine(book.getContact(Helper.askUser(messages[0])));
                            break;
                        default:
                            throw new Exception("Invalid operation! ");

                    }
                }
                catch (Exception e) { 
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("\n");
                }
            
            }

        }
    }
}
