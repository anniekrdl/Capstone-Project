using System.Data.Common;
using MySqlConnector;

namespace OnlineWebshop
{
    public interface IDatabaseService
    {

        /// <summary>
        /// Returns a MySQL connection.
        /// </summary>
        /// <returns>An instance of  <see cref="MySqlConnection"/>.</returns>
        MySqlConnection GetConnection();
    }
}
