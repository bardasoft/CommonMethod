using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DBOperAt
{
    public  class PubConstant
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        public static string MSSQLDBConnectionString
        {
            //server=192.168.18.131,1433;Initial Catalog=AlarmServer;User ID= AlarmServerUser;Password=AlarmServer
            //ConfigurationManager.ConnectionStrings["data"].ConnectionString;
            get
            {
                StringBuilder sbConnstr = new StringBuilder();
               
                if (DataBaseInfo.DBPort != 0) //设置端口
                {
                    sbConnstr.Append("Data Source = " + DataBaseInfo.DBAddress + "," + DataBaseInfo.DBPort + ";");
                }
                else
                {
                    sbConnstr.Append("Data Source = " + DataBaseInfo.DBAddress + "; ");
                }
                sbConnstr.Append("Initial Catalog=" + DataBaseInfo.DBName + "; ");
                sbConnstr.Append("User ID=" + DataBaseInfo.DBUserName + "; ");
                sbConnstr.Append("Password=" + DataBaseInfo.DBPassword + " ");
                return sbConnstr.ToString();
            }
        }

        public static string MySqlDBConnectionString
        {
            get 
            {
                StringBuilder sbConnstr = new StringBuilder();
                sbConnstr.Append("server=" + DataBaseInfo.DBAddress + "; ");
                sbConnstr.Append("Port=" + DataBaseInfo.DBPort + "; ");
                sbConnstr.Append("user id=" + DataBaseInfo.DBUserName + "; ");
                sbConnstr.Append("password=" + DataBaseInfo.DBPassword + "; ");
                sbConnstr.Append("database=" + DataBaseInfo.DBName + ";Connect Timeout=500 ");
                return sbConnstr.ToString();
            }
        }

        public static string DBConnectionStringState
        {
            get { return ""; }
        }

        public static string SQLiteDBConnectionString
        {
            get { return ""; }
        }
    }
}
