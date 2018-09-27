using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FounderTecInfoSys.Addin.CAR.DAL;
using FounderTecInfoSys.Addin.CAR.Model;

namespace FounderTecInfoSys.Addin.CAR.BLL
{
    public class SAListBLL
    {
        #region ×Ö¶Î
        private int _factoryID;
        #endregion

        #region ¹¹Ôì
        public SAListBLL(int factoryID) 
        {
            _factoryID = factoryID;          
        }
        #endregion

        public int Add(SAList model)
        {
            SAListDAL dd = new SAListDAL(_factoryID);
            return dd.Add(model);
        }

        public void Delete(int rkey)
        {
            SAListDAL dd = new SAListDAL(_factoryID);
            dd.Delete(rkey);
        }

        public void Update(SAList model)
        {
            SAListDAL dd = new SAListDAL(_factoryID);
            dd.Update(model);
        }

        public DataTable GetDataSet(string sql)
        {
            SAListDAL dd = new SAListDAL(_factoryID);
            return dd.GetDataSet(sql);
        }

        public void DeteleByKey(int did)
        {
            SAListDAL dd = new SAListDAL(_factoryID);
            dd.DeteteByKey(did);
        }
    }
}
