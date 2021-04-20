using SqlSugar;
using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// ProcessItem:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProcessItem
	{
		public ProcessItem()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _discrible;
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
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Discrible
		{
			set{ _discrible=value;}
			get{return _discrible;}
		}
		#endregion Model

	}
}

