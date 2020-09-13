using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool isSpecial(int character)
            {
                int[] ranges = {48, 57, 65, 90, 97, 122 };
                // numbers between each set of 2 are non special characters
                for (var i = 0; i < ranges.Length; i++) {
                    if (i % 2 == 0) {
                        if (character >= ranges[i] && character <= ranges[i + 1]) {
                            return false;
                        }
                    }
                }
                return true;
            }

            Random rnd = new Random();
            int newCharacter() => rnd.Next(33, 127);

            string genString(int len, bool special)
            {
                string password = "";
                for (int i = 0; i < len; i++)
                {
                    int newChar = newCharacter();
                    if (!special)
                    {
                        while (isSpecial(newChar))
                        {
                            newChar = newCharacter();
                        }
                    }
                    password += (char) newChar;
                }
                return password;
            }

            bool isNum = int.TryParse(textBox1.Text, out int length);
            if (isNum)
                Clipboard.SetText(genString(length, checkBox1.Checked));
            else // 32 by default if an invalid length is provided
                Clipboard.SetText(genString(32, checkBox1.Checked));
            textBox1.Text = "Copied to clipboard!";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/mt60395/gen");
        }
    }
}
