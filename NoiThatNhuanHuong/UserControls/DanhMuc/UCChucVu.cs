using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.DanhMuc
{
    public partial class UCChucVu : UserControl
    {
        public UCChucVu()
        {
            InitializeComponent();
        }

        private void UCChucVu_Load(object sender, EventArgs e)
        {
            BatDau();
        }

        void display()
        {
            gridControl1.DataSource = SQL_DanhMuc.Display_ChucVu();
            FixNColumnNames();
        }
        int chucnang;
        void BatDau()
        {
            chucnang = 0;
            // button
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            // Text
            txtMaChucVu.Enabled = false;
            txtTenChucVu.Enabled = false;
            txtMaChucVu.Text = "";
            txtTenChucVu.Text = "";
            // Data table
            display();
            // Bắt lỗi 
            errorProvider1.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BatDau();
            chucnang = 1;
            // button
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            // text
            txtMaChucVu.Enabled = true;
            txtTenChucVu.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BatDau();
            chucnang = 2;
            // button
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            // text
            txtTenChucVu.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông Báo", MessageBoxButtons.YesNo))
            {
                SQL_DanhMuc.Delete_ChucVu(txtMaChucVu.Text);
                BatDau();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaChucVu.Text = gridView1.GetRowCellValue(e.RowHandle, "MaCV").ToString();
            txtTenChucVu.Text = gridView1.GetRowCellValue(e.RowHandle, "TenCV").ToString();
        }
        public void FixNColumnNames()
        {
            gridView1.Columns[0].Caption = "Mã chức vụ";
            gridView1.Columns[1].Caption = "Tên chức vụ";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            BatDau();
        }

        DataTable chucvu = new DataTable();
        public bool checkma()
        {
            chucvu = SQL_DanhMuc.Display_ChucVu();
            bool check = false; // không trùng
            for (int i = 0; i < chucvu.Rows.Count; i++)
                if (txtMaChucVu.Text == chucvu.Rows[i][0].ToString())
                {
                    check = true;   // trùng mã
                    break;
                }
            return check;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaChucVu.Text == "" || txtTenChucVu.Text == "")
            {
                MessageBox.Show("Dữ liệu chưa đủ.", "Thông Báo");
                // bắt lỗi
                if (txtMaChucVu.Text == "") errorProvider1.SetError(txtMaChucVu, "Chưa điền mã Chức Vụ");
                if (txtTenChucVu.Text == "") errorProvider1.SetError(txtTenChucVu, "Chưa điền tên Chức Vụ");

            }
            else
            {
                if (chucnang == 1) // Nút thêm
                {
                    if (checkma() == true)
                    {
                        MessageBox.Show("Mã chức vụ đã tồn tại.", "Thông Báo");
                        //bắt lỗi
                        errorProvider1.SetError(txtMaChucVu, "Mã chức vụ đã tồn tại.");
                    }

                    else
                    {
                        SQL_DanhMuc.Add_ChucVu(txtMaChucVu.Text, txtTenChucVu.Text);
                        BatDau();
                    }
                }
                if (chucnang == 2)// nút sửa
                {
                    SQL_DanhMuc.Edit__ChucVu(txtMaChucVu.Text, txtTenChucVu.Text);
                    BatDau();
                }

            }
        }
    }
}
