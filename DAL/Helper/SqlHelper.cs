using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace DAL.Helper
{
    /// <summary>
    /// The SqlHelper class is intended to encapsulate high performance, scalable best practices for 
    /// common uses of SqlClient.
    /// </summary>
    public class SqlHelper
    {
        #region private utility methods & constructors

        //Since this class provides only static methods, make the default constructor private to prevent 
        //instances from being created with "new SqlHelper()".
        private SqlHelper() { }

        private static void AttachParameters(SqlCommand command, IList<SqlParameter> commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                //check for derived output value with no value assigned
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }

                command.Parameters.Add(p);
            }
        }
        
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, IList<SqlParameter> commandParameters)
        {
            //if the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            //associate the connection with the command
            command.Connection = connection;

            //set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            //if we were provided a transaction, assign it.
            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            //set the command type
            command.CommandType = commandType;

            //attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }

        #endregion private utility methods & constructors

        #region ExecuteNonQuery

        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, IList<SqlParameter> commandParameters)
        {
            //create & open a SqlConnection, and dispose of it after we are done.
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                //call the overload that takes a connection in place of the connection string
                int IntID = ExecuteNonQuery(cn, commandType, commandText, commandParameters);

                cn.Close();
                cn.Dispose();
                return IntID;
            }
        }
        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, IList<SqlParameter> commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters);

            //finally, execute the command.
            int retval = cmd.ExecuteNonQuery();

            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }
        
        #endregion ExecuteNonQuery

        #region ExecuteTable

        public static DataTable ExecuteTable(string connString, CommandType cmdType, string cmdText, IList<SqlParameter> cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    //SqlConnection conn = new SqlConnection(connString);
                    SqlDataAdapter oDataAdapter = new SqlDataAdapter();
                    DataTable oDataTable = new DataTable();


                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    oDataAdapter.SelectCommand = cmd;
                    oDataAdapter.Fill(oDataTable);
                    cmd.Parameters.Clear();
                    return oDataTable;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception exx)
                {
                    throw exx;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();

                }
            }
        }

        #endregion

        #region ExecuteRow

        public static DataRow ExecuteRow(string connString, CommandType cmdType, string cmdText, IList<SqlParameter> cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter oDataAdapter = new SqlDataAdapter();

            DataTable oDataTable = new DataTable();
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                oDataAdapter.SelectCommand = cmd;
                oDataAdapter.Fill(oDataTable);
                cmd.Parameters.Clear();
                if (oDataTable.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    DataRow oRow = oDataTable.Rows[0];
                    return oRow;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                oDataTable = null;
                cmd = null;
                oDataAdapter = null;
            }
        }

        #endregion
    }
}
