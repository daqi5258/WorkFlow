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
        public String formName;
        public RichTextBox pRTB;
        public String type;
        public String ScoreInAreaPath;
        /// <summary>
        /// 设定界面
        /// </summary>
        /// <param name="rtb"></param>
        public SetFrom(RichTextBox rtb,String type)
        {
           
            this.type = type;
            if (type == "ScoreInAreaPath")
                formName = "打分规则文件路径设置";
            else if (type == "fileExportPath")
            {
                formName = "导出文件路径设置";
            }
            InitSetting();
            InitializeComponent();
            pRTB = rtb;
        }

        public void  ButtonST_MouseClick(object sender, MouseEventArgs e)
        {
            fileExportPath=SelectFoldPath(fileExportPath);
            FileExportPath.Text = fileExportPath;
            //Setting();
        }

        /*
        public String SelectFoldPath(String selectedPath)
        {
            String path = null;
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "请选择文件路径",
                SelectedPath = selectedPath
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }
            return path;
        }
        */
        /// <summary>
        /// 获取项目文件路径
        /// </summary>
        /// <returns>大项目的顶层文件夹路径</returns>
        public String SelectFoldPath(String selectedPath)
        {
            String path = null;
            FolderBrowserForm dialog = new FolderBrowserForm();
            dialog.DirectoryPath = selectedPath;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                path = dialog.DirectoryPath;
            }
            else
                path = selectedPath;
            return path;
        }

        public void Setting(String filePath)
        {
            iniFile iniF = new iniFile();
            iniF.iniPath = @"./setting.ini";
            if ("fileExportPath" == type)
            {
                iniF.writeIni("FileExportPath", "Path", @filePath);
            }else if ("ScoreInAreaPath"==type)
            {
                iniF.writeIni("ScoreInAreaPath", "Path", @filePath);
            }
            
            Console.WriteLine("path="+iniF.iniPath);
        }

        public void InitSetting()
        {
            iniFile iniF = new iniFile();
            iniF.iniPath = @"./setting.ini";
            
            if ("fileExportPath" == type)
            {
                fileExportPath = iniF.readIni("FileExportPath", "Path");
            }else if ("ScoreInAreaPath" == type)
            {
                fileExportPath = iniF.readIni("ScoreInAreaPath", "Path");
            }
            Console.WriteLine("\npath="+iniF.iniPath+",type="+type);
        }

        private void ButtonCM_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (FileExportPath.Text.Length<3)
            {
                Setting("C:/");
            }else
                Setting(FileExportPath.Text);
            pRTB.AppendText("\n路径设置为："+ FileExportPath.Text);
            this.Dispose(true);
        }
    }
}
