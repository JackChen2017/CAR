using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Addin.CAR.DAL;

namespace FounderTecInfoSys.Addin.CAR.BLL
{
    /// <summary>
    /// 业务层  QSMBLL
    /// </summary>
    public class QSMBLL
    {
        QSMDAL qsmDal = null;

        #region ----------构造函数----------
        /// <summary>
        /// 构造函数
        /// </summary>
        public QSMBLL(int factoryID)
        {
            qsmDal = new QSMDAL(factoryID);
        }

        #endregion

        #region ----------函数定义----------
        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="Table_CAR_QSM">qsminfo对象</param>
        /// <returns>新插入记录的编号</returns>
        public int add(QSMInfo qsminfo)
        {
            // Validate input
            if (qsminfo == null)
                return 0;

            return qsmDal.Add(qsminfo);
        }

        /// <summary>
        /// 向数据表Table_CAR_QSM更新一条记录。
        /// </summary>
        /// <param name="QSMDAL">Table_CAR_QSM</param>
        /// <returns>影响的行数</returns>
        public int Update(QSMInfo qsminfo)
        {
            // Validate input
            if (qsminfo == null)
                return 0;

            return qsmDal.Update(qsminfo);
        }


        /// <summary>
        /// 删除数据表Table_CAR_QSM中的一条记录
        /// </summary>
        /// <param name="rkey">rkey</param>
        /// <returns>影响的行数</returns>
        public int DeleteByrkey(int rkey)
        {
            // Validate input
            if (rkey < 0)
                return 0;
            //return Table_CAR_QSMDAL.Delete(rkey);
            return qsmDal.DeleteByrkey(rkey);
        }

        #endregion

        #region 查询
        /// <summary>
        /// 得到 qsminfo 数据实体
        /// </summary>
        /// <param name="rkey">rkey</param>
        /// <returns>qsminfo 数据实体</returns>
        public QSMInfo getQSMInfoByrkey(int rkey)
        {
            // Validate input
            if (rkey < 0)
                return null;

            // Use the dal to get a record 

            return qsmDal.getQSMInfoByrkey(rkey);
        }

        /// <summary>
        /// 得到数据表Table_CAR_QSM所有记录
        /// </summary>
        /// <returns>实体集</returns>
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

