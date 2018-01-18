using System;
using System.Collections.Generic;
using System.Text;

namespace DBOperAt
{
    public class DataBaseInfo
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public static Enum_DataBase DataBase = Enum_DataBase.MSSQLServer;

        /// <summary>
        /// 数据库主机地址
        /// </summary>
        private static string strDBAddress;

        /// <summary>
        /// 数据库主机地址
        /// </summary>
        public static string DBAddress
        {
            get { return strDBAddress; }
            set { strDBAddress = value; }
        }

        /// <summary>
        /// 数据库主机端口
        /// </summary>
        private static int intDBPort;

        /// <summary>
        /// 数据库主机端口
        /// </summary>
        public static int DBPort
        {
            get { return intDBPort; }
            set { intDBPort = value; }
        }

        /// <summary>
        /// 数据库名称
        /// </summary>
        private static string strDBName;

        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string DBName
        {
            get { return strDBName; }
            set { strDBName = value; }
        }

        /// <summary>
        /// 主机用户名
        /// </summary>
        private static string strDBUserName;

        /// <summary>
        /// /// <summary>
        /// 主机用户名
        /// </summary>
        /// </summary>
        public static string DBUserName
        {
            get { return strDBUserName; }
            set { strDBUserName = value; }
        }


        /// <summary>
        /// 主机密码
        /// </summary>
        private static string strDBPassword;

        /// <summary>
        /// /// <summary>
        /// 主机密码
        /// </summary>
        /// </summary>
        public static string DBPassword
        {
            get { return strDBPassword; }
            set { strDBPassword = value; }
        }

    }
}
