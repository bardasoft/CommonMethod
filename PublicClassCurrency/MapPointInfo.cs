using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency
{
    /// <summary>
    /// 地图点信息
    /// </summary>
    public class MapPointInfo
    {
        /// <summary>
        /// 经度
        /// </summary>
        double dblLon;
        /// <summary>
        /// 经度
        /// </summary>
        public double Lon
        {
            get { return dblLon; }
            set { dblLon = value; }
        }

        /// <summary>
        /// 纬度
        /// </summary>
        double dblLat;
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat
        {
            get { return dblLat; }
            set { dblLat = value; }
        }

        /// <summary>
        /// 地图等级
        /// </summary>
        int intMapLevel;
        /// <summary>
        /// 地图等级
        /// </summary>
        public int MapLevel
        {
            get { return intMapLevel; }
            set { intMapLevel = value; }
        }

        /// <summary>
        /// 坐标系统
        /// </summary>
        Enum_CordinateSystem CordinateSyatem = Enum_CordinateSystem.WGS_84;

    }
}
