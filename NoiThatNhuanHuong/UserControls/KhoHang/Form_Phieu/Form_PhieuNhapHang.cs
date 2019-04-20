using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace NoiThatNhuanHuong.UserControls.KhoHang.Form_Phieu
{
    public partial class Form_PhieuNhapHang : DevExpress.XtraEditors.XtraForm
    {
        public Form_PhieuNhapHang()
        {
            InitializeComponent();
        }

        private void Form_PhieuNhapHang_Load(object sender, EventArgs e)
        {
            display_CBB();
            txtDaThanhToan.Text = "0";
            txtDonGia.Text = "0";
            txtTongTien.Text = "0";
        }

        void display_CBB()
        {
            cbbNhanVien.DataSource = SQL_ThongTin.Display_NhanVien();
            cbbNhanVien.DisplayMember = "TenNV";
            cbbNhanVien.ValueMember = "MaNV";

            cbbNCC.DataSource = SQL_ThongTin.Display_NCC();
            cbbNCC.DisplayMember = "TenNCC";
            cbbNCC.ValueMember = "MaNCC";


            DataTable temp = SQL_ThongTin.Display_SanPham_Find(cbbNCC.SelectedValue.ToString());
            cbbSanPham.DataSource = temp;
            cbbSanPham.DisplayMember = "Tên Sản Phẩm";
            cbbSanPham.ValueMember = "Mã Sản Phẩm";
        }

        void reset()
        {
            listView1.Items.Clear();
            cbbNCC.Text = "";
            cbbNhanVien.Text = "";
            cbbSanPham.Text = "";
            nmrSoLuong.Text = "";
            txtDonGia.Text = "";
            txtThanhTien.Text = "";
            txtTongTien.Text = "";
            txtDaThanhToan.Text = "";
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            reset();
        }

       

        private void cbbSanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable temp = SQL_ThongTin.Display_SanPham_Find(cbbNCC.SelectedValue.ToString());
            if (temp.Rows.Count > 0)
            {
                txtDonGia.Text = temp.Rows[cbbSanPham.SelectedIndex][4].ToString();
            }
        }

        private void cbbNCC_SelectedValueChanged(object sender, EventArgs e)
        {
            cbbSanPham.ResetText();
            txtDonGia.Text = "";
            DataTable temp = SQL_ThongTin.Display_SanPham_Find(cbbNCC.SelectedValue.ToString());
            cbbSanPham.DataSource = temp;
            cbbSanPham.DisplayMember = "Tên Sản Phẩm";
            cbbSanPham.ValueMember = "Mã Sản Phẩm";
        }

        private void nmrSoLuong_ValueChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = (int.Parse(nmrSoLuong.Value.ToString()) * int.Parse(txtDonGia.Text)).ToString();
        }

        private void txtDonGia_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDonGia.Text != "")
                txtThanhTien.Text = (int.Parse(nmrSoLuong.Value.ToString()) * int.Parse(txtDonGia.Text)).ToString();
            else
                txtThanhTien.Text = "";
        }
        int stt = 1;
        int tongtien = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbbNCC.Text == "" || cbbSanPham.Text == "" || nmrSoLuong.Value <1 || txtDonGia.Text==""||txtThanhTien.Text=="")
            {
                ///bắt lỗi
            }
            else
            {
                /// bắt lỗi cho combobox
                /// 
                /// nếu trùng sản phảm thì cập nhật cho  số lượng
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (cbbSanPham.SelectedValue.ToString() == listView1.Items[0].SubItems[1].Text)
                    {
                        // số lượng
                        int soluongcu = int.Parse(listView1.Items[i].SubItems[3].Text);
                        int soluongmoi = int.Parse(nmrSoLuong.Value.ToString());
                        listView1.Items[i].SubItems[3].Text = (soluongcu + soluongmoi).ToString();
                        // tính tổng tiền
                        tongtien = tongtien + int.Parse(txtThanhTien.Text);
                        txtTongTien.Text = tongtien.ToString();
                        // thành tiền = số luong * đơn giá
                        int soluong = int.Parse(listView1.Items[i].SubItems[3].Text);
                        listView1.Items[0].SubItems[5].Text = (soluong * int.Parse(txtDonGia.Text)).ToString();
                        ///
                        stt++;
                        cbbNCC.Enabled = false;
                        return;
                    }
                }
            }
            /// Nếu không trùng thì thêm  dòng mới
            ///add vào listview     
                   ListViewItem dong = new ListViewItem((stt).ToString());
                   dong.SubItems.Add(cbbSanPham.SelectedValue.ToString());
                   dong.SubItems.Add(cbbSanPham.Text);
                   dong.SubItems.Add(nmrSoLuong.Value.ToString());
                   dong.SubItems.Add(txtDonGia.Text);
                   dong.SubItems.Add(txtThanhTien.Text);
                   listView1.Items.Add(dong);
                    // tính tổng tiền
                    tongtien = tongtien + int.Parse(txtThanhTien.Text);
                    txtTongTien.Text = tongtien.ToString();
                    stt++;  
                    cbbNCC.Enabled = false;
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items.RemoveAt(i);    // xóa tại dòng được chọn
                    stt--;
                    // tính tổng tiền
                    tongtien = tongtien - thanhtien;
                    txtTongTien.Text = tongtien.ToString();
                    // đẩy STT lên
                    for (int j = i;j<listView1.Items.Count;j++)
                    {
                        listView1.Items[j].Text = (j+1).ToString();
                    }
                }
            }
            
        }
        int thanhtien;
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var item = e.Item;
            thanhtien = int.Parse(item.SubItems[5].Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbbNhanVien.Text == "" || int.Parse(txtTongTien.Text) < 1)
            {
                /// bắt lỗi
            }
            else
            {
                // bắt lỗi cho cbb

                /// add Phiếu Nhập vào SQL
                SQL_KhoHang.Add_PhieuNhapHang(cbbNhanVien.SelectedValue.ToString(), dpkNgayNhap.Value.ToString("yyyy-MM-dd"), decimal.Parse(txtTongTien.Text), decimal.Parse(txtDaThanhToan.Text));

                /// lấy mã phiếu nhập hàng vừa nhập
                string Temp_PhieuNhapHang = "";
                DataTable Temp = SQL_KhoHang.Display_PhieuNhapKho();
                Temp_PhieuNhapHang = Temp.Rows[Temp.Rows.Count - 1][0].ToString();

                /// add bảng listview Chi tiết phiếu nhập vào SQL
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    SQL_KhoHang.Add_ChiTietNhapHang(Temp_PhieuNhapHang, listView1.Items[i].SubItems[1].Text, int.Parse(listView1.Items[i].SubItems[3].Text), decimal.Parse(listView1.Items[i].SubItems[5].Text));
                }
                reset();
            }
        }
    }
}