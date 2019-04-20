using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.HeThong
{
    public partial class UCPhanQuyen : UserControl
    {
        public UCPhanQuyen()
        {
            InitializeComponent();
        }

        private void UCPhanQuyen_Load(object sender, EventArgs e)
        {
            display();
        }
        void display()
        {
            gridControl1.DataSource = SQL_HeThong.Display_PhanQuyen();
            FixNColumnNames();
        }
        public void FixNColumnNames()
        {
            gridView1.Columns[0].Caption = "Mã người dùng";
            gridView1.Columns[1].Caption = "Hệ Thống";
            gridView1.Columns[2].Caption = "Bán Hàng";
            gridView1.Columns[3].Caption = "Kho";
            gridView1.Columns[4].Caption = "Công Nợ";
            gridView1.Columns[5].Caption = "Quản Lý";
            gridView1.Columns[6].Caption = "Danh Mục";
            gridView1.Columns[7].Caption = "Báo Cáo";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            display();
        }
    }
}
