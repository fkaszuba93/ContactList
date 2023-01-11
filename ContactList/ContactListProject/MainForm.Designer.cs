
namespace ContactListProject
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage listPage;
        private System.Windows.Forms.TabPage treePage;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.listPage = new System.Windows.Forms.TabPage();
            this.treePage = new System.Windows.Forms.TabPage();
            this.treeView = new System.Windows.Forms.TreeView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl.SuspendLayout();
            this.listPage.SuspendLayout();
            this.treePage.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 3);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(786, 383);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.listPage);
            this.tabControl.Controls.Add(this.treePage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 422);
            this.tabControl.TabIndex = 1;
            // 
            // listPage
            // 
            this.listPage.Controls.Add(this.listView);
            this.listPage.Location = new System.Drawing.Point(4, 29);
            this.listPage.Name = "listPage";
            this.listPage.Padding = new System.Windows.Forms.Padding(3);
            this.listPage.Size = new System.Drawing.Size(792, 389);
            this.listPage.TabIndex = 0;
            this.listPage.Text = "List";
            this.listPage.UseVisualStyleBackColor = true;
            // 
            // treePage
            // 
            this.treePage.Controls.Add(this.treeView);
            this.treePage.Location = new System.Drawing.Point(4, 29);
            this.treePage.Name = "treePage";
            this.treePage.Padding = new System.Windows.Forms.Padding(3);
            this.treePage.Size = new System.Drawing.Size(792, 389);
            this.treePage.TabIndex = 1;
            this.treePage.Text = "Tree";
            this.treePage.UseVisualStyleBackColor = true;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(786, 383);
            this.treeView.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "csv";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCSVToolStripMenuItem,
            this.exportCSVToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importCSVToolStripMenuItem
            // 
            this.importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            this.importCSVToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.importCSVToolStripMenuItem.Text = "Import CSV";
            this.importCSVToolStripMenuItem.Click += new System.EventHandler(this.importCSVToolStripMenuItem_Click);
            // 
            // exportCSVToolStripMenuItem
            // 
            this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.exportCSVToolStripMenuItem.Text = "Export CSV";
            this.exportCSVToolStripMenuItem.Click += new System.EventHandler(this.exportCSVToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newContactToolStripMenuItem,
            this.contactDetailsToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // newContactToolStripMenuItem
            // 
            this.newContactToolStripMenuItem.Name = "newContactToolStripMenuItem";
            this.newContactToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.newContactToolStripMenuItem.Text = "Add new contact";
            this.newContactToolStripMenuItem.Click += new System.EventHandler(this.newContactToolStripMenuItem_Click);
            // 
            // contactDetailsToolStripMenuItem
            // 
            this.contactDetailsToolStripMenuItem.Enabled = false;
            this.contactDetailsToolStripMenuItem.Name = "contactDetailsToolStripMenuItem";
            this.contactDetailsToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.contactDetailsToolStripMenuItem.Text = "Contact details";
            this.contactDetailsToolStripMenuItem.Click += new System.EventHandler(this.contactDetailsToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Enabled = false;
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.deleteSelectedToolStripMenuItem.Text = "Delete selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "csv";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "ContactList";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tabControl.ResumeLayout(false);
            this.listPage.ResumeLayout(false);
            this.treePage.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

