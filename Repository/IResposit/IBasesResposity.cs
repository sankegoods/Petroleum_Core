using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.IResposit
{
    public interface IBasesResposity<T> where T : class
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindPageAll(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize, ref int totalCount, string orderBy = "");
        IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "");
        ISugarQueryable<T> GetAll();
    }
}
