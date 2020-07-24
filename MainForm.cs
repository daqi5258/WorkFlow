using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkFlow
{
    public partial class MainForm : Form
    {
        
        public IWorkbook workbook;
        public String Exportpath;
        public MainForm()
        {
            InitSetting();
            InitializeComponent();
            
        }

       public void clear()
       {
            MainPanel.Controls.Clear();
       }
        private void ZGB_Tool1_1_Click(object sender, EventArgs e)
        {
            clear();
            FolderPanel fdPanel = new FolderPanel();
            fdPanel.init(this.MessageText, "1_1", Exportpath, progressBar);
            MainPanel.Controls.Add(fdPanel);
            this.ClientSize = new System.Drawing.Size(800, 720);
            this.ResumeLayout(false);
        }
        private void ZGB_Tool1_2_Click(object sender, EventArgs e)
        {
            clear();
            FolderPanel fdPanel = new FolderPanel();
            fdPanel.init(this.MessageText, "1_2", Exportpath, progressBar);
            MainPanel.Controls.Add(fdPanel);
            this.ClientSize = new System.Drawing.Size(800, 720);
            this.ResumeLayout(false);
        }

        private void newPA_Click(object sender, EventArgs e)
        {
            clear();
            PAMain PAMain = new PAMain();
            PAMain.init(this.MessageText);
            MainPanel.Controls.Add(PAMain);
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.ResumeLayout(false);
        }

        private void openPA_Click(object sender, EventArgs e)
        {
           
        }





      
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
            return path;
        }
        /*
        public String[] GetFiles(String filePath,String project_id,String project_name)
        {
            OracleDB odb = new OracleDB();
            String del = "delete from data0001 where project_id ="+project_id;
            odb.ExecuteSQL(del);
            string[] files1 = Directory.GetFiles(filePath + @"\项师-工作目录\6 出图设校审存档", "总工办*分*.xls*", SearchOption.AllDirectories);
            //System.IO.File.WriteAllLines(@"E:\评分表信息.txt", files1);
            
            foreach (String tmp in files1)
            {
                String sql = "merge into data0001 using (select '"+tmp.ToString()+"' name,'"+ project_id + "' as project_id ,'"+ project_name + "' as project_name from dual ) tmp on (data0001.name =tmp.name and  data0001.project=tmp.project_id and data0001.project_name=tmp.project_name) when not matched then insert (pkey,name,project_name,project_id) values(data0001_seq.nextval,tmp.name,tmp.project_name,tmp.project_id)  ";
                odb.ExecuteSQL(sql);
            }
            return files1;
        }
        */

        /*
        public void Check(String flag)
        {
            progressBar.Value =0;
            OracleDB odb = new OracleDB();
            //单项目文件总目录
            String str = SelectFoldPath(@"\\Hcdata\和创施工图设计平台\居住一所\");
            if (str ==null)
            {
                ShowMessage("操作失败！");
                return;
            }
            ShowMessage("您选择的项目是："+str.Split('\\')[6]+",程序已经开始检索，请等待检索完成......");
            String dept = str.Split('\\')[4];
            if (str.Length<0)
                return;
            String[] XS = Directory.GetDirectories(str, "*项师*", SearchOption.TopDirectoryOnly);
            if(XS==null){
                ShowMessage("没有相师目录，操作失败！");
                return;
            }
            //人员信息表
            String[] ISO = Directory.GetDirectories(XS[0],"*ISO*", SearchOption.TopDirectoryOnly);
            //String[] ISOBG = getFold(ISO[0], "*ISO*", SearchOption.TopDirectoryOnly);
            String[] RY = Directory.GetDirectories(ISO[0], "*人员*", SearchOption.AllDirectories);
            PersonArrange pa = new PersonArrange();
            if (ISO.Length > 0)
            {
                try
                {
                    pa = pa.GetPersonDetail(ISO[0]);
                    ShowMessage("人员安排表检索成功！");
                }
                catch (Exception e)
                {
                    ShowMessage("人员安排表读取失败！");
                }
            }
            progressBar.Value = 10;

            Console.WriteLine("str="+str);
            String project_id = str.Substring(str.LastIndexOf("\\")+1,6) ;
            String project_name =  str.Substring(str.LastIndexOf("\\") + 7) ;
            if (pa != null)
            {
                if (pa.project_id != null)
                {
                    project_id = pa.project_id;
                }
                if (pa.project_name != null)
                {
                    project_name = pa.project_name;
                }
            }
            String[] ctsj = Directory.GetDirectories(XS[0], "*出图设校*", SearchOption.TopDirectoryOnly);
            String[] zt = Directory.GetDirectories(ctsj[0], "*总图*", SearchOption.TopDirectoryOnly);
            String[] nt = Directory.GetDirectories(ctsj[0], "*暖通*", SearchOption.TopDirectoryOnly);
            String[] jz = Directory.GetDirectories(ctsj[0], "*建筑*", SearchOption.TopDirectoryOnly);
            String[] gps = Directory.GetDirectories(ctsj[0], "*给排水*", SearchOption.TopDirectoryOnly);
            String[] jg = Directory.GetDirectories(ctsj[0], "*结构*", SearchOption.TopDirectoryOnly);
            String[] dq = Directory.GetDirectories(ctsj[0], "*电*", SearchOption.TopDirectoryOnly);

            String[] zy = new String[5];
            if (nt.Length>0)
            {
                zy[0] = nt[0];
            }
            if (jz.Length > 0)
            {
                zy[1] = jz[0];
            }
            if (gps.Length > 0)
            {
                zy[2] = gps[0];
            }
            if (jg.Length > 0)
            {
                zy[3] = jg[0];
            }
            if (dq.Length > 0)
            {
                zy[4] = dq[0];
            }
            List<String[]> res = new List<String[]>();
            int ColCount = 8;
            if (flag=="1_2")
            {
                ColCount = 14;
            }
            //检索5大专业的打分信息
            foreach (String path in zy)
            {
                if(path == null){
                    continue;
                }
                String[] tmp = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                String zttmp = path.Substring(path.LastIndexOf("\\") + 1);
                foreach (String det in tmp)
                {
                    String[] resStr = new String[ColCount];
                    resStr[0] = project_id;
                    resStr[1] = project_name;
                    resStr[2] = zttmp;
                    resStr[3] = det.Substring(det.LastIndexOf("\\") + 1);
                    resStr[4] = "N";
                    resStr[5] = "N";
                    resStr[6] = "N";
                    resStr[ColCount-1] = det;
                    int a = 0;
                    if (flag=="1_2")
                    {
                        resStr[9] = "N";
                        resStr[10] = "N";
                        resStr[11] = "N";
                        resStr[12] = "N";
                        //resStr[13] = "1";

                        if (pa != null && pa.detail.Count > 0)
                        {
                            foreach (String[] tmpStr in pa.detail)
                            {
                                if (tmpStr[0] == resStr[2] && resStr[3].IndexOf(tmpStr[1].Substring(0, Math.Max(4, tmpStr[1].Length))) > -1)
                                {
                                    resStr[9] = tmpStr[4];
                                    resStr[10] = tmpStr[5];
                                    resStr[11] = tmpStr[6];
                                    resStr[12] = tmpStr[7];
                                    //resStr[13] = tmpStr[10];
                                    break;
                                }
                            }

                        }
                    }
                    //Console.WriteLine("\nr3="+resStr[3]+","+det);
                    if (resStr[3] != "000-楼-文件名不要带#号" && resStr[3] != "000-楼-文件名不要带#号")
                    {
                        String[] zf = Directory.GetDirectories(det, "专负存档文件", SearchOption.TopDirectoryOnly);
                        String[] jd = Directory.GetDirectories(det, "校对存档文件", SearchOption.TopDirectoryOnly);
                        String[] sh = Directory.GetDirectories(det, "审核存档文件", SearchOption.TopDirectoryOnly);
                        //Connsole.WriteLine(zttmp + ":" + resStr[3] + ",zf=" + zf.Length + ",jd=" + jd.Length + ",sh=" + sh.Length);
                        if (zf.Length > 0)
                        {
                            String file1 = GetFile(zf[0]);
                            if (flag == "1_2")
                            {
                                if (file1.Length > 0)
                                {

                                    String zfScore = function.GetScore(file1, 2);
                                    resStr[5] = zfScore.Split(',')[0];
                                    resStr[6] = zfScore.Split(',')[1];
                                }else
                                {
                                    resStr[5] = "";
                                    resStr[6] = "";
                                }
                            }else 
                            {
                                if (file1.Length > 0)
                                    resStr[4] = "Y";
                            }
                        }
                        if (jd.Length > 0)
                        {
                            String file2 = GetFile(jd[0]);
                            if (flag == "1_2")
                            {
                                if (file2.Length > 0)
                                {

                                    String zfScore = function.GetScore(file2, 0);
                                    resStr[4] = zfScore;
                                }
                                else
                                {
                                    resStr[4] = "";
                                }
                            }
                            else
                            {
                                if (file2.Length > 0)
                                    resStr[5] = "Y";
                            }
                        }
                        if (sh.Length > 0)
                        {
                            String file3 = GetFile(sh[0]);
                            if (flag == "1_2")
                             {
                                if (file3.Length > 0)
                                {
                                    String zfScore = function.GetScore(file3, 1);
                                    resStr[7] = zfScore.Split(',')[0];
                                    resStr[8] = zfScore.Split(',')[1];
                                 }
                                else
                                {
                                    resStr[7] = "";
                                    resStr[8] = "";
                                 }

                            }
                            else
                            {
                                if (file3.Length > 0)
                                    resStr[6] = "Y";
                            }
                        }
                    }
                    else
                        continue;
                    res.Add(resStr);
                }
            }
            progressBar.Value = 80;
            ExcelManagement em = new ExcelManagement();
            String[] header = { "项目编号", "项目名称", "专业", "子项目", "专负打分", "校对打分", "审核打分", "打分表路径" };
            String exportFile = @Exportpath +"\\"+ dept + DateTime.Now.ToString("MM_dd") + "的评审进度.xls";
            if (flag == "1_2")
            {
                header = new String[] { "项目编号", "项目名称", "专业", "子项目", "校对打分设计", "专负打分设计", "专负打分校对", "审核打分设计", "审核打分专负","审核人","专负（校核人）","校对人","设计人","系数", "打分表路径" };
                exportFile = @Exportpath + "\\"+ dept + DateTime.Now.ToString("MM_dd") + "的打分明细.xls";
            }
            em.Write(exportFile, res, header,dept);
            progressBar.Value = 100;
            ShowMessage("检索完成，结果见："+ exportFile);
        }
       
        public String GetFile(String filePath)
        {

            string[] files = Directory.GetFiles(filePath, "*打分*.xls*", SearchOption.AllDirectories);
            return function.GetLatestFile(files);
        }
         */
        public void ShowMessage(String message)
        {
            RichTextBox rtb = this.MessageText;
            rtb.AppendText("\n"+message);
        }

        private void FileExportPath_Click(object sender, EventArgs e)
        {
            SetFrom sf = new SetFrom(this.MessageText);
            sf.ShowDialog();
        }

        public void InitSetting()
        {
            iniFile iniF = new iniFile();
            iniF.iniPath = @"./setting.ini";
            if (!iniF.exists())
            {
                iniF.writeIni("FileExportPath", "Path", @"C:/");
            }
            Exportpath = iniF.readIni("FileExportPath", "Path");
        }
        /*
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            ShowMessage("x="+this.Width.ToString()+ ",y="+this.Height.ToString());
        }
        */
      
    }
}
