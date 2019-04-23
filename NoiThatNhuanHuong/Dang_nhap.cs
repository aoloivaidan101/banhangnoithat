using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong
{
    public partial class Dang_nhap : Form
    {
        public Dang_nhap()
        {
            InitializeComponent();
        }

        DataTable bang_NguoiDung = new DataTable();
        /*  private void ShowFormMain()
          {
              Form1 fm = new Form1();
              fm.ShowDialog();

          }*/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            bang_NguoiDung = SQL_HeThong.Display_NguoiDung();

            for (int i = 0; i < bang_NguoiDung.Rows.Count; i++)
            {
                if (txtTenDangNhap.Text == bang_NguoiDung.Rows[i][2].ToString() && txtMatKhau.Text == bang_NguoiDung.Rows[i][3].ToString())
                {

                    {
                        this.Hide();
                        Form1 frm = new Form1();
                        frm.Show();

                    }
                }
                else
                {
                    MessageBox.Show(" Tài khoản không tồn tại ", "Thông báo");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát không", "Thông báo",MessageBoxButtons.YesNo);
            if(thoat==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Dang_nhap_Load(object sender, EventArgs e)
        {
            
        }
    }
}
