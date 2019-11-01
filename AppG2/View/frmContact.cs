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

namespace AppG2.View
{
    public partial class frmContact : Form
    {
        string pathDataFile;
        public frmContact()
        {
            InitializeComponent();
            pathDataFile = Application.StartupPath + @"\Data\contact.txt";
            loadContact();
        }
        private void loadContact()
        {
            
            bdsContact.DataSource = null;
            dtgvContact.AutoGenerateColumns = false;
            List<Model.Contact> lstContacts  = ContactService.GetContact(pathDataFile, null);
            if (lstContacts == null)
                throw new Exception("Chua co thong tin");
            else
            {
                bdsContact.DataSource = lstContacts;
            }
            dtgvContact.DataSource = bdsContact;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc là muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                // var historyLearning = (HistoryLearning)bdsQuaTrinhHocTap.Current; 2 cach
                var contact = bdsContact.Current as Model.Contact;
                ContactService.DeleteContact(contact.ID, pathDataFile);

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
            var f = new frmContactChiTiet(pathDataFile, null);
            if (f.ShowDialog() == DialogResult.OK)
            {
                loadContact();
                //Tiến hành nạp lại dữ liệu lên lưới
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var contact = bdsContact.Current as Model.Contact;
            if (contact != null)
            {
                 var f = new frmContactChiTiet(pathDataFile, contact);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    loadContact();
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
            List<Model.Contact> lstContacts = ContactService.GetContact(pathDataFile, txtSearch.Text);
            if (lstContacts == null)
                throw new Exception("Chua co thong tin");
            else
            {
                bdsContact.DataSource = lstContacts;
            }
            dtgvContact.DataSource = bdsContact;
        }
    }
}
