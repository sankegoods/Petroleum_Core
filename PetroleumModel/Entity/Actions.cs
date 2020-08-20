using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// Actions:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Actions
	{
		public Actions()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _url;
		private int? _nametype;
		private int? _nonmenu;
		private int? _mnusort;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NameType
		{
			set{ _nametype=value;}
			get{return _nametype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NonMenu
		{
			set{ _nonmenu=value;}
			get{return _nonmenu;}
		}

		public int? Mnusort { get => _mnusort; set => _mnusort = value; }
		#endregion Model

	}
}

