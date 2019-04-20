using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NoiThatNhuanHuong
{
    class SQL_HeThong
    {
        #region Hệ Thống

        #region Người Dùng
        public static void Add_NguoiDung(string HoTen, string TenDangNhap, string MatKhau)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO NguoiDung VALUES (@HoTen,@TenDangNhap,@MatKhau)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("HoTen", HoTen);
                command.Parameters.AddWithValue("TenDangNhap", TenDangNhap);
                command.Parameters.AddWithValue("MatKhau", MatKhau);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Edit__NguoiDung(int MaNguoiDung,string HoTen, string TenDangNhap, string MatKhau)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE NguoiDung SET HoTen=@HoTen, TenDangNhap=@TenDangNhap, MatKhau=@MatKhau  WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("HoTen", HoTen);
                command.Parameters.AddWithValue("TenDangNhap", TenDangNhap);
                command.Parameters.AddWithValue("MatKhau", MatKhau);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Delete_Nguoidung(int MaNguoiDung)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNguoiDung", MaNguoiDung);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static DataTable Display_NguoiDung()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT * FROM NguoiDung";
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

        #region Phân Quyền
        public static void Add_PhanQuyen(int MaNguoiDung, bool ChucNangHeThong, bool ChucNangBanHang, bool ChucNangKho, bool ChucNangCongNo, bool ChucNangQuanLy, bool ChucNangDanhMuc, bool ChucNangBaoCao)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO  VALUES (@MaNguoiDung,@ChucNangHeThong,@ChucNangBanHang,@ChucNangKho,@ChucNangCongNo,@ChucNangQuanLy,@ChucNangDanhMuc,@ChucNangBaoCao)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNguoiDung", MaNguoiDung);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Edit__PhanQuyen(int MaNguoiDung, bool ChucNangHeThong, bool ChucNangBanHang, bool ChucNangKho, bool ChucNangCongNo, bool ChucNangQuanLy, bool ChucNangDanhMuc, bool ChucNangBaoCao)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE PhanQuyen SET  MaNguoiDung=@MaNguoiDung, ChucNangHeThong=@ChucNangHeThong, ChucNangBanHang=@ChucNangBanHang, ChucNangKho=@ChucNangKho, ChucNangCongNo=@ChucNangCongNo, ChucNangQuanLy=@ChucNangQuanLy, ChucNangDanhMuc=@ChucNangDanhMuc, ChucNangBaoCao=@ChucNangBaoCao  WHERE MaNguoiDung = @MaNguoiDung";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNguoiDung", MaNguoiDung);
                command.Parameters.AddWithValue("ChucNangHeThong", ChucNangHeThong);
                command.Parameters.AddWithValue("ChucNangBanHang", ChucNangBanHang);
                command.Parameters.AddWithValue("ChucNangKho", ChucNangKho);
                command.Parameters.AddWithValue("ChucNangCongNo", ChucNangCongNo);
                command.Parameters.AddWithValue("ChucNangQuanLy", ChucNangQuanLy);
                command.Parameters.AddWithValue("ChucNangDanhMuc", ChucNangDanhMuc);
                command.Parameters.AddWithValue("ChucNangBaoCao", ChucNangBaoCao);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
     
        public static DataTable Display_PhanQuyen()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT  * FROM PhanQuyen";
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
