using SqlSugar;
using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// ProcessStepRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProcessStepRecord
	{
		public ProcessStepRecord()
		{}
		#region Model
		private int _id;
		private string _typed;
		private string _recordremarks;
		private int? _oilstation;
		private string _oilstationremark;
		private int? _executivedirector;
		private string _executivedirectorremark;
		private int? _generalmanager;
		private string _generalmanagerremark;
		private int? _generalmanagerofperson;
		private string _generalmanagerofpersonremark;
		private int? _chiefinspector;
		private string _chiefinspectorremark;
		private DateTime _createtime;
		private DateTime? _updatetime;
		private int _whethertoexecute;
		private string _non;
		private int _reforderid;
		private int _result;
		private string _executemethod;
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
		public string Typed
		{
			set{ _typed=value;}
			get{return _typed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordRemarks
		{
			set{ _recordremarks=value;}
			get{return _recordremarks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OilStation
		{
			set{ _oilstation=value;}
			get{return _oilstation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OilStationRemark
		{
			set{ _oilstationremark=value;}
			get{return _oilstationremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ExecutiveDirector
		{
			set{ _executivedirector=value;}
			get{return _executivedirector;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExecutiveDirectorRemark
		{
			set{ _executivedirectorremark=value;}
			get{return _executivedirectorremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GeneralManager
		{
			set{ _generalmanager=value;}
			get{return _generalmanager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GeneralManagerRemark
		{
			set{ _generalmanagerremark=value;}
			get{return _generalmanagerremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GeneralManagerOfPerson
		{
			set{ _generalmanagerofperson=value;}
			get{return _generalmanagerofperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GeneralManagerOfPersonRemark
		{
			set{ _generalmanagerofpersonremark=value;}
			get{return _generalmanagerofpersonremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ChiefInspector
		{
			set{ _chiefinspector=value;}
			get{return _chiefinspector;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChiefInspectorRemark
		{
			set{ _chiefinspectorremark=value;}
			get{return _chiefinspectorremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
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
		public int WhetherToExecute
		{
			set{ _whethertoexecute=value;}
			get{return _whethertoexecute;}
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
		public int RefOrderId
		{
			set{ _reforderid=value;}
			get{return _reforderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExecuteMethod
		{
			set{ _executemethod=value;}
			get{return _executemethod;}
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

