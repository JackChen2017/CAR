using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Addin.CAR.DAL;

namespace FounderTecInfoSys.Addin.CAR.BLL
{
    /// <summary>
    /// 业务层  Table_CAR_SABLL
    /// </summary>
    public class SABLL
    {
        SADAL saDal = null;

        #region ----------构造函数----------
        /// <summary>
        /// 构造函数
        /// </summary>
        public SABLL(int factoryID)
        {
            saDal = new SADAL(factoryID);
        }

        #endregion

        #region ----------函数定义----------
        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="Table_CAR_SA">table_car_sa对象</param>
        /// <returns>新插入记录的编号</returns>
        public int add(SAInfo sa)
        {
            // Validate input
            if (sa == null)
                return 0;

            return saDal.Add(sa);
        }

        /// <summary>
        /// 向数据表Table_CAR_SA更新一条记录。
        /// </summary>
        /// <param name="oTable_CAR_SAInfo">Table_CAR_SA</param>
        /// <returns>影响的行数</returns>
        public int Update(SAInfo sa)
        {
            // Validate input
            if (sa == null)
                return 0;

            return saDal.Update(sa);
        }


        /// <summary>
        /// 删除数据表Table_CAR_SA中的一条记录
        /// </summary>
        /// <param name="rkey">rkey</param>
        /// <returns>影响的行数</returns>
        public int DeleteByrkey(int rkey)
        {
            // Validate input
            if (rkey < 0)
                return 0;
            //return Table_CAR_SADAL.Delete(rkey);
            return saDal.DeleteByrkey(rkey);
        }

        #endregion

        #region 查询
        /// <summary>
        /// 得到 table_car_sa 数据实体
        /// </summary>
        /// <param name="rkey">rkey</param>
        /// <returns>table_car_sa 数据实体</returns>
        public SAInfo getSAInfoByrkey(int rkey)
        {
            // Validate input
            if (rkey < 0)
                return null;

            // Use the dal to get a record 

            return saDal.GetSAInfoByrkey(rkey);
        }

        /// <summary>
        /// 得到数据表Table_CAR_SA所有记录
        /// </summary>
        /// <returns>实体集</returns>
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

