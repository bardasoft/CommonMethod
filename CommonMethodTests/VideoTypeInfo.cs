using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethodTests
{

    /// <summary>
    /// 视频设备类型
    /// </summary>
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

        private PublicClassCurrency.Enum_VideoType videoType = PublicClassCurrency.Enum_VideoType.Unrecognized;
        /// <summary>
        /// 视频设备类型 对应
        /// </summary>
        public PublicClassCurrency.Enum_VideoType VideoType
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
        List<PublicClassCurrency.CameraInfo> CameraModel
        {
            get;
            set;
        }
    }
}
