using System.Data;
using MySql.Data.MySqlClient;

namespace QlyNhaHang.DAL
{
    public class ThongKeDAL
    {
        public DataTable GetDoanhThuTheoNgay()
        {
            using (MySqlConnection conn = DataAccess.GetConnection())
            {
                string query = @"
                    SELECT DATE(NgayLap) AS Ngay,
                           SUM(ThanhToan) AS DoanhThu
                    FROM HoaDon
                    WHERE TrangThai = 'DaThanhToan'
                    GROUP BY DATE(NgayLap)
                    ORDER BY Ngay DESC";

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetMonBanChay()
        {
            using (MySqlConnection conn = DataAccess.GetConnection())
            {
                string query = @"
                    SELECT m.TenMon,
                           SUM(ct.SoLuong) AS TongBan
                    FROM ChiTietHoaDon ct
                    INNER JOIN MonAn m ON ct.MaMon = m.MaMon
                    GROUP BY m.TenMon
                    ORDER BY TongBan DESC";

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
