using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using yysf_Service.BusService;
using yysf_Service.IService.IBusService;

namespace yysf_wx_api.Controllers
{
    [Route(template:"api/[controller]")]
    [ApiController]
    public class MiniAppController : ControllerBase
    {
        private readonly IClassifyServeice _classifyServeice;
        private readonly IArticleService _articleService;
        public MiniAppController(IClassifyServeice classifyServeice, IArticleService articleService) 
        {
            this._classifyServeice= classifyServeice;
            this._articleService = articleService;
        }
        [HttpGet, Route(template: "GetClassifyList")]
        public async Task<IActionResult> GetClassifyList(string key)//根据key标识获取分类列表
            => Ok(value:await _classifyServeice.GetClassifyList(key));
        [HttpGet, Route(template: "GetArticleListPage")]//由条件获取分页

        public async Task<IActionResult> GetArticleList(string keyWord,int? classifyId, int pageIndex = 1, int pageSize = 10)
            => Ok(value: await _articleService.GetArticleListPageAsync(keyWord, classifyId, pageIndex, pageSize));
    }
}
