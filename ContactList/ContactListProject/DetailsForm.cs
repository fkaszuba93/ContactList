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

        public DetailsForm()
        {
            InitializeComponent();
        }

        public DetailsForm(Contact contact)
        {
            this.contact = contact;
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
