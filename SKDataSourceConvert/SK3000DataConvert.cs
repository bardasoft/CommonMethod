using PublicClassCurrency;
using System;
using System.Collections.Generic;
using System.Text;

namespace SKDataSourceConvert
{
    public class SK3000DataConvert
    {
        public static VideoInfo VideoInfo_DataRowToVideoInfo()
        {
            VideoInfo v = new VideoInfo();

            return v;
        }

        #region 视频信息相关
        private static PublicClassCurrency.VideoInfo GetVideoInfo_ByDataRow(DataRow drVideoInfo)
        {
            PublicClassCurrency.VideoInfo videoInfo = new PublicClassCurrency.VideoInfo();
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
            videoInfo.DVSChannelNum = Convert.ToInt32(drVideoInfo[TVideoTable_FieldName.c_strFieldName_DVSChannelNum]);
            videoInfo.DVSType = Convert.ToString(drVideoInfo["DVSType"]);
            videoInfo.UserName = Convert.ToString(drVideoInfo["UserName"]);
            videoInfo.Password = Convert.ToString(drVideoInfo["PassWord"]);
            #region 新版本视频控件兼容类型判断
            if (videoInfo.DVSType.EndsWith("ZW") || videoInfo.DVSType == "SK838")
            {
                //云视通设备
                videoInfo.VideoType = PublicClassCurrency.Enum_VideoType.CloundSee;
            }
            else if (videoInfo.DVSType.Contains("IPCWA") || videoInfo.DVSType.Contains("SK835"))
            {
                videoInfo.VideoType = PublicClassCurrency.Enum_VideoType.IPCWA;
            }
            else if (videoInfo.DVSType.EndsWith("YS"))
            {
                videoInfo.VideoType = PublicClassCurrency.Enum_VideoType.Ezviz;
            }
            else if (videoInfo.DVSType.EndsWith("HM"))  //180117 华迈设备
            {
                videoInfo.VideoType = PublicClassCurrency.Enum_VideoType.HuaMaiVideo;
            }
            else if (videoInfo.DVSType.StartsWith("SK86") || videoInfo.DVSType.StartsWith("SK519") || videoInfo.DVSType.StartsWith("SK8519"))
            {
                if (SystemSetting_VideoPlay.SKVideoNewModeEnable == 1)
                {
                    videoInfo.VideoType = PublicClassCurrency.Enum_VideoType.SKVideo;
                    videoInfo.IntercomEnable = true;
                }
                else
                {
                    videoInfo.VideoType = PublicClassCurrency.Enum_VideoType.Unrecognized;
                }

            }
            else if (videoInfo.DVSType.StartsWith("SK836"))
            {
                if (SystemSetting_VideoPlay.SKVideoNewModeEnable == 1)
                {
                    videoInfo.VideoType = PublicClassCurrency.Enum_VideoType.SKVideo;
                }
                else
                {
                    videoInfo.VideoType = PublicClassCurrency.Enum_VideoType.Unrecognized;
                }
            }
            else
            {
                videoInfo.VideoType = PublicClassCurrency.Enum_VideoType.Unrecognized;
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

        private static PublicClassCurrency.VideoInfo SetVideoCameraInfo(PublicClassCurrency.VideoInfo videoInfo, string strCameraInfos)
        {
            string[] strsCameraInfo = strCameraInfos.Split('$');
            if (strsCameraInfo.Length == 0)
            {
                return videoInfo;
            }
            videoInfo.Cameras = new Dictionary<int, PublicClassCurrency.CameraInfo>();
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
                        if ((i == 0 || i == 8 || i == 9 || i == 10) && (!string.IsNullOrEmpty(strsCameraInfo[i])))
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
                        if (i == 0 && (!string.IsNullOrEmpty(strsCameraInfo[i])))
                        {
                            videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i]);
                            break;
                        }
                    }
                    break;
                case "SK8501ZW":    //SK838 云视通  从第一路开始
                case "SK8504ZW":
                case "SK8508ZW":
                case "SK8516ZW":
                case "SK8501YS":    //萤石云 从第一路开始
                case "SK8504YS":
                case "SK8508YS":
                case "SK8516YS":
                    for (int i = 1; i <= videoInfo.DVSChannelNum; i++)
                    {
                        if (strsCameraInfo.Length >= i)
                        {
                            //171911 修正 通道从1 开始 ,摄像头名称依然从1 开始
                            videoInfo.Cameras[i] = GetCameraInfo(videoInfo, i, strsCameraInfo[i - 1]);

                        }
                    }
                    break;
                default:
                    //其余设备按照通道数量区摄像头信息
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

        private static PublicClassCurrency.CameraInfo GetCameraInfo(PublicClassCurrency.VideoInfo v, int intChannel, string strCameraName)
        {
            PublicClassCurrency.CameraInfo c = new PublicClassCurrency.CameraInfo();
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
