using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Common.SQLBase;
using System.Data.SqlClient;

namespace FounderTecInfoSys.Addin.CAR.DAL
{
    public class SAListDAL : DataModuleBase
    {
        #region 构造函数
        public SAListDAL(int _factoryid)
            :
            base(System.Configuration.ConfigurationManager.ConnectionStrings[_factoryid.ToString()].ConnectionString)
        { }
        #endregion
        #region  成员方法
        #region
        //////<summary>
        // ////增加一条数据
        // ////</summary>
        //public int Add(SAInfo model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into CAR_Table_SA(");
        //    strSql.Append("sn_ptr,custCode,custName,recordDateTime,founderMaterilNo,custPartNo,cycleValue,happenAddress,LOT,ET,T,reason,mateialType,results,quantity,signDate,signingPerson,factoryName,discountPrice,discountAmount)");
        //    strSql.Append(" values (");
        //    strSql.Append("@sn_ptr,@custCode,@custName,@recordDateTime,@founderMaterilNo,@custPartNo,@cycleValue,@happenAddress,@LOT,@ET,@T,@reason,@mateialType,@results,@quantity,@signDate,@signingPerson,@factoryName,@discountPrice,@discountAmount)");
        //    strSql.Append(";select @@IDENTITY as id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@sn_ptr", SqlDbType.Int,4),
        //            new SqlParameter("@custCode", SqlDbType.VarChar,10),
        //            new SqlParameter("@custName", SqlDbType.VarChar,80),
        //            new SqlParameter("@recordDateTime", SqlDbType.DateTime),
        //            new SqlParameter("@founderMaterilNo", SqlDbType.VarChar,30),
        //            new SqlParameter("@custPartNo", SqlDbType.VarChar,50),
        //            new SqlParameter("@cycleValue", SqlDbType.VarChar,10),
        //            new SqlParameter("@happenAddress", SqlDbType.VarChar,50),
        //            new SqlParameter("@LOT", SqlDbType.VarChar,20),
        //            new SqlParameter("@ET", SqlDbType.VarChar,20),
        //            new SqlParameter("@T", SqlDbType.VarChar,20),
        //            new SqlParameter("@reason", SqlDbType.VarChar,50),
        //            new SqlParameter("@mateialType", SqlDbType.VarChar,10),
        //            new SqlParameter("@results", SqlDbType.VarChar,10),
        //            new SqlParameter("@quantity", SqlDbType.Float,8),
        //            new SqlParameter("@signDate", SqlDbType.DateTime),
        //            new SqlParameter("@signingPerson", SqlDbType.VarChar,20),
        //            new SqlParameter("@factoryName", SqlDbType.VarChar,10),
        //            new SqlParameter("@discountPrice", SqlDbType.Float,8),
        //            new SqlParameter("@discountAmount", SqlDbType.Float,8)};
        //    parameters[0].Value = model.sn_ptr;
        //    parameters[1].Value = model.custCode;
        //    parameters[2].Value = model.custName;
        //    parameters[3].Value = model.recordDateTime;
        //    parameters[4].Value = model.founderMaterilNo;
        //    parameters[5].Value = model.custPartNo;
        //    parameters[6].Value = model.cycleValue;
        //    parameters[7].Value = model.happenAddress;
        //    parameters[8].Value = model.LOT;
        //    parameters[9].Value = model.ET;
        //    parameters[10].Value = model.T;
        //    parameters[11].Value = model.reason;
        //    parameters[12].Value = model.mateialType;
        //    parameters[13].Value = model.results;
        //    parameters[14].Value = model.quantity;
        //    parameters[15].Value = model.signDate;
        //    parameters[16].Value = model.signingPerson;
        //    parameters[17].Value = model.factoryName;
        //    parameters[18].Value = model.discountPrice;
        //    parameters[19].Value = model.discountAmount;

        //    System.Data.SqlClient.SqlCommand cmd = GenCommand(strSql.ToString(), CommandType.Text);
        //    for (int i = 0; i < parameters.Length; i++)
        //    {
        //        cmd.Parameters.Add(parameters[i]);
        //    }

