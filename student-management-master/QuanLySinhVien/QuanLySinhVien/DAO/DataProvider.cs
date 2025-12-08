using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLySinhVien.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        // [QUAN TRỌNG] Chuỗi kết nối dùng Windows Authentication (Integrated Security=True)
        // Lưu ý: Nếu máy bạn tên SQL không phải là .\SQLHOC thì đổi thành .\SQLEXPRESS hoặc dấu chấm (.)
        private string connectionSTR = @"Data Source=.\SQLHOC;Initial Catalog=QuanLySinhVien;Integrated Security=True;Encrypt=False";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameters(query, parameter, command); // Gọi hàm phụ trợ
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameters(query, parameter, command);
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameters(query, parameter, command);
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

        // Hàm phụ tách riêng để code gọn hơn
        private void AddParameters(string query, object[] parameter, SqlCommand command)
        {
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
        }
    }
}