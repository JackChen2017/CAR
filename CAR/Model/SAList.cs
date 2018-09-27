using System;
using System.Collections.Generic;
using System.Text;

namespace FounderTecInfoSys.Addin.CAR.Model
{
    /// <summary>
    /// 实体类 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SAList
    {
        public SAList()
        { }
        #region Model
        private int _rkey;
        private int _sn_ptr;
        private string _custCode;
        private string _custName;
        private DateTime? _recorddatetime;
        private string _foundermaterilno;
        private string _custpartno;
        private string _cyclevalue;
        private string _happenaddress;
        private string _lot;
        private string _et;
        private string _t;
        private string _reason;
        private string _mateialtype;
        private string _results;
        private decimal? _quantity;
        private DateTime? _signdate;
        private string _signingperson;
        private string _factoryname;
        private decimal? _discountprice;
        private decimal? _discountamount;
        /// <summary>
        /// 
        /// </summary>
        public int rkey
        {
            set { _rkey = value; }
            get { return _rkey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sn_ptr
        {
            set { _sn_ptr = value; }
            get { return _sn_ptr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string custCode
        {
            set { _custCode = value; }
            get { return _custCode; }
        }
        public string custName
        {
            set { _custName = value; }
            get { return _custName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? recordDateTime
        {
            set { _recorddatetime = value; }
            get { return _recorddatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string founderMaterilNo
        {
            set { _foundermaterilno = value; }
            get { return _foundermaterilno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string custPartNo
        {
            set { _custpartno = value; }
            get { return _custpartno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cycleValue
        {
            set { _cyclevalue = value; }
            get { return _cyclevalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string happenAddress
        {
            set { _happenaddress = value; }
            get { return _happenaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOT
        {
            set { _lot = value; }
            get { return _lot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ET
        {
            set { _et = value; }
            get { return _et; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string T
        {
            set { _t = value; }
            get { return _t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string reason
        {
            set { _reason = value; }
            get { return _reason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mateialType
        {
            set { _mateialtype = value; }
            get { return _mateialtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string results
        {
            set { _results = value; }
            get { return _results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? signDate
        {
            set { _signdate = value; }
            get { return _signdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string signingPerson
        {
            set { _signingperson = value; }
            get { return _signingperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string factoryName
        {
            set { _factoryname = value; }
            get { return _factoryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? discountPrice
        {
            set { _discountprice = value; }
            get { return _discountprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? discountAmount
        {
            set { _discountamount = value; }
            get { return _discountamount; }
        }
        #endregion Model

    }
}


