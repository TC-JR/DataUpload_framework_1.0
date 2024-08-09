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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DataUpload_framework_1._0
{
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
            //下拉列表
            //打开参数界面关闭停止监听按钮状态
            Form1.PasswordOk = false;
            //载入数据
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
            uiTextBox5.Text = JsonConfigHelper.ReadConfig("speed7");
            uiTextBox6.Text = JsonConfigHelper.ReadConfig("power7");
            uiTextBox13.Text = JsonConfigHelper.ReadConfig("banjingA");
            uiTextBox14.Text = JsonConfigHelper.ReadConfig("banjingB");
            uiTextBox19.Text = JsonConfigHelper.ReadConfig("jianju");
            uiCheckBox1.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("AutoUpData"));
            textBox1.Text = Form1.dataPath;

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
            bool Switch9 = Form1.nine;
            bool Switch10 = Form1.ten;


            // 设置开关状态
            uiSwitch1.Active = Switch1;
            uiSwitch2.Active = Switch2;
            uiSwitch3.Active = Switch3;
            uiSwitch4.Active = Switch4;
            uiSwitch5.Active = Switch5;
            uiSwitch6.Active = Switch6;
            uiSwitch7.Active = Switch7;
            uiSwitch8.Active = Switch8;
            uiSwitch9.Active = Switch9;
            uiSwitch10.Active = Switch10;

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
            AppSettings.SetValue("uiSwitch9", uiSwitch9.Active.ToString());
            AppSettings.SetValue("uiSwitch10", uiSwitch10.Active.ToString());


            //重新更新变量
            Form1.one = uiSwitch1.Active;
            Form1.two = uiSwitch2.Active;
            Form1.three = uiSwitch3.Active;
            Form1.four = uiSwitch4.Active;
            Form1.five = uiSwitch5.Active;
            Form1.six = uiSwitch6.Active;
            Form1.seven = uiSwitch7.Active;
            Form1.eight = uiSwitch8.Active;
            Form1.nine = uiSwitch9.Active;
            Form1.ten = uiSwitch10.Active;

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
            JsonConfigHelper.WriteConfig("speed7", uiTextBox5.Text);
            JsonConfigHelper.WriteConfig("power7", uiTextBox6.Text);
            JsonConfigHelper.WriteConfig("banjingA", uiTextBox13.Text);
            JsonConfigHelper.WriteConfig("banjingB", uiTextBox14.Text);
            JsonConfigHelper.WriteConfig("jianju", uiTextBox19.Text);
            JsonConfigHelper.WriteConfig("AutoUpData", uiCheckBox1.Checked.ToString());
            Form1.AutoUpData = uiCheckBox1.Checked;
            JsonConfigHelper.WriteConfig("FocalLength", uiTextBox7.Text);
            JsonConfigHelper.WriteConfig("Time", uiTextBox8.Text);
            Form1.dataPath = textBox1.Text;
            JsonConfigHelper.WriteConfig("datapath",Form1.dataPath);
            SaveuiSwitch();
            //关闭窗口
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D://";
            openFileDialog.Filter = "程序文件|*.data|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
                Form1.dataPath = openFileDialog.FileName;
            }

        }
    }

}

