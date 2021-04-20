using SqlSugar;
using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// Approver:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Approver
	{
		public Approver()
		{}
		#region Model
		private int _id;
		private string _jobcode;
		private int _arealeve;
		private string _discrible;
		private int _orders;
		private int? _processitemid;
		private string _executemethod;
		/// <summary>
		/// 
		/// </summary>
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobCode
		{
			set{ _jobcode=value;}
			get{return _jobcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AreaLeve
		{
			set{ _arealeve=value;}
			get{return _arealeve;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Discrible
		{
			set{ _discrible=value;}
			get{return _discrible;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Orders
		{
			set{ _orders=value;}
			get{return _orders;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProcessItemId
		{
			set{ _processitemid=value;}
			get{return _processitemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExecuteMethod
		{
			set{ _executemethod=value;}
			get{return _executemethod;}
		}
		#endregion Model

	}
}

