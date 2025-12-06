using System;
using System.Data;
using System.Data.SqlClient; // Thư viện quan trọng để kết nối SQL
using System.Linq;

namespace QuanLySinhVien.DAO
{
    public class DataProvider
    {
        // Design Pattern Singleton: Chỉ tạo duy nhất 1 instance trong suốt quá trình chạy
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        // CHUỖI KẾT NỐI (Quan trọng nhất)
        // Cách lấy: Vào SQL Server -> Connect -> Copy dòng Server Name.
        // Nếu dùng User/Pass của SQL: "Data Source=TEN_SERVER;Initial Catalog=QuanLySinhVien;User ID=sa;Password=yourPass"
        // Nếu dùng Windows Auth: "Data Source=TEN_SERVER;Initial Catalog=QuanLySinhVien;Integrated Security=True"
        private string connectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True";

        // Hàm chạy câu lệnh SELECT (Lấy dữ liệu ra dạng bảng)
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        // Hàm chạy câu lệnh INSERT, UPDATE, DELETE (Trả về số dòng thành công)
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
    }
}   