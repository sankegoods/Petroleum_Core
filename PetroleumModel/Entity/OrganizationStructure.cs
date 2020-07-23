using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// OrganizationStructure:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrganizationStructure
	{
		public OrganizationStructure()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _leve;
		private string _parentid;
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
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
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
		public string Leve
		{
			set{ _leve=value;}
			get{return _leve;}
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

