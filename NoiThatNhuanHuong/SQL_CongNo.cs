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
        #region PhieuNo
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
        #endregion
    }
}
