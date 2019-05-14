using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency.Video
{
    public class VideoStream
    {

        CameraInfo Channel
        {
            get;
            set;
        }
        /// <summary>
        /// 码流类型
        /// 1主 2子 3第三码流
        /// </summary>
        int intStreamType = 1;
        public int StreamType
        {
            get { return intStreamType; }
            set { intStreamType = value; }
        }


        private int intResolutionWidth;

        /// <summary>
        /// 码流_宽
        /// </summary>
        public int ResolutionWidth
        {
            get { return intResolutionWidth; }
            set { intResolutionWidth = value; }
        }

        private int intResolutionHeight;

        /// <summary>
        /// 码流_高
        /// </summary>
        public int ResolutionHeight
        {
            get { return intResolutionHeight; }
            set { intResolutionHeight = value; }
        }


        private int intFPS;
        /// <summary>
        /// 帧率
        /// </summary>
        public int FPS
        {
            get { return intFPS; }
            set { intFPS = value; }
        }

        private int intBitrate;
        /// <summary>
        /// 码流
        /// </summary>
        public int Bitrate
        {
            get { return intBitrate; }
            set { intBitrate = value; }
        }
    }
}
