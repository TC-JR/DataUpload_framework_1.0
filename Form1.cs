using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Sunny.UI;
using BJJCZ_BaseDevelop;
using System.Reflection.Emit;
using System.Reflection;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace DataUpload_framework_1._0
{

    public partial class Form1 : Form
    {
        //加载密码
        public static string Passworld1_administrators;
        //上传数据读取
        public static string UpSpeed1;
        public static string UpPower1;
        public static string UpSpeed2;
        public static string UpPower2;
        public static string UpSpeed3;
        public static string UpPower3;
        public static string UpSpeed4;
        public static string UpPower4;
        public static string UpSpeed5;
        public static string UpPower5;
        public static string UpSpeed6;
        public static string UpPower6;
        public static string UpSpeed7;
        public static string UpPower7;
        public static string UpbanjingA;
        public static string UpbanjingB;
        public static string Upjianju;

        public static string UpFocalLength;
        public static string UpTime;
        //开关状态
        public static bool one;
        public static bool two;
        public static bool three;
        public static bool four;
        public static bool five;
        public static bool six;
        public static bool seven;
        public static bool eight;
        public static bool nine;
        public static bool ten;

        public static bool createNew;

        //是否自动上传
        public static bool AutoUpData;
        //读取文件路径
        public static string dataPath;

        //读配置文件
        public static string configFilePath = "config.json";
        public static JsonConfigManager configManager = new JsonConfigManager(configFilePath);
        public ConfigClass config = configManager.Read<ConfigClass>();

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        #region 使用互斥量防止程序重复运行
        static Mutex mutex = new Mutex(true, "{UpLoad}"); // {YourAppGuid}为应用程序的全局唯一标识符
        [STAThread]

        private void Form1_Load(object sender, EventArgs e)
        {
            var a = ReadRegistryValue("Software\\TianCiCompany\\DataUpLoad\\RegistrationInformation");

            // 检查注册表值是否存在  
            if (a != "True")
            {
                // 注册表值不存在或找不到注册表键，给出提示并退出程序  
                MessageBox.Show("软件未注册，程序将退出。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else if (!mutex.WaitOne(TimeSpan.Zero)) //防止程序重复运行
            {
                MessageBox.Show("该程序已经在运行了！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            uiButton1.Enabled = false;
            uiButton2.Enabled = false;
            txt_IP.Enabled = false;
            txt_Port.Enabled = false;
            cmb_Socket.Enabled = false;
            //读配置文件

            Passworld1_administrators = config.password;
            UpSpeed1 = config.speed1;
            UpPower1 = config.power1;
            UpSpeed2 = config.speed2;
            UpPower2 = config.power2;
            UpSpeed3 = config.speed3;
            UpPower3 = config.power3;
            UpSpeed4 = config.speed4;
            UpPower4 = config.power4;
            UpSpeed5 = config.speed5;
            UpPower5 = config.power5;
            UpSpeed6 = config.speed6;
            UpPower6 = config.power6;
            UpSpeed7 = config.speed7;
            UpPower7 = config.power7;
            UpbanjingA = config.banjingA;
            UpbanjingB = config.banjingB;
            Upjianju = config.jianju;
            dataPath = config.dataPath;
            //是否自动上传
            AutoUpData = Convert.ToBoolean(config.AutoUpData);

            UpFocalLength = config.FocalLength;
            UpTime = config.Time;
            txt_IP.Text = config.ip;
            txt_Port.Text = config.port;
            uiComboBox1.Items.Add("操作员");
            uiComboBox1.Items.Add("管理员");
            uiComboBox1.SelectedIndex = 0;
            //读开关状态
            one = Convert.ToBoolean(config.Switch1);
            two = Convert.ToBoolean(config.Switch2);
            three = Convert.ToBoolean(config.Switch3);
            four = Convert.ToBoolean(config.Switch4);
            five = Convert.ToBoolean(config.Switch5);
            six = Convert.ToBoolean(config.Switch6);
            seven = Convert.ToBoolean(config.Switch7);
            eight = Convert.ToBoolean(config.Switch8);
            nine = Convert.ToBoolean(config.Switch9);
            ten = Convert.ToBoolean(config.Switch10);

        }
        #endregion

        //注册表键值
        private const string registryKeyPath = @"SOFTWARE\TianCiCompany\DataUpLoad";
        private const string registryValueName = "RegistrationInformation";
        //监听按键
        public static bool ctrl;
        //登录状态
        public static bool LoginStatus = false;
        //监听状态
        public static bool listenIn = false;
        //密码验证状态
        public static bool PasswordOk = false;
        //定义回调:解决跨线程访问问题
        private delegate void SetTextValueCallBack(string strValue);
        //定义接收客户端发送消息的回调
        private delegate void ReceiveMsgCallBack(string strReceive);
        //声明回调
        private SetTextValueCallBack setCallBack;
        //声明
        private ReceiveMsgCallBack receiveCallBack;
        //定义回调：给ComboBox控件添加元素
        private delegate void SetCmbCallBack(string strItem);
        //声明
        private SetCmbCallBack setCmbCallBack;
        //定义发送文件的回调
        private delegate void SendFileCallBack(byte[] bf);
        //声明
        private SendFileCallBack sendCallBack;
        //关闭
        public bool col = true;
        //用于通信的Socket
        Socket socketSend;
        //用于监听的SOCKET
        Socket socketWatch;

        //将远程连接的客户端的IP地址和Socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        //创建监听连接的线程
        Thread AcceptSocketThread;
        //接收客户端发送消息的线程
        Thread threadReceive;

        //检查注册表
        public static string ReadRegistryValue(string keyName)
        {
            string value = "";
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName))
                {
                    if (key != null)
                    {
                        value = key.GetValue(keyName).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur.
                Console.WriteLine(ex.Message);
                return "false";
            }
            return value;
        }

        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            //重置登录状态
            LoginStatus = false;
            //监听状态开启
            listenIn = true;
            //重置关闭
            col = true;
            //当点击开始监听的时候 在服务器端创建一个负责监听IP地址和端口号的Socket
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //获取ip地址
            IPAddress ip = IPAddress.Parse(this.txt_IP.Text.Trim());
            //创建端口号
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(this.txt_Port.Text.Trim()));
            try
            {
                //绑定IP地址和端口号
                socketWatch.Bind(point);
                this.txt_Log.AppendText(DateTime.Now.ToString("G") + "监听成功" + " \r");
                //开始监听:设置最大可以同时连接多少个请求
                socketWatch.Listen(10);
                //实例化回调
                setCallBack = new SetTextValueCallBack(SetTextValue);
                receiveCallBack = new ReceiveMsgCallBack(ReceiveMsg);
                setCmbCallBack = new SetCmbCallBack(AddCmbItem);
                //sendCallBack = new SendFileCallBack(SendFile);

                //创建线程
                AcceptSocketThread = new Thread(new ParameterizedThreadStart(StartListen));
                AcceptSocketThread.IsBackground = true;
                AcceptSocketThread.Start(socketWatch);

            }
            catch (Exception str)
            {
                this.txt_Log.AppendText(DateTime.Now.ToString("G") + str + " \r");
                listenIn = false;
                return;
            }
            //按钮禁用启用
            uiButton2.Enabled = true;
            uiButton1.Enabled = false;
            //uiButton3.Enabled = false;
            uiButton4.Enabled = false;
            txt_IP.Enabled = false;
            txt_Port.Enabled = false;
            cmb_Socket.Enabled = false;
            //txt_Msg.Enabled = false;
            uiComboBox1.Enabled = false;
        }
        public string strIp;
        /// <summary>
        /// 消息变量
        /// </summary>
        public static string strMsg;

        /// <summary>
        /// 等待客户端的连接，并且创建与之通信用的Socket
        /// </summary>
        /// <param name="obj"></param>
        private void StartListen(object obj)
        {
            try
            {
                Socket socketWatch = obj as Socket;
                while (col)
                {
                    //等待客户端的连接，并且创建一个用于通信的Socket
                    socketSend = socketWatch.Accept();
                    //获取远程主机的ip地址和端口号
                    strIp = socketSend.RemoteEndPoint.ToString();
                    dicSocket.Add(strIp, socketSend);
                    this.cmb_Socket.Invoke(setCmbCallBack, strIp);
                    strMsg = DateTime.Now.ToString("G") + "远程主机：" + socketSend.RemoteEndPoint + "连接成功";
                    //使用回调
                    txt_Log.Invoke(setCallBack, strMsg);
                    if (cmb_Socket.Items.Count != -1)
                    {
                        cmb_Socket.SelectedIndex = cmb_Socket.Items.Count - 1;
                    }
                    //定义接收客户端消息的线程
                    Thread threadReceive = new Thread(new ParameterizedThreadStart(Receive));
                    threadReceive.IsBackground = true;
                    threadReceive.Start(socketSend);
                    //Debug.WriteLine(1);
                    Thread.Sleep(50);
                }
            }
            catch { }
        }

        /// <summary>
        /// 服务器端不停的接收客户端发送的消息
        /// </summary>
        /// <param name="obj"></param>
        private void Receive(object obj)
        {
            try
            {
                Socket socketSend = obj as Socket;
                //客户端连接成功后，服务器接收客户端发送的消息
                byte[] buffer = new byte[2048];
                int count;
                string str;
                string strReceiveMsg;
                while (col)
                {
                    //实际接收到的有效字节数
                    count = socketSend.Receive(buffer);
                    if (count == 0)//count 表示客户端关闭，要退出循环
                    {
                        break;
                    }
                    else
                    {
                        str = Encoding.Default.GetString(buffer, 0, count);
                        strReceiveMsg = DateTime.Now.ToString("G") + "接收：" + socketSend.RemoteEndPoint + "发送的消息:" + str;
                        txt_Log.Invoke(receiveCallBack, strReceiveMsg);
                        if (!LoginStatus)
                        {
                            if (str != "")
                            {
                                Auto();
                            }
                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch { }
        }

        /// <summary>
        /// 回调委托需要执行的方法
        /// </summary>
        /// <param name="strValue"></param>
        private void SetTextValue(string strValue)
        {
            this.txt_Log.AppendText(strValue + " \r");
        }

        private void ReceiveMsg(string strMsg)
        {
            this.txt_Log.AppendText(strMsg + " \r");
        }

        private void AddCmbItem(string strItem)
        {
            this.cmb_Socket.Items.Add(strItem);
        }

        public string ip;

        /// <summary>
        /// 自动应答
        /// </summary>
        private void Auto()
        {
            try
            {
                if (!LoginStatus)
                {
                    if (AutoUpData)
                    {
                        //上传文件内的参数组
                        strMsg = files();
                    }
                    else
                    {
                        //上传预设参数
                        strMsg = alls();
                    }
                }
                else
                {
                    txt_Log.Invoke(receiveCallBack, DateTime.Now.ToString("G") + "\t" + "请先登录操作员");
                    return;
                }
                txt_Log.Invoke(receiveCallBack, DateTime.Now.ToString("G") + "\t" + strMsg);
                txt_Log.ScrollToCaret();
                byte[] buffer = Encoding.Default.GetBytes(strMsg);
                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);
                //将泛型集合转换为数组
                byte[] newBuffer = list.ToArray();
                //获得用户选择的IP地址
                ip = this.cmb_Socket.SelectedItem.ToString();
                dicSocket[ip].Send(newBuffer);
                //内存回收
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(DateTime.Now.ToString("G") + "给客户端发送消息出错:" + ex.Message);
            }
        }

        /// <summary>
        /// 停止监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StopListen_Click(object sender, EventArgs e)
        {
            //清空已连接列表
            cmb_Socket.Clear();
            //监听状态关闭
            listenIn = false;
            //按钮禁用启用
            uiButton2.Enabled = false;
            uiButton1.Enabled = true;
            uiButton4.Enabled = true;
            uiComboBox1.Enabled = true;
            //跳出循环结束线程
            col = false;
            if (socketWatch != null)
            {
                socketWatch.Close();
            }
            else if (socketSend != null)
            {
                socketSend.Close();
            }
            //终止线程
            if (AcceptSocketThread != null)
            {
                AcceptSocketThread.Abort();
            }
            if (threadReceive != null)
            {
                threadReceive.Abort();
            }
            this.txt_Log.AppendText(DateTime.Now.ToString("G") + "停止监听" + " \r");
            //重置停止监听按键密码状态
            PasswordOk = false;
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedIndex == 0)
            {
                //登录状态改为假
                LoginStatus = false;
                //禁用界面
                uiButton1.Enabled = true;
                //uiButton3.Enabled = false;
                //uiButton4.Enabled = false;
                txt_IP.Enabled = false;
                txt_Port.Enabled = false;
                cmb_Socket.Enabled = false;
                //txt_Msg.Enabled = false;
                return;
            }

            PWD pWD = new PWD();
            pWD.ShowDialog();
            //如果登录状态为真启用界面
            if (LoginStatus)
            {
                uiButton1.Enabled = false;
                uiButton2.Enabled = false;
                //uiButton3.Enabled = true;
                //uiButton4.Enabled = false;
                txt_IP.Enabled = true;
                txt_Port.Enabled = true;
                cmb_Socket.Enabled = true;
                //txt_Msg.Enabled = true;
                uiComboBox1.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 定时清理log窗口，转存日志到txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txt_Log.Text != "")
            {
                StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Log" + @"\" + DateTime.Now.ToString("D") + ".txt");
                sw.WriteLine(txt_Log.Text);
                sw.Flush();
                sw.Close();
                txt_Log.Text = "";
            }
        }

        private void uiLabel1_DoubleClick(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)//判断ctrl是否按下
            {
                Data data = new Data();
                data.ShowDialog();
            }
        }


        public string ReadFile()
        {
            string fileContent = "";
            // 检查文件是否存在
            if (File.Exists(dataPath))
            {
                // 读取文件内容
                fileContent = File.ReadAllText(dataPath);
                Debug.WriteLine("文件内容：");
                Debug.WriteLine(fileContent);
                return fileContent;
            }
            else
            {
                return fileContent;
            }
        }

        public string files()
        {
            string a = null;
            a = ReadFile();
            if (ten)
            {
                a += UpbanjingA + ";" + UpbanjingB + ";" + Upjianju + ";";
            }
            if (seven)
            {
                a += UpFocalLength + ";";
            }
            if (eight)
            {
                a += UpTime + ";";
            }
            return a;
        }


        public string alls()
        {
            string a = null;
            if (one)
            {
                a += UpSpeed1 + ";" + UpPower1 + ";";
            }
            if (two)
            {
                a += UpSpeed2 + ";" + UpPower2 + ";";
            }
            if (three)
            {
                a += UpSpeed3 + ";" + UpPower3 + ";";
            }
            if (four)
            {
                a += UpSpeed4 + ";" + UpPower4 + ";";
            }
            if (five)
            {
                a += UpSpeed5 + ";" + UpPower5 + ";";
            }
            if (six)
            {
                a += UpSpeed6 + ";" + UpPower6 + ";";
            }
            if (nine)
            {
                a += UpSpeed7 + ";" + UpPower7 + ";";
            }
            if (ten)
            {
                a += UpbanjingA + ";" + UpbanjingB + ";" + Upjianju + ";";
            }
            if (seven)
            {
                a += UpFocalLength + ";";
            }
            if (eight)
            {
                a += UpTime + ";";
            }
            return a;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!listenIn)
            {
                //转存日志
                StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Log" + @"\" + DateTime.Now.ToString("D") + ".txt");
                sw.WriteLine(txt_Log.Text);
                txt_Log.Text = "";
                sw.Flush();
                sw.Close();
            }
            else
            {
                this.txt_Log.AppendText(DateTime.Now.ToString("G") + "停止监听后再退出程序" + " \r");
                e.Cancel = true;
            }
        }

        private void 打开日志目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 获取程序运行目录  
            string programFilesDir = Environment.CurrentDirectory + "\\Log";

            // 打开目录  
            System.Diagnostics.Process.Start("explorer.exe", programFilesDir);
        }

        private void 打开日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 获取程序运行目录  
            string applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // 指定要打开的文件夹路径  
            string folderPath = Path.Combine(applicationDirectory, "Log");

            // 构建文件的完整路径。假设文件名为"example.txt"  
            string filePath = Path.Combine(folderPath, DateTime.Now.ToString("D") + ".txt");

            // 检查文件夹和文件是否存在  
            if (Directory.Exists(folderPath) && File.Exists(filePath))
            {
                try
                {
                    // 打开文件  
                    System.Diagnostics.Process.Start(filePath);
                }
                catch { }
            }
        }

        private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_Log.Text != "")
            {
                StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Log" + @"\" + DateTime.Now.ToString("D") + ".txt");
                sw.WriteLine(txt_Log.Text);
                sw.Flush();
                sw.Close();
                txt_Log.Text = "";
            }
        }

    }
}