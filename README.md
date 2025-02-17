# Contact_Book
 A program to add,save,update contacts
 
Search for contact by name
Update any existing contacts
Sort contacts(Names) alphabetically
Save contacts to a file
Load contacts from a file

  private List<Contacts> contacts = new List<Contacts>();
        string filePath = @"C:\Users\boydd\OneDrive\Desktop\Angula\Contacts.txt";

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
            Console.WriteLine("Contacts were sorted out alphabetically");
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
            // Convert contacts to string format
            string[] lines = contacts.Select(c => $"{c.Name},{c.PhoneNumber},{c.Email}").ToArray();

            // Write all lines at once
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
