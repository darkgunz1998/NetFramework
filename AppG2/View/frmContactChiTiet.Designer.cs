namespace AppG2.View
{
    partial class frmContactChiTiet
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
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnDongY = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBoQua
            // 
            this.btnBoQua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBoQua.Image = global::AppG2.Properties.Resources.deleete2;
            this.btnBoQua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoQua.Location = new System.Drawing.Point(478, 289);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(95, 39);
            this.btnBoQua.TabIndex = 15;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBoQua.UseVisualStyleBackColor = true;
            // 
            // btnDongY
            // 
            this.btnDongY.Image = global::AppG2.Properties.Resources.update;
            this.btnDongY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDongY.Location = new System.Drawing.Point(377, 289);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(95, 39);
            this.btnDongY.TabIndex = 14;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click_1);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(293, 221);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(280, 22);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Phone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(293, 169);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(280, 22);
            this.txtPhone.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(293, 109);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 22);
            this.txtName.TabIndex = 1;
            // 
            // frmContactChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmContactChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmContactChiTiet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
    }
}