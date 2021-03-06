﻿using CollectionManagement.BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.DataAccessLayer
{
    public class DBHelper : IDisposable
    {
#if DEBUG
        private static string defaultConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
#else
        private static string defaultConnectionString = "";
#endif

        private static SqlConnection _connection = null;
        public DBHelper()
        {
            _connection = new SqlConnection(defaultConnectionString);
        }

        public DataTable ExecuteProcedure(DBHelperModel dbHelperModel)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(dbHelperModel.StoredProcedureName, _connection))
                {
                    _connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 600;

                    if (dbHelperModel.StoreProcedureParameters != null && dbHelperModel.StoreProcedureParameters.Count() > 0)
                    {
                        foreach (var parameterItem in dbHelperModel.StoreProcedureParameters)
                        {
                            command.Parameters.Add(new SqlParameter { ParameterName = parameterItem.Key, Value = parameterItem.Value });
                        }
                    }
                    SqlDataReader results = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(results);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection != null)
                    _connection.Close();
            }
        }

        private static DataTable Query(String consulta, IList<SqlParameter> parametros)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(defaultConnectionString);
                SqlCommand command = new SqlCommand();
                SqlDataAdapter da;
                try
                {
                    command.Connection = connection;
                    command.CommandText = consulta;
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros.ToArray());
                    }
                    da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int ExecuteNonQuery(DBHelperModel dbHelperModel, out string transactionId)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(dbHelperModel.StoredProcedureName, _connection))
                {
                    _connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 600;

                    if (dbHelperModel.StoreProcedureParameters != null && dbHelperModel.StoreProcedureParameters.Count() > 0)
                    {
                        foreach (var parameterItem in dbHelperModel.StoreProcedureParameters)
                        {
                            command.Parameters.Add(new SqlParameter { ParameterName = parameterItem.Key, Value = parameterItem.Value });
                        }
                    }
                    if (dbHelperModel.SqlParameter != null)
                    {
                        command.Parameters.Add(dbHelperModel.SqlParameter);
                        command.Parameters.Add("@OutTransactionId", SqlDbType.Char, 500);
                        command.Parameters["@OutTransactionId"].Direction = ParameterDirection.Output;
                    }
                    var result = command.ExecuteNonQuery();
                    if (dbHelperModel.SqlParameter != null)
                    {
                        transactionId = (string)command.Parameters["@OutTransactionId"].Value;
                    }
                    else transactionId = "0";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection != null)
                    _connection.Close();
            }
        }

        #region IDisposable implementation 

        /// <summary>
        /// overide Dispose method
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
                _connection.Close();
        }

        #endregion IDisposable implementation
    }
}
