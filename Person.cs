using System;
using System.Collections.Generic;
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
        public String person_project{ get; set; }//项目工程师
        public String person_1 { get; set; }//总图、建筑专负
        public String person_2 { get; set; }//结构专负
        public String person_3 { get; set; }//给排水专负
        public String person_4 { get; set; }//电气专负
        public String person_5 { get; set; }//暖通专负
        public List<DetailArrange> das;//子项目信息

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
        public List<DetailArrange> deteleDA(DetailArrange da)
        {
            if (das.Contains(da))
            {
                das.Remove(da);
            }
            return das;
        }

        public void setDAS (List<DetailArrange>  tmpLDA)
        {            
             das=tmpLDA;
        }

        public List<DetailArrange> get()
        {
            return das;
        }


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
