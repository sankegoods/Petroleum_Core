using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumModel.Dtos
{
    public class PageingInfo
    {
        
        /// <summary>
        /// 页码
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 每页几个数据
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int totalCount { get; set; }
    }
}
