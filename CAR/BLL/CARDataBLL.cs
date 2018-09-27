using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FounderTecInfoSys.Addin.CAR.DAL;
using FounderTecInfoSys.Addin.CAR.Model;

namespace FounderTecInfoSys.Addin.CAR.BLL
{
    public class CARDataBLL
    {
        #region 字段
       private int _factoryID;
       #endregion
       
       
       #region 构造
        public CARDataBLL(int factoryID) 
       {
           _factoryID = factoryID;          
       }
      #endregion

       #region 向DATA01主表插入一条记录
        /// <summary>
       /// 向DATA01主表插入一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回0则成功</returns>
       public int AddData(DataInfo info)
        {
            DataDAL dd = new DataDAL(_factoryID);
            return dd.AddData(info);
        }
       #endregion

        #region 更新DATA01主表一条记录
        /// <summary>
        /// 更新DATA01主表一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回0则成功</returns>
        public int UpdateData(DataInfo info)
        {
            DataDAL dd = new DataDAL(_factoryID);
            return dd.UpdateData(info);
        }
        #endregion

        #region 删除DATA01主表一条记录
        /// <summary>
        ///  删除DATA01主表一条记录
        /// </summary>
        /// <param name="rkey">主键</param>
        /// <returns>返回0则成功</returns>
        public int DelData(int rkey)
        {
            DataDAL dd = new DataDAL(_factoryID);
            return dd.DelData(rkey);
        }
        #endregion

        #region 查
        public DataInfo GetByKey(int rkey)
        {
            DataDAL dd = new DataDAL(_factoryID);
            return dd.GetByKey(rkey);
        }

        public DataTable GetDataSet(string sql)
        {
            DataDAL dd = new DataDAL(_factoryID);
            return dd.GetDataSet(sql);
        }
        #endregion

        public string getSerialNo(string type)
        {
            DataDAL dd = new DataDAL(_factoryID);
            return dd.getSerialNo(type);
        }
    }
}
