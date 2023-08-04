using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yysf_Entity.BusEntitys;
using yysf_Entity_Framework;
using yysf_Repository.BusRepository.IBusRepository;

namespace yysf_Repository.BusRepository
{
    public class ArticleRepository:BaseRepository<Article>,IArticleRepository//文章仓库
    {
        public ArticleRepository(SqlDbContext sqlDbContext)    
            : base(sqlServerDbContext: sqlDbContext) { }

    }
}
