namespace AppG2.View
{
    partial class frmContact
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContact));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dtgvContact = new System.Windows.Forms.DataGridView();
            this.Character = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.bdsContact = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsContact)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(53, 74);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(645, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(382, 120);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(490, 120);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 28);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(598, 120);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dtgvContact
            // 
            this.dtgvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvContact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Character,
            this.ContactName,
            this.Phone,
            this.Email,
            this.ID});
            this.dtgvContact.Location = new System.Drawing.Point(53, 169);
            this.dtgvContact.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvContact.MultiSelect = false;
            this.dtgvContact.Name = "dtgvContact";
            this.dtgvContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvContact.Size = new System.Drawing.Size(647, 230);
            this.dtgvContact.TabIndex = 4;
            // 
            // Character
            // 
            this.Character.DataPropertyName = "Character";
            this.Character.HeaderText = "";
            this.Character.Name = "Character";
            this.Character.Width = 60;
            // 
            // ContactName
            // 
            this.ContactName.DataPropertyName = "NameContact";
            this.ContactName.HeaderText = "ContactName";
            this.ContactName.Name = "ContactName";
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(309, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(132, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Contacts";
            this.label1.UseMnemonic = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Chartreuse;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.Honeydew;
            this.btnClose.Location = new System.Drawing.Point(600, 436);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(751, 479);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgvContact);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dtgvContact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsContact;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Character;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}