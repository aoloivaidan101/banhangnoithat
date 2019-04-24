using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.CongNo
{
    public partial class Form_ChiTietPhieuNo : Form
    {
        public Form_ChiTietPhieuNo()
        {
            InitializeComponent();
        }

        private void Form_ChiTietPhieuNo_Load(object sender, EventArgs e)
        {
            display();
            GetData();
            listView1.GridLines = true;
            check_TinhTrangNo();
        }
        void check_TinhTrangNo()
        {
            DataTable check = SQL_CongNo.Display_PhieuNo();
            for(int i=0;i<check.Rows.Count; i++)
            {
                if (Temp.Temp_PhieuNoID == check.Rows[i][0].ToString())
                {
                    // MessageBox.Show(check.Rows[i][4].ToString());
                    if (check.Rows[i][4].ToString() == "True")
                    {
                        btnThanhToan.Enabled = false;
                        txtDaThanhToan.Text = check.Rows[i][3].ToString();
                    }
                    else
                    {
                        btnThanhToan.Enabled = true;
                    }
                }
            }
        }

        void display()  //load thông tin về phiếu
        {
            DataTable phieunhapkho = SQL_KhoHang.Display_PhieuNhapKho();

            txtMaPhieuNhap.Text = Temp.Temp_PhieuNhapHangID;

            
            for (int i = 0; i < phieunhapkho.Rows.Count; i++)
            {
                if (Temp.Temp_PhieuNhapHangID == phieunhapkho.Rows[i][0].ToString())
                {
                    txtNguoiNhan.Text = phieunhapkho.Rows[i][1].ToString();
                    dpkNgayNhap.Text = phieunhapkho.Rows[i][2].ToString();
                    txtTongTien.Text = phieunhapkho.Rows[i][3].ToString();
                    txtDaThanhToan.Text = phieunhapkho.Rows[i][4].ToString();
                }
            }

            // lấy tên nhà cung cấp tương  ứng
            DataTable find_NCC = SQL_KhoHang.Display_Find_NCC_of_NhapKho(Temp.Temp_PhieuNhapHangID);
            txtNhaCungCap.Text = find_NCC.Rows[0][0].ToString();
            txtDiaChi.Text = find_NCC.Rows[0][1].ToString();
        }

        void GetData() // đổ dữ liệu vào listview
        {
            DataTable chitiethoadon = SQL_KhoHang.Display_ChiTietNhapKho_Find(Temp.Temp_PhieuNhapHangID);
            //add dòng cho list view
            for (int j = 0; j < chitiethoadon.Rows.Count; j++)
            {
                ListViewItem dong = new ListViewItem((j + 1).ToString());
                for (int k = 2; k < chitiethoadon.Columns.Count; k++)
                {
                    ListViewItem.ListViewSubItem cot = new ListViewItem.ListViewSubItem(dong, chitiethoadon.Rows[j][k].ToString());
                    dong.SubItems.Add(cot);
                }
                listView1.Items.Add(dong);
            }

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            /// add vào  bảng trả nợ
            SQL_CongNo.Add_PhieuTraNo(Temp.Temp_PhieuNoID,DateTime.Now.ToString("yyyy-MM-dd"),decimal.Parse( txtTongTien.Text),"Chủ cửa hàng");
            /// sửa tình trạng phiếu nợ          
            SQL_CongNo.Edit_PhieuNo(int.Parse(Temp.Temp_PhieuNoID),true);
            MessageBox.Show("cập nhật trả nợ thành công.");
        }
    }
}
