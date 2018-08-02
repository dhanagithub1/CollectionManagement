using CollectionManagement.BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.DataAccessLayer
{
    public class DBHelper
    {
#if DEBUG
        private static string defaultConnectionString = "Data Source=localhost;Initial Catalog=GLOBOBH_MapaAntenas;Integrated Security=SSPI";
#else
        private static string defaultConnectionString = "";
#endif
       
        private static SqlConnection _connection = null;
        public DBHelper()
        {
            _connection = new SqlConnection(defaultConnectionString);
        }

        public DataSet ExecuteProcedure(DBHelperModel dbHelperModel)
        {
            try
            {
                var results = new DataSet();
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
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(results);

                    return results;
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
    }
}
