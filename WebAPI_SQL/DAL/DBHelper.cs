using System;
using System.Data;
using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DBHelper
    {
        //private static string connectionString = "Data Source=F:\\GitHubBase\\Coocoo1984\\yingujiudianNetCoreSQL\\WebAPI_SQL\\DAL\\DB\\test.db";

        public static string ConnectionString { get =>
                GetConnectionString();
        }

        private static string GetConnectionString()
        {
            string result;// = "Data Source=F:\\MyGitHub\\yingujiudianNetCoreSQL\\WebAPI_SQL\\WebAPI_SQL\\DB\\test.db";
            //添加 json 文件路径
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //创建配置根对象
            var configurationRoot = builder.Build();
            var nameSection = configurationRoot.GetSection("DataBaseConnectionString");
            result = nameSection.Value;

            return result;

        }


        //连接字符串
        //private static readonly string str = ConfigurationManager.
        //private static readonly string ConnectionString = 
        //string dd = ConfigurationManager.AppSettings["constr"].ToString();

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SqliteParameter[] param)
        {
            using (SqliteConnection conn = new SqliteConnection(ConnectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    conn.Open();
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="param">参数</param>
        /// <returns>返回 首行首列</returns>
        public static object ExecuteScale(string sql, params SqliteParameter[] param)
        {
            using (SqliteConnection conn = new SqliteConnection(ConnectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    conn.Open();
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        ///多行查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns>ExecuteReader</returns>
        public static SqliteDataReader ExecueDataReader(string sql, params SqliteParameter[] param)
        {
            using (SqliteConnection conn = new SqliteConnection(ConnectionString))
            { 
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    try
                    {
                        conn.Open();
                        return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    }
                    catch (Exception ex)
                    {
                        cmd.Dispose();
                        conn.Close();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 查询多行数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数数组</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteTable(string sql, params SqliteParameter[] param)
        {
            DataTable dt = new DataTable();

            using (SqliteConnection conn = new SqliteConnection(ConnectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    conn.Open();
                    SqliteDataReader dr = cmd.ExecuteReader();
                    //动态添加表的数据列
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        DataColumn myDataColumn = new DataColumn();
                        myDataColumn.DataType = dr.GetFieldType(i);
                        myDataColumn.ColumnName = dr.GetName(i);
                        dt.Columns.Add(myDataColumn);
                    }

                    //添加表的数据
                    while (dr.Read())
                    {
                        DataRow itemDataRow = dt.NewRow();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            itemDataRow[i] = dr[i].ToString();
                        }
                        dt.Rows.Add(itemDataRow);
                        itemDataRow = null;
                    }
                    ///关闭数据读取器
                    dr.Close();
                }
            }

            return dt;
        }

        /// <summary>
        /// 查询多行数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteTable(string sql)
        {
            DataTable dt = new DataTable();

            using (SqliteConnection conn = new SqliteConnection(ConnectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    conn.Open();
                    SqliteDataReader dr = cmd.ExecuteReader();
                    //动态添加表的数据列
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        DataColumn myDataColumn = new DataColumn();
                        myDataColumn.DataType = dr.GetFieldType(i);
                        myDataColumn.ColumnName = dr.GetName(i);
                        dt.Columns.Add(myDataColumn);
                    }

                    //添加表的数据
                    while (dr.Read())
                    {
                        DataRow itemDataRow = dt.NewRow();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            itemDataRow[i] = dr.GetValue(i);
                        }
                        dt.Rows.Add(itemDataRow);
                        itemDataRow = null;
                    }
                    ///关闭数据读取器
                    dr.Close();
                }
            }

            return dt;
        }

    }

}
