using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataUpload_framework_1._0
{
    public partial class PWD : Form
    {
        public PWD()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            keepDown();
        }
        public void keepDown()
        {
            if (uiTextBox1.Text == Form1.Passworld1_administrators)
            {
                Form1.LoginStatus = true;
                Form1.PasswordOk = true;
            }
            this.Close();

        }
        private void uiTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                keepDown();
                // 执行确认输入的逻辑代码  
                // ...  
                // 阻止回车键被输出到文本框  
                //e.Handled = true;
            }
        }
    }
}
