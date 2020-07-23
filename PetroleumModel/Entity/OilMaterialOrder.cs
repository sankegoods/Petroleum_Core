using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// OilMaterialOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OilMaterialOrder
	{
		public OilMaterialOrder()
		{}
		#region Model
		private int _id;
		private string _non;
		private string _applypersonid;
		private DateTime _applydate;
		private string _remark;
		private int _isdel;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private int _ispanke=0;
		private int _islaunch=0;
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
		public string NoN
		{
			set{ _non=value;}
			get{return _non;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyPersonId
		{
			set{ _applypersonid=value;}
			get{return _applypersonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ApplyDate
		{
			set{ _applydate=value;}
			get{return _applydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
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
		public int IsPanke
		{
			set{ _ispanke=value;}
			get{return _ispanke;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsLaunch
		{
			set{ _islaunch=value;}
			get{return _islaunch;}
		}
		#endregion Model

	}
}

