using System;
using System.Collections.Generic;
using System.Text;

namespace DBOperAt
{
    public static class DataBaseOperAt
    {
        public static void SetDBInfo(string DBAddress, int intPort, string DatabaseName, string DatabaseUser, string DatabasePassword, Enum_DataBase database)
        {
            DataBaseInfo.DataBase = database;
            DataBaseInfo.DBAddress = DBAddress;
            DataBaseInfo.DBPort = intPort;
            DataBaseInfo.DBName = DatabaseName;
            DataBaseInfo.DBUserName = DatabaseUser;
            DataBaseInfo.DBPassword = DatabasePassword;
            switch (database)
            {
                case Enum_DataBase.MySQL:
                    DBHelpMSSQL.connectionString = PubConstant.MSSQLDBConnectionString;
                    break;
                case Enum_DataBase.MSSQLServer:
                    DBHelpMySql.connectionString = PubConstant.MySqlDBConnectionString;
                    break;
                case Enum_DataBase.SQLite:
                    DBHelpSQLite.connectionString = PubConstant.SQLiteDBConnectionString;
                    break;
            }
            
        }

        public static bool DBTestConn()
        {
            return false;
        }
    }
}
