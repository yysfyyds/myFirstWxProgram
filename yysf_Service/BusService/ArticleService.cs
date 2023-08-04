using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yysf_Core.Extends;
using yysf_Entity;
using yysf_Entity.BusEntitys;
using yysf_Repository.BusRepository.IBusRepository;
using yysf_Service.IService.IBusService;

namespace yysf_Service.BusService
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        public ArticleService(IArticleRepository articleRepositry)
            : base(repository: articleRepositry) 
        {

        }

        public async Task<ApiResult<PageData<Article>>> GetArticleListPageAsync(string title, string content, int? classifyId, int pageIndex = 1, int pageSize = 10)
        {//获取文章分页数据
            IQueryable<Article> query =  base._repository.Query()
            .WhereIf(expression: e => e.Title.Contains(title), condition: !string.IsNullOrEmpty(value: title))
            .WhereIf(expression: e => e.Content.Contains(content), condition: !string.IsNullOrEmpty(value: content))
            .WhereIf(expression: e => e.ClassifyId == classifyId, condition: classifyId != null);

            int count = _repository.Count();
            List<Article> articles=await query.Skip(count:(pageIndex-1)*pageSize)
            .Take(count:pageSize)
            .ToListAsync();

            PageData<Article> pageData = new PageData<Article>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                List=articles,
                Total=count
            
            };
            ApiResult<PageData<Article>> apiResult = new ApiResult<PageData<Article>>()
            {
                Data = pageData,
                Message="获取分页文章数据列表"
            };
            return apiResult;
        }

        public async Task<ApiResult<PageData<Article>>> GetArticleListPageAsync(string keyWord,int?classifyId, int pageIndex = 1, int pageSize = 10)
        {
            List<Article> articlesList=await base.Query(lambda: e=>(e.State==1))
                .WhereIf(expression: e => e.Title.Contains( keyWord)
                    && e.Content.Contains( keyWord), condition: !string.IsNullOrEmpty(value: keyWord))
                .WhereIf(expression: e =>e.ClassifyId==classifyId,condition: classifyId!=null)
                .Paging(skipNum: pageIndex, takeNum: pageSize, count: out int count)
                .ToListAsync();

            PageData<Article> pageData = new PageData<Article>()
            {
                Total = count,
                List = articlesList,
                PageIndex = pageIndex,
                PageSize = pageSize,

            };
            ApiResult<PageData<Article>> apiResult = new ApiResult<PageData<Article>>() 
            {
                Data = pageData,
                Message = "获取分页文章数据列表"
            };
            return apiResult;

        }
    }
}
