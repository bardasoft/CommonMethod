using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace CommonMethod
{
    public class DBRelevant
    {
        /// <summary>
        /// 获取数据库语句_插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strKeyField"></param>
        /// <returns></returns>
        public static string GetDBOperatStr_Insert<T>(T t,string strTableName, string strKeyField)
        {

            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("INSERT INTO ");
            sbResult.Append(strTableName + " ");    //表名称
            sbResult.Append("( ");
            foreach (var pi in propertys)
            {

                if (strKeyField == pi.Name)
                {
                    continue;   //主键跳过
                }
                sbResult.Append(pi.Name);
                sbResult.Append(",");
            }
            sbResult.Length = sbResult.Length - 1;

            sbResult.Append(") ");
            sbResult.Append("VALUES ");
            sbResult.Append("( ");
            foreach (var pi in propertys)
            {
                if (strKeyField == pi.Name)
                {
                    continue;   //主键跳过
                }
                if ((pi.PropertyType == typeof(byte)))
                {
                    //特殊处理1  byte类型
                    sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                }
                else if ((pi.PropertyType == typeof(DateTime)))
                {
                    //特殊处理2 时间类型格式
                    DateTime Temp_tim = Convert.ToDateTime(pi.GetValue(t, null));
                    //sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                    sbResult.Append("'" + Temp_tim.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
                }
                else
                {
                    sbResult.Append("'" + Convert.ToString(pi.GetValue(t, null)) + "' ");
                }
                sbResult.Append(",");
            }
            sbResult.Length = sbResult.Length - 1;
            sbResult.Append(") ");
            return sbResult.ToString();
        }

        /// <summary>
        /// 获取数据库语句_更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strsKeyField"></param>
        /// <returns></returns>
        public static string GetDBOperatStr_Update<T>(T t, string strTableName, string[] strsKeyField)
        {
            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("UPDATE  ");
            sbResult.Append(strTableName + " ");    //表名称
            sbResult.Append("SET ");
            foreach (var pi in propertys)
            {
                if (StrInStrs(strsKeyField, pi.Name))
                {
                    continue;
                }
                sbResult.Append(pi.Name + " = ");
                if ((pi.PropertyType == typeof(byte)))
                {
                    //特殊处理1  byte类型
                    sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                }
                else if ((pi.PropertyType == typeof(DateTime)))
                {
                    //特殊处理2 时间类型格式
                    DateTime Temp_tim = Convert.ToDateTime(pi.GetValue(t, null));
                    //sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                    sbResult.Append("'" + Temp_tim.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
                }
                else
                {

                    sbResult.Append("'" + Convert.ToString(pi.GetValue(t, null)) + "' ");
                }
                sbResult.Append(",");
            }
            sbResult.Length = sbResult.Length - 1;
            sbResult.Append("WHERE ");
            foreach (var pi in propertys)
            {
                if (StrInStrs(strsKeyField, pi.Name))
                {
                    sbResult.Append(pi.Name + " = ");
                    if (!(pi.PropertyType == typeof(byte)))
                    {
                        sbResult.Append("'" + Convert.ToString(pi.GetValue(t, null)) + "' ");
                    }
                    else
                    {
                        sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                    }
                    sbResult.Append("AND ");
                }
            }
            sbResult.Length = sbResult.Length - 4;
            return sbResult.ToString();
        }

        /// <summary>
        /// 获取数据库语句_更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strsKeyField"></param>
        /// <param name="strsUpdateField"></param>
        /// <returns></returns>
        public static string GetDBOperatStr_Update<T>(T t, string strTableName, string[] strsKeyField, string[] strsUpdateField)
        {
            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("UPDATE  ");
            sbResult.Append(strTableName + " ");    //表名称
            sbResult.Append("SET ");
            foreach (var pi in propertys)
            {
                if (StrInStrs(strsUpdateField, pi.Name))
                {
                    sbResult.Append(pi.Name + " = ");
                    if ((pi.PropertyType == typeof(byte)))
                    {
                        //特殊处理1  byte类型
                        sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                    }
                    else if ((pi.PropertyType == typeof(DateTime)))
                    {
                        //特殊处理2 时间类型格式
                        DateTime Temp_tim = Convert.ToDateTime(pi.GetValue(t, null));
                        //sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                        sbResult.Append("'" + Temp_tim.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
                    }
                    else
                    {

                        sbResult.Append("'" + Convert.ToString(pi.GetValue(t, null)) + "' ");
                    }
                    sbResult.Append(",");
                }
            }
            sbResult.Length = sbResult.Length - 1;
            sbResult.Append("WHERE ");
            foreach (var pi in propertys)
            {
                if (StrInStrs(strsKeyField, pi.Name))
                {
                    sbResult.Append(pi.Name + " = ");
                    if (!(pi.PropertyType == typeof(byte)))
                    {
                        sbResult.Append("'" + Convert.ToString(pi.GetValue(t, null)) + "' ");
                    }
                    else
                    {
                        sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                    }
                    sbResult.Append("AND ");
                }
            }
            sbResult.Length = sbResult.Length - 4;
            return sbResult.ToString();
        }

        /// <summary>
        /// 获取数据库语句_查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strsKeyField"></param>
        /// <returns></returns>
        public static string GetDBOperatStr_Query<T>(T t, string strTableName, string[] strsKeyField)
        {
            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("SELECT * FROM ");
            sbResult.Append(strTableName + " ");
            sbResult.Append("WHERE ");
            foreach (var pi in propertys)
            {
                if (StrInStrs(strsKeyField, pi.Name))
                {
                    sbResult.Append(pi.Name + " = ");
                    if ((pi.PropertyType == typeof(byte)))
                    {
                        //特殊处理1  byte类型
                        sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                    }
                    else if ((pi.PropertyType == typeof(DateTime)))
                    {
                        //特殊处理2 时间类型格式
                        DateTime Temp_tim = Convert.ToDateTime(pi.GetValue(t, null));
                        //sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                        sbResult.Append("'" + Temp_tim.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
                    }
                    else
                    {
                        sbResult.Append("'" + Convert.ToString(pi.GetValue(t, null)) + "' ");
                    }
                    sbResult.Append("AND ");
                }
            }
            sbResult.Length = sbResult.Length - 4;
            return sbResult.ToString();
        }

        /// <summary>
        /// 获取数据库语句_删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strsKeyField"></param>
        /// <returns></returns>
        public static string GetDBOperatStr_Delete<T>(T t, string strTableName, string[] strsKeyField)
        {
            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("DELETE FROM ");
            sbResult.Append(strTableName + " ");
            sbResult.Append("WHERE ");
            foreach (var pi in propertys)
            {
                if (StrInStrs(strsKeyField, pi.Name))
                {
                    sbResult.Append(pi.Name + " = ");
                    if (!(pi.PropertyType == typeof(byte)))
                    {
                        sbResult.Append("'" + Convert.ToString(pi.GetValue(t, null)) + "' ");
                    }
                    else
                    {
                        sbResult.Append(Convert.ToString(pi.GetValue(t, null)) + " ");
                    }
                    sbResult.Append("AND ");
                }
            }
            sbResult.Length = sbResult.Length - 4;
            return sbResult.ToString();
        }

        private static bool StrInStrs(string[] strs, string str)
        {
            foreach (string s in strs)
            {
                if (s == str)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
