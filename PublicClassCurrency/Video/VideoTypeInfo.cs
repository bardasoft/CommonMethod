using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency.Video
{
    public class VideoTypeInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public int VideoTypeID
        {
            get;
            set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string VideoTypeValue
        {
            get;
            set;
        }


        private PublicClassCurrency.Enum_VideoType videoType ;
        /// <summary>
        /// 视频设备类型 对应
        /// </summary>
        public  PublicClassCurrency.Enum_VideoType VideoType
        {
            get { return videoType; }
            set { videoType = value; }
        }


        /// <summary>
        /// 类型名称
        /// </summary>

        public string VideoTypeName
        {
            get;
            set;
        }

        /// <summary>
        /// 类型描述
        /// </summary>
        public string VideoTypeDescribe
        {
            get;
            set;
        }

        /// <summary>
        /// 通道数量
        /// </summary>
        public int ChannelNum
        {
            get;
            set;
        }

        /// <summary>
        /// 码流端口
        /// </summary>
        public UInt16 StreamPort
        {
            get;
            set;
        }

        /// <summary>
        /// 连接端口
        /// </summary>
        public UInt16 ConnectPort
        {
            get;
            set;
        }

        /// <summary>
        /// 通道模型
        /// </summary>
        public List<PublicClassCurrency.CameraInfo> CameraModel
        {
            get;
            set;
        }

        /// <summary>
        /// 对讲通道模型
        /// </summary>
        public List<PublicClassCurrency.VideoTalkChannelInfo> TalkChannelModel
        {
            get;
            set;
        }



        private bool bolVideoTypeVerificationEnable = false;

        /// <summary>
        /// 视频设备类型 验证（添加/更新）功能是否启用
        /// </summary>
        public bool VideoTypeVerificationEnable
        {
            get { return bolVideoTypeVerificationEnable; }
            set { bolVideoTypeVerificationEnable = value; }
        }

        private int intConnParaType = 1;

        /// <summary>
        /// 连接参数类型 
        /// 1：IP
        /// 2: 唯一码
        /// </summary>
        public int ConnParaType
        {
            get { return intConnParaType; }
            set { intConnParaType = value; }
        }

    }
}
