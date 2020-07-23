using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// OilMaterialOrderDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OilMaterialOrderDetail
	{
		public OilMaterialOrderDetail()
		{}
		#region Model
		private int _id;
		private int? _orderid;
		private string _oilspec;
		private decimal? _volume;
		private decimal? _surplus;
		private decimal? _dayavg;
		private decimal? _needamount;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private int? _isdel;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OilSpec
		{
			set{ _oilspec=value;}
			get{return _oilspec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Volume
		{
			set{ _volume=value;}
			get{return _volume;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Surplus
		{
			set{ _surplus=value;}
			get{return _surplus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DayAvg
		{
			set{ _dayavg=value;}
			get{return _dayavg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NeedAmount
		{
			set{ _needamount=value;}
			get{return _needamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

