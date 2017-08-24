using System.Configuration;
using System.IO;
using System.Linq;
using Codeflyers.EC.Domain.Concrete;

namespace TestingConfUtilities.Classes
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class DevUtilities
    {
        private EfDbContext efdb;
        public DevUtilities()
        {

        }

        public void DeleteTableDataAndRessedId(string tableName, string connectionString)
        {
            var sqlStatement = "DELETE FROM " + tableName + " DBCC CHECKIDENT ('" + tableName + "', RESEED, 0)";
            CreateDbContext(connectionString);
            efdb.Database.ExecuteSqlCommand(sqlStatement);
        }



        public void DeleteDataBaseDataAndReseedAllIds(string connectionString)
        {
            // I should get the DB name from connectionString and replace the hard code DB [TestingConfUtilities.DB]
            var DbName = GetDbNameFromConnectionString(connectionString);
            var sqlStatement = "USE ["+DbName+ "] EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' EXEC sp_MSForEachTable 'ALTER TABLE ? DISABLE TRIGGER ALL' EXEC sp_MSForEachTable 'DELETE FROM ?' EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL' EXEC sp_MSForEachTable 'ALTER TABLE ? ENABLE TRIGGER ALL' EXEC sp_MSForEachTable 'IF OBJECTPROPERTY(object_id(''?''), ''TableHasIdentity'') = 1 DBCC CHECKIDENT (''?'', RESEED, 0)'";
            var efdb = new EfDbContext(connectionString);
            efdb.Database.ExecuteSqlCommand(sqlStatement);

        }
        public T GetValueFromDB<T>(string connectionString, string tableName, string searchByColumn, string searchValue, string targetColumn)
        {
            var sqlStatement = "SELECT " + targetColumn + " FROM " + tableName + " WHERE " + searchByColumn + " = '" + searchValue + "'";
            var efdb = new EfDbContext(connectionString);
            var queryResult = efdb.Database.SqlQuery<T>(sqlStatement).Single();
            return queryResult;
        }

        public void ExecuteSqlScriptFile(string connectionString, string scriptPath)
        {
            FileInfo file = new FileInfo(scriptPath);
            string scriptContent = file.OpenText().ReadToEnd();
            ExecuteSqlScriptContent(connectionString, scriptContent);
        }

        public void ExecuteSqlScriptContent(string connectionString, string scriptContent)
        {
            var efdb = new EfDbContext(connectionString);
            efdb.Database.ExecuteSqlCommand(scriptContent);

        }

        private void CreateDbContext(string connectionString)
        {
            if (efdb == null)
            {
                efdb = new EfDbContext(connectionString);
            }
        }

        private string GetDbNameFromConnectionString(string connectionString)
        {
            var start = connectionString.IndexOf("Catalog=");
            var subString1 = connectionString.Substring(start + 8, connectionString.Length - start - 8);
            var end = subString1.IndexOf(";");
            var subString2 = subString1.Substring(0, end);
            return subString2;
        }
    }
}
