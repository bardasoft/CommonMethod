﻿using System;
using System.Collections.Generic;
using System.Data;
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
                    DBHelpMySql.connectionString = PubConstant.MySqlDBConnectionString;
                    break;
                case Enum_DataBase.MSSQLServer:
                    DBHelpMSSQL.connectionString = PubConstant.MSSQLDBConnectionString;
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

        public static DataSet QuerySQL(string strSQL)
        {
            switch (DataBaseInfo.DataBase)
            {
                case Enum_DataBase.MySQL:
                    return DBHelpMySql.Query(strSQL);
                case Enum_DataBase.MSSQLServer:
                    return DBHelpMSSQL.QuerySQL(strSQL);
                    break;
                case Enum_DataBase.SQLite:
                    return null;
                    break;
            }
            return null;
        }

        public static int ExecSQL(string strSQL)
        {
            switch (DataBaseInfo.DataBase)
            {
                case Enum_DataBase.MySQL:
                    return DBHelpMySql.ExecuteSql(strSQL);
                case Enum_DataBase.MSSQLServer:
                    return DBHelpMSSQL.ExecuteSQL(strSQL);
                    break;
                case Enum_DataBase.SQLite:
                    return 0;
                    break;
            }
            return -1;
        }
    }
}
