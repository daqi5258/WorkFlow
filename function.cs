using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WorkFlow
{
    static class function
    {
        /// <summary>
        /// 获取ICell的字符串数据
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
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
            else if (cell.CellType == CellType.Numeric)
            {
                str = cell.NumericCellValue + "";
            }
            else if (cell.CellType == CellType.Formula)
            {
                if (cell.CachedFormulaResultType == CellType.Numeric)
                    str = "" + cell.NumericCellValue.ToString("#0.00 ");
                else if (cell.CachedFormulaResultType == CellType.Error)
                    str = "0.0";
                else if (cell.CachedFormulaResultType == CellType.String)
                {
                    str = cell.StringCellValue;
                }
                else if (cell.CachedFormulaResultType == CellType.Blank)
                {
                    str = cell.ToString();
                }

            }
            else if (cell.CellType == CellType.Error)
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
        /// <summary>
        /// 获取多文件集里面最新的文件
        /// </summary>
        /// <param name="files">多文件集</param>
        /// <returns></returns>
        public static String GetLatestFile(string[] files)
        {
            if (files.Length > 0)
            {
                FileInfo fi = new FileInfo(files[0]);
                DateTime lastWT = fi.LastWriteTime;
                if (files.Length > 1)
                {
                    foreach (String path in files)
                    {
                        FileInfo inf = new FileInfo(path);
                        if (inf.LastWriteTime.CompareTo(lastWT) > 0)
                        {
                            fi = inf;
                            lastWT = inf.LastWriteTime;
                        }
                    }
                }
                return fi.FullName;
            }
            else
                return "";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">打分表路径</param>
        /// <param name="index">0:校对 1:审核 2:专负</param>
        /// <returns></returns>
        public static String GetScore(String filePath, int index)
        {
            try
            {
                filePath = filePath.Replace("~$", "");
                IWorkbook workbook = WorkbookFactory.Create(filePath);
                if (workbook == null)
                    return ",,";

                ISheet sht = workbook.GetSheetAt(index);
                if (index == 0)
                {
                    ICell cell = sht.GetRow(20).GetCell(3);
                    return function.Value(cell);
                }
                else if (index == 1)
                {
                    return function.Value(sht.GetRow(20).GetCell(3)) + "," + function.Value(sht.GetRow(20).GetCell(4));
                }
                else if (index == 2)
                {
                    return function.Value(sht.GetRow(22).GetCell(3)) + "," + function.Value(sht.GetRow(22).GetCell(4));
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("e=" + e.ToString() + "," + filePath);
            }
            return "";
        }

        public static double StringToDouble(String str)
        {
            if (str == null)
            {
                return 0.00;
            }
            else if (str == "")
            {
                return 0.00;
            }
            else if (Regex.IsMatch(str.Trim(), @"^[-]?\d*[.]?\d*$"))
            {
                return double.Parse(str);
            }
            else
            {
                Console.WriteLine("str=" + str + "," + Regex.IsMatch(str, @"^[-]?\d*[.]?\d*$"));
                return 0.00;
            }

        }





        public static String cpScore(String filePath)
        {
            try
            {
                IWorkbook wb = WorkbookFactory.Create(filePath);
                ISheet sht1 = wb.GetSheet("居住一所");
                ISheet sht2 = wb.GetSheet("居住二所");
                ISheet sht3 = wb.GetSheet("公建一所");
                ISheet sht4 = wb.GetSheet("公建二所");
                
                if (sht1 != null)
                {
                    Console.WriteLine("sht1=" + sht1.LastRowNum);
                    wb.cmp(sht1);
                }
                if (sht2 != null)
                {
                    Console.WriteLine("sht2=" + sht2.LastRowNum);
                    wb.cmp(sht2);
                }
                if (sht3 != null)
                {
                    Console.WriteLine("sht3=" + sht3.LastRowNum);
                    wb.cmp(sht3);
                }
                if (sht4 != null)
                {
                    Console.WriteLine("sht4=" + sht4.LastRowNum);
                    wb.cmp(sht4);
                }


                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
                wb.Write(fs);
                fs.Close();
                // ISheet sht1s = wb.cmp(sht1);




            }
            catch (FileNotFoundException)
            {
                return "未找到文件,请确认文件是否存在!";
            }
            return "";
        }

        public static ISheet cmp(this IWorkbook wb, ISheet sht)
        {
            ISheet shtc = wb.CreateSheet(sht.SheetName + "建筑(结构)汇总");

            List<PersonScore> ps = new List<PersonScore>();
            List<String[]> list = new List<string[]>();
            for (int i = 0; i < sht.LastRowNum; i++)
            {
                IRow row = sht.GetRow(i + 1);
                if (Value(row.GetCell(2)).IndexOf("建筑") > -1 || Value(row.GetCell(2)).IndexOf("结构") > -1)
                {
                    String[] str = new string[11];
                    str[0] = function.Value(row.GetCell(4));
                    str[1] = function.Value(row.GetCell(5));
                    str[2] = function.Value(row.GetCell(6));
                    str[3] = function.Value(row.GetCell(7));
                    str[4] = function.Value(row.GetCell(8));
                    str[5] = function.Value(row.GetCell(9));
                    str[6] = function.Value(row.GetCell(10));
                    str[7] = function.Value(row.GetCell(11));
                    str[8] = function.Value(row.GetCell(12));
                    str[9] = function.Value(row.GetCell(13));
                    str[10] = function.Value(row.GetCell(2));
                    list.Add(str);
                }
            }
            foreach (String[] str in list)
            {
                int flag = 0;
                foreach (PersonScore t_ps in ps)
                {
                    
                    if (t_ps.Name == str[1] && t_ps.Major==str[10])
                    {
                        flag += 1;
                        t_ps.Count++;
                        t_ps.totalScore += StringToDouble(str[4].ToString());
                    } else if (t_ps.Name == str[2] && t_ps.Major == str[10])
                    {
                        flag += 2;
                        t_ps.Count++;
                        t_ps.totalScore += StringToDouble(str[5].ToString());
                    } else if (t_ps.Name == str[3] && t_ps.Major == str[10])
                    {
                        flag += 5;
                        t_ps.Count++;
                        t_ps.totalScore += StringToDouble(str[9].ToString());
                    }
                    if (flag == 8)
                        break;

                }
                if (flag == 0 || flag == 2 || flag == 5 || flag == 7)
                {
                    PersonScore tps = new PersonScore();
                    tps.Name = str[1];
                    tps.Count = 1;
                    tps.type = PersonScore.PSType.ZF;
                    tps.Major = str[10];
                    tps.totalScore = StringToDouble(str[4].ToString());
                    ps.Add(tps);
                }
                if (flag == 1 || flag == 5 || flag == 6 ||  flag == 0) {
                    PersonScore tps = new PersonScore();
                    tps.Name = str[2];
                    tps.Count = 1;
                    tps.type = PersonScore.PSType.JD;
                    tps.Major = str[10];
                    tps.totalScore = StringToDouble(str[5].ToString());
                    ps.Add(tps);
                }
                if (flag == 1 || flag == 2 || flag == 3|| flag == 0)
                {
                    PersonScore tps = new PersonScore();
                    tps.Name = str[3];
                    tps.Count = 1;
                    tps.type = PersonScore.PSType.SJ;
                    tps.Major = str[10];
                    tps.totalScore = StringToDouble(str[9].ToString());
                    ps.Add(tps);
                }
            }
            //数据导出
            int count = ps.Count + 40;//30
            for (int i=0;i<count;i++)
            {
                IRow row = shtc.CreateRow(i);
                for (int j = 0;j<4;j++)
                {
                    ICell cell = row.CreateCell(j);
                }
            }
            CellRangeAddress cra = new CellRangeAddress(0, 0, 0, 3);
            shtc.AddMergedRegion(cra);
            shtc.GetRow(0).GetCell(0).SetCellValue("校核分数汇总表");

            shtc.GetRow(1).GetCell(0).SetCellValue("部门：");
            shtc.GetRow(1).GetCell(1).SetCellValue(sht.SheetName);
            shtc.GetRow(2).GetCell(0).SetCellValue("专业：");
            shtc.GetRow(2).GetCell(1).SetCellValue("建筑");
            shtc.GetRow(3).GetCell(0).SetCellValue("校核人");
            shtc.GetRow(3).GetCell(1).SetCellValue("校核总分数");
            shtc.GetRow(3).GetCell(2).SetCellValue("校核项目数量");
            shtc.GetRow(3).GetCell(3).SetCellValue("校核平均分");
            int cRow = 4;
            double totalScore = 0;
            int num = 0;
            foreach (PersonScore tps in ps)
            {
                if (tps.Major.IndexOf("建筑")>-1 && tps.type== PersonScore.PSType.ZF)
                {
                    shtc.GetRow(cRow).GetCell(0).SetCellValue(tps.Name);
                    shtc.GetRow(cRow).GetCell(1).SetCellValue(tps.totalScore);
                    shtc.GetRow(cRow).GetCell(2).SetCellValue(tps.Count);
                    shtc.GetRow(cRow).GetCell(3).SetCellValue(tps.totalScore/tps.Count);
                    totalScore += tps.totalScore;
                    num += tps.Count;
                    cRow++;
                }
            }
            shtc.GetRow(cRow).GetCell(0).SetCellValue("小计:");
            shtc.GetRow(cRow).GetCell(1).SetCellValue(totalScore);
            shtc.GetRow(cRow).GetCell(2).SetCellValue(num);
            shtc.GetRow(cRow).GetCell(3).SetCellValue(totalScore / num);

            cRow++; cRow++;
            totalScore = 0;
            num = 0;
            shtc.GetRow(cRow).GetCell(0).SetCellValue("专业：");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("建筑");
            cRow++;
            shtc.GetRow(cRow).GetCell(0).SetCellValue("校对人");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("校对总分数");
            shtc.GetRow(cRow).GetCell(2).SetCellValue("校对项目数量");
            shtc.GetRow(cRow).GetCell(3).SetCellValue("校对平均分");
            cRow++;
            foreach (PersonScore tps in ps)
            {
                if (tps.Major.IndexOf("建筑") > -1 && tps.type == PersonScore.PSType.JD )
                {
                    shtc.GetRow(cRow).GetCell(0).SetCellValue(tps.Name);
                    shtc.GetRow(cRow).GetCell(1).SetCellValue(tps.totalScore);
                    shtc.GetRow(cRow).GetCell(2).SetCellValue(tps.Count);
                    shtc.GetRow(cRow).GetCell(3).SetCellValue(tps.totalScore / tps.Count);
                    totalScore += tps.totalScore;
                    num += tps.Count;
                    cRow++;
                }
            }
            shtc.GetRow(cRow).GetCell(0).SetCellValue("小计:");
            shtc.GetRow(cRow).GetCell(1).SetCellValue(totalScore);
            shtc.GetRow(cRow).GetCell(2).SetCellValue(num);
            shtc.GetRow(cRow).GetCell(3).SetCellValue(totalScore / num);


            cRow++; cRow++;
            totalScore = 0;
            num = 0;
            shtc.GetRow(cRow).GetCell(0).SetCellValue("专业：");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("建筑");
            cRow++;
            shtc.GetRow(cRow).GetCell(0).SetCellValue("设计人");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("设计总分数");
            shtc.GetRow(cRow).GetCell(2).SetCellValue("设计项目数量");
            shtc.GetRow(cRow).GetCell(3).SetCellValue("设计平均分");
            cRow++;
            foreach (PersonScore tps in ps)
            {
                if (tps.Major.IndexOf("建筑") > -1 && tps.type == PersonScore.PSType.SJ)
                {
                    shtc.GetRow(cRow).GetCell(0).SetCellValue(tps.Name);
                    shtc.GetRow(cRow).GetCell(1).SetCellValue(tps.totalScore);
                    shtc.GetRow(cRow).GetCell(2).SetCellValue(tps.Count);
                    shtc.GetRow(cRow).GetCell(3).SetCellValue(tps.totalScore / tps.Count);
                    totalScore += tps.totalScore;
                    num += tps.Count;
                    cRow++;
                }
            }
            shtc.GetRow(cRow).GetCell(0).SetCellValue("小计:");
            shtc.GetRow(cRow).GetCell(1).SetCellValue(totalScore);
            shtc.GetRow(cRow).GetCell(2).SetCellValue(num);
            shtc.GetRow(cRow).GetCell(3).SetCellValue(totalScore / num);
            cRow++; cRow++; cRow++;

            shtc.GetRow(cRow).GetCell(0).SetCellValue("专业");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("结构");
            cRow++;
            shtc.GetRow(cRow).GetCell(0).SetCellValue("校核人");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("校核总分数");
            shtc.GetRow(cRow).GetCell(2).SetCellValue("校核项目数量");
            shtc.GetRow(cRow).GetCell(3).SetCellValue("校核平均分");
            cRow++;
            totalScore = 0;
            num = 0;
            foreach (PersonScore tps in ps)
            {
                if (tps.Major.IndexOf("结构") > -1 && tps.type == PersonScore.PSType.ZF)
                {
                    shtc.GetRow(cRow).GetCell(0).SetCellValue(tps.Name);
                    shtc.GetRow(cRow).GetCell(1).SetCellValue(tps.totalScore);
                    shtc.GetRow(cRow).GetCell(2).SetCellValue(tps.Count);
                    shtc.GetRow(cRow).GetCell(3).SetCellValue(tps.totalScore / tps.Count);
                    totalScore += tps.totalScore;
                    num += tps.Count;
                    cRow++;
                }
            }
            shtc.GetRow(cRow).GetCell(0).SetCellValue("小计:");
            shtc.GetRow(cRow).GetCell(1).SetCellValue(totalScore);
            shtc.GetRow(cRow).GetCell(2).SetCellValue(num);
            shtc.GetRow(cRow).GetCell(3).SetCellValue(totalScore / num);

            cRow++; cRow++;
            totalScore = 0;
            num = 0;
            shtc.GetRow(cRow).GetCell(0).SetCellValue("专业：");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("结构");
            cRow++;
            shtc.GetRow(cRow).GetCell(0).SetCellValue("校对人");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("校对总分数");
            shtc.GetRow(cRow).GetCell(2).SetCellValue("校对项目数量");
            shtc.GetRow(cRow).GetCell(3).SetCellValue("校对平均分");
            cRow++;
            foreach (PersonScore tps in ps)
            {
                if (tps.Major.IndexOf("结构") > -1 && tps.type == PersonScore.PSType.JD)
                {
                    shtc.GetRow(cRow).GetCell(0).SetCellValue(tps.Name);
                    shtc.GetRow(cRow).GetCell(1).SetCellValue(tps.totalScore);
                    shtc.GetRow(cRow).GetCell(2).SetCellValue(tps.Count);
                    shtc.GetRow(cRow).GetCell(3).SetCellValue(tps.totalScore / tps.Count);
                    totalScore += tps.totalScore;
                    num += tps.Count;
                    cRow++;
                }
            }
            shtc.GetRow(cRow).GetCell(0).SetCellValue("小计:");
            shtc.GetRow(cRow).GetCell(1).SetCellValue(totalScore);
            shtc.GetRow(cRow).GetCell(2).SetCellValue(num);
            shtc.GetRow(cRow).GetCell(3).SetCellValue(totalScore / num);


            cRow++; cRow++;
            totalScore = 0;
            num = 0;
            shtc.GetRow(cRow).GetCell(0).SetCellValue("专业：");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("结构");
            cRow++;
            shtc.GetRow(cRow).GetCell(0).SetCellValue("设计人");
            shtc.GetRow(cRow).GetCell(1).SetCellValue("设计总分数");
            shtc.GetRow(cRow).GetCell(2).SetCellValue("设计项目数量");
            shtc.GetRow(cRow).GetCell(3).SetCellValue("设计平均分");
            cRow++;
            foreach (PersonScore tps in ps)
            {
                if (tps.Major.IndexOf("结构") > -1 && tps.type == PersonScore.PSType.SJ)
                {
                    shtc.GetRow(cRow).GetCell(0).SetCellValue(tps.Name);
                    shtc.GetRow(cRow).GetCell(1).SetCellValue(tps.totalScore);
                    shtc.GetRow(cRow).GetCell(2).SetCellValue(tps.Count);
                    shtc.GetRow(cRow).GetCell(3).SetCellValue(tps.totalScore / tps.Count);
                    totalScore += tps.totalScore;
                    num += tps.Count;
                    cRow++;
                }
            }
            shtc.GetRow(cRow).GetCell(0).SetCellValue("小计:");
            shtc.GetRow(cRow).GetCell(1).SetCellValue(totalScore);
            shtc.GetRow(cRow).GetCell(2).SetCellValue(num);
            shtc.GetRow(cRow).GetCell(3).SetCellValue(totalScore / num);





            return shtc;
        }
    }


    class PersonScore
    {
        public String Name { get; set; }
        public int Count { get; set; }
        public double totalScore { get; set; }
        public PersonScore()
        {
            Name = "";
            Major = "";
            Count = 0;
            totalScore = 0;
        }
        public PSType type { get; set; }
        public String Major { get; set; }
        public enum PSType{
            ZF =1,
            SH=2,
            JD=3,
            SJ=4,
        }

        public enum MajorType { 
            JZ =0,
            JG=1,
            Water=2,
            Ele=3,
            NT=4

        }
    }

}
