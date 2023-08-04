using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Entity
{//分页通用返回类
    public class PageData<TEntity>
    {
        public List<TEntity> List { get; set; } 
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}
