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
        }

        //读配置文件
        public static string configFilePath = "config.json";
        public static JsonConfigManager configManager = new JsonConfigManager(configFilePath);
        public ConfigClass config = configManager.Read<ConfigClass>();

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Load(object sender, EventArgs e)
        {
            //重置密码状态
            Form1.PasswordOk = false;
            //载入数据
            uiTextBox1.Text = config.speed1;
            uiTextBox2.Text = config.power1;
            uiTextBox3.Text = config.speed2;
            uiTextBox4.Text = config.power2;
            uiTextBox9.Text = config.speed3;
            uiTextBox10.Text = config.power3;
            uiTextBox11.Text = config.speed4;
            uiTextBox12.Text = config.power4;
            uiTextBox15.Text = config.speed5;
            uiTextBox16.Text = config.power5;
            uiTextBox17.Text = config.speed6;
            uiTextBox18.Text = config.power6;
            uiTextBox5.Text = config.speed7;
            uiTextBox6.Text = config.power7;
            uiTextBox13.Text = config.banjingA;
            uiTextBox14.Text = config.banjingB;
            uiTextBox19.Text = config.jianju;
            uiCheckBox1.Checked = Convert.ToBoolean(config.AutoUpData);
            textBox1.Text = config.dataPath;
            uiTextBox7.Text = config.FocalLength;
            uiTextBox8.Text = config.Time;

            //读开关状态
            uiSwitch1.Active = Convert.ToBoolean(config.Switch1);
            uiSwitch2.Active = Convert.ToBoolean(config.Switch2);
            uiSwitch3.Active = Convert.ToBoolean(config.Switch3);
            uiSwitch4.Active = Convert.ToBoolean(config.Switch4);
            uiSwitch5.Active = Convert.ToBoolean(config.Switch5);
            uiSwitch6.Active = Convert.ToBoolean(config.Switch6);
            uiSwitch7.Active = Convert.ToBoolean(config.Switch7);
            uiSwitch8.Active = Convert.ToBoolean(config.Switch8);
            uiSwitch9.Active = Convert.ToBoolean(config.Switch9);
            uiSwitch10.Active = Convert.ToBoolean(config.Switch10);
        }

        /// <summary>
        /// 保存并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton1_Click(object sender, EventArgs e)
        {
            config.speed1 = uiTextBox1.Text;
            config.power1 = uiTextBox2.Text;
            config.speed2 = uiTextBox3.Text;
            config.power2 = uiTextBox4.Text;
            config.speed3 = uiTextBox9.Text;
            config.power3 = uiTextBox10.Text;
            config.speed4 = uiTextBox11.Text;
            config.power4 = uiTextBox12.Text;
            config.speed5 = uiTextBox15.Text;
            config.power5 = uiTextBox16.Text;
            config.speed6 = uiTextBox17.Text;
            config.power6 = uiTextBox18.Text;
            config.speed7 = uiTextBox5.Text;
            config.power7 = uiTextBox6.Text;
            config.banjingA = uiTextBox13.Text;
            config.banjingB = uiTextBox14.Text;
            config.jianju = uiTextBox19.Text;
            config.AutoUpData = uiCheckBox1.Checked.ToString();
            config.FocalLength = uiTextBox7.Text;
            config.Time = uiTextBox8.Text;
            config.dataPath = textBox1.Text;

            config.Switch1= uiSwitch1.Active.ToString();
            config.Switch2 = uiSwitch2.Active.ToString();
            config.Switch3 = uiSwitch3.Active.ToString();
            config.Switch4 = uiSwitch4.Active.ToString();
            config.Switch5 = uiSwitch5.Active.ToString();
            config.Switch6 = uiSwitch6.Active.ToString();
            config.Switch7 = uiSwitch7.Active.ToString();
            config.Switch8 = uiSwitch8.Active.ToString();
            config.Switch9 = uiSwitch9.Active.ToString();
            config.Switch10 = uiSwitch10.Active.ToString();

            configManager.Write(config);

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
            Form1.AutoUpData = uiCheckBox1.Checked;
            Form1.dataPath = textBox1.Text;
            //关闭窗口
            this.Close();
        }

        /// <summary>
        /// 加载上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

