using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using OracleInternal.SqlAndPlsqlParser;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

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

        public List<HCType> Read(String filePath)
        {
            IWorkbook workbook = WorkbookFactory.Create(filePath);
            if (workbook is null)
                return null;
            ISheet sheet  = workbook.GetSheetAt(0);
            int rowCount = sheet.LastRowNum ;
            List<HCType> HCTypes = new List<HCType>();
            for (int i=1;i<rowCount;i++)
            {

                String Kind = Value(sheet.GetRow(i).GetCell(0));
                String TypeName = Value(sheet.GetRow(i).GetCell(1));
                String Area = Value(sheet.GetRow(i).GetCell(2));
                String jz = Value(sheet.GetRow(i).GetCell(3));
                String jg = Value(sheet.GetRow(i).GetCell(4));
                String water = Value(sheet.GetRow(i).GetCell(5));
                String ele = Value(sheet.GetRow(i).GetCell(6));
                String nt = Value(sheet.GetRow(i).GetCell(7));
                Boolean flag = true;
                foreach (HCType hctype in HCTypes)
                {
                    if (hctype.TypeName == TypeName)
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
                    hctype.Kind = Kind;
                    hctype.TypeName = TypeName;
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

        public void Write(String filepath,List<String[]> inf,String[] header)
        {
            DateTime dt = DateTime.Now;
            String shtStr = dt.ToString(@"MM_dd");
            
            IWorkbook workbook = new HSSFWorkbook();
            try{
                workbook = WorkbookFactory.Create(filepath);
                
                ISheet sht = workbook.GetSheetAt(0);
                int RowCount = sht.LastRowNum+1;
                
                foreach (String[] str in inf)
                {
                    Console.WriteLine(sht.SheetName + "," + RowCount+",lastR="+sht.LastRowNum);
                    IRow row = sht.CreateRow(RowCount);
                    for (int i = 0; i < str.Length; i++)
                    {
                        ICell cell = row.CreateCell(i);
                        cell.SetCellValue(str[i]);
                    }
                    RowCount++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nfile not found:"+e);
                ISheet sht = workbook.CreateSheet(shtStr);
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


        public void Write(String filePath)
        {
            String name = @"人员安排表.xls";
            FileStream fs = new FileStream(filePath + "\\" + name, FileMode.Create, FileAccess.ReadWrite);
            HSSFWorkbook wb = new HSSFWorkbook(fs);

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
