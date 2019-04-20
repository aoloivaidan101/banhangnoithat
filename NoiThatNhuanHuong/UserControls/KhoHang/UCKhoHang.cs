using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.KhoHang
{
    public partial class UCKhoHang : UserControl
    {
        public UCKhoHang()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            display();
        }

        void display()
        {
            gridControl1.DataSource = SQL_KhoHang.Display_HangTon();
            FixNColumnNames();
        }
        public void FixNColumnNames()
        {
            gridView1.Columns[0].Caption = "Mã sản phẩm";
            gridView1.Columns[1].Caption = "Tên sản phẩm";
            gridView1.Columns[2].Caption = "Số lượng";
        }

        private void UCKhoHang_Load(object sender, EventArgs e)
        {
            display();
        }
    }
}
