using ContactListProject.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactListProject.IO
{
    public class ContactsFileReader : ContactsIO
    {
        public ContactsFileReader(string path) : base(path) { }

        public Contacts ReadContacts()
        {
            Contacts contacts = new Contacts();

            var data = File.ReadLines(path);
            foreach (string line in data)
            {
                contacts.Add(Contact.Parse(line));
            }
            return contacts;
        }
    }
}
