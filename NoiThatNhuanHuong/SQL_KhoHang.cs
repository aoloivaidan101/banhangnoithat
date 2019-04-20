using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace NoiThatNhuanHuong
{
    class SQL_KhoHang
    {
        #region     Kho Hàng
        public static DataTable Display_HangTon()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT SanPham.MaSP,TenSP,SoLuong FROM SanPham";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                connection.Close();
                return table;
            }
        }

        public static DataTable Display_PhieuNhapKho()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT * FROM NhapKho";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                connection.Close();
                return table;
            }
        }

        public static DataTable Display_ChiTietNhapKho_Find(string code)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT ChiTietNhapKho.MaChitietNhapKho,MaPhieuNhap,SanPham.TenSP,ChiTietNhapKho.SoLuongNhap,SanPham.GiaBan,ChiTietNhapKho.ThanhTien FROM ChiTietNhapKho join SanPham on SanPham.MaSP=ChiTietNhapKho.MaSP where ChiTietNhapKho.MaPhieuNhap ='"+code+"'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                connection.Close();
                return table;
            }
        }
        public static DataTable Display_Find_NCC_of_NhapKho(string code)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "select NhaCungCap.TenNCC,DiaChi from NhaCungCap join SanPham join ChiTietNhapKho join NhapKho on NhapKho.MaPhieuNhap= ChiTietNhapKho.MaPhieuNhap on ChiTietNhapKho.MaSP = SanPham.MaSP on SanPham.MaNCC = NhaCungCap.MaNCC where NhapKho.MaPhieuNhap='" +code+"'";
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

        #region Phiếu Nhập 

        public static void Add_PhieuNhapHang(string MaNV, string NgayNhap, decimal TongTien, decimal DaThanhToan)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "insert into NhapKho(MaNV,NgayNhap,TongTien,DaThanhToan) values (@MaNV,@NgayNhap,@TongTien,@DaThanhToan)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNV", MaNV);
                command.Parameters.AddWithValue("NgayNhap", NgayNhap);
                command.Parameters.AddWithValue("TongTien", TongTien);
                command.Parameters.AddWithValue("DaThanhToan", DaThanhToan);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Add_ChiTietNhapHang(string MaPhieuNhap, string MaSP, int SoLuongNhap, decimal ThanhTien)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "insert into ChiTietNhapKho(MaPhieuNhap,MaSP,SoLuongNhap,ThanhTien) values (@MaPhieuNhap,@MaSP,@SoLuongNhap,@ThanhTien)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaPhieuNhap", MaPhieuNhap);
                command.Parameters.AddWithValue("MaSP", MaSP);
                command.Parameters.AddWithValue("SoLuongNhap", SoLuongNhap);
                command.Parameters.AddWithValue("ThanhTien", ThanhTien);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Delete_PhieuNhapHang(string MaPhieuNhap)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM NhapKho WHERE NhapKho.MaPhieuNhap = @MaPhieuNhap";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaPhieuNhap", MaPhieuNhap);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        #endregion
    }
}
