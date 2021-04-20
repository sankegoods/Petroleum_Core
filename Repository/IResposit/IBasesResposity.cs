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
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        IEnumerable<T> FindPageAll(int pageIndex, int pageSize, ref int totalCount, string orderBy = "");

        SqlSugarClient FindPageLianbiao();

        /// <summary>
        /// 根据条件查询数据 是否分组
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "");
        ISugarQueryable<T> GetAll();
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="list"></param>
        /// <param name="predicate1"></param>
        /// <returns></returns>
        int UpdateInfo(Expression<Func<T, T>> predicate, Expression<Func<T, bool>> predicate1);
        /// <summary>
        /// 修改（批量）
        /// </summary>
        /// <param name="list"></param>
        /// <param name="predicate1"></param>
        /// <returns></returns>
        int Updateable(List<T> list, Expression<Func<T, T>> predicate);

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int DeleteInfo(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 事务
        /// </summary>
        /// <param name="action"></param>
        void StatrAffair(Action action);

        void StatrAffairs(Action action);

        /// <summary>
        /// 添加数据(返回受影响行数)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int AddInfo(T t);

        /// <summary>
        /// 添加数据(返回插入的自增长列)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int AddCreateInfo(T t);
    }
}
