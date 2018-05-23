using PublicClassCurrency;
using SKDataSourceConvert.SK3000FieldName;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SKDataSourceConvert
{

    /// <summary>
    /// SK3000数据转换
    /// </summary>
    public class SK3000DataConvert
    {
        /// <summary>
        /// 视频信息_数据行转为VideoInfo
        /// </summary>
        /// <param name="drVideoInfo"></param>
        /// <returns></returns>
        public static VideoInfo VideoInfo_DataRowToVideoInfo(DataRow drVideoInfo)
        {
            VideoInfo v = new VideoInfo();
            v = GetVideoInfo_ByDataRow(drVideoInfo);
            return v;
        }

        #region 视频信息相关
        private static VideoInfo GetVideoInfo_ByDataRow(DataRow drVideoInfo)
        {
            VideoInfo videoInfo = new VideoInfo();
            string dvsNumber = Convert.ToString(drVideoInfo["DVSNumber"]);
            string cameras1 = Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo1]);
            string cameras2 = Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo2]);
            string cameras3 = Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo3]);
            string cameras4 = Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo4]);

            StringBuilder sbCameraInfos = new StringBuilder();
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo1]) + "$");
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo2]) + "$");
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo3]) + "$");
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo4]) + "$");
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo5]) + "$");
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo6]) + "$");
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo7]) + "$");
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo8]) + "$");
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo9]) + "$");
            sbCameraInfos.Append(Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_CamerasInfo10]));
            videoInfo.DVSNumber = dvsNumber;
            videoInfo.HostID = Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_HostID]);
            videoInfo.DVSName = Convert.ToString(drVideoInfo["DVSName"]);
            videoInfo.DVSAddress = Convert.ToString(drVideoInfo["DVSAddress"]);
            videoInfo.DVSConnectPort = Convert.ToInt32(drVideoInfo[TVideoTable_FieldName.c_strFieldName_DVSControlPort]);
            videoInfo.DVSDataPort = Convert.ToInt32(drVideoInfo[TVideoTable_FieldName.c_strFieldName_DVSStreamPort]);
            videoInfo.DVSChannelNum = Convert.ToInt32(drVideoInfo[TVideoTable_FieldName.c_strFieldName_DVSChannelNum]);
            videoInfo.DVSType = Convert.ToString(drVideoInfo["DVSType"]);
            videoInfo.UserName = Convert.ToString(drVideoInfo["UserName"]);
            videoInfo.Password = Convert.ToString(drVideoInfo["PassWord"]);
            #region 新版本视频控件兼容类型判断
            if (videoInfo.DVSType.EndsWith("ZW") || videoInfo.DVSType == "SK838")
            {
                //云视通设备
                videoInfo.VideoType = Enum_VideoType.CloundSee;
            }
            else if (videoInfo.DVSType.Contains("IPCWA") || videoInfo.DVSType.Contains("SK835"))
            {
                videoInfo.VideoType = Enum_VideoType.IPCWA;
            }
            else if (videoInfo.DVSType.EndsWith("YS"))
            {
                videoInfo.VideoType = Enum_VideoType.Ezviz;
            }
            else if (videoInfo.DVSType.EndsWith("HM"))  //180117 华迈设备
            {
                videoInfo.VideoType = Enum_VideoType.HuaMaiVideo;
            }
            else if (videoInfo.DVSType == "AXISM3037")
            {
                videoInfo.VideoType = Enum_VideoType.Axis;
            }
            else if (videoInfo.DVSType.EndsWith("XM")
                    || videoInfo.DVSType == "SK838C"
                    || videoInfo.DVSType == "SK836C")
            {
                videoInfo.VideoType = Enum_VideoType.XMaiVideo;
            }
            else if (videoInfo.DVSType.StartsWith("BSRNR"))
            {
                videoInfo.VideoType = Enum_VideoType.BlueSky;
                
            }
            else if (SK3000TransitionSet.SKVideoTypeAssignmentEnable
                    && (videoInfo.DVSType.StartsWith("SK86")
                    || videoInfo.DVSType.StartsWith("SK519")
                    || videoInfo.DVSType.StartsWith("SK8519")
                    || (videoInfo.DVSType == "SK836")))
            {
                videoInfo.VideoType = Enum_VideoType.SKVideo;
                videoInfo.IntercomEnable = !(videoInfo.DVSType == "SK836");
            }
            else if (SK3000TransitionSet.HikVideoTypeAssignmentEnable
                    && (videoInfo.DVSType.EndsWith("HA")))
            {
                videoInfo.VideoType = Enum_VideoType.HikDVR;
            }
            else
            {
                videoInfo.VideoType = Enum_VideoType.Unrecognized;
            }
            #endregion

            try
            {
                videoInfo.NetworkState = Convert.ToInt32(drVideoInfo["Reserver3"]);
            }
            catch
            {
                videoInfo.NetworkState = -1; //状态未明
            }
            //170801  视频预览密码
            videoInfo.PreviewPwd = Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_PreviewPwd]);

            //170801 播放时间设置
            string Temp_strVideoPlayTime = Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_VideoPlayTime]);
            if (CommonMethod.Verification.isNumber(Temp_strVideoPlayTime) && !string.IsNullOrEmpty(Temp_strVideoPlayTime))
            {
                videoInfo.VideoPlayTime_Minute = Convert.ToInt32(Temp_strVideoPlayTime);
            }

            string strTempAutoIntercom = Convert.ToString(drVideoInfo[TVideoTable_FieldName.c_strFieldName_AutoIntercom]);
            if (CommonMethod.Verification.isNumber(strTempAutoIntercom))
            {
                videoInfo.AutoIntercom = Convert.ToInt32(strTempAutoIntercom);
            }
            videoInfo = SetVideoCameraInfo(videoInfo, sbCameraInfos.ToString());
            return videoInfo;
        }

        private static VideoInfo SetVideoCameraInfo(VideoInfo videoInfo, string strCameraInfos)
        {
            string[] strsCameraInfo = strCameraInfos.Split('$');
            if (strsCameraInfo.Length == 0)
            {
                return videoInfo;
            }
            videoInfo.Cameras = new Dictionary<int, CameraInfo>();
            switch (videoInfo.DVSType)
            {
                case "SK8601":
                case "SK8604":
                case "SK8608":
                case "SK8612":
                case "SK8616":
                case "SK8632":
                    //4路模拟(0,1,2,3) 8路数字（8,9,10,11,12,13,14,15）
                    for (int i = 0; i < strsCameraInfo.Length; i++)
                    {
                        if (videoInfo.DVSChannelNum <= i)
                        {
                            break;
                        }
                        if ((i < 4 || i > 7) && !string.IsNullOrEmpty(strsCameraInfo[i]))
                        {
                            videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i]);
                        }
                    }
                    break;

                case "SK519V":
                case "SK8519V":
                    //1路模拟(0)  3路数字(8,9,10)
                    for (int i = 0; i < strsCameraInfo.Length; i++)
                    {
                        if (videoInfo.DVSChannelNum <= i)
                        {
                            break;
                        }
                        if ((i == 0 || i == 8 || i == 9 || i == 10) && !string.IsNullOrEmpty(strsCameraInfo[i]))
                        {
                            videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i]);
                        }
                    }
                    break;

                case "SK836":
                    //1路模拟(0)
                    for (int i = 0; i < strsCameraInfo.Length; i++)
                    {
                        if (videoInfo.DVSChannelNum <= i)
                        {
                            break;
                        }
                        if (i == 0 && !string.IsNullOrEmpty(strsCameraInfo[i]))
                        {
                            videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i]);
                            break;
                        }
                    }
                    break;
                //从第一路开始
                case "SK8501ZW":    //SK838 云视通  
                case "SK8504ZW":
                case "SK8508ZW":
                case "SK8516ZW":
                case "SK8501YS":    //萤石云 从第一路开始
                case "SK8504YS":
                case "SK8508YS":
                case "SK8516YS":
                case "SK8504HA":    //海康视频 从第一路开始
                case "SK8508HA":
                case "SK8516HA":
                case "SK8532HA":
                case "SK8564HA":
                case "BSRNR01":  //蓝色星际
                case "BSRNR04":
                case "BSRNR08":
                case "BSRNR16":
                case "BSRNR32":
                case "BSRNR64":
                case "AXISM3037":
                    for (int i = 1; i <= videoInfo.DVSChannelNum; i++)
                    {
                        if (strsCameraInfo.Length >= i && !string.IsNullOrEmpty(strsCameraInfo[i]))
                        {
                            //171911 修正 通道从1 开始 ,摄像头名称依然从1 开始
                            videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i - 1]);

                        }
                    }
                    break;

                case "SK838C":
                case "SK836C":
                    for (int i = 0; i < videoInfo.DVSChannelNum; i++)
                    {
                        if (strsCameraInfo.Length >= i && !string.IsNullOrEmpty(strsCameraInfo[i]))
                        {
                            videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i]);
                        }
                    }
                    break;

                default:
                    //其余设备按照通道数量区摄像头信息 下标从0开始
                    for (int i = 0; i < strsCameraInfo.Length; i++)
                    {
                        if (videoInfo.DVSChannelNum <= i)
                        {
                            break;
                        }
                        if (!string.IsNullOrEmpty(strsCameraInfo[i]))
                        {
                            videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i]);
                        }
                    }
                    break;
            }
            return videoInfo;
        }

        private static CameraInfo GetCameraInfo(VideoInfo v, int intChannel, string strCameraName)
        {
            CameraInfo c = new CameraInfo();
            c.DVSNumber = v.DVSNumber;
            c.DVSType = v.DVSType;
            c.DVSAddress = v.DVSAddress;
            c.Channel = intChannel;
            c.CameraName = strCameraName;
            return c;
        }

        #endregion
    }
}
