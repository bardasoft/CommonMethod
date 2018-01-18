using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency
{
    /// <summary>
    /// 设备类型
    /// </summary>
    public enum Enum_VideoType
    {
        /// <summary>
        /// 未识别
        /// </summary>
        Unrecognized = 0,

        /// <summary>
        /// 云视通主机
        /// </summary>
        CloundSee = 1,

        /// <summary>
        /// 普顺达设备 SK835
        /// </summary>
        IPCWA = 2,

        /// <summary>
        /// 萤石云
        /// </summary>
        Ezviz = 3,

        /// <summary>
        /// 时刻视频
        /// </summary>
        SKVideo = 4,

        /// <summary>
        /// 华迈云视频类型
        /// </summary>
        HuaMaiVideo = 5
    }
}
