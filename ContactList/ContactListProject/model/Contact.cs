using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace ContactListProject.model
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Column("RowId")]
        public int RowId { get; set; }
        
        [Column("ParentId")]
        public int ParentId { get; set; }
        
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Company")]
        public string Company { get; set; }

        [Column("Location")]
        public string Location { get; set; }

        [Column("Position")]
        public string Position { get; set; }

        [Column("PhoneNumbers")]
        public string PhoneNumbers { get; set; }
        
        [NotMapped]
        public List<Contact> Subordinates { get; set; }

        private List<string> phoneNumbersList;

        public List<string> GetPhoneNumbers()
        {
            return phoneNumbersList;
        }

        public void SetPhoneNumbers(List<string> value)
        {
            phoneNumbersList = value;
        }


        public static Contact Parse(string csvData)
        {
            Regex dataFormatRegex = new Regex("^([0-9]+,){2}([A-Za-z ]+,){4}[A-Za-z ]+(,[0-9]{10})+$");
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

        public Contact()
        {
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
            phoneNumbersList = phoneNumbers;
            PhoneNumbers = phoneNumbersListToString();
            Subordinates = new List<Contact>();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + ", " + Company + ", " + Position;
        }

        public string ToCSVString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(RowId).Append(",").Append(ParentId).Append(",")
                .Append(FirstName).Append(",").Append(LastName).Append(",")
                .Append(Company).Append(",").Append(Location).Append(",").Append(Position);
            foreach (string number in phoneNumbersList)
            {
                sb.Append(",").Append(number);
            }
            return sb.ToString();
        }

        private string phoneNumbersListToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string ph in phoneNumbersList)
            {
                sb.Append(ph).Append(',');
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        private List<string> phoneNumbersStringToList()
        {
            return new List<string>(PhoneNumbers.Split(","));
        }
    }
}
