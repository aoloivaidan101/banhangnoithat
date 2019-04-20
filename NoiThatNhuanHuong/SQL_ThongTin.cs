using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NoiThatNhuanHuong
{
    class SQL_ThongTin
    {
        #region Thông Tin

        #region KHách Hàng
        public static void Add_KhachHang(string SDT, string TenKH, string DiaChi, string Email)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO KhachHang(SDT,TenKH,DiaChi,Email) VALUES (@SDT,@TenKH,@DiaChi,@Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("TenKH", TenKH);
                command.Parameters.AddWithValue("SDT", SDT);
                command.Parameters.AddWithValue("DiaChi", DiaChi);
                command.Parameters.AddWithValue("Email", Email);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Edit__KhachHang(string MaKH, string SDT, string TenKH, string DiaChi, string Email)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE KhachHang SET  MaKH=@MaKH, SDT=@SDT, TenKH=@TenKH, DiaChi=@DiaChi, Email=@Email  WHERE MaKH = @MaKH";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaKH", MaKH);
                command.Parameters.AddWithValue("TenKH", TenKH);
                command.Parameters.AddWithValue("SDT", SDT);
                command.Parameters.AddWithValue("DiaChi", DiaChi);
                command.Parameters.AddWithValue("Email", Email);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Delete_KhachHang(string MaKH)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaKH", MaKH);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static DataTable Display_KhachHang()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT * FROM KhachHang ";
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

        #region Nhà Cung Cấp
        public static void Add_NCC(string MaNCC, string SDTNCC, string TenNCC, string DiaChi, string Email)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO NhaCungCap VALUES (@MaNCC,@SDTNCC,@TenNCC,@DiaChi,@Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNCC", MaNCC);
                command.Parameters.AddWithValue("TenNCC", TenNCC);
                command.Parameters.AddWithValue("SDTNCC", SDTNCC);
                command.Parameters.AddWithValue("DiaChi", DiaChi);
                command.Parameters.AddWithValue("Email", Email);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Edit__NCC(string MaNCC, string SDTNCC, string TenNCC, string DiaChi, string Email)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE NhaCungCap SET  MaNCC=@MaNCC, SDTNCC=@SDTNCC, TenNCC=@TenNCC, DiaChi=@DiaChi, Email=@Email  WHERE MaNCC = @MaNCC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNCC", MaNCC);
                command.Parameters.AddWithValue("TenNCC", TenNCC);
                command.Parameters.AddWithValue("SDTNCC", SDTNCC);
                command.Parameters.AddWithValue("DiaChi", DiaChi);
                command.Parameters.AddWithValue("Email", Email);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Delete_NCC(string MaNCC)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNCC", MaNCC);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static DataTable Display_NCC()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT *FROM NhaCungCap ";
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

        #region Nhân Viên
        public static void Add_NhanVien(string MaNV, string TenNV, string MaCV, string GioiTinh, string NgaySinh, string SDTNV, string DiaChi, string Email)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO NhanVien VALUES (@MaNV,@TenNV,@MaCV,@GioiTinh,@NgaySinh,@SDTNV,@DiaChi,@Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNV", MaNV);
                command.Parameters.AddWithValue("TenNV", TenNV);
                command.Parameters.AddWithValue("MaCV", MaCV);
                command.Parameters.AddWithValue("GioiTinh", GioiTinh);
                command.Parameters.AddWithValue("NgaySinh", NgaySinh);
                command.Parameters.AddWithValue("SDTNV", SDTNV);
                command.Parameters.AddWithValue("DiaChi", DiaChi);
                command.Parameters.AddWithValue("Email", Email);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Edit__NhanVien(string MaNV, string TenNV, string MaCV, string GioiTinh, string NgaySinh, string SDTNV, string DiaChi, string Email)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE NhanVien SET  MaNV=@MaNV, TenNV=@TenNV, MaCV=@MaCV, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, SDTNV=@SDTNV, DiaChi=@DiaChi, Email=@Email  WHERE MaNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNV", MaNV);
                command.Parameters.AddWithValue("TenNV", TenNV);
                command.Parameters.AddWithValue("MaCV", MaCV);
                command.Parameters.AddWithValue("GioiTinh", GioiTinh);
                command.Parameters.AddWithValue("NgaySinh", NgaySinh);
                command.Parameters.AddWithValue("SDTNV", SDTNV);
                command.Parameters.AddWithValue("DiaChi", DiaChi);
                command.Parameters.AddWithValue("Email", Email);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Delete_NhanVien(string MaNV)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaNV", MaNV);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static DataTable Display_NhanVien()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT NhanVien.MaNV,TenNV, ChucVu.TenCV , case NhanVien.GioiTinh when 1 then N'Nam' when 0 then N'Nữ' end as 'GioiTinh', NhanVien.NgaySinh, NhanVien.SDTNV ,NhanVien.Email, NhanVien.DiaChi FROM NhanVien join ChucVu on ChucVu.MaCV = NhanVien.MaCV ";
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

        #region Sản Phẩm
        public static void Add_SanPham(string MaSP, string TenSP, string MaLoaiSP, string MaNCC, decimal GiaNhap, decimal GiaBan, int SoLuong, string MoTa)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "INSERT INTO SanPham VALUES (@MaNCC,@TenSP,@MaLoaiSP,@MaNCC,@GiaNhap,@GiaBan,@SoLuong,@MoTa)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaSP", MaSP);
                command.Parameters.AddWithValue("TenSP", TenSP);
                command.Parameters.AddWithValue("MaLoaiSP", MaLoaiSP);
                command.Parameters.AddWithValue("MaNCC", MaNCC);
                command.Parameters.AddWithValue("GiaNhap", GiaNhap);
                command.Parameters.AddWithValue("GiaBan", GiaBan);
                command.Parameters.AddWithValue("SoLuong", SoLuong);
                command.Parameters.AddWithValue("MoTa", MoTa);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Edit_SanPham(string MaSP, string TenSP, string MaLoaiSP, string MaNCC, decimal GiaNhap, decimal GiaBan, string MoTa)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "UPDATE SanPham SET  MaSP=@MaSP, TenSP=@TenSP, MaLoaiSP=@MaLoaiSP, MaNCC=@MaNCC, GiaNhap=@GiaNhap, GiaBan=@GiaBan, MoTa=@MoTa  WHERE MaSP = @MaSP";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaSP", MaSP);
                command.Parameters.AddWithValue("TenSP", TenSP);
                command.Parameters.AddWithValue("MaLoaiSP", MaLoaiSP);
                command.Parameters.AddWithValue("MaNCC", MaNCC);
                command.Parameters.AddWithValue("GiaNhap", GiaNhap);
                command.Parameters.AddWithValue("GiaBan", GiaBan);
                command.Parameters.AddWithValue("MoTa", MoTa);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void Delete_SanPham(string MaSP)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("MaSP", MaSP);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static DataTable Display_SanPham()
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT SanPham.MaSP as N'Mã Sản Phẩm', SanPham.TenSP as N'Tên Sản Phẩm', LoaiSP.TenLoaiSP as N'Loại Sản Phẩm', NhaCungCap.TenNCC as N'Nhà Cung Cấp', SanPham.GiaNhap as N'Giá Nhập', SanPham.GiaBan as N'Giá Bán', SanPham.SoLuong as N'Số Lượng',SanPham.MoTa as N'Mô Tả' FROM NhaCungCap  join SanPham join LoaiSP on LoaiSP.MaLoaiSP = SanPham.MaLoaiSP on SanPham.MaNCC = NhaCungCap.MaNCC ";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                connection.Close();
                return table;
            }
        }

        public static DataTable Display_SanPham_Find(string code)
        {
            using (SqlConnection connection = new SqlConnection(SQL_Connection._SQL))
            {
                connection.Open();
                string query = "SELECT SanPham.MaSP as N'Mã Sản Phẩm', SanPham.TenSP as N'Tên Sản Phẩm', LoaiSP.TenLoaiSP as N'Loại Sản Phẩm', NhaCungCap.TenNCC as N'Nhà Cung Cấp', SanPham.GiaNhap as N'Giá Nhập', SanPham.GiaBan as N'Giá Bán', SanPham.SoLuong as N'Số Lượng',SanPham.MoTa as N'Mô Tả' FROM NhaCungCap  join SanPham join LoaiSP on LoaiSP.MaLoaiSP = SanPham.MaLoaiSP on SanPham.MaNCC = NhaCungCap.MaNCC where NhaCungCap.MaNCC = '" + code + "'" ;
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
