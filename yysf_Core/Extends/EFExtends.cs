using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace yysf_Core.Extends
{
    public static class EFExtends//扩展whereif条件语句
    {
        public static IQueryable<T> WhereIf<T>(this  IQueryable<T> queryable,Expression<Func<T,bool>> expression
            ,bool condition)
        {
            return condition? queryable.Where(predicate: expression ): queryable;
        }
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable,int skipNum,int takeNum,out int count)
        {
            count = queryable.Count();
            return queryable.Skip(count: skipNum).Take(count: takeNum);
        }
    }
}
