using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkFlow
{
    struct ScoreInArea
    {
        public String Area;
        public String jz;
        public String jg;
        public String water;
        public String ele;
        public String nt;

    }
    class HCType
    {
        public String Kind { get; set; }
        public String TypeName { get; set; }
        public List<ScoreInArea> Detail;
        public HCType()
        {
            Detail = new List<ScoreInArea>();
        }
        public HCType(String kind, String typeName)
        {
            this.Kind = kind;
            this.TypeName = typeName;
            Detail = new List<ScoreInArea>();
        }
        public List<ScoreInArea> GetScoreInArea()
        {
            return Detail;
        }
        public void SetScoreInArea(List<ScoreInArea> scoreInAreas)
        {
            Detail = scoreInAreas;
        }
        public void AddScoreInArea(ScoreInArea scoreInArea)
        {
            if (Detail.Count > 0)
            {
                if (!Detail.Contains(scoreInArea))
                    Detail.Add(scoreInArea);
            }
            else
                Detail.Add(scoreInArea);
        }


      
    }
}
