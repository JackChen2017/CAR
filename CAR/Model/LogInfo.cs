using System;
using System.Collections.Generic;
using System.Text;

namespace FounderTecInfoSys.Addin.CAR.Model
{
    [Serializable]
    public class LogInfo
    {
        #region ×Ö¶Î
        private int? _rkey;
        private int? _sn_ptr;
        private string _sn_type;
        private int? _sp_total_step;
        private DateTime? _sp_start_date;
        private DateTime? _sp_end_date;
        private int? _sp_type;
        private int? _sp_step;
        private string _sp_user;
        private string _sp_content;
        private int? _status;
        #endregion

        #region ÉèÖÃÊôĞÔ
        
        public int? rkey
        {
            get { return _rkey; }
            set { _rkey = value; }
        }            
        public int? sn_ptr
        {
            get { return _sn_ptr; }
            set { _sn_ptr = value; }
        }
        public string sn_type
        {
            get { return _sn_type; }
            set { _sn_type = value; }
        }
        public int? sp_total_step
        {
            get { return _sp_total_step; }
            set { _sp_total_step = value; }
        }
        public DateTime? sp_start_date
        {
            get { return _sp_start_date; }
            set { _sp_start_date = value; }
        }
        public DateTime? sp_end_date
        {
            get { return _sp_end_date; }
            set { _sp_end_date = value; }
        }
        public int? sp_type
        {
            get { return _sp_type; }
            set { _sp_type = value; }
        }
        public int? sp_step
        {
            get { return _sp_step; }
            set { _sp_step = value; }
        }
        public string sp_user
        {
            get { return _sp_user; }
            set { _sp_user = value; }
        }
        public string sp_content
        {
            get { return _sp_content; }
            set { _sp_content = value; }
        }
        public int? status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion
    }
}
