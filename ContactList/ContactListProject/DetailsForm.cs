using ContactListProject.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContactListProject
{
    public partial class DetailsForm : System.Windows.Forms.Form
    {
        private Contact contact;

        public Contact Contact
        {
            get
            {
                return contact;
            }
        }

        public DetailsForm()
        {
            InitializeComponent();
        }

        public DetailsForm(Contact contact)
        {
            this.contact = contact;
            InitializeComponent();
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            if (contact != null)
            {
                firstNameTextBox.Text = contact.FirstName;
                lastNameTextBox.Text = contact.LastName;
                locationTextBox.Text = contact.Location;
                companyTextBox.Text = contact.Company;
                positionTextBox.Text = contact.Position;
                TextBox[] phoneNumbers = { phone1TextBox, phone2TextBox, phone3TextBox };
                for (int i = 0; i < contact.PhoneNumbers.Count; i++)
                {
                    phoneNumbers[i].Text = contact.PhoneNumbers[i];
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text, lastName = lastNameTextBox.Text, company = companyTextBox.Text,
                location = locationTextBox.Text, position = positionTextBox.Text, phone1 = phone1TextBox.Text;
            contact = new Contact(0, 0, firstName, lastName, company, location, position, new List<string> { phone1 });
        }
    }
}
