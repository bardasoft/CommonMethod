﻿using System;
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


        #region 视频类型验证

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

        /// <summary>
        /// 支持485透传功能
        /// </summary>
        private bool bolSupport458Data = false;
        /// <summary>
        /// 支持485透传功能
        /// </summary>
        public bool Support458Data
        {
            get { return bolSupport458Data; }
            set { bolSupport458Data = value; }
        }


        /// <summary>
        /// 支持解析IP
        /// </summary>
        private bool bolSupportParsingIP = false;
        /// <summary>
        /// 支持解析IP
        /// </summary>
        public bool SupportParsingIP
        {
            get { return bolSupportParsingIP; }
            set { bolSupportParsingIP = value; }
        }


        /// <summary>
        /// 支持811解析
        /// </summary>
        private bool bolSupportParsing811 = false;
        /// <summary>
        /// 支持811解析
        /// </summary>
        public bool SupportParsing811
        {
            get { return bolSupportParsing811; }
            set { bolSupportParsing811 = value; }
        }

        /// <summary>
        /// 支持直连设置
        /// </summary>
        private bool bolSupportDirectSet = false;

        /// <summary>
        /// 支持直连设置
        /// </summary>
        public bool SupportDirectSet
        {
            get { return bolSupportDirectSet; }
            set { bolSupportDirectSet = value; }
        }

        /// <summary>
        /// 支持云台协议设置
        /// </summary>
        private bool bolSupportPTZProtoclSet = false;

        /// <summary>
        /// 支持云台协议设置
        /// </summary>
        public bool SupportPTZProtoclSet
        {
            get { return bolSupportPTZProtoclSet; }
            set { bolSupportPTZProtoclSet = value; }
        }

        /// <summary>
        /// 需要输入控制端口
        /// </summary>
        private bool bolNeedEnterControlPort = false;
        /// <summary>
        /// 需要输入控制端口
        /// </summary>
        public bool NeedEnterControlPort
        {
            get { return bolNeedEnterControlPort; }
            set { bolNeedEnterControlPort = value; }
        }

        /// <summary>
        /// 需要输入数据端口
        /// </summary>
        private bool bolNeedEnterStreamPort = false;
        /// <summary>
        /// 需要输入数据端口
        /// </summary>
        public bool NeedEnterStreamPort
        {
            get { return bolNeedEnterStreamPort; }
            set { bolNeedEnterStreamPort = value; }
        }


        private bool bolIPAddressEntryEnable = false;

        /// <summary>
        /// IP地址输入使能（仅记录，不产生效果）
        /// </summary>
        public bool IPAddressEntryEnable
        {
            get
            {
                return bolIPAddressEntryEnable;
            }
            set
            {
                bolIPAddressEntryEnable = value;
            }
        }

        #endregion

    }
}
