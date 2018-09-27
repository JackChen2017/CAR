using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Addin.CAR.DAL;

namespace FounderTecInfoSys.Addin.CAR.BLL
{
    /// <summary>
    /// ҵ���  Table_CAR_SABLL
    /// </summary>
    public class SABLL
    {
        SADAL saDal = null;

        #region ----------���캯��----------
        /// <summary>
        /// ���캯��
        /// </summary>
        public SABLL(int factoryID)
        {
            saDal = new SADAL(factoryID);
        }

        #endregion

        #region ----------��������----------
        #region ��Ӹ���ɾ��
        /// <summary>
        /// �����ݿ��в���һ���¼�¼��
        /// </summary>
        /// <param name="Table_CAR_SA">table_car_sa����</param>
        /// <returns>�²����¼�ı��</returns>
        public int add(SAInfo sa)
        {
            // Validate input
            if (sa == null)
                return 0;

            return saDal.Add(sa);
        }

        /// <summary>
        /// �����ݱ�Table_CAR_SA����һ����¼��
        /// </summary>
        /// <param name="oTable_CAR_SAInfo">Table_CAR_SA</param>
        /// <returns>Ӱ�������</returns>
        public int Update(SAInfo sa)
        {
            // Validate input
            if (sa == null)
                return 0;

            return saDal.Update(sa);
        }


        /// <summary>
        /// ɾ�����ݱ�Table_CAR_SA�е�һ����¼
        /// </summary>
        /// <param name="rkey">rkey</param>
        /// <returns>Ӱ�������</returns>
        public int DeleteByrkey(int rkey)
        {
            // Validate input
            if (rkey < 0)
                return 0;
            //return Table_CAR_SADAL.Delete(rkey);
            return saDal.DeleteByrkey(rkey);
        }

        #endregion

        #region ��ѯ
        /// <summary>
        /// �õ� table_car_sa ����ʵ��
        /// </summary>
        /// <param name="rkey">rkey</param>
        /// <returns>table_car_sa ����ʵ��</returns>
        public SAInfo getSAInfoByrkey(int rkey)
        {
            // Validate input
            if (rkey < 0)
                return null;

            // Use the dal to get a record 

            return saDal.GetSAInfoByrkey(rkey);
        }

        /// <summary>
        /// �õ����ݱ�Table_CAR_SA���м�¼
        /// </summary>
        /// <returns>ʵ�弯</returns>
        public IList<SAInfo> FindAllSAInfo()
        {
            // Use the dal to get all records 

            return saDal.FindAllSAInfo();
        }

        ///<summary>
        ///
        ///</summary>

        public IList<SAInfo> FindBySql(string sqlWhere)
        {

            return saDal.FindBySql(sqlWhere);
        }

        public DataTable getDataSet(string sql)
        {

            return saDal.getDataSet(sql);
        }

        public string GetSerialNo()
        {
            return saDal.GetSerialNo();
        }
        #endregion

        #endregion
    }
}

