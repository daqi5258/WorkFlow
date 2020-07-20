using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlow
{
    public partial class SetFrom : Form
    {
        public String fileExportPath;
        public SetFrom()
        {
            InitSetting();
            InitializeComponent();
            
        }

        public void  ButtonST_MouseClick(object sender, MouseEventArgs e)
        {
            fileExportPath=SelectFoldPath(fileExportPath);
            FileExportPath.Text = fileExportPath;
            //Setting();
        }


        public String SelectFoldPath(String selectedPath)
        {
            String path = null;
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "请选择文件路径",
                // dialog.RootFolder  = Environment.SpecialFolder.Desktop; 
                SelectedPath = selectedPath
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }
            return path;
        }


        public void Setting(String filePath)
        {
            iniFile iniF = new iniFile();
            iniF.iniPath = @"./setting.ini";
            iniF.writeIni("FileExportPath", "Path", @filePath);
            Console.WriteLine("path="+iniF.iniPath);
        }

        public void InitSetting()
        {
            iniFile iniF = new iniFile();
            iniF.iniPath = @"./setting.ini";
            fileExportPath = iniF.readIni("FileExportPath", "Path");
            Console.WriteLine("\npath="+iniF.iniPath);
        }

        private void ButtonCM_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (FileExportPath.Text.Length<3)
            {
                Setting("C:/");
            }else
                Setting(FileExportPath.Text);
            this.Dispose(true);
        }
    }
}
