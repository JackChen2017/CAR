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
        #region �ֶ�
       private int _factoryID;
       #endregion
       
       
       #region ����
        public CARLogBLL(int factoryID) 
       {
           _factoryID = factoryID;          
       }
      #endregion

       #region ��LOG�����һ����¼
        /// <summary>
       /// ��LOG�����һ����¼
        /// </summary>
        /// <param name="info"></param>
        /// <returns>����0��ɹ�</returns>
       public int AddData(LogInfo info)
        {
            LogDAL dd = new LogDAL(_factoryID);
            return dd.AddLog(info);
        }
       #endregion

        #region ����LOG��һ����¼
        /// <summary>
        /// ����LOG��һ����¼
        /// </summary>
        /// <param name="info"></param>
        /// <returns>����0��ɹ�</returns>
        public int UpdateData(LogInfo info)
        {
            LogDAL dd = new LogDAL(_factoryID);
            return dd.UpdateLog(info);
        }
        #endregion

        #region ɾ��LOG��һ����¼
        /// <summary>
        ///  ɾ��LOG��һ����¼
        /// </summary>
        /// <param name="rkey">����</param>
        /// <returns>����0��ɹ�</returns>
        public int DelData(int rkey)
        {
            LogDAL dd = new LogDAL(_factoryID);
            return dd.DelLog(rkey);
        }
        #endregion

        #region ��
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
