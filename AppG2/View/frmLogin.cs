using AppG2.Controller;
using AppG2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppG2.View
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = txtusername.Text;
            user.PassWord = txtpassword.Text;
            if(ContactService.CheckLogin(user))
            {
                this.Hide();
                var f = new frmContact(user);  
                f.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Vui lòng nhập đúng tài khoản và mật khẩu", "Thông báo");
        }
    }
}
