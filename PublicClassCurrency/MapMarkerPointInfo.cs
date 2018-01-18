using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency
{
    /// <summary>
    /// 地图标注点信息
    /// </summary>
    public class MapMarkerPointInfo
    {
        /// <summary>
        /// 标注点名称
        /// </summary>
        public string MarkerName = "";

        /// <summary>
        /// 标注点显示信息
        /// </summary>
        public string MarkerDisplayValue = "";

        /// <summary>
        /// 标注点标签
        /// </summary>
        public object MarkerDisplayTag;
        
        /// <summary>
        /// 标注点Icon路径
        /// </summary>
        public string MarkerIconFilePath = "";

        /// <summary>
        /// 标注点Icon 宽度
        /// </summary>
        public int MarkerIconWidth = 32;
        /// <summary>
        /// 标注点Icon 高度
        /// </summary>
        public int MarkerIconHeight = 32;

        /// <summary>
        /// 标注点首次显示地图等级
        /// 0表示未设置
        /// </summary>
        public int MarkerFirstDisplayMapLevel = 0;

        /// <summary>
        /// 地图点信息
        /// </summary>
        public MapPointInfo MarkerPoint = new MapPointInfo();
    }
}
