using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumModel.ExtendMode
{
    public class organStrucChildren
    {
        public int id { get; set; }
        public string label { get; set; }
        public string Leve { get; set; }
        public string ParentId { get; set; }
        public List<organSturchilders> children { get; set; }
    }
}
