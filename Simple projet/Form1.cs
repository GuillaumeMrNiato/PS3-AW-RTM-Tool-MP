using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3Lib;
using Microsoft.VisualBasic;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using PS3ManagerAPI;

namespace Simple_projet
{
    public partial class Form1 : Form
    {
        static PS3API PS3 = new PS3API();
        byte[] bytes3;
        public Form1()
        {
            InitializeComponent();
        }

        private void xylosButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.ConnectTarget() && PS3.AttachProcess())
                {
                    if (PS3.GetCurrentAPI() == SelectAPI.ControlConsole)
                    {
                        PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "MrNiato's Advanced Warfare RTM Tool");
                    }
                    xylosProgressBar1.Value = 100;
                    toolStripStatusLabel2.Text = "Linked !";
                    toolStripStatusLabel2.ForeColor = Color.Lime;
                    PS3.SetMemory(0x4CABE4, new byte[] { 0x2c, 0x03, 0x00, 0x01 });
                    PS3.Extension.WriteString(0x7CC8DC, "^5M^7r^5N^7i^5a^7t^5o ^7's ^6AW Recovery Tool ^2--> ^1www.mrniato.h7k3r.fr ^2<--");
                    RPC.Init();
                }
                else
                {
                    toolStripStatusLabel2.Text = "Error, Not Linked !";
                    toolStripStatusLabel2.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                toolStripStatusLabel2.Text = "Error, Not Linked !";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void xylosRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
            RPC.ChangeDEX();
        }

        private void xylosRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
            RPC.ChangeCEX();
        }

        private void xylosButton2_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            numericUpDown1.Value = randNum.Next(0, 31);
            numericUpDown3.Value = randNum.Next(0, 50000);
            numericUpDown4.Value = randNum.Next(0, 25000);
            numericUpDown5.Value = randNum.Next(0, 15000);
            numericUpDown6.Value = randNum.Next(0, 15000);
            numericUpDown7.Value = randNum.Next(0, 15000);
            numericUpDown8.Value = randNum.Next(0, 15000);
            numericUpDown9.Value = randNum.Next(0, 15000);
            numericUpDown10.Value = randNum.Next(0, 15000);
            numericUpDown11.Value = randNum.Next(0, 15000);
            numericUpDown14.Value = randNum.Next(0, 15000);
            numericUpDown13.Value = randNum.Next(0, 15000);
            numericUpDown15.Value = randNum.Next(0, 15000);
        }

        private void xylosButton3_Click(object sender, EventArgs e)
        {
            byte[] buffer1337 = new byte[4];
            PS3.GetMemory(0x2ae7575, buffer1337);
            numericUpDown1.Value = BitConverter.ToInt32(buffer1337, 0);
            byte[] buffer = new byte[4];
            PS3.GetMemory(0x2ae7611, buffer);
            numericUpDown2.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae764e, buffer);
            numericUpDown3.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae7625, buffer);
            numericUpDown4.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae75fd, buffer);
            numericUpDown5.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae762d, buffer);
            numericUpDown6.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2AE75BD, buffer);
            numericUpDown7.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae765a, buffer);
            numericUpDown8.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae7619, buffer);
            numericUpDown9.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae767a, buffer);
            numericUpDown10.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae75b9, buffer);
            numericUpDown11.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae7652, buffer);
            numericUpDown13.Value = BitConverter.ToInt32(buffer, 0);
            PS3.GetMemory(0x2ae766a, buffer);
            numericUpDown14.Value = BitConverter.ToInt32(buffer1337, 0);
            PS3.GetMemory(0x2ae7615, buffer);
            numericUpDown15.Value = BitConverter.ToInt32(buffer, 0);
            textBox1.Text = PS3.Extension.ReadString(0x2AEC351);
            textBox2.Text = PS3.Extension.ReadString(0x2AEC351 + 0x80);
            textBox3.Text = PS3.Extension.ReadString(0x2AEC351 + 0x80 + 0x80);
            textBox4.Text = PS3.Extension.ReadString(0x2AEC351 + 0x80 + 0x80 + 0x80);
            textBox5.Text = PS3.Extension.ReadString(0x2AEC351 + 0x80 + 0x80 + 0x80 + 0x80);
            textBox6.Text = PS3.Extension.ReadString(0x2AEC351 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80);
            textBox7.Text = PS3.Extension.ReadString(0x2AEC351 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80);
            textBox8.Text = PS3.Extension.ReadString(0x2AEC351 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80);
            textBox9.Text = PS3.Extension.ReadString(0x2AEC351 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80);
            textBox10.Text = PS3.Extension.ReadString(0x2AEC351 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80 + 0x80);
        }
        private void xylosButton4_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x2ae7575, BitConverter.GetBytes((int)numericUpDown1.Value));
            PS3.SetMemory(0x2ae7611, BitConverter.GetBytes((int)numericUpDown2.Value));
            PS3.SetMemory(0x2ae764e, BitConverter.GetBytes((int)numericUpDown3.Value));
            PS3.SetMemory(0x2ae7625, BitConverter.GetBytes((int)numericUpDown4.Value));
            PS3.SetMemory(0x2ae762d, BitConverter.GetBytes((int)numericUpDown5.Value));
            PS3.SetMemory(0x2AE75BD, BitConverter.GetBytes((int)numericUpDown6.Value));
            PS3.SetMemory(0x2ae765a, BitConverter.GetBytes((int)numericUpDown7.Value));
            PS3.SetMemory(0x2ae7619, BitConverter.GetBytes((int)numericUpDown8.Value));
            PS3.SetMemory(0x2ae767a, BitConverter.GetBytes((int)numericUpDown9.Value));
            PS3.SetMemory(0x2ae75b9, BitConverter.GetBytes((int)numericUpDown10.Value));
            PS3.SetMemory(0x2ae7652, BitConverter.GetBytes((int)numericUpDown11.Value));
            PS3.SetMemory(0x2ae766a, BitConverter.GetBytes((int)numericUpDown13.Value));
            PS3.SetMemory(0x2ae7615, BitConverter.GetBytes((int)numericUpDown14.Value));
            PS3.Extension.WriteString(0x2AEC351, textBox1.Text);
            PS3.Extension.WriteString(0x2AEC3D1, textBox2.Text);
            PS3.Extension.WriteString(0x2AEC451, textBox3.Text);
            PS3.Extension.WriteString(0x2AEC4D1, textBox4.Text);
            PS3.Extension.WriteString(0x2AEC551, textBox5.Text);
            PS3.Extension.WriteString(0x2AEC5D1, textBox6.Text);
            PS3.Extension.WriteString(0x2AEC651, textBox7.Text);
            PS3.Extension.WriteString(0x2AEC6D1, textBox8.Text);
            PS3.Extension.WriteString(0x2AEC751, textBox9.Text);
            PS3.Extension.WriteString(0x2AEC7D1, textBox10.Text);
            if (xylosCheckBox1.Checked)
            {
                bytes3 = new byte[] { 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 
                0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe, 0xfe
             };
                PS3.SetMemory(0x2aecca8, bytes3);
                PS3.SetMemory(0x2AEF3D6, new byte[] { 0xFF });
            }
            MessageBox.Show("Done ! Launch a game, kill someone and enjoy your stats !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox11.Text;
            textBox2.Text = textBox11.Text;
            textBox3.Text = textBox11.Text;
            textBox4.Text = textBox11.Text;
            textBox5.Text = textBox11.Text;
            textBox6.Text = textBox11.Text;
            textBox7.Text = textBox11.Text;
            textBox8.Text = textBox11.Text;
            textBox9.Text = textBox11.Text;
            textBox10.Text = textBox11.Text;
        }

        private void xylosButton5_Click(object sender, EventArgs e)
        {
            string myString = textBox12.Text;
            int index = Killstreaks.FindString(myString, -1);
            if (index != -1)
            {
                Killstreaks.SetSelected(index, true);
                label26.Text = "Found the item \"" + myString + "\" at index: " + index + "";

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static uint KInterval = 0x30;
        private void Killstreaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Killstreaks.SelectedItem == "Drone")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2aeff27, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AEFEF7, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Drone";
            }
            if (Killstreaks.SelectedItem == "Warbird")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2aeff2b, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AEFEFB, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Warbird";
            }
            if (Killstreaks.SelectedItem == "Drone de Reco")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2aeff4f, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2aeff13, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Drone de Reco";
            }
            if (Killstreaks.SelectedItem == "Bombardement")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2aeff47, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2aeff17, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Bombardement";
            }
            if (Killstreaks.SelectedItem == "Frappe de missiles")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AEFF3F, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2aeff0f, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Frappe de missiles";
            }
            if (Killstreaks.SelectedItem == "Paladin")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AEFF2F, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AEFEFF, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Paladin";
            }
            if (Killstreaks.SelectedItem == "Colis Stratégique")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AEFF37, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AEFF07, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Colis Stratégique";
            }
            if (Killstreaks.SelectedItem == "Tourelle")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AEFF43, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AEFF13, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Tourelle";
            }
            if (Killstreaks.SelectedItem == "XS1 Vulcan")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AEFF33, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AEFF03, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : XS1 Vulcan";
            }
            if (Killstreaks.SelectedItem == "XS1 Goliath")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AEFF3B, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AEFF0B, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : XS1 Goliath";
            }
            if (Killstreaks.SelectedItem == "Drone d'assaut Aérien")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AEFF4B, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AEFF1B, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Drone d'assaut Aérien";
            }
            if (Killstreaks.SelectedItem == "Piratage Système")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AEFF53, buffer2);
                numericUpDown12.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AEFF23, buffer4);
                numericUpDown16.Value = BitConverter.ToInt32(buffer4, 0);
                label25.Text = "Killstreak Selected : Piratage Système";
            }
        }

        private void xylosButton6_Click(object sender, EventArgs e)
        {
            if (Killstreaks.SelectedItem == "Drone")
            {
                PS3.SetMemory(0x2aeff27, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2AEFEF7, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "Warbird")
            {
                PS3.SetMemory(0x2aeff2b, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2AEFEFB, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "Drone de Reco")
            {
                PS3.SetMemory(0x2aeff4f, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2aeff13, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "Bombardement")
            {
                PS3.SetMemory(0x2aeff47, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2aeff17, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "Frappe de missiles")
            {
                PS3.SetMemory(0x2AEFF3F, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2aeff0f, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "Paladin")
            {
                PS3.SetMemory(0x2AEFF2F, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2AEFEFF, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "Colis Stratégique")
            {
                PS3.SetMemory(0x2AEFF37, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2AEFF07, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "Tourelle")
            {
                PS3.SetMemory(0x2AEFF43, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2AEFF13, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "XS1 Vulcan")
            {
                PS3.SetMemory(0x2AEFF33, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2AEFF03, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "XS1 Goliath")
            {
                PS3.SetMemory(0x2AEFF3B, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2AEFF0B, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "Drone d'assaut Aérien")
            {
                PS3.SetMemory(0x2AEFF4B, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2AEFF1B, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
            if (Killstreaks.SelectedItem == "Piratage Système")
            {
                PS3.SetMemory(0x2AEFF53, BitConverter.GetBytes((int)numericUpDown12.Value));
                PS3.SetMemory(0x2AEFF23, BitConverter.GetBytes((int)numericUpDown16.Value));
            }
        }

        private void xylosButton7_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x2AEFF3F, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2aeff0f, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2aeff27, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2AEFEF7, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2aeff2b, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2AEFEFB, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2aeff4f, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2aeff13, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2aeff47, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2aeff17, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2AEFF2F, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2AEFEFF, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2AEFF37, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2AEFF07, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2AEFF43, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2AEFF13, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2AEFF33, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2AEFF03, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2AEFF3B, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2AEFF0B, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2AEFF4B, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2AEFF1B, BitConverter.GetBytes((int)numericUpDown16.Value));
            PS3.SetMemory(0x2AEFF23, BitConverter.GetBytes((int)numericUpDown12.Value));
            PS3.SetMemory(0x2AEFF53, BitConverter.GetBytes((int)numericUpDown16.Value));
        }

        private void xylosButton8_Click(object sender, EventArgs e)
        {
            string myString = textBox13.Text;
            int index = exolauncher.FindString(myString, -1);
            if (index != -1)
            {
                exolauncher.SetSelected(index, true);
                label30.Text = "Found the item \"" + myString + "\" at index: " + index + "";

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exolauncher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (exolauncher.SelectedItem == "Semtex")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE786A, buffer2);
                numericUpDown18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE785E, buffer4);
                numericUpDown17.Value = BitConverter.ToInt32(buffer4, 0);
                label31.Text = "Exo Launcher Selected : Semtex";
            }
            if (exolauncher.SelectedItem == "Grenade Frag")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7886, buffer2);
                numericUpDown18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE787A, buffer4);
                numericUpDown17.Value = BitConverter.ToInt32(buffer4, 0);
                label31.Text = "Exo Launcher Selected : Grenade Frag";
            }
            if (exolauncher.SelectedItem == "Drone à pointes")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2ae794a, buffer2);
                numericUpDown18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2ae793e, buffer4);
                numericUpDown17.Value = BitConverter.ToInt32(buffer4, 0);
                label31.Text = "Exo Launcher Selected : Drone à pointes";
            }
            if (exolauncher.SelectedItem == "Drone Explosif")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7BEA, buffer2);
                numericUpDown18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7BDE, buffer4);
                numericUpDown17.Value = BitConverter.ToInt32(buffer4, 0);
                label31.Text = "Exo Launcher Selected : Drone Explosif";
            }
            if (exolauncher.SelectedItem == "Grenade IEM")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7912, buffer2);
                numericUpDown18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7906, buffer4);
                numericUpDown17.Value = BitConverter.ToInt32(buffer4, 0);
                label31.Text = "Exo Launcher Selected : Grenade IEM";
            }
            if (exolauncher.SelectedItem == "Grenade Fumigène")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE78DA, buffer2);
                numericUpDown18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE78CE, buffer4);
                numericUpDown17.Value = BitConverter.ToInt32(buffer4, 0);
                label31.Text = "Exo Launcher Selected : Grenade Fumigène";
            }
            if (exolauncher.SelectedItem == "Grenade Paralysante")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2ae78be, buffer2);
                numericUpDown18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2ae78b2, buffer4);
                numericUpDown17.Value = BitConverter.ToInt32(buffer4, 0);
                label31.Text = "Exo Launcher Selected : Grenade Paralysante";
            }
        }

        private void xylosButton10_Click(object sender, EventArgs e)
        {
            if (exolauncher.SelectedItem == "Semtex")
            {
                PS3.SetMemory(0x2AE786A, BitConverter.GetBytes((int)numericUpDown18.Value));
                PS3.SetMemory(0x2AE785E, BitConverter.GetBytes((int)numericUpDown17.Value));
            }
            if (exolauncher.SelectedItem == "Grenade Frag")
            {
                PS3.SetMemory(0x2AE7886, BitConverter.GetBytes((int)numericUpDown18.Value));
                PS3.SetMemory(0x2AE787A, BitConverter.GetBytes((int)numericUpDown17.Value));
            }
            if (exolauncher.SelectedItem == "Drone à pointes")
            {
                PS3.SetMemory(0x2ae794a, BitConverter.GetBytes((int)numericUpDown18.Value));
                PS3.SetMemory(0x2ae793e, BitConverter.GetBytes((int)numericUpDown17.Value));
            }
            if (exolauncher.SelectedItem == "Drone Explosif")
            {
                PS3.SetMemory(0x2AE7BEA, BitConverter.GetBytes((int)numericUpDown18.Value));
                PS3.SetMemory(0x2AE7BDE, BitConverter.GetBytes((int)numericUpDown17.Value));
            }
            if (exolauncher.SelectedItem == "Grenade IEM")
            {
                PS3.SetMemory(0x2AE7912, BitConverter.GetBytes((int)numericUpDown18.Value));
                PS3.SetMemory(0x2AE7906, BitConverter.GetBytes((int)numericUpDown17.Value));
            }
            if (exolauncher.SelectedItem == "Grenade Fumigène")
            {
                PS3.SetMemory(0x2AE78DA, BitConverter.GetBytes((int)numericUpDown18.Value));
                PS3.SetMemory(0x2AE78CE, BitConverter.GetBytes((int)numericUpDown17.Value));
            }
            if (exolauncher.SelectedItem == "Grenade Paralysante")
            {
                PS3.SetMemory(0x2ae78be, BitConverter.GetBytes((int)numericUpDown18.Value));
                PS3.SetMemory(0x2ae78b2, BitConverter.GetBytes((int)numericUpDown17.Value));
            }
        }

        private void xylosButton9_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x2AE786A, BitConverter.GetBytes((int)numericUpDown18.Value));
            PS3.SetMemory(0x2AE785E, BitConverter.GetBytes((int)numericUpDown17.Value));
            PS3.SetMemory(0x2AE7886, BitConverter.GetBytes((int)numericUpDown18.Value));
            PS3.SetMemory(0x2AE787A, BitConverter.GetBytes((int)numericUpDown17.Value));
            PS3.SetMemory(0x2ae794a, BitConverter.GetBytes((int)numericUpDown18.Value));
            PS3.SetMemory(0x2ae793e, BitConverter.GetBytes((int)numericUpDown17.Value));
            PS3.SetMemory(0x2AE7BEA, BitConverter.GetBytes((int)numericUpDown18.Value));
            PS3.SetMemory(0x2AE7BDE, BitConverter.GetBytes((int)numericUpDown17.Value));
            PS3.SetMemory(0x2AE7912, BitConverter.GetBytes((int)numericUpDown18.Value));
            PS3.SetMemory(0x2AE7906, BitConverter.GetBytes((int)numericUpDown17.Value));
            PS3.SetMemory(0x2AE78DA, BitConverter.GetBytes((int)numericUpDown18.Value));
            PS3.SetMemory(0x2AE78CE, BitConverter.GetBytes((int)numericUpDown17.Value));
            PS3.SetMemory(0x2ae78be, BitConverter.GetBytes((int)numericUpDown18.Value));
            PS3.SetMemory(0x2ae78b2, BitConverter.GetBytes((int)numericUpDown17.Value));
        }

        private void xylosButton11_Click(object sender, EventArgs e)
        {
            string myString = textBox14.Text;
            int index = weapons.FindString(myString, -1);
            if (index != -1)
            {
                weapons.SetSelected(index, true);
                label34.Text = "Found the item \"" + myString + "\" at index: " + index + "";

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weapons.SelectedItem == "BAL-27")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7C22, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7C26, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(0x2AE7C1E, buffer5);
                numericUpDown19.Value = BitConverter.ToInt32(buffer5, 0);
                label35.Text = "Weapons Selected : BAL-27";
            }
            if (weapons.SelectedItem == "AK12")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7C06, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7C0A, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(0x2AE7C02, buffer5);
                numericUpDown19.Value = BitConverter.ToInt32(buffer5, 0);
                label35.Text = "Weapons Selected : AK12";
            }
            if (weapons.SelectedItem == "ARX-160")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7C92, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7C96, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7C8E, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : ARX-160";
            }
            if (weapons.SelectedItem == "HBRa3")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7C3E, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7C42, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7C3A, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : HBRa3";
            }
            if (weapons.SelectedItem == "IMR")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7C76, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7C7A, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7C72, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : IMR";
            }
            if (weapons.SelectedItem == "MK14")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7CAE, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7CB2, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7CAA, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : MK14";
            }
            if (weapons.SelectedItem == "KF5")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7D56, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7D5A, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7D52, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : KF5";
            }
            if (weapons.SelectedItem == "MP11")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7CCA, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7CCE, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7CC6, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : MP11";
            }
            if (weapons.SelectedItem == "ASM1")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7D3A, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7D3E, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7D36, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : ASM1";
            }
            if (weapons.SelectedItem == "SN6")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7CE6, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7CEA, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7CE2, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : SN6";
            }
            if (weapons.SelectedItem == "SAC3")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7D1E, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7D22, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7D1A, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : SAC3";
            }
            if (weapons.SelectedItem == "AMR9")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7D02, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7D06, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7CFE, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : AMR9";
            }
            if (weapons.SelectedItem == "Lynx")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7DAA, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7DAE, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7DA6, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : Lynx";
            }
            if (weapons.SelectedItem == "MORS")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7D8E, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7D92, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7D8A, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : MORS";
            }
            if (weapons.SelectedItem == "NA-45")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7D72, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7D76, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7D6E, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : NA-45";
            }
            if (weapons.SelectedItem == "Atlas 20mm")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7DC6, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7DCA, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7DC2, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : Atlas 20mm";
            }
            if (weapons.SelectedItem == "Tac-19")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7F16, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7F1A, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7F12, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : Tac-19";
            }
            if (weapons.SelectedItem == "S-12")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7EFA, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7EFE, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7EF6, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : S-12";
            }
            if (weapons.SelectedItem == "Bulldog")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7EDE, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7EE2, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7EDA, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : Bulldog";
            }
            if (weapons.SelectedItem == "EM1")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE98E6, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE98EA, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE98E2, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : EM1";
            }
            if (weapons.SelectedItem == "Pytaek")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE98E6, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE98EA, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE98E2, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : Pytaek";
            }
            if (weapons.SelectedItem == "Heavy Sheild")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7DE2, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7DE6, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7DDE, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : Heavy Sheild";
            }
            if (weapons.SelectedItem == "Atlas 45")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7EC2, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7EC6, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7EBE, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : Atlas 45";
            }
            if (weapons.SelectedItem == "RW1")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7EA6, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7EAA, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7EA2, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : RW1";
            }
            if (weapons.SelectedItem == "MP443 Grach")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7E8A, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7E8E, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7E86, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : MP443 Grach";
            }
            if (weapons.SelectedItem == "PDW")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7E6E, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7E72, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7E6A, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : PDW";
            }
            if (weapons.SelectedItem == "MAAW")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7F32, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7F36, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7F2E, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : MAAW";
            }
            if (weapons.SelectedItem == "MAHEM")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7F4E, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7F52, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7F4A, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : MAHEM";
            }
            if (weapons.SelectedItem == "Stinger M7")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(0x2AE7F6A, buffer2);
                numericUpDown20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(0x2AE7F6E, buffer4);
                numericUpDown21.Value = BitConverter.ToInt32(buffer4, 0);
                PS3.GetMemory(0x2AE7F66, buffer4);
                numericUpDown19.Value = BitConverter.ToInt32(buffer4, 0);
                label35.Text = "Weapons Selected : Stinger M7";
            }
        }

        private void xylosButton13_Click(object sender, EventArgs e)
        {
            if (weapons.SelectedItem == "MAHEM")
            {
                PS3.SetMemory(0x2AE7F4E, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7F52, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7F4A, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "MAAW")
            {
                PS3.SetMemory(0x2AE7F32, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7F36, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7F2E, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "PDW")
            {
                PS3.SetMemory(0x2AE7E6E, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7E72, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7E6A, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "MP443 Grach")
            {
                PS3.SetMemory(0x2AE7E8A, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7E8E, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7E86, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "RW1")
            {
                PS3.SetMemory(0x2AE7EA6, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7EAA, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7EA2, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "Atlas 45")
            {
                PS3.SetMemory(0x2AE7EC2, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7EC6, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7EBE, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "Heavy Sheild")
            {
                PS3.SetMemory(0x2AE7DE2, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7DE6, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7DDE, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "Pytaek")
            {
                PS3.SetMemory(0x2AE7C5A, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7C5E, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7C56, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "EM1")
            {
                PS3.SetMemory(0x2AE98E6, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE98EA, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE98E2, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "Bulldog")
            {
                PS3.SetMemory(0x2AE7EDE, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7EE2, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7EDA, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "S-12")
            {
                PS3.SetMemory(0x2AE7EFA, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7EFE, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7EF6, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "Tac-19")
            {
                PS3.SetMemory(0x2AE7F16, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7F1A, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7F12, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "Atlas 20mm")
            {
                PS3.SetMemory(0x2AE7DC6, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7DCA, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7DC2, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "NA-45")
            {
                PS3.SetMemory(0x2AE7D72, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7D76, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7D6E, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "MORS")
            {
                PS3.SetMemory(0x2AE7D8E, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7D92, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7D8A, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "Lynx")
            {
                PS3.SetMemory(0x2AE7DAA, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7DAE, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7DA6, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "AMR9")
            {
                PS3.SetMemory(0x2AE7D02, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7D06, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7CFE, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "SN6")
            {
                PS3.SetMemory(0x2AE7CE6, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7CEA, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7CE2, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "SAC3")
            {
                PS3.SetMemory(0x2AE7D1E, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7D22, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7D1A, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "ASM1")
            {
                PS3.SetMemory(0x2AE7D3A, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7D3E, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7D36, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "BAL-27")
            {
                PS3.SetMemory(0x2AE7C22, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7C26, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7C1E, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "AK12")
            {
                PS3.SetMemory(0x2AE7C06, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7C0A, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7C02, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "ARX-160")
            {
                PS3.SetMemory(0x2AE7C92, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7C96, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7C8E, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "HBRa3")
            {
                PS3.SetMemory(0x2AE7C3E, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7C42, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7C3A, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "IMR")
            {
                PS3.SetMemory(0x2AE7C76, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7C7A, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7C72, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "MK14")
            {
                PS3.SetMemory(0x2AE7CAE, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7CB2, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7CAA, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "KF5")
            {
                PS3.SetMemory(0x2AE7D56, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7D5A, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7D52, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
            if (weapons.SelectedItem == "MP11")
            {
                PS3.SetMemory(0x2AE7CCA, BitConverter.GetBytes((int)numericUpDown20.Value));
                PS3.SetMemory(0x2AE7CCE, BitConverter.GetBytes((int)numericUpDown21.Value));
                PS3.SetMemory(0x2AE7CC6, BitConverter.GetBytes((int)numericUpDown19.Value));
            }
        }

        private void xylosButton12_Click(object sender, EventArgs e)
        {
            //0x2AE7F4A
            PS3.SetMemory(0x2AE7F4E, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7F52, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7F4A, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7F32, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7F36, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7F2E, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7E6E, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7E72, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7E6A, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7E8A, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7E8E, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7E86, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7EA6, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7EAA, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7EA2, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7EC2, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7EC6, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7EBE, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7DE2, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7DE6, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7DDE, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7C5A, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7C5E, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7C56, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE98E6, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE98EA, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE98E2, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7EDE, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7EE2, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7EDA, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7EFA, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7EFE, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7EF6, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7F16, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7F1A, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7F12, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7DC6, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7DCA, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7DC2, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7D72, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7D76, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7D6E, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7D8E, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7D92, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7D8A, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7DAA, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7DAE, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7DA6, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7D02, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7D06, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7CFE, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7CE6, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7CEA, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7CE2, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7C22, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7C26, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7C1E, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7C06, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7C0A, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7C02, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7C92, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7C96, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7C8E, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7C3E, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7C42, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7C3A, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7C76, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7C7A, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7C72, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7CAE, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7CB2, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7CAA, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7D56, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7D5A, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7D52, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7CCA, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7CCE, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7CC6, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7D3A, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7D3E, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7D36, BitConverter.GetBytes((int)numericUpDown19.Value));
            PS3.SetMemory(0x2AE7D1E, BitConverter.GetBytes((int)numericUpDown20.Value));
            PS3.SetMemory(0x2AE7D22, BitConverter.GetBytes((int)numericUpDown21.Value));
            PS3.SetMemory(0x2AE7D1A, BitConverter.GetBytes((int)numericUpDown19.Value));
        }

        private void xylosCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
        }

        private void xylosCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
          
        }
        public static string get_player_name(uint client)
        {
            string getnames = PS3.Extension.ReadString(0x1AEE380 + 0x3334 + client * 0x3980);
            return getnames;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Players.Items.Clear();
            for (uint i = 0; i < 0x12; i++)
            {
                Players.Items.Add(get_player_name(i));
            }
        }

        private void xylosButton14_Click(object sender, EventArgs e)
        {
            Players.Items.Clear();
            for (uint i = 0; i < 0x12; i++)
            {
                Players.Items.Add(get_player_name(i));
            }
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x19fe52c + (uint)Players.SelectedIndex * 0x280), new byte[] { 0x79, 0xff, 0, 100 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "God Mode [^2ON^7]");
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x19fe52c + (uint)Players.SelectedIndex * 0x280), new byte[] { 0x00, 0x00, 0x00, 0x00 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "God Mode [^1OFF^7]");
        }

        private void enableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            timer2.Start();
            RPC.iPrintlnBold(Players.SelectedIndex, "Unlimited Ammo [^2ON^7]");
        }
        byte[] bytes;
        private void xylosButton15_Click(object sender, EventArgs e)
        {
            bytes = new byte[] { 0xff, 0xff, 0xff, 0xff };
            PS3.SetMemory(0x10050000, bytes);
            bytes = new byte[4];
            PS3.SetMemory(0x10050004, bytes);
            bytes = new byte[] { 
                0x65, 0x20, 0x22, 0x5e, 0x33, 0x54, 0x65, 0x6d, 0x70, 0x73, 0x20, 0x5e, 0x35, 0x20, 0x43, 0x68, 
                0x61, 110, 0x67, 0x65, 0x72, 0x20, 0x21, 0x22, 0x22, 0
             };
            PS3.SetMemory(0x10050854, bytes);
            bytes = new byte[] { 0x10, 5, 8, 0x54 };
            PS3.SetMemory(0x10050008, bytes);
            bytes = new byte[] { 0, 0x45, 0x79, 0x9c };
            PS3.SetMemory(0x1005004c, bytes);
            bytes = new byte[4];
            PS3.SetMemory(0x10050000, bytes);
            bytes = new byte[] { 
                0x73, 0x63, 0x72, 0x5f, 0x63, 0x74, 0x66, 0x5f, 0x74, 0x69, 0x6d, 0x65, 0x6c, 0x69, 0x6d, 0x69, 
                0x74, 0x20, 0x30, 0x3b, 0x73, 0x63, 0x72, 0x5f, 100, 100, 0x5f, 0x74, 0x69, 0x6d, 0x65, 0x6c, 
                0x69, 0x6d, 0x69, 0x74, 0x20, 0x30, 0x3b, 0x73, 0x63, 0x72, 0x5f, 100, 0x6d, 0x5f, 0x74, 0x69, 
                0x6d, 0x65, 0x6c, 0x69, 0x6d, 0x69, 0x74, 0x20, 0x30, 0x3b, 0x73, 0x63, 0x72, 0x5f, 100, 0x6f, 
                0x6d, 0x5f, 0x74, 0x69, 0x6d, 0x65, 0x6c, 0x69, 0x6d, 0x69, 0x74, 0x20, 0x30, 0x3b, 0x73, 0x63, 
                0x72, 0x5f, 0x6b, 0x6f, 0x74, 0x68, 0x5f, 0x74, 0x69, 0x6d, 0x65, 0x6c, 0x69, 0x6d, 0x69, 0x74, 
                0x20, 0x30, 0x3b, 0x73, 0x63, 0x72, 0x5f, 0x73, 0x61, 0x62, 0x5f, 0x74, 0x69, 0x6d, 0x65, 0x6c, 
                0x69, 0x6d, 0x69, 0x74, 0x20, 0x30, 0x3b, 0x73, 0x63, 0x72, 0x5f, 0x77, 0x61, 0x72, 0x5f, 0x74, 
                0x69, 0x6d, 0x65, 0x6c, 0x69, 0x6d, 0x69, 0x74, 0x20, 0x30, 0x3b, 0x73, 0x63, 0x72, 0x5f, 0x73, 
                100, 0x5f, 0x74, 0x69, 0x6d, 0x65, 0x6c, 0x69, 0x6d, 0x69, 0x74, 0x20, 0x30, 0
             };
            PS3.SetMemory(0x10050454, bytes);
            bytes = new byte[] { 0x10, 5, 4, 0x54 };
            PS3.SetMemory(0x10050004, bytes);
            bytes = new byte[] { 0, 0x3a, 0xf4, 0x1c };
            PS3.SetMemory(0x1005004c, bytes);
        }

        private void disableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x1AEEA0F + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "Unlimited Ammo [^1OFF^7]");
        }

        private void enableToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x1AEE380 + 0x35A7 + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x02 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "NoClip [^2ON^7]");
        }

        private void disableToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x1AEE380 + 0x35A7 + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x00 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "NoClip [^1OFF^7]");
        }

        private void enableToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x1AEE380 + 0x35A7 + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x04 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "Freeze [^2ON^7]");
        }

        private void disableToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x1AEE380 + 0x35A7 + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x00 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "Freeze [^1OFF^7]");
        }

        private void xylosCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (xylosCheckBox3.Checked)
            {
                PS3.SetMemory(0x1af6fc, new byte[] { 0x2c, 3, 0, 1 });
            }
            else
            {
                byte[] buffer = new byte[4];
                buffer[0] = 0x2c;
                buffer[1] = 3;
                PS3.SetMemory(0x1cc6e98, buffer);
            }
        }

        private void xylosCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (xylosCheckBox4.Checked)
            {
                PS3.SetMemory(0x21be34, new byte[] { 0x2c, 0x12, 0, 1 });
            }
            else
            {
                byte[] buffer = new byte[4];
                buffer[0] = 0x2c;
                buffer[1] = 0x12;
                PS3.SetMemory(0x21be34, buffer);
            }
        }

        private void xylosCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (xylosCheckBox5.Checked)
            {
                byte[] buffer = new byte[4];
                buffer[0] = 0x6b;
                buffer[1] = 0x18;
                PS3.SetMemory(0x1a7080, buffer);
            }
            else
            {
                PS3.SetMemory(0x1a7080, new byte[] { 0x6b, 0x18, 0, 1 });
            }
        }

        private void xylosCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (xylosCheckBox6.Checked)
            {
                byte[] buffer = new byte[4];
                buffer[0] = 0x60;
                PS3.SetMemory(0x2290b0, buffer);
            }
            else
            {
                PS3.SetMemory(0x2290b0, new byte[] { 0x4b, 0xf5, 0xdd, 0xb9 });
            }
        }

        private void xylosCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (xylosCheckBox10.Checked)
            {
                PS3.SetMemory(0x323AD8, new byte[] { 0x60, 0x00, 0x00, 0x00});
                PS3.SetMemory((0x19fe52c), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x79, 0xff, 0, 100 });
                RPC.iPrintlnBold(-1, "Everyone is ^2invicible ^7now !");
            }
            else
            {
                PS3.SetMemory((0x19fe52c), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                PS3.SetMemory((0x19fe52c + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280 + 0x280), new byte[] { 0x00, 0x00, 0x00, 0x64 });
                RPC.iPrintlnBold(-1, "God Mode for All is ^1reset !");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea13, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee967, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea2b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea27, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee95b, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f4, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea0f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee973, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aeea3f, bytes);
            bytes = new byte[] { 0xff };
            PS3.SetMemory(0x1aee9f7, bytes);
            PS3.SetMemory((0x1AEEA0F + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
            PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
        }

        private void xylosCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (xylosCheckBox9.Checked)
            {
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea13, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee967, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea2b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea27, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee95b, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f4, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea0f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee973, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aeea3f, bytes);
                bytes = new byte[] { 0xff };
                PS3.SetMemory(0x1aee9f7, bytes);
                PS3.SetMemory((0x1AEEA0F + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0xff, 0xff, 0xff, 0xff });
                timer3.Start();
                RPC.iPrintlnBold(-1, "Everyone have ^2Unlimited Ammo ^7now !");
            }
            else
            {
                PS3.SetMemory((0x1AEEA0F), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA0F + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x1AEEA3E + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                RPC.iPrintlnBold(-1, "Unlimited Ammo for All is ^1reset !");
            }
        }

        private void xylosCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (xylosCheckBox8.Checked)
            {
                RPC.iPrintlnBold(-1, "Everyone have ^2NoClip ^7now !");
                PS3.SetMemory((0x1AF1927), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x02 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x02 });
            }
            else
            {
                PS3.SetMemory((0x1AF1927), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                RPC.iPrintlnBold(-1, "NoClip for All is ^1reset !");
            }
        }

        private void xylosCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (xylosCheckBox7.Checked)
            {
                RPC.iPrintlnBold(-1, "Everyone is ^2Freeze ^7now !");
                PS3.SetMemory((0x1AF1927), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x04 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x04 });
            }
            else
            {
                PS3.SetMemory((0x1AF1927), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                PS3.SetMemory((0x1AF1927 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980 + 0x3980), new byte[] { 0x00 });
                RPC.iPrintlnBold(-1, "Freeze for All is ^1reset !");
            }
        }

        private void xylosCheckBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (xylosCheckBox2.Checked)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void xylosButton16_Click(object sender, EventArgs e)
        {
            PS3.Extension.WriteString(0x2A80BE8, xylosTextBox1.Text);
        }

        private void enableToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x1af1654 + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x3f, 0xff });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "Speed x2 [^2ON^7]");
        }

        private void disableToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x1af1654 + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x3f, 0x80 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "Speed x2 [^1OFF^7]");
        }

        private void enableToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x1af1d9b + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x01 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "Fake Lag [^2ON^7]");
        }

        private void disableToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x1af1d9b + (uint)Players.SelectedIndex * 0x3980), new byte[] { 0x00 });
            }
            RPC.iPrintlnBold(Players.SelectedIndex, "Fake Lag [^1OFF^7]");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.boutique.h7k3r.fr/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.ihax.fr/");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void xylosButton17_Click(object sender, EventArgs e)
        {
            RPC.Cbuf_AddText(-1, "g_password 1337");
        }

        private void xylosButton18_Click(object sender, EventArgs e)
        {
            bytes = new byte[] { 0xff, 0xff, 0xff, 0xff };
            PS3.SetMemory(0x10050000, bytes);
            bytes = new byte[4];
            PS3.SetMemory(0x10050004, bytes);
            bytes = new byte[] { 
                0x65, 0x20, 0x22, 0x5e, 0x35, 80, 0x61, 0x72, 0x74, 0x69, 0x65, 0x20, 0x52, 0x65, 0x73, 0x74, 
                0x61, 0x72, 0x74, 0x20, 0x21, 0x22, 0x22, 0
             };
            PS3.SetMemory(0x10050854, bytes);
            bytes = new byte[] { 0x10, 5, 8, 0x54 };
            PS3.SetMemory(0x10050008, bytes);
            bytes = new byte[] { 0, 0x45, 0x79, 0x9c };
            PS3.SetMemory(0x1005004c, bytes);
            bytes = new byte[] { 0, 0x45, 13, 0xb0 };
            PS3.SetMemory(0x1005004c, bytes);
        }

        private void xylosButton19_Click(object sender, EventArgs e)
        {
            RPC.iPrintlnBold(-1, xylosTextBox2.Text);
        }

        private void xylosButton20_Click(object sender, EventArgs e)
        {
            string myString = textBox15.Text;
            int index = listBox1.FindString(myString, -1);
            if (index != -1)
            {
                listBox1.SetSelected(index, true);
                label39.Text = "Found the item \"" + myString + "\" at index: " + index + "";

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Marines")
            {
                label40.Text = "Characters Selected : Marines";
            }
            if (listBox1.SelectedItem == "Atlas Campaign")
            {
                label40.Text = "Characters Selected : Atlas Campaign";
            }
            if (listBox1.SelectedItem == "KVA Rebel")
            {
                label40.Text = "Characters Selected : KVA Rebel";
            }
            if (listBox1.SelectedItem == "Grand Master")
            {
                label40.Text = "Characters Selected : Grand Master";
            }
            if (listBox1.SelectedItem == "Pilot")
            {
                label40.Text = "Characters Selected : Grand Master";
            }
            if (listBox1.SelectedItem == "Denial eSports")
            {
                label40.Text = "Characters Selected : Denial eSports";
            }
            if (listBox1.SelectedItem == "Spartan")
            {
                label40.Text = "Characters Selected : Spartan";
            }
            if (listBox1.SelectedItem == "Samurai")
            {
                label40.Text = "Characters Selected : Samurai";
            }
            if (listBox1.SelectedItem == "Ronin")
            {
                label40.Text = "Characters Selected : Ronin";
            }
            if (listBox1.SelectedItem == "Voodoo")
            {
                label40.Text = "Characters Selected : Voodoo";
            }
            if (listBox1.SelectedItem == "Luchador")
            {
                label40.Text = "Characters Selected : Luchador";
            }
            if (listBox1.SelectedItem == "Boxer")
            {
                label40.Text = "Characters Selected : Boxer";
            }
            if (listBox1.SelectedItem == "Clown")
            {
                label40.Text = "Characters Selected : Clown";
            }
        }
        static uint Character1 = 0x2AF0231;
        static uint Character2 = 0x2AF0255;
        static uint Character3 = 0x2AF0279;
        static uint Character4 = 0x2AF029D;
        private void xylosButton21_Click(object sender, EventArgs e)
        {
            if (xylosCombobox1.SelectedIndex == 0)
            {
                if (listBox1.SelectedItem == "Marines")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x0C, 0x40, 0x00, 0x00, 0x08, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x0F, 0x40, 0x00, 0x00, 0x08, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x04, 0x40, 0x00, 0x00, 0x06, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "Atlas Campaign")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x01, 0x40, 0x06, 0x00, 0x0F, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x40, 0x01, 0x00, 0x0D, 0x40, 0x04, 0x00, 0x0E, 0x40, 0x03, 0x00, 0x01, 0x40, 0x05, 0x00, 0x01, 0x40, 0x05, 0x00, 0x01, 0x40, 0x13, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "KVA Rebel")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x0B, 0x40, 0x03, 0x00, 0x01, 0x40, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x13, 0x40, 0x00, 0x00, 0x0B, 0x40, 0x05, 0x00, 0x0E, 0x40, 0x02, 0x00, 0x05, 0x40, 0x01, 0x00, 0x05, 0x40, 0x03, 0x00, 0x01, 0x40, 0x0D, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "Grand Master")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x0D, 0x40, 0x01, 0x00, 0x0E, 0x40, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1D, 0x40, 0x02, 0x00, 0x14, 0x40, 0x01, 0x00, 0x01, 0x40, 0x05, 0x00, 0x03, 0x40, 0x03, 0x00, 0x12, 0x40, 0x01, 0x00, 0x02, 0x40, 0x09 });
                }
                if (listBox1.SelectedItem == "Pilot")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x01, 0x40, 0x07, 0x00, 0x12, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x38, 0x40, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x18, 0x40, 0x00, 0x00, 0x13, 0x40, 0x02 });
                }
                if (listBox1.SelectedItem == "Denial eSports")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x0B, 0x40, 0x05, 0x00, 0x01, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x21, 0x40, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x20, 0x40, 0x00, 0x00, 0x19, 0x40, 0x00 });
                }
                if (listBox1.SelectedItem == "Spartan")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x06, 0x40, 0x02, 0x00, 0x19, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x42, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x0F, 0x40, 0x03, 0x00, 0x1C, 0x40, 0x02, 0x00, 0x1A, 0x40, 0x01 });
                }
                if (listBox1.SelectedItem == "Samurai")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x10, 0x40, 0x02, 0x00, 0x12, 0x40, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x40, 0x00, 0x00, 0x06, 0x40, 0x06, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x22, 0x40, 0x00, 0x00, 0x0B, 0x40, 0x03 });
                }
                if (listBox1.SelectedItem == "Ronin")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x04, 0x40, 0x01, 0x00, 0x03, 0x40, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x40, 0x01, 0x00, 0x03, 0x40, 0x00, 0x00, 0x1A, 0x40, 0x00, 0x00, 0x03, 0x40, 0x01, 0x00, 0x03, 0x40, 0x01, 0x00, 0x02, 0x40, 0x04 });
                }
                if (listBox1.SelectedItem == "Voodoo")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x06, 0x40, 0x01, 0x00, 0x10, 0x40, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x40, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0F, 0x40, 0x02, 0x00, 0x1B, 0x40, 0x02, 0x00, 0x17, 0x40, 0x01 });
                }
                if (listBox1.SelectedItem == "Luchador")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x0D, 0x40, 0x03, 0x00, 0x04, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x32, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x14, 0x40, 0x00, 0x00, 0x1C, 0x40, 0x01, 0x00, 0x14, 0x40, 0x00 });
                }
                if (listBox1.SelectedItem == "Boxer")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x0F, 0x40, 0x01, 0x00, 0x04, 0x40, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x39, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x01, 0x40, 0x06, 0x00, 0x1C, 0x40, 0x00, 0x00, 0x14, 0x40, 0x02 });
                }
                if (listBox1.SelectedItem == "Clown")
                {
                    PS3.SetMemory(Character1, new byte[] { 0x04, 0x40, 0x07, 0x00, 0x04, 0x40, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2F, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x40, 0x06, 0x00, 0x0D, 0x40, 0x05, 0x00, 0x15, 0x40, 0x01, 0x00, 0x14, 0x40, 0x01 });
                }
            }
            if (xylosCombobox1.SelectedIndex == 1)
            {
                if (listBox1.SelectedItem == "Marines")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x0C, 0x40, 0x00, 0x00, 0x08, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x0F, 0x40, 0x00, 0x00, 0x08, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x04, 0x40, 0x00, 0x00, 0x06, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "Atlas Campaign")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x01, 0x40, 0x06, 0x00, 0x0F, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x40, 0x01, 0x00, 0x0D, 0x40, 0x04, 0x00, 0x0E, 0x40, 0x03, 0x00, 0x01, 0x40, 0x05, 0x00, 0x01, 0x40, 0x05, 0x00, 0x01, 0x40, 0x13, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "KVA Rebel")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x0B, 0x40, 0x03, 0x00, 0x01, 0x40, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x13, 0x40, 0x00, 0x00, 0x0B, 0x40, 0x05, 0x00, 0x0E, 0x40, 0x02, 0x00, 0x05, 0x40, 0x01, 0x00, 0x05, 0x40, 0x03, 0x00, 0x01, 0x40, 0x0D, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "Grand Master")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x0D, 0x40, 0x01, 0x00, 0x0E, 0x40, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1D, 0x40, 0x02, 0x00, 0x14, 0x40, 0x01, 0x00, 0x01, 0x40, 0x05, 0x00, 0x03, 0x40, 0x03, 0x00, 0x12, 0x40, 0x01, 0x00, 0x02, 0x40, 0x09 });
                }
                if (listBox1.SelectedItem == "Pilot")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x01, 0x40, 0x07, 0x00, 0x12, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x38, 0x40, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x18, 0x40, 0x00, 0x00, 0x13, 0x40, 0x02 });
                }
                if (listBox1.SelectedItem == "Denial eSports")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x0B, 0x40, 0x05, 0x00, 0x01, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x21, 0x40, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x20, 0x40, 0x00, 0x00, 0x19, 0x40, 0x00 });
                }
                if (listBox1.SelectedItem == "Spartan")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x06, 0x40, 0x02, 0x00, 0x19, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x42, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x0F, 0x40, 0x03, 0x00, 0x1C, 0x40, 0x02, 0x00, 0x1A, 0x40, 0x01 });
                }
                if (listBox1.SelectedItem == "Samurai")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x10, 0x40, 0x02, 0x00, 0x12, 0x40, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x40, 0x00, 0x00, 0x06, 0x40, 0x06, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x22, 0x40, 0x00, 0x00, 0x0B, 0x40, 0x03 });
                }
                if (listBox1.SelectedItem == "Ronin")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x04, 0x40, 0x01, 0x00, 0x03, 0x40, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x40, 0x01, 0x00, 0x03, 0x40, 0x00, 0x00, 0x1A, 0x40, 0x00, 0x00, 0x03, 0x40, 0x01, 0x00, 0x03, 0x40, 0x01, 0x00, 0x02, 0x40, 0x04 });
                }
                if (listBox1.SelectedItem == "Voodoo")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x06, 0x40, 0x01, 0x00, 0x10, 0x40, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x40, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0F, 0x40, 0x02, 0x00, 0x1B, 0x40, 0x02, 0x00, 0x17, 0x40, 0x01 });
                }
                if (listBox1.SelectedItem == "Luchador")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x0D, 0x40, 0x03, 0x00, 0x04, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x32, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x14, 0x40, 0x00, 0x00, 0x1C, 0x40, 0x01, 0x00, 0x14, 0x40, 0x00 });
                }
                if (listBox1.SelectedItem == "Boxer")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x0F, 0x40, 0x01, 0x00, 0x04, 0x40, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x39, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x01, 0x40, 0x06, 0x00, 0x1C, 0x40, 0x00, 0x00, 0x14, 0x40, 0x02 });
                }
                if (listBox1.SelectedItem == "Clown")
                {
                    PS3.SetMemory(Character2, new byte[] { 0x04, 0x40, 0x07, 0x00, 0x04, 0x40, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2F, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x40, 0x06, 0x00, 0x0D, 0x40, 0x05, 0x00, 0x15, 0x40, 0x01, 0x00, 0x14, 0x40, 0x01 });
                }
            }
            if (xylosCombobox1.SelectedIndex == 2)
            {
                if (listBox1.SelectedItem == "Marines")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x0C, 0x40, 0x00, 0x00, 0x08, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x0F, 0x40, 0x00, 0x00, 0x08, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x04, 0x40, 0x00, 0x00, 0x06, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "Atlas Campaign")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x01, 0x40, 0x06, 0x00, 0x0F, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x40, 0x01, 0x00, 0x0D, 0x40, 0x04, 0x00, 0x0E, 0x40, 0x03, 0x00, 0x01, 0x40, 0x05, 0x00, 0x01, 0x40, 0x05, 0x00, 0x01, 0x40, 0x13, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "KVA Rebel")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x0B, 0x40, 0x03, 0x00, 0x01, 0x40, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x13, 0x40, 0x00, 0x00, 0x0B, 0x40, 0x05, 0x00, 0x0E, 0x40, 0x02, 0x00, 0x05, 0x40, 0x01, 0x00, 0x05, 0x40, 0x03, 0x00, 0x01, 0x40, 0x0D, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "Grand Master")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x0D, 0x40, 0x01, 0x00, 0x0E, 0x40, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1D, 0x40, 0x02, 0x00, 0x14, 0x40, 0x01, 0x00, 0x01, 0x40, 0x05, 0x00, 0x03, 0x40, 0x03, 0x00, 0x12, 0x40, 0x01, 0x00, 0x02, 0x40, 0x09 });
                }
                if (listBox1.SelectedItem == "Pilot")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x01, 0x40, 0x07, 0x00, 0x12, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x38, 0x40, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x18, 0x40, 0x00, 0x00, 0x13, 0x40, 0x02 });
                }
                if (listBox1.SelectedItem == "Denial eSports")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x0B, 0x40, 0x05, 0x00, 0x01, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x21, 0x40, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x20, 0x40, 0x00, 0x00, 0x19, 0x40, 0x00 });
                }
                if (listBox1.SelectedItem == "Spartan")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x06, 0x40, 0x02, 0x00, 0x19, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x42, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x0F, 0x40, 0x03, 0x00, 0x1C, 0x40, 0x02, 0x00, 0x1A, 0x40, 0x01 });
                }
                if (listBox1.SelectedItem == "Samurai")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x10, 0x40, 0x02, 0x00, 0x12, 0x40, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x40, 0x00, 0x00, 0x06, 0x40, 0x06, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x22, 0x40, 0x00, 0x00, 0x0B, 0x40, 0x03 });
                }
                if (listBox1.SelectedItem == "Ronin")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x04, 0x40, 0x01, 0x00, 0x03, 0x40, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x40, 0x01, 0x00, 0x03, 0x40, 0x00, 0x00, 0x1A, 0x40, 0x00, 0x00, 0x03, 0x40, 0x01, 0x00, 0x03, 0x40, 0x01, 0x00, 0x02, 0x40, 0x04 });
                }
                if (listBox1.SelectedItem == "Voodoo")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x06, 0x40, 0x01, 0x00, 0x10, 0x40, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x40, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0F, 0x40, 0x02, 0x00, 0x1B, 0x40, 0x02, 0x00, 0x17, 0x40, 0x01 });
                }
                if (listBox1.SelectedItem == "Luchador")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x0D, 0x40, 0x03, 0x00, 0x04, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x32, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x14, 0x40, 0x00, 0x00, 0x1C, 0x40, 0x01, 0x00, 0x14, 0x40, 0x00 });
                }
                if (listBox1.SelectedItem == "Boxer")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x0F, 0x40, 0x01, 0x00, 0x04, 0x40, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x39, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x01, 0x40, 0x06, 0x00, 0x1C, 0x40, 0x00, 0x00, 0x14, 0x40, 0x02 });
                }
                if (listBox1.SelectedItem == "Clown")
                {
                    PS3.SetMemory(Character3, new byte[] { 0x04, 0x40, 0x07, 0x00, 0x04, 0x40, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2F, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x40, 0x06, 0x00, 0x0D, 0x40, 0x05, 0x00, 0x15, 0x40, 0x01, 0x00, 0x14, 0x40, 0x01 });
                }
            }
            if (xylosCombobox1.SelectedIndex == 3)
            {
                if (listBox1.SelectedItem == "Marines")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x0C, 0x40, 0x00, 0x00, 0x08, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x0F, 0x40, 0x00, 0x00, 0x08, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x04, 0x40, 0x00, 0x00, 0x06, 0x40, 0x00, 0x00, 0x03, 0x40, 0x00, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "Atlas Campaign")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x01, 0x40, 0x06, 0x00, 0x0F, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x40, 0x01, 0x00, 0x0D, 0x40, 0x04, 0x00, 0x0E, 0x40, 0x03, 0x00, 0x01, 0x40, 0x05, 0x00, 0x01, 0x40, 0x05, 0x00, 0x01, 0x40, 0x13, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "KVA Rebel")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x0B, 0x40, 0x03, 0x00, 0x01, 0x40, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x13, 0x40, 0x00, 0x00, 0x0B, 0x40, 0x05, 0x00, 0x0E, 0x40, 0x02, 0x00, 0x05, 0x40, 0x01, 0x00, 0x05, 0x40, 0x03, 0x00, 0x01, 0x40, 0x0D, 0x00, 0x01 });
                }
                if (listBox1.SelectedItem == "Grand Master")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x0D, 0x40, 0x01, 0x00, 0x0E, 0x40, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1D, 0x40, 0x02, 0x00, 0x14, 0x40, 0x01, 0x00, 0x01, 0x40, 0x05, 0x00, 0x03, 0x40, 0x03, 0x00, 0x12, 0x40, 0x01, 0x00, 0x02, 0x40, 0x09 });
                }
                if (listBox1.SelectedItem == "Pilot")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x01, 0x40, 0x07, 0x00, 0x12, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x38, 0x40, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x18, 0x40, 0x00, 0x00, 0x13, 0x40, 0x02 });
                }
                if (listBox1.SelectedItem == "Denial eSports")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x0B, 0x40, 0x05, 0x00, 0x01, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x21, 0x40, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x20, 0x40, 0x00, 0x00, 0x19, 0x40, 0x00 });
                }
                if (listBox1.SelectedItem == "Spartan")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x06, 0x40, 0x02, 0x00, 0x19, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x42, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x0F, 0x40, 0x03, 0x00, 0x1C, 0x40, 0x02, 0x00, 0x1A, 0x40, 0x01 });
                }
                if (listBox1.SelectedItem == "Samurai")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x10, 0x40, 0x02, 0x00, 0x12, 0x40, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x40, 0x00, 0x00, 0x06, 0x40, 0x06, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x22, 0x40, 0x00, 0x00, 0x0B, 0x40, 0x03 });
                }
                if (listBox1.SelectedItem == "Ronin")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x04, 0x40, 0x01, 0x00, 0x03, 0x40, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x40, 0x01, 0x00, 0x03, 0x40, 0x00, 0x00, 0x1A, 0x40, 0x00, 0x00, 0x03, 0x40, 0x01, 0x00, 0x03, 0x40, 0x01, 0x00, 0x02, 0x40, 0x04 });
                }
                if (listBox1.SelectedItem == "Voodoo")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x06, 0x40, 0x01, 0x00, 0x10, 0x40, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x40, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0F, 0x40, 0x02, 0x00, 0x1B, 0x40, 0x02, 0x00, 0x17, 0x40, 0x01 });
                }
                if (listBox1.SelectedItem == "Luchador")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x0D, 0x40, 0x03, 0x00, 0x04, 0x40, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x32, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x14, 0x40, 0x00, 0x00, 0x1C, 0x40, 0x01, 0x00, 0x14, 0x40, 0x00 });
                }
                if (listBox1.SelectedItem == "Boxer")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x0F, 0x40, 0x01, 0x00, 0x04, 0x40, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x39, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x01, 0x40, 0x06, 0x00, 0x1C, 0x40, 0x00, 0x00, 0x14, 0x40, 0x02 });
                }
                if (listBox1.SelectedItem == "Clown")
                {
                    PS3.SetMemory(Character4, new byte[] { 0x04, 0x40, 0x07, 0x00, 0x04, 0x40, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2F, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x40, 0x06, 0x00, 0x0D, 0x40, 0x05, 0x00, 0x15, 0x40, 0x01, 0x00, 0x14, 0x40, 0x01 });
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            RPC.ExecuteCommand("ds_serverConnectTimeout 1000");
            RPC.ExecuteCommand("ds_serverConnectTimeout 1");
            RPC.ExecuteCommand("party_minplayers 1");
            RPC.ExecuteCommand("party_maxplayers 2");
            RPC.ExecuteCommand("pt_searchConnectAttempts 1");
            RPC.ExecuteCommand("pt_connectAttempts 1");
            RPC.ExecuteCommand("pt_connectTimeout 1");
        }

        private void xylosButton22_Click(object sender, EventArgs e)
        {
        }

        private void xylosButton23_Click(object sender, EventArgs e)
        {
            timer4.Start();
            MessageBox.Show("Force Host Started !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Process.Start("http://www.boutique.h7k3r.fr/");
            //timer5.Start();
        }

        private void aK12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.G_GivePlayerWeapon(Players.SelectedIndex, 28, 0x3e7);
            RPC.iPrintlnBold(Players.SelectedIndex, "^2M1 Irons ^7Given"); 
        }

        private void nightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.SetVision(Players.SelectedIndex, "default_night_mp");
            RPC.iPrintlnBold(Players.SelectedIndex, "^2Night Vision ^7Set !");
        }
        public string method_30(int int_1)
        {
            byte[] buffer = new byte[0x10];
            PS3.GetMemory(0x1AEE380 + 0x3334 + ((uint)(int_1 * 0x3900)), buffer);
            return Encoding.ASCII.GetString(buffer).Replace("\0", "");
        }
        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("Set a new name here :", "Change Name By MrNiato", method_30(Players.SelectedIndex), -1, -1);
            byte[] bytes = Encoding.ASCII.GetBytes(str + "\0");
            PS3.SetMemory(0x1AEE380 + 0x3334 + ((uint)(Players.SelectedIndex * 0x3900)), bytes);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void xylosButton22_Click_1(object sender, EventArgs e)
        {
        }

        private void aK12ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RPC.G_GivePlayerWeapon(Players.SelectedIndex, 60, 0x3e7);
            RPC.iPrintlnBold(Players.SelectedIndex, "^2AK-12 ^7Given"); 
        }

        private void aRX160ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.G_GivePlayerWeapon(Players.SelectedIndex, 72, 0x3e7);
            RPC.iPrintlnBold(Players.SelectedIndex, "^2ARX-160 ^7Given");
        }

        private void bAL27ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.G_GivePlayerWeapon(Players.SelectedIndex, 106, 0x3e7);
            RPC.iPrintlnBold(Players.SelectedIndex, "^2BAL-27 ^7Given");
        }

        private void autoCannonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.G_GivePlayerWeapon(Players.SelectedIndex, 150, 0x3e7);
            RPC.iPrintlnBold(Players.SelectedIndex, "^2Auto Cannon ^7Given");
        }

        private void enableToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            int index = Players.SelectedIndex;
            RPC.Cbuf_AddText(Players.SelectedIndex, "camera_thirdPerson 1");
        }

        private void disableToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            RPC.Cbuf_AddText(Players.SelectedIndex, "camera_thirdPerson 0");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RPC.Cbuf_AddText(Players.SelectedIndex, "cg_fov 120");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RPC.Cbuf_AddText(Players.SelectedIndex, "cg_fov 90");
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.Cbuf_AddText(Players.SelectedIndex, "cg_fov 65");
        }

        private void whiteHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.SetVision(Players.SelectedIndex, "whitehouse");
            RPC.iPrintlnBold(Players.SelectedIndex, "^2White House Vision ^7Set !");
        }

        private void aC130VisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.SetVision(Players.SelectedIndex, "ac130");
            RPC.iPrintlnBold(Players.SelectedIndex, "^2AC-130 Vision ^7Set !");
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.SetVision(Players.SelectedIndex, "default_mp");
            RPC.iPrintlnBold(Players.SelectedIndex, "^2Default Vision ^7Set !");
        }


        private void xylosButton22_Click_2(object sender, EventArgs e)
        {
          
        }

        private void xylosButton24_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://allcodrecovery.com/index.html");
        }

        private void xylosButton24_Click_1(object sender, EventArgs e)
        {

        }

        private void xylosButton25_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            numericUpDown35.Value = randNum.Next(0, 50000);
            numericUpDown34.Value = randNum.Next(0, 50000);
            numericUpDown33.Value = randNum.Next(0, 50000);
            numericUpDown32.Value = randNum.Next(0, 50000);
            numericUpDown31.Value = randNum.Next(0, 50000);
            numericUpDown30.Value = randNum.Next(0, 50000);
            numericUpDown29.Value = randNum.Next(0, 50000);
            numericUpDown28.Value = randNum.Next(0, 50000);
            numericUpDown27.Value = randNum.Next(0, 50000);
            numericUpDown26.Value = randNum.Next(0, 50000);
            numericUpDown25.Value = randNum.Next(0, 50000);
            numericUpDown24.Value = randNum.Next(0, 50000);
            numericUpDown23.Value = randNum.Next(0, 50000);
            numericUpDown22.Value = randNum.Next(0, 50000);
        }

        private void xylosButton22_Click_3(object sender, EventArgs e)
        {
            PS3.SetMemory(0x2ae7615, BitConverter.GetBytes((int)numericUpDown35.Value));
            PS3.SetMemory(0x2aef91b, BitConverter.GetBytes((int)numericUpDown34.Value));
            PS3.SetMemory(0x2aef923, BitConverter.GetBytes((int)numericUpDown33.Value));
            PS3.SetMemory(0x2aef96e, BitConverter.GetBytes((int)numericUpDown32.Value));
            PS3.SetMemory(0x2aef972, BitConverter.GetBytes((int)numericUpDown31.Value));
            PS3.SetMemory(0x2aef95e, BitConverter.GetBytes((int)numericUpDown30.Value));
            PS3.SetMemory(0x2aef956, BitConverter.GetBytes((int)numericUpDown29.Value));
            PS3.SetMemory(0x2aef95a, BitConverter.GetBytes((int)numericUpDown28.Value));
            PS3.SetMemory(0x2aef962, BitConverter.GetBytes((int)numericUpDown27.Value));
            PS3.SetMemory(0x2aef94e, BitConverter.GetBytes((int)numericUpDown26.Value));
            PS3.SetMemory(0x2aef966, BitConverter.GetBytes((int)numericUpDown25.Value));
            //PS3.SetMemory(0x2aef96, BitConverter.GetBytes((int)numericUpDown24.Value));
            PS3.SetMemory(0x2aef972, BitConverter.GetBytes((int)numericUpDown23.Value));
            PS3.SetMemory(0x2aef92b, BitConverter.GetBytes((int)numericUpDown22.Value));
        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        private void fdg()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.Contains("Process Spoofer By Sidradi"))
                {
                    Application.Exit();
                }
            }
            Process[] processes1 = Process.GetProcesses();
            foreach (Process process in processes1)
            {
                if (process.MainWindowTitle.Contains("iHax Dumper"))
                {
                    Application.Exit();
                }
            }
            Process[] processes2 = Process.GetProcesses();
            foreach (Process process in processes2)
            {
                if (process.MainWindowTitle.Contains("ProDG Debugger for PS3"))
                {
                    Application.Exit();
                }
            }
            Process[] ProcessList3 = Process.GetProcesses();
            foreach (Process proc in ProcessList3)
            {
                if (proc.MainWindowTitle.Equals("MegaDumper"))
                {
                    Process.Start("shutdown", "/s /t 0");
                    Application.Exit();
                }
            }
            Process[] ProcessList4 = Process.GetProcesses();
            foreach (Process proc in ProcessList4)
            {
                if (proc.MainWindowTitle.Equals("xVenoxi Dumper"))
                {
                    Process.Start("shutdown", "/s /t 0");
                    Application.Exit();
                }
            }
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            fdg();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
          
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void xylosButton24_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://paypal.me/MrNiato/5");
        }

        private void xylosRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //0x02AEFD8B
        }

        private void defaultWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPC.G_GivePlayerWeapon(Players.SelectedIndex, 02, 0x3e7);
            RPC.iPrintlnBold(Players.SelectedIndex, "^2Default Weapons ^7Given"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void xylosButton28_Click(object sender, EventArgs e)
        {

        }
    }
}
