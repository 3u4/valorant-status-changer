using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valorant_Status_Changer
{
    public partial class Form1 : Form
    {
        static void ExecuteCommand(string Command)
        {
            ProcessStartInfo run = new ProcessStartInfo();
            run.FileName = "cmd.exe";
            run.Verb = "runas";
            run.Arguments = "/C "+Command;
            run.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                Process.Start(run);
                MessageBox.Show("Done");
            }
            catch
            {
                MessageBox.Show("An Error Occured, make sure you are granting Administrator privelages to the program!");
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.TabStop = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteCommand("netsh advfirewall firewall add rule name=\"valorantOFFLINE\" dir=out remoteport=5223 protocol=TCP action=block");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExecuteCommand("netsh advfirewall firewall delete rule name=\"valorantOFFLINE\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

       
    }
}
