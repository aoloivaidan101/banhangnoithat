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
    public partial class UCVatLieu : UserControl
    {
        public UCVatLieu()
        {
            InitializeComponent();
        }

        private void UCVatLieu_Load(object sender, EventArgs e)
        {
            BatDau();
        }

        void display()
        {
            gridControl1.DataSource = SQL_DanhMuc.Display_VatLieu();
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
            txtMaVatLieu.Enabled = false;
            txtTenVatLieu.Enabled = false;
            txtMaVatLieu.Text = "";
            txtTenVatLieu.Text = "";
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
            txtMaVatLieu.Enabled = true;
            txtTenVatLieu.Enabled = true;                    
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
            txtTenVatLieu.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa dữ liệu không?","Thông Báo",MessageBoxButtons.YesNo))
            {
                SQL_DanhMuc.Delete_VatLieu(txtMaVatLieu.Text);
                BatDau();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaVatLieu.Text = gridView1.GetRowCellValue(e.RowHandle, "MaVL").ToString();
            txtTenVatLieu.Text = gridView1.GetRowCellValue(e.RowHandle, "TenVL").ToString();
        }
        public void FixNColumnNames()
        {
            gridView1.Columns[0].Caption = "Mã vật liệu";
            gridView1.Columns[1].Caption = "Tên vật liệu";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BatDau();
        }

        DataTable vatlieu = new DataTable();
        public  bool checkma()
        {
            vatlieu = SQL_DanhMuc.Display_VatLieu(); 
            bool check = false; // không trùng
            for (int i = 0; i < vatlieu.Rows.Count; i++)
                if (txtMaVatLieu.Text == vatlieu.Rows[i][0].ToString())
                {
                    check = true;   // trùng mã
                    break;
                }                 
            return check;   
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(txtMaVatLieu.Text =="" || txtTenVatLieu.Text=="")
            {
                MessageBox.Show("Dữ liệu chưa đủ.", "Thông Báo");
                // bắt lỗi
                errorProvider1.SetError(txtMaVatLieu,"Chưa điền mã vật liệu");
                errorProvider1.SetError(txtTenVatLieu,"Chưa điền tên vật liệu");
            }
            else
            {
                if (chucnang == 1) // Nút thêm
                {
                    if (checkma() == true)
                    {
                        MessageBox.Show("Mã Vật Liệu đã tồn tại.", "Thông Báo");
                        //bắt lỗi
                        errorProvider1.SetError(txtMaVatLieu, "Mã Vật Liệu đã tồn tại.");
                    }
                        
                    else
                    {
                        SQL_DanhMuc.Add_VatLieu(txtMaVatLieu.Text, txtTenVatLieu.Text);
                        BatDau();
                    }                      
                }
                if (chucnang == 2)// nút sửa
                {
                    SQL_DanhMuc.Edit__VatLieu(txtMaVatLieu.Text, txtTenVatLieu.Text);
                    BatDau();
                }
                
            }
            
            
        }
    }
}
