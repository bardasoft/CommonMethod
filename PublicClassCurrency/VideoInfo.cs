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

        #region 设备基本信息

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
        private int intDVSConnectPort = 0;
        /// <summary>
        /// DVS连接端口
        /// SK3000:DVSControlPort
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
        /// DVS数据端口
        /// SK3000:DVSStreamPort
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
        private int intVideoPlayTime_Minute = 0;

        /// <summary>
        /// 视频播放时间限制_分 0代表无限制
        /// </summary>
        public int VideoPlayTime_Minute
        {
            get { return intVideoPlayTime_Minute; }
            set { intVideoPlayTime_Minute = value; }
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

        private Dictionary<int, VideoTalkChannelInfo> dicTalkChannel = new Dictionary<int, VideoTalkChannelInfo>();
        /// <summary>
        /// 对讲通道信息
        /// </summary>
        public Dictionary<int, VideoTalkChannelInfo> TalkChannel
        {
            get { return dicTalkChannel; }
            set { dicTalkChannel = value; }
        }
        #endregion

        #region 服务器相关信息（部分设备独立配置服务器，以满足客户部分特殊需求）

        private bool bolVideoServerEnable = false;
        /// <summary>
        /// 视频服务器是否启用
        /// SK3000:DVSPTZProtocol[IP:Port]
        /// </summary>
        public bool VideoServerEnable
        {
            get { return bolVideoServerEnable; }
            set { bolVideoServerEnable = value; }
        }



        private string strVideoServerIP;

        /// <summary>
        /// 视频服务器IP
        /// SK3000:DVSPTZProtocol[IP:Port]
        /// </summary>
        public string VideoServerIP
        {
            get { return strVideoServerIP; }
            set { strVideoServerIP = value; }
        }

        private int intVideoServerPort;

        /// <summary>
        /// 视频服务器端口
        /// SK3000:DVSPTZProtocol[IP:Port]
        /// </summary>
        public int VideoServerPort
        {
            get { return intVideoServerPort; }
            set { intVideoServerPort = value; }
        }



        #endregion

        #region 设备功能

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

        /// <summary>
        /// 云台控制使能
        /// </summary>
        private bool bolPTZControlEnable = true;

        /// <summary>
        /// 云台控制使能
        /// </summary>
        public bool PTZControlEnable
        {
            get { return bolPTZControlEnable; }
            set { bolPTZControlEnable = value; }
        }

        #endregion

        #region 设备状态
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
        /// 设备登陆状态 -1表示登陆失败 0表示未登录  1表示已登陆  2表示登陆中
        /// </summary>
        private int intLoginState;

        /// <summary>
        /// 设备登陆状态 -1表示登陆失败 0表示未登录  1表示已登陆  2表示登陆中
        /// </summary>
        public int LoginState
        {
            get { return intLoginState; }
            set
            {
                if (intLoginState != value)
                {
                    intLoginState = value;
                    VideoLoginStateChanged(null);
                }
            }
        }
        private string strLoginPrompt = "";

        /// <summary>
        /// 登陆提示
        /// </summary>
        public string LoginPrompt
        {
            get { return strLoginPrompt; }
            set { strLoginPrompt = value; }
        }
        /// <summary>
        /// 设备登陆句柄
        /// </summary>
        private int intLoginHandle;

        /// <summary>
        /// 设备登陆句柄
        /// </summary>
        public int LoginHandle
        {
            get { return intLoginHandle; }
            set { intLoginHandle = value; }
        }
        
        #endregion

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

        #region 事件与委托

        public delegate void VideoLoginStateChangedDelegate(object sender, object VideoLoginStateChangedValue);
        /// <summary>
        /// 用户登陆状态改变事件
        /// </summary>
        public event VideoLoginStateChangedDelegate VideoLoginStateChangeEvent;
        public void VideoLoginStateChanged(object VideoLoginStateChangedValue)
        {
            if (VideoLoginStateChangeEvent != null)
            {
                VideoLoginStateChangeEvent(this, VideoLoginStateChangedValue);
            }
        }
        #endregion
    }
}
