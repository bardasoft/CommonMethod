using System;
using System.Collections.Generic;
using System.Text;

namespace CommonMethod
{
    /// <summary>
    /// 公用对象
    /// </summary>
    public class CommonObject
    {
        /// <summary>
        /// 170120 ComboBox Item
        /// value 表示键 display表示显示的值
        /// </summary>
        public class ComboBoxItem
        {
            /// <summary>
            /// ComboBox控件Item
            /// </summary>
            /// <param name="value"></param>
            /// <param name="display"></param>
            public ComboBoxItem(object value, string display)
            {
                this.ItemValue = value;
                this.ItemDisplay = display;
            }

            /// <summary>
            /// Item 键
            /// </summary>
            object itemValue;

            /// <summary>
            /// Item 键
            /// </summary>
            public object ItemValue
            {
                get { return itemValue; }
                set { itemValue = value; }
            }

            /// <summary>
            /// Item 值
            /// </summary>
            string itemDisplay;
            /// <summary>
            /// Item 值
            /// </summary>
            public string ItemDisplay
            {
                get { return itemDisplay; }
                set { itemDisplay = value; }
            }

            /// <summary>
            /// 重写 ToString() 方法
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return ItemDisplay;
            }
        }
        #region Area

        /// <summary>
        /// 显示对象
        /// </summary>
        public class Area
        {
            /// <summary>
            /// Area 键
            /// </summary>
            private string m_Area_Value;
            /// <summary>
            /// Area 键
            /// </summary>
            public string Area_Value
            {
                get { return m_Area_Value; }
                set { m_Area_Value = value; }
            }

            /// <summary>
            /// Area 值
            /// </summary>
            private string m_Area_Display;
            /// <summary>
            /// Area 值
            /// </summary>
            public string Area_Display
            {
                get { return m_Area_Display; }
                set { m_Area_Display = value; }
            }
            private double m_Area_Order;
            /// <summary>
            /// 
            /// </summary>
            public double Area_Order
            {
                get { return m_Area_Order; }
                set { m_Area_Order = value; }
            }
        }

        #endregion
        /// <summary>
        /// 列表
        /// </summary>
        [Serializable]
        public class AreaLists : List<Area>
        {
            private int _maxItems = 0;
            /// <summary>
            /// 最大数
            /// </summary>
            public int MaxItems { get { return this._maxItems; } set { this._maxItems = value; } }
        }
    }
}
