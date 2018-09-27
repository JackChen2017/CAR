using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FounderTecInfoSys.Addin.CAR.DAL;
using FounderTecInfoSys.Addin.CAR.Model;

namespace FounderTecInfoSys.Addin.CAR.BLL
{
    public class CARLogBLL
    {
        #region 字段
       private int _factoryID;
       #endregion
       
       
       #region 构造
        public CARLogBLL(int factoryID) 
       {
           _factoryID = factoryID;          
       }
      #endregion

       #region 向LOG表插入一条记录
        /// <summary>
       /// 向LOG表插入一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回0则成功</returns>
       public int AddData(LogInfo info)
        {
            LogDAL dd = new LogDAL(_factoryID);
            return dd.AddLog(info);
        }
       #endregion

        #region 更新LOG表一条记录
        /// <summary>
        /// 更新LOG表一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回0则成功</returns>
        public int UpdateData(LogInfo info)
        {
            LogDAL dd = new LogDAL(_factoryID);
            return dd.UpdateLog(info);
        }
        #endregion

        #region 删除LOG表一条记录
        /// <summary>
        ///  删除LOG表一条记录
        /// </summary>
        /// <param name="rkey">主键</param>
        /// <returns>返回0则成功</returns>
        public int DelData(int rkey)
        {
            LogDAL dd = new LogDAL(_factoryID);
            return dd.DelLog(rkey);
        }
        #endregion

        #region 查
        public LogInfo GetByKey(int rkey)
        {
            LogDAL dd = new LogDAL(_factoryID);
            return dd.GetByKey(rkey);
        }

        public DataTable GetDataSet(string sql)
        {
            LogDAL dd = new LogDAL(_factoryID);
            return dd.GetDataSet(sql);
        }
        public void DeleteByKey(int did,string sn_ptr)
        {
            LogDAL dd = new LogDAL(_factoryID);
            dd.DeleteByKey(did,sn_ptr);
        }
        #endregion
    }
}
