using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NoiThatNhuanHuong
{
    class SQL_DanhMuc
    {
        #region Danh Mục

        #region Loại Sản Phẩm
        public static void Add_LoaiSanPham (string MaLoaiSP, string TenLoaiSP,string MaVL)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO LoaiSP VALUES (@MaLoaiSP,@TenLoaiSP,@MaVL)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaLoaiSP", MaLoaiSP);
                command.Parameters.AddWithValue("TenLoaiSP", TenLoaiSP);
                command.Parameters.AddWithValue("MaVL", MaVL);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Edit_LoaiSanPham(string MaLoaiSP, string TenLoaiSP, string MaVL)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE LoaiSP SET  MaLoaiSP=@MaLoaiSP, TenLoaiSP=@TenLoaiSP, MaVL=@MaVL   WHERE MaLoaiSP = @MaLoaiSP";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaLoaiSP", MaLoaiSP);
                command.Parameters.AddWithValue("TenLoaiSP", TenLoaiSP);
                command.Parameters.AddWithValue("MaVL", MaVL);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }




        public static void Delete_LoaiSanPham(string MaLoaiSP)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM LoaiSP WHERE MaLoaiSP = @MaLoaiSP";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaLoaiSP", MaLoaiSP);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static DataTable Display_LoaiSanPham()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT LoaiSP.MaLoaiSP,TenLoaiSP,VatLieu.TenVL FROM LoaiSP join VatLieu on VatLieu.MaVL =LoaiSP.MaVL";
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

        #region Vật Liệu
        public static void Add_VatLieu(string MaVL, string TenVL)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO VatLieu VALUES (@MaVL,@TenVL)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaVL", MaVL);
                command.Parameters.AddWithValue("TenVL", TenVL);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Edit__VatLieu(string MaVL, string TenVL)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE VatLieu SET  MaVL=@MaVL, TenVL=@TenVL  WHERE MaVL = @MaVL";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaVL", MaVL);
                command.Parameters.AddWithValue("TenVL", TenVL);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Delete_VatLieu(string MaVL)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM VatLieu WHERE MaVL = @MaVL";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaVL", MaVL);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static DataTable Display_VatLieu()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT * FROM VatLieu ";
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

        #region Chức Vụ
        public static void Add_ChucVu(string MaCV, string TenCV)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO ChucVu VALUES (@MaCV,@TenCV)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaCV", MaCV);
                command.Parameters.AddWithValue("TenCV", TenCV);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Edit__ChucVu(string MaCV, string TenCV)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE ChucVu SET  MaCV=@MaCV, TenCV=@TenCV  WHERE MaCV = @MaCV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaCV", MaCV);
                command.Parameters.AddWithValue("TenCV", TenCV);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Delete_ChucVu(string MaCV)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM ChucVu WHERE MaCV = @MaCV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaCV", MaCV);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static DataTable Display_ChucVu()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT * FROM ChucVu ";
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

        #endregion
    }
}
    