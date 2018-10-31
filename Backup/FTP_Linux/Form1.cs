using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using FTP_Linux.code;
using Tamir.SharpSsh;

namespace FTP_Linux
{
    public partial class Form1 : Form
    {
        public string Host;
        public string User;
        public string Pass;
        public string IdentityFile;

        public bool type;

        private SshTransferProtocolBase sshCp=null;
        public Form1()
        {
            InitializeComponent();
            //this.IP.Text = "192.168.1.160";
            //this.userName.Text="zmm";
            //this.password.Text="333";
            this.send.Visible = false;
            this.comboBox1.SelectedIndex = 0;
            this.label6.Visible = false;
        }

        private void openFile_Click(object sender, EventArgs e)
        {

        }

        private void pathTest_Click(object sender, EventArgs e)
        {
            
        }

        private void IPTest_Click(object sender, EventArgs e)
        {

            
            
        }

        private void send_Click_1(object sender, EventArgs e)
        {
            Host = this.IP.Text;
            User = this.userName.Text;
            Pass = this.password.Text;
            IdentityFile = this.targetPath.Text;

            if (!type && !checkDir(IdentityFile))
            {
                MessageBox.Show("路径格式错误");
                return;
            }
            
            Util.SshConnectionInfo input = Util.GetConnectionInfo(Host, User, Pass, IdentityFile);

            sshCp = new Scp(input.Host, input.User);
            sshCp.Password = input.Pass;
            try
            {
                sshCp.Connect();
                MessageBox.Show("连接主机成功");
            }
            catch
            {
                MessageBox.Show("连接主机失败");
                return;
            }
            try
            {
                if (type)
                {
                    sshCp.Get(this.targetPath.Text, this.sourcePath.Text);
                  //  sshCp.Put(this.sourcePath.Text, handleDir(this.sourcePath.Text, this.targetPath.Text));
                    MessageBox.Show("下载成功");
                }
                else
                {
                    sshCp.Put(this.sourcePath.Text, handleDir(this.sourcePath.Text, this.targetPath.Text));
                    MessageBox.Show("上传成功");
                }

            }
            catch
            {
                MessageBox.Show("文件传送失败");
            }
           
        }

        private string  handleDir(string local,string remote)
        {
           string filename="";
           if(local.IndexOf("\\")>0)
           {
               string[] locals = local.Split('\\');
               filename = locals[locals.Length - 1];
           }

           return remote+filename;
        }

        private bool checkDir(string targetDir)
        {
            //检验路径格式
            if ((targetDir.Length - 1) == targetDir.LastIndexOf("/"))
                return true;
            else return false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.comboBox1.SelectedIndex == 0) {
                type = false;
                this.send.Visible = true;
                this.send.Text = "上传文件到目标主机";
                this.openFile.Visible = true;
                this.groupBox1.Text="上传";

            }
            if (this.comboBox1.SelectedIndex == 1)
            {
                
                type = true;
                this.send.Visible = true;
                this.send.Text = "从目标主机下载文件";

                this.openFile.Visible = false;

                this.groupBox1.Text = "下载";
            }
        }

        private void openFile_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "选择文件";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                String fileName = fileDialog.FileName;
                this.sourcePath.Text = fileDialog.FileName; ;
            }
            else
            {
            } 
        }

 





    }
}
