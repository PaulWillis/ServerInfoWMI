using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DAL
    {

        private string _connectionString;
         
        public DAL(string connectionString)
        {
            _connectionString = connectionString; 
        }
         
        public Utils.OperationResult TestSqlServerConnectionString()
        {
            Utils.OperationResult opres = new Utils.OperationResult();
            opres.Success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        opres.Success = true;
                    }

                }
            }
            catch (System.Exception ex)
            {
                opres.AddMessage(ex.Message);
            }
            return opres;


        }


        public bool InsertIntoDB(string query)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    result = true;
                }

            }
            catch (Exception ex)
            {
                var dt = new DataTable
                {
                    Columns = { { "Message", typeof(string) } }
                };
                if (ex.Message.ToUpper().Contains("LOGIN FAILED FOR"))
                {
                    dt.Rows.Add("THE LOGIN FAILED");
                }
                else
                {
                    throw;
                }
            }
            return result;
        }


        public DataTable GetDataTable(string query)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }





        /// <summary>
        /// loads any type , may need to add some extra if conditions
        /// <example>var result = LoadRecords<TicketHeader>(sqlstmnt);</example>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SqlStmt"></param>
        /// <returns></returns>
        public IQueryable<T> LoadRecords<T>(string SqlStmt, CommandType CommandTypeText)
        {
            List<T> MethodResult = new List<T>();
            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandTypeText;
                    cmd.CommandText = SqlStmt;
                    cmd.CommandTimeout = 30000;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        T _obj = (T)Activator.CreateInstance(typeof(T));
                        foreach (PropertyInfo prop in typeof(T).GetProperties())
                        {

                            if (prop.ToString().ToUpper().Contains("INT32") || prop.ToString().ToUpper().Contains("DECIMAL"))
                            {
                                prop.SetValue(_obj, reader.GetValue(reader.GetOrdinal(prop.Name)), null);
                            }
                            else
                            {
                                try
                                {
                                    prop.SetValue(_obj, reader.GetValue(reader.GetOrdinal(prop.Name)).ToString().Trim(), null);
                                }
                                catch (IndexOutOfRangeException ex)
                                {
                                    prop.SetValue(_obj, "", null);

                                }
                                catch (System.Exception ex1)
                                {
                                    throw;
                                }
                            }
                        }
                        MethodResult.Add(_obj);
                    }
                    reader.Close();
                }
            }
            return MethodResult.AsQueryable();

        }


    }
}
