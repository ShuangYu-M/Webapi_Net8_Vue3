using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using webApi_Net8.request;
using webApi_Net8.response;

namespace webApi_Net8.Helper
{
    public static class SqlHelper
    {
        static SqlHelper() { }

        private static string _connectionString = "Server=10.0.0.10;Database=Dome2;User Id=G105988;Password=G105988;";

        // 用于获取数据库连接
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening connection: " + ex.Message);
            }
            return connection;
        }

        // 用于执行查询
        public static DataTable Query(string query)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }


        /// <summary>
        /// datatable转换list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> Query<T>(string sql)
        {
            DataTable dt = Query(sql);
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                var obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (prop.IsDefined(typeof(ColumnNameAttribute), false))
                    {
                        ColumnNameAttribute attr = prop.GetCustomAttribute<ColumnNameAttribute>();
                        if (attr != null)
                        {
                            DataColumn column = dt.Columns[attr.ColumnName];
                            if (column != null && row[column] != DBNull.Value)
                            {
                                prop.SetValue(obj, Convert.ChangeType(row[column], prop.PropertyType));
                            }
                            else
                            {
                                // 如果DataTable中没有对应的列，或者列值为DBNull，则设置默认值
                                if (prop.PropertyType == typeof(int))
                                {
                                    prop.SetValue(obj, 0); // 为int类型设置默认值0
                                }
                                else if (prop.PropertyType == typeof(string))
                                {
                                    prop.SetValue(obj, null); // 为string类型设置默认值null
                                }
                                // 可以根据需要添加其他类型的默认值处理
                            }
                        }
                    }
                }
                data.Add(obj);
            }
            return data;
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class ColumnNameAttribute : Attribute
        {
            public string ColumnName { get; }

            public ColumnNameAttribute(string columnName)
            {
                ColumnName = columnName;
            }
        }




        // 用于执行非查询操作（如插入、更新、删除），并返回受影响的行数
        public static int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                return command.ExecuteNonQuery();
            }
        }

        // 静态方法，用于关闭数据库连接
        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }





    }
}
