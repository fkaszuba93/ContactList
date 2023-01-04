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
        private Contacts contacts;

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
                    contacts = fileReader.ReadContacts();
                    contacts.SortList();
                    PopulateListView(contacts);
                    PopulateTreeView(contacts);
                    if (fileReader.Status != ContactsFileReader.OK)
                    {
                        ShowErrorMessage(fileReader.Status);
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ContactsFileWriter fileWriter = new ContactsFileWriter(saveFileDialog.FileName);
                    fileWriter.SaveContacts(contacts);
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        private static void ShowErrorMessage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
