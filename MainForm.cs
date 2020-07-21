using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
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
            InitializeComponent();
            InitSetting();
        }

       public void clear()
       {
            MainPanel.Controls.Clear();
       }

        /// <summary>
        /// 选择某个大项目，汇总该项目评分信息到指定目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZGB_Tool1_1_Click(object sender, EventArgs e)
        {
            clear();
            Check("1_1");
            /*
            Form f = new Form
            {
                Text = "检索完成",
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            };
           
            f.ShowDialog();
             */
            /*
            String str = selectFoldPath();
            PersonArrange pa = getPersonDetail(str);
            Console.WriteLine(pa.project_id+":"+pa.project_name);
            oracleDB odb = new oracleDB();
            String[] files = getFiles(str,pa.project_id,pa.project_name);

            Console.WriteLine("\nlength="+files.Length);

            String mergeSQL = @"merge into data0001 using (select substr(  SUBSTR(name, instr(name, '\',1,6)+1) , 1 , instr(SUBSTR(name, instr(name, '\',1,6)+1),'\',1,1)-1 ) nproject_name  , substr( "+
           @" SUBSTR(name, instr(name, '\',1,4)+1), 1 , instr(SUBSTR(name, instr(name, '\',1,4)+1),'\',1,1)-1 " +
           @" ) as ndept , substr(SUBSTR(name, instr(name, '\',1,5)+1) , 1, instr(SUBSTR(name, instr(name, '\',1,5)+1),'\',1,1)-1 " +
           @" ) as nyear  , substr( SUBSTR(name, instr(name, '\',1,9)+1)  , 1 , instr(SUBSTR(name, instr(name, '\',1,9)+1),'\',1,1)-1 " +
           @" ) as nteam , substr( SUBSTR(name, instr(name, '\',1,10)+1) , 1 , instr(SUBSTR(name, instr(name, '\',1,10)+1),'\',1,1)-1 "+
           @" ) as npart  , substr( SUBSTR(name, instr(name, '\',1,11)+1) , 1 , instr(SUBSTR(name, instr(name, '\',1,11)+1),'\',1,1)-1) as ntype" +
           @" , pkey from data0001 ) tmp on(tmp.pkey = data0001.pkey) when matched then  " +
           @"   update set project_name = '" + pa.project_name+"',no='"+pa.project_id+"', deptment = tmp.ndept, team = tmp.nteam, type = tmp.ntype, part = tmp.npart, year = tmp.nyear ";
            Console.WriteLine(@mergeSQL);
            int c= odb.ExecuteSQL(@mergeSQL);
            Console.WriteLine("c="+c);
            */

        }
        private void ZGB_Tool1_2_Click(object sender, EventArgs e)
        {
            clear();
            Check("1_2");
        }

        private void newPA_Click(object sender, EventArgs e)
        {
            clear();
            PAMain PAMain = new PAMain();
            PAMain.init();
            MainPanel.Controls.Add(PAMain);
            this.ResumeLayout(false);
        }

        private void openPA_Click(object sender, EventArgs e)
        {
            clear();
            PAMain PAMain = new PAMain();
            PAMain.init();
            MainPanel.Controls.Add(PAMain);
            this.ResumeLayout(false);
        }





        private string SelectFilePath()
        {
            string path = null;
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Files (*.*)|*.txt"//如果需要筛选txt文件（"Files (*.txt)|*.txt"）
            }
           ;
            var result = openFileDialog.ShowDialog();
            if (result.Equals("OK") || result == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            return path;
        }

        /// <summary>
        /// 获取项目文件路径
        /// </summary>
        /// <returns>大项目的顶层文件夹路径</returns>
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


        public PersonArrange GetPersonDetail(String filepath)
        {
            PersonArrange pa = new PersonArrange();
            //string[] files1 = Directory.GetFiles(filepath + @"\项师-工作目录\1 ISO\ISO表格\人员安排表", "*人员安排*.xls*", SearchOption.AllDirectories);
            string[] files1 = Directory.GetFiles(filepath , "*人员安排*.xls*", SearchOption.AllDirectories);
            try
            {
                Console.WriteLine(files1[0]);
                 workbook = WorkbookFactory.Create(files1[0]);
             }
             catch (Exception e)
            {
                Console.WriteLine("\n" + e.ToString());
             }
             if (workbook is null)
             {
                Console.WriteLine("workbook is null");
                return pa;
             } 
             ISheet sheet = workbook.GetSheetAt(0);
            
            pa.project_name = sheet.GetRow(0).GetCell(3) == null ? "" : sheet.GetRow(0).GetCell(3).ToString();
            pa.construct_company = sheet.GetRow(1).GetCell(3) == null ? "" : sheet.GetRow(1).GetCell(3).ToString();
            pa.project_id = sheet.GetRow(2).GetCell(3) == null ? "" : sheet.GetRow(2).GetCell(3).ToString();
            pa.person_project  = sheet.GetRow(3).GetCell(3) == null ? "" : sheet.GetRow(3).GetCell(3).ToString();

            pa.person_1 = sheet.GetRow(6).GetCell(4)==null?"": sheet.GetRow(6).GetCell(4).ToString();
            pa.person_2 = sheet.GetRow(6).GetCell(7) == null ? "" : sheet.GetRow(6).GetCell(7).ToString();
            pa.person_3 = sheet.GetRow(6).GetCell(10) == null ? "" : sheet.GetRow(6).GetCell(10).ToString();
            pa.person_4 = sheet.GetRow(6).GetCell(13) == null ? "" : sheet.GetRow(6).GetCell(13).ToString();
            pa.person_5 = sheet.GetRow(6).GetCell(16) == null ? "" : sheet.GetRow(6).GetCell(16).ToString();
            
            List<DetailArrange> lda = new List<DetailArrange>();
            for (int i = 8;i<sheet.LastRowNum ;i++)
            {
                if (sheet.GetRow(i) != null)
                {
                    //Console.WriteLine("i=" + i + ",v=" + sheet.GetRow(i).GetCell(0));
                    DetailArrange dat = new DetailArrange
                    {
                        flag = Value(sheet.GetRow(i).GetCell(0)),
                        project_detail = Value(sheet.GetRow(i).GetCell(1)),
                        project_type = Value(sheet.GetRow(i).GetCell(2)),
                        detail_no = Value(sheet.GetRow(i).GetCell(3)),
                        person_design_1 = Value(sheet.GetRow(i).GetCell(4)),
                        person_verify_1 = Value(sheet.GetRow(i).GetCell(5)),
                        person_check_1 = Value(sheet.GetRow(i).GetCell(6)),
                        person_design_2 = Value(sheet.GetRow(i).GetCell(7)),
                        person_verify_2 = Value(sheet.GetRow(i).GetCell(8)),
                        person_check_2 = Value(sheet.GetRow(i).GetCell(9)),
                        person_design_3 = Value(sheet.GetRow(i).GetCell(10)),
                        person_verify_3 = Value(sheet.GetRow(i).GetCell(11)),
                        person_check_3 = Value(sheet.GetRow(i).GetCell(12)),
                        person_design_4 = Value(sheet.GetRow(i).GetCell(13)),
                        person_verify_4 = Value(sheet.GetRow(i).GetCell(14)),
                        person_check_4 = Value(sheet.GetRow(i).GetCell(15)),
                        person_design_5 = Value(sheet.GetRow(i).GetCell(16)),
                        person_verify_5 = Value(sheet.GetRow(i).GetCell(17)),
                        person_check_5 = Value(sheet.GetRow(i).GetCell(18))
                    };
                    lda.Add(dat);
                }
            }
            pa.setDAS(lda);
            //Console.WriteLine("\n sht_num="+sheet.LastRowNum+",project_id="+pa.project_id+",p1="+pa.person_1+",p2="+pa.person_2+",rowId="+rowId+",p="+pa.das[1].person_design_1);
            return pa;

        }

        public static String Value(ICell cell)
        {
            if (cell is null)
            {
                return "";
            }
            String str = "";
            if (cell.CellType == CellType.String)
            {
                str = cell.StringCellValue;
            }
            else if(cell.CellType == CellType.Numeric){
                str = cell.NumericCellValue + "";
            }
            else if (cell.CellType == CellType.Formula)
            {
                if(cell.CachedFormulaResultType==CellType.Numeric)
                    str = cell.NumericCellValue + "";
                else if (cell.CachedFormulaResultType == CellType.Error)
                    str = cell.ErrorCellValue.ToString();
            }else if (cell.CellType==CellType.Error)
            {
                str = cell.ErrorCellValue.ToString();
            }
            else if (cell.CellType == CellType.Blank)
            {
                str = cell.ToString();
            }
            //Console.WriteLine("str="+str);
            return str;
        }


        public String[]  GetFold(String path,String  filer, SearchOption searchOption)
        {
            //Console.WriteLine(path);
            String[] dirs = Directory.GetDirectories(path, filer, searchOption);
            return dirs;
        }
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
            String[] XS = GetFold(str, "*项师*", SearchOption.TopDirectoryOnly);
            
            //人员信息表
            String[] ISO = GetFold(XS[0],"*ISO*", SearchOption.TopDirectoryOnly);
            //String[] ISOBG = getFold(ISO[0], "*ISO*", SearchOption.TopDirectoryOnly);
            String[] RY = GetFold(XS[0], "*人员*", SearchOption.AllDirectories);
            PersonArrange pa = new PersonArrange();
            if (RY.Length > 0)
            {
                pa = GetPersonDetail(RY[0]);
                ShowMessage("项目人员表检索成功！");
            }
            progressBar.Value = 10;
            String project_id = pa.project_id.Length>0 ?  pa.project_id:str.Substring(str.LastIndexOf("\\")+1,6) ;
            String project_name = pa.project_name.Length > 0 ? pa.project_name:str.Substring(str.LastIndexOf("\\") + 7) ;
           // Console.WriteLine(str.Substring(str.LastIndexOf("\\") + 1, 6) + "," + pa.project_id);

            String[] ctsj = GetFold(XS[0], "*出图设校*", SearchOption.TopDirectoryOnly);
            String[] zt = GetFold(ctsj[0], "*总图*", SearchOption.TopDirectoryOnly);
            String[] nt = GetFold(ctsj[0], "*暖通*", SearchOption.TopDirectoryOnly);
            String[] jz = GetFold(ctsj[0], "*建筑*", SearchOption.TopDirectoryOnly);
            String[] gps = GetFold(ctsj[0], "*给排水*", SearchOption.TopDirectoryOnly);
            String[] jg = GetFold(ctsj[0], "*结构*", SearchOption.TopDirectoryOnly);
            String[] dq = GetFold(ctsj[0], "*电气*", SearchOption.TopDirectoryOnly);

            //Console.WriteLine(zt[0]+nt[0]+jz[0]+gps[0]+jg[0]+dq[0]);


            String[] zy = {nt[0], jz[0], gps[0] ,jg[0] , dq[0] };
            List<String[]> res = new List<String[]>();
            int ColCount = 8;
            if (flag=="1_2")
            {
                ColCount = 10;
            }
            foreach (String path in zy)
            {

                String[] tmp = GetFold(path, "*", SearchOption.TopDirectoryOnly);
                //Console.WriteLine(path+"下面的子项有"+tmp.Length);
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
                    //Console.WriteLine("\nr3="+resStr[3]+","+det);
                    if (resStr[3] != "000-楼-文件名不要带#号" && resStr[3] != "000-楼-文件名不要带#号")
                    {

                        String[] zf = GetFold(det, "专负存档文件", SearchOption.TopDirectoryOnly);
                        String[] jd = GetFold(det, "校对存档文件", SearchOption.TopDirectoryOnly);
                        String[] sh = GetFold(det, "审核存档文件", SearchOption.TopDirectoryOnly);
                        //Connsole.WriteLine(zttmp + ":" + resStr[3] + ",zf=" + zf.Length + ",jd=" + jd.Length + ",sh=" + sh.Length);
                        if (zf.Length > 0)
                        {
                            String file1 = GetFile(zf[0], pa.project_id, pa.project_name);
                            if (flag == "1_2")
                            {
                                if (file1.Length > 0)
                                {

                                    String zfScore = GetScore(file1, 2);
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
                            String file2 = GetFile(jd[0], pa.project_id, pa.project_name);
                            if (flag == "1_2")
                            {
                                if (file2.Length > 0)
                                {

                                    String zfScore = GetScore(file2, 0);
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
                            String file3 = GetFile(sh[0], pa.project_id, pa.project_name);
                            if (file3.Length > 0)
                                if (flag == "1_2")
                                {
                                    if (file3.Length > 0)
                                    {

                                        String zfScore = GetScore(file3, 1);
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
                    /*
                    String sql = "merge into data0002 using (select '" + resStr[0] + "'  project_id ,'"
                        + resStr[1] + "' project_name,'" + resStr[2] + "' zy,'" + resStr[3] + "' part,'" + resStr[4] + "' zf,'" + resStr[5] + "' jd,'" + resStr[6] + "' sh ,'" + resStr[7] + "' path from dual) tmp on (tmp.project_id=data0002.project_id and tmp.project_name=data0002.project_name and tmp.zy=data0002.zy and tmp.part=data0002.part) " +
                        " when matched then update set zf=tmp.zf,jd=tmp.jd,sh=tmp.sh when not matched then insert values('" + resStr[0] + "','" + resStr[1] + "','" + resStr[2] + "','" + resStr[3] + "','" + resStr[4] + "','" + resStr[5] + "','" + resStr[6] + "','" + resStr[7] + "') ";
                    */
                    //Console.WriteLine(sql);
                    //odb.ExecuteSQL(sql);
                    res.Add(resStr);
                }
            }
            progressBar.Value = 80;
            ExcelManagement em = new ExcelManagement();
            String[] header = { "项目编号", "项目名称", "专业", "子项目", "专负打分", "校对打分", "审核打分", "打分表路径" };
            String exportFile = @Exportpath +"\\"+ dept + DateTime.Now.ToString("MM_dd") + "的评审进度.xls";
            if (flag == "1_2")
            {
                header = new String[] { "项目编号", "项目名称", "专业", "子项目", "校对打分设计", "专负打分设计", "专负打分校对", "审核打分设计", "审核打分专负", "打分表路径" };
                exportFile = @Exportpath + "\\"+ dept + DateTime.Now.ToString("MM_dd") + "的打分明细.xls";
            }
            em.Write(exportFile, res, header);
            progressBar.Value = 100;
            ShowMessage("检索完成，结果见："+ exportFile);
        }

        public String GetFile(String filePath, String project_id, String project_name)
        {

            string[] files = Directory.GetFiles(filePath, "*分*.xls*", SearchOption.AllDirectories);
            //Console.WriteLine("path="+filePath+",s="+ files.Length);
            if (files.Length>0)
            {
               
                FileInfo fi = new FileInfo(files[0]);
                DateTime lastWT = fi.LastWriteTime;
                if (files.Length>1) {
                    foreach (String path in files)
                    {
                        FileInfo inf = new FileInfo(path);
                        if (inf.LastWriteTime.CompareTo(lastWT)>0)
                        {
                            fi = inf;
                            lastWT = inf.LastWriteTime;
                        }
                        //Console.WriteLine("file=" + inf.FullName + "," + inf.LastWriteTime);
                    }
                }
                return fi.FullName;
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">打分表路径</param>
        /// <param name="index">0:校对 1:审核 2:专负</param>
        /// <returns></returns>
        public String GetScore(String filePath,int index)
        {
            try
            {
                workbook = WorkbookFactory.Create(filePath);
                ISheet sht = workbook.GetSheetAt(index);
                if (index == 0)
                {
                    ICell cell = sht.GetRow(20).GetCell(3);
                    return Value(cell);
                }
                else if (index == 1)
                {
                    return Value(sht.GetRow(20).GetCell(3)) +","+ Value(sht.GetRow(20).GetCell(4));
                }
                else if (index == 2)
                {
                    return Value(sht.GetRow(22).GetCell(3)) +","+Value(sht.GetRow(22).GetCell(4));
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                ShowMessage("e=" + e.ToString());
                Console.WriteLine("e="+e.ToString());
            }
            return "";
        }


        public void ShowMessage(String message)
        {
            RichTextBox rtb = this.MessageText;
            rtb.AppendText("\n"+message);
        }

        private void FileExportPath_Click(object sender, EventArgs e)
        {
            
            SetFrom sf = new SetFrom();
            //FileStream fs = new FileStream(System.IO.Directory.GetCurrentDirectory(),FileMode.OpenOrCreate,FileAccess.ReadWrite);
            //sf.FileExportPath.Text=Exportpath;
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

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            ShowMessage("x="+this.Width.ToString()+ ",y="+this.Height.ToString());
        }

      

        /*
        private void detailGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (detailGrid.IsCurrentCellDirty)
            //{
            var c = detailGrid.CurrentCell;
            if(c!=null)
                   Console.WriteLine(c.Value+",id="+ c.ColumnIndex);
            //}
        }
        private void detailGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (detailGrid.IsCurrentCellDirty)
            {
               
                detailGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        */

    }
}
