using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DBOperAt
{
    class DBHelpMSSQL
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        //private static string connectionString = ConfigurationManager.ConnectionStrings["AlarmServerDB"].ConnectionString;

        public static string connectionString = PubConstant.MSSQLDBConnectionString;

        #region 公用方法
        /// <summary>
        /// 查询表中是否存在列名
        /// </summary>
        /// <param name="tableName">表的名称</param>
        /// <param name="columnName">列的名称</param>
        /// <returns></returns>
        public static bool ColunmExists(string tableName, string columnName)
        { 
             string sql="SELECT COUNT(1) FROM SYSCOLUMNS WHERE [id]=object_id('"+tableName+"') AND [name]='"+columnName+"'";
             object obj = GetSingle(sql);
             if (obj == null)
             {
                 return false;
             }
             return Convert.ToInt32(obj) > 0;
        }

        /// <summary>
        /// 判断是否存在表
        /// </summary>
        /// <param name="tableName">表的名称</param>
        /// <returns></returns>
        public static bool TableExists(string tableName)
        {
            string sql = "SELECT COUNT(1) FROM SYSOBJECTS WHERE ID=object_id(N'[" + tableName + "]') AND OBJECTPROPERTY(id, N'IsUserTable')=1";
            object obj = GetSingle(sql);
            if (obj == null)
            {
                return false;
            }
            if (int.Parse(obj.ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取列中最大的数（返回值为最大数+1）
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="tableName">表的名称</param>
        /// <returns></returns>
        public static int GetMaxID(string tableName, string fieldName)
        {
            string sql = "SELECT MAX(" + fieldName + ") +1 FROM " + tableName + "";
            object obj = GetSingle(sql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return (int)obj;
            }
        }
        #endregion

        #region 简单的SQL语句
        /// <summary>
        /// 执行SQL语句，返回受影响的行数
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns>受影响的行数Int</returns>
        public static int ExecuteSQL(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int affectrows = command.ExecuteNonQuery();
                        return affectrows;
                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回受影响的行数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Tiems">超时时间</param>
        /// <returns>受影响的行数Int</returns>
        public static int ExecuteSQLByTime(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandTimeout = Times;
                        int affectrows = command.ExecuteNonQuery();
                        return affectrows;
                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条查询语句，返回查询结果(DataSet)
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>查询结果(DataSet)</returns>
        public static DataSet QuerySQL(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    PrepareCommand(command, connection, null, SQLString, null);
                    using (SqlDataAdapter data = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            data.Fill(ds, "ds");
                            command.Parameters.Clear();
                        }
                        catch(SqlException ex)
                        {
                            throw ex;
                        }
                        return ds;
                    }
                }
            }
        
        }

        /// <summary>
        /// 执行一条计算查询结果语句（Count），返回查询结果（Object）
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（Object）</returns>
        public static object CountQuerySQL(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = command.ExecuteScalar();
                        if (Object.Equals(obj, null) || Object.Equals(obj, System.DBNull.Value))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句（Count），返回查询结果（Object）
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Times">超时时间</param>
        /// <returns>查询结果（Object）</returns>
        public static object CountQuerySQLByTime(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandTimeout = Times;
                        object obj = command.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果(object)
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                using (SqlCommand command = new SqlCommand(SQLString,connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = command.ExecuteScalar();
                        if (object.Equals(obj, null) || object.Equals(obj,System.DBNull.Value))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                        
                    }
                    catch(SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句添加等待时间，返回查询结果(object)
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="times">发生错误之前的等待时间</param>
        /// <returns></returns>
        public static object GetSingle(string SQLString, int times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandTimeout = times;
                        object obj = command.ExecuteScalar();
                        if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                    
                }
            }
        }
        #endregion

        #region 执行带参数的SQL执行语句

        /// <summary>
        /// 执行带参数SQL语句，返回受影响的行数
        /// </summary>
        /// <param name="SQLString">执行语句</param>
        /// <param name="cmdParams">参数</param>
        /// <returns>受影响的行数Int</returns>
        public static int ExecuteSQL(string SQLString, params SqlParameter[] cmdParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(command, connection, null, SQLString, cmdParams);
                        int affectrows = command.ExecuteNonQuery();
                        return affectrows;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 执行带参数SQL查询语句，返回查询结果
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="cmdParams">参数</param>
        /// <returns>查询结果DataSet</returns>
        public static DataSet QuerySQL(string SQLString, params SqlParameter[] cmdParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    PrepareCommand(command, connection, null, SQLString, cmdParams);
                    using (SqlDataAdapter data = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            data.Fill(ds, "ds");
                            command.Parameters.Clear();
                        }
                        catch (SqlException ex)
                        {
                            throw ex;
                        }
                        return ds;
                    }
                }
            }
        }

        /// <summary>
        /// 执行带参数的查询结果语句（Count），返回查询结果（Object）
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="cmdParams">参数</param>
        /// <returns>查询结果Object</returns>
        public static object CountQuerySQL(string SQLString, params SqlParameter[] cmdParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(command, connection, null, SQLString, cmdParams);
                        object obj = command.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || Object.Equals(obj, DBNull.Value))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Command的参数赋值
        /// </summary>
        /// <param name="command">command对象</param>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="trans">事物（不太能理解）（当有语句执行异常时，回滚至数据操作前的状态）</param>
        /// <param name="commandText">数据库执行语句</param>
        /// <param name="commandParams">参数</param>
        public static void PrepareCommand(SqlCommand command, SqlConnection conn, SqlTransaction trans, string commandText, SqlParameter[] commandParams)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            command.Connection = conn;
            command.CommandText = commandText;
            if (trans != null)
            {
                command.Transaction = trans;
            }
            command.CommandType = CommandType.Text;
            if (commandParams != null)
            {
                foreach (SqlParameter param in commandParams)
                {
                    if ((param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Input) &&
                        (param.Value == null))
                    {
                        param.Value = DBNull.Value;
                    }
                    command.Parameters.Add(param);
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句,实现数据库事物（Hashtable）(无序)
        /// </summary>
        /// <param name="SQLStrings">SQL语句表(key表示SQL语句，Values表示该语句的SqlParameter)</param>
        public static void ExecuteSQLTran(Hashtable SQLStrings)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlCommand command = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry DE in SQLStrings)
                        { 
                            string cmdText=DE.Value.ToString();
                            SqlParameter[] cmdParas = (SqlParameter[])DE.Key;
                            PrepareCommand(command, connection, transaction, cmdText, cmdParas);
                            int val = command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        transaction.Commit();//事物提交
                    }
                    catch(SqlException ex)
                    {
                        transaction.Rollback();//事物回滚
                        throw ex;
                    }
                }

            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事（list<DictionaryEntry>）（有序）
        /// </summary>
        /// <param name="SQLList">SQL语句表(Value表示SQL语句，key表示该语句的SqlParameter)</param>
        public static void ExecuteSQLTran(List<DictionaryEntry> SQLList)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlCommand command = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry DE in SQLList)
                        {
                            string cmdText = DE.Value.ToString();
                            SqlParameter[] cmdParas = (SqlParameter[])DE.Key;
                            PrepareCommand(command, connection, transaction, cmdText, cmdParas);
                            int val = command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                    catch(SqlException ex)
                    {
                        transaction.Rollback(); //事物回滚
                        throw ex;
                    }
                }
            }
        }
        #endregion

        #region 存储过程操作 RunProcDure(返回结果为结果集) RunProcdure(返回结果为Int或者Object)
        /// <summary>
        /// 执行存储过程，返回SqlDataReader（调用方法后要对Reader对象进行Close()）
        /// </summary>
        /// <param name="storeProcName">;存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        public static SqlDataReader RunProceDure(string storeProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storeProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;
        }

        /// <summary>
        /// 执行存储过程，返回收影响的行数
        /// </summary>
        /// <param name="storeProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">返回值</param>
        /// <returns></returns>
        public static int RunProcedure(string storeProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;//结果
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storeProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                return result;
            }
        }

        /// <summary>
        /// 创建SqlCommand对象（用来返回一个整数）
        /// </summary>
        /// <param name="connection">连接对象</param>
        /// <param name="storeProcName">存储过程名称</param>
        /// <param name="parameters">存储过程需要的参数</param>
        /// <returns></returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storeProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storeProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// 执行存储过程返回第一行第一列
        /// </summary>
        /// <param name="storeProcName">存过过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static object RunProcdure(string storeProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = BuildIntCommand(connection, storeProcName, parameters);
                    return command.ExecuteScalar(); 
                }
                catch(SqlException ex)
                {
                    connection.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行存储过程，返回结果集
        /// </summary>
        /// <param name="storeProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns></returns>
        public static DataSet RunProceDure(string storeProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlDa.SelectCommand = BuildQueryCommand(connection, storeProcName, parameters);
                sqlDa.Fill(ds, tableName);
                connection.Close();
                return ds;
            }
        }

        /// <summary>
        /// 执行存储过程，返回结果集
        /// </summary>
        /// <param name="storeProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <param name="times">发生错误之前的等待时间</param>
        /// <returns></returns>
        public static DataSet RunProceDurn(string storeProcName, IDataParameter[] parameters, string tableName, int times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlDa.SelectCommand = BuildQueryCommand(connection,storeProcName,parameters);
                sqlDa.SelectCommand.CommandTimeout = times;
                sqlDa.Fill(ds, tableName);
                connection.Close();
                return ds;
            }
        }

        /// <summary>
        /// 创建SqlCommand对象（用来返回一个结果集）
        /// </summary>
        /// <param name="connection">连接对象</param>
        /// <param name="storeProcName">存储过程名称</param>
        /// <param name="parameters"》存储过程参数</param>
        /// <returns></returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storeProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storeProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) 
                        && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }
        #endregion

        #region 对数据库进行批量操作 （插入与更新）
        
        /// <summary>
        /// 使用SqlDaraAdapter批量更新数据库表
        /// </summary>
        /// <param name="SQLString">数据库查询语句（带主键，带修改的值）</param>
        /// <param name="dt">修改后的表</param>
        /// <returns></returns>
        public static bool BatchUpdateTable(string SQLString,DataTable dt)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(SQLString,connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                        {
                            try
                            {
                                builder.ConflictOption = ConflictOption.OverwriteChanges;
                                connection.Open();
                                adapter.UpdateBatchSize = 5000;  //批处理的数量设置
                                adapter.SelectCommand.Transaction = connection.BeginTransaction();  //事物
                                if (dt.ExtendedProperties["SQL"] != null)  //可以将数据表的语句放在 ExtendedProperties中
                                {
                                    adapter.SelectCommand.CommandText = dt.ExtendedProperties["SQL"].ToString();
                                }
                                adapter.Update(dt); // 进行更新操作
                                adapter.SelectCommand.Transaction.Commit();
                                return true;
                            }
                            catch(SqlException ex)
                            {
                                adapter.SelectCommand.Transaction.Rollback();
                                throw ex;
                            }

                        }
                    }
                }
            }
        }

        /// <summary>
        /// 使用SqlBulkCopy将数据批量插入数据库，使用时注意主键重复，否则会异常
        ///（使用中间表和触发器可以完成对数据的批量更新/插入）
        /// </summary>
        /// <param name="tableName">数据库中对应表的名字</param>
        /// <param name="dt">插入的数据表</param>
        /// <returns></returns>
        public static bool BatchInsertTable(string tableName, DataTable dt)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.FireTriggers)) //设置模式，当前为插入式启用触发器
                {
                    try
                    {
                        bulkCopy.DestinationTableName = tableName;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        bulkCopy.WriteToServer(dt);
                        return true;
                    }
                    catch(SqlException ex)
                    {
                        throw ex;
                    }
                }
            }            
        }

        #endregion

    }
}
