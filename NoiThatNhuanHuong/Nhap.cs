using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace NoiThatNhuanHuong
{
    class Nhap
    {
        //Đổ dữ liệu vào combobox
        //  cbbLoaiPhong.DataSource = SQL_Connect.Display_LoaiPhong();
        //     cbbLoaiPhong.DisplayMember = "Tên Loại Phòng";
        //     cbbLoaiPhong.ValueMember = "Mã Loại Phòng";

        // click vào gridview => đổ dữa liệu vào control
        //txtMaLoai.Text = gridView1.GetRowCellValue(e.RowHandle, "Mã Loại Phòng").ToString();

        // add mã loại sản phẩm khi chọn tên sản phẩm ở combobox
        // sp.MaLoaiSP = cbbLoaiSP.SelectedValue.ToString();  


        /*
    public string radio_To_string()
    {

        return (rdoNam.Checked == true) ? "true" : "false";
    } // check radio -> string      : gọi hàm khi thêm/sửa
*/

        /*
        if (DataGridView1.Rows[row].Cells[5].Value.ToString() == "Nam")
                rdoNam.Checked = true;
            if (DataGridView1.Rows[row].Cells[5].Value.ToString() == "Nữ")
                rdoNu.Checked = true;
            */

        #region Test báo cáo
        public static DataTable Display_BaoCao()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT *FROM nhanvienchucvu";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                connection.Close();
                return table;
            }
        }
        #endregion
    }
}
