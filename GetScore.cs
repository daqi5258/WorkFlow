using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace WorkFlow
{
    class GetScore
    {
       /// <summary>
       /// 检索打分表
       /// </summary>
       /// <param name="folders">项目目录集</param>
       /// <param name="Exportpath">导出结果位置</param>
       /// <param name="flag">统计分数或是否打分标志</param>
       /// <param name="c">检索项目成功的数目</param>
       /// <param name="unFolder">未检索成功的项目</param>
       /// <param name="ScoreInAreaPath">打分规则文件目录</param>
       /// <returns></returns>
        public static String Check(List<String> folders,String Exportpath, String flag,ref int c,ref String unFolder,String ScoreInAreaPath)//,ref ProgressBar progressBar,ref RichTextBox rtb)
        {
            ExcelManagement em = new ExcelManagement();
            try
            {
                string[] files = Directory.GetFiles(ScoreInAreaPath, "*打分规则*.xls*", SearchOption.AllDirectories);
                HCTypes = em.Read(function.GetLatestFile(files));
            }
            catch (FileNotFoundException e)
            {
                unFolder += "没有发现打分规则表,请联系总工办!";
            }

            foreach (String str in folders) {
                //progressBar.Value = 0;
                //单项目文件总目录
               
                if (str == null || str.Length < 1)
                {
                    unFolder += " \n\t没有该目录" + str;
                    continue;
                }
                //rtb.AppendText("您选择的项目是：" + str.Split('\\')[6] + ",程序已经开始检索，请等待检索完成......");
                String dept = str.Split('\\')[4];
                String[] XS = Directory.GetDirectories(str, "*项师*", SearchOption.TopDirectoryOnly);
                if (XS == null || XS.Length <1)
                {
                    unFolder += " \n\t没有相师目录" + str;
                    continue; 
                }
                //人员信息表
                String[] ISO = Directory.GetDirectories(XS[0], "*ISO*", SearchOption.TopDirectoryOnly);
                if (ISO == null || ISO.Length < 1)
                {
                    unFolder += " \n\t没有ISO目录" + str;
                    continue;
                }
                //String[] ISOBG = getFold(ISO[0], "*ISO*", SearchOption.TopDirectoryOnly);
                String[] RY = Directory.GetDirectories(ISO[0], "*人员*", SearchOption.AllDirectories);
                if (RY == null || RY.Length < 1)
                {
                    unFolder += " \n\t没有人员安排表：" + str;
                    continue;
                }
                PersonArrange pa = new PersonArrange();
                if (ISO.Length > 0)
                {
                    try
                    {
                        pa = pa.GetPersonDetail(ISO[0]);
                    }
                    catch (Exception e)
                    {
                        unFolder += " \n\t没有人员安排表读取失败：" + str;
                        continue;
                    }
                }

                String project_id = str.Substring(str.LastIndexOf("\\") + 1, 6);
                String project_name = str.Substring(str.LastIndexOf("\\") + 7);
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
                if (nt.Length > 0)
                {
                    zy[4] = nt[0];
                }
                if (jz.Length > 0)
                {
                    zy[0] = jz[0];
                }
                if (gps.Length > 0)
                {
                    zy[2] = gps[0];
                }
                if (jg.Length > 0)
                {
                    zy[1] = jg[0];
                }
                if (dq.Length > 0)
                {
                    zy[3] = dq[0];
                }
                List<String[]> res = new List<String[]>();
                int ColCount = 8;
                if (flag == "1_2")
                {
                    ColCount = 18;
                }
                //检索5大专业的打分信息
                foreach (String path in zy)
                {
                    if (path == null)
                    {
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
                        resStr[4] = "";
                        resStr[5] = "";
                        resStr[6] = "";
                        resStr[ColCount - 1] = null;// det;
                        int a = 0;
                        if (flag == "1_2")
                        {
                            if (pa != null && pa.detail.Count > 0)
                            {
                                foreach (String[] tmpStr in pa.detail)
                                {
                                    if ((tmpStr[0].IndexOf(zttmp)>-1 || zttmp.IndexOf(tmpStr[0]) > -1) && tmpStr[1].Substring(0,4)==resStr[3].Substring(0,4) )
                                    {
                                        resStr[4] = tmpStr[6];
                                        resStr[5] = tmpStr[3];
                                        resStr[6] = tmpStr[5];
                                        resStr[7] = tmpStr[4];
                                        resStr[14] = tmpStr[7];
                                        resStr[15] = tmpStr[8];

                                        if (HCTypes != null)
                                        {
                                            foreach (HCType hCType in HCTypes)
                                            {
                                                Boolean eFlag = false;
                                                if (hCType.TypeName == tmpStr[7])
                                                {
                                                    foreach (ScoreInArea sia in hCType.Detail)
                                                    {
                                                        if (sia.Area == tmpStr[8])
                                                        {
                                                            if (zttmp.IndexOf("建筑") > -1)
                                                                resStr[16] = sia.jz;
                                                            else if (zttmp.IndexOf("结构") > -1)
                                                                resStr[16] = sia.jg;
                                                            else if (zttmp.IndexOf("水") > -1)
                                                                resStr[16] = sia.water;
                                                            else if (zttmp.IndexOf("电") > -1)
                                                                resStr[16] = sia.ele;
                                                            else if (zttmp.IndexOf("暖通") > -1)
                                                                resStr[16] = sia.nt;
                                                            eFlag = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (eFlag)
                                                    break;
                                            }
                                        }
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
                                        resStr[10] = zfScore.Split(',')[0];
                                        resStr[8] = zfScore.Split(',')[1];
                                    }
                                    else
                                    {
                                        resStr[10] = "";
                                        resStr[8] = "";
                                    }
                                }
                                else
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
                                        resStr[12] = zfScore;
                                    }
                                    else
                                    {
                                        resStr[12] = "";
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
                                        resStr[11] = zfScore.Split(',')[0];
                                        resStr[9] = zfScore.Split(',')[1];
                                    }
                                    else
                                    {
                                        resStr[11] = "";
                                        resStr[9] = "";
                                    }

                                }
                                else
                                {
                                    if (file3.Length > 0)
                                        resStr[6] = "Y";
                                }
                            }
                           for (int i =8;i<=12;i++)
                            {
                                if(resStr[16]!=null )
                                    resStr[i] = (100 - (100 - function.StringToDouble(resStr[i])) / function.StringToDouble(resStr[16])).ToString("#0.00");
                            }
                            resStr[13] = (function.StringToDouble(resStr[10]) * 0.3 + function.StringToDouble(resStr[11]) * 0.4 + function.StringToDouble(resStr[12]) * 0.3).ToString("#0.00");

                        }
                        else
                            continue;
                       res.Add(resStr);
                    }
                } 
                String[] header = { "项目编号", "项目名称", "专业", "子项目", "专负打分", "校对打分", "审核打分", "打分表路径" };
                String exportFile = @Exportpath + "\\" + DateTime.Now.ToString("yyyy") + "年施工图打分汇总表" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                if (flag == "1_2")
                {
                    header = new String[] { "项目号", "项目名称", "专业", "子项名称", "审核人", "专负(校核)人", "校对人", "设计人", "审核判校核分", "专负判校对分", "审核判设计分", "专负判设计分", "校对判设计分", "设计人得分小计", "建筑类型1", "建筑类型2","系数" };
                    exportFile = @Exportpath + "\\" + DateTime.Now.ToString("yyyy") + "年施工图打分明细汇总表" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                }
                
                String result= em.Write(exportFile, res, header,dept);
                if (result == "OK")
                {
                    c++;
                }
                else
                    unFolder += result;
              
                
            } 
            return "检索完成，结果见文件夹：<A href=\" " + Exportpath+"\">"+Exportpath;
        }







        public static String GetFile(String filePath)
        {

            string[] files = Directory.GetFiles(filePath, "*打分*.xls*", SearchOption.AllDirectories);
            return function.GetLatestFile(files);
        }

        public static List<HCType> HCTypes;

    }
}
