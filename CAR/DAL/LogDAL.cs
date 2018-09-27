using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Common.SQLBase;

namespace FounderTecInfoSys.Addin.CAR.DAL
{
    public class LogDAL : DataModuleBase
    {
        #region 字段
        private string sqlAddData = "Proc_CAR_InsertCARLog";
        private string sqlUpdateData = "Proc_CAR_UpdateCARLog";
        private string sqlDelData = "Proc_CAR_DelCARLog";
        #endregion
        
        #region 构造
        public LogDAL(int _factoryid)
            :
            base(System.Configuration.ConfigurationManager.ConnectionStrings[_factoryid.ToString()].ConnectionString)
        { }
        #endregion

        #region Insert
        /// <summary>
        /// Insert CAR_Table_LOG 表
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回0则操作成功</returns>
        public int AddLog(LogInfo info)
        {
            int returnID = 0;
            System.Data.SqlClient.SqlCommand cmd = GenCommand(sqlAddData, CommandType.StoredProcedure);

            #region add Parameters
            cmd.Parameters.Add("@rkey", SqlDbType.Int);
            cmd.Parameters.Add("@SN_PTR", SqlDbType.Int);
            cmd.Parameters.Add("@SN_TYPE", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@SP_Total_Step", SqlDbType.Int);
            cmd.Parameters.Add("@SP_Start_Date", SqlDbType.DateTime);
            cmd.Parameters.Add("@SP_End_Date", SqlDbType.DateTime);
            cmd.Parameters.Add("@SP_Type", SqlDbType.Int);
            cmd.Parameters.Add("@SP_Step", SqlDbType.Int);
            cmd.Parameters.Add("@SP_User", SqlDbType.VarChar,50);
            cmd.Parameters.Add("@SP_Content", SqlDbType.VarChar,200);
            cmd.Parameters.Add("@Status", SqlDbType.Int);
            cmd.Parameters.Add("@returnID", SqlDbType.Int);
            #endregion

            #region set Parameter Value

            System.Data.SqlClient.SqlParameterCollection par = cmd.Parameters;

            par["@rkey"].Direction = ParameterDirection.Output;
            par["@SN_PTR"].Value = info.sn_ptr;
            par["@SN_TYPE"].Value = info.sn_type;
            par["@SP_Total_Step"].Value = info.sp_total_step;
            par["@SP_Start_Date"].Value = info.sp_start_date;
            par["@SP_End_Date"].Value = info.sp_end_date;
            par["@SP_Type"].Value = info.sp_type;
            par["@SP_Step"].Value = info.sp_step;
            par["@SP_User"].Value = info.sp_user;
            par["@SP_Content"].Value = info.sp_content;
            par["@Status"].Value = info.status;
            par["@returnID"].Value = 0;
            par["@returnID"].Direction = ParameterDirection.InputOutput;
            #endregion

            FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().ExecuteStoredProcedure(cmd);

            //更新info.rkey
            info.rkey = Convert.ToInt32(par["@rkey"].Value);
            returnID = Convert.ToInt32(par["@returnID"].Value);
            return returnID;
        }
       #endregion

        #region Update
        /// <summary>
        /// Update CAR_Table_LOG 表
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回0则操作成功</returns>
        public int UpdateLog(LogInfo info)
        {
            int returnID = 0;
            System.Data.SqlClient.SqlCommand cmd = GenCommand(sqlUpdateData, CommandType.StoredProcedure);

            #region add Parameters
            cmd.Parameters.Add("@rkey", SqlDbType.Int);
            cmd.Parameters.Add("@SN_PTR", SqlDbType.Int);
            cmd.Parameters.Add("@SN_TYPE", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@SP_Total_Step", SqlDbType.Int);
            cmd.Parameters.Add("@SP_Start_Date", SqlDbType.DateTime);
            cmd.Parameters.Add("@SP_End_Date", SqlDbType.DateTime);
            cmd.Parameters.Add("@SP_Type", SqlDbType.Int);
            cmd.Parameters.Add("@SP_Step", SqlDbType.Int);
            cmd.Parameters.Add("@SP_User", SqlDbType.VarChar,50);
            cmd.Parameters.Add("@SP_Content", SqlDbType.VarChar,200);
            cmd.Parameters.Add("@Status", SqlDbType.Int);
            cmd.Parameters.Add("@returnID", SqlDbType.Int);
            #endregion

            #region set Parameter Value

            System.Data.SqlClient.SqlParameterCollection par = cmd.Parameters;

            par["@rkey"].Value = info.rkey;
            par["@SN_PTR"].Value = info.sn_ptr;
            par["@SN_TYPE"].Value = info.sn_type;
            par["@SP_Total_Step"].Value = info.sp_total_step;
            par["@SP_Start_Date"].Value = info.sp_start_date;
            par["@SP_End_Date"].Value = info.sp_end_date;
            par["@SP_Type"].Value = info.sp_type;
            par["@SP_Step"].Value = info.sp_step;
            par["@SP_User"].Value = info.sp_user;
            par["@SP_Content"].Value = info.sp_content;
            par["@Status"].Value = info.status;
            par["@returnID"].Value = 0;
            par["@returnID"].Direction = ParameterDirection.InputOutput;
            #endregion

            FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().ExecuteStoredProcedure(cmd);

            
            returnID = Convert.ToInt32(par["@returnID"].Value);
            return returnID;
        }
        #endregion

        #region Del
        /// <summary>
        /// 删除 CAR_Table_LOG表 一条记录
        /// </summary>
        /// <param name="rkey">关键字</param>
        /// <returns>返回0则执行成功</returns>
        public int DelLog(int rkey)
        {
            int returnID = 0;
            System.Data.SqlClient.SqlCommand cmd = GenCommand(sqlDelData, CommandType.StoredProcedure);

            #region add Parameters
            cmd.Parameters.Add("@RKEY", SqlDbType.Int);
            cmd.Parameters.Add("@returnID", SqlDbType.Int);
            #endregion

            #region set value paramenter

            System.Data.SqlClient.SqlParameterCollection par = cmd.Parameters;

            par["@RKEY"].Value = rkey;
            par["@returnID"].Value = 0;
            par["@returnID"].Direction = ParameterDirection.InputOutput;
            #endregion

            FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().ExecuteStoredProcedure(cmd);

            returnID = Convert.ToInt32(par["@returnID"].Value);

            return returnID;
        }
        #endregion

        #region 查
        public LogInfo GetByKey(int rkey)
        {
            LogInfo logInfo = new LogInfo();
            string sql = "select * from [CAR_Table_LOG] where rkey = " + rkey.ToString();
            System.Data.SqlClient.SqlCommand cmd = GenCommand(sql, CommandType.Text);
            DataTable tb = new DataTable();
            try
            {
                FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().GetSQL(tb, cmd);
                foreach(DataRow row in tb.Rows)
                {
                    logInfo.rkey = int.Parse(row["rkey"].ToString());
                    logInfo.sn_ptr = int.Parse(row["sn_ptr"].ToString());
                    logInfo.sn_type = row["sn_type"].ToString();
                    logInfo.sp_total_step = int.Parse(row["SP_Total_Step"].ToString());
                    try
                    {
                        logInfo.sp_start_date = Convert.ToDateTime(row["SP_Start_Date"].ToString());
                    }
                    catch
                    {
                        logInfo.sp_start_date = null;
                    }
                    try
                    {
                        logInfo.sp_end_date = Convert.ToDateTime(row["SP_End_Date"].ToString());
                    }
                    catch
                    {
                        logInfo.sp_end_date = null;
                    }
                    logInfo.sp_type = int.Parse(row["SP_Type"].ToString());
                    logInfo.sp_step = int.Parse(row["SP_Step"].ToString());
                    logInfo.sp_user = row["SP_User"].ToString();
                    logInfo.sp_content = row["SP_Content"].ToString();
                    logInfo.status = int.Parse(row["Status"].ToString());
                }
            }
            catch (Exception ex)
            { }
            return logInfo;
        }

        public DataTable GetDataSet(string sql)
        {
            DataTable tb = new DataTable();
            try
            {
                FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().GetSQL(tb,GenCommand(sql,CommandType.Text));
            }
            catch (Exception ex)
            { }
            return tb;
        }
        public void DeleteByKey(int did,string sn_type)
        {
            string sql = "delete from CAR_Table_LOG where sn_ptr = " + did.ToString() + " and sn_type = '" + sn_type + "'";
            FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().ExecuteSQL(GenCommand(sql, CommandType.Text));
        }
        #endregion
    }
}
