using ContactListProject.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactListProject.IO
{
    public class ContactsFileReader : ContactsIO
    {
        private string status;

        public string Status
        { 
            get
            {
                return status;
            }
        }

        public const string OK = "OK";

        public ContactsFileReader(string path) : base(path) { }

        public Contacts ReadContacts(Contacts contacts, bool updateDb = true)
        {
            StringBuilder statusStringBuilder = new StringBuilder();
            bool isError = false;

            var data = File.ReadLines(path);
            List<Contact> contactList = new List<Contact>();
            foreach (string line in data)
            {
                try
                {
                    contactList.Add(Contact.Parse(line));
                }
                catch (ArgumentException ex)
                {
                    isError = true;
                    statusStringBuilder.Append(ex.Message).Append("\n\n");
                }
            }
            contacts.Add(contactList, updateDb);
            status = isError ? statusStringBuilder.ToString() : OK;
            return contacts;
        }
    }
}
