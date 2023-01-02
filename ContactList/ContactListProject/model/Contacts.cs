using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactListProject.model
{
    public class Contacts
    {
        private List<Contact> contactList;

        public Contacts()
        {
            contactList = new List<Contact>();
        }

        public static Contacts ReadFromFile(string path)
        {
            Contacts contacts = new Contacts();

            var data = File.ReadLines(path);
            foreach (string line in data)
            {
                contacts.contactList.Add(Contact.Parse(line));
            }
            return contacts;
        }

        public List<string> ToStringList()
        {
            return contactList.ConvertAll(contact => contact.ToString());
        }
    }
}
