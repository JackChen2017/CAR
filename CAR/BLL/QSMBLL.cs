using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Addin.CAR.DAL;

namespace FounderTecInfoSys.Addin.CAR.BLL
{
    /// <summary>
    /// ҵ���  QSMBLL
    /// </summary>
    public class QSMBLL
    {
        QSMDAL qsmDal = null;

        #region ----------���캯��----------
        /// <summary>
        /// ���캯��
        /// </summary>
        public QSMBLL(int factoryID)
        {
            qsmDal = new QSMDAL(factoryID);
        }

        #endregion

        #region ----------��������----------
        #region ��Ӹ���ɾ��
        /// <summary>
        /// �����ݿ��в���һ���¼�¼��
        /// </summary>
        /// <param name="Table_CAR_QSM">qsminfo����</param>
        /// <returns>�²����¼�ı��</returns>
        public int add(QSMInfo qsminfo)
        {
            // Validate input
            if (qsminfo == null)
                return 0;

            return qsmDal.Add(qsminfo);
        }

        /// <summary>
        /// �����ݱ�Table_CAR_QSM����һ����¼��
        /// </summary>
        /// <param name="QSMDAL">Table_CAR_QSM</param>
        /// <returns>Ӱ�������</returns>
        public int Update(QSMInfo qsminfo)
        {
            // Validate input
            if (qsminfo == null)
                return 0;

            return qsmDal.Update(qsminfo);
        }


        /// <summary>
        /// ɾ�����ݱ�Table_CAR_QSM�е�һ����¼
        /// </summary>
        /// <param name="rkey">rkey</param>
        /// <returns>Ӱ�������</returns>
        public int DeleteByrkey(int rkey)
        {
            // Validate input
            if (rkey < 0)
                return 0;
            //return Table_CAR_QSMDAL.Delete(rkey);
            return qsmDal.DeleteByrkey(rkey);
        }

        #endregion

        #region ��ѯ
        /// <summary>
        /// �õ� qsminfo ����ʵ��
        /// </summary>
        /// <param name="rkey">rkey</param>
        /// <returns>qsminfo ����ʵ��</returns>
        public QSMInfo getQSMInfoByrkey(int rkey)
        {
            // Validate input
            if (rkey < 0)
                return null;

            // Use the dal to get a record 

            return qsmDal.getQSMInfoByrkey(rkey);
        }

        /// <summary>
        /// �õ����ݱ�Table_CAR_QSM���м�¼
        /// </summary>
        /// <returns>ʵ�弯</returns>
        public IList<QSMInfo> FindAllQSMInfo()
        {
            // Use the dal to get all records 

            return qsmDal.FindAllQSMInfo();
        }

        ///<summary>
        ///
        ///</summary>

        public IList<QSMInfo> FindBySql(string sqlWhere)
        {

            return qsmDal.FindBySql(sqlWhere);
        }

        public DataTable getDataSet(string sql)
        {

            return qsmDal.getDataSet(sql);
        }
        public string GetSerialNo()
        {
            return qsmDal.GetSerialNo();
        }

        #endregion

        #endregion
    }
}

