using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency.Video
{
    public interface IVideoInfo
    {
        /// <summary>
        /// 获取码流信息使能
        /// </summary>
        bool GetStreamInfoEnable
        {
            get;
        }
    }
}
