using ContactListProject.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
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

        private HashSet<TextBox> errors;

        public DetailsForm() : this(null)
        {
        }

        public DetailsForm(Contact contact)
        {
            this.contact = contact;
            errors = new HashSet<TextBox>();
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
                List<string> phoneNumbersList = contact.GetPhoneNumbers();
                for (int i = 0; i < phoneNumbersList.Count && i < phoneNumbers.Length; i++)
                {
                    phoneNumbers[i].Text = phoneNumbersList[i];
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (errors.Count == 0)
            {
                string firstName = firstNameTextBox.Text, lastName = lastNameTextBox.Text, company = companyTextBox.Text,
                location = locationTextBox.Text, position = positionTextBox.Text;
                List<string> phoneNumbers = new List<string>();
                TextBox[] phoneNumberTextBoxes = { phone1TextBox, phone2TextBox, phone3TextBox };
                foreach (TextBox number in phoneNumberTextBoxes)
                {
                    if (number.TextLength > 0)
                    {
                        phoneNumbers.Add(number.Text);
                    }
                }
                contact = new Contact(-1, 0, firstName, lastName, company, location, position, phoneNumbers);
            }
        }

        private void firstNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateField(firstNameTextBox);
        }

        private void lastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateField(lastNameTextBox);
        }

        private void locationTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateField(locationTextBox);
        }

        private void companyTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateField(companyTextBox);
        }

        private void positionTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateField(positionTextBox);
        }

        private void phone1TextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidatePhoneNumber(phone1TextBox);
        }

        private void phone2TextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidatePhoneNumber(phone2TextBox);
        }

        private void phone3TextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidatePhoneNumber(phone3TextBox);
        }

        private void ValidateField(TextBox field)
        {
            Regex regex = new Regex("^[A-Za-z ]+$");
            if (!regex.IsMatch(field.Text))
            {
                SetError(field, "Invalid data format");
            }
            else
            {
                ClearError(field);
            }
        }

        private void ValidatePhoneNumber(TextBox number)
        {
            Regex regex = new Regex("^[0-9]{10}$");
            if (number.TextLength > 0 && !regex.IsMatch(number.Text))
            {
                SetError(number, "Invalid phone number");
            }
            else
            {
                ClearError(number);
            }
        }

        private void SetError(TextBox field, string msg)
        {
            errorProvider.SetError(field, msg);
            errors.Add(field);
            saveButton.DialogResult = DialogResult.None;
        }

        private void ClearError(TextBox field)
        {
            errorProvider.SetError(field, string.Empty);
            errors.Remove(field);
            if (errors.Count == 0)
            {
                saveButton.DialogResult = DialogResult.OK;
            }
        }
    }
}
