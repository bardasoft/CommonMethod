using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod_Winform_Use
{
    public partial class FrmItemsTest : Form
    {
        public FrmItemsTest()
        {
            InitializeComponent();
        }

        private void FrmItemsTest_Load(object sender, EventArgs e)
        {
            List<CommonMethod.CommonObject.ComboBoxItem> l = new List<CommonMethod.CommonObject.ComboBoxItem>();
            CommonMethod.CommonObject.ComboBoxItem item = new CommonMethod.CommonObject.ComboBoxItem("1", "一");
            l.Add(item);
            item = new CommonMethod.CommonObject.ComboBoxItem("2", "二");
            l.Add(item);
            comboBox1.DataSource = l;
            comboBox1.ValueMember = "ItemValue";
            comboBox1.DisplayMember = "ItemDisplay";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CommonMethod.CommonObject.ComboBoxItem c = new CommonMethod.CommonObject.ComboBoxItem("1", "一");
            //comboBox1.SelectedItem = c;
            //comboBox1.SelectedValue = "1";
            //comboBox1.SelectedIndex = new CommonMethod.CommonObject.ComboBoxItem("1", "一");
            //comboBox1.SelectedText = "二";
            comboBox1.SelectedValue = new CommonMethod.CommonObject.ComboBoxItem("2", "二");
            //comboBox1.SelectedItem = new CommonMethod.CommonObject.ComboBoxItem("1", "一");

        }

        Color clr = Color.Yellow;
        Color clr1 = Control.DefaultBackColor;
        private void timer1_Tick(object sender, EventArgs e)
        {
            button2.BackColor = button2.BackColor == clr ? clr1 : clr;
            //button2.BackColor = ;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Delete(Environment.CurrentDirectory + "\\新建文本文档.txt");
        }
    }
}
