using System;
using SqlSugar;
namespace PetroleumModel.Model
{
    /// <summary>
    /// OilMaterialOrder:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OilMaterialOrder
    {
        public OilMaterialOrder()
        { }
        #region Model
        private int _id;
        private string _non;
        private string _staffNoN;
        private DateTime _applydate;
        private string _remark;
        private int _isdel;
        private DateTime? _createtime;
        private DateTime? _updatetime;
        private int _ispanke = 0;
        private int _islaunch = 0;
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NoN
        {
            set { _non = value; }
            get { return _non; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StaffNoN
        {
            set { _staffNoN = value; }
            get { return _staffNoN; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ApplyDate
        {
            set { _applydate = value; }
            get { return _applydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsPanke
        {
            set { _ispanke = value; }
            get { return _ispanke; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsLaunch
        {
            set { _islaunch = value; }
            get { return _islaunch; }
        }
        #endregion Model

    }
}

