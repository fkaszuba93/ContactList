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
    public partial class MainForm : System.Windows.Forms.Form
    {
        private Contacts contacts;

        public MainForm()
        {
            InitializeComponent();
            contacts = new Contacts();
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
            UpdateEditMenu();
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
                    contacts = fileReader.ReadContacts(contacts);
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

        private void newContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailsForm detailsForm = new DetailsForm();
            if (detailsForm.ShowDialog() == DialogResult.OK)
            {
                Contact contact = detailsForm.Contact;
                contacts.Add(contact);
                UpdateView();
            }
        }

        private void contactDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listView.SelectedIndices[0];
            Contact contact = contacts.GetList()[index];
            DetailsForm detailsForm = new DetailsForm(contact);
            if (detailsForm.ShowDialog() == DialogResult.OK)
            {
                contacts.Update(index, detailsForm.Contact);
                UpdateView();
            }
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete selected contacts?";
            var result = MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                List<Contact> contactsToDelete = new List<Contact>();
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int index = listView.Items.IndexOf(item);
                    contactsToDelete.Add(contacts.GetList()[index]);
                }
                foreach (Contact contact in contactsToDelete)
                {
                    contacts.Delete(contact);
                }
                UpdateView();
            }
        }

        private void UpdateEditMenu()
        {
            int selectedItems = listView.SelectedItems.Count;
            contactDetailsToolStripMenuItem.Enabled = selectedItems == 1;
            deleteSelectedToolStripMenuItem.Enabled = selectedItems > 0;
        }

        private void UpdateView()
        {
            listView.Clear();
            PopulateListView(contacts);
            treeView.Nodes.Clear();
            PopulateTreeView(contacts);
        }

        private static void ShowErrorMessage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
