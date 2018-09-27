using System;
using System.Collections.Generic;
using System.Text;

namespace FounderTecInfoSys.Addin.CAR.Model
{
    ///<summary>
    ///����ʵ�� [����("Table_CAR_SA")]
    /// </summary>
    [Serializable()]
    public class SAInfo
    {
        /// <summary>
        ///  ��Ա 
        /// </summary>
        private int? rkey;
        private string serialno = String.Empty;
        private DateTime? ent_date;
        private string ent_user = String.Empty;
        private string car_content = String.Empty;
        private DateTime? close_date;
        private int? status;


        ///<summary>
        ///  ���췽��
        ///</summary>
        public SAInfo() { }


        ///<summary>
        ///���� [�ֶ�("RKEY")]
        ///���ݿ�����:int
        ///</summary>

        public int? RKEY
        {
            get { return this.rkey; }
            set { this.rkey = value; }
        }




        ///<summary>
        ///���� [("serialNo")]
        ///���ݿ�����:varchar(20)
        ///</summary>
        public string SERIALNO
        {
            get { return this.serialno; }
            set { this.serialno = value; }
        }

        ///<summary>
        ///���� [("ent_date")]
        ///���ݿ�����:datetime(8)
        ///</summary>
        public DateTime? ENT_DATE
        {
            get { return this.ent_date; }
            set { this.ent_date = value; }
        }

        ///<summary>
        ///���� [("ent_user")]
        ///���ݿ�����:varchar(50)
        ///</summary>
        public string ENT_USER
        {
            get { return this.ent_user; }
            set { this.ent_user = value; }
        }

        ///<summary>
        ///���� [("car_content")]
        ///���ݿ�����:varchar(8000)
        ///</summary>
        public string CAR_CONTENT
        {
            get { return this.car_content; }
            set { this.car_content = value; }
        }

        ///<summary>
        ///���� [("close_date")]
        ///���ݿ�����:datetime(8)
        ///</summary>
        public DateTime? CLOSE_DATE
        {
            get { return this.close_date; }
            set { this.close_date = value; }
        }

        public int? STATUS
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }
}