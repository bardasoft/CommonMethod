using PublicClassCurrency.Video;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency
{
    /// <summary>
    /// 摄像头信息
    /// </summary>
    public class CameraInfo
    {

        /// <summary>
        /// 视频设备信息
        /// </summary>
        public VideoInfo VideoInfo
        {
            get;
            set;
        }

        private int intCameraID = 0;
        /// <summary>
        /// ID
        /// </summary>
        public int CameraID
        {
            get { return intCameraID; }
            set { intCameraID = value; }
        }

        /// <summary>
        /// 视频设备编号
        /// </summary>
        private string strDVSNumber = "";

        /// <summary>
        /// 视频设备编号
        /// </summary>
        public string DVSNumber
        {
            get { return strDVSNumber; }
            set { strDVSNumber = value; }
        }

        /// <summary>
        /// 摄像头通道号
        /// </summary>
        private int intChannel = 0;
        /// <summary>
        /// 摄像头通道号
        /// 181105后接入设备统一通道号由1开始
        /// 已统一设备 ：智诺（ZL）
        /// </summary>
        public int Channel
        {
            get { return intChannel; }
            set { intChannel = value; }
        }


        /// <summary>
        /// DSV地址/唯一码
        /// </summary>
        private string strDVSAddress = "";

        /// <summary>
        /// DSV地址/唯一码
        /// </summary>
        public string DVSAddress
        {
            get { return strDVSAddress; }
            set { strDVSAddress = value; }
        }

        /// <summary>
        /// DVS类型
        /// </summary>
        private string strDVSType = "";
        /// <summary>
        /// DVS类型
        /// </summary>
        public string DVSType
        {
            get { return strDVSType; }
            set { strDVSType = value; }
        }

        /// <summary>
        /// 摄像头名称
        /// </summary>
        private string strCameraName = "";
        /// <summary>
        /// 摄像头名称
        /// </summary>
        public string CameraName
        {
            get { return strCameraName; }
            set { strCameraName = value; }
        }

        /// <summary>
        /// 设备头唯一码
        /// </summary>
        private string strCameraUniqueCode;

        /// <summary>
        /// 设备头唯一码
        /// </summary>
        public string CameraUniqueCode
        {
            get { return strCameraUniqueCode; }
            set { strCameraUniqueCode = value; }
        }

        /// <summary>
        /// 平面地图名称
        /// </summary>
        private string strPlaneMapName = "";
        /// <summary>
        /// 平面地图名称
        /// </summary>
        public string PlaneMapName
        {
            get { return strPlaneMapName; }
            set { strPlaneMapName = value; }
        }

        private int intPlaneMapX;

        /// <summary>
        /// 平面地图X
        /// </summary>
        public int PlaneMapX
        {
            get { return intPlaneMapX; }
            set { intPlaneMapX = value; }
        }

        private int intPlaneMapY;
        /// <summary>
        /// 平面地图Y
        /// </summary>
        public int PlaneMapY
        {
            get { return intPlaneMapY; }
            set { intPlaneMapY = value; }
        }

        private List<VideoStream> videoStream = new List<VideoStream>();
        public List<VideoStream> VideoStream
        {
            get { return videoStream; }
            set { videoStream = value; }
        }
    }
}
