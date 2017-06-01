using System;
using System.Collections.Generic;
using System.Text;

namespace CommonMethod
{
    /// <summary>
    /// 在线地图对象
    /// </summary>
    public class OnlieMapObject
    {
        /// <summary>
        /// 地址信息
        /// </summary>
        public class OnlineMapAddressInfo
        {
            /// <summary>
            /// 经度
            /// </summary>
            double lon;
            /// <summary>
            /// 经度
            /// </summary>
            public double Lon
            {
                get { return lon; }
                set { lon = value; }
            }

            /// <summary>
            /// 纬度
            /// </summary>
            double lat;
            /// <summary>
            /// 纬度
            /// </summary>
            public double Lat
            {
                get { return lat; }
                set { lat = value; }
            }

            /// <summary>
            /// 地图显示等级 默认0 代表使用当前地图等级
            /// </summary>
            int level = 0;
            /// <summary>
            /// 地图显示等级
            /// </summary>
            public int Level
            {
                get { return level; }
                set { level = value; }
            }

            /// <summary>
            /// 键值 数据的主键
            /// </summary>
            string valueInfo;
            /// <summary>
            /// 键值 数据的主键
            /// </summary>
            public string ValueInfo
            {
                get { return valueInfo; }
                set { valueInfo = value; }
            }


            /// <summary>
            /// 显示信息
            /// </summary>
            string dislpayInfo = "";
            /// <summary>
            /// 显示信息
            /// </summary>
            public string DislpayInfo
            {
                get { return dislpayInfo; }
                set { dislpayInfo = value; }
            }

            /// <summary>
            /// 图标显示信息
            /// 0,绿色标杆（默认） 1,蓝色小车 2,蓝色标点
            /// 11.绿色基本指示点 12.蓝色基本指示点 13.红色基本指示点 
            /// 14.橙色基本指示点 15.紫色基本指示点 16.粉色基本指示点
            /// 21.绿色标杆 22.蓝色标杆 23.红色标杆 
            /// 24.橙色标杆 25.紫色标杆 26.粉色标杆
            private int displayIconIndex = 0;

            /// <summary>
            /// 图标显示信息
            /// 0,绿色标杆（默认） 1,蓝色小车 2,蓝色标点
            /// 11.绿色基本指示点 12.蓝色基本指示点 13.红色基本指示点 
            /// 14.橙色基本指示点 15.紫色基本指示点 16.粉色基本指示点
            /// 21.绿色标杆 22.蓝色标杆 23.红色标杆 
            /// 24.橙色标杆 25.紫色标杆 26.粉色标杆
            /// </summary>
            public int DisplayIconIndex
            {
                get { return displayIconIndex; }
                set { displayIconIndex = value; }
            }

            bool isAlarm = false;

            public bool IsAlarm
            {
                get { return isAlarm; }
                set { isAlarm = value; }
            }
        }
    }
}
