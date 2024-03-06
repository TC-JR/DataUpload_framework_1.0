using BJJCZ_BaseDevelop;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DataUpload_framework_1._0
{
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
            //下拉列表
            uiComboBox1.Items.Add("1500");
            uiComboBox1.Items.Add("3000");
            uiComboBox1.SelectedIndex = Convert.ToInt32(JsonConfigHelper.ReadConfig("laser"));
            //打开参数界面关闭停止监听按钮状态
            Form1.PasswordOk = false;
            //载入数据
            //uiTextBox21.Text = JsonConfigHelper.ReadConfig("laser");
            uiTextBox1.Text = JsonConfigHelper.ReadConfig("speed1");
            uiTextBox2.Text = JsonConfigHelper.ReadConfig("power1");
            uiTextBox3.Text = JsonConfigHelper.ReadConfig("speed2");
            uiTextBox4.Text = JsonConfigHelper.ReadConfig("power2");
            uiTextBox9.Text = JsonConfigHelper.ReadConfig("speed3");
            uiTextBox10.Text = JsonConfigHelper.ReadConfig("power3");
            uiTextBox11.Text = JsonConfigHelper.ReadConfig("speed4");
            uiTextBox12.Text = JsonConfigHelper.ReadConfig("power4");
            uiTextBox15.Text = JsonConfigHelper.ReadConfig("speed5");
            uiTextBox16.Text = JsonConfigHelper.ReadConfig("power5");
            uiTextBox17.Text = JsonConfigHelper.ReadConfig("speed6");
            uiTextBox18.Text = JsonConfigHelper.ReadConfig("power6");
            uiTextBox7.Text = JsonConfigHelper.ReadConfig("FocalLength");
            uiTextBox8.Text = JsonConfigHelper.ReadConfig("Time");
            ReaduiSwitch();
        }

        public void ReaduiSwitch()
        {
            //读取开关状态
            bool Switch1 = Form1.one;
            bool Switch2 = Form1.two;
            bool Switch3 = Form1.three;
            bool Switch4 = Form1.four;
            bool Switch5 = Form1.five;
            bool Switch6 = Form1.six;
            bool Switch7 = Form1.seven;
            bool Switch8 = Form1.eight;

            // 设置开关状态
            uiSwitch1.Active = Switch1;
            uiSwitch2.Active = Switch2;
            uiSwitch3.Active = Switch3;
            uiSwitch4.Active = Switch4;
            uiSwitch5.Active = Switch5;
            uiSwitch6.Active = Switch6;
            uiSwitch7.Active = Switch7;
            uiSwitch8.Active = Switch8;
        }


        public void SaveuiSwitch()
        {
            //把开关状态更新配置文件
            AppSettings.SetValue("uiSwitch1", uiSwitch1.Active.ToString());
            AppSettings.SetValue("uiSwitch2", uiSwitch2.Active.ToString());
            AppSettings.SetValue("uiSwitch3", uiSwitch3.Active.ToString());
            AppSettings.SetValue("uiSwitch4", uiSwitch4.Active.ToString());
            AppSettings.SetValue("uiSwitch5", uiSwitch5.Active.ToString());
            AppSettings.SetValue("uiSwitch6", uiSwitch6.Active.ToString());
            AppSettings.SetValue("uiSwitch7", uiSwitch7.Active.ToString());
            AppSettings.SetValue("uiSwitch8", uiSwitch8.Active.ToString());

            //重新更新变量
            Form1.one = uiSwitch1.Active;
            Form1.two = uiSwitch2.Active;
            Form1.three = uiSwitch3.Active;
            Form1.four = uiSwitch4.Active;
            Form1.five = uiSwitch5.Active;
            Form1.six = uiSwitch6.Active;
            Form1.seven = uiSwitch7.Active;
            Form1.eight = uiSwitch8.Active;

        }


        private void uiButton1_Click(object sender, EventArgs e)
        {
            //写入数据
            JsonConfigHelper.WriteConfig("speed1", uiTextBox1.Text);
            JsonConfigHelper.WriteConfig("power1", uiTextBox2.Text);
            JsonConfigHelper.WriteConfig("speed2", uiTextBox3.Text);
            JsonConfigHelper.WriteConfig("power2", uiTextBox4.Text);
            JsonConfigHelper.WriteConfig("speed3", uiTextBox9.Text);
            JsonConfigHelper.WriteConfig("power3", uiTextBox10.Text);
            JsonConfigHelper.WriteConfig("speed4", uiTextBox11.Text);
            JsonConfigHelper.WriteConfig("power4", uiTextBox12.Text);
            JsonConfigHelper.WriteConfig("speed5", uiTextBox15.Text);
            JsonConfigHelper.WriteConfig("power5", uiTextBox16.Text);
            JsonConfigHelper.WriteConfig("speed6", uiTextBox17.Text);
            JsonConfigHelper.WriteConfig("power6", uiTextBox18.Text);
            JsonConfigHelper.WriteConfig("FocalLength", uiTextBox7.Text);
            JsonConfigHelper.WriteConfig("Time", uiTextBox8.Text);
            JsonConfigHelper.WriteConfig("laser", uiComboBox1.SelectedIndex.ToString());

            SaveuiSwitch();
            //关闭窗口
            this.Close();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            var a = "";
            Energy(uiTextBox6.Text, ref a);
            uiTextBox2.Text += a;
        }
        private void uiButton3_Click(object sender, EventArgs e)
        {
            var a = "";
            Energy(uiTextBox5.Text, ref a);
            uiTextBox4.Text += a;
        }
        private void uiButton4_Click(object sender, EventArgs e)
        {
            var a = "";
            Energy(uiTextBox13.Text, ref a);
            uiTextBox10.Text += a;
        }
        private void uiButton5_Click(object sender, EventArgs e)
        {
            var a = "";
            Energy(uiTextBox14.Text, ref a);
            uiTextBox12.Text += a;
        }
        private void uiButton6_Click(object sender, EventArgs e)
        {
            var a = "";
            Energy(uiTextBox19.Text, ref a);
            uiTextBox16.Text += a;
        }
        private void uiButton7_Click(object sender, EventArgs e)
        {
            var a = "";
            Energy(uiTextBox20.Text, ref a);
            uiTextBox18.Text += a;
        }


        public void Energy(string str, ref string rst)
        {
            try
            {
                if (uiComboBox1.SelectedIndex == 0)
                {
                    rst = (Convert.ToDouble(str) / 100 * 1500).ToString();
                }
                else
                {
                    rst = (Convert.ToDouble(str) / 100 * 3000).ToString();
                }
            }
            catch { }
        }



    }

}

