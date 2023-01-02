using ContactListProject.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactListProject
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Contacts contacts = Contacts.ReadFromFile("c:\\fk\\temp\\companies_data.csv");
            contacts.SortList();
            PopulateListView(contacts);
            PopulateTreeView(contacts);
        }

        private void PopulateListView(Contacts contacts)
        {
            List<string> items = contacts.ToStringList();
            foreach (string item in items)
            {
                listView.Items.Add(item);
            }
        }

        private void PopulateTreeView(Contacts contacts)
        {
            List<Contact> hierarchyTree = contacts.ToHierarchyTree();
            foreach (Contact contact in hierarchyTree)
            {
                AddTreeNode(contact, null);
            }
        }

        private void AddTreeNode(Contact contact, TreeNode parent)
        {
            TreeNode node = new TreeNode(contact.ToString());
            if (parent != null)
            {
                parent.Nodes.Add(node);
            }
            else
            {
                treeView.Nodes.Add(node);
            }
            foreach (Contact subordinate in contact.Subordinates)
            {
                AddTreeNode(subordinate, node);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listPage_Click(object sender, EventArgs e)
        {

        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
