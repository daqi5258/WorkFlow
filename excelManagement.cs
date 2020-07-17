using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using OracleInternal.SqlAndPlsqlParser;
using System;
using System.Collections.Generic;
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
           
               
            
            
            //Console.WriteLine("sheet name="+sheet.SheetName+",分数："                +cell.ToString()+","+cell.CellType+",s="+score+",m=");
            
            //设置第一行第一列值,更多方法请参考源官方Demo
            //row.CreateCell(0).SetCellValue("test");//设置第一行第一列值

            //导出excel
            //FileStream fs = new FileStream(exportExcelPath, FileMode.Create, FileAccess.ReadWrite);
            //workbook.Write(fs);
            //fs.Close();
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
    }
}
