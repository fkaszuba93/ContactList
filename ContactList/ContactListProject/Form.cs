using ContactListProject.model;
using ContactListProject.IO;
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

        private void importCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ContactsFileReader fileReader = new ContactsFileReader(openFileDialog.FileName);
                    Contacts contacts = fileReader.ReadContacts();
                    contacts.SortList();
                    PopulateListView(contacts);
                    PopulateTreeView(contacts);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }
    }
}
