using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency.Video
{
    public class VIdeoInfo_SK8519V:IVideoInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public bool GetStreamInfoEnable => true;

        /// <summary>
        /// 
        /// </summary>
        public string IPAddress { get; set; }
    }
}
