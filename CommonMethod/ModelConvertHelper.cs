using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace CommonMethod
{
    public class ModelConvertHelper<T> where T : new()
    {
        /// <summary>
        /// 模型转换_Table
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<T> ConvertToModel(DataTable dt)
        {

            IList<T> ts = new List<T>();// 定义集合
            Type type = typeof(T); // 获得此模型的类型
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                ts.Add(ConvertToModel(dr));
            }
            return ts;
        }

        /// <summary>
        /// 模型类型转换_DataRow
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ConvertToModel(DataRow dr)
        {
            T t = new T();
            string tempName = "";
            PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
            foreach (PropertyInfo pi in propertys)
            {
                tempName = pi.Name;
                if (!pi.CanWrite)
                {
                    continue;
                }
                if (!dr.Table.Columns.Contains(tempName))
                {
                    //数据行不存在对应字段
                    continue;
                }
                object value = dr[tempName];
                if (value != DBNull.Value)
                {
                    value = PropertyInfoConvertHelper.GetPropertyValue(pi, value);
                    pi.SetValue(t, value, null);
                }


            }
            return t;
        }
    }
}
