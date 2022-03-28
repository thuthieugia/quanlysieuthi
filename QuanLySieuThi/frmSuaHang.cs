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
    public partial class frmSuaHang : Form
    {
        frmSieuThi frmST;
        public frmSuaHang(frmSieuThi frm)
        {
            InitializeComponent();
            this.frmST = frm;
        }

        private void frmSuaHang_Load(object sender, EventArgs e)
        {
            hienComboBox();
        }
        void hienComboBox()
        {

            BULLoaiHang bulLH = new BULLoaiHang();
            cbLoaiHang.DataSource = bulLH.layLoaiHang();
            cbLoaiHang.DisplayMember = "tenLoaiHang";
            cbLoaiHang.ValueMember = "maLoaiHang";

            BULNhaCungCap bulNCC = new BULNhaCungCap();
            cbNCC.DataSource = bulNCC.layNhaCungCap();
            cbNCC.DisplayMember = "tenNhaCungCap";
            cbNCC.ValueMember = "maNhaCungCap";

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                BULHang bul = new BULHang();
                bul.suaHang(new Hang(int.Parse(txtMaHang.Text), txtTenHang.Text, txtDonViTinh.Text, float.Parse(txtDonGia.Text), int.Parse(txtSoLuongCon.Text), int.Parse(cbLoaiHang.SelectedValue + ""), int.Parse(cbNCC.SelectedValue + "")));
                frmST.hienDanhSachHang();
                MessageBox.Show("Sửa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Thao tác thất bạt, dữ liệu sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } 
        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {
            BULHang bul = new BULHang();
            List<Hang> arr = bul.layHang();
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].MaHang + "" == txtMaHang.Text)
                {
                    txtDonGia.Text = arr[i].DonGia + "";
                    txtDonViTinh.Text = arr[i].DonViTinh;
                    txtSoLuongCon.Text = arr[i].SoLuongCon + "";
                    txtTenHang.Text = arr[i].TenHang;
                    cbLoaiHang.SelectedValue = arr[i].MaLoaiHang;
                    cbNCC.SelectedValue = arr[i].MaNhaCungCap;



                    break;
                }
                else
                {
                    txtDonGia.Text = "";
                    txtDonViTinh.Text = "";
                    txtSoLuongCon.Text = "";
                    txtTenHang.Text = "";
                }
            }
        }
    }
}
