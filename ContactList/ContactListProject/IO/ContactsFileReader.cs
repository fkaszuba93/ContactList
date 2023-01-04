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

        public Contacts ReadContacts()
        {
            Contacts contacts = new Contacts();
            StringBuilder statusStringBuilder = new StringBuilder();
            bool isError = false;

            var data = File.ReadLines(path);
            foreach (string line in data)
            {
                try
                {
                    contacts.Add(Contact.Parse(line));
                }
                catch (ArgumentException ex)
                {
                    isError = true;
                    statusStringBuilder.Append(ex.Message).Append("\n\n");
                }
            }
            status = isError ? statusStringBuilder.ToString() : OK;
            return contacts;
        }
    }
}
