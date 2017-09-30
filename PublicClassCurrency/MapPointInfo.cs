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
        /// 纬度
        /// </summary>
        double dblLat;

        /// <summary>
        /// 地图等级
        /// </summary>
        int intMapLevel;

        /// <summary>
        /// 坐标系统
        /// </summary>
        Enum_CordinateSystem cordinateSyatem = Enum_CordinateSystem.WGS_84;

    }
}
