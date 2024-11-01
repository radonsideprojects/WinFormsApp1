using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Forms
{
    public partial class GreetingWindow : Form
    {
        public GreetingWindow()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CaptchaWindow().ShowDialog();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;

            await Task.Delay(new Random().Next(3500));

            MessageBox.Show("Failed to login.\nPerhaps you should re-check your username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            button1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;

        }
    }
}
