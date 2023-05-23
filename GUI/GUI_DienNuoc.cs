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
    public partial class GUI_DienNuoc : Form
    {
        public GUI_DienNuoc()
        {
            InitializeComponent();
        }

        BUS_DienNuoc busdn = new BUS_DienNuoc();

        
        private void GUI_DienNuoc_Load(object sender, EventArgs e)
        {
            dgvDienNuoc.DataSource = busdn.getDienNuoc();
           
            cbMaCH.DataSource = busdn.getCanHo();
            cbMaCH.ValueMember = "MaCH";
        }

        private void dgvDienNuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDN.Text = dgvDienNuoc.CurrentRow.Cells[0].Value.ToString();
            txtThang.Text = dgvDienNuoc.CurrentRow.Cells[1].Value.ToString();
            txtNam.Text = dgvDienNuoc.CurrentRow.Cells[2].Value.ToString();
            txtSoDienTieuThu.Text = dgvDienNuoc.CurrentRow.Cells[3].Value.ToString();
            txtSoNuocTieuThu.Text = dgvDienNuoc.CurrentRow.Cells[4].Value.ToString();
            cbCanHo.Text = dgvDienNuoc.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
