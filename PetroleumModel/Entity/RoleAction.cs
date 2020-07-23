using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// RoleAction:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleAction
	{
		public RoleAction()
		{}
		#region Model
		private int _roleactionid;
		private int? _roleid;
		private int _actionid;
		private string _isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int RoleActionID
		{
			set{ _roleactionid=value;}
			get{return _roleactionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ActionId
		{
			set{ _actionid=value;}
			get{return _actionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

