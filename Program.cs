using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Contact
{

    class Contacts
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contacts(string name, string phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString()
        {
            return $"Name: {Name} \n Phone Number: {PhoneNumber} \n Email: {Email}";
        }



        public static void Main(string[] args)
        {
            ContactsBook contactBook = new ContactsBook();
            contactBook.LoadContacts();

            while (true) 
            {
                Console.WriteLine("\n--- Contact Book Menu ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Search Contact");
                Console.WriteLine("3. Update Contact");
                Console.WriteLine("4. View Contacts");
                Console.WriteLine("5. Sort Contacts");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        contactBook.AddContact(name, phoneNumber, email);
                        break;
                    case "2":
                        Console.Write("Enter Name to search: ");
                        string searchName = Console.ReadLine();
                        Contacts contact = contactBook.SearchContact(searchName);
                        if (contact != null)
                        {
                            Console.WriteLine("Contact Found: " + contact);
                        }
                        else
                        {
                            Console.WriteLine("Contact not found!");
                        }
                        break;
                    case "3":
                        Console.Write("Enter Name to update: ");
                        string updateName = Console.ReadLine();
                        Console.Write("Enter New Phone Number: ");
                        string newPhone = Console.ReadLine();
                        Console.Write("Enter New Email: ");
                        string newEmail = Console.ReadLine();
                        contactBook.updateContacts(updateName, newPhone, newEmail);
                        break;

                    case "4":
                        contactBook.DisplayContacts();
                        break;

                    case "5":
                        contactBook.SortContacts();
                        break;

                    case "6":
                        contactBook.SaveContacts();
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
    }

}