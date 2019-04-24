using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NoiThatNhuanHuong
{
    class SQL_CongNo
    {
        #region PhieuNo _ Trả nợ
        public static void Add_PhieuNo(string MaPhieuNhap, decimal TienNo, bool  TinhTrang)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO BangNo(MaPhieuNhap,TienNo,TinhTrang) VALUES (@MaPhieuNhap,@TienNo,@TinhTrang)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaPhieuNhap", MaPhieuNhap);
                command.Parameters.AddWithValue("TienNo", TienNo);
                command.Parameters.AddWithValue("TinhTrang", TinhTrang);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Add_PhieuTraNo(string STT_No,string Ngay, decimal TongTien, string NguoiTra)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO TraNo(STT_No,Ngay,TongTien,NguoiTra) VALUES (@STT_No,@Ngay,@TongTien,@NguoiTra)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("STT_No", STT_No);
                command.Parameters.AddWithValue("Ngay", Ngay);
                command.Parameters.AddWithValue("TongTien", TongTien);
                command.Parameters.AddWithValue("NguoiTra", NguoiTra);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        #endregion

        #region EDIT phiếu nợ
        public static void Edit_PhieuNo(int STT_No, bool TinhTrang)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE BangNo SET  TinhTrang= @TinhTrang WHERE STT_No = @STT_No";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("STT_No", STT_No);
                command.Parameters.AddWithValue("TinhTrang", TinhTrang);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        #endregion
        #region Display
        public static DataTable Display_PhieuNo()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT BangNo.STT_No,BangNo.MaPhieuNhap,NhapKho.NgayNhap,BangNo.TienNo,TinhTrang FROM BangNo join NhapKho on NhapKho.MaPhieuNhap=BangNo.MaPhieuNhap";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                connection.Close();
                return table;
            }
        }

        public static DataTable Display_PhieuNo_Find(string code)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT distinct BangNo.STT_No,BangNo.MaPhieuNhap,NhapKho.NgayNhap,BangNo.TienNo,TinhTrang FROM BangNo join NhapKho join ChiTietNhapKho join SanPham join NhaCungCap on NhaCungCap.MaNCC=SanPham.MaNCC on SanPham.MaSP=ChiTietNhapKho.MaSP on ChiTietNhapKho.MaPhieuNhap= NhapKho.MaPhieuNhap on NhapKho.MaPhieuNhap=BangNo.MaPhieuNhap where NhaCungCap.MaNCC ='" + code+"'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                connection.Close();
                return table;
            }
        }

        public static DataTable Display_PhieuTraNo()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT *From TraNo";
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
