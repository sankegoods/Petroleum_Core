using Repository.IResposit;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Resposit
{
    public class BasesResposity<T> : IBasesResposity<T> where T : class, new()
    {
        protected readonly SqlSugarClient _db;
        public BasesResposity()
        {
            _db = DbContextFactory.GetInstance();
        }

        /// <summary>
        /// 查询全部(不加分页)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll()
        {
            return _db.Queryable<T>().ToList();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindPageAll(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize, ref int totalCount, string orderBy = "")
        {
            var query = _db.Queryable<T>().Where(predicate);
            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }
            return query.ToPageList(pageIndex, pageSize, ref totalCount);
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "")
        {
            var query = _db.Queryable<T>().Where(predicate);
            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }
            return query.ToList();
        }

        public ISugarQueryable<T> GetAll()
        {
            return _db.Queryable<T>();
        }
    }
}
