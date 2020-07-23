using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// StaffRole:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StaffRole
	{
		public StaffRole()
		{}
		#region Model
		private int _id;
		private int _staffid;
		private int _roleid;
		private string _isdele;
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
		public int StaffId
		{
			set{ _staffid=value;}
			get{return _staffid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsDele
		{
			set{ _isdele=value;}
			get{return _isdele;}
		}
		#endregion Model

	}
}

