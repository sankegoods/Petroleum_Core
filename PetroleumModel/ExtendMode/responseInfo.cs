using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumModel.ExtendMode
{
    public class responseInfo
    {
        public int pageInfo { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
        public List<object> okInfo { get; set; }
    }
}
