using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Common.SQLBase;

namespace FounderTecInfoSys.Addin.CAR.DAL
{
    public class DataDAL:DataModuleBase
    {
        #region 字段
        private string sqlAddData = "Proc_CAR_InsertCARData01";
        private string sqlUpdateData = "Proc_CAR_UpdateCARData01";
        private string sqlDelData = "Proc_CAR_DelCARData01";
        #endregion
        
        #region 构造
        public DataDAL(int _factoryid)
            :
            base(System.Configuration.ConfigurationManager.ConnectionStrings[_factoryid.ToString()].ConnectionString)
        { }
        #endregion

        #region Insert
        /// <summary>
        /// Insert CAR_Table_Data01 表
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回0则操作成功</returns>
        public int AddData(DataInfo info)
        {
            int returnID = 0;
            System.Data.SqlClient.SqlCommand cmd = GenCommand(sqlAddData, CommandType.StoredProcedure);
            
            #region add Parameters            
            cmd.Parameters.Add("@serial_no", SqlDbType.VarChar,15);
            cmd.Parameters.Add("@FactoryID", SqlDbType.Decimal,5);
            cmd.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
			cmd.Parameters.Add("@FactoryType", SqlDbType.VarChar,50);
            cmd.Parameters.Add("@CustName", SqlDbType.VarChar, 50);
			cmd.Parameters.Add("@CustType", SqlDbType.VarChar,50);
			cmd.Parameters.Add("@Fahuo_Quan", SqlDbType.Decimal,9);
			cmd.Parameters.Add("@JianCha_Quan", SqlDbType.Decimal,9);
			cmd.Parameters.Add("@badness_bi", SqlDbType.Decimal,7);
			cmd.Parameters.Add("@badness_DC", SqlDbType.VarChar,50);
			cmd.Parameters.Add("@zaixian_quan", SqlDbType.Decimal,9);
			cmd.Parameters.Add("@kuchun_quan", SqlDbType.Decimal,9);
			cmd.Parameters.Add("@tuihuo_status", SqlDbType.Int,4);
			cmd.Parameters.Add("@tuihuo_quan", SqlDbType.Decimal,9);
			cmd.Parameters.Add("@kuhuhappen_address", SqlDbType.Decimal,5);
			cmd.Parameters.Add("@tijiao_status", SqlDbType.Decimal,5);
			cmd.Parameters.Add("@tijiao_type", SqlDbType.Decimal,5);
			cmd.Parameters.Add("@DC_quan", SqlDbType.Decimal,9);
			cmd.Parameters.Add("@zaitu_status", SqlDbType.Decimal,5);
			cmd.Parameters.Add("@zaitu_quan", SqlDbType.Decimal,9);
			cmd.Parameters.Add("@chuli_status", SqlDbType.Decimal,5);
			cmd.Parameters.Add("@changleikuchun_status", SqlDbType.Decimal,5);
			cmd.Parameters.Add("@chuli_type", SqlDbType.Decimal,5);
            cmd.Parameters.Add("@happen_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@required_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@issued_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@from_comp", SqlDbType.VarChar,50);
            cmd.Parameters.Add("@car_comp", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@issued_user", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@issued_app", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@issued_mg", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@received_user", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@hsf_happen_type", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@car_part_num", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@car_content", SqlDbType.VarChar);
            cmd.Parameters.Add("@lot", SqlDbType.VarChar,30);
            cmd.Parameters.Add("@batch", SqlDbType.Float);
            cmd.Parameters.Add("@sample", SqlDbType.Float);
            cmd.Parameters.Add("@badness_num", SqlDbType.Float);
            cmd.Parameters.Add("@rework", SqlDbType.Float);
            cmd.Parameters.Add("@reject", SqlDbType.Float);
            cmd.Parameters.Add("@nowork", SqlDbType.Float);
            cmd.Parameters.Add("@info_type_1", SqlDbType.Int);
            cmd.Parameters.Add("@info_type_2", SqlDbType.Int);
            cmd.Parameters.Add("@info_type_3", SqlDbType.Int);
            cmd.Parameters.Add("@info_type_4", SqlDbType.Int);
            cmd.Parameters.Add("@info_type_5", SqlDbType.Int);
            cmd.Parameters.Add("@info_content", SqlDbType.VarChar);
            cmd.Parameters.Add("@interim_action", SqlDbType.VarChar);
            cmd.Parameters.Add("@ia_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@corrective_action", SqlDbType.VarChar);
            cmd.Parameters.Add("@ca_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@ipca", SqlDbType.VarChar);
            cmd.Parameters.Add("@ipca_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@atpr", SqlDbType.VarChar);
            cmd.Parameters.Add("@atpr_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@z_user", SqlDbType.VarChar,20);
            cmd.Parameters.Add("@z_app", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@z_mg", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@levels", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@together_write", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@sop_status", SqlDbType.Int);
            cmd.Parameters.Add("@sop_name", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@sop_content", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@sop_user", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@sop_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_status", SqlDbType.Int);
            cmd.Parameters.Add("@conf_content", SqlDbType.VarChar);
            cmd.Parameters.Add("@pre_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@end_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_user", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@conf_user_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_app", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@conf_app_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_mg", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@conf_mg_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@comp_mg", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@other_together_write", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@op_type", SqlDbType.Int);
            cmd.Parameters.Add("@status", SqlDbType.Int);
            cmd.Parameters.Add("@nowuser", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ReqReplyDate", SqlDbType.DateTime);
            cmd.Parameters.Add("@Happen_Address", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@CycleValue", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime);
            cmd.Parameters.Add("@ReceiveUser", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ReqSolution", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ReqTimeLimit", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@ShadinessQty", SqlDbType.Float);
            cmd.Parameters.Add("@IA_APP", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@IA_USER", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@IPCA_APP", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@IPCA_USER", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@Info_Date", SqlDbType.DateTime);
            cmd.Parameters.Add("@RKEY", SqlDbType.Int);
            cmd.Parameters.Add("@returnID", SqlDbType.Int);
            #endregion

            #region set Parameter Value

            System.Data.SqlClient.SqlParameterCollection par = cmd.Parameters;

            par["@serial_no"].Value = info.serial_no;
            par["@FactoryID"].Value = info.FactoryID;
            par["@FactoryName"].Value = info.FactoryName;
            par["@FactoryType"].Value = info.FactoryType;
            par["@CustName"].Value = info.CustName;
            par["@CustType"].Value = info.CustType;
            par["@Fahuo_Quan"].Value = info.Fahuo_Quan;
            par["@JianCha_Quan"].Value = info.JianCha_Quan;
            par["@badness_bi"].Value = info.badness_bi;
            par["@badness_DC"].Value = info.badness_DC;
            par["@zaixian_quan"].Value = info.zaixian_quan;
            par["@kuchun_quan"].Value = info.kuchun_quan;
            par["@tuihuo_status"].Value = info.tuihuo_status;
            par["@tuihuo_quan"].Value = info.tuihuo_quan;
            par["@kuhuhappen_address"].Value = info.kuhuhappen_address;
            par["@tijiao_status"].Value = info.tijiao_status;
            par["@tijiao_type"].Value = info.tijiao_type;
            par["@DC_quan"].Value = info.DC_quan;
            par["@zaitu_status"].Value = info.zaitu_status;
            par["@zaitu_quan"].Value = info.zaitu_quan;
            par["@chuli_status"].Value = info.chuli_status;
            par["@changleikuchun_status"].Value = info.changleikuchun_status;
            par["@chuli_type"].Value = info.chuli_type;
            par["@happen_date"].Value = info.happen_date;
            par["@required_date"].Value = info.required_date;
            par["@conf_date"].Value = info.conf_date;
            par["@issued_date"].Value = info.issued_date;
            par["@from_comp"].Value = info.from_comp;
            par["@car_comp"].Value = info.car_comp;
            par["@issued_user"].Value = info.issued_user;
            par["@issued_app"].Value = info.issued_app;
            par["@issued_mg"].Value = info.issued_mg;
            par["@received_user"].Value = info.received_user;
            par["@hsf_happen_type"].Value = info.hsf_happen_type;
            par["@car_part_num"].Value = info.car_part_num;
            par["@car_content"].Value = info.car_content;
            par["@lot"].Value = info.lot;
            par["@batch"].Value = info.batch;
            par["@sample"].Value = info.sample;
            par["@badness_num"].Value = info.badness_num;
            par["@rework"].Value = info.rework;
            par["@reject"].Value = info.reject;
            par["@nowork"].Value = info.nowork;
            par["@info_type_1"].Value = info.info_type_1;
            par["@info_type_2"].Value = info.info_type_2;
            par["@info_type_3"].Value = info.info_type_3;
            par["@info_type_4"].Value = info.info_type_4;
            par["@info_type_5"].Value = info.info_type_5;
            par["@info_content"].Value = info.info_content;
            par["@interim_action"].Value = info.interim_action;
            par["@ia_date"].Value = info.ia_date;
            par["@corrective_action"].Value = info.corrective_action;
            par["@ca_date"].Value = info.ca_date;
            par["@ipca"].Value = info.ipca;
            par["@ipca_date"].Value = info.ipca_date;
            par["@atpr"].Value = info.atpr;
            par["@atpr_date"].Value = info.atpr_date;
            par["@z_user"].Value = info.z_user;
            par["@z_app"].Value = info.z_app;
            par["@z_mg"].Value = info.z_mg;
            par["@levels"].Value = info.levels;
            par["@together_write"].Value = info.together_write;
            par["@sop_status"].Value = info.sop_status;
            par["@sop_name"].Value = info.sop_name;
            par["@sop_content"].Value = info.sop_content;
            par["@sop_user"].Value = info.sop_user;
            par["@sop_date"].Value = info.sop_date;
            par["@conf_status"].Value = info.conf_status;
            par["@conf_content"].Value = info.conf_content;
            par["@pre_date"].Value = info.pre_date;
            par["@end_date"].Value = info.end_date;
            par["@conf_user"].Value = info.conf_user;
            par["@conf_user_date"].Value = info.conf_user_date;
            par["@conf_app"].Value = info.conf_app;
            par["@conf_app_date"].Value = info.conf_app_date;
            par["@conf_mg"].Value = info.conf_mg;
            par["@conf_mg_date"].Value = info.conf_mg_date;
            par["@comp_mg"].Value = info.comp_mg;
            par["@other_together_write"].Value = info.other_together_write;
            par["@op_type"].Value = info.op_type;
            par["@status"].Value = info.status;
            par["@nowuser"].Value = info.nowuser;

            par["@ReqReplyDate"].Value = info.ReqReplyDate;
            par["@Happen_Address"].Value = info.Happen_Address;
            par["@CycleValue"].Value = info.CycleValue;
            par["@ReceiveDate"].Value = info.ReceiveDate;
            par["@ReceiveUser"].Value = info.ReceiveUser;
            par["@ReqSolution"].Value = info.ReqSolution;
            par["@ReqTimeLimit"].Value = info.ReqTimeLimit;
            par["@ShadinessQty"].Value = info.ShadinessQty;

            par["@IA_APP"].Value = info.IA_APP;
            par["@IA_USER"].Value = info.IA_USER;
            par["@IPCA_APP"].Value = info.IPCA_APP;
            par["@IPCA_USER"].Value = info.IPCA_USER;
            par["@Info_Date"].Value = info.Info_Date;

            par["@RKEY"].Value = 0;
            par["@RKEY"].Direction = ParameterDirection.InputOutput;
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
        /// Update CAR_Table_Data01 表
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回0则操作成功</returns>
        public int UpdateData(DataInfo info)
        {
            int returnID = 0;
            System.Data.SqlClient.SqlCommand cmd = GenCommand(sqlUpdateData, CommandType.StoredProcedure);

            #region add Parameters
            cmd.Parameters.Add("@rkey", SqlDbType.Int);
            cmd.Parameters.Add("@serial_no", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@FactoryID", SqlDbType.Decimal, 5);
            cmd.Parameters.Add("@FactoryName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@FactoryType", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@CustName", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@CustType", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@Fahuo_Quan", SqlDbType.Decimal, 9);
            cmd.Parameters.Add("@JianCha_Quan", SqlDbType.Decimal, 9);
            cmd.Parameters.Add("@badness_bi", SqlDbType.Decimal, 5);
            cmd.Parameters.Add("@badness_DC", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@zaixian_quan", SqlDbType.Decimal, 9);
            cmd.Parameters.Add("@kuchun_quan", SqlDbType.Decimal, 9);
            cmd.Parameters.Add("@tuihuo_status", SqlDbType.Int, 4);
            cmd.Parameters.Add("@tuihuo_quan", SqlDbType.Decimal, 9);
            cmd.Parameters.Add("@kuhuhappen_address", SqlDbType.Decimal, 5);
            cmd.Parameters.Add("@tijiao_status", SqlDbType.Decimal, 5);
            cmd.Parameters.Add("@tijiao_type", SqlDbType.Decimal, 5);
            cmd.Parameters.Add("@DC_quan", SqlDbType.Decimal, 9);
            cmd.Parameters.Add("@zaitu_status", SqlDbType.Decimal, 5);
            cmd.Parameters.Add("@zaitu_quan", SqlDbType.Decimal, 9);
            cmd.Parameters.Add("@chuli_status", SqlDbType.Decimal, 5);
            cmd.Parameters.Add("@changleikuchun_status", SqlDbType.Decimal, 5);
            cmd.Parameters.Add("@chuli_type", SqlDbType.Decimal, 5);
            cmd.Parameters.Add("@happen_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@required_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@issued_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@from_comp", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@car_comp", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@issued_user", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@issued_app", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@issued_mg", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@received_user", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@hsf_happen_type", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@car_part_num", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@car_content", SqlDbType.VarChar);
            cmd.Parameters.Add("@lot", SqlDbType.VarChar,30);
            cmd.Parameters.Add("@batch", SqlDbType.Float);
            cmd.Parameters.Add("@sample", SqlDbType.Float);
            cmd.Parameters.Add("@badness_num", SqlDbType.Float);
            cmd.Parameters.Add("@rework", SqlDbType.Float);
            cmd.Parameters.Add("@reject", SqlDbType.Float);
            cmd.Parameters.Add("@nowork", SqlDbType.Float);
            cmd.Parameters.Add("@info_type_1", SqlDbType.Int);
            cmd.Parameters.Add("@info_type_2", SqlDbType.Int);
            cmd.Parameters.Add("@info_type_3", SqlDbType.Int);
            cmd.Parameters.Add("@info_type_4", SqlDbType.Int);
            cmd.Parameters.Add("@info_type_5", SqlDbType.Int);
            cmd.Parameters.Add("@info_content", SqlDbType.VarChar);
            cmd.Parameters.Add("@interim_action", SqlDbType.VarChar);
            cmd.Parameters.Add("@ia_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@corrective_action", SqlDbType.VarChar);
            cmd.Parameters.Add("@ca_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@ipca", SqlDbType.VarChar);
            cmd.Parameters.Add("@ipca_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@atpr", SqlDbType.VarChar);
            cmd.Parameters.Add("@atpr_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@z_user", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@z_app", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@z_mg", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@levels", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@together_write", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@sop_status", SqlDbType.Int);
            cmd.Parameters.Add("@sop_name", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@sop_content", SqlDbType.VarChar, 200);
            cmd.Parameters.Add("@sop_user", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@sop_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_status", SqlDbType.Int);
            cmd.Parameters.Add("@conf_content", SqlDbType.VarChar);
            cmd.Parameters.Add("@pre_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@end_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_user", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@conf_user_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_app", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@conf_app_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@conf_mg", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@conf_mg_date", SqlDbType.DateTime);
            cmd.Parameters.Add("@comp_mg", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@other_together_write", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@op_type", SqlDbType.Int);
            cmd.Parameters.Add("@status", SqlDbType.Int);
            cmd.Parameters.Add("@nowuser", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ReqReplyDate", SqlDbType.DateTime);
            cmd.Parameters.Add("@Happen_Address", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@CycleValue", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime);
            cmd.Parameters.Add("@ReceiveUser", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ReqSolution", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ReqTimeLimit", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@ShadinessQty", SqlDbType.Float);

            cmd.Parameters.Add("@IA_APP", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@IA_USER", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@IPCA_APP", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@IPCA_USER", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@Info_Date", SqlDbType.DateTime);
            cmd.Parameters.Add("@returnID", SqlDbType.Int);
            #endregion

            #region set Parameter Value

            System.Data.SqlClient.SqlParameterCollection par = cmd.Parameters;

            par["@rkey"].Value = info.rkey; ;
            par["@serial_no"].Value = info.serial_no;
            par["@FactoryID"].Value = info.FactoryID;
            par["@FactoryName"].Value = info.FactoryName;
            par["@FactoryType"].Value = info.FactoryType;
            par["@CustName"].Value = info.CustName;
            par["@CustType"].Value = info.CustType;
            par["@Fahuo_Quan"].Value = info.Fahuo_Quan;
            par["@JianCha_Quan"].Value = info.JianCha_Quan;
            par["@badness_bi"].Value = info.badness_bi;
            par["@badness_DC"].Value = info.badness_DC;
            par["@zaixian_quan"].Value = info.zaixian_quan;
            par["@kuchun_quan"].Value = info.kuchun_quan;
            par["@tuihuo_status"].Value = info.tuihuo_status;
            par["@tuihuo_quan"].Value = info.tuihuo_quan;
            par["@kuhuhappen_address"].Value = info.kuhuhappen_address;
            par["@tijiao_status"].Value = info.tijiao_status;
            par["@tijiao_type"].Value = info.tijiao_type;
            par["@DC_quan"].Value = info.DC_quan;
            par["@zaitu_status"].Value = info.zaitu_status;
            par["@zaitu_quan"].Value = info.zaitu_quan;
            par["@chuli_status"].Value = info.chuli_status;
            par["@changleikuchun_status"].Value = info.changleikuchun_status;
            par["@chuli_type"].Value = info.chuli_type;
            par["@happen_date"].Value = info.happen_date;
            par["@required_date"].Value = info.required_date;
            par["@conf_date"].Value = info.conf_date;
            par["@issued_date"].Value = info.issued_date;
            par["@from_comp"].Value = info.from_comp;
            par["@car_comp"].Value = info.car_comp;
            par["@issued_user"].Value = info.issued_user;
            par["@issued_app"].Value = info.issued_app;
            par["@issued_mg"].Value = info.issued_mg;
            par["@received_user"].Value = info.received_user;
            par["@hsf_happen_type"].Value = info.hsf_happen_type;
            par["@car_part_num"].Value = info.car_part_num;
            par["@car_content"].Value = info.car_content;
            par["@lot"].Value = info.lot;
            par["@batch"].Value = info.batch;
            par["@sample"].Value = info.sample;
            par["@badness_num"].Value = info.badness_num;
            par["@rework"].Value = info.rework;
            par["@reject"].Value = info.reject;
            par["@nowork"].Value = info.nowork;
            par["@info_type_1"].Value = info.info_type_1;
            par["@info_type_2"].Value = info.info_type_2;
            par["@info_type_3"].Value = info.info_type_3;
            par["@info_type_4"].Value = info.info_type_4;
            par["@info_type_5"].Value = info.info_type_5;
            par["@info_content"].Value = info.info_content;
            par["@interim_action"].Value = info.interim_action;
            par["@ia_date"].Value = info.ia_date;
            par["@corrective_action"].Value = info.corrective_action;
            par["@ca_date"].Value = info.ca_date;
            par["@ipca"].Value = info.ipca;
            par["@ipca_date"].Value = info.ipca_date;
            par["@atpr"].Value = info.atpr;
            par["@atpr_date"].Value = info.atpr_date;
            par["@z_user"].Value = info.z_user;
            par["@z_app"].Value = info.z_app;
            par["@z_mg"].Value = info.z_mg;
            par["@levels"].Value = info.levels;
            par["@together_write"].Value = info.together_write;
            par["@sop_status"].Value = info.sop_status;
            par["@sop_name"].Value = info.sop_name;
            par["@sop_content"].Value = info.sop_content;
            par["@sop_user"].Value = info.sop_user;
            par["@sop_date"].Value = info.sop_date;
            par["@conf_status"].Value = info.conf_status;
            par["@conf_content"].Value = info.conf_content;
            par["@pre_date"].Value = info.pre_date;
            par["@end_date"].Value = info.end_date;
            par["@conf_user"].Value = info.conf_user;
            par["@conf_user_date"].Value = info.conf_user_date;
            par["@conf_app"].Value = info.conf_app;
            par["@conf_app_date"].Value = info.conf_app_date;
            par["@conf_mg"].Value = info.conf_mg;
            par["@conf_mg_date"].Value = info.conf_mg_date;
            par["@comp_mg"].Value = info.comp_mg;
            par["@other_together_write"].Value = info.other_together_write;
            par["@op_type"].Value = info.op_type;
            par["@status"].Value = info.status;
            par["@nowuser"].Value = info.nowuser;
            par["@ReqReplyDate"].Value = info.ReqReplyDate;
            par["@Happen_Address"].Value = info.Happen_Address;
            par["@CycleValue"].Value = info.CycleValue;
            par["@ReceiveDate"].Value = info.ReceiveDate;
            par["@ReceiveUser"].Value = info.ReceiveUser;
            par["@ReqSolution"].Value = info.ReqSolution;
            par["@ReqTimeLimit"].Value = info.ReqTimeLimit;
            par["@ShadinessQty"].Value = info.ShadinessQty;
            par["@IA_APP"].Value = info.IA_APP;
            par["@IA_USER"].Value = info.IA_USER;
            par["@IPCA_APP"].Value = info.IPCA_APP;
            par["@IPCA_USER"].Value = info.IPCA_USER;
            par["@Info_Date"].Value = info.Info_Date;
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
        /// 删除 CAR_Table_Data01表 一条记录
        /// </summary>
        /// <param name="rkey">关键字</param>
        /// <returns>返回0则执行成功</returns>
        public int DelData(int rkey)
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
        public DataInfo GetByKey(int rkey)
        {
            DataInfo dataInfo = new DataInfo();
            string sql = "select * from CAR_Table_Data01 where rkey = "+ rkey.ToString();
            System.Data.SqlClient.SqlCommand cmd = GenCommand(sql, CommandType.Text);
            DataTable tb = new DataTable();
            DateTime? dataTime = null;
            try
            {
                FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().GetSQL(tb, cmd);
                if (tb.Rows.Count > 0)
                {
                    foreach (DataRow row in tb.Rows)
                    {
                        dataInfo.rkey = int.Parse(row["rkey"].ToString());
                        dataInfo.serial_no = row["Serial_No"].ToString();
                        dataInfo.FactoryID = string.IsNullOrEmpty(row["FactoryID"].ToString()) ? 0 : decimal.Parse(row["FactoryID"].ToString()); 
                        dataInfo.FactoryName = row["FactoryName"].ToString();
                        dataInfo.FactoryType = row["FactoryType"].ToString();
                        dataInfo.CustName = row["CustName"].ToString();
                        dataInfo.CustType = row["CustType"].ToString();
                        dataInfo.Fahuo_Quan = string.IsNullOrEmpty(row["Fahuo_Quan"].ToString()) ? 0: decimal.Parse(row["Fahuo_Quan"].ToString());
                        dataInfo.JianCha_Quan = string.IsNullOrEmpty(row["JianCha_Quan"].ToString()) ? 0 : decimal.Parse(row["JianCha_Quan"].ToString());
                        dataInfo.badness_bi = string.IsNullOrEmpty(row["badness_bi"].ToString()) ? 0 : decimal.Parse(row["badness_bi"].ToString());
                        dataInfo.badness_DC = row["badness_DC"].ToString();
                        dataInfo.zaixian_quan = string.IsNullOrEmpty(row["zaixian_quan"].ToString()) ? 0 : decimal.Parse(row["zaixian_quan"].ToString());
                        dataInfo.kuchun_quan = string.IsNullOrEmpty(row["kuchun_quan"].ToString()) ? 0 : decimal.Parse(row["kuchun_quan"].ToString());
                        dataInfo.tuihuo_status = string.IsNullOrEmpty(row["tuihuo_status"].ToString()) ? 0 : int.Parse(row["tuihuo_status"].ToString());
                        dataInfo.tuihuo_quan = string.IsNullOrEmpty(row["tuihuo_quan"].ToString()) ? 0 : decimal.Parse(row["tuihuo_quan"].ToString());
                        dataInfo.kuhuhappen_address = string.IsNullOrEmpty(row["kuhuhappen_address"].ToString()) ? 0 : decimal.Parse(row["kuhuhappen_address"].ToString());
                        dataInfo.tijiao_status = string.IsNullOrEmpty(row["tijiao_status"].ToString()) ? 0 : decimal.Parse(row["tijiao_status"].ToString());
                        dataInfo.tijiao_type = string.IsNullOrEmpty(row["tijiao_type"].ToString()) ? 0 : decimal.Parse(row["tijiao_type"].ToString());
                        dataInfo.DC_quan = string.IsNullOrEmpty(row["DC_quan"].ToString()) ? 0 : decimal.Parse(row["DC_quan"].ToString());
                        dataInfo.zaitu_status = string.IsNullOrEmpty(row["zaitu_status"].ToString()) ? 0 : decimal.Parse(row["zaitu_status"].ToString());
                        dataInfo.zaitu_quan = string.IsNullOrEmpty(row["zaitu_quan"].ToString()) ? 0 : decimal.Parse(row["zaitu_quan"].ToString());
                        dataInfo.chuli_status = string.IsNullOrEmpty(row["chuli_status"].ToString()) ? 0 : decimal.Parse(row["chuli_status"].ToString());
                        dataInfo.changleikuchun_status = string.IsNullOrEmpty(row["changleikuchun_status"].ToString()) ? 0 : decimal.Parse(row["changleikuchun_status"].ToString());
                        dataInfo.chuli_type = string.IsNullOrEmpty(row["chuli_type"].ToString()) ? 0 : decimal.Parse(row["chuli_type"].ToString());

                        dataInfo.happen_date = string.IsNullOrEmpty(row["happen_date"].ToString()) ? dataTime : Convert.ToDateTime(row["happen_date"].ToString());
                        dataInfo.required_date = string.IsNullOrEmpty(row["Required_Date"].ToString()) ? dataTime : Convert.ToDateTime(row["Required_Date"].ToString());
                        dataInfo.conf_date = string.IsNullOrEmpty(row["conf_date"].ToString()) ? dataTime : Convert.ToDateTime(row["conf_date"].ToString());
                        dataInfo.issued_date = string.IsNullOrEmpty(row["issued_date"].ToString()) ? dataTime : Convert.ToDateTime(row["issued_date"].ToString());
                        dataInfo.from_comp = row["from_comp"].ToString();
                        dataInfo.car_comp = row["car_comp"].ToString();
                        dataInfo.issued_user = row["issued_user"].ToString();
                        dataInfo.issued_app = row["issued_app"].ToString();
                        dataInfo.issued_mg = row["issued_mg"].ToString();
                        dataInfo.received_user = row["received_user"].ToString();
                        dataInfo.hsf_happen_type = row["hsf_happen_type"].ToString();
                        dataInfo.car_part_num = row["car_part_num"].ToString();
                        dataInfo.car_content = row["car_content"].ToString();
                        dataInfo.lot = row["lot"].ToString();
                        dataInfo.batch = string.IsNullOrEmpty(row["batch"].ToString()) ? 0 : float.Parse(row["batch"].ToString());
                        dataInfo.sample = string.IsNullOrEmpty(row["sample"].ToString()) ? 0 : float.Parse(row["sample"].ToString());
                        dataInfo.badness_num = string.IsNullOrEmpty(row["badness_num"].ToString()) ? 0 : float.Parse(row["badness_num"].ToString());
                        dataInfo.rework = string.IsNullOrEmpty(row["rework"].ToString()) ? 0 : float.Parse(row["rework"].ToString());
                        dataInfo.reject = string.IsNullOrEmpty(row["reject"].ToString()) ? 0 : float.Parse(row["reject"].ToString());
                        dataInfo.nowork = string.IsNullOrEmpty(row["nowork"].ToString()) ? 0 : float.Parse(row["nowork"].ToString());
                        dataInfo.info_type_1 = string.IsNullOrEmpty(row["info_type_1"].ToString()) ? 0 : Convert.ToInt32(row["info_type_1"].ToString());
                        dataInfo.info_type_2 = string.IsNullOrEmpty(row["info_type_2"].ToString()) ? 0 : Convert.ToInt32(row["info_type_2"].ToString());
                        dataInfo.info_type_3 = string.IsNullOrEmpty(row["info_type_3"].ToString()) ? 0 : Convert.ToInt32(row["info_type_3"].ToString());
                        dataInfo.info_type_4 = string.IsNullOrEmpty(row["info_type_4"].ToString()) ? 0 : Convert.ToInt32(row["info_type_4"].ToString());
                        dataInfo.info_type_5 = string.IsNullOrEmpty(row["info_type_5"].ToString()) ? 0 : Convert.ToInt32(row["info_type_5"].ToString());
                        dataInfo.info_content = row["info_content"].ToString();
                        dataInfo.interim_action = row["interim_action"].ToString();
                        dataInfo.ia_date = string.IsNullOrEmpty(row["IA_Date"].ToString()) ? dataTime : Convert.ToDateTime(row["IA_Date"].ToString());
                        dataInfo.corrective_action = row["corrective_action"].ToString();
                        dataInfo.ca_date = string.IsNullOrEmpty(row["ca_date"].ToString()) ? dataTime : Convert.ToDateTime(row["ca_date"].ToString());
                        dataInfo.ipca = row["ipca"].ToString();
                        dataInfo.ipca_date = string.IsNullOrEmpty(row["ipca_date"].ToString()) ? dataTime : Convert.ToDateTime(row["ipca_date"].ToString());
                        dataInfo.atpr = row["atpr"].ToString();
                        dataInfo.atpr_date = string.IsNullOrEmpty(row["atpr_date"].ToString()) ? dataTime : Convert.ToDateTime(row["atpr_date"].ToString());
                        dataInfo.z_user = row["z_user"].ToString();
                        dataInfo.z_app = row["z_app"].ToString();
                        dataInfo.z_mg = row["z_mg"].ToString();
                        dataInfo.levels = row["levels"].ToString();
                        dataInfo.together_write = row["together_write"].ToString();
                        dataInfo.sop_status = string.IsNullOrEmpty(row["sop_status"].ToString()) ? 0 : Convert.ToInt32(row["sop_status"].ToString());
                        dataInfo.sop_name = row["sop_name"].ToString();
                        dataInfo.sop_content = row["sop_content"].ToString();
                        dataInfo.sop_user = row["sop_user"].ToString();
                        dataInfo.sop_date = string.IsNullOrEmpty(row["sop_date"].ToString()) ? dataTime : Convert.ToDateTime(row["sop_date"].ToString());
                        dataInfo.conf_status = string.IsNullOrEmpty(row["conf_status"].ToString()) ? 0 : Convert.ToInt32(row["conf_status"].ToString());
                        dataInfo.conf_content = row["conf_content"].ToString();
                        dataInfo.pre_date = string.IsNullOrEmpty(row["pre_date"].ToString()) ? dataTime : Convert.ToDateTime(row["pre_date"].ToString());
                        dataInfo.end_date = string.IsNullOrEmpty(row["end_date"].ToString()) ? dataTime : Convert.ToDateTime(row["end_date"].ToString());
                        dataInfo.conf_user = row["conf_user"].ToString();
                        dataInfo.conf_user_date = string.IsNullOrEmpty(row["conf_user_date"].ToString()) ? dataTime : Convert.ToDateTime(row["conf_user_date"].ToString());
                        dataInfo.conf_app = row["conf_app"].ToString();
                        dataInfo.conf_app_date = string.IsNullOrEmpty(row["conf_app_date"].ToString()) ? dataTime : Convert.ToDateTime(row["conf_app_date"].ToString());
                        dataInfo.conf_mg = row["conf_mg"].ToString();
                        dataInfo.conf_mg_date = string.IsNullOrEmpty(row["conf_mg_date"].ToString()) ? dataTime : Convert.ToDateTime(row["conf_mg_date"].ToString());
                        dataInfo.comp_mg = row["comp_mg"].ToString();
                        dataInfo.other_together_write = row["other_together_write"].ToString();
                        dataInfo.op_type = string.IsNullOrEmpty(row["op_type"].ToString()) ? 0 : Convert.ToInt32(row["op_type"].ToString());
                        dataInfo.status = string.IsNullOrEmpty(row["status"].ToString()) ? 0 : Convert.ToInt32(row["status"].ToString());
                        dataInfo.nowuser = row["nowuser"].ToString();

                        dataInfo.ReqReplyDate = string.IsNullOrEmpty(row["ReqReplyDate"].ToString()) ? dataTime : Convert.ToDateTime(row["ReqReplyDate"].ToString());
                        dataInfo.Happen_Address = row["Happen_Address"].ToString();
                        dataInfo.CycleValue = row["CycleValue"].ToString();
                        dataInfo.ReceiveDate = string.IsNullOrEmpty(row["ReceiveDate"].ToString()) ? dataTime : Convert.ToDateTime(row["ReceiveDate"].ToString());
                        dataInfo.ReceiveUser = row["ReceiveUser"].ToString();
                        dataInfo.ReqSolution = row["ReqSolution"].ToString();
                        dataInfo.ReqTimeLimit = row["ReqTimeLimit"].ToString();
                        dataInfo.ShadinessQty =  string.IsNullOrEmpty(row["ShadinessQty"].ToString()) ? 0 : float.Parse(row["ShadinessQty"].ToString());
                        dataInfo.IA_APP = row["IA_APP"].ToString();
                        dataInfo.IA_USER = row["IA_User"].ToString();
                        dataInfo.IPCA_APP = row["IPCA_APP"].ToString();
                        dataInfo.IPCA_USER = row["IPCA_User"].ToString();
                        dataInfo.Info_Date = string.IsNullOrEmpty(row["Info_Date"].ToString()) ? dataTime : Convert.ToDateTime(row["Info_Date"].ToString());
                    }
                }
            }
            catch(Exception ex)
            { }

            return dataInfo;
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
        #endregion

        #region 获取单号
        public string getSerialNo(string type)
        {
            if (type.Trim().Length > 5)
            {
                return type;
            }
            string sql = "exec PROC_CAR_GetSerialNo '" + type + "'";
            System.Data.SqlClient.SqlCommand cmd = GenCommand(sql, CommandType.Text);
            DataTable tb = new DataTable();
            try
            {
                FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().GetSQL(tb, cmd);
            }
            catch { }
            if (tb.Rows.Count > 0)
            {
                return tb.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
