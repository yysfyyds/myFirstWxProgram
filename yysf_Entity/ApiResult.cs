using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Entity
{
    public class ApiResult<T>
    {
        public int Code { get; set; } = 200;//状态码默认200
        public T? Data { get; set; }//通用数据
        public string? Message { get; set; }//消息
    }
}
