using System;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Main
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "工具运行正常！当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }



        private string StringToHexString(string s, Encoding encode)
        {
            byte[] b = encode.GetBytes(s);
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)
            {
                result += " " + Convert.ToString(b[i], 16);
            }
            return result;
        }
        private void Hex_button1_Click(object sender, EventArgs e)
        {
            if (Hex_textBox1.Text == String.Empty)
            {
                Hex_textBox2.Text = "请输入内容！";
                Hex_textBox1.Focus();
                return;
            }
            else
            {
                Regex reg = new Regex("^[a-zA-Z_0-9]+$");
                Match ma = reg.Match(Hex_textBox1.Text);
                if (ma.Success)
                {
                    string strVin = this.Hex_textBox1.Text.Trim();
                    if (strVin.Length == 17)
                    {
                        string s = Hex_textBox1.Text;
                        Hex_textBox2.Text = StringToHexString(s, Encoding.Default);
                    }
                    else
                    {
                        Hex_textBox2.Text = "车架号长度不够，请仔细检查确认是否17位！";
                        return;
                    }
                }
                else
                {
                    Hex_textBox2.Text = "输入错误，请勿输入非法字符！";
                    Hex_textBox1.Focus();
                    return;
                }
            }
        }
        private void Vin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar >= 'A' && e.KeyChar <= 'Z' || e.KeyChar >= 'a' && e.KeyChar <= 'z' || e.KeyChar == 1 || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24 || e.KeyChar == 26 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
        private void Num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 1 || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24 || e.KeyChar == 26 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
        private void Hex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar >= 'A' && e.KeyChar <= 'F' || e.KeyChar >= 'a' && e.KeyChar <= 'f' || e.KeyChar == 1 || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24 || e.KeyChar == 26 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
        private void Hex_button2_Click(object sender, EventArgs e)
        {
            Hex_textBox1.Clear();
            Hex_textBox2.Clear();
            return;
        }
        private void Hex_button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Hex_textBox2.Text); 
            MessageBox.Show("HEX内容拷贝成功！", "提示");
            return;
        }
        bool flag = true;
        private void 总在最前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                总在最前ToolStripMenuItem.Checked = true;
                this.TopMost = true;
                flag = false;
            }
            else
            {
                总在最前ToolStripMenuItem.Checked = false;
                this.TopMost = false;
                flag = true;
            }
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("没有关于，有问题联系 Wechat：351999", "关于");
            return;
        }

        private void ID_button1_Click(object sender, EventArgs e)
        {
            if (ID_textBox1.Text == String.Empty)
            {
                ID_textBox2.Text = "请输入内容！";
                ID_textBox1.Focus();
                return;
            }
            else
            {
                Regex reg = new Regex("^[0-9]+$");
                Match ma = reg.Match(ID_textBox1.Text);
                if (ma.Success)
                {
                    string strText = this.ID_textBox1.Text.Trim();
                    if (strText.Length == 8)
                    {
                        int ID = Convert.ToInt32(ID_textBox1.Text, 10);
                        ID_textBox2.Text = ID.ToString("X8");
                    }
                    else
                    {
                        ID_textBox2.Text = "ID为8位数字！";
                        MessageBox.Show("ID为8位数字，输入范围\n 00000000 至 99999999", "提示");
                        return;
                    }
                }
                else
                {
                    ID_textBox2.Text = "输入内容不正确！";
                    MessageBox.Show("请输入数字，输入范围\n 00000000 至 99999999", "错误");
                    ID_textBox1.Focus();
                    return;
                }
            }
        }
        private void ID_button2_Click(object sender, EventArgs e)
        {
            ID_textBox1.Text = "";
            ID_textBox2.Text = "";
        }

        private void Key_button2_Click(object sender, EventArgs e)
        {
            Key_textBox1.Text = "";
            Key_textBox2.Text = "";
            return;
        }

    }
}