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
        #region �ֶ�
       private int _factoryID;
       #endregion
       
       
       #region ����
        public CARDataBLL(int factoryID) 
       {
           _factoryID = factoryID;          
       }
      #endregion

       #region ��DATA01�������һ����¼
        /// <summary>
       /// ��DATA01�������һ����¼
        /// </summary>
        /// <param name="info"></param>
        /// <returns>����0��ɹ�</returns>
       public int AddData(DataInfo info)
        {
            DataDAL dd = new DataDAL(_factoryID);
            return dd.AddData(info);
        }
       #endregion

        #region ����DATA01����һ����¼
        /// <summary>
        /// ����DATA01����һ����¼
        /// </summary>
        /// <param name="info"></param>
        /// <returns>����0��ɹ�</returns>
        public int UpdateData(DataInfo info)
        {
            DataDAL dd = new DataDAL(_factoryID);
            return dd.UpdateData(info);
        }
        #endregion

        #region ɾ��DATA01����һ����¼
        /// <summary>
        ///  ɾ��DATA01����һ����¼
        /// </summary>
        /// <param name="rkey">����</param>
        /// <returns>����0��ɹ�</returns>
        public int DelData(int rkey)
        {
            DataDAL dd = new DataDAL(_factoryID);
            return dd.DelData(rkey);
        }
        #endregion

        #region ��
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
