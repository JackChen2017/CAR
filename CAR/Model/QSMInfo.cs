using System;
using System.Collections.Generic;
using System.Text;

namespace FounderTecInfoSys.Addin.CAR.Model
{
    ///<summary>
    ///数据实体 [表名("Table_CAR_QSM")]
    /// </summary>
    [Serializable()]
    public class QSMInfo
    {
        /// <summary>
        ///  成员 
        /// </summary>
        private int? rkey;
        private string serialno = String.Empty;
        private DateTime? ent_date;
        private string ent_user = String.Empty;
        private string tousu_level = String.Empty;
        private string tousu_type = String.Empty;
        private string cust_code = String.Empty;
        private string cust_name = String.Empty;
        private string factory_name = String.Empty;
        private DateTime? happen_date;
        private string cust_materialno = String.Empty;
        private string interalno = String.Empty;
        private DateTime? require_date;
        private string car_content = String.Empty;
        private decimal? chuhuo_qty;
        private decimal? jiancha_qty;
        private decimal? buliang_qty;
        private decimal? buliangbili;
        private string buliangdc;
        private decimal? zaixian_qty;
        private decimal? kucun_qty;
        private int? tuihuo_status;
        private decimal? tuihuo_qty;
        private int? happen_address;
        private int? tijiao_status;
        private int? tijiao_type;
        private string notes = String.Empty;
        private decimal? dcjiaohuo_qty;
        private int? zaitu_status;
        private decimal? zaitu_qty;
        private int? zaituchuli_type;
        private int? cangcun_status;
        private int? cangcunchuli_type;
        private string info_content = String.Empty;
        private DateTime? first_reply_date;
        private DateTime? last_reply_date;
        private string conf_content = String.Empty;
        private DateTime? close_date;
        private int? status;


        ///<summary>
        ///  构造方法
        ///</summary>
        public QSMInfo() { }


        ///<summary>
        ///主键 [字段("RKEY")]
        ///数据库类型:int?
        ///</summary>

        public int? RKEY
        {
            get { return this.rkey; }
            set { this.rkey = value; }
        }




        ///<summary>
        ///属性 [("serialNo")]
        ///数据库类型:nvarchar(20)
        ///</summary>
        public string SERIALNO
        {
            get { return this.serialno; }
            set { this.serialno = value; }
        }

        ///<summary>
        ///属性 [("ent_Date")]
        ///数据库类型:DateTime?(8)
        ///</summary>
        public DateTime? ENT_DATE
        {
            get { return this.ent_date; }
            set { this.ent_date = value; }
        }

        ///<summary>
        ///属性 [("ent_user")]
        ///数据库类型:varchar(50)
        ///</summary>
        public string ENT_USER
        {
            get { return this.ent_user; }
            set { this.ent_user = value; }
        }

        ///<summary>
        ///属性 [("tousu_level")]
        ///数据库类型:varchar(20)
        ///</summary>
        public string TOUSU_LEVEL
        {
            get { return this.tousu_level; }
            set { this.tousu_level = value; }
        }

        ///<summary>
        ///属性 [("tousu_type")]
        ///数据库类型:varchar(20)
        ///</summary>
        public string TOUSU_TYPE
        {
            get { return this.tousu_type; }
            set { this.tousu_type = value; }
        }

        ///<summary>
        ///属性 [("cust_Code")]
        ///数据库类型:nvarchar(20)
        ///</summary>
        public string CUST_CODE
        {
            get { return this.cust_code; }
            set { this.cust_code = value; }
        }

        ///<summary>
        ///属性 [("cust_Name")]
        ///数据库类型:nvarchar(100)
        ///</summary>
        public string CUST_NAME
        {
            get { return this.cust_name; }
            set { this.cust_name = value; }
        }

        ///<summary>
        ///属性 [("factory_Name")]
        ///数据库类型:nvarchar(20)
        ///</summary>
        public string FACTORY_NAME
        {
            get { return this.factory_name; }
            set { this.factory_name = value; }
        }

        ///<summary>
        ///属性 [("happen_Date")]
        ///数据库类型:DateTime?(8)
        ///</summary>
        public DateTime? HAPPEN_DATE
        {
            get { return this.happen_date; }
            set { this.happen_date = value; }
        }

        ///<summary>
        ///属性 [("cust_MaterialNo")]
        ///数据库类型:nvarchar(200)
        ///</summary>
        public string CUST_MATERIALNO
        {
            get { return this.cust_materialno; }
            set { this.cust_materialno = value; }
        }

        ///<summary>
        ///属性 [("int?eralNo")]
        ///数据库类型:nvarchar(50)
        ///</summary>
        public string INTERALNO
        {
            get { return this.interalno; }
            set { this.interalno = value; }
        }

        ///<summary>
        ///属性 [("require_Date")]
        ///数据库类型:DateTime?(8)
        ///</summary>
        public DateTime? REQUIRE_DATE
        {
            get { return this.require_date; }
            set { this.require_date = value; }
        }

        ///<summary>
        ///属性 [("CAR_Content")]
        ///数据库类型:varchar(8000)
        ///</summary>
        public string CAR_CONTENT
        {
            get { return this.car_content; }
            set { this.car_content = value; }
        }

        ///<summary>
        ///属性 [("chuhuo_qty")]
        ///数据库类型:numeric(12, 0)
        ///</summary>
        public decimal? CHUHUO_QTY
        {
            get { return this.chuhuo_qty; }
            set { this.chuhuo_qty = value; }
        }

        ///<summary>
        ///属性 [("jiancha_qty")]
        ///数据库类型:numeric(12, 0)
        ///</summary>
        public decimal? JIANCHA_QTY
        {
            get { return this.jiancha_qty; }
            set { this.jiancha_qty = value; }
        }

