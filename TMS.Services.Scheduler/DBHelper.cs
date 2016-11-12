using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using Dapper;


namespace TMS.Utilities
{
    public static class DBHelper
    {

        public static string Connection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            }
        }
        public static IDbConnection ConnectionString
        {
            get
            {

                return new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">Destination database tablename</param>
        /// <param name="con">Connection String</param>
        /// <param name="data">datatble that has to be inserted</param>
        /// <param name="truncateexistingdata">Pass true if the data in the destination table has to be truncated</param>
        /// <param name="mappings">Column mappings from source to destination tables</param>
        /// <returns>Bulk copies the datatable in to a database table and returns status</returns>
        public static bool DoBulkCopy(string tableName, string con, DataTable data, bool truncateexistingdata, SqlBulkCopyColumnMapping[] mappings)
        {
            try
            {
                using (var sbc = new SqlBulkCopy(con))
                {
                    if (mappings != null)
                    {
                        foreach (var map in mappings)
                        {
                            sbc.ColumnMappings.Add(map);
                        }
                    }
                    if (truncateexistingdata)
                    {
                        ExecuteNonQuery(con, "truncate table " + tableName, null, CommandType.Text);
                    }
                    sbc.DestinationTableName = tableName;
                    sbc.WriteToServer(data);
                }

                return true;
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                return false;
            }
        }

        private static void ProcessException(Exception ex)
        {
            Console.WriteLine(ex.InnerException.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="con">the connection string</param>
        /// <param name="sql">the sql statement</param>
        /// <param name="param">paremeters</param>
        /// <returns>Executes the select statements on the database and return datatable</returns>
        public static DataTable Execute(string con, string sql, List<SqlParameter> param)
        {
            try
            {
                using (var conn = new SqlConnection(con))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        AddParams(cmd, param);
                        var da = new SqlDataAdapter { SelectCommand = cmd };
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                return null;
            }
        }

        public static DataTable Execute(string con, string sql, SqlParameter[] param)
        {
            return Execute(con, sql, param.ToList());
        }
        private static void AddParams(SqlCommand cmd, SqlParameter[] param)
        {
            if (param == null) return;
            foreach (var p in param)
            {
                cmd.Parameters.Add(p);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sql">the sql statement</param>
        /// <param name="param">paremeters</param>
        /// <returns>Executes the select statements on the database and return datatable</returns>
        public static IEnumerable<T> Execute<T>(string sql, object param)
        {
            try
            {
                using (var conn = new SqlConnection(Connection))
                {
                    conn.Open();
                    var obj = conn.Query<T>(sql, param, commandType: CommandType.StoredProcedure);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static IEnumerable<T> ExecuteNonSp<T>(string sql, object param)
        {
            try
            {
                using (var conn = new SqlConnection(Connection))
                {
                    conn.Open();
                    var obj = conn.Query<T>(sql, param);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="con">the connection string</param>
        /// <param name="sql">the sql statement</param>
        /// <param name="param">paremeters</param>
        /// <returns>Executes the select statements on the database and return datatable</returns>
        public static IEnumerable<T> Execute<T>(string con, string sql, object param)
        {
            try
            {
                using (var conn = new SqlConnection(con))
                {
                    conn.Open();
                    var obj = conn.Query<T>(sql, param);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                return null;
            }
        }

        private static void AddParams(SqlCommand cmd, List<SqlParameter> param)
        {
            cmd.Parameters.Clear();
            if (param == null) return;
            foreach (var p in param)
            {
                cmd.Parameters.Add(p);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="con">the connection string</param>
        /// <param name="sql">the sql statement</param>
        /// <param name="param">paremeters</param>
        /// <param name="commandType">Conmmand type either text(for query) or procedure</param>
        /// <returns>Executes non queries and return status</returns>
        public static int ExecuteNonQuery(string con, string sql, List<SqlParameter> param, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                using (var conn = new SqlConnection(con))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.CommandType = commandType;
                        AddParams(cmd, param);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                return -100;
            }
        }


        public static string ExecuteQueryReturnIdentity(string con, string sql, List<SqlParameter> param)
        {
            try
            {
                string strReturnValue;
                using (var conn = new SqlConnection(con))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.StoredProcedure;
                        AddParams(cmd, param);
                        strReturnValue = cmd.ExecuteScalar().ToString();
                    }
                }
                return strReturnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ExecuteQueryReturnIdentityNonSP(string con, string sql, List<SqlParameter> param)
        {
            var strReturnValue = string.Empty;
            try
            {
                using (var conn = new SqlConnection(con))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandText = sql + ";select @@IDENTITY";
                        AddParams(cmd, param);
                        //TODO: check for null
                        strReturnValue = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new DatabaseException(ex, sql, param);
            }

            return strReturnValue;
        }

        public static object ExecuteScalar(string ConnectionString, string sqlCommand, List<SqlParameter> sqlParameter, bool isStoreProcedure = false)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandText = sqlCommand;
                        if (isStoreProcedure)
                            cmd.CommandType = CommandType.StoredProcedure;
                        AddParams(cmd, sqlParameter);
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                return 9999999;
            }
        }
    }
}
