using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.XReport
{
    public partial class HoaDonBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        public HoaDonBanHang()
        {
            InitializeComponent();
        }
        private ListView control;
        public ListView ListViewControl
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
                printableComponentContainer1.PrintableComponent = control;
            }
        }
        public ListView GridControl1 { get; internal set; }



        public void SetProperties(string tenNhanVien, string MaHoaDon, string MaKhachHang, string tenKhachHang, string SDT, string Email, string DiaChi, string TongTien, string NgayThang )
        {
            txtTenNV.Text =tenNhanVien;
            txtHoaDon.Text = MaHoaDon;
            txtMaKH.Text = MaKhachHang;
            txtTenKH.Text = tenKhachHang;
            txtSDT.Text = SDT;
            txtEmail.Text = Email;
            txtDiaChi.Text = DiaChi;
            txtTongTien.Text = TongTien;
            txtNgayThang.Text = NgayThang;
        }

    }
}
