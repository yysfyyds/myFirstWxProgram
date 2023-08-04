using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yysf_Entity;
using yysf_Entity.BusEntitys;
using yysf_Repository;
using yysf_Service.IService.IBusService;

namespace yysf_Service.BusService
{
    public class ClassifyService:BaseService<Classify>,IClassifyServeice
    {
        public ClassifyService(IBaseRepository<Classify> repository)
            : base(repository)
        {

        }
        public async Task<ApiResult<List<Classify>>> GetClassifyList(string Key)
        {
            List<Classify> classifyList = await base.Query(lambda: e =>e.IsShowNav==true).ToListAsync();
            ApiResult<List<Classify>> apiResult = new ApiResult<List<Classify>>();
            apiResult.Data = classifyList;
            apiResult.Message = "正在获取分类列表";
            return apiResult;

        }
    }
}
