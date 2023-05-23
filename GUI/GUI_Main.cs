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
    public partial class GUI_Main : Form
    {
        public GUI_Main()
        {
            InitializeComponent();
        }
        public bool isExit = true;

        public event EventHandler Exit;

        private void btnQuanLyNguoiDan_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "GUI_NguoiDan")
                {
                    f.Activate();
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                GUI_NguoiDan f = new GUI_NguoiDan();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Dock = DockStyle.Fill;
                f.Show();
            }


        }

        private void GUI_Main_Load(object sender, EventArgs e)
        {

        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "GUI_NhanVien")
                {
                    f.Activate();
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                GUI_NhanVien f = new GUI_NhanVien();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void btnQuanLyDichVu_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "GUI_DichVu")
                {
                    f.Activate();
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                GUI_DichVu f = new GUI_DichVu();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void GUI_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }

        private void btnQuanLyDienNuoc_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "GUI_DienNuoc")
                {
                    f.Activate();
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                GUI_DienNuoc f = new GUI_DienNuoc();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void btnThanhToanDN_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "GUI_ThanhToanDienNuoc")
                {
                    f.Activate();
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                GUI_ThanhToanDienNuoc f = new GUI_ThanhToanDienNuoc();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void btnThanhToanDV_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "GUI_ThanhToanDichVu")
                {
                    f.Activate();
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                GUI_ThanhToanDichVu f = new GUI_ThanhToanDichVu();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }
    }
}
