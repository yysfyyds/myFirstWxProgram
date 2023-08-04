using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Entity.BusEntitys
{
    public class Picture: BaseEntity<Guid>
    {
        public string? Title { get; set; }//?的作用好像是对空值的某种处理,图片标题
        public int LikeCount { get; set; }//喜欢次数
        public int  ShareCount { get; set; }
        public int CollectCount { get; set;}
        public int DownLoadCount { get; set; }

    }

}