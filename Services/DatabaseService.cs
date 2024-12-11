using System.Data.Common;
using MySqlConnector;

namespace OnlineWebshop
{

    public class DatabaseService
    {

        private MySqlConnectionStringBuilder mySqlBuilder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "Delcroktam6",
            Database = "capstoneproject",
        };

        //protected: bruikbaar in parent en child class. Private alleen in huidige (parent) class.
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(mySqlBuilder.ConnectionString);

        }

    }

}
