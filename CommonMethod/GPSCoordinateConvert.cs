using System;
using System.Collections.Generic;
using System.Text;

namespace CommonMethod
{
    /// <summary>
    /// GPS经纬度转换
    /// </summary>
    public class GPSCoordinateConvert
    {
        /******************************* 161219 经纬度计算
        * WGS-84：是国际标准，GPS坐标（Google Earth使用、或者GPS模块）
        * GCJ-02：中国坐标偏移标准，Google Map、高德、腾讯使用
        * BD-09：百度坐标偏移标准，Baidu Map使用
        ******************************/
        #region 坐标转换

        static double PI = 3.14159265358979324;
        static double x_pi = 3.14159265358979324 * 3000.0 / 180.0;


        /// <summary>
        /// WGS-84 转换 GCJ-02
        /// </summary>
        /// <param name="wgsLon"></param>
        /// <param name="wgsLat"></param>
        /// <param name="Lng"></param>
        /// <param name="lat"/param>
        public static void WGSToGCJ_encrypt(double wgsLon, double wgsLat, out double Lng, out double Lat)
        {
            double dlng, dlat;
            delta(wgsLon, wgsLat, out dlng, out dlat);
            Lng = wgsLon + dlng;
            Lat = wgsLat + dlat;
        }

        /// <summary>
        /// WGS-84 转换 BD-09
        /// </summary>
        /// <param name="wgsLon"></param>
        /// <param name="wgsLat"></param>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        public static void WGSToBD_encrypt(double wgsLon, double wgsLat, out double lng, out double lat)
        {
            if (outOfChina(wgsLon, wgsLat))
            {
                GCJToBD_encrypt(wgsLon, wgsLat, out lng, out lat);
                return;
            }
            double dlng, dlat;
            delta(wgsLon, wgsLat, out dlng, out dlat);
            GCJToBD_encrypt(wgsLon + dlng, wgsLat + dlat, out lng, out lat);
        }



        /// <summary>
        /// GCJ-02 转换 BD-09
        /// </summary>
        /// <param name="gcjLon"></param>
        /// <param name="gcjLat"></param>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        public static void GCJToBD_encrypt(double gcjLon, double gcjLat, out double lng, out double lat)
        {
            double x = gcjLon;
            double y = gcjLat;
            double z = Math.Sqrt(x * x + y * y) + 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) + 0.000003 * Math.Cos(x * x_pi);
            lng = z * Math.Cos(theta) + 0.0065;
            lat = z * Math.Sin(theta) + 0.006;
        }

        private static void delta(double lng, double lat, out double outlng, out double outlat)
        {
            // Krasovsky 1940
            //
            // a = 6378245.0, 1/f = 298.3
            // b = a * (1 - f)
            // ee = (a^2 - b^2) / a^2;
            double a = 6378245.0; //  a: 卫星椭球坐标投影到平面地图坐标系的投影因子。
            double ee = 0.00669342162296594323; //  ee: 椭球的偏心率。
            double dLat = transformLat(lng - 105.0, lat - 35.0);
            double dLon = transformLon(lng - 105.0, lat - 35.0);
            double radLat = lat / 180.0 * PI;
            double magic = Math.Sin(radLat);
            magic = 1 - ee * magic * magic;
            double sqrtMagic = Math.Sqrt(magic);
            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * PI);
            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * PI);
            outlng = dLon;
            outlat = dLat;
        }
        private static double transformLat(double x, double y)
        {
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y + 0.2 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * PI) + 20.0 * Math.Sin(2.0 * x * PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * PI) + 40.0 * Math.Sin(y / 3.0 * PI)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * PI) + 320 * Math.Sin(y * PI / 30.0)) * 2.0 / 3.0;
            return ret;
        }
        private static double transformLon(double x, double y)
        {
            double ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * PI) + 20.0 * Math.Sin(2.0 * x * PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * PI) + 40.0 * Math.Sin(x / 3.0 * PI)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * PI) + 300.0 * Math.Sin(x / 30.0 * PI)) * 2.0 / 3.0;
            return ret;
        }

        /// <summary>
        ///  GCJ-02 转换 WGS-84
        /// </summary>
        /// <param name="gcjLon"></param>
        /// <param name="gcjLat"></param>
        /// <param name="wgsLon"></param>
        /// <param name="wgsLat"></param>
        public static void GCJToWGS_encrypt(double gcjLon, double gcjLat, out double wgsLon, out double wgsLat)
        {
            double dlng, dlat;
            delta(gcjLon, gcjLat, out dlng, out dlat);
            wgsLon = gcjLon - dlng;
            wgsLat = gcjLat - dlat;
        }

        /// <summary>
        ///   BD-09 转换 GCJ-02
        /// </summary>
        /// <param name="bdLon"></param>
        /// <param name="bdLat"></param>
        /// <param name="gcjLon"></param>
        /// <param name="gcjLat"></param>
        public static void BDToGCJ_encrypt(double bdLon, double bdLat, out double gcjLon, out double gcjLat)
        {
            double x = bdLon - 0.0065, y = bdLat - 0.006;
            double lon = bdLon - 0.0065, lat = bdLat - 0.006;
            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * x_pi);
            gcjLon = z * Math.Cos(theta);
            gcjLat = z * Math.Sin(theta);
        }

        /// <summary>
        /// BD-09 转换 WGS-84
        /// </summary>
        /// <param name="bdLon"></param>
        /// <param name="bdLat"></param>
        /// <param name="wgsLon"></param>
        /// <param name="wgsLat"></param>
        public static void BDToWGS_encrypt(double bdLon, double bdLat, out double wgsLon, out double wgsLat)
        {
            double gcjLon, gcjLat;
            BDToGCJ_encrypt(bdLon, bdLat, out gcjLon, out gcjLat);
            GCJToWGS_encrypt(gcjLon, gcjLat, out wgsLon, out wgsLat);
        }

        //是否存在中国
        private static bool outOfChina(double lon, double lat)
        {
            if (lon < 72.004 || lon > 137.8347)
                return true;
            if (lat < 0.8293 || lat > 55.8271)
                return true;
            return false;
        }
        #endregion

        /// <summary>
        /// 计算两点之间的距离单位米
        /// </summary>
        /// <param name="lonA"></param>
        /// <param name="latA"></param>
        /// <param name="lonB"></param>
        /// <param name="latB"></param>
        /// <returns></returns>
        public static double GPS_Distance(double lonA, double latA, double lonB, double latB)
        {
            var earthR = 6371000;
            var x = Math.Cos(latA * PI / 180) * Math.Cos(latB * PI / 180) * Math.Cos((lonA - lonB) * PI / 180);
            var y = Math.Sin(latA * PI / 180) * Math.Sin(latB * PI / 180);
            var s = x + y;
            if (s > 1) s = 1;
            if (s < -1) s = -1;
            var alpha = Math.Acos(s);
            var distance = alpha * earthR;
            return distance;
        }
    }
}
