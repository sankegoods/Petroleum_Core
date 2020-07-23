using PetroleumModel.Model;
using PetroleumService.IService;
using Repository.IResposit;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace PetroleumService.Service
{
    public class BasesService<T> : IBaseService<T> where T : class, new()
    {
        protected IBasesResposity<T> _baseRepository { get; set; }
        public ISugarQueryable<T> getList()
        {
            return _baseRepository.GetAll();
        }

        /// <summary>
        /// 事务
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool Submit(Action action)
        {
            using (var tranScope = new TransactionScope())
            {
                try
                {
                    action();
                    tranScope.Complete();
                    return true;
                }
                catch (Exception)
                {
                    tranScope.Dispose();
                    throw;
                }
            }
        }
    }
}
