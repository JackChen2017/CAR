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
    /// ���ݷ��ʲ�   Table_CAR_SADAL
    /// </summary>
    public partial class SADAL
    {

        #region   �ֶ� and ����
        DBHelper dbHelper = null;

        ///<sumary>
        ///�ֶ� ����ָ��Ŀ�����ݿ�
        ///</sumary>
        private int factoryID = 0;

        ///<sumary>
        ///���� ����ָ��Ŀ�����ݿ�
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
        #region ���캯��
        /// <summary>
        /// 
        /// </summary>
        public SADAL()
        {
        }


        public SADAL(int factoryID)
        {
            this.FactoryID = factoryID;
            this.dbHelper = new DBHelper(factoryID);
        }

        #endregion

        #region ���

        /// <summary>
        /// �����ݿ��в���һ���¼�¼��
        /// </summary>
        /// <param name="Table_CAR_SA">table_car_sa����</param>
        /// <returns>�²����¼�ı��</returns>
        public int Add(SAInfo sa)
        {
            #region /// ����SQL�洢���̽������
            string sql = "sp_Table_CAR_SA_Add";
            ///�洢������
            SqlParameter[] parameters ={
			new SqlParameter("@returnID",SqlDbType.Int),
			///new SqlParameter("@rkey",SqlDbType.Int,4),
			new SqlParameter("@rkey",SqlDbType.Float),
			new SqlParameter("@serialNo",SqlDbType.VarChar,20),
			new SqlParameter("@ent_date",SqlDbType.DateTime,8),
			new SqlParameter("@ent_user",SqlDbType.VarChar,50),
			new SqlParameter("@car_content",SqlDbType.VarChar,8000),
			new SqlParameter("@close_date",SqlDbType.DateTime,8),
            new SqlParameter("@status",SqlDbType.Float)
			};

            parameters[0].Value = 0;
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[1].Direction = ParameterDirection.InputOutput;
            parameters[1].Value = sa.RKEY;
            parameters[2].Value = sa.SERIALNO;
            parameters[3].Value = sa.ENT_DATE;
            parameters[4].Value = sa.ENT_USER;
            parameters[5].Value = sa.CAR_CONTENT;
            parameters[6].Value = sa.CLOSE_DATE;
            parameters[7].Value = sa.STATUS;

            #endregion

            ///
            int result = 0;

            #region ���ݿ����
            try
            {
                dbHelper.ExecuteCommandProc(sql, parameters);
                result = int.Parse(parameters[0].Value.ToString());
                sa.RKEY = int.Parse(parameters[1].Value.ToString());
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

        #region �޸�
        ///<sumary>
        ///�޸�  
        ///</sumary>
        /// <param name="Table_CAR_SA">table_car_sa����</param>
        ///<returns>����INT���ͺ�, 0Ϊ�����ɹ�, ��0����ʧ��.</returns>
        public int Update(SAInfo sa)
        {
            #region
            string sql = "sp_Table_CAR_SA_Update";
            //=====

            SqlParameter[] parameters ={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@rkey",SqlDbType.Int,4),
			new SqlParameter("@serialNo",SqlDbType.VarChar,20),
			new SqlParameter("@ent_date",SqlDbType.DateTime,8),
			new SqlParameter("@ent_user",SqlDbType.VarChar,50),
			new SqlParameter("@car_content",SqlDbType.VarChar,8000),
			new SqlParameter("@close_date",SqlDbType.DateTime,8),
            new SqlParameter("@status",SqlDbType.Int),
			};
            parameters[0].Value = 1;
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[1].Value = sa.RKEY;
            parameters[2].Value = sa.SERIALNO;
            parameters[3].Value = sa.ENT_DATE;
            parameters[4].Value = sa.ENT_USER;
            parameters[5].Value = sa.CAR_CONTENT;
            parameters[6].Value = sa.CLOSE_DATE;
            parameters[7].Value = sa.STATUS;

            //===

            #endregion
            ///
            int result = 0;
            #region ���ݿ����
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

        #region ɾ��

        ///<sumary>
        /// ɾ��  
        ///</sumary>
        /// <param name="table_car_sa">����</param>
        ///<returns>����INT���ͺ�, 0Ϊ�����ɹ�, ��0����ʧ��.</returns>		
        public int Delete(SAInfo sa)
        {
            #region
            string sql = "sp_Table_CAR_SA_Delete";
            //=========================
            SqlParameter[] parameters ={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@RKEY",SqlDbType.Int,4)};

            parameters[0].Value = 1;
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[2].Value = sa.RKEY;


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
        /// ɾ��  
        ///</sumary>
        /// <param name="table_car_sa">����</param>
        ///<returns>���ز�����Ӱ�������</returns>		
        public int DeleteByrkey(int rkey)
        {
            #region
            string sql = "delete from dbo.Table_CAR_SA where rkey='" + rkey + "'";
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

        #region ��
        ///<sumary>
        ///	ͨ��������ȡ���ݶ���
        ///</sumary>
        /// <param name="rkey">rkey</param>
        ///<returns>Table_CAR_SA����</returns>		
        public SAInfo GetSAInfoByrkey(int rkey)
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
				isNull(car_content,'') as car_content
				,
				close_date
                ,
                isnull(status,0) as status
				
			from Table_CAR_SA where rkey='{0}'";

            #endregion
            ///���巵�ض���
            SAInfo sa = null;
            #region ���ݿ����
            try
            {

                sa = new SAInfo();


                using (DataTable tb = dbHelper.GetDataSet(string.Format(sql, rkey)))
                {
                    foreach (DataRow row in tb.Rows)
                    {

                        sa.RKEY = int.Parse(row["rkey"].ToString());
                        sa.SERIALNO = row["serialNo"].ToString();
                        sa.ENT_DATE = DateTime.Parse(row["ent_date"].ToString());
                        sa.ENT_USER = row["ent_user"].ToString();
                        sa.CAR_CONTENT = row["car_content"].ToString();
                        sa.CLOSE_DATE = DateTime.Parse(row["close_date"].ToString());
                        sa.STATUS = int.Parse(row["status"].ToString());
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

            return sa;
        }


        ///<sumary>
        ///	ͨ����ȡ�������ݶ���
        ///</sumary>
        public IList<SAInfo> FindAllSAInfo()
        {
            return FindBySql("1=1");
        }


        ///<sumary>
        ///	ͨ��SQL����ȡ���ݶ���
        ///</sumary>
        /// <param name="sqlWhere">sqlWhere��������</param>
        ///<returns>IList<Table_CAR_SA>���ݼ���</returns>		
        public IList<SAInfo> FindBySql(string sqlWhere)
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
				isNull(car_content,'') as car_content
				,
				close_date
                ,
                isnull(status,0) as status
				
			from Table_CAR_SA";
            if (sqlWhere.Length > 0)
            {
                sql = sql + " where " + sqlWhere;
            }
            #endregion

            IList<SAInfo> resultList = new List<SAInfo>();

            #region
            try
            {

                using (DataTable tb = dbHelper.GetDataSet(sql))
                {
                    foreach (DataRow row in tb.Rows)
                    {
                        SAInfo sa = new SAInfo();

                        sa.RKEY = int.Parse(row["rkey"].ToString());

                        sa.SERIALNO = row["serialNo"].ToString();
                        sa.ENT_DATE = DateTime.Parse(row["ent_date"].ToString());
                        sa.ENT_USER = row["ent_user"].ToString();
                        sa.CAR_CONTENT = row["car_content"].ToString();
                        sa.CLOSE_DATE = DateTime.Parse(row["close_date"].ToString());
                        sa.STATUS = int.Parse(row["status"].ToString());

                        resultList.Add(sa);
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
        ///	ͨ��SQL����ȡ����
        ///</sumary>
        /// <param name="sql">sql���</param>
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
        #region ��ȡ����
        public string GetSerialNo()
        {
            string sql = "exec PROC_CAR_GetSASerialNo";
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



