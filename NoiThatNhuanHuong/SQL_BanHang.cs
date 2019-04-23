using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NoiThatNhuanHuong
{
    class SQL_BanHang
    {
        #region Add
        public static void Add_HoaDon(string MaNV, string MaKH,string Ngay,decimal TongTien)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "insert into HoaDon(MaNV,MaKH,Ngay,TongTien) values (@MaNV,@MaKH,@Ngay,@TongTien)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNV", MaNV);
                command.Parameters.AddWithValue("MaKH", MaKH);
                command.Parameters.AddWithValue("Ngay", Ngay);
                command.Parameters.AddWithValue("TongTien", TongTien);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Add_ChiTietHoaDon(string MaHoaDon, string MaSP, int SoLuongBan, decimal ThanhTien)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "insert into ChiTietHoaDon(MaHoaDon,MaSP,SoLuongBan,ThanhTien) values (@MaHoaDon,@MaSP,@SoLuongBan,@ThanhTien)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaHoaDon", MaHoaDon);
                command.Parameters.AddWithValue("MaSP", MaSP);
                command.Parameters.AddWithValue("SoLuongBan", SoLuongBan);
                command.Parameters.AddWithValue("ThanhTien", ThanhTien);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        #endregion

        #region Delete
        public static void Delete_HoaDon(string MaHoaDon)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaHoaDon", MaHoaDon);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        #endregion
        #region Display
        public static DataTable Display_HoaDon()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT HoaDon.MaHoaDon,NhanVien.TenNV,KhachHang.MaKH,TenKH,HoaDon.Ngay,TongTien FROM NhanVien join HoaDon join KhachHang on KhachHang.MaKH = HoaDon.MaKH on HoaDon.MaNV=NhanVien.MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                connection.Close();
                return table;
            }
        }
        public static DataTable Display_ChiTietHoaDon_Find(string code)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT SanPham.MaSP,TenSP,ChiTietHoaDon.SoLuongBan,SanPham.GiaBan,ChiTietHoaDon.ThanhTien FROM ChiTietHoaDon join SanPham on SanPham.MaSP=ChiTietHoaDon.MaSP where ChiTietHoaDon.MaHoaDon = '" + code+"'";
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
