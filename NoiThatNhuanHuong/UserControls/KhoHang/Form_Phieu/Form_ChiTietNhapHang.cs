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
    public partial class Form_ChiTietNhapHang : DevExpress.XtraEditors.XtraForm
    {
        public Form_ChiTietNhapHang()
        {
            InitializeComponent();
        }

        
        void display()  //load thông tin về phiếu
        {
            DataTable phieunhapkho = SQL_KhoHang.Display_PhieuNhapKho();

            txtMaPhieuNhap.Text = Temp.Temp_PhieuNhapHangID;
            for(int i=0;i<phieunhapkho.Rows.Count;i++)
            {
                if(Temp.Temp_PhieuNhapHangID==phieunhapkho.Rows[i][0].ToString())
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

        private void Form_ChiTietNhapHang_Load(object sender, EventArgs e)
        {
            display();
            GetData();
            listView1.GridLines = true;
        }
        
        void GetData() // đổ dữ liệu vào listview
        {
            DataTable chitiethoadon = SQL_KhoHang.Display_ChiTietNhapKho_Find(Temp.Temp_PhieuNhapHangID);           
            //add dòng cho list view
            for(int j=0;j< chitiethoadon.Rows.Count;j++)
            {
                ListViewItem dong = new ListViewItem((j+1).ToString());
                for(int k=2;k<chitiethoadon.Columns.Count;k++)
                {
                    ListViewItem.ListViewSubItem cot = new ListViewItem.ListViewSubItem(dong, chitiethoadon.Rows[j][k].ToString());
                    dong.SubItems.Add(cot);
                }             
                listView1.Items.Add(dong);
            }
            
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("22");
        }
    }
}