using AppG2.Controller;
using AppG2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppG2.View
{
    public partial class frmContactChiTiet : Form
    {
        Model.Contact contact = null;
        //string pathDataFile = null;
        User usr = new User();
        public frmContactChiTiet( User user, Model.Contact contact = null )
        {
            InitializeComponent();
            this.contact = contact;
            usr = user;
           // this.pathDataFile = pathDataFile;
            if (contact != null)
            {
                this.Text = "Chỉnh sửa danh bạ";
                txtName.Text = contact.NameContact;
                txtPhone.Text = contact.Phone;
                txtEmail.Text = contact.Email;

            }
            else
            {
                this.Text = "Thêm quá danh bạ";
            }
        }
        
        private void btnDongY_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDongY_Click_1(object sender, EventArgs e)
        {
            if (contact != null)
            {
                //cap nhat
                contact.NameContact = txtName.Text;
                contact.Email = txtEmail.Text;
                contact.Phone = txtPhone.Text;
                contact.UserName = usr.UserName;
                ContactService.EditContactDB(contact);
            }
            else
            {
                //them moi 
                Model.Contact cont = new Model.Contact();
                cont.NameContact = txtName.Text;
                cont.Email = txtEmail.Text;
                cont.Phone = txtPhone.Text;
                cont.UserName = usr.UserName;
                ContactService.CreateContactDB(cont);
            }
            MessageBox.Show("Đã cập nhật dữ liệu thành công");
            DialogResult = DialogResult.OK; // Đóng form
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txtEmail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }
            }
            if(txtEmail.Text.Trim() == null)
            {
                MessageBox.Show("E-mail address not empty", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
        }
    }
}
