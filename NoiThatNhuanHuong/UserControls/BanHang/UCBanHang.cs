using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoiThatNhuanHuong.UserControls.XReport;
using DevExpress.XtraReports.UI;

namespace NoiThatNhuanHuong.UserControls.BanHang
{
    public partial class UCBanHang : UserControl
    {
        public UCBanHang()
        {
            InitializeComponent();
        }

        private void UCBanHang_Load(object sender, EventArgs e)
        {
            display_Gridview();
            display_Nhanvien();
            reset();     
        }

        void reset()
        {
            /// những control = false
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;

            /// những text = flase
            txtMaKH.Enabled = false;
            txtDiaChiGiaoHang.Enabled = false;
            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtDonGia.Enabled = false;
            txtThanhTien.Enabled = false;

            /// text 
            txtDonGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTongTien.Text = "0";
            

        }
        void display_Gridview()
        {
            gridControl1.DataSource = SQL_ThongTin.Display_SanPham();
            gridView1.Columns[4].Visible = false;       // ẩn cột nhà cung cấp giá nhập và mô tả
            gridView1.Columns[7].Visible = false;          
        }
        void display_Nhanvien()
        {
            cbbNhanVien.DataSource = SQL_ThongTin.Display_NhanVien();
            cbbNhanVien.DisplayMember = "TenNV";
            cbbNhanVien.ValueMember = "MaNV";
        }

        // load thông tin khách hàng nếu  đã có
        bool khachhangcu =false;
        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {
            DataTable khachhang = SQL_ThongTin.Display_KhachHang();
            for(int i=0;i<khachhang.Rows.Count;i++)
            {
                if(txtSDT.Text == khachhang.Rows[i][1].ToString())
                {
                    MessageBox.Show("Khách hàng cũ.", "Thông báo.");
                    khachhangcu = true;
                    txtMaKH.Text = khachhang.Rows[i][0].ToString();
                    txtTenKH.Text = khachhang.Rows[i][2].ToString();
                    txtEmail.Text = khachhang.Rows[i][4].ToString();
                    txtDiaChi.Text = khachhang.Rows[i][3].ToString();
                    txtDiaChi.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTenKH.Enabled = false;
                    return;
                }
            }
            khachhangcu = false;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtTenKH.Enabled = true;
        }

