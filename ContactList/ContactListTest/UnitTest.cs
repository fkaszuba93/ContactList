using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using ContactListProject.model;
using ContactListProject.IO;

namespace ContactListTest
{
    public class UnitTest
    {
        private Contacts contacts;

        [SetUp]
        public void Setup()
        {
            contacts = new Contacts();
            var emptyList = new List<string>();
            contacts.Add(new Contact(2, 1, "Jackie", "Smith", "IBM", "Johannesburg", "Assistant Director", emptyList));
            contacts.Add(new Contact(1, 0, "Peter", "Ndoro", "IBM", "Johannesburg", "Managing Director", emptyList));
            contacts.Add(new Contact(7, 0, "Mathew", "Burke", "Microsoft", "Johannesburg", "Account Manager", emptyList));
            contacts.Add(new Contact(33, 1, "Chris", "Thorpe", "IBM", "Johannesburg", "Technical Director", emptyList));
        }

        [Test]
        public void TestCreateContact()
        {
            string data = "1,0,Peter,Ndoro,IBM,Johannesburg,Managing Director,0762349827,0116725362,0116725368";
            Contact contact = Contact.Parse(data);

            Assert.AreEqual(1, contact.RowId);
            Assert.AreEqual(0, contact.ParentId);
            Assert.AreEqual("Peter", contact.FirstName);
            Assert.AreEqual("Ndoro", contact.LastName);
            Assert.AreEqual("IBM", contact.Company);
            Assert.AreEqual("Johannesburg", contact.Location);
            Assert.AreEqual("Managing Director", contact.Position);
            Assert.AreEqual(3, contact.PhoneNumbers.Count);
            Assert.AreEqual("0762349827", contact.PhoneNumbers[0]);
            Assert.AreEqual("0116725362", contact.PhoneNumbers[1]);
            Assert.AreEqual("0116725368", contact.PhoneNumbers[2]);
        }

        [Test]
        public void TestCreateContactInvalidData()
        {
            string data = "invalid data";
            Assert.Throws<ArgumentException>(() => Contact.Parse(data));
        }

        [Test]
        public void TestContactToCSVString()
        {
            Contact contact = new Contact(2, 1, "Jackie", "Smith", "IBM", "Johannesburg", "Assistant Director", new List<string>());
            string csv = contact.ToCSVString(), expected = "2,1,Jackie,Smith,IBM,Johannesburg,Assistant Director";

            Assert.AreEqual(expected, csv);
        }

        [Test]
        public void TestSortList()
        {
            contacts.SortList();
            List<Contact> list = contacts.GetList();

            for (int i = 1; i < list.Count; i++)
            {
                Assert.IsTrue(list[i - 1].RowId < list[i].RowId);
            }
        }

        [Test]
        public void TestToHierarchyTree()
        {
            List<Contact> tree = contacts.ToHierarchyTree();

            Assert.AreEqual(2, tree.Count);
            Assert.IsTrue(tree[0].Subordinates.Count > 0);
        }

        [Test]
        public void TestReadContactsFromFile()
        {
            ContactsFileReader fileReader = new ContactsFileReader("..\\..\\..\\companies_data.csv");
            Contacts contacts = fileReader.ReadContacts();

            Assert.AreEqual(ContactsFileReader.OK, fileReader.Status);
            Assert.IsTrue(contacts.GetList().Count > 0);
        }

        [Test]
        public void TestSaveContactsToFile()
        {
            string path = "data.csv";
            ContactsFileWriter fileWriter = new ContactsFileWriter(path);
            fileWriter.SaveContacts(contacts);
            FileInfo file = new FileInfo(path);

            Assert.IsTrue(file.Exists);
            Assert.IsTrue(file.Length > 0);
        }
    }
}
