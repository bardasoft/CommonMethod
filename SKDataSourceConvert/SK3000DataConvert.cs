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
            string Temp_strValue = "";
            string[] Temp_strsValue;
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
            //独立视频服务器信息
            Temp_strValue = Convert.ToString(drVideoInfo["DVSPTZProtocol"]);
            Temp_strsValue = Temp_strValue.Split(':');
            if (Temp_strsValue.Length == 2
                && CommonMethod.Verification.isIP(Temp_strsValue[0])
                && CommonMethod.Verification.isNumber(Temp_strsValue[1]))
            {
                videoInfo.VideoServerEnable = true;
                videoInfo.VideoServerIP = Temp_strsValue[0];
                videoInfo.VideoServerPort = Convert.ToInt32(Temp_strValue[1]);
            }
            else
            {
                videoInfo.VideoServerEnable = false;
            }
            videoInfo.VideoType = GetVideoTypeByVideoTypeName(videoInfo.DVSType);
            videoInfo.IntercomEnable = GetIntercomEnableByVideoTypeName(videoInfo.DVSType);
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
                case "SK8600":
                    videoInfo.OnlyIntercom = true;
                    videoInfo.PTZControlEnable = false;
                    break;
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
                case "SK8516ZL":
                case "SK8532ZL":
                for (int i = 1; i <= videoInfo.DVSChannelNum; i++)
                {
                    if (strsCameraInfo.Length >= i && !string.IsNullOrEmpty(strsCameraInfo[i - 1]))
                    {
                        //171911 修正 通道从1 开始 ,摄像头名称依然从1 开始
                        videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i - 1]);

                    }
                }
                break;

                case "SK8616H":     //仅8路模拟
                    for (int i = 1; i <= videoInfo.DVSChannelNum; i++)
                    {
                        if ((i > 8) && !string.IsNullOrEmpty(strsCameraInfo[i]))
                        {
                            videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i-1]);
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


        /// <summary>
        /// 使用视频设备类型名称获取视频设备类型
        /// </summary>
        /// <param name="strVideoTypeName"></param>
        /// <returns></returns>
        public static Enum_VideoType GetVideoTypeByVideoTypeName(string strVideoTypeName)
        {
            Enum_VideoType result = Enum_VideoType.Unrecognized;
            if (strVideoTypeName.EndsWith("ZW") || strVideoTypeName == "SK838")
            {
                //云视通设备
                result = Enum_VideoType.CloundSee;
            }
            else if (strVideoTypeName.Contains("IPCWA") || strVideoTypeName.Contains("SK835"))
            {
                result = Enum_VideoType.IPCWA;
            }
            else if (strVideoTypeName.EndsWith("YS"))
            {
                result = Enum_VideoType.Ezviz;
            }
            else if (strVideoTypeName.EndsWith("HM"))  //180117 华迈设备
            {
                result = Enum_VideoType.HuaMaiVideo;
            }
            else if (strVideoTypeName == "AXISM3037")
            {
                result = Enum_VideoType.Axis;
            }
            else if (strVideoTypeName.EndsWith("XM")
                    || strVideoTypeName == "SK838C"
                    || strVideoTypeName == "SK836C")
            {
                result = Enum_VideoType.XMaiVideo;
            }
            else if (strVideoTypeName.StartsWith("BSRNR"))
            {
                result = Enum_VideoType.BlueSky;

            }
            else if (strVideoTypeName.Trim() == "SK8616H")
            {
                result = Enum_VideoType.SKNVideo;      //181018 时刻h265
            }
            else if (SK3000TransitionSet.SKVideoTypeAssignmentEnable
                    && (strVideoTypeName.StartsWith("SK86")
                    || strVideoTypeName.StartsWith("SK519")
                    || strVideoTypeName.StartsWith("SK8519")
                    || (strVideoTypeName == "SK836")))
            {
                result = Enum_VideoType.SKVideo;
            }
            else if (SK3000TransitionSet.HikVideoTypeAssignmentEnable
                    && (strVideoTypeName.EndsWith("HA")))
            {
                result = Enum_VideoType.HikDVR;
            }
            else if (strVideoTypeName.EndsWith("ZL"))
            {
                result = Enum_VideoType.ZLVideo;
            }
            else
            {
                result = Enum_VideoType.Unrecognized;
            }

            return result;
        }

        /// <summary>
        /// 使用视频设备类型名称获取设备是否支持对讲
        /// </summary>
        /// <param name="strVideoTypeName"></param>
        /// <returns></returns>
        public static bool GetIntercomEnableByVideoTypeName(string strVideoTypeName)
        {
            bool bolResult = false;
            switch (strVideoTypeName)
            {
                case "SK8601":
                case "SK8604":
                case "SK8608":
                case "SK8616":
                case "SK8632":
                case "SK519V":
                case "SK8519V":
                case "SK8616H":
                    bolResult = true;
                    break;
            }
            return bolResult;
        }

        public static Byte GetIdentityTypeValueByVideoTypeName(string strVideoTypeName)
        {
            bool Temp_bolIPEnable = false;
            bool Temp_bolUniqueCpdeEnable = false;

            switch (strVideoTypeName)
            {
                default:
                    break;
            }
            byte result = Convert.ToByte((Temp_bolIPEnable ? 1 : 0) + (Temp_bolUniqueCpdeEnable ? 2 : 0));
            return result;
        }


        public static bool GetPTZControlByVideoTypeName(string strVideoTypeName)
        {
            bool bolResult = true;
            switch (strVideoTypeName)
            {

            }
            return bolResult;
        }

        public static bool GetPTZControlByVideoType(Enum_VideoType videoType)
        {
            bool bolResult = true;
            switch (videoType)
            {
                case Enum_VideoType.SKNVideo:

                    break;
            }
            return bolResult;
        }
    }
}
