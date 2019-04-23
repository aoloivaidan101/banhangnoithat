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

namespace NoiThatNhuanHuong.UserControls.BanHang
{
    public partial class Form_ChiTietHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public Form_ChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void Form_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            display();
            GetData();
        }

        void display()      /// load thông tin hóa đơn
        {
            DataTable hoadon = SQL_BanHang.Display_HoaDon();
            for (int i = 0; i < hoadon.Rows.Count; i++)
            {
                if (Temp.Temp_HoaDonID == hoadon.Rows[i][0].ToString())
                {
                    txtMaHD.Text = hoadon.Rows[i][0].ToString();
                    txtTenKH.Text = hoadon.Rows[i][3].ToString();
                    txtTenNV.Text = hoadon.Rows[i][1].ToString();
                    txtTongTien.Text = hoadon.Rows[i][5].ToString();
                    dpkNgayban.Text = hoadon.Rows[i][4].ToString();
                }
            }
        }

        void GetData() // đổ dữ liệu vào listview
        {
            DataTable chitiethoadon = SQL_BanHang.Display_ChiTietHoaDon_Find(Temp.Temp_HoaDonID);
            //add dòng cho list view
            for (int j = 0; j < chitiethoadon.Rows.Count; j++)
            {
                ListViewItem dong = new ListViewItem((j + 1).ToString());
                for (int k = 0; k < chitiethoadon.Columns.Count; k++)
                {
                    ListViewItem.ListViewSubItem cot = new ListViewItem.ListViewSubItem(dong, chitiethoadon.Rows[j][k].ToString());
                    dong.SubItems.Add(cot);
                }
                listView1.Items.Add(dong);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SQL_BanHang.Delete_HoaDon(Temp.Temp_HoaDonID);
            this.Close();
        }
    }
}