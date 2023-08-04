using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yysf_Entity;
using yysf_Entity.BusEntitys;

namespace yysf_Service.IService.IBusService
{
    public interface IClassifyServeice:IBaseService<Classify>
    {
        Task<ApiResult<List<Classify>>> GetClassifyList(string Key);//获取分类表
    }
}
