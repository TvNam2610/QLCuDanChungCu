using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_DangNhap : Form
    {
        public GUI_DangNhap()
        {
            InitializeComponent();
        }
        BUS_TaiKhoan bustk = new BUS_TaiKhoan();

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.IconRight = Properties.Resources._172484_invisible_icon;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.IconRight = Properties.Resources._4280480_off_outlined_visibility_hide_invisible_icon;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (bustk.kiemTraTK(txtUserName.Text, txtPassword.Text))
            {
                GUI_Main f = new GUI_Main();
                f.Show();
                this.Hide();
                f.Exit += F_Exit;
            }
            else
            {
                MessageBox.Show("Sai mật khẩu , tài khoản . Yêu cầu nhập lại");
            }
        }

        private void F_Exit(object sender, EventArgs e)
        {
            (sender as GUI_Main).isExit = false;
            (sender as GUI_Main).Close();
            this.Show();
        }
    }
}
