using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.ComponentModel;

namespace CommonMethod
{
    public class PropertyInfoConvertHelper
    {

        /// <summary>
        /// 根据属性信息获取对应的值类型
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="inValue"></param>
        /// <returns></returns>
        public static object GetPropertyValue(PropertyInfo pi, object inValue)
        {
            object value = inValue;
            Type Temp_t = pi.PropertyType;
            if (Temp_t.IsGenericType && Temp_t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                NullableConverter nullableConverter = new NullableConverter(Temp_t);
                value = nullableConverter.ConvertFromString(value.ToString());
            }
            else if (pi.PropertyType == typeof(byte))
            {
                value = Convert.ToByte(value);
            }
            else if (pi.PropertyType == typeof(int))
            {
                string Temp_strValue = Convert.ToString(value);
                value = string.IsNullOrEmpty(Temp_strValue) ? 0 : Convert.ToInt32(value);
            }
            else if (pi.PropertyType == typeof(DateTime))
            {
                value = Convert.ToDateTime(value);
            }
            else if (inValue == DBNull.Value)
            {
                value = null;
            }
            return value;
        }
    }
}
