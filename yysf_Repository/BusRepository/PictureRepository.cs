using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yysf_Entity.BusEntitys;
using yysf_Entity_Framework;

namespace yysf_Repository.BusRepository
{//图片类仓储
    public class PictureRepository:BaseRepository<Picture>, IPictureRepository
    {
        public PictureRepository(SqlDbContext sqlDbContext)
            : base(sqlServerDbContext: sqlDbContext) 
        {

        }
    }
}
