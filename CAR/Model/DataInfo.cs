using System;
using System.Collections.Generic;
using System.Text;
namespace FounderTecInfoSys.Addin.CAR.Model
{
    [Serializable]
    public class DataInfo
    {
        #region ◊÷∂Œ
        private int? _rkey;//1
        private string _serial_no;//2
        private decimal? _factoryid;
        private string _factoryname;
        private string _factorytype;
        private string _custname;
        private string _custtype;
        private decimal? _fahuo_quan;
        private decimal? _jiancha_quan;
        private decimal? _badness_bi;
        private string _badness_dc;
        private decimal? _zaixian_quan;
        private decimal? _kuchun_quan;
        private int? _tuihuo_status;
        private decimal? _tuihuo_quan;
        private decimal? _kuhuhappen_address;
        private decimal? _tijiao_status;
        private decimal? _tijiao_type;
        private decimal? _dc_quan;
        private decimal? _zaitu_status;
        private decimal? _zaitu_quan;
        private decimal? _chuli_status;
        private decimal? _changleikuchun_status;
        private decimal? _chuli_type;
        private DateTime? _happen_date;//3
        private DateTime? _required_date;//4
        private DateTime? _conf_date;//5
        private DateTime? _issued_date;
        private string _from_comp;
        private string _car_comp;
        private string _issued_user;
        private string _issued_app;
        private string _issued_mg;
        private string _received_user;
        private string _hsf_happen_type;
        private string _car_part_num;
        private string _car_content;
        private string _lot;
        private float? _batch;
        private float? _sample;
        private float? _badness_num;
        private float? _rework;
        private float? _reject;
        private float? _nowork;
        private int? _info_type_1;
        private int? _info_type_2;
        private int? _info_type_3;
        private int? _info_type_4;
        private int? _info_type_5;
        private string _info_content;
        private string _interim_action;
        private DateTime? _ia_date;//30
        private string _corrective_action;
        private DateTime? _ca_date;
        private string _ipca;
        private DateTime? _ipca_date;
        private string _atpr;
        private DateTime? _atpr_date;
        private string _z_user;
        private string _z_app;
        private string _z_mg;
        private string _levels;//40
        private string _together_write;//41
        private int? _sop_status;//42
        private string _sop_name;//43
        private string _sop_content;//44
        private string _sop_user;//45
        private DateTime? _sop_date;
        private int? _conf_status;
        private string _conf_content;
        private DateTime? _pre_date;//49
        private DateTime? _end_date;//50
        private string _conf_user;//51
        private DateTime? _conf_user_date;//52
        private string _conf_app;//53
        private DateTime? _conf_app_date;//54
        private string _conf_mg;//55
        private DateTime? _conf_mg_date;//56
        private string _comp_mg;//57
        private string _other_together_write;//58
        private int? _op_type;//59
        private int? _status;//60
        private string _nowuser;
        private DateTime? _ReqReplyDate;
        private string _Happen_Address;
        private string _CycleValue;
        private DateTime? _ReceiveDate;
        private string _ReceiveUser;
        private string _ReqSolution;
        private string _ReqTimeLimit;
        private float? _ShadinessQty;
        private string _ia_app;
        private string _ia_user;
        private string _ipca_app;
        private string _ipca_user;
        private DateTime? _info_date;
        #endregion

