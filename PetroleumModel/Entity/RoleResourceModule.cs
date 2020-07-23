using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// RoleResourceModule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleResourceModule
	{
		public RoleResourceModule()
		{}
		#region Model
		private Guid _roleid;
		private Guid _resourcemoduleid;
		/// <summary>
		/// 
		/// </summary>
		public Guid RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid ResourceModuleId
		{
			set{ _resourcemoduleid=value;}
			get{return _resourcemoduleid;}
		}
		#endregion Model

	}
}

