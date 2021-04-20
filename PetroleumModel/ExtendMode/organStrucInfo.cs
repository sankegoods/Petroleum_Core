using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumModel.ExtendMode
{
     public class organStrucInfo
    {
        public int id { get; set; }
        public string label { get; set; }
        public string Leve { get; set; }
        public string ParentId { get; set; }
        public List<organStrucChildren> children { get; set; }
    }
}
