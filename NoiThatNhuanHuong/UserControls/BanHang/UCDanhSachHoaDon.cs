using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.BanHang
{
    public partial class UCDanhSachHoaDon : UserControl
    {
        public UCDanhSachHoaDon()
        {
            InitializeComponent();
        }

        private void UCDanhSachHoaDon_Load(object sender, EventArgs e)
        {
            display();
        }

        void display()
        {
            gridControl1.DataSource = SQL_BanHang.Display_HoaDon();
            fixHeaderName();
        }
        void fixHeaderName()
        {
            gridView1.Columns[0].Caption = "Mã hóa đơn";
            gridView1.Columns[1].Caption = "Tên nhân viên";
            gridView1.Columns[2].Caption = "Mã khách hàng";
            gridView1.Columns[3].Caption = "Tên khách hàng";
            gridView1.Columns[4].Caption = "Ngày tạo";
            gridView1.Columns[5].Caption = "Tổng tiền";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            display();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            Temp.Temp_HoaDonID = gridView1.GetRowCellValue(e.RowHandle, "MaHoaDon").ToString();
            Form_ChiTietHoaDon dlg2 = new Form_ChiTietHoaDon();
            dlg2.ShowDialog();
        }
    }
}
