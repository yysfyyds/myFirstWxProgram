using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Entity
{
    public class BaseEntity <TKey>
    {
        public TKey Id { get; set; } //主键
        public int Sort { get; set; }//排序
        public DateTime CreateTime { get; set; } = DateTime.Now;//数据创建时间
        public DateTime UpdateTime { get; set; } = DateTime.Now;//数据修改时间
        public long UserId { get; set; }
        public string? UserName { get; set; }//?表示可为空

    }
}
