using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod
{
    /// <summary>
    /// 窗体位置计算及设置
    /// </summary>
    public class ScreenPosionCalculation
    {
        /// <summary>
        /// 获取点所在的屏幕索引号 不存在则返回-1
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static int ObtainScreenIndex(Point point)
        {
            int k = Screen.AllScreens.GetUpperBound(0);
            for (int i = 0; i <= k; i++)
            {
                Screen s = Screen.AllScreens[i];    //当前屏幕
                int intScreenMaxWidth = s.Bounds.Location.X + s.Bounds.Width;       //当前屏幕最大宽度
                int intScreenMacHeight = s.Bounds.Location.Y + s.Bounds.Height;     //当前屏幕最大高度
                if (point.X >= s.Bounds.Location.X && point.X < intScreenMaxWidth && point.Y >= s.Bounds.Location.Y && point.Y < intScreenMacHeight)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获取窗体中心点
        /// </summary>
        /// <param name="pointFormTopRightCorner"></param>
        /// <param name="sizeForm"></param>
        /// <returns></returns>
        public static Point GetFormCenterPosition(Point pointFormTopRightCorner, Size sizeForm)
        {
            Point pointFormCenter = new Point();
            pointFormCenter.X = pointFormTopRightCorner.X + (sizeForm.Width / 2);
            pointFormCenter.Y = pointFormTopRightCorner.Y + (sizeForm.Height / 2);
            return pointFormCenter;
        }

        /// <summary>
        /// 窗体居中在屏幕中居中显示的位置
        /// </summary>
        /// <param name="intScreenIndex">屏幕索引号</param>
        /// <param name="intWindowWidth">窗体宽度</param>
        /// <param name="intWindowsHeight">窗体高度</param>
        /// <param name="result">显示位置</param>
        /// <returns>1.数据正常 2.屏幕索引号不存在 3.窗体宽度高度 大于屏幕宽度高度</returns>
        public static int CenterDisplayPosition(int intScreenIndex, int intWindowWidth, int intWindowsHeight, out Point result)
        {
            result = new Point();
            int k = Screen.AllScreens.GetUpperBound(0);
            if (k < intScreenIndex) //屏幕索引号不存在
            {
                return 2;
            }

            Screen s = Screen.AllScreens[intScreenIndex];
            int Temp_intScreensWidth = s.Bounds.Width / 2;
            int Temp_intScreensHeight = s.Bounds.Height / 2;
            int Temp_intFormWidth = intWindowWidth / 2;
            int Temp_intFormHeight = intWindowsHeight / 2;

            int Temp_intFormStartPositionX = Temp_intScreensWidth - Temp_intFormWidth;
            int Temp_intFormStartPositionY = Temp_intScreensHeight - Temp_intFormHeight;

            if ((s.Bounds.Width < intWindowWidth) || (s.Bounds.Height < intWindowsHeight))    //窗体宽度高度 大于屏幕宽度高度
            {
                if (s.Bounds.Width < intWindowWidth)
                {
                    result.X = s.Bounds.Location.X;
                }
                else
                {
                    result.X = s.Bounds.Location.X + Temp_intFormStartPositionX;
                }
                if (s.Bounds.Height < intWindowsHeight)
                {
                    result.Y = s.Bounds.Location.Y;
                }
                else
                {
                    result.Y = s.Bounds.Location.Y + Temp_intFormStartPositionY;
                }
                return 3;
            }
            result = new Point(s.Bounds.Location.X + Temp_intFormStartPositionX, s.Bounds.Location.Y + Temp_intFormStartPositionY);
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intScreenIndex"></param>
        /// <param name="fm"></param>
        /// <returns>1.设置成功 2.屏幕索引号不存在 3.窗体宽度高度 大于屏幕宽度高度</returns>
        public static int SetFormDisplayPosition(int intScreenIndex,Form fm)
        {
            Point result = new Point();
            int intWindowWidth = fm.Width;
            int intWindowsHeight = fm.Height;
            int k = Screen.AllScreens.GetUpperBound(0);
            if (k < intScreenIndex) //屏幕索引号不存在
            {
                return 2;
            }

            Screen s = Screen.AllScreens[intScreenIndex];
            int Temp_intScreensWidth = s.Bounds.Width / 2;
            int Temp_intScreensHeight = s.Bounds.Height / 2;
            int Temp_intFormWidth = intWindowWidth / 2;
            int Temp_intFormHeight = intWindowsHeight / 2;

            int Temp_intFormStartPositionX = Temp_intScreensWidth - Temp_intFormWidth;
            int Temp_intFormStartPositionY = Temp_intScreensHeight - Temp_intFormHeight;

            if ((s.Bounds.Width < intWindowWidth) || (s.Bounds.Height < intWindowsHeight))    //窗体宽度高度 大于屏幕宽度高度
            {
                if (s.Bounds.Width < intWindowWidth)
                {
                    result.X = s.Bounds.Location.X;
                }
                else
                {
                    result.X = s.Bounds.Location.X + Temp_intFormStartPositionX;
                }
                if (s.Bounds.Height < intWindowsHeight)
                {
                    result.Y = s.Bounds.Location.Y;
                }
                else
                {
                    result.Y = s.Bounds.Location.Y + Temp_intFormStartPositionY;
                }
                return 3;
            }
            result = new Point(s.Bounds.Location.X + Temp_intFormStartPositionX, s.Bounds.Location.Y + Temp_intFormStartPositionY);
            fm.DesktopLocation = result;
            return 1;
        }

        public void TEST()
        {
            MessageBox.Show("1");
        }
    }
}
