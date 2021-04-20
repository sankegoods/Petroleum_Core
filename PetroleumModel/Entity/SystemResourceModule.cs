using SqlSugar;
using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// SystemResourceModule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SystemResourceModule
	{
		public SystemResourceModule()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _code;
		private string _url;
		private int? _typed;
		private string _parentid;
		private int? _orderno;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Typed
		{
			set{ _typed=value;}
			get{return _typed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		#endregion Model

	}
}

