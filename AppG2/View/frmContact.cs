using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppG2.Model;
using AppG2.Controller;
using System.IO;
using System.Text.RegularExpressions;

namespace AppG2.View
{
    public partial class frmContact : Form
    {
        string pathDataFile;
        User usr = new User();
        public frmContact(User user)
        {
            InitializeComponent();
            pathDataFile = Application.StartupPath + @"\Data\contact.txt";
            usr = user;
            loadContact(user);
           
        }
        private void loadContact(User user)
        {
            
            bdsContact.DataSource = null;
            dtgvContact.AutoGenerateColumns = false;
            List<Model.Contact> lstContacts  = ContactService.GetContactDB(user, null);
            if (lstContacts == null)
                throw new Exception("Chua co thong tin");
            else
            {
                bdsContact.DataSource = lstContacts;
            }
            dtgvContact.DataSource = bdsContact;
            AddListCharactor();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc là muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                // var historyLearning = (HistoryLearning)bdsQuaTrinhHocTap.Current; 2 cach
                var contact = bdsContact.Current as Model.Contact;
                ContactService.DeleteContactDB(contact.ID);

                //delete in datagridview nếu chọn nhiều cái
                /*foreach (DataGridViewRow item in dtgvQuaTrinhHocTap.SelectedRows)
                {
                    dtgvQuaTrinhHocTap.Rows.RemoveAt(item.Index);
                }*/
                //delete in datagridview nếu chỉ lấy 1 cái là cái đầu tiên mình chọn xóa
                dtgvContact.Rows.RemoveAt(dtgvContact.SelectedRows[0].Index);
              
            }
            else MessageBox.Show("Bạn đã không xóa", "Thông báo");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var f = new frmContactChiTiet(usr, null);
            if (f.ShowDialog() == DialogResult.OK)
            {
                loadContact(usr);
                
                //Tiến hành nạp lại dữ liệu lên lưới
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var contact = bdsContact.Current as Model.Contact;
            if (contact != null)
            {
                 var f = new frmContactChiTiet(usr, contact);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    loadContact(usr);
                    
                    //Tiến hành nạp lại dữ liệu lên lưới
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bdsContact.DataSource = null;
            dtgvContact.AutoGenerateColumns = false;
            List<Contact> lstContacts = ContactService.GetContactDB(usr ,txtSearch.Text);
            if (lstContacts == null)
                throw new Exception("Chua co thong tin");
            else
            {
                bdsContact.DataSource = lstContacts;
            }
            dtgvContact.DataSource = bdsContact;
        }
        private void AddListCharactor()
        {
            flpanel.Controls.Clear();
            List<Contact> lstContacts = ContactService.GetContactDB(usr);
            HashSet<string> lstCharacter = new HashSet<string>();
            foreach(var contact in lstContacts)
                lstCharacter.Add(contact.Character);
            foreach(var character in lstCharacter)
            {
                Label label = new Label();
                label.Text = character;
                label.Click += new EventHandler(label_click);
                flpanel.Controls.Add(label);
            }
        }
        private void label_click(object sender, EventArgs e)
        {
            var character = ((Label)sender);
            List<Contact> lstContacts = ContactService.GetContactDBFromCharacter(character.Text);
            bdsContact.DataSource = lstContacts;
            dtgvContact.DataSource = bdsContact;
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            var count = 0;
            var db = new AppG2Context();
            OpenFileDialog openfileDialog = new OpenFileDialog();
            openfileDialog.Title = "Chọn file csv";
            openfileDialog.Filter = "File csv(*.csv)|*.csv";
            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openfileDialog.FileName))
                {
                    var lstcnt = File.ReadAllLines(openfileDialog.FileName);
                    foreach (var contact in lstcnt)
                    {
                        var ls = contact.Split(new char[] { ',' });
                        Contact cnt = new Contact();

                        cnt.ID = Guid.NewGuid().ToString();
                        cnt.NameContact = ls[0];
                        cnt.Phone = ls[1];
                        cnt.Email = ls[2];
                        cnt.UserName = usr.UserName;
                        if(!ContactService.ExistPhoneOrEmail(cnt.Phone, cnt.Email, cnt.UserName, cnt.ID))
                        {
                            db.ContactDbset.Add(cnt);
                            count++;
                        }
                       
                        
                    }
                    db.SaveChanges();
                    loadContact(usr);
                    MessageBox.Show("Import thành công " + count + " giá trị" , "Thông báo");
                }
                else
                {
                    MessageBox.Show("Lỗi khi mở file", "Thông báo");
                }
            }
            
        }

    }
    
}
