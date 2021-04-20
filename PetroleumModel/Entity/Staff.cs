using SqlSugar;
using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// Staff:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Staff
	{
		public Staff()
		{}
		#region Model
		private int _id;
		private string _non;
		private string _name;
		private string _sex;
		private string _birthday;
		private string _nativeplace;
		private string _addressd;
		private string _passwords;
		private string _email;
		private string _tel;
		private string _statusd;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private int? _jobid;
		private int? _roleid;
		private int? _orgid;
		private string _ishsegroup;
		private int? _islaunch;
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
		public string NoN
		{
			set{ _non=value;}
			get{return _non;}
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
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BirthDay
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NativePlace
		{
			set{ _nativeplace=value;}
			get{return _nativeplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Addressd
		{
			set{ _addressd=value;}
			get{return _addressd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Passwords
		{
			set{ _passwords=value;}
			get{return _passwords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Statusd
		{
			set{ _statusd=value;}
			get{return _statusd;}
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
		public int? JobId
		{
			set{ _jobid=value;}
			get{return _jobid;}
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
		public int? OrgID
		{
			set{ _orgid=value;}
			get{return _orgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsHSEGroup
		{
			set{ _ishsegroup=value;}
			get{return _ishsegroup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsLaunch
		{
			set{ _islaunch=value;}
			get{return _islaunch;}
		}
		#endregion Model

	}
}