        ///<summary>
        ///属性 [("buliang_qty")]
        ///数据库类型:numeric(12, 0)
        ///</summary>
        public decimal? BULIANG_QTY
        {
            get { return this.buliang_qty; }
            set { this.buliang_qty = value; }
        }

        ///<summary>
        ///属性 [("buliangbili")]
        ///数据库类型:numeric(5, 2)
        ///</summary>
        public decimal? BULIANGBILI
        {
            get { return this.buliangbili; }
            set { this.buliangbili = value; }
        }

        ///<summary>
        ///属性 [("buliangDC")]
        ///数据库类型:varchar(50)
        ///</summary>
        public string BULIANGDC
        {
            get { return this.buliangdc; }
            set { this.buliangdc= value; }
        }

        ///<summary>
        ///属性 [("zaixian_qty")]
        ///数据库类型:numeric(12, 0)
        ///</summary>
        public decimal? ZAIXIAN_QTY
        {
            get { return this.zaixian_qty; }
            set { this.zaixian_qty = value; }
        }

        ///<summary>
        ///属性 [("kucun_qty")]
        ///数据库类型:numeric(12, 0)
        ///</summary>
        public decimal? KUCUN_QTY
        {
            get { return this.kucun_qty; }
            set { this.kucun_qty = value; }
        }

        ///<summary>
        ///属性 [("tuihuo_status")]
        ///数据库类型:int?
        ///</summary>
        public int? TUIHUO_STATUS
        {
            get { return this.tuihuo_status; }
            set { this.tuihuo_status = value; }
        }

        ///<summary>
        ///属性 [("tuihuo_qty")]
        ///数据库类型:numeric(12, 0)
        ///</summary>
        public decimal? TUIHUO_QTY
        {
            get { return this.tuihuo_qty; }
            set { this.tuihuo_qty = value; }
        }

        ///<summary>
        ///属性 [("happen_address")]
        ///数据库类型:int?
        ///</summary>
        public int? HAPPEN_ADDRESS
        {
            get { return this.happen_address; }
            set { this.happen_address = value; }
        }

        ///<summary>
        ///属性 [("tijiao_status")]
        ///数据库类型:int?
        ///</summary>
        public int? TIJIAO_STATUS
        {
            get { return this.tijiao_status; }
            set { this.tijiao_status = value; }
        }

        ///<summary>
        ///属性 [("tijiao_type")]
        ///数据库类型:int?
        ///</summary>
        public int? TIJIAO_TYPE
        {
            get { return this.tijiao_type; }
            set { this.tijiao_type = value; }
        }

        ///<summary>
        ///属性 [("notes")]
        ///数据库类型:varchar(8000)
        ///</summary>
        public string NOTES
        {
            get { return this.notes; }
            set { this.notes = value; }
        }

        ///<summary>
        ///属性 [("dcjiaohuo_qty")]
        ///数据库类型:numeric(12, 0)
        ///</summary>
        public decimal? DCJIAOHUO_QTY
        {
            get { return this.dcjiaohuo_qty; }
            set { this.dcjiaohuo_qty = value; }
        }

        ///<summary>
        ///属性 [("zaitu_status")]
        ///数据库类型:int?
        ///</summary>
        public int? ZAITU_STATUS
        {
            get { return this.zaitu_status; }
            set { this.zaitu_status = value; }
        }

        ///<summary>
        ///属性 [("zaitu_qty")]
        ///数据库类型:numeric(12, 0)
        ///</summary>
        public decimal? ZAITU_QTY
        {
            get { return this.zaitu_qty; }
            set { this.zaitu_qty = value; }
        }

        ///<summary>
        ///属性 [("zaituchuli_type")]
        ///数据库类型:int?
        ///</summary>
        public int? ZAITUCHULI_TYPE
        {
            get { return this.zaituchuli_type; }
            set { this.zaituchuli_type = value; }
        }

        ///<summary>
        ///属性 [("cangcun_status")]
        ///数据库类型:int?
        ///</summary>
        public int? CANGCUN_STATUS
        {
            get { return this.cangcun_status; }
            set { this.cangcun_status = value; }
        }

        ///<summary>
        ///属性 [("cangcunchuli_type")]
        ///数据库类型:int?
        ///</summary>
        public int? CANGCUNCHULI_TYPE
        {
            get { return this.cangcunchuli_type; }
            set { this.cangcunchuli_type = value; }
        }

        ///<summary>
        ///属性 [("info_content")]
        ///数据库类型:varchar(8000)
        ///</summary>
        public string INFO_CONTENT
        {
            get { return this.info_content; }
            set { this.info_content = value; }
        }

        ///<summary>
        ///属性 [("first_reply_date")]
        ///数据库类型:DateTime?(8)
        ///</summary>
        public DateTime? FIRST_REPLY_DATE
        {
            get { return this.first_reply_date; }
            set { this.first_reply_date = value; }
        }

        ///<summary>
        ///属性 [("last_reply_date")]
        ///数据库类型:DateTime?(8)
        ///</summary>
        public DateTime? LAST_REPLY_DATE
        {
            get { return this.last_reply_date; }
            set { this.last_reply_date = value; }
        }

        ///<summary>
        ///属性 [("conf_content")]
        ///数据库类型:varchar(8000)
        ///</summary>
        public string CONF_CONTENT
        {
            get { return this.conf_content; }
            set { this.conf_content = value; }
        }

        ///<summary>
        ///属性 [("clost_date")]
        ///数据库类型:DateTime?(8)
        ///</summary>
        public DateTime? CLOSE_DATE
        {
            get { return this.close_date; }
            set { this.close_date = value; }
        }

        ///<summary>
        ///属性 [("status")]
        ///数据库类型:int?
        ///</summary>
        public int? STATUS
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }
}
