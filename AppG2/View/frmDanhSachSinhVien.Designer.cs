namespace AppG2.View
{
    partial class frmDanhSachSinhVien
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.clbSinhVien = new System.Windows.Forms.CheckedListBox();
            this.grbSinhVien = new System.Windows.Forms.GroupBox();
            this.txbDiaChi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbDiemTrungBinh = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabSinhVien = new System.Windows.Forms.TabControl();
            this.tbpVan = new System.Windows.Forms.TabPage();
            this.flpVan = new System.Windows.Forms.FlowLayoutPanel();
            this.tbpVatLy = new System.Windows.Forms.TabPage();
            this.flpVatLy = new System.Windows.Forms.FlowLayoutPanel();
            this.tbpCNTT = new System.Windows.Forms.TabPage();
            this.flpCNTT = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.CheckBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bổSungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bổSungSinhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bổSungĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chỉnhSửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemLịchSửHọcCủaSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bdsSinhVien = new System.Windows.Forms.BindingSource(this.components);
            this.grbSinhVien.SuspendLayout();
            this.tabSinhVien.SuspendLayout();
            this.tbpVan.SuspendLayout();
            this.tbpVatLy.SuspendLayout();
            this.tbpCNTT.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm sinh viên:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(152, 17);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(235, 22);
            this.txtFind.TabIndex = 2;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // clbSinhVien
            // 
            this.clbSinhVien.FormattingEnabled = true;
            this.clbSinhVien.Location = new System.Drawing.Point(21, 57);
            this.clbSinhVien.Name = "clbSinhVien";
            this.clbSinhVien.Size = new System.Drawing.Size(366, 514);
            this.clbSinhVien.TabIndex = 4;
            this.clbSinhVien.SelectedIndexChanged += new System.EventHandler(this.clbSinhVien_SelectedIndexChanged);
            // 
            // grbSinhVien
            // 
            this.grbSinhVien.Controls.Add(this.txbDiaChi);
            this.grbSinhVien.Controls.Add(this.label6);
            this.grbSinhVien.Controls.Add(this.lbDiemTrungBinh);
            this.grbSinhVien.Controls.Add(this.label5);
            this.grbSinhVien.Controls.Add(this.tabSinhVien);
            this.grbSinhVien.Controls.Add(this.dtpDOB);
            this.grbSinhVien.Controls.Add(this.label3);
            this.grbSinhVien.Controls.Add(this.cbGender);
            this.grbSinhVien.Controls.Add(this.txbName);
            this.grbSinhVien.Controls.Add(this.label2);
            this.grbSinhVien.Location = new System.Drawing.Point(411, 57);
            this.grbSinhVien.Name = "grbSinhVien";
            this.grbSinhVien.Size = new System.Drawing.Size(377, 514);
            this.grbSinhVien.TabIndex = 7;
            this.grbSinhVien.TabStop = false;
            this.grbSinhVien.Text = "Thông tin chi tiết";
            // 
            // txbDiaChi
            // 
            this.txbDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDiaChi.Location = new System.Drawing.Point(9, 235);
            this.txbDiaChi.Name = "txbDiaChi";
            this.txbDiaChi.ReadOnly = true;
            this.txbDiaChi.Size = new System.Drawing.Size(239, 27);
            this.txbDiaChi.TabIndex = 16;
            this.txbDiaChi.Text = "Hà nội";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nơi ở:";
            // 
            // lbDiemTrungBinh
            // 
            this.lbDiemTrungBinh.AutoSize = true;
            this.lbDiemTrungBinh.Location = new System.Drawing.Point(128, 479);
            this.lbDiemTrungBinh.Name = "lbDiemTrungBinh";
            this.lbDiemTrungBinh.Size = new System.Drawing.Size(16, 17);
            this.lbDiemTrungBinh.TabIndex = 14;
            this.lbDiemTrungBinh.Text = "6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Điểm trung bình:";
            // 
            // tabSinhVien
            // 
            this.tabSinhVien.Controls.Add(this.tbpVan);
            this.tabSinhVien.Controls.Add(this.tbpVatLy);
            this.tabSinhVien.Controls.Add(this.tbpCNTT);
            this.tabSinhVien.Location = new System.Drawing.Point(9, 275);
            this.tabSinhVien.Name = "tabSinhVien";
            this.tabSinhVien.SelectedIndex = 0;
            this.tabSinhVien.Size = new System.Drawing.Size(331, 205);
            this.tabSinhVien.TabIndex = 12;
            // 
            // tbpVan
            // 
            this.tbpVan.Controls.Add(this.flpVan);
            this.tbpVan.Location = new System.Drawing.Point(4, 25);
            this.tbpVan.Name = "tbpVan";
            this.tbpVan.Padding = new System.Windows.Forms.Padding(3);
            this.tbpVan.Size = new System.Drawing.Size(323, 176);
            this.tbpVan.TabIndex = 0;
            this.tbpVan.Text = "Văn";
            this.tbpVan.UseVisualStyleBackColor = true;
            // 
            // flpVan
            // 
            this.flpVan.Location = new System.Drawing.Point(80, 20);
            this.flpVan.Name = "flpVan";
            this.flpVan.Size = new System.Drawing.Size(164, 139);
            this.flpVan.TabIndex = 0;
            // 
            // tbpVatLy
            // 
            this.tbpVatLy.Controls.Add(this.flpVatLy);
            this.tbpVatLy.Location = new System.Drawing.Point(4, 25);
            this.tbpVatLy.Name = "tbpVatLy";
            this.tbpVatLy.Padding = new System.Windows.Forms.Padding(3);
            this.tbpVatLy.Size = new System.Drawing.Size(323, 176);
            this.tbpVatLy.TabIndex = 1;
            this.tbpVatLy.Text = "Vật lý";
            this.tbpVatLy.UseVisualStyleBackColor = true;
            // 
            // flpVatLy
            // 
            this.flpVatLy.Location = new System.Drawing.Point(80, 20);
            this.flpVatLy.Name = "flpVatLy";
            this.flpVatLy.Size = new System.Drawing.Size(164, 139);
            this.flpVatLy.TabIndex = 0;
            // 
            // tbpCNTT
            // 
            this.tbpCNTT.Controls.Add(this.flpCNTT);
            this.tbpCNTT.Location = new System.Drawing.Point(4, 25);
            this.tbpCNTT.Name = "tbpCNTT";
            this.tbpCNTT.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCNTT.Size = new System.Drawing.Size(323, 176);
            this.tbpCNTT.TabIndex = 2;
            this.tbpCNTT.Text = "CNTT";
            this.tbpCNTT.UseVisualStyleBackColor = true;
            // 
            // flpCNTT
            // 
            this.flpCNTT.Location = new System.Drawing.Point(80, 20);
            this.flpCNTT.Name = "flpCNTT";
            this.flpCNTT.Size = new System.Drawing.Size(164, 139);
            this.flpCNTT.TabIndex = 0;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(9, 168);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 22);
            this.dtpDOB.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ngày sinh";
            // 
            // cbGender
            // 
            this.cbGender.AutoSize = true;
            this.cbGender.Enabled = false;
            this.cbGender.Location = new System.Drawing.Point(9, 100);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(113, 21);
            this.cbGender.TabIndex = 9;
            this.cbGender.Text = "Giới tính nam";
            this.cbGender.UseVisualStyleBackColor = true;
            // 
            // txbName
            // 
            this.txbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbName.Location = new System.Drawing.Point(9, 56);
            this.txbName.Name = "txbName";
            this.txbName.ReadOnly = true;
            this.txbName.Size = new System.Drawing.Size(239, 27);
            this.txbName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ tên:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(411, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 38);
            this.panel1.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bổSungToolStripMenuItem,
            this.chỉnhSửaToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.xemLịchSửHọcCủaSVToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(411, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bổSungToolStripMenuItem
            // 
            this.bổSungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bổSungSinhViênToolStripMenuItem,
            this.bổSungĐiểmToolStripMenuItem});
            this.bổSungToolStripMenuItem.Name = "bổSungToolStripMenuItem";
            this.bổSungToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.bổSungToolStripMenuItem.Text = "Bổ sung";
            // 
            // bổSungSinhViênToolStripMenuItem
            // 
            this.bổSungSinhViênToolStripMenuItem.Name = "bổSungSinhViênToolStripMenuItem";
            this.bổSungSinhViênToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.bổSungSinhViênToolStripMenuItem.Text = "Bổ sung sinh viên";
            this.bổSungSinhViênToolStripMenuItem.Click += new System.EventHandler(this.bổSungSinhViênToolStripMenuItem_Click);
            // 
            // bổSungĐiểmToolStripMenuItem
            // 
            this.bổSungĐiểmToolStripMenuItem.Name = "bổSungĐiểmToolStripMenuItem";
            this.bổSungĐiểmToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.bổSungĐiểmToolStripMenuItem.Text = "Bổ sung điểm";
            this.bổSungĐiểmToolStripMenuItem.Click += new System.EventHandler(this.bổSungĐiểmToolStripMenuItem_Click);
            // 
            // chỉnhSửaToolStripMenuItem
            // 
            this.chỉnhSửaToolStripMenuItem.Name = "chỉnhSửaToolStripMenuItem";
            this.chỉnhSửaToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.chỉnhSửaToolStripMenuItem.Text = "Chỉnh sửa";
            this.chỉnhSửaToolStripMenuItem.Click += new System.EventHandler(this.chỉnhSửaToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // xemLịchSửHọcCủaSVToolStripMenuItem
            // 
            this.xemLịchSửHọcCủaSVToolStripMenuItem.Name = "xemLịchSửHọcCủaSVToolStripMenuItem";
            this.xemLịchSửHọcCủaSVToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.xemLịchSửHọcCủaSVToolStripMenuItem.Text = "Xem lịch sử học";
            this.xemLịchSửHọcCủaSVToolStripMenuItem.Click += new System.EventHandler(this.xemLịchSửHọcCủaSVToolStripMenuItem_Click);
            // 
            // frmDanhSachSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 591);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbSinhVien);
            this.Controls.Add(this.clbSinhVien);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label1);
            this.Name = "frmDanhSachSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDanhSachSinhVien";
            this.grbSinhVien.ResumeLayout(false);
            this.grbSinhVien.PerformLayout();
            this.tabSinhVien.ResumeLayout(false);
            this.tbpVan.ResumeLayout(false);
            this.tbpVatLy.ResumeLayout(false);
            this.tbpCNTT.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSinhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.CheckedListBox clbSinhVien;
        private System.Windows.Forms.GroupBox grbSinhVien;
        private System.Windows.Forms.Label lbDiemTrungBinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabSinhVien;
        private System.Windows.Forms.TabPage tbpVan;
        private System.Windows.Forms.TabPage tbpVatLy;
        private System.Windows.Forms.TabPage tbpCNTT;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbGender;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDiaChi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bdsSinhVien;
        private System.Windows.Forms.FlowLayoutPanel flpVan;
        private System.Windows.Forms.FlowLayoutPanel flpVatLy;
        private System.Windows.Forms.FlowLayoutPanel flpCNTT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bổSungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chỉnhSửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bổSungSinhViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bổSungĐiểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemLịchSửHọcCủaSVToolStripMenuItem;
    }
}