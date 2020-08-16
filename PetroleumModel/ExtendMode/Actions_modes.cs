using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumModel
{
    public class Actions_modes
    {
        public string Name { get; set; }
        public List<Actions> children { get; set; }
    }
}
