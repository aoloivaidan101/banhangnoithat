﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoiThatNhuanHuong.UserControls.KhoHang.Form_Phieu;

namespace NoiThatNhuanHuong.UserControls.CongNo
{
    public partial class UCPhieuNo : UserControl
    {
        public UCPhieuNo()
        {
            InitializeComponent();
        }
        bool isLoadDone = false;    
        private void UCPhieuNo_Load(object sender, EventArgs e)
        {
            display(); 
            LoadInfor();
            display_NCC();
            cbbNCC.Text = "";
           isLoadDone = true;

        }

        void display()
        {
            gridControl1.DataSource = SQL_CongNo.Display_PhieuNo();
            fixHeaderName();          
        }
        void fixHeaderName()
        {
            gridView1.Columns[0].Caption = "Mã phiếu nợ";
            gridView1.Columns[1].Caption = "Mã phiếu nhập";
            gridView1.Columns[2].Caption = "Ngày nhập";
            gridView1.Columns[3].Caption = "Tiền nợ";
            gridView1.Columns[4].Caption = "Tình trạng";

        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            // lấy mã phiếu nhập
            Temp.Temp_PhieuNhapHangID = gridView1.GetRowCellValue(e.RowHandle, "MaPhieuNhap").ToString();
            Form_ChiTietNhapHang dlg2 = new Form_ChiTietNhapHang();
            dlg2.ShowDialog();
        }

        void LoadInfor()
        {
            DataTable phieuno = SQL_CongNo.Display_PhieuNo();
            txtSoPhieuNo.Text = phieuno.Rows.Count.ToString();
            int tongtien = 0;
            for (int i = 0; i < phieuno.Rows.Count; i++)
                tongtien = tongtien + int.Parse(phieuno.Rows[i][3].ToString());
            txtTongTien.Text = tongtien.ToString();
        }

        void display_NCC()
        {
            cbbNCC.DataSource = SQL_ThongTin.Display_NCC();
            cbbNCC.DisplayMember = "TenNCC";
            cbbNCC.ValueMember = "MaNCC";
;        }

        private void cbbNCC_SelectedValueChanged(object sender, EventArgs e)
        {
            //load bang
            if (cbbNCC.Text != "" && isLoadDone)
            {
                gridControl1.DataSource = SQL_CongNo.Display_PhieuNo_Find(cbbNCC.SelectedValue.ToString());
                fixHeaderName();
            }      
            ///// load phiếu 
            ///// load tổng tiền
            ///
            // 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cbbNCC.Text = "";
            display();
        }
    }
}
