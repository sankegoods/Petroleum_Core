using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// LeaveOffice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LeaveOffice
	{
		public LeaveOffice()
		{}
		#region Model
		private int _id;
		private string _non;
		private string _staffname;
		private int? _jobid;
		private string _leavetype;
		private DateTime? _applydate;
		private string _reason;
		private string _explanationhandover;
		private string _handoversatffid;
		private string _applypersonid;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private int? _isyes;
		private string _isdel;
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
		public string NoN
		{
			set{ _non=value;}
			get{return _non;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StaffName
		{
			set{ _staffname=value;}
			get{return _staffname;}
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
		public string LeaveType
		{
			set{ _leavetype=value;}
			get{return _leavetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ApplyDate
		{
			set{ _applydate=value;}
			get{return _applydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExplanationHandover
		{
			set{ _explanationhandover=value;}
			get{return _explanationhandover;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HandoverSatffId
		{
			set{ _handoversatffid=value;}
			get{return _handoversatffid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyPersonId
		{
			set{ _applypersonid=value;}
			get{return _applypersonid;}
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
		public int? isyes
		{
			set{ _isyes=value;}
			get{return _isyes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

