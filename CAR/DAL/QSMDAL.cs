using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using FounderTecInfoSys.Addin.CAR.Model;
using FounderTecInfoSys.Addin.CAR;
using System.Configuration;

namespace FounderTecInfoSys.Addin.CAR.DAL
{
    /// <summary>
    /// 数据访问层   qsmDAL
    /// </summary>
    public partial class QSMDAL 
    {

        #region   字段 and 属性
        DBHelper dbHelper = null;

        ///<sumary>
        ///字段 用于指定目标数据库
        ///</sumary>
        private int factoryID = 0;

        ///<sumary>
        ///属性 用于指定目标数据库
        ///</sumary>
        public int FactoryID
        {
            get
            {
                return this.factoryID;
            }
            set
            {
                this.factoryID = value;
            }
        }

        private string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[this.factoryID.ToString()].ConnectionString;
            }
        }

        #endregion
        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public QSMDAL()
        {
        }


        public QSMDAL(int factoryID)
        {
            this.FactoryID = factoryID;
            this.dbHelper = new DBHelper(factoryID);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="qsminfo">qsminfo对象</param>
        /// <returns>新插入记录的编号</returns>
        public int Add(QSMInfo qsminfo)
        {
            #region /// 调用SQL存储过程进行添加
            string sql = "sp_TABLE_CAR_QSM_Add";
            ///存储过程名
            SqlParameter[] parameters ={
			new SqlParameter("@returnID",SqlDbType.Int),
			///new SqlParameter("@rkey",SqlDbType.Int,4),
			new SqlParameter("@rkey",SqlDbType.Float),
			new SqlParameter("@serialNo",SqlDbType.VarChar,20),
			new SqlParameter("@ent_Date",SqlDbType.DateTime,8),
			new SqlParameter("@ent_user",SqlDbType.VarChar,50),
			new SqlParameter("@tousu_level",SqlDbType.VarChar,20),
			new SqlParameter("@tousu_type",SqlDbType.VarChar,20),
			new SqlParameter("@cust_Code",SqlDbType.VarChar,20),
			new SqlParameter("@cust_Name",SqlDbType.VarChar,100),
			new SqlParameter("@factory_Name",SqlDbType.VarChar,20),
			new SqlParameter("@happen_Date",SqlDbType.DateTime,8),
			new SqlParameter("@cust_MaterialNo",SqlDbType.VarChar,200),
			new SqlParameter("@interalNo",SqlDbType.VarChar,50),
			new SqlParameter("@require_Date",SqlDbType.DateTime,8),
			new SqlParameter("@CAR_Content",SqlDbType.VarChar,8000),
			new SqlParameter("@chuhuo_qty",SqlDbType.Decimal,9),
			new SqlParameter("@jiancha_qty",SqlDbType.Decimal,9),
			new SqlParameter("@buliang_qty",SqlDbType.Decimal,9),
			new SqlParameter("@buliangbili",SqlDbType.Decimal,5),
			new SqlParameter("@buliangDC",SqlDbType.VarChar,50),
			new SqlParameter("@zaixian_qty",SqlDbType.Decimal,9),
			new SqlParameter("@kucun_qty",SqlDbType.Decimal,9),
			new SqlParameter("@tuihuo_status",SqlDbType.Int,4),
			new SqlParameter("@tuihuo_qty",SqlDbType.Decimal,9),
			new SqlParameter("@happen_address",SqlDbType.Int,4),
			new SqlParameter("@tijiao_status",SqlDbType.Int,4),
			new SqlParameter("@tijiao_type",SqlDbType.Int,4),
			new SqlParameter("@notes",SqlDbType.VarChar,8000),
			new SqlParameter("@dcjiaohuo_qty",SqlDbType.Decimal,9),
			new SqlParameter("@zaitu_status",SqlDbType.Int,4),
			new SqlParameter("@zaitu_qty",SqlDbType.Decimal,9),
			new SqlParameter("@zaituchuli_type",SqlDbType.Int,4),
			new SqlParameter("@cangcun_status",SqlDbType.Int,4),
			new SqlParameter("@cangcunchuli_type",SqlDbType.Int,4),
			new SqlParameter("@info_content",SqlDbType.VarChar,8000),
			new SqlParameter("@first_reply_date",SqlDbType.DateTime,8),
			new SqlParameter("@last_reply_date",SqlDbType.DateTime,8),
			new SqlParameter("@conf_content",SqlDbType.VarChar,8000),
			new SqlParameter("@close_date",SqlDbType.DateTime,8),
            new SqlParameter("@status",SqlDbType.Int,4)
			};

            parameters[0].Value = 0;
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[1].Direction = ParameterDirection.InputOutput;
            parameters[1].Value = qsminfo.RKEY;
            parameters[2].Value = qsminfo.SERIALNO;
            parameters[3].Value = qsminfo.ENT_DATE;
            parameters[4].Value = qsminfo.ENT_USER;
            parameters[5].Value = qsminfo.TOUSU_LEVEL;
            parameters[6].Value = qsminfo.TOUSU_TYPE;
            parameters[7].Value = qsminfo.CUST_CODE;
            parameters[8].Value = qsminfo.CUST_NAME;
            parameters[9].Value = qsminfo.FACTORY_NAME;
            parameters[10].Value = qsminfo.HAPPEN_DATE;
            parameters[11].Value = qsminfo.CUST_MATERIALNO;
            parameters[12].Value = qsminfo.INTERALNO;
            parameters[13].Value = qsminfo.REQUIRE_DATE;
            parameters[14].Value = qsminfo.CAR_CONTENT;
            parameters[15].Value = qsminfo.CHUHUO_QTY;
            parameters[16].Value = qsminfo.JIANCHA_QTY;
            parameters[17].Value = qsminfo.BULIANG_QTY;
            parameters[18].Value = qsminfo.BULIANGBILI;
            parameters[19].Value = qsminfo.BULIANGDC;
            parameters[20].Value = qsminfo.ZAIXIAN_QTY;
            parameters[21].Value = qsminfo.KUCUN_QTY;
            parameters[22].Value = qsminfo.TUIHUO_STATUS;
            parameters[23].Value = qsminfo.TUIHUO_QTY;
            parameters[24].Value = qsminfo.HAPPEN_ADDRESS;
            parameters[25].Value = qsminfo.TIJIAO_STATUS;
            parameters[26].Value = qsminfo.TIJIAO_TYPE;
            parameters[27].Value = qsminfo.NOTES;
            parameters[28].Value = qsminfo.DCJIAOHUO_QTY;
            parameters[29].Value = qsminfo.ZAITU_STATUS;
            parameters[30].Value = qsminfo.ZAITU_QTY;
            parameters[31].Value = qsminfo.ZAITUCHULI_TYPE;
            parameters[32].Value = qsminfo.CANGCUN_STATUS;
            parameters[33].Value = qsminfo.CANGCUNCHULI_TYPE;
            parameters[34].Value = qsminfo.INFO_CONTENT;
            parameters[35].Value = qsminfo.FIRST_REPLY_DATE;
            parameters[36].Value = qsminfo.LAST_REPLY_DATE;
            parameters[37].Value = qsminfo.CONF_CONTENT;
            parameters[38].Value = qsminfo.CLOSE_DATE;
            parameters[39].Value = qsminfo.STATUS;

            #endregion

            ///
            int result = 0;

            #region 数据库操作
            try
            {
                dbHelper.ExecuteCommandProc(sql, parameters);
                result = int.Parse(parameters[0].Value.ToString());
                qsminfo.RKEY = int.Parse(parameters[1].Value.ToString());
            }
            catch (Exception e)
            {
                ///message ID
                result = 2;
            }
            finally
            {
                dbHelper.CloseConnection();
            }
            #endregion

            return result;
        }

        #endregion

        #region 修改
        ///<sumary>
        ///修改  
        ///</sumary>
        /// <param name="qsminfo">qsminfo对象</param>
        ///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
        public int Update(QSMInfo qsminfo)
        {
            #region
            string sql = "sp_TABLE_CAR_QSM_Update";
            //=====

            SqlParameter[] parameters ={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@rkey",SqlDbType.Int,4),
			new SqlParameter("@serialNo",SqlDbType.VarChar,20),
			new SqlParameter("@ent_Date",SqlDbType.DateTime,8),
			new SqlParameter("@ent_user",SqlDbType.VarChar,50),
			new SqlParameter("@tousu_level",SqlDbType.VarChar,20),
			new SqlParameter("@tousu_type",SqlDbType.VarChar,20),
			new SqlParameter("@cust_Code",SqlDbType.VarChar,20),
			new SqlParameter("@cust_Name",SqlDbType.VarChar,100),
			new SqlParameter("@factory_Name",SqlDbType.VarChar,20),
			new SqlParameter("@happen_Date",SqlDbType.DateTime,8),
			new SqlParameter("@cust_MaterialNo",SqlDbType.VarChar,200),
			new SqlParameter("@interalNo",SqlDbType.VarChar,50),
			new SqlParameter("@require_Date",SqlDbType.DateTime,8),
			new SqlParameter("@CAR_Content",SqlDbType.VarChar,8000),
			new SqlParameter("@chuhuo_qty",SqlDbType.Decimal,9),
			new SqlParameter("@jiancha_qty",SqlDbType.Decimal,9),
			new SqlParameter("@buliang_qty",SqlDbType.Decimal,9),
			new SqlParameter("@buliangbili",SqlDbType.Decimal,5),
			new SqlParameter("@buliangDC",SqlDbType.VarChar,50),
			new SqlParameter("@zaixian_qty",SqlDbType.Decimal,9),
			new SqlParameter("@kucun_qty",SqlDbType.Decimal,9),
			new SqlParameter("@tuihuo_status",SqlDbType.Int,4),
			new SqlParameter("@tuihuo_qty",SqlDbType.Decimal,9),
			new SqlParameter("@happen_address",SqlDbType.Int,4),
			new SqlParameter("@tijiao_status",SqlDbType.Int,4),
			new SqlParameter("@tijiao_type",SqlDbType.Int,4),
			new SqlParameter("@notes",SqlDbType.VarChar,8000),
			new SqlParameter("@dcjiaohuo_qty",SqlDbType.Decimal,9),
			new SqlParameter("@zaitu_status",SqlDbType.Int,4),
			new SqlParameter("@zaitu_qty",SqlDbType.Decimal,9),
			new SqlParameter("@zaituchuli_type",SqlDbType.Int,4),
			new SqlParameter("@cangcun_status",SqlDbType.Int,4),
			new SqlParameter("@cangcunchuli_type",SqlDbType.Int,4),
			new SqlParameter("@info_content",SqlDbType.VarChar,8000),
			new SqlParameter("@first_reply_date",SqlDbType.DateTime,8),
			new SqlParameter("@last_reply_date",SqlDbType.DateTime,8),
			new SqlParameter("@conf_content",SqlDbType.VarChar,8000),
			new SqlParameter("@close_date",SqlDbType.DateTime,8),
            new SqlParameter("@status",SqlDbType.Int,4)
			};
            parameters[0].Value = 1;
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[1].Value = qsminfo.RKEY;
            parameters[2].Value = qsminfo.SERIALNO;
            parameters[3].Value = qsminfo.ENT_DATE;
            parameters[4].Value = qsminfo.ENT_USER;
            parameters[5].Value = qsminfo.TOUSU_LEVEL;
            parameters[6].Value = qsminfo.TOUSU_TYPE;
            parameters[7].Value = qsminfo.CUST_CODE;
            parameters[8].Value = qsminfo.CUST_NAME;
            parameters[9].Value = qsminfo.FACTORY_NAME;
            parameters[10].Value = qsminfo.HAPPEN_DATE;
            parameters[11].Value = qsminfo.CUST_MATERIALNO;
            parameters[12].Value = qsminfo.INTERALNO;
            parameters[13].Value = qsminfo.REQUIRE_DATE;
            parameters[14].Value = qsminfo.CAR_CONTENT;
            parameters[15].Value = qsminfo.CHUHUO_QTY;
            parameters[16].Value = qsminfo.JIANCHA_QTY;
            parameters[17].Value = qsminfo.BULIANG_QTY;
            parameters[18].Value = qsminfo.BULIANGBILI;
            parameters[19].Value = qsminfo.BULIANGDC;
            parameters[20].Value = qsminfo.ZAIXIAN_QTY;
            parameters[21].Value = qsminfo.KUCUN_QTY;
            parameters[22].Value = qsminfo.TUIHUO_STATUS;
            parameters[23].Value = qsminfo.TUIHUO_QTY;
            parameters[24].Value = qsminfo.HAPPEN_ADDRESS;
            parameters[25].Value = qsminfo.TIJIAO_STATUS;
            parameters[26].Value = qsminfo.TIJIAO_TYPE;
            parameters[27].Value = qsminfo.NOTES;
            parameters[28].Value = qsminfo.DCJIAOHUO_QTY;
            parameters[29].Value = qsminfo.ZAITU_STATUS;
            parameters[30].Value = qsminfo.ZAITU_QTY;
            parameters[31].Value = qsminfo.ZAITUCHULI_TYPE;
            parameters[32].Value = qsminfo.CANGCUN_STATUS;
            parameters[33].Value = qsminfo.CANGCUNCHULI_TYPE;
            parameters[34].Value = qsminfo.INFO_CONTENT;
            parameters[35].Value = qsminfo.FIRST_REPLY_DATE;
            parameters[36].Value = qsminfo.LAST_REPLY_DATE;
            parameters[37].Value = qsminfo.CONF_CONTENT;
            parameters[38].Value = qsminfo.CLOSE_DATE;
            parameters[39].Value = qsminfo.STATUS;

            //===

            #endregion
            ///
            int result = 0;
            #region 数据库操作
            try
            {
                dbHelper.ExecuteCommandProc(sql, parameters);
                result = int.Parse(parameters[0].Value.ToString());
            }
            catch (Exception e)
            {
                result = 2;
            }
            finally
            {
                dbHelper.CloseConnection();
            }
            #endregion

            return result;
        }
        #endregion

        #region 删除

        ///<sumary>
        /// 删除  
        ///</sumary>
        /// <param name="qsminfo">对象</param>
        ///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
        public int Delete(QSMInfo qsminfo)
        {
            #region
            string sql = "sp_TABLE_CAR_QSM_Delete";
            //=========================
            SqlParameter[] parameters ={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@RKEY",SqlDbType.Int,4)};

            parameters[0].Value = 1;
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[1].Value = qsminfo.RKEY;


            //=========================
            #endregion
            ///
            int result = 0;
            #region
            try
            {

                dbHelper.ExecuteCommandProc(sql, parameters);
                result = int.Parse(parameters[0].Value.ToString());
            }
            catch (Exception e)
            {
                result = 2;
            }
            finally
            {
                dbHelper.CloseConnection();
            }
            #endregion

            return result;
        }

        ///<sumary>
        /// 删除  
        ///</sumary>
        /// <param name="qsminfo">对象</param>
        ///<returns>返回操作所影响的行数</returns>		
        public int DeleteByrkey(int rkey)
        {
            #region
            string sql = "delete from dbo.TABLE_CAR_QSM where rkey='" + rkey + "'";
            int result = 0;

            try
            {
                dbHelper.ExecuteCommand(sql);
                result = 0;
            }
            catch (Exception e)
            {
                result = 2;
                throw e;
            }
            finally
            {
                dbHelper.CloseConnection();
            }
            #endregion

            return result;
        }


        #endregion

        #region 查
        ///<sumary>
        ///	通过主键获取数据对象
        ///</sumary>
        /// <param name="rkey">rkey</param>
        ///<returns>qsminfo对象</returns>		
        public QSMInfo getQSMInfoByrkey(int rkey)
        {
            #region SQL
            string sql = @"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(serialno,'') as serialno
				,
				ent_date
				,
				isNull(ent_user,'') as ent_user
				,
				isNull(tousu_level,'') as tousu_level
				,
				isNull(tousu_type,'') as tousu_type
				,
				isNull(cust_code,'') as cust_code
				,
				isNull(cust_name,'') as cust_name
				,
				isNull(factory_name,'') as factory_name
				,
				happen_date
				,
				isNull(cust_materialno,'') as cust_materialno
				,
				isNull(interalno,'') as interalno
				,
				require_date
				,
				isNull(car_content,'') as car_content
				,
				isNull(chuhuo_qty,0) as chuhuo_qty
				,
				isNull(jiancha_qty,0) as jiancha_qty
				,
				isNull(buliang_qty,0) as buliang_qty
				,
				isNull(buliangbili,0) as buliangbili
				,
				isNull(buliangdc,0) as buliangdc
				,
				isNull(zaixian_qty,0) as zaixian_qty
				,
				isNull(kucun_qty,0) as kucun_qty
				,
				isNull(tuihuo_status,0) as tuihuo_status
				,
				isNull(tuihuo_qty,0) as tuihuo_qty
				,
				isNull(happen_address,0) as happen_address
				,
				isNull(tijiao_status,0) as tijiao_status
				,
				isNull(tijiao_type,0) as tijiao_type
				,
				isNull(notes,'') as notes
				,
				isNull(dcjiaohuo_qty,0) as dcjiaohuo_qty
				,
				isNull(zaitu_status,0) as zaitu_status
				,
				isNull(zaitu_qty,0) as zaitu_qty
				,
				isNull(zaituchuli_type,0) as zaituchuli_type
				,
				isNull(cangcun_status,0) as cangcun_status
				,
				isNull(cangcunchuli_type,0) as cangcunchuli_type
				,
				isNull(info_content,'') as info_content
				,
				first_reply_date
				,
				last_reply_date
				,
				isNull(conf_content,'') as conf_content
				,
				close_date
                ,
                isNull(status,0) as status
				
			from TABLE_CAR_QSM where rkey='{0}'";

            #endregion
            ///定义返回对象
            QSMInfo qsminfo = null;
            #region 数据库操作
            try
            {

                qsminfo = new QSMInfo();


                using (DataTable tb = dbHelper.GetDataSet(string.Format(sql, rkey)))
                {
                    foreach (DataRow row in tb.Rows)
                    {

                        qsminfo.RKEY = int.Parse(row["rkey"].ToString());
                        qsminfo.SERIALNO = row["serialNo"].ToString();
                        if (row["ent_Date"].ToString() != "")
                        {
                            qsminfo.ENT_DATE = DateTime.Parse(row["ent_Date"].ToString());
                        }
                        qsminfo.ENT_USER = row["ent_user"].ToString();
                        qsminfo.TOUSU_LEVEL = row["tousu_level"].ToString();
                        qsminfo.TOUSU_TYPE = row["tousu_type"].ToString();
                        qsminfo.CUST_CODE = row["cust_Code"].ToString();
                        qsminfo.CUST_NAME = row["cust_Name"].ToString();
                        qsminfo.FACTORY_NAME = row["factory_Name"].ToString();
                        if(row["happen_Date"].ToString() != "")
                        {
                        qsminfo.HAPPEN_DATE = DateTime.Parse(row["happen_Date"].ToString());
                        }
                        qsminfo.CUST_MATERIALNO = row["cust_MaterialNo"].ToString();
                        qsminfo.INTERALNO = row["interalNo"].ToString();
                        if (row["require_Date"].ToString() != "")
                        {
                        qsminfo.REQUIRE_DATE = DateTime.Parse(row["require_Date"].ToString());
                        }
                        qsminfo.CAR_CONTENT = row["CAR_Content"].ToString();
                        qsminfo.CHUHUO_QTY = decimal.Parse(row["chuhuo_qty"].ToString());
                        qsminfo.JIANCHA_QTY = decimal.Parse(row["jiancha_qty"].ToString());
                        qsminfo.BULIANG_QTY = decimal.Parse(row["buliang_qty"].ToString());
                        qsminfo.BULIANGBILI = decimal.Parse(row["buliangbili"].ToString());
                        qsminfo.BULIANGDC = row["buliangDC"].ToString();
                        qsminfo.ZAIXIAN_QTY = decimal.Parse(row["zaixian_qty"].ToString());
                        qsminfo.KUCUN_QTY = decimal.Parse(row["kucun_qty"].ToString());
                        qsminfo.TUIHUO_STATUS = int.Parse(row["tuihuo_status"].ToString());
                        qsminfo.TUIHUO_QTY = decimal.Parse(row["tuihuo_qty"].ToString());
                        qsminfo.HAPPEN_ADDRESS = int.Parse(row["happen_address"].ToString());
                        qsminfo.TIJIAO_STATUS = int.Parse(row["tijiao_status"].ToString());
                        qsminfo.TIJIAO_TYPE = int.Parse(row["tijiao_type"].ToString());
                        qsminfo.NOTES = row["notes"].ToString();
                        qsminfo.DCJIAOHUO_QTY = decimal.Parse(row["dcjiaohuo_qty"].ToString());
                        qsminfo.ZAITU_STATUS = int.Parse(row["zaitu_status"].ToString());
                        qsminfo.ZAITU_QTY = decimal.Parse(row["zaitu_qty"].ToString());
                        qsminfo.ZAITUCHULI_TYPE = int.Parse(row["zaituchuli_type"].ToString());
                        qsminfo.CANGCUN_STATUS = int.Parse(row["cangcun_status"].ToString());
                        qsminfo.CANGCUNCHULI_TYPE = int.Parse(row["cangcunchuli_type"].ToString());
                        qsminfo.INFO_CONTENT = row["info_content"].ToString();
                        if (row["first_reply_date"].ToString() != "")
                        {
                        qsminfo.FIRST_REPLY_DATE = DateTime.Parse(row["first_reply_date"].ToString());
                        }
                        if (row["last_reply_date"].ToString() != "")
                        {
                        qsminfo.LAST_REPLY_DATE = DateTime.Parse(row["last_reply_date"].ToString());
                        }
                        qsminfo.CONF_CONTENT = row["conf_content"].ToString();
                        if (row["close_date"].ToString() != "")
                        {
                        qsminfo.CLOSE_DATE = DateTime.Parse(row["close_date"].ToString());
                        }
                        qsminfo.STATUS = int.Parse(row["status"].ToString());



                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                dbHelper.CloseConnection();
            }
            #endregion

            return qsminfo;
        }


        ///<sumary>
        ///	通过获取所有数据对象
        ///</sumary>
        public IList<QSMInfo> FindAllQSMInfo()
        {
            return FindBySql("1=1");
        }


        ///<sumary>
        ///	通过SQL语句获取数据对象
        ///</sumary>
        /// <param name="sqlWhere">sqlWhere参数条件</param>
        ///<returns>IList<qsminfo>数据集合</returns>		
        public IList<QSMInfo> FindBySql(string sqlWhere)
        {
            #region SQL
            string sql = @"select 
				isNull(rkey,0) as rkey
				,
				isNull(serialno,'') as serialno
				,
				ent_date
				,
				isNull(ent_user,'') as ent_user
				,
				isNull(tousu_level,'') as tousu_level
				,
				isNull(tousu_type,'') as tousu_type
				,
				isNull(cust_code,'') as cust_code
				,
				isNull(cust_name,'') as cust_name
				,
				isNull(factory_name,'') as factory_name
				,
				happen_date
				,
				isNull(cust_materialno,'') as cust_materialno
				,
				isNull(interalno,'') as interalno
				,
				require_date
				,
				isNull(car_content,'') as car_content
				,
				isNull(chuhuo_qty,0) as chuhuo_qty
				,
				isNull(jiancha_qty,0) as jiancha_qty
				,
				isNull(buliang_qty,0) as buliang_qty
				,
				isNull(buliangbili,0) as buliangbili
				,
				isNull(buliangdc,0) as buliangdc
				,
				isNull(zaixian_qty,0) as zaixian_qty
				,
				isNull(kucun_qty,0) as kucun_qty
				,
				isNull(tuihuo_status,0) as tuihuo_status
				,
				isNull(tuihuo_qty,0) as tuihuo_qty
				,
				isNull(happen_address,0) as happen_address
				,
				isNull(tijiao_status,0) as tijiao_status
				,
				isNull(tijiao_type,0) as tijiao_type
				,
				isNull(notes,'') as notes
				,
				isNull(dcjiaohuo_qty,0) as dcjiaohuo_qty
				,
				isNull(zaitu_status,0) as zaitu_status
				,
				isNull(zaitu_qty,0) as zaitu_qty
				,
				isNull(zaituchuli_type,0) as zaituchuli_type
				,
				isNull(cangcun_status,0) as cangcun_status
				,
				isNull(cangcunchuli_type,0) as cangcunchuli_type
				,
				isNull(info_content,'') as info_content
				,
				first_reply_date
				,
				last_reply_date
				,
				isNull(conf_content,'') as conf_content
				,
				close_date
                ,
                isNull(status,0) as status
				
			from table_car_qsm";
            if (sqlWhere.Length > 0)
            {
                sql = sql + " where " + sqlWhere;
            }
            #endregion

            IList<QSMInfo> resultList = new List<QSMInfo>();

            #region
            try
            {

                using (DataTable tb = dbHelper.GetDataSet(sql))
                {
                    foreach (DataRow row in tb.Rows)
                    {
                        QSMInfo qsminfo = new QSMInfo();

                        qsminfo.RKEY = int.Parse(row["rkey"].ToString());

                        qsminfo.SERIALNO = row["serialNo"].ToString();
                        if (row["ent_Date"].ToString() != "")
                        {
                            qsminfo.ENT_DATE = DateTime.Parse(row["ent_Date"].ToString());
                        }
                        qsminfo.ENT_USER = row["ent_user"].ToString();
                        qsminfo.TOUSU_LEVEL = row["tousu_level"].ToString();
                        qsminfo.TOUSU_TYPE = row["tousu_type"].ToString();
                        qsminfo.CUST_CODE = row["cust_Code"].ToString();
                        qsminfo.CUST_NAME = row["cust_Name"].ToString();
                        qsminfo.FACTORY_NAME = row["factory_Name"].ToString();
                        if (row["happen_Date"].ToString() != "")
                        {
                            qsminfo.HAPPEN_DATE = DateTime.Parse(row["happen_Date"].ToString());
                        }
                        qsminfo.CUST_MATERIALNO = row["cust_MaterialNo"].ToString();
                        qsminfo.INTERALNO = row["interalNo"].ToString();
                        if (row["require_Date"].ToString() != "")
                        {
                            qsminfo.REQUIRE_DATE = DateTime.Parse(row["require_Date"].ToString());
                        }
                        qsminfo.CAR_CONTENT = row["CAR_Content"].ToString();
                        qsminfo.CHUHUO_QTY = decimal.Parse(row["chuhuo_qty"].ToString());
                        qsminfo.JIANCHA_QTY = decimal.Parse(row["jiancha_qty"].ToString());
                        qsminfo.BULIANG_QTY = decimal.Parse(row["buliang_qty"].ToString());
                        qsminfo.BULIANGBILI = decimal.Parse(row["buliangbili"].ToString());
                        qsminfo.BULIANGDC = row["buliangDC"].ToString();
                        qsminfo.ZAIXIAN_QTY = decimal.Parse(row["zaixian_qty"].ToString());
                        qsminfo.KUCUN_QTY = decimal.Parse(row["kucun_qty"].ToString());
                        qsminfo.TUIHUO_STATUS = int.Parse(row["tuihuo_status"].ToString());
                        qsminfo.TUIHUO_QTY = decimal.Parse(row["tuihuo_qty"].ToString());
                        qsminfo.HAPPEN_ADDRESS = int.Parse(row["happen_address"].ToString());
                        qsminfo.TIJIAO_STATUS = int.Parse(row["tijiao_status"].ToString());
                        qsminfo.TIJIAO_TYPE = int.Parse(row["tijiao_type"].ToString());
                        qsminfo.NOTES = row["notes"].ToString();
                        qsminfo.DCJIAOHUO_QTY = decimal.Parse(row["dcjiaohuo_qty"].ToString());
                        qsminfo.ZAITU_STATUS = int.Parse(row["zaitu_status"].ToString());
                        qsminfo.ZAITU_QTY = decimal.Parse(row["zaitu_qty"].ToString());
                        qsminfo.ZAITUCHULI_TYPE = int.Parse(row["zaituchuli_type"].ToString());
                        qsminfo.CANGCUN_STATUS = int.Parse(row["cangcun_status"].ToString());
                        qsminfo.CANGCUNCHULI_TYPE = int.Parse(row["cangcunchuli_type"].ToString());
                        qsminfo.INFO_CONTENT = row["info_content"].ToString();
                        if (row["first_reply_date"].ToString() != "")
                        {
                            qsminfo.FIRST_REPLY_DATE = DateTime.Parse(row["first_reply_date"].ToString());
                        }
                        if (row["last_reply_date"].ToString() != "")
                        {
                            qsminfo.LAST_REPLY_DATE = DateTime.Parse(row["last_reply_date"].ToString());
                        }
                        qsminfo.CONF_CONTENT = row["conf_content"].ToString();
                        if (row["close_date"].ToString() != "")
                        {
                            qsminfo.CLOSE_DATE = DateTime.Parse(row["close_date"].ToString());
                        }
                        qsminfo.STATUS = int.Parse(row["status"].ToString());

                        resultList.Add(qsminfo);
                    }
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                dbHelper.CloseConnection();
            }
            #endregion

            return resultList;
        }

        ///<sumary>
        ///	通过SQL语句获取数据
        ///</sumary>
        /// <param name="sql">sql语句</param>
        ///<returns>DataTable</returns>

        public DataTable getDataSet(string sql)
        {
            DataTable dt = null;
            try
            {
                dt = dbHelper.GetDataSet(sql);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbHelper.CloseConnection();
            }
            return dt;


        }
        #region 获取单号
        public string GetSerialNo()
        {
            string sql = "exec PROC_CAR_GetQSMSerialNo";
            System.Data.SqlClient.SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = new SqlConnection(connectionString);
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
        #endregion

}



