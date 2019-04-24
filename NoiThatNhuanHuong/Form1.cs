using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoiThatNhuanHuong
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "McSkin";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skins();
        }




        private void btnLoaiSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.DanhMuc.UCLoaiSanPham LoaiSanPham = new UserControls.DanhMuc.UCLoaiSanPham();
            DevExpress.XtraTab.XtraTabPage tabLoaiSanPham = new DevExpress.XtraTab.XtraTabPage();
            tabLoaiSanPham.Name = "tabLoaiSanPham";
            tabLoaiSanPham.Text = "Loại Sản Phẩm";
            tabLoaiSanPham.Controls.Add(LoaiSanPham);
            LoaiSanPham.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Loại Sản Phẩm")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) {}
            else
            {
                xtabHienThi.TabPages.Add(tabLoaiSanPham);
                xtabHienThi.SelectedTabPage = tabLoaiSanPham;
            }
        }

        private void btnChatLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   
            UserControls.DanhMuc.UCVatLieu VatLieu = new UserControls.DanhMuc.UCVatLieu();
            DevExpress.XtraTab.XtraTabPage tabVatLieu = new DevExpress.XtraTab.XtraTabPage();
            tabVatLieu.Name = "tabVatLieu";
            tabVatLieu.Text = "Vật Liệu";
            tabVatLieu.Controls.Add(VatLieu);
            VatLieu.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Vật Liệu")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabVatLieu);
                xtabHienThi.SelectedTabPage = tabVatLieu;
            }
        }
        private void btnChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.DanhMuc.UCChucVu ChucVu = new UserControls.DanhMuc.UCChucVu();
            DevExpress.XtraTab.XtraTabPage tabChucVu = new DevExpress.XtraTab.XtraTabPage();
            tabChucVu.Name = "tabChucVu";
            tabChucVu.Text = "Chức Vụ";
            tabChucVu.Controls.Add(ChucVu);
            ChucVu.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Chức Vụ")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabChucVu);
                xtabHienThi.SelectedTabPage = tabChucVu;
            }
        }
        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.ThongTin.UCNhanVien NhanVien = new UserControls.ThongTin.UCNhanVien();
            DevExpress.XtraTab.XtraTabPage tabNhanVien = new DevExpress.XtraTab.XtraTabPage();
            tabNhanVien.Name = "tabNhanVien";
            tabNhanVien.Text = "Nhân Viên";
            tabNhanVien.Controls.Add(NhanVien);
            NhanVien.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "nhân Viên")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabNhanVien);
                xtabHienThi.SelectedTabPage = tabNhanVien;
            }
        }
        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.ThongTin.UCKhachHang KhachHang = new UserControls.ThongTin.UCKhachHang();
            DevExpress.XtraTab.XtraTabPage tabKhachHang = new DevExpress.XtraTab.XtraTabPage();
            tabKhachHang.Name = "tabKhachHang";
            tabKhachHang.Text = "Khách Hàng";
            tabKhachHang.Controls.Add(KhachHang);
            KhachHang.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Khách Hàng")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabKhachHang);
                xtabHienThi.SelectedTabPage = tabKhachHang;
            }
        }
        private void btnSanPham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.ThongTin.UCSanPham SanPham = new UserControls.ThongTin.UCSanPham();
            DevExpress.XtraTab.XtraTabPage tabSanPham = new DevExpress.XtraTab.XtraTabPage();
            tabSanPham.Name = "tabSanPham";
            tabSanPham.Text = "Sản Phẩm";
            tabSanPham.Controls.Add(SanPham);
            SanPham.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Sản Phẩm")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabSanPham);
                xtabHienThi.SelectedTabPage = tabSanPham;
            }
        }
        private void btnNhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.ThongTin.UCNhaCungCap NhaCungCap = new UserControls.ThongTin.UCNhaCungCap();
            DevExpress.XtraTab.XtraTabPage tabNhaCungCap = new DevExpress.XtraTab.XtraTabPage();
            tabNhaCungCap.Name = "tabNhaCungCap";
            tabNhaCungCap.Text = "Nhà cung cấp";
            tabNhaCungCap.Controls.Add(NhaCungCap);
            NhaCungCap.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Nhà Cung Cấp")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabNhaCungCap);
                xtabHienThi.SelectedTabPage = tabNhaCungCap;
            }
        }
        private void xtabHienThi_CloseButtonClick(object sender, EventArgs e)
        {
            xtabHienThi.TabPages.RemoveAt(xtabHienThi.SelectedTabPageIndex);
        }

        private void btnNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.HeThong.UCNguoiDung NguoiDung = new UserControls.HeThong.UCNguoiDung();
            DevExpress.XtraTab.XtraTabPage tabNguoiDung = new DevExpress.XtraTab.XtraTabPage();
            tabNguoiDung.Name = "tabNguoiDung";
            tabNguoiDung.Text = "Người Dùng";
            tabNguoiDung.Controls.Add(NguoiDung);
            NguoiDung.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Người Dùng")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabNguoiDung);
                xtabHienThi.SelectedTabPage = tabNguoiDung;
            }
        }
        private void btnPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.HeThong.UCPhanQuyen Phanquyen = new UserControls.HeThong.UCPhanQuyen();
            DevExpress.XtraTab.XtraTabPage tabPhanquyen = new DevExpress.XtraTab.XtraTabPage();
            tabPhanquyen.Name = "tabPhanQuyen";
            tabPhanquyen.Text = "Phân Quyền";
            tabPhanquyen.Controls.Add(Phanquyen);
            Phanquyen.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Phân Quyền")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabPhanquyen);
                xtabHienThi.SelectedTabPage = tabPhanquyen;
            }
        }

        private void btnTonKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.KhoHang.UCKhoHang khohang = new UserControls.KhoHang.UCKhoHang();
            DevExpress.XtraTab.XtraTabPage tabkhohang = new DevExpress.XtraTab.XtraTabPage();
            tabkhohang.Name = "tabKhoHang";
            tabkhohang.Text = "Kho Hàng";
            tabkhohang.Controls.Add(khohang);
            khohang.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Kho Hàng")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabkhohang);
                xtabHienThi.SelectedTabPage = tabkhohang;
            }
        }

        private void btnPhieuNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.KhoHang.UCPhieuNhapKho nhapkho = new UserControls.KhoHang.UCPhieuNhapKho();
            DevExpress.XtraTab.XtraTabPage tabnhapkho = new DevExpress.XtraTab.XtraTabPage();
            tabnhapkho.Name = "tabNhapKho";
            tabnhapkho.Text = "Phiếu Nhập Kho";
            tabnhapkho.Controls.Add(nhapkho);
            nhapkho.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Phiếu Nhập Kho")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabnhapkho);
                xtabHienThi.SelectedTabPage = tabnhapkho;
            }
        }

        private void btnHoaDonBanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.BanHang.UCBanHang banhang = new UserControls.BanHang.UCBanHang();
            DevExpress.XtraTab.XtraTabPage tabbanhang = new DevExpress.XtraTab.XtraTabPage();
            tabbanhang.Name = "tabBanHang";
            tabbanhang.Text = "Hóa Đơn";
            tabbanhang.Controls.Add(banhang);
            banhang.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Hóa Đơn")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabbanhang);
                xtabHienThi.SelectedTabPage = tabbanhang;
            }
        }

        private void btnDanhSachHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.BanHang.UCDanhSachHoaDon List_HoaDon = new UserControls.BanHang.UCDanhSachHoaDon();
            DevExpress.XtraTab.XtraTabPage tablisthoadon= new DevExpress.XtraTab.XtraTabPage();
            tablisthoadon.Name = "tabDanhsachhoadon";
            tablisthoadon.Text = "Danh Sách Hóa Đơn";
            tablisthoadon.Controls.Add(List_HoaDon);
            List_HoaDon.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Danh Sách Hóa Đơn")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tablisthoadon);
                xtabHienThi.SelectedTabPage = tablisthoadon;
            }
        }

        private void btnPhieuNo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.CongNo.UCPhieuNo PhieuNo = new UserControls.CongNo.UCPhieuNo();
            DevExpress.XtraTab.XtraTabPage tabPhieuno = new DevExpress.XtraTab.XtraTabPage();
            tabPhieuno.Name = "tabPhieuno";
            tabPhieuno.Text = "Phiếu nợ";
            tabPhieuno.Controls.Add(PhieuNo);
            PhieuNo.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Phiếu nợ")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabPhieuno);
                xtabHienThi.SelectedTabPage = tabPhieuno;
            }
        }

        private void btnPhieuTraNo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControls.CongNo.UCPhieuTraNo PhieuTraNo = new UserControls.CongNo.UCPhieuTraNo();
            DevExpress.XtraTab.XtraTabPage tabPhieuTraNo = new DevExpress.XtraTab.XtraTabPage();
            tabPhieuTraNo.Name = "tabPhieuTrano";
            tabPhieuTraNo.Text = "Phiếu trả nợ";
            tabPhieuTraNo.Controls.Add(PhieuTraNo);
            PhieuTraNo.Dock = DockStyle.Fill;
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtabHienThi.TabPages)
            {
                if (tab.Text == "Phiếu trả nợ")
                {
                    xtabHienThi.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1) { }
            else
            {
                xtabHienThi.TabPages.Add(tabPhieuTraNo);
                xtabHienThi.SelectedTabPage = tabPhieuTraNo;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
