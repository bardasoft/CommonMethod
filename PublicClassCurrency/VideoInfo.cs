using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency
{
    /// <summary>
    /// 摄像机信息
    /// </summary>
    public class VideoInfo
    {
        #region 参数
        /// <summary>
        /// 视频设备类型
        /// </summary>
        public Enum_VideoType VideoType = Enum_VideoType.Unrecognized;

        /// <summary>
        /// 摄像机编号
        /// </summary>
        private string strDVSNumber;
        /// <summary>
        /// 摄像机编号
        /// </summary>
        public string DVSNumber
        {
            get { return strDVSNumber; }
            set { strDVSNumber = value; }
        }

        /// <summary>
        /// 主机编号
        /// </summary>
        private string strHostID;
        /// <summary>
        /// 主机编号
        /// </summary>
        public string HostID
        {
            get { return strHostID; }
            set { strHostID = value; }
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
        /// DVS名称
        /// </summary>
        private string strDVSName = "";
        /// <summary>
        /// DVS名称
        /// </summary>
        public string DVSName
        {
            get { return strDVSName; }
            set { strDVSName = value; }
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
        /// DVS连接端口
        /// </summary>
        private int intDVSConnectPort=0;
        /// <summary>
        /// DVS连接端口
        /// </summary>
        public int DVSConnectPort
        {
            get { return intDVSConnectPort; }
            set { intDVSConnectPort = value; }
        }

        /// <summary>
        /// DVS数据端口
        /// </summary>
        private int intDVSDataPort = 0;
        /// <summary>
        /// DVS连接端口
        /// </summary>
        public int DVSDataPort
        {
            get { return intDVSDataPort; }
            set { intDVSDataPort = value; }
        }

        /// <summary>
        /// 通道号数量
        /// </summary>
        private int intDVSChannelNum = 0;
        /// <summary>
        /// 通道号数量
        /// </summary>
        public int DVSChannelNum
        {
            get { return intDVSChannelNum; }
            set { intDVSChannelNum = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        private string strUserName = "";
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string strPassword = "";
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        /// <summary>
        /// 用户预览密码
        /// </summary>
        private string strPreviewPwd = "";
        /// <summary>
        /// 用户预览密码
        /// </summary>
        public string PreviewPwd
        {
            get { return strPreviewPwd; }
            set { strPreviewPwd = value; }
        }

        /// <summary>
        /// 视频播放时间限制_分 0代表无限制
        /// </summary>
        private int intVideoPlayTime_Minute=0;

        /// <summary>
        /// 视频播放时间限制_分 0代表无限制
        /// </summary>
        public int VideoPlayTime_Minute
        {
            get { return intVideoPlayTime_Minute; }
            set { intVideoPlayTime_Minute = value; }
        }

        /// <summary>
        /// 网络状态 大于0在线 0离线 -1状态未明
        /// </summary>
        private int intNetworkState;
        /// <summary>
        /// 网络状态 大于0在线 0离线 -1状态未明
        /// </summary>
        public int NetworkState
        {
            get { return intNetworkState; }
            set { intNetworkState = value; }
        }

        /// <summary>
        /// 自动对讲功能
        /// 0关闭 1自动进入对讲 2自动进入监听  3自动进入对讲喊话
        /// </summary>
        private int intAutoIntercom = 0;

        /// <summary>
        /// 自动对讲功能 
        /// 0关闭 1自动进入对讲 2自动进入监听  3自动进入对讲喊话
        /// </summary>
        public int AutoIntercom
        {
            get { return intAutoIntercom; }
            set { intAutoIntercom = value; }
        }


        /// <summary>
        /// 摄像头信息
        /// </summary>
        private Dictionary<int, CameraInfo> dicCameras = new Dictionary<int, CameraInfo>();
        /// <summary>
        /// 摄像头信息
        /// </summary>
        public Dictionary<int, CameraInfo> Cameras
        {
            get { return dicCameras; }
            set { dicCameras = value; }
        }

        /// <summary>
        /// 对讲使能
        /// </summary>
        private bool bolIntercomEnable = false;
        /// <summary>
        /// 对讲使能
        /// </summary>
        public bool IntercomEnable
        {
            get { return bolIntercomEnable; }
            set
            {
                bolIntercomEnable = value;
            }
        }


        /// <summary>
        /// 仅作为对讲设备
        /// </summary>
        private bool bolOnlyIntercom = false;
        /// <summary>
        /// 仅作为对讲设备
        /// </summary>
        public bool OnlyIntercom
        {
            get { return bolOnlyIntercom; }
            set
            {
                bolOnlyIntercom = value;
            }
        }
        #endregion

        #region 方法

        #region 摄像头信息
        /// <summary>
        /// 设置摄像头信息
        /// </summary>
        /// <param name="intChannel"></param>
        /// <param name="strCameraName"></param>
        private void SetCameraInfo(int intChannel, string strCameraName)
        {
            Cameras[intChannel] = new CameraInfo();
            Cameras[intChannel].DVSNumber = DVSNumber;
            Cameras[intChannel].DVSType = DVSType;
            Cameras[intChannel].DVSAddress = DVSAddress;
            Cameras[intChannel].CameraName = strCameraName;
            Cameras[intChannel].Channel = intChannel;
        }

        /// <summary>
        /// 是否存在摄像头信息
        /// </summary>
        /// <param name="cameraInfo"></param>
        public bool ExistCamera(CameraInfo cameraInfo)
        {
            if (cameraInfo.DVSAddress == DVSAddress && cameraInfo.DVSNumber == DVSNumber)
            {
                if (dicCameras != null && dicCameras.Count > 0)
                {
                    foreach (KeyValuePair<int, CameraInfo> kv in Cameras)
                    {
                        if (
                                kv.Value.CameraName == cameraInfo.CameraName &&
                                kv.Value.Channel == cameraInfo.Channel
                            )
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        /// <summary>
        /// 是否存在摄像头
        /// </summary>
        public bool ExistCameraInfo()
        {
            if (dicCameras != null && Cameras.Count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
