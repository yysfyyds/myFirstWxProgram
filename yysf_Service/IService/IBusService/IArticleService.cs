using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yysf_Entity;
using yysf_Entity.BusEntitys;

namespace yysf_Service.IService.IBusService
{
    public interface IArticleService:IBaseService<Article>
    {//获取文章列表数据分页
        Task<ApiResult<PageData<Article>>> GetArticleListPageAsync(string title, string content, int? classifyId, int pageIndex = 1, int pageSize = 10);
        Task<ApiResult<PageData<Article>>> GetArticleListPageAsync(string keyWord,int? classifyId,int pageIndex=1, int pageSize = 10);//根据关键字获取分页，文章列表
    }
}
