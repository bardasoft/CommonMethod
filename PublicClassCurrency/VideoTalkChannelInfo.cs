using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency
{
    public class VideoTalkChannelInfo
    {
        /// <summary>
        /// 视频设备信息
        /// </summary>
        public VideoInfo VideoInfo
        {
            get;
            set;
        }

        private int intVideoTalkChannelID = 0;

        /// <summary>
        /// 对讲通道ID
        /// </summary>
        public int VideoTalkChannelID
        {
            get { return intVideoTalkChannelID; }
            set { intVideoTalkChannelID = value; }
        }

        private int  intVideoTalkChannel = -1;
        /// <summary>
        /// 对讲通道号
        /// </summary>
        public int VideoTalkChannel
        {
            get { return intVideoTalkChannel; }
            set { intVideoTalkChannel = value; }
        }

        private string strVideoTalkChanneName = "";

        /// <summary>
        /// 对讲通道名称
        /// </summary>
        public string VideoTalkChannelName
        {
            get { return strVideoTalkChanneName; }
            set { strVideoTalkChanneName = value; }
        }

        private string strVideoTalkChannelTagInfo = "";

        /// <summary>
        /// 视频对讲通道标签信息 
        /// SK8616:表示门禁标签信息
        /// </summary>
        public string VideoTalkChannelTagInfo
        {
            get { return strVideoTalkChannelTagInfo; }
            set { strVideoTalkChannelTagInfo = value; }
        }
    }
}
