﻿using BUS;
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
    public partial class GUI_ThanhToanDienNuoc : Form
    {
        public GUI_ThanhToanDienNuoc()
        {
            InitializeComponent();
        }

        BUS_HoaDonDienNuoc hd = new BUS_HoaDonDienNuoc();
        private void GUI_ThanhToanDienNuoc_Load(object sender, EventArgs e)
        {
            dgvThanhToanDN.DataSource = hd.getHoaDonDienNuoc();
        }

       
    }
}