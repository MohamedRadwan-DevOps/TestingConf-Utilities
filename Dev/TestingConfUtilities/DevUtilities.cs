using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

using Microsoft.SqlServer.Server;
using System.Configuration;

namespace TestingConfUtilities
{
    /// <summary>
    /// This class use methods to help developer doing tasks not related to the business actions but for configuration or preparation purpose for automate the developer task that needed
    /// </summary>
    public class DevUtilities
    {
        /// <summary>
        /// This method will delete all data in the database and reseed the Ids for selected table, you can use this method to restate a table before inserting test data in the table so you just return the table to the original state
        /// </summary>
        /// <param name="tableName">
        /// The table name that will be deleted and reseed.
        /// </param>
        public void DeleteTableDataAndRessedId(string tableName, string connectionString)
        {
            string sqlStatement = "delete from " + tableName + " DBCC CHECKIDENT ('" + tableName + "', RESEED, 0)";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, sqlConnection);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        /// <summary>
        /// This method will delete all data in the database and reseed all tables that have identity, remember this method swallows exception occur when it try to reseed table that doesn't has identity 
        /// </summary>
        /// <param name="connStrinInConfig">
        /// The connection string variable in the app.cofnig or the web.config, so you must review the web.config or app.config to make sure you send existing one.
        /// </param>
        [Obsolete("Please use the other method with the same name")]
        public void DeleteDataBaseDataAndReseedAllIds(SqlConnection sqlConnection)
        {
            SqlCommand cmd1 = new SqlCommand("sp_MSForEachTable", sqlConnection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@command1", SqlDbType.VarChar)).Value = "ALTER TABLE ? NOCHECK CONSTRAINT ALL";

            SqlCommand cmd2 = new SqlCommand("sp_MSForEachTable", sqlConnection);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@command1", SqlDbType.VarChar)).Value = "ALTER TABLE ? DISABLE TRIGGER ALL";

            SqlCommand cmd3 = new SqlCommand("sp_MSForEachTable", sqlConnection);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add(new SqlParameter("@command1", SqlDbType.VarChar)).Value = "DELETE FROM ?";

            SqlCommand cmd4 = new SqlCommand("sp_MSForEachTable", sqlConnection);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.Add(new SqlParameter("@command1", SqlDbType.VarChar)).Value = "ALTER TABLE ? CHECK CONSTRAINT ALL";
            SqlCommand cmd5 = new SqlCommand("sp_MSForEachTable", sqlConnection);
            cmd5.CommandType = CommandType.StoredProcedure;
            cmd5.Parameters.Add(new SqlParameter("@command1", SqlDbType.VarChar)).Value = "ALTER TABLE ? ENABLE TRIGGER ALL";
            SqlCommand cmd6 = new SqlCommand("sp_MSFOREACHTABLE", sqlConnection);
            cmd6.CommandType = CommandType.StoredProcedure;
            cmd6.Parameters.Add(new SqlParameter("@command1", SqlDbType.VarChar)).Value = "SELECT * FROM ?";

            sqlConnection.Open();

            try
            {


                //cmd1.Transaction = sqlTransaction;
                cmd1.ExecuteNonQuery();

                //cmd2.Transaction = sqlTransaction;
                cmd2.ExecuteNonQuery();

                //cmd3.Transaction = sqlTransaction;
                cmd3.ExecuteNonQuery();

                //cmd4.Transaction = sqlTransaction;
                cmd4.ExecuteNonQuery();

                //cmd5.Transaction = sqlTransaction;
                cmd5.ExecuteNonQuery();

                //cmd6.Transaction = sqlTransaction;
                cmd6.ExecuteNonQuery();
                //sqlTransaction.Commit();




            }
            catch (System.Exception exception)
            {
                //sqlTransaction.Rollback();

            }


            //connection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlCommand cmd7 = new SqlCommand("sp_MSForEachTable", sqlConnection);
                cmd7.CommandType = CommandType.StoredProcedure;
                //cmd7.Parameters.Add(new SqlParameter("@command1", SqlDbType.VarChar)).Value = "DBCC CHECKIDENT ('?', reseed, 0)";
                cmd7.Parameters.Add(new SqlParameter("@command1", SqlDbType.VarChar)).Value = "IF OBJECTPROPERTY(object_id(''?''), ''TableHasIdentity'') = 1 DBCC CHECKIDENT (''?'', RESEED, 0)";


                cmd7.Transaction = sqlTransaction;
                //connection.BeginTransaction();
                cmd7.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch (Exception e)
            {

            }
            finally
            {
                sqlConnection.Close();
            }

        }
        public void DeleteDataBaseDataAndReseedAllIds(string connectionString)
        {
            string script = "USE [ALM] EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' EXEC sp_MSForEachTable 'ALTER TABLE ? DISABLE TRIGGER ALL' EXEC sp_MSForEachTable 'DELETE FROM ?' EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL' EXEC sp_MSForEachTable 'ALTER TABLE ? ENABLE TRIGGER ALL' EXEC sp_MSForEachTable 'IF OBJECTPROPERTY(object_id(''?''), ''TableHasIdentity'') = 1 DBCC CHECKIDENT (''?'', RESEED, 0)'";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(sqlConnection));
            if (RuntimePolicyHelper.LegacyV2RuntimeEnabledSuccessfully)
            {
                server.ConnectionContext.ExecuteNonQuery(script);
            }
            else
            {
                throw new Exception("Could not load SMO");
            }
        }

        /// <summary>
        /// This method will return a scalar value from any table with any where condition, we can use this method to check for specific value in the DB
        /// so this method will very helpful in the testing scenario when we want to make sure that our CRUD was success
        /// </summary>
        /// <param name="connectionString">
        /// The connection string of the target DB.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="searchByColumn">
        /// The search by column that will be used in the where clause.
        /// </param>
        /// <param name="searchValue">
        /// The value that will be used in the where clause after the = operator, remember to put single quotes around the value if the value is string for example 'Seif'
        /// </param>
        /// <param name="targetColumn">
        /// The name of column that you want to get it's value.
        /// </param>
        /// <returns>
        /// </returns>
        public string GetValueFromDB(string connectionString, string tableName, string searchByColumn, string searchValue, string targetColumn)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlscript = "select " + targetColumn + " from " + tableName + " where " + searchByColumn + " = " + searchValue;
            SqlCommand cmd1 = new SqlCommand(sqlscript, sqlConnection);
            sqlConnection.Open();
            string targetValue = cmd1.ExecuteScalar().ToString();
            sqlConnection.Close();
            return targetValue;

        }
        public void ExecuteSqlScriptFile(string connectionString, string scriptPath)
        {
            FileInfo file = new FileInfo(scriptPath);
            string scriptContent = file.OpenText().ReadToEnd();
            ExecuteSqlScriptContent(connectionString, scriptContent);
        }

        public void ExecuteSqlScriptContent(string connectionString, string scriptContent)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(sqlConnection));
            if (RuntimePolicyHelper.LegacyV2RuntimeEnabledSuccessfully)
            {
                server.ConnectionContext.ExecuteNonQuery(scriptContent);
            }
            else
            {
                throw new Exception("Could not load SMO");
            }
        }

        public SqlConnection CreateSqlConnectionFromConfig(string connectionStringConfigName)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringConfigName].ConnectionString);
        }
        public string GetConnectionStringFromConfig(string connectionStringConfigName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringConfigName].ConnectionString;
        }
    }
}
