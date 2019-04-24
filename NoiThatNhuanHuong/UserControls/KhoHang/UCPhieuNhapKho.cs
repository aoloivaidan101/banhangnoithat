using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoiThatNhuanHuong.UserControls.KhoHang.Form_Phieu;

namespace NoiThatNhuanHuong.UserControls.KhoHang
{
    public partial class UCPhieuNhapKho : UserControl
    {
        public UCPhieuNhapKho()
        {
            InitializeComponent();
        }

        private void UCPhieuNhapKho_Load(object sender, EventArgs e)
        {
            display();
        }
        void display()
        {
            gridControl1.DataSource = SQL_KhoHang.Display_PhieuNhapKho();
            FixNColumnNames();
        }
        public void FixNColumnNames()
        {
            gridView1.Columns[0].Caption = "Mã phiếu nhập";
            gridView1.Columns[1].Caption = "Nhân viên";
            gridView1.Columns[2].Caption = "Ngày nhập";
            gridView1.Columns[3].Caption = "Tổng tiền";
            gridView1.Columns[4].Caption = "Đã thanh toán";
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            display();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            Temp.Temp_PhieuNhapHangID = gridView1.GetRowCellValue(e.RowHandle, "MaPhieuNhap").ToString();
            Form_ChiTietNhapHang dlg2 = new Form_ChiTietNhapHang();
            dlg2.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_PhieuNhapHang form = new Form_PhieuNhapHang();
            form.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SQL_KhoHang.Delete_PhieuNhapHang(Temp.Temp_PhieuNhapHangID);
            display();
        }
    }
}
