using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;

namespace IntegrationComponent
{
    class DbClient
    {
        private string connectionsString { get; } =
            "Server=dbs-oa-dk2.database.windows.net;Database=db-oa-dk2; Initial Catalog=db-oa-dk2; User Id=admin-oa-dk2;Password=oceanicFlyAway16;";

        public string GetPlaneMap()
        {
            String cmdString = "SELECT [Id],[TANGER],[DEKANARISKEOEER],[TUNIS],[CAIRO],[MARRAKESH],[TRIPOLI],[SAHARA],[DAKAR],[TIMBUKTU],[WADAI],[OMDURMAN],[SUAKIN],[SIERRALEONE],[GULDKYSTEN],[SLAVEKYSTEN],[DARFUR],[BAHRELGHAZAL],[ADDISABEBA],[VICTORIASOEEN],[KAPGUARAFUI],[CONGO],[KABALO],[ZANZIBAR],[STHELENA],[LUANDA],[VICTORIAFALDENE],[MOCAMBIQUE],[AMATAVE],[HVALBUGTEN],[DRAGEBJERGET],[KAPSTMARIE],[KAPSTADEN]  FROM [dbo].[PlaneMap]";

            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                SqlCommand command = new SqlCommand(cmdString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.GetString(0);
            }
        }

        public string GetPrices()
        {
            String cmdString = "SELECT [Id],[PriceValue],[MinSize],[MaxSize],[MinWeight],[MaxWeight]  FROM [dbo].[Prices]";

            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                SqlCommand command = new SqlCommand(cmdString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.GetString(0);
            }
        }
    }
}