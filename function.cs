using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    str = ""+cell.NumericCellValue.ToString("#0.00 ");
                else if (cell.CachedFormulaResultType == CellType.Error)
                    str = "";
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
                Console.WriteLine("str="+ str+","+ Regex.IsMatch(str, @"^[-]?\d*[.]?\d*$"));
                return 0.00;
            }

        }

    }
}