        #region …Ë÷√ Ù–‘
        public int? rkey
        {
            get { return _rkey; }
            set { _rkey = value; }
        }                 
        public string serial_no
        {
            get { return _serial_no; }
            set { _serial_no = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FactoryID
        {
            set { _factoryid = value; }
            get { return _factoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FactoryName
        {
            set { _factoryname = value; }
            get { return _factoryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FactoryType
        {
            set { _factorytype = value; }
            get { return _factorytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustName
        {
            set { _custname = value; }
            get { return _custname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustType
        {
            set { _custtype = value; }
            get { return _custtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Fahuo_Quan
        {
            set { _fahuo_quan = value; }
            get { return _fahuo_quan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? JianCha_Quan
        {
            set { _jiancha_quan = value; }
            get { return _jiancha_quan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? badness_bi
        {
            set { _badness_bi = value; }
            get { return _badness_bi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string badness_DC
        {
            set { _badness_dc = value; }
            get { return _badness_dc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? zaixian_quan
        {
            set { _zaixian_quan = value; }
            get { return _zaixian_quan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? kuchun_quan
        {
            set { _kuchun_quan = value; }
            get { return _kuchun_quan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tuihuo_status
        {
            set { _tuihuo_status = value; }
            get { return _tuihuo_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? tuihuo_quan
        {
            set { _tuihuo_quan = value; }
            get { return _tuihuo_quan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? kuhuhappen_address
        {
            set { _kuhuhappen_address = value; }
            get { return _kuhuhappen_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? tijiao_status
        {
            set { _tijiao_status = value; }
            get { return _tijiao_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? tijiao_type
        {
            set { _tijiao_type = value; }
            get { return _tijiao_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DC_quan
        {
            set { _dc_quan = value; }
            get { return _dc_quan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? zaitu_status
        {
            set { _zaitu_status = value; }
            get { return _zaitu_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? zaitu_quan
        {
            set { _zaitu_quan = value; }
            get { return _zaitu_quan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? chuli_status
        {
            set { _chuli_status = value; }
            get { return _chuli_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? changleikuchun_status
        {
            set { _changleikuchun_status = value; }
            get { return _changleikuchun_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? chuli_type
        {
            set { _chuli_type = value; }
            get { return _chuli_type; }
        }
        public DateTime? happen_date
        {
            get { return _happen_date; }
            set { _happen_date = value; }

        }
        public DateTime? required_date
        {
            get { return _required_date; }
            set { _required_date = value; }
        }
        public DateTime? conf_date
        {
            get { return _conf_date; }
            set { _conf_date = value; }
        }
        public DateTime? issued_date
        {
            get { return _issued_date; }
            set { _issued_date = value; }
        }
        public string from_comp
        {
            get { return _from_comp; }
            set { _from_comp = value; }
        }
        public string car_comp
        {
            get { return _car_comp; }
            set { _car_comp = value; }
        }
        public string issued_user
        {
            get { return _issued_user; }
            set { _issued_user = value; }
        }
        public string issued_app
        {
            get { return _issued_app; }
            set { _issued_app = value; }
        }
        public string issued_mg
        {
            get { return _issued_mg; }
            set { _issued_mg = value; }
        }
        public string received_user
        {
            get { return _received_user; }
            set { _received_user = value; }
        }
        public string hsf_happen_type
        {
            get { return _hsf_happen_type; }
            set { _hsf_happen_type = value; }
        }
        public string car_part_num
        {
            get { return _car_part_num; }
            set { _car_part_num = value; }
        }
        public string car_content
        {
            get { return _car_content; }
            set { _car_content = value; }
        }
        public string lot
        {
            get { return _lot; }
            set { _lot = value; }
        }
        public float? batch
        {
            get { return _batch; }
            set { _batch = value; }
        }
        public float? sample
        {
            get { return _sample; }
            set { _sample = value; }
        }
        public float? badness_num
        {
            get { return _badness_num; }
            set { _badness_num = value; }
        }
        public float? rework
        {
            get { return _rework; }
            set { _rework = value; }
        }
        public float? reject
        {
            get { return _reject; }
            set { _reject = value; }
        }
        public float? nowork
        {
            get { return _nowork; }
            set { _nowork = value; }
        }
        public int? info_type_1
        {
            get { return _info_type_1; }
            set { _info_type_1 = value; }
        }
        public int? info_type_2
        {
            get { return _info_type_2; }
            set { _info_type_2 = value; }
        }
        public int? info_type_3
        {
            get { return _info_type_3; }
            set { _info_type_3 = value; }
        }
        public int? info_type_4
        {
            get { return _info_type_4; }
            set { _info_type_4 = value; }
        }
        public int? info_type_5
        {
            get { return _info_type_5; }
            set { _info_type_5 = value; }
        }
        public string info_content
        {
            get { return _info_content; }
            set { _info_content = value; }
        }
        public string interim_action
        {
            get { return _interim_action; }
            set { _interim_action = value; }
        }
        public DateTime? ia_date //30
        {
            get { return _ia_date; }
            set { _ia_date = value; }
        }
        public string corrective_action
        {
            get { return _corrective_action; }
            set { _corrective_action = value; }
        }
        public DateTime? ca_date
        {
            get { return _ca_date; }
            set { _ca_date = value; }
        }
        public string ipca
        {
            get { return _ipca; }
            set { _ipca = value; }
        }
        public DateTime? ipca_date
        {
            get { return _ipca_date; }
            set { _ipca_date = value; }
        }
        public string atpr
        {
            get { return _atpr; }
            set { _atpr = value; }
        }
        public DateTime? atpr_date
        {
            get { return _atpr_date; }
            set { _atpr_date = value; }
        }
        public string z_user
        {
            get { return _z_user; }
            set { _z_user = value; }
        }
        public string z_app
        {
            get { return _z_app; }
            set { _z_app = value; }
        }
        public string z_mg
        {
            get { return _z_mg; }
            set { _z_mg = value; }
        }
        public string levels
        {
            get { return _levels; }
            set { _levels = value; }
        }//40
        public string together_write
        {
            get { return _together_write; }
            set { _together_write = value; }
        }//41
        public int? sop_status
        {
            get { return _sop_status; }
            set { _sop_status = value; }
        }//42
        public string sop_name
        {
            get { return _sop_name; }
            set { _sop_name = value; }
        }//43
        public string sop_content
        {
            get { return _sop_content; }
            set { _sop_content = value; }
        }//44
        public string sop_user
        {
            get { return _sop_user; }
            set { _sop_user = value; }
        }
        public DateTime? sop_date
        {
            get { return _sop_date; }
            set { _sop_date = value; }
        }
        public int? conf_status
        {
            get { return _conf_status; }
            set { _conf_status = value; }
        }
        public string conf_content
        {
            get { return _conf_content; }
            set { _conf_content = value; }
        }
        public DateTime? pre_date
        {
            get { return _pre_date; }
            set { _pre_date = value; }
        }//49
        public DateTime? end_date
        {
            get { return _end_date; }
            set { _end_date = value; }
        }//50
        public string conf_user
        {
            get { return _conf_user; }
            set { _conf_user = value; }
        }//51
        public DateTime? conf_user_date
        {
            get { return _conf_user_date; }
            set { _conf_user_date = value; }
        }//52
        public string conf_app
        {
            get { return _conf_app; }
            set { _conf_app = value; }
        }//53
        public DateTime? conf_app_date
        {
            get { return _conf_app_date; }
            set { _conf_app_date = value; }
        }//54
        public string conf_mg
        {
            get { return _conf_mg; }
            set { _conf_mg = value; }
        }//55
        public DateTime? conf_mg_date//56
        {
            get { return _conf_mg_date; }
            set { _conf_mg_date = value; }
        }
        public string comp_mg//57
        {
            get { return _comp_mg; }
            set { _comp_mg = value; }
        }
        public string other_together_write
        {
            get { return _other_together_write; }
            set { _other_together_write = value; }
        }//58
        public int? op_type
        {
            get { return _op_type; }
            set { _op_type = value; }
        }//59
        public int? status
        {
            get { return _status; }
            set { _status = value; }
        }//60
        public string nowuser
        {
            get { return _nowuser; }
            set { _nowuser = value; }
        }//61
        public DateTime? ReqReplyDate
        {
            get { return _ReqReplyDate; }
            set { _ReqReplyDate = value; }
        }
        public string Happen_Address
        {
            get { return _Happen_Address; }
            set { _Happen_Address = value; }
        }
        public string CycleValue
        {
            get { return _CycleValue; }
            set { _CycleValue = value; }
        }
        public DateTime? ReceiveDate
        {
            get { return _ReceiveDate; }
            set { _ReceiveDate = value; }
        }
        public string ReceiveUser
        {
            get { return _ReceiveUser; }
            set { _ReceiveUser = value; }
        }       
        public string ReqSolution
        {
            get { return _ReqSolution; }
            set { _ReqSolution = value; }
        }
        public string ReqTimeLimit
        {
            get { return _ReqTimeLimit; }
            set { _ReqTimeLimit = value; }
        }
        public float? ShadinessQty
        {
            get { return _ShadinessQty; }
            set { _ShadinessQty = value; }
        }
        public string IA_APP
        {
            get { return _ia_app; }
            set { _ia_app = value; }
        }
        public string IA_USER
        {
            get { return _ia_user; }
            set { _ia_user = value; }
        }
        public string IPCA_APP
        {
            get { return _ipca_app; }
            set { _ipca_app = value; }
        }
        public string IPCA_USER
        {
            get { return _ipca_user; }
            set { _ipca_user = value; }
        }
        public DateTime? Info_Date
        {
            get { return _info_date; }
            set { _info_date = value; }
        }
        #endregion
    }

    
}
