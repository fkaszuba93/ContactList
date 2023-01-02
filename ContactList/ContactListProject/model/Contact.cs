using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        public static Contact Parse(string csvData)
        {
            Regex dataFormatRegex = new Regex("^[0-9]+,[0-9]+,[A-Za-z]+,[A-Za-z ]+,[A-Za-z ]+,[A-Za-z ]+,[A-Za-z ]+(,[0-9]{10})+$");
            if (!dataFormatRegex.IsMatch(csvData))
            {
                throw new ArgumentException("Invalid data format: " + csvData);
            }

            string[] dataArray = csvData.Split(',');
            int rowId = int.Parse(dataArray[0]);
            int parentId = int.Parse(dataArray[1]);
            string firstName = dataArray[2];
            string lastName = dataArray[3];
            string company = dataArray[4];
            string location = dataArray[5];
            string position = dataArray[6];
            List<string> phoneNumbers = new List<string> { dataArray[7], dataArray[8], dataArray[9] };

            return new Contact(rowId, parentId, firstName, lastName, company, location, position, phoneNumbers);
        }

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
