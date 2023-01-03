using NUnit.Framework;
using System;
using System.Collections.Generic;
using ContactListProject.model;

namespace ContactListTest
{
    public class UnitTest
    {
        [SetUp]
        public void Setup()
        {
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
        public void TestReadFromFile()
        {
            string path = "..\\..\\..\\companies_data.csv";
            Contacts contacts = Contacts.ReadFromFile(path);

            Assert.IsTrue(contacts.GetList().Count > 0);
        }

        [Test]
        public void TestSortList()
        {
            Contacts contacts = new Contacts();
            contacts.Add(new Contact(2, 1, "Jackie", "Smith", "IBM", "Johannesburg", "Assistant Director", null));
            contacts.Add(new Contact(1, 0, "Peter", "Ndoro", "IBM", "Johannesburg", "Managing Director", null));
            contacts.Add(new Contact(7, 0, "Mathew", "Burke", "Microsoft", "Johannesburg", "Account Manager", null));
            contacts.Add(new Contact(33, 1, "Chris", "Thorpe", "IBM", "Johannesburg", "Technical Director", null));

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
            Contacts contacts = new Contacts();
            contacts.Add(new Contact(1, 0, "Peter", "Ndoro", "IBM", "Johannesburg", "Managing Director", null));
            contacts.Add(new Contact(2, 1, "Jackie", "Smith", "IBM", "Johannesburg", "Assistant Director", null));
            contacts.Add(new Contact(33, 1, "Chris", "Thorpe", "IBM", "Johannesburg", "Technical Director", null));

            List<Contact> tree = contacts.ToHierarchyTree();

            Assert.IsTrue(tree.Count == 1);
            Assert.IsTrue(tree[0].Subordinates.Count > 0);
        }
    }
}
