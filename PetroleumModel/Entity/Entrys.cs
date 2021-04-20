using System;
namespace PetroleumModel.Model
{
	/// <summary>
	/// Entrys:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Entrys
	{
		public Entrys()
		{}
		#region Model
		private int _id;
		private string _staffname;
		private int? _sex;
		private string _birthday;
		private int? _maritalstatus;
		private decimal? _height;
		private int? _highesteducation;
		private string _major;
		private string _foreginlanguageaptitude;
		private string _idnumber;
		private string _nativeplace;
		private string _addressd;
		private string _email;
		private string _tel;
		private int? _hasemedicalhistory;
		private string _medicalhistorycomment;
		private string _hobbiesandspeciality;
		private DateTime? _educationalexperience1startdate;
		private DateTime? _educationalexperience1enddate;
		private string _educationalexperience1schoolname;
		private string _educationalexperience1major;
		private string _educationalexperience1certificate;
		private DateTime? _educationalexperience2startdate;
		private DateTime? _educationalexperience2enddate;
		private string _educationalexperience2schoolname;
		private string _educationalexperience2major;
		private string _educationalexperience2certificate;
		private DateTime? _educationalexperience3startdate;
		private DateTime? _educationalexperience3enddate;
		private string _educationalexperience3schoolname;
		private string _educationalexperience3major;
		private string _educationalexperience3certificate;
		private DateTime? _educationalexperience4startdate;
		private DateTime? _educationalexperience4enddate;
		private string _educationalexperience4schoolname;
		private string _educationalexperience4major;
		private string _educationalexperience4certificate;
		private string _familystatus1name;
		private string _familystatus1appellation;
		private string _familystatus1company;
		private string _familystatus1tel;
		private string _familystatus2name;
		private string _familystatus2appellation;
		private string _familystatus2company;
		private string _familystatus2tel;
		private string _emergencycontactname;
		private string _emergencycontacttel;
		private string _emergencycontacteelationshipwithme;
		private string _workexperience1companyname;
		private string _workexperience1job;
		private DateTime? _workexperience1startdate;
		private DateTime? _workexperience1enddate;
		private string _workexperience1pay;
		private string _workexperience1leavingreasons;
		private string _workexperience2companyname;
		private string _workexperience2job;
		private DateTime? _workexperience2startdate;
		private DateTime? _workexperience2enddate;
		private string _workexperience2pay;
		private string _workexperience2leavingreasons;
		private string _workexperience3companyname;
		private string _workexperience3job;
		private DateTime? _workexperience3startdate;
		private DateTime? _workexperience3enddate;
		private string _workexperience3pay;
		private string _workexperience3leavingreasons;
		private string _workexperience4companyname;
		private string _workexperience4job;
		private DateTime? _workexperience4startdate;
		private DateTime? _workexperience4enddate;
		private string _workexperience4pay;
		private string _workexperience4leavingreasons;
		private int? _jobid;
		private string _title;
		private int? _organization_id;
		private string _supervisorcomments;
		private string _probationarysalary;
		private string _correctsalary;
		private string _worknumber;
		private DateTime? _entrydate;
		private string _birthcertificatephoto;
		private string _registrationphoto;
		private string _bankcardnumber;
		private string _createstaffeid;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private string _non;
		private string _staffno;
		private int _isdel;
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
		public string StaffName
		{
			set{ _staffname=value;}
			get{return _staffname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sex
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
		public int? MaritalStatus
		{
			set{ _maritalstatus=value;}
			get{return _maritalstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? HighestEducation
		{
			set{ _highesteducation=value;}
			get{return _highesteducation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ForeginLanguageAptitude
		{
			set{ _foreginlanguageaptitude=value;}
			get{return _foreginlanguageaptitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IDNumber
		{
			set{ _idnumber=value;}
			get{return _idnumber;}
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
		public int? HaseMedicalHistory
		{
			set{ _hasemedicalhistory=value;}
			get{return _hasemedicalhistory;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MedicalHistoryComment
		{
			set{ _medicalhistorycomment=value;}
			get{return _medicalhistorycomment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HobbiesAndSpeciality
		{
			set{ _hobbiesandspeciality=value;}
			get{return _hobbiesandspeciality;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EducationalExperience1StartDate
		{
			set{ _educationalexperience1startdate=value;}
			get{return _educationalexperience1startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EducationalExperience1EndDate
		{
			set{ _educationalexperience1enddate=value;}
			get{return _educationalexperience1enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience1SchoolName
		{
			set{ _educationalexperience1schoolname=value;}
			get{return _educationalexperience1schoolname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience1Major
		{
			set{ _educationalexperience1major=value;}
			get{return _educationalexperience1major;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience1Certificate
		{
			set{ _educationalexperience1certificate=value;}
			get{return _educationalexperience1certificate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EducationalExperience2StartDate
		{
			set{ _educationalexperience2startdate=value;}
			get{return _educationalexperience2startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EducationalExperience2EndDate
		{
			set{ _educationalexperience2enddate=value;}
			get{return _educationalexperience2enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience2SchoolName
		{
			set{ _educationalexperience2schoolname=value;}
			get{return _educationalexperience2schoolname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience2Major
		{
			set{ _educationalexperience2major=value;}
			get{return _educationalexperience2major;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience2Certificate
		{
			set{ _educationalexperience2certificate=value;}
			get{return _educationalexperience2certificate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EducationalExperience3StartDate
		{
			set{ _educationalexperience3startdate=value;}
			get{return _educationalexperience3startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EducationalExperience3EndDate
		{
			set{ _educationalexperience3enddate=value;}
			get{return _educationalexperience3enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience3SchoolName
		{
			set{ _educationalexperience3schoolname=value;}
			get{return _educationalexperience3schoolname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience3Major
		{
			set{ _educationalexperience3major=value;}
			get{return _educationalexperience3major;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience3Certificate
		{
			set{ _educationalexperience3certificate=value;}
			get{return _educationalexperience3certificate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EducationalExperience4StartDate
		{
			set{ _educationalexperience4startdate=value;}
			get{return _educationalexperience4startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EducationalExperience4EndDate
		{
			set{ _educationalexperience4enddate=value;}
			get{return _educationalexperience4enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience4SchoolName
		{
			set{ _educationalexperience4schoolname=value;}
			get{return _educationalexperience4schoolname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience4Major
		{
			set{ _educationalexperience4major=value;}
			get{return _educationalexperience4major;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalExperience4Certificate
		{
			set{ _educationalexperience4certificate=value;}
			get{return _educationalexperience4certificate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyStatus1Name
		{
			set{ _familystatus1name=value;}
			get{return _familystatus1name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyStatus1Appellation
		{
			set{ _familystatus1appellation=value;}
			get{return _familystatus1appellation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyStatus1Company
		{
			set{ _familystatus1company=value;}
			get{return _familystatus1company;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyStatus1Tel
		{
			set{ _familystatus1tel=value;}
			get{return _familystatus1tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyStatus2Name
		{
			set{ _familystatus2name=value;}
			get{return _familystatus2name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyStatus2Appellation
		{
			set{ _familystatus2appellation=value;}
			get{return _familystatus2appellation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyStatus2Company
		{
			set{ _familystatus2company=value;}
			get{return _familystatus2company;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyStatus2Tel
		{
			set{ _familystatus2tel=value;}
			get{return _familystatus2tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmergencyContactName
		{
			set{ _emergencycontactname=value;}
			get{return _emergencycontactname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmergencyContactTel
		{
			set{ _emergencycontacttel=value;}
			get{return _emergencycontacttel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmergencyContactEelationShipWithMe
		{
			set{ _emergencycontacteelationshipwithme=value;}
			get{return _emergencycontacteelationshipwithme;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience1CompanyName
		{
			set{ _workexperience1companyname=value;}
			get{return _workexperience1companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience1Job
		{
			set{ _workexperience1job=value;}
			get{return _workexperience1job;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WorkExperience1StartDate
		{
			set{ _workexperience1startdate=value;}
			get{return _workexperience1startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WorkExperience1EndDate
		{
			set{ _workexperience1enddate=value;}
			get{return _workexperience1enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience1Pay
		{
			set{ _workexperience1pay=value;}
			get{return _workexperience1pay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience1LeavingReasons
		{
			set{ _workexperience1leavingreasons=value;}
			get{return _workexperience1leavingreasons;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience2CompanyName
		{
			set{ _workexperience2companyname=value;}
			get{return _workexperience2companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience2Job
		{
			set{ _workexperience2job=value;}
			get{return _workexperience2job;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WorkExperience2StartDate
		{
			set{ _workexperience2startdate=value;}
			get{return _workexperience2startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WorkExperience2EndDate
		{
			set{ _workexperience2enddate=value;}
			get{return _workexperience2enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience2Pay
		{
			set{ _workexperience2pay=value;}
			get{return _workexperience2pay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience2LeavingReasons
		{
			set{ _workexperience2leavingreasons=value;}
			get{return _workexperience2leavingreasons;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience3CompanyName
		{
			set{ _workexperience3companyname=value;}
			get{return _workexperience3companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience3Job
		{
			set{ _workexperience3job=value;}
			get{return _workexperience3job;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WorkExperience3StartDate
		{
			set{ _workexperience3startdate=value;}
			get{return _workexperience3startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WorkExperience3EndDate
		{
			set{ _workexperience3enddate=value;}
			get{return _workexperience3enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience3Pay
		{
			set{ _workexperience3pay=value;}
			get{return _workexperience3pay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience3LeavingReasons
		{
			set{ _workexperience3leavingreasons=value;}
			get{return _workexperience3leavingreasons;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience4CompanyName
		{
			set{ _workexperience4companyname=value;}
			get{return _workexperience4companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience4Job
		{
			set{ _workexperience4job=value;}
			get{return _workexperience4job;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WorkExperience4StartDate
		{
			set{ _workexperience4startdate=value;}
			get{return _workexperience4startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WorkExperience4EndDate
		{
			set{ _workexperience4enddate=value;}
			get{return _workexperience4enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience4Pay
		{
			set{ _workexperience4pay=value;}
			get{return _workexperience4pay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience4LeavingReasons
		{
			set{ _workexperience4leavingreasons=value;}
			get{return _workexperience4leavingreasons;}
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Organization_Id
		{
			set{ _organization_id=value;}
			get{return _organization_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SupervisorComments
		{
			set{ _supervisorcomments=value;}
			get{return _supervisorcomments;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProbationarySalary
		{
			set{ _probationarysalary=value;}
			get{return _probationarysalary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CorrectSalary
		{
			set{ _correctsalary=value;}
			get{return _correctsalary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkNumber
		{
			set{ _worknumber=value;}
			get{return _worknumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EntryDate
		{
			set{ _entrydate=value;}
			get{return _entrydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BirthCertificatePhoto
		{
			set{ _birthcertificatephoto=value;}
			get{return _birthcertificatephoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegistrationPhoto
		{
			set{ _registrationphoto=value;}
			get{return _registrationphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankCardNumber
		{
			set{ _bankcardnumber=value;}
			get{return _bankcardnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateStaffeId
		{
			set{ _createstaffeid=value;}
			get{return _createstaffeid;}
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
		public string NoN
		{
			set{ _non=value;}
			get{return _non;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StaffNo
		{
			set{ _staffno=value;}
			get{return _staffno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

