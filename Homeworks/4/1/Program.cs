using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp18
{
    // Entity
    class PhoneContact
    {
        //private public protected
        private static int autoInc = 1;
        private int id = 0;
        private string name = "";
        private string phone = "";

        public PhoneContact()
        {

        }

        public PhoneContact(string name, string phone)
        {
            this.id = autoInc++;
            this.name = name;
            this.phone = phone;
        }

        public int getId()
        {
            return id;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public string getName() => this.name;

        public void setPhone(string phone)
        {
            this.phone = phone;
        }
        public string getPhone() => this.phone;
    }

    //Service
    class PhoneBook
    {
        private List<PhoneContact> contacts = null;


        public PhoneBook()
        {
            contacts = new List<PhoneContact>();

        }


        public PhoneContact create(string name, string phone) // phone validation
        {
            validateContact(name, phone);
            contacts.Add(new PhoneContact(name, phone));
            return contacts.Last();
        }

        public List<PhoneContact> getContacts() { return contacts; }

        public PhoneContact getContact(int id) // return exception if not found
        {
            PhoneContact contact = contacts.Find(value => value.getId() == id);
            if(contact == null)
            {
                throw new Exception("Error: the contact with that id doesn't exist!");
            }
            return contact;
        }

        public PhoneContact update(int id, string name, string phone)
        {
            PhoneContact contact = idValidation(id);
            validateContact(name, phone);

            contact.setName(name);
            contact.setPhone(phone);

            return contact;
        }

        public bool remove(int id)
        {
            PhoneContact contact = idValidation(id);

            return contacts.Remove(contact);
        }

        private bool phoneValidation(string phone)
        {
            phone = phone.Trim();
            if (phone.Length < 7)
            {
                return false;
            }
            string reg = @"^\+?(38)?0{1}\d+$";
            return Regex.IsMatch(phone, reg);
        }

        private bool existenceValidation(string name, string phone)
        {
            foreach (PhoneContact item in contacts)
            {
                if (item.getName() == name || item.getPhone() == phone)
                {
                    return true;
                }
            }
            return false;
        }
        private PhoneContact idValidation(int id)
        {
            PhoneContact contact = contacts.Find(value => value.getId() == id);

            if (contact == null)
                throw new Exception("Error: contact with that id doesn't exist!");
            return contact;
        }
        private void validateContact(string name, string phone)
        {
            phone = phone.Trim();

            if (name.Trim().Length < 2)
            {
                throw new Exception("Error: short name!");
            }
            if (!phoneValidation(phone))
            {
                throw new Exception("Error: invalid phone number!");
            }

            if (existenceValidation(name, phone))
            {
                throw new Exception("Error: contact already exists!");
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
    class Program
    {
        static void Main(string[] args)
        {
            List<string> operations = new List<string>() { "Create", "Update", "Remove", "Get Contact", "Show All", "Exit" };
            Console.WriteLine("Welcome to the Phone Book application! The list of supported operations:");
            for (int i = 0; i < operations.Count; i++)
            {
                Console.WriteLine($"\t{i} - {operations[i]}");
            }
            PhoneBook phoneBook = new PhoneBook();
            while (true)
            {
                try
                { 
                    int operation = Convert.ToInt32(Helper.askUser("Choose an operation: "));

                    if (!(operation>=0 && operation < operations.Count)) 
                    {
                        throw new Exception("Error: invalid operation!");
                    }

                    List<string> messages = new List<string>() {"Insert an id: ", "Insert a name: ", "Insert a phone: "};

                    switch (operation)
                    {
                        case 0:
                            phoneBook.create(Helper.askUser(messages[1]), Helper.askUser(messages[2]));
                            break;
                        
                        case 4:
                            foreach(PhoneContact item in phoneBook.getContacts())
                            {
                                Console.WriteLine($"{item.getId()}) {item.getName()}: {item.getPhone()}");
                            }
                            break;
                        case 5:
                            return;

                        default:
                            int id = Convert.ToInt32(Helper.askUser(messages[0]));
                            switch (operation)
                            {
                                case 1:
                                    phoneBook.update(id, Helper.askUser(messages[1]), Helper.askUser(messages[2]));
                                    break;
                                case 2:
                                    phoneBook.remove(id);
                                    break;
                                case 3:
                                    PhoneContact contact = phoneBook.getContact(id);
                                    Console.WriteLine($"{contact.getId()}) {contact.getName()}: {contact.getPhone()}");
                                    break;
                            }       
                            break;
                    }

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