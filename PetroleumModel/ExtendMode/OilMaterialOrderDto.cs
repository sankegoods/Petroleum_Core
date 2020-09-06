using PetroleumModel.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumModel.ExtendMode
{
    public class OilMaterialOrderDto : OilMaterialOrder
    {
        public string stfName { get; set; }
        public string OilSpec { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Surplus { get; set; }
        public decimal? DayAvg { get; set; }
        public decimal? NeedAmount { get; set; }
        public int DetailID { get; set; }
    }
}
