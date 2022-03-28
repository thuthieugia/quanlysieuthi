﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUL;


namespace QuanLySieuThi
{
    public partial class frmThemNCC : Form
    {
        frmSieuThi frmST;
        public frmThemNCC(frmSieuThi frm)
        {
            InitializeComponent();
            this.frmST = frm;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                BULNhaCungCap bul = new BULNhaCungCap();
                bul.themNhaCungCap(new NhaCungCap(1, txtTenNCC.Text, txtDiaChi.Text));
                frmST.hienDanhSachNhaCungCap();
                MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Thao tác thất bạt, dữ liệu sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void FrmThemNCC_Load(object sender, EventArgs e)
        {

        }
    }
}
