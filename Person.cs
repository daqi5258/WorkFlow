using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Org.BouncyCastle.Math.EC.Multiplier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow
{
    /// <summary>
    /// 人员安排信息
    /// </summary>
    public class PersonArrange
    {
        
        public String project_id { get; set; }//工程编号
        public String construct_company { get; set; }//建筑公司
        public String project_name { get; set; }//工程名称
        public String person_project{ get; set; }//项目负责人
        public String person_construct { get; set; }//注册建筑师
        /// <summary>
        /// 项目秘书
        /// </summary>
        public String person_secretary { get; set; }
        public List<String[]> detail;//人员安排
        public PersonArrange()
        {
            project_id = null;
            project_name = null;
            detail = new List<string[]>();
        }

        /*
        public List<DetailArrange> addDA(DetailArrange da )
        {
            if (!das.Contains(da))
            {
                das.Add(da);
            }
            return das;
        }
        */
       

        /// <summary>
        /// 读取人员安排表
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public PersonArrange GetPersonDetail(String filepath)
        {
            try
            {
                IWorkbook workbook = new HSSFWorkbook();
                PersonArrange pa = new PersonArrange();
                string[] files1 = Directory.GetFiles(filepath, "*人员安排*.xls*", SearchOption.AllDirectories);
                try
                {
                    workbook = WorkbookFactory.Create(function.GetLatestFile(files1));
                }
                catch (Exception e)
                {
                    return pa;
                }
                if (workbook is null)
                {
                    Console.WriteLine("workbook is null");
                    return pa;
                }
                ISheet sheet = workbook.GetSheetAt(0);
                pa.project_id = sheet.GetRow(1).GetCell(1) == null ? "" : sheet.GetRow(1).GetCell(1).ToString();
                pa.construct_company = sheet.GetRow(2).GetCell(1) == null ? "" : sheet.GetRow(2).GetCell(1).ToString();
                pa.project_name = sheet.GetRow(3).GetCell(1) == null ? "" : sheet.GetRow(3).GetCell(1).ToString();
                pa.person_project = sheet.GetRow(4).GetCell(1) == null ? "" : sheet.GetRow(4).GetCell(1).ToString();
                pa.person_construct = sheet.GetRow(5).GetCell(1) == null ? "" : sheet.GetRow(5).GetCell(1).ToString();
                pa.person_secretary = sheet.GetRow(6).GetCell(1) == null ? "" : sheet.GetRow(6).GetCell(1).ToString();
               
                List<String[]> lda = new List<String[]>();
                Boolean ck = false;
                String lastName = "";
                int startRow = 0;
                for (int i = 1; i < sheet.LastRowNum; i++)
                {
                    if (sheet.GetRow(i)!=null && sheet.GetRow(i).GetCell(0)!=null && function.Value(sheet.GetRow(i).GetCell(0))=="人员安排表")
                    {
                        ck = true;
                        //Console.WriteLine("start row="+i);
                        startRow = i + 2;
                    }
                    if (sheet.GetRow(i) != null && ck && i>=startRow)
                    {
                        IRow row = sheet.GetRow(i);
                        int colCount = row.LastCellNum;
                        String[] str = new string[colCount];
                        if(function.Value(row.GetCell(0)).Length>0)
                            lastName = function.Value(row.GetCell(0));
                        str[0] = lastName;
                        for (int j = 1; j < colCount; j++)
                        {
                            str[j] = function.Value(row.GetCell(j));
                            
                        };
                        if (str[1].Length>0)
                        {
                            lda.Add(str);
                        }
                       
                    }
                }
                //Console.WriteLine("子项目有："+lda.Count);
                pa.setDetail(lda);
                return pa;
            }
            catch (Exception e)
            {
                Console.WriteLine("e="+e.ToString());
                return null;
            }

        }

        public void setDetail(List<string[]> lda)
        {
            detail = lda;
        }
        /*
* 
* public PersonArrange GetPersonDetail(String filepath)
{
   IWorkbook workbook = new HSSFWorkbook();
   PersonArrange pa = new PersonArrange();
   string[] files1 = Directory.GetFiles(filepath, "*人员安排*.xls*", SearchOption.AllDirectories);
   try
   {
       workbook = WorkbookFactory.Create(function.GetLatestFile(files1));
   }
   catch (Exception e)
   {
       return pa;
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
   pa.person_project = sheet.GetRow(3).GetCell(3) == null ? "" : sheet.GetRow(3).GetCell(3).ToString();

   pa.person_1 = sheet.GetRow(6).GetCell(4) == null ? "" : sheet.GetRow(6).GetCell(4).ToString();
   pa.person_2 = sheet.GetRow(6).GetCell(7) == null ? "" : sheet.GetRow(6).GetCell(7).ToString();
   pa.person_3 = sheet.GetRow(6).GetCell(10) == null ? "" : sheet.GetRow(6).GetCell(10).ToString();
   pa.person_4 = sheet.GetRow(6).GetCell(13) == null ? "" : sheet.GetRow(6).GetCell(13).ToString();
   pa.person_5 = sheet.GetRow(6).GetCell(16) == null ? "" : sheet.GetRow(6).GetCell(16).ToString();

   List<DetailArrange> lda = new List<DetailArrange>();
   for (int i = 8; i < sheet.LastRowNum; i++)
   {
       if (sheet.GetRow(i) != null)
       {
           DetailArrange dat = new DetailArrange
           {
               flag = function.Value(sheet.GetRow(i).GetCell(0)),
               project_detail = function.Value(sheet.GetRow(i).GetCell(1)),
               project_type = function.Value(sheet.GetRow(i).GetCell(2)),
               detail_no = function.Value(sheet.GetRow(i).GetCell(3)),
               person_design_1 = function.Value(sheet.GetRow(i).GetCell(4)),
               person_verify_1 = function.Value(sheet.GetRow(i).GetCell(5)),
               person_check_1 = function.Value(sheet.GetRow(i).GetCell(6)),
               person_design_2 = function.Value(sheet.GetRow(i).GetCell(7)),
               person_verify_2 = function.Value(sheet.GetRow(i).GetCell(8)),
               person_check_2 = function.Value(sheet.GetRow(i).GetCell(9)),
               person_design_3 = function.Value(sheet.GetRow(i).GetCell(10)),
               person_verify_3 = function.Value(sheet.GetRow(i).GetCell(11)),
               person_check_3 = function.Value(sheet.GetRow(i).GetCell(12)),
               person_design_4 = function.Value(sheet.GetRow(i).GetCell(13)),
               person_verify_4 = function.Value(sheet.GetRow(i).GetCell(14)),
               person_check_4 = function.Value(sheet.GetRow(i).GetCell(15)),
               person_design_5 = function.Value(sheet.GetRow(i).GetCell(16)),
               person_verify_5 = function.Value(sheet.GetRow(i).GetCell(17)),
               person_check_5 = function.Value(sheet.GetRow(i).GetCell(18))
           };
           lda.Add(dat);
       }
   }
   pa.setDAS(lda);
   return pa;

}
* 
*/
    }
    /// <summary>
    ///子项目明细
    /// </summary>
    public class DetailArrange
    {
      
        public String flag{get; set;} //标准，暂无试用
        public String project_detail { get; set; }//子项目描述
        public String project_type { get; set; }//户型
        public String detail_no { get; set; }//子项目编号
        //总图、建筑的设计、校对和审核人
        public String person_design_1 { get; set; }
        public String person_verify_1 { get; set; }
        public String person_check_1 { get; set; }
        //结构的设计、校对和审核人
        public String person_design_2 { get; set; }
        public String person_verify_2 { get; set; }
        public String person_check_2 { get; set; }
        //给排水的设计、校对和审核人
        public String person_design_3 { get; set; }
        public String person_verify_3 { get; set; }
        public String person_check_3 { get; set; }
        //电气的设计、校对和审核人
        public String person_design_4 { get; set; }
        public String person_verify_4 { get; set; }
        public String person_check_4 { get; set; }
        //暖通的设计、校对和审核人
        public String person_design_5 { get; set; }
        public String person_verify_5 { get; set; }
        public String person_check_5 { get; set; }

    }



}
