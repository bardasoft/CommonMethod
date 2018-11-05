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
        SKVideo = 81,

        /// <summary>
        /// 华迈云视频类型
        /// </summary>
        HuaMaiVideo = 5,

        /// <summary>
        /// 安讯士
        /// </summary>
        Axis = 6,

       
        /// <summary>
        /// 雄迈视频SDK
        /// </summary>
        XMaiVideo=8,

        /// <summary>
        /// 蓝色星际
        /// </summary>
        BlueSky=9,

        /// <summary>
        /// 宇视视频
        /// </summary>
        IMOS=10,

        /// <summary>
        /// 时刻视频（H265）
        /// </summary>
        SKNVideo=11,
        /// <summary>
        /// 海康DVR 直接访问模式
        /// </summary>
        HikDVR = 12,

        /// <summary>
        /// 海康流媒体模式
        /// </summary>
        HikDVRStream = 13,

        /// <summary>
        /// 智诺视频
        /// </summary>
        ZLVideo = 82,
    }

    /// <summary>
    /// 录像类型
    /// 完成解析的类型
    /// 与视频类型对应
    /// </summary>
    public enum Enum_VIdeoRecordType
    {
        /// <summary>
        /// 未识别
        /// </summary>
        Unrecognized = 0,


        /// <summary>
        /// 安讯士
        /// </summary>
        Axis = 6,

        /// <summary>
        /// 雄迈
        /// </summary>
        XMaiVideo=8,
        /// <summary>
        /// 蓝色星际
        /// </summary>
        BlueSky=9,
        /// <summary>
        /// 海康DVS 直接访问模式
        /// </summary>
        HikDVR = 12,

        /// <summary>
        /// 海康流媒体模式
        /// </summary>
        HikStreamVideo=14,
        /// <summary>
        /// 智诺视频
        /// </summary>
        ZLVideoRecord = 82,
    }

    
    /// <summary>
    /// 录像文件类型
    /// </summary>
    public enum Enum_VideoRecordFileType
    {

        /// <summary>
        /// 未识别
        /// </summary>
        Unrecognized = 0,

        /// <summary>
        /// 音频文件
        /// </summary>
        Video = 1,

        /// <summary>
        /// 视频文件
        /// </summary>
        Audio = 2,
        /// <summary>
        /// 音视频文件
        /// </summary>
        VideoAndAudio = 3,
    }
}
