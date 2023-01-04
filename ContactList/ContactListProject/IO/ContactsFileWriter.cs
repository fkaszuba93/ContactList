using ContactListProject.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ContactListProject.IO
{
    public class ContactsFileWriter : ContactsIO
    {
        public ContactsFileWriter(string path) : base(path) { }

        public void SaveContacts(Contacts contacts)
        {
            List<string> csvData = contacts.ToCSVList();
            File.WriteAllLines(path, csvData);
        }
    }
}
