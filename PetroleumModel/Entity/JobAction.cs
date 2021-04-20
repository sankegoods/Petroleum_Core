using SqlSugar;
using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// RoleAction:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JobAction
	{
		public JobAction()
		{}
		#region Model
		private int _jobactionid;
		private int? _jobid;
		private int _actionid;
		private string _isdelete;
		/// <summary>
		/// 
		/// </summary>
		[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
		public int JobActionID
		{
			set{ _jobactionid = value;}
			get{return _jobactionid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? JobId
		{
			set{ _jobid = value;}
			get{return _jobid; }
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