        //    DataTable tb = new DataTable();
        //    FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().GetSQL(tb, cmd);
        //    if (tb.Rows.Count > 0)
        //    {
        //        return Convert.ToInt32(tb.Rows[0][0].ToString());
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        #endregion
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(SAList model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@rkey", SqlDbType.Int,4),
					new SqlParameter("@sn_ptr", SqlDbType.Int,4),
					new SqlParameter("@custCode", SqlDbType.VarChar,10),
					new SqlParameter("@custName", SqlDbType.VarChar,80),
					new SqlParameter("@recordDateTime", SqlDbType.DateTime),
					new SqlParameter("@founderMaterilNo", SqlDbType.VarChar,30),
					new SqlParameter("@custPartNo", SqlDbType.VarChar,50),
					new SqlParameter("@cycleValue", SqlDbType.VarChar,10),
					new SqlParameter("@happenAddress", SqlDbType.VarChar,50),
					new SqlParameter("@LOT", SqlDbType.VarChar,20),
					new SqlParameter("@ET", SqlDbType.VarChar,20),
					new SqlParameter("@T", SqlDbType.VarChar,20),
					new SqlParameter("@reason", SqlDbType.VarChar,50),
					new SqlParameter("@mateialType", SqlDbType.VarChar,10),
					new SqlParameter("@results", SqlDbType.VarChar,10),
					new SqlParameter("@quantity", SqlDbType.Float,8),
					new SqlParameter("@signDate", SqlDbType.DateTime),
					new SqlParameter("@signingPerson", SqlDbType.VarChar,20),
					new SqlParameter("@factoryName", SqlDbType.VarChar,10),
					new SqlParameter("@discountPrice", SqlDbType.Float,8),
					new SqlParameter("@discountAmount", SqlDbType.Float,8)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.sn_ptr;
            parameters[2].Value = model.custCode;
            parameters[3].Value = model.custName;
            parameters[4].Value = model.recordDateTime;
            parameters[5].Value = model.founderMaterilNo;
            parameters[6].Value = model.custPartNo;
            parameters[7].Value = model.cycleValue;
            parameters[8].Value = model.happenAddress;
            parameters[9].Value = model.LOT;
            parameters[10].Value = model.ET;
            parameters[11].Value = model.T;
            parameters[12].Value = model.reason;
            parameters[13].Value = model.mateialType;
            parameters[14].Value = model.results;
            parameters[15].Value = model.quantity;
            parameters[16].Value = model.signDate;
            parameters[17].Value = model.signingPerson;
            parameters[18].Value = model.factoryName;
            parameters[19].Value = model.discountPrice;
            parameters[20].Value = model.discountAmount;

            SqlCommand cmd = GenCommand("UP_CAR_Table_SAList_ADD", CommandType.StoredProcedure);
            foreach (SqlParameter pr in parameters)
            {
                cmd.Parameters.Add(pr);
            }
            return FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().ExecuteStoredProcedure(cmd);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int rkey)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CAR_Table_SAList ");
            strSql.Append(" where rkey=@rkey ");
            SqlParameter[] parameters = {
                    new SqlParameter("@rkey", SqlDbType.Int,4)};
            parameters[0].Value = rkey;
            SqlCommand cmd = GenCommand(strSql.ToString(), CommandType.Text);
            foreach (SqlParameter pr in parameters)
            {
                cmd.Parameters.Add(pr);
            }
            FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().ExecuteStoredProcedure(cmd);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(SAList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CAR_Table_SAList set ");
            strSql.Append("sn_ptr=@sn_ptr,");
            strSql.Append("custCode=@custCode,");
            strSql.Append("custName=@custName,");
            strSql.Append("recordDateTime=@recordDateTime,");
            strSql.Append("founderMaterilNo=@founderMaterilNo,");
            strSql.Append("custPartNo=@custPartNo,");
            strSql.Append("cycleValue=@cycleValue,");
            strSql.Append("happenAddress=@happenAddress,");
            strSql.Append("LOT=@LOT,");
            strSql.Append("ET=@ET,");
            strSql.Append("T=@T,");
            strSql.Append("reason=@reason,");
            strSql.Append("mateialType=@mateialType,");
            strSql.Append("results=@results,");
            strSql.Append("quantity=@quantity,");
            strSql.Append("signDate=@signDate,");
            strSql.Append("signingPerson=@signingPerson,");
            strSql.Append("factoryName=@factoryName,");
            strSql.Append("discountPrice=@discountPrice,");
            strSql.Append("discountAmount=@discountAmount");
            strSql.Append(" where rkey=@rkey ");
            SqlParameter[] parameters = {
					new SqlParameter("@rkey", SqlDbType.Int,4),
					new SqlParameter("@sn_ptr", SqlDbType.Int,4),
                    new SqlParameter("@custCode", SqlDbType.VarChar,10),
                    new SqlParameter("@custName", SqlDbType.VarChar,80),
					new SqlParameter("@recordDateTime", SqlDbType.DateTime),
					new SqlParameter("@founderMaterilNo", SqlDbType.VarChar,30),
					new SqlParameter("@custPartNo", SqlDbType.VarChar,50),
					new SqlParameter("@cycleValue", SqlDbType.VarChar,10),
					new SqlParameter("@happenAddress", SqlDbType.VarChar,50),
					new SqlParameter("@LOT", SqlDbType.VarChar,20),
					new SqlParameter("@ET", SqlDbType.VarChar,20),
					new SqlParameter("@T", SqlDbType.VarChar,20),
					new SqlParameter("@reason", SqlDbType.VarChar,50),
					new SqlParameter("@mateialType", SqlDbType.VarChar,10),
					new SqlParameter("@results", SqlDbType.VarChar,10),
					new SqlParameter("@quantity", SqlDbType.Float,8),
					new SqlParameter("@signDate", SqlDbType.DateTime),
					new SqlParameter("@signingPerson", SqlDbType.VarChar,20),
					new SqlParameter("@factoryName", SqlDbType.VarChar,10),
					new SqlParameter("@discountPrice", SqlDbType.Float,8),
					new SqlParameter("@discountAmount", SqlDbType.Float,8)};
            parameters[0].Value = model.rkey;
            parameters[1].Value = model.sn_ptr;
            parameters[2].Value = model.custCode;
            parameters[3].Value = model.custName;
            parameters[4].Value = model.recordDateTime;
            parameters[5].Value = model.founderMaterilNo;
            parameters[6].Value = model.custPartNo;
            parameters[7].Value = model.cycleValue;
            parameters[8].Value = model.happenAddress;
            parameters[9].Value = model.LOT;
            parameters[10].Value = model.ET;
            parameters[11].Value = model.T;
            parameters[12].Value = model.reason;
            parameters[13].Value = model.mateialType;
            parameters[14].Value = model.results;
            parameters[15].Value = model.quantity;
            parameters[16].Value = model.signDate;
            parameters[17].Value = model.signingPerson;
            parameters[18].Value = model.factoryName;
            parameters[19].Value = model.discountPrice;
            parameters[20].Value = model.discountAmount;

            SqlCommand cmd = GenCommand(strSql.ToString(), CommandType.Text);
            foreach (SqlParameter pr in parameters)
            {
                cmd.Parameters.Add(pr);
            }
            FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().ExecuteStoredProcedure(cmd);
        }

        public DataTable GetDataSet(string sql)
        {
            DataTable tb = new DataTable();
            try
            {
                FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().GetSQL(tb, GenCommand(sql, CommandType.Text));
            }
            catch (Exception ex)
            { }
            return tb;
        }

        public void DeteteByKey(int did)
        {
            string sql = "delete from CAR_Table_SAList where sn_ptr = " + did.ToString();
            FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().ExecuteSQL(GenCommand(sql, CommandType.Text));
        }
        #endregion
    }
}
