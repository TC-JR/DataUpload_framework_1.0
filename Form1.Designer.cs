namespace DataUpload_framework_1._0
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.txt_IP = new Sunny.UI.UIIPTextBox();
            this.txt_Port = new Sunny.UI.UITextBox();
            this.cmb_Socket = new Sunny.UI.UIComboBox();
            this.txt_Log = new Sunny.UI.UIRichTextBox();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.打开日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开日志目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel2 = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel3 = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel5 = new Sunny.UI.UIMarkLabel();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(12, 12);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 0;
            this.uiButton1.Text = "开始监听";
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(118, 12);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(100, 35);
            this.uiButton2.TabIndex = 1;
            this.uiButton2.Text = "停止监听";
            this.uiButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Click += new System.EventHandler(this.btn_StopListen_Click);
            // 
            // txt_IP
            // 
            this.txt_IP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.txt_IP.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txt_IP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_IP.Location = new System.Drawing.Point(12, 115);
            this.txt_IP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_IP.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Padding = new System.Windows.Forms.Padding(1);
            this.txt_IP.ShowText = false;
            this.txt_IP.Size = new System.Drawing.Size(150, 29);
            this.txt_IP.Style = Sunny.UI.UIStyle.Custom;
            this.txt_IP.TabIndex = 3;
            this.txt_IP.Text = "127.0.0.1";
            this.txt_IP.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_IP.Value = ((System.Net.IPAddress)(resources.GetObject("txt_IP.Value")));
            // 
            // txt_Port
            // 
            this.txt_Port.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txt_Port.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Port.DoubleValue = 7800D;
            this.txt_Port.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Port.IntValue = 7800;
            this.txt_Port.Location = new System.Drawing.Point(12, 195);
            this.txt_Port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Port.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Port.ShowText = false;
            this.txt_Port.Size = new System.Drawing.Size(150, 29);
            this.txt_Port.TabIndex = 4;
            this.txt_Port.Text = "7800";
            this.txt_Port.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Port.Watermark = "";
            // 
            // cmb_Socket
            // 
            this.cmb_Socket.DataSource = null;
            this.cmb_Socket.FillColor = System.Drawing.Color.White;
            this.cmb_Socket.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Socket.Location = new System.Drawing.Point(12, 275);
            this.cmb_Socket.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_Socket.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_Socket.Name = "cmb_Socket";
            this.cmb_Socket.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_Socket.Size = new System.Drawing.Size(150, 29);
            this.cmb_Socket.TabIndex = 6;
            this.cmb_Socket.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_Socket.Watermark = "";
            // 
            // txt_Log
            // 
            this.txt_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Log.ContextMenuStrip = this.uiContextMenuStrip1;
            this.txt_Log.FillColor = System.Drawing.Color.White;
            this.txt_Log.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Log.Location = new System.Drawing.Point(255, 106);
            this.txt_Log.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Log.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.Padding = new System.Windows.Forms.Padding(2);
            this.txt_Log.ReadOnly = true;
            this.txt_Log.ShowText = false;
            this.txt_Log.Size = new System.Drawing.Size(515, 330);
            this.txt_Log.Style = Sunny.UI.UIStyle.Custom;
            this.txt_Log.TabIndex = 7;
            this.txt_Log.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开日志ToolStripMenuItem,
            this.打开日志目录ToolStripMenuItem,
            this.清空日志ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(177, 82);
            // 
            // 打开日志ToolStripMenuItem
            // 
            this.打开日志ToolStripMenuItem.Name = "打开日志ToolStripMenuItem";
            this.打开日志ToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.打开日志ToolStripMenuItem.Text = "打开日志";
            this.打开日志ToolStripMenuItem.Click += new System.EventHandler(this.打开日志ToolStripMenuItem_Click);
            // 
            // 打开日志目录ToolStripMenuItem
            // 
            this.打开日志目录ToolStripMenuItem.Name = "打开日志目录ToolStripMenuItem";
            this.打开日志目录ToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.打开日志目录ToolStripMenuItem.Text = "打开日志目录";
            this.打开日志目录ToolStripMenuItem.Click += new System.EventHandler(this.打开日志目录ToolStripMenuItem_Click);
            // 
            // 清空日志ToolStripMenuItem
            // 
            this.清空日志ToolStripMenuItem.Name = "清空日志ToolStripMenuItem";
            this.清空日志ToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.清空日志ToolStripMenuItem.Text = "清空日志";
            this.清空日志ToolStripMenuItem.Click += new System.EventHandler(this.清空日志ToolStripMenuItem_Click);
            // 
            // uiMarkLabel1
            // 
            this.uiMarkLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel1.Location = new System.Drawing.Point(12, 78);
            this.uiMarkLabel1.Name = "uiMarkLabel1";
            this.uiMarkLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiMarkLabel1.TabIndex = 8;
            this.uiMarkLabel1.Text = "IP段";
            this.uiMarkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiMarkLabel2
            // 
            this.uiMarkLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel2.Location = new System.Drawing.Point(12, 158);
            this.uiMarkLabel2.Name = "uiMarkLabel2";
            this.uiMarkLabel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiMarkLabel2.TabIndex = 9;
            this.uiMarkLabel2.Text = "端口号";
            this.uiMarkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiMarkLabel3
            // 
            this.uiMarkLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel3.Location = new System.Drawing.Point(12, 238);
            this.uiMarkLabel3.Name = "uiMarkLabel3";
            this.uiMarkLabel3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiMarkLabel3.TabIndex = 10;
            this.uiMarkLabel3.Text = "已连接列表";
            this.uiMarkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiMarkLabel5
            // 
            this.uiMarkLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel5.Location = new System.Drawing.Point(255, 78);
            this.uiMarkLabel5.Name = "uiMarkLabel5";
            this.uiMarkLabel5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel5.Size = new System.Drawing.Size(100, 23);
            this.uiMarkLabel5.TabIndex = 12;
            this.uiMarkLabel5.Text = "日志";
            this.uiMarkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton4
            // 
            this.uiButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton4.Location = new System.Drawing.Point(670, 12);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(100, 35);
            this.uiButton4.TabIndex = 13;
            this.uiButton4.Text = "登录";
            this.uiButton4.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton4.Click += new System.EventHandler(this.uiButton4_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300000;
            this.timer1.Tag = "";
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiComboBox1.DataSource = null;
            this.uiComboBox1.FillColor = System.Drawing.Color.White;
            this.uiComboBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox1.Location = new System.Drawing.Point(531, 14);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox1.Size = new System.Drawing.Size(123, 29);
            this.uiComboBox1.TabIndex = 14;
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox1.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(148, 413);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 15;
            this.uiLabel1.Text = "V2.0";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel1.DoubleClick += new System.EventHandler(this.uiLabel1_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 451);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiComboBox1);
            this.Controls.Add(this.uiButton4);
            this.Controls.Add(this.uiMarkLabel5);
            this.Controls.Add(this.uiMarkLabel3);
            this.Controls.Add(this.uiMarkLabel2);
            this.Controls.Add(this.uiMarkLabel1);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.cmb_Socket);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 490);
            this.Name = "Form1";
            this.Text = "DataUpload2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIIPTextBox txt_IP;
        private Sunny.UI.UITextBox txt_Port;
        private Sunny.UI.UIComboBox cmb_Socket;
        private Sunny.UI.UIRichTextBox txt_Log;
        private Sunny.UI.UIMarkLabel uiMarkLabel1;
        private Sunny.UI.UIMarkLabel uiMarkLabel2;
        private Sunny.UI.UIMarkLabel uiMarkLabel3;
        private Sunny.UI.UIMarkLabel uiMarkLabel5;
        private Sunny.UI.UIButton uiButton4;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开日志目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空日志ToolStripMenuItem;
    }
}

