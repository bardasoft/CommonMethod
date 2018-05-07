using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace CommonMethod
{
    /// <summary>
    /// 获取系统信息
    /// </summary>
    public class GetSystemInfo
    {
        public static string GetMACAddress()
        {
            try
            {
                string strMac = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        strMac = mo["MacAddress"].ToString();
                    }
                }
                moc = null;
                mc = null;
                return strMac;
            }
            catch
            {
                return "unknown";
            }
        }
    }
}
