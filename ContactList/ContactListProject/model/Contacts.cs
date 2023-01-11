using ContactListProject.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static Contacts LoadFromDatabase()
        {
            Contacts contacts = new Contacts();

            using var dbContext = new ContactsContext();
            contacts.contactList = dbContext.Contacts.ToList();

            return contacts;
        }

        public List<Contact> GetList()
        {
            return contactList;
        }

        public void Add(Contact contact, bool updateDb = true)
        {
            if (contact.RowId == -1)
            {
                contact.RowId = contactList.Count + 1;
                while (contactList.Exists(c => c.RowId == contact.RowId))
                {
                    contact.RowId++;
                }
            }
            contactList.Add(contact);

            if (updateDb) 
            {
                using var dbContext = new ContactsContext();
                dbContext.Add(contact);
                dbContext.SaveChanges();
            }
        }

        public void Add(List<Contact> list, bool updateDb = true)
        {
            contactList.AddRange(list);
            
            if (updateDb)
            {
                using var dbContext = new ContactsContext();
                dbContext.Contacts.AddRange(contactList);
                dbContext.SaveChanges();
            }
        }

        public void Update(int index, Contact contact)
        {
            contactList[index] = contact;

            using var dbContext = new ContactsContext();
            dbContext.Update(contact);
            dbContext.SaveChanges();
        }

        public void Delete(Contact contact)
        {
            contactList.Remove(contact);

            using var dbContext = new ContactsContext();
            dbContext.Remove(contact);
            dbContext.SaveChanges();
        }

        public void SortList()
        {
            var sortedList = 
                from contact in contactList
                orderby contact.RowId ascending
                select contact;
            contactList = new List<Contact>(sortedList);
        }

        public List<string> ToStringList()
        {
            return contactList.ConvertAll(contact => contact.ToString());
        }

        public List<Contact> ToHierarchyTree()
        {
            List<Contact> hierarchyTree = new List<Contact>(contactList);
            foreach (Contact contact in hierarchyTree)
            {
                var subordinates =
                    from sub in hierarchyTree
                    where sub.ParentId == contact.RowId
                    orderby sub.RowId ascending
                    select sub;
                contact.Subordinates = new List<Contact>(subordinates);
            }
            hierarchyTree.RemoveAll(contact => contact.ParentId != 0);
            return hierarchyTree;
        }

        public List<string> ToCSVList()
        {
            return contactList.ConvertAll(contact => contact.ToCSVString());
        }
    }
}