        private void ckGiaoHang_CheckedChanged(object sender, EventArgs e)
        {
            if(ckGiaoHang.Checked)  txtDiaChiGiaoHang.Enabled = true;
            else txtDiaChiGiaoHang.Enabled = false;
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaSP.Text= gridView1.GetRowCellValue(e.RowHandle, "Mã Sản Phẩm").ToString();
            txtTenSP.Text = gridView1.GetRowCellValue(e.RowHandle, "Tên Sản Phẩm").ToString();
            txtDonGia.Text = gridView1.GetRowCellValue(e.RowHandle, "Giá Bán").ToString();
            temp_soluong= int.Parse(gridView1.GetRowCellValue(e.RowHandle, "Số Lượng").ToString());
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
        int temp_soluong;
        private void nmrSoLuong_ValueChanged(object sender, EventArgs e)
        {
            /// báo  hết hàng
            if(temp_soluong< int.Parse(nmrSoLuong.Value.ToString()))
            {
                MessageBox.Show("Không đủ số lượng bán");
                errorProvider1.SetError(nmrSoLuong, "không đủ số lượng bán");
            }
            else txtThanhTien.Text = (int.Parse(nmrSoLuong.Value.ToString()) * int.Parse(txtDonGia.Text)).ToString();
        }

        private void txtDonGia_EditValueChanged(object sender, EventArgs e)
        {
                txtThanhTien.Text = (int.Parse(nmrSoLuong.Value.ToString()) * int.Parse(txtDonGia.Text)).ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem items in listView1.SelectedItems)
            {              
                txtMaSP.Text = items.SubItems[1].Text;
                txtTenSP.Text = items.SubItems[2].Text;
                nmrSoLuong.Text = items.SubItems[3].Text;
                txtDonGia.Text = items.SubItems[4].Text;
                txtThanhTien.Text = items.SubItems[5].Text;
            }
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        int stt = 1;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (nmrSoLuong.Value < 1 || temp_soluong < int.Parse(nmrSoLuong.Value.ToString()))
            {
                ///bắt lỗi
                MessageBox.Show("Thêm giỏ hàng lỗi", "Thông báo");
                if(nmrSoLuong.Value < 1) errorProvider1.SetError(nmrSoLuong, "chưa nhập số lượng");
                if(temp_soluong < int.Parse(nmrSoLuong.Value.ToString())) errorProvider1.SetError(nmrSoLuong, "không đủ số lượng bán");
            }
            else
            {              
                /// nếu trùng sản phảm thì cập nhật cho  số lượng
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (txtMaSP.Text == listView1.Items[i].SubItems[1].Text)
                    {
                        // số lượng
                        int soluongcu = int.Parse(listView1.Items[i].SubItems[3].Text);
                        int soluongmoi = int.Parse(nmrSoLuong.Value.ToString());
                        listView1.Items[i].SubItems[3].Text = (soluongcu + soluongmoi).ToString();
                        // tính tổng tiền
                        // thành tiền = số luong * đơn giá
                        int soluong = int.Parse(listView1.Items[i].SubItems[3].Text);
                        listView1.Items[i].SubItems[5].Text = (soluong * int.Parse(txtDonGia.Text)).ToString();
                        TongTien();
                        ///
                       // stt++;
                        return;
                    }
                }

                /// Nếu không trùng thì thêm  dòng mới
                ///add vào listview     
                ListViewItem dong = new ListViewItem((stt).ToString());
                dong.SubItems.Add(txtMaSP.Text);
                dong.SubItems.Add(txtTenSP.Text);
                dong.SubItems.Add(nmrSoLuong.Value.ToString());
                dong.SubItems.Add(txtDonGia.Text);
                dong.SubItems.Add(txtThanhTien.Text);
                listView1.Items.Add(dong);
                // tính tổng tiền
                TongTien();
                stt++;
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    // sửa thành tiền 
                    // sửa số lượng
                    // sửa tổng tiên                   
                    listView1.Items[i].SubItems[3].Text = nmrSoLuong.Value.ToString();
                    listView1.Items[i].SubItems[5].Text = txtThanhTien.Text;
                    TongTien();
                }
            }
        }

        void TongTien()
        {
            int tongtien = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                tongtien = tongtien + int.Parse(listView1.Items[i].SubItems[5].Text);
            }
            txtTongTien.Text = tongtien.ToString();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items.RemoveAt(i);    // xóa tại dòng được chọn
                    stt--;
                    // tính tổng tiền                 
                    TongTien();
                    // đẩy STT lên
                    for (int j = i; j < listView1.Items.Count; j++)
                    {
                        listView1.Items[j].Text = (j + 1).ToString();
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            reset();
            errorProvider1.Clear();
            listView1.Items.Clear();
            ckGiaoHang.Checked = false;
            txtDiaChiGiaoHang.ResetText();
            cbbNhanVien.Text = "";
            txtMaNV.Text = "";
            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtEmail.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            nmrSoLuong.Value = 0;
        }

        private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load mã nhân viên tương ứng tên đc chọn
            DataTable nhanvien = SQL_ThongTin.Display_NhanVien(); 
            //MessageBox.Show(nhanvien.Rows[int.Parse(cbbNhanVien.SelectedIndex.ToString())][0].ToString());
            txtMaNV.Text = nhanvien.Rows[int.Parse(cbbNhanVien.SelectedIndex.ToString())][0].ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string MaKH;
            string MaHD;
            if (txtSDT.Text == "" || txtTenKH.Text == "" ||txtEmail.Text==""||txtDiaChi.Text==""|| txtMaNV.Text == "" || int.Parse(txtTongTien.Text) < 1)
            {
                /// báo lỗi
                 MessageBox.Show("Lỗi dữ liệu.","Thông báo");
                if (txtTenKH.Text == "") errorProvider1.SetError(txtTenKH, "chưa điền tên khách hàng.");
                if (txtSDT.Text == "") errorProvider1.SetError(txtSDT, "chưa điền sđt khách hàng.");
                if (txtDiaChi.Text == "") errorProvider1.SetError(txtDiaChi, "chưa điền địa chỉ.");
                if (txtEmail.Text == "") errorProvider1.SetError(txtEmail, "chưa điền email.");
                if (txtMaNV.Text == "") errorProvider1.SetError(cbbNhanVien, "chưa chọn nhân viên.");
                if (int.Parse(txtTongTien.Text) < 1) errorProvider1.SetError(txtTongTien, "Chưa có thông tin mặt hàng.");
                return;
            }
            else
            {
                /// lưu thông tin khách hàng
                if (khachhangcu == false)
                {
                        /// add
                        SQL_ThongTin.Add_KhachHang(txtSDT.Text, txtTenKH.Text, txtDiaChi.Text, txtEmail.Text);
                        /// lấy ra mã khách hàng của thằng khách hàng vừa add (ở vị trí cuối cùng)
                        DataTable khachhang = SQL_ThongTin.Display_KhachHang();
                        MaKH = khachhang.Rows[khachhang.Rows.Count - 1][0].ToString();
                   // }
                }
                else
                {
                    /// lấy mã KH cũ để tạo hóa đơn
                    MaKH = txtMaKH.Text;
                }

                /// lưu thông tin hóa đơn
                      /// Add
                    SQL_BanHang.Add_HoaDon(txtMaNV.Text, MaKH, DateTime.Now.ToString("yyyy-MM-dd"), decimal.Parse(txtTongTien.Text));
                    /// lấy ra mã hóa đơn  vừa add (ở vị trí cuối cùng)
                    DataTable hoadon = SQL_BanHang.Display_HoaDon();
                    MaHD = hoadon.Rows[hoadon.Rows.Count - 1][0].ToString();
               // }
                /// lưu thông tin chi tiết hóa đơn
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    SQL_BanHang.Add_ChiTietHoaDon(MaHD, listView1.Items[i].SubItems[1].Text, int.Parse(listView1.Items[i].SubItems[3].Text), decimal.Parse(listView1.Items[i].SubItems[5].Text));                  
                }
            }
            MessageBox.Show("Thêm Hóa đơn thành công.");

            /// In Hoa Don
            gridView1.BestFitColumns();
            HoaDonBanHang report = new HoaDonBanHang();
            report.ListViewControl = listView1;
            // set thuộc tính
            string ngaythang = "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            report.SetProperties(cbbNhanVien.Text,MaHD,MaKH,txtTenKH.Text,txtSDT.Text,txtEmail.Text,txtDiaChi.Text,txtTongTien.Text,ngaythang);

            //thu nhỏ hóa đơn
            report.PaperKind = System.Drawing.Printing.PaperKind.Statement;
            report.Landscape = true;

            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
