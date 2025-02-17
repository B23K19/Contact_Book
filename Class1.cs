using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{    internal class ContactsBook
    {
        private List<Contacts> contacts = new List<Contacts>();
        string filePath = @"Your Directory";

        public void AddContact(string name,string phoneNumber,string email) 
        {
           // contacts.Add(new Contacts(name , phoneNumber , email));
            if(!contacts.Exists(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
              {
               contacts.Add(new Contacts(name , phoneNumber , email));
               Console.WriteLine("New contact was added");
              }
             else
             {
                Console.WriteLine("Contact already exist");
             }
            
        }
        //Search for a contact using linear search algorithm
        public Contacts SearchContact(string name) 
        {
            return contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void updateContacts(string name,string newPhoneNumber,string newEmail) 
        {
            Contacts contact = SearchContact(name);
            if (contact != null)
            {   
                contact.PhoneNumber = newPhoneNumber;
                contact.Email = newEmail;
                Console.WriteLine("Contacts was successfully update");
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void SortContacts()
        {
            contacts = contacts.OrderBy(c => c.Name).ToList();
            Console.WriteLine("Names are sorted out alphabetically");
        }

        public void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found");
                return;
            }
            else
            {
                Console.WriteLine("Contacts list:\n");
                foreach (Contacts contact in contacts)
                {
                    Console.WriteLine($"{contact}\n");
                }
            }
        }
        public void SaveContacts()
        {
            
            string[] lines = contacts.Select(c => $"{c.Name},{c.PhoneNumber},{c.Email}").ToArray();

            
            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Contacts saved to file.");
        }
        

        public void LoadContacts()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No contacts found");
                return;
            }
            
            contacts.Clear();
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    contacts.Add(new Contacts(parts[0], parts[1], parts[2]));
                }
            }
            Console.WriteLine("Contacts loaded from file.");
        }
       
            
            
        }

    }

