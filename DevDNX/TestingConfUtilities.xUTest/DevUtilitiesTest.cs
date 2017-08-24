using TestingConfUtilities.Classes;
using Xunit;

namespace TestingConfUtilities.xUTest
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class DevUtilitiesTest
    {
        private string _connectionString;
        public DevUtilitiesTest()
        {
            _connectionString = "Data Source=.;Initial Catalog=TestingConfUtilities.DB;Integrated Security=SSPI;";
        }

        [Fact]
        public void DeleteTableDataAndRessedI()
        {
            var testingUtilities = new DevUtilities();
            testingUtilities.DeleteTableDataAndRessedId("Products",_connectionString );



        }
        [Fact]
        public void DeleteDataBaseDataAndReseedAllIds()
        {
            var testingUtilities = new DevUtilities();
            testingUtilities.DeleteDataBaseDataAndReseedAllIds(_connectionString);
        }

        [Fact]
        public void GetValueFromDB()
        {
            var testingUtilities = new DevUtilities();
            testingUtilities.GetValueFromDB<decimal>(_connectionString,"Products","Name","Laptop","Price");
        }

        //Thsi method will fail as DX don't support get connections tring from config.json yet
        [Fact]
        public void GetConnectionString()
        {
            var testingUtilities = new DevUtilities();
        }
    }
}
