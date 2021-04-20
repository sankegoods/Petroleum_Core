using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumModel.Dtos
{
    public class ResponseInfo
    {
        /// <summary>
        /// 成功(集合)
        /// </summary>
        public List<object> success { get; set; }
        /// <summary>
        /// 成功(字段)
        /// </summary>
        public object successIn { get; set; }
        /// <summary>
        /// 失败
        /// </summary>
        public object unsuccessful { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int totalCount { get; set; }
    }
}
