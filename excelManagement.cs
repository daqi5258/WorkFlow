using NPOI.HSSF.UserModel;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using OracleInternal.SqlAndPlsqlParser;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WorkFlow
{
    class ExcelManagement
    {
       
        public void Read(String filePath,String sht,ref String score)
        {
            IWorkbook workbook ;
            try
            {
                workbook = WorkbookFactory.Create(filePath);
                if (workbook is null)
                    return;
                ISheet sheet;
                if (sht.IndexOf("专负") > -1)
                {
                    sheet = workbook.GetSheetAt(2);
                    //Console.WriteLine("专负打分表");
                }
                else if (sht.IndexOf("审核") > -1)
                {
                    sheet = workbook.GetSheetAt(1);
                    //Console.WriteLine("审核打分表");
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);//获取第一个工作薄

                }
                //Console.WriteLine("校对" + sht + "," + sht.IndexOf("审核") + "," + sht.IndexOf("专负"));
                IRow row = (IRow)sheet.GetRow(20);//获取第一行
                ICell cell = sheet.GetRow(20).GetCell(3) as ICell;

                try
                {
                    cell.SetCellType(CellType.String);
                    score = "" + cell.StringCellValue;
                }
                catch (InvalidOperationException e)
                {
                    // score = cell.ToString();
                    //if (score.Equals("100-SUM<D12:D20>") || score== "100-SUM<D12:D20>")
                    score = "null";
                    Console.WriteLine("\n" + sht + "," + e.ToString() + "," + cell.CellType);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n"+e.ToString());
            }    
        }

        public  List<HCType> Read(String filePath)
        {
           // kinds.Clear();
            IWorkbook workbook = WorkbookFactory.Create(filePath);
            if (workbook is null)
                return null;
            ISheet sheet  = workbook.GetSheetAt(0);
            int rowCount = sheet.LastRowNum ;
            List<HCType> HCTypes = new List<HCType>();
            String lastTypeName = "";
            int count = 0;
            for (int i=4;i<rowCount && count<3;i++)
            {

                String Kind = Value(sheet.GetRow(i).GetCell(0));
                String TypeName = Value(sheet.GetRow(i).GetCell(0));
                String Area = Value(sheet.GetRow(i).GetCell(1));
                String jz = Value(sheet.GetRow(i).GetCell(2));
                String jg = Value(sheet.GetRow(i).GetCell(3));
                String water = Value(sheet.GetRow(i).GetCell(4));
                String ele = Value(sheet.GetRow(i).GetCell(5));
                String nt = Value(sheet.GetRow(i).GetCell(6));
                Boolean flag = true;
                if (TypeName.Length<1 && Area.Length<1)
                {
                    count++;
                    continue;
                }
                else
                    count = 0;
                if (TypeName.Length > 0)
                    lastTypeName = TypeName;
                foreach (HCType hctype in HCTypes)
                {
                   
                    if (hctype.TypeName == lastTypeName)
                    {
                        ScoreInArea sia = new ScoreInArea();
                        sia.Area = Area;
                        sia.jz = jz;
                        sia.jg = jg;
                        sia.water = water;
                        sia.ele = ele;
                        sia.nt = nt;
                        hctype.AddScoreInArea(sia);
                        flag = false;
                        continue;
                    }
                }
                if (flag)
                {
                    HCType hctype = new HCType();
                    hctype.Kind = lastTypeName;
                    hctype.TypeName = lastTypeName;
                    ScoreInArea sia = new ScoreInArea();
                    sia.Area = Area;
                    sia.jz = jz;
                    sia.jg = jg;
                    sia.water = water;
                    sia.ele = ele;
                    sia.nt = nt;
                    hctype.AddScoreInArea(sia);
                    HCTypes.Add(hctype);

                }
            }
            //Console.WriteLine("c="+HCTypes.Count);
            return HCTypes;
        }

        public void Write(String filepath,List<String[]> inf,String[] header,String dept)
        {
            DateTime dt = DateTime.Now;
            //String shtStr = dt.ToString(@"MM_dd");
            
            IWorkbook workbook = new HSSFWorkbook();
            try{
                workbook = WorkbookFactory.Create(filepath);

                ISheet sht = workbook.GetSheet(dept);
                if (sht != null)
                {
                    int RowCount = sht.LastRowNum + 1;
                    foreach (String[] str in inf)
                    {
                        IRow row = sht.CreateRow(RowCount);
                        for (int i = 0; i < str.Length; i++)
                        {
                            ICell cell = row.CreateCell(i);
                            cell.SetCellValue(str[i]);
                        }
                        RowCount++;
                    }
                }
                else
                {
                    sht = workbook.CreateSheet(dept);
                    IRow Header = sht.CreateRow(0);
                    for (int i = 0; i < header.Length; i++)
                    {
                        ICell cell = Header.CreateCell(i);
                        cell.SetCellValue(header[i]);
                    }
                    int rowCount = 1;
                    foreach (String[] str in inf)
                    {
                        IRow row = sht.CreateRow(rowCount);
                        for (int i = 0; i < str.Length; i++)
                        {
                            ICell cell = row.CreateCell(i);
                            cell.SetCellValue(str[i]);
                        }
                        rowCount++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nfile not found:"+e);
                ISheet sht = workbook.CreateSheet(dept);
                IRow Header = sht.CreateRow(0);
                for (int i = 0; i < header.Length; i++)
                {
                    ICell cell = Header.CreateCell(i);
                    cell.SetCellValue(header[i]);
                }
                int rowCount = 1;
                foreach (String[] str in inf)
                {
                    IRow row = sht.CreateRow(rowCount);
                    for (int i = 0; i < str.Length; i++)
                    {
                        ICell cell = row.CreateCell(i);
                        cell.SetCellValue(str[i]);
                    }
                    rowCount++;
                }
               
                
            }

            FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Close();
        }

        /// <summary>
        /// closed
        /// </summary>
        /// <param name="filePath"></param>
        public String  Write(String filePath,List<String[]> mString,DataGridView dataGridView, DataGridView dataGridView2)
        {
            String fileName = filePath + "\\人员安排表.xls";
            try
            {
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                
                FileInfo fileInfo = new FileInfo(fileName);
                if (fileInfo.Exists)
                {
                    fileInfo.CopyTo(filePath + "\\" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm") + "_" + fileInfo.Name);
                }

                IWorkbook wb = new XSSFWorkbook();
                ISheet sheet0 = wb.CreateSheet("公共信息");
                int mCount = mString.Count;
                for (int i = 0; i < mCount; i++)
                {
                    String[] str = mString[i];
                    IRow row = sheet0.CreateRow(i);
                    for (int j = 0; j < str.Length || j < 4; j++)
                    {
                        ICell cell = row.CreateCell(j);
                    }
                }

                CellRangeAddress cra = new CellRangeAddress(0, 0, 0, 3);
                sheet0.AddMergedRegion(cra);
                cra = new CellRangeAddress(1, 1, 1, 3);
                sheet0.AddMergedRegion(cra);
                cra = new CellRangeAddress(2, 2, 1, 3);
                sheet0.AddMergedRegion(cra);
                cra = new CellRangeAddress(3, 3, 1, 3);
                sheet0.AddMergedRegion(cra);

                ICellStyle dateStyle = wb.CreateCellStyle();//样式
                dateStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//文字水平对齐方式
                dateStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//文字垂直对齐方式
                ICell C0 = sheet0.GetRow(0).GetCell(0);
                C0.SetCellValue("公共信息");
                C0.CellStyle = dateStyle;
                sheet0.GetRow(1).GetCell(1).CellStyle = dateStyle;
                sheet0.GetRow(2).GetCell(1).CellStyle = dateStyle;
                sheet0.GetRow(3).GetCell(1).CellStyle = dateStyle;
                for (int i = 1; i < mString.Count; i++)
                {
                    String[] str = mString[i];
                    IRow row = sheet0.GetRow(i);
                    if (i < 4)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            ICell cell = row.GetCell(j);
                            cell.SetCellValue(str[j]);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < str.Length; j++)
                        {
                            ICell cell = row.GetCell(j);
                            cell.SetCellValue(str[j]);
                        }
                    }
                }
                sheet0.GetRow(mCount - 1).GetCell(0).SetCellValue("子项目序号");
                sheet0.GetRow(mCount - 1).GetCell(1).SetCellValue("子项目类型");
                sheet0.GetRow(mCount - 1).GetCell(2).SetCellValue("建筑类型");
                sheet0.GetRow(mCount - 1).GetCell(3).SetCellValue("建筑面积");

                int dataGridR = dataGridView.RowCount;
                int dataGridC = dataGridView.ColumnCount;

                for (int i = mCount; i < mCount + dataGridR; i++)
                {
                    IRow row = sheet0.CreateRow(i + 1);
                    for (int j = 0; j < dataGridC; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue("" + dataGridView.Rows[i - mCount].Cells[j].Value);
                    }
                }
                //sheet0.CreateRow(100).CreateCell(0);
                //sheet0.GetRow(100).GetCell(0).SetCellFormula("=Today()");



                ISheet sheet1 = wb.CreateSheet("人员安排信息");
                int dataGridR1 = dataGridView2.RowCount;
                int dataGridC1 = dataGridView2.ColumnCount;
                if (dataGridC1 < 12)
                    dataGridC1 = 12;
                for (int i = 0; i < dataGridR1 + 1; i++)
                {
                    IRow row = sheet1.CreateRow(i);
                    for (int j = 0; j < dataGridC1; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        if (i != 0)
                            cell.SetCellValue("" + dataGridView2.Rows[i - 1].Cells[j].Value);
                    }

                }
                sheet1.GetRow(0).GetCell(0).SetCellValue("专业");
                sheet1.GetRow(0).GetCell(1).SetCellValue("文件夹开头");
                sheet1.GetRow(0).GetCell(2).SetCellValue("子项号");
                sheet1.GetRow(0).GetCell(3).SetCellValue("子项名称");
                sheet1.GetRow(0).GetCell(4).SetCellValue("审核人");
                sheet1.GetRow(0).GetCell(5).SetCellValue("校核人");
                sheet1.GetRow(0).GetCell(6).SetCellValue("校对人");
                sheet1.GetRow(0).GetCell(7).SetCellValue("设计人");
                sheet1.GetRow(0).GetCell(8).SetCellValue("建筑类型");
                sheet1.GetRow(0).GetCell(9).SetCellValue("建筑面积");
                sheet1.GetRow(0).GetCell(10).SetCellValue("系数");
                sheet1.GetRow(0).GetCell(11).SetCellValue("备注");
                FileStream fs = fileInfo.Create();
                wb.Write(fs);
                fs.Close();
            }catch (Exception e)
            {
                return "ERROR!"+e.ToString();
            }
            return fileName;
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
            else if (cell.CellType == CellType.Numeric)
            {
                str = cell.NumericCellValue + "";
            }
            else if (cell.CellType == CellType.Formula)
            {
                if (cell.CachedFormulaResultType == CellType.Numeric)
                    str = cell.NumericCellValue + "";
                else if (cell.CachedFormulaResultType == CellType.Error)
                    str = cell.ErrorCellValue.ToString();
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



       
    }
}
