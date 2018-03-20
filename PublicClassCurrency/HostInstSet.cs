using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency
{

    /// <summary>
    /// 主机指令设置信息
    /// </summary>
    public class HostInstSet
    {
        /// <summary>
        /// 主机编号
        /// </summary>
        private string strHostID = "";
        /// <summary>
        /// 主机编号
        /// </summary>
        public string HostID
        {
            get { return strHostID; }
            set { strHostID = value; }
        }

        /// <summary>
        /// 指令地址
        /// </summary>
        private int intInstAddr;
        /// <summary>
        /// 指令地址
        /// </summary>
        public int InstAddr
        {
            get { return intInstAddr; }
            set { intInstAddr = value; }
        }

        /// <summary>
        /// 指令名称
        /// </summary>
        private string strInstName;
        /// <summary>
        /// 指令名称
        /// </summary>
        public string InstName
        {
            get { return strInstName; }
            set { strInstName = value; }
        }

        /// <summary>
        /// 指令内容
        /// </summary>
        public string strInstContent;
        /// <summary>
        /// 指令内容
        /// </summary>
        public string InstContent
        {
            get { return strInstContent; }
            set { strInstContent = value; }
        }

        /// <summary>
        /// 指令长度
        /// </summary>
        private int intInstLength;

        /// <summary>
        /// 指令长度
        /// </summary>
        public int InstLength
        {
            get { return intInstLength; }
            set { intInstLength = value; }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        private string strPrompt;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Prompt
        {
            get { return strPrompt; }
            set { strPrompt = value; }
        }
    }
}
