using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency
{
    /// <summary>
    /// 事件记录ID
    /// </summary>
    public class EventRecordID
    {
        /// <summary>
        /// 用户组号
        /// </summary>
        private string strUserGroupID;

        /// <summary>
        /// 用户组号
        /// </summary>
        public string UserGroupID
        {
            get { return strUserGroupID; }
            set { strUserGroupID = value; }
        }

        /// <summary>
        /// 主机编号
        /// </summary>
        private string strHostID;
        /// <summary>
        /// 主机编号
        /// </summary>
        public string HostID
        {
            get { return strHostID; }
            set { strHostID = value; }
        }

        /// <summary>
        /// 探头编号
        /// </summary>
        private string strProbeID = "";
        /// <summary>
        /// 探头编号
        /// </summary>
        public string ProbeID
        {
            get { return strProbeID; }
            set { strProbeID = value; }
        }
        
        /// <summary>
        /// 事件时刻
        /// </summary>
        private DateTime timEventTime;
        
        /// <summary>
        /// 事件时刻
        /// </summary>
        public DateTime EventTime
        {
            get { return timEventTime; }
            set { timEventTime = value; }
        }

        /// <summary>
        /// 事件内容
        /// </summary>
        private string strEventContent;

        /// <summary>
        /// 事件内容
        /// </summary>
        public string EventContent
        {
            get { return strEventContent; }
            set { strEventContent = value; }
        }
    }
}
