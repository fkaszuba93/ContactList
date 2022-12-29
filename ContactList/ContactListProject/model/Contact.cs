using System;
using System.Collections.Generic;
using System.Text;

namespace ContactListProject.model
{
    public class Contact
    {
        public int RowId { get; }
        public int ParentId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Company { get; }
        public string Location { get; }
        public string Position { get; }
        public List<string> PhoneNumbers { get; }
        public List<Contact> Subordinates { get; set; }
        public bool IsPrinted { get; set; }

        public Contact(int rowId, int parentId, string firstName, string lastName, string company, string location, string position, List<string> phoneNumbers)
        {
            RowId = rowId;
            ParentId = parentId;
            FirstName = firstName;
            LastName = lastName;
            Company = company;
            Location = location;
            Position = position;
            PhoneNumbers = phoneNumbers;
            Subordinates = new List<Contact>();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + ", " + Company + ", " + Position;
        }
    }
}
