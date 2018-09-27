using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace FounderTecInfoSys.Addin.CAR.ChildApproval
{
    /// <summary>
    ///ChildApproval 的摘要说明
    ///处理开立流程嵌入到回复流程处理类
    ///Add by ZhangJS 2014-12-31
    /// </summary>
    public class ChildApproval
    {
        DBHelper dbHelper = null;

        public ChildApproval()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public ChildApproval(DBHelper DB)
        {
            this.dbHelper = DB;
        }

        public ChildApproval(int factoryid)
        {
            this.dbHelper = new DBHelper(factoryid);
        }

        /// <summary>
        /// 保存子流程数据
        /// </summary>
        /// <param name="approvalType">子流程类型</param>
        /// <param name="Data0498_rkey">嵌入子流程位置</param>    
        /// <returns></returns>
        public int SaveChildApproval(ChildApprovalType approvalType, decimal Data0497_rkey, decimal Data0498_rkey)
        {
            //默认为自动连接
            return SaveChildApproval(approvalType, Data0497_rkey, Data0498_rkey, 1);
        }

        /// <summary>
        /// 保存子流程数据
        /// </summary>
        /// <param name="approvalType">子流程类型</param>
        /// <param name="Data0498_rkey">嵌入子流程位置</param>
        /// <param name="AUTOJOIN">是否自动连接</param>
        /// <returns></returns>
        public int SaveChildApproval(ChildApprovalType approvalType, decimal Data0497_rkey, decimal Data0498_rkey, int AUTOJOIN)
        {
            //默认子流程设置为0, 为自动获取
            return SaveChildApproval(approvalType, Data0497_rkey, Data0498_rkey, AUTOJOIN, 0);
        }

        /// <summary>
        /// 保存子流程数据
        /// </summary>
        /// <param name="approvalType">子流程类型</param>
        /// <param name="Data0498_rkey">嵌入子流程位置</param>
        /// <param name="AUTOJOIN">是否自动连接</param>
        /// <returns></returns>
        public int SaveChildApproval(ChildApprovalType approvalType, decimal Data0497_rkey, decimal Data0498_rkey, int AUTOJOIN, int CHILDAPPROVAL_RKEY)
        {
            string save_sql = string.Format(@"
            delete DATA0498_EXTENT where CHILD_TYPE={0} and DATA0498_RKEY in (
	            select RKEY from DATA0498 where APPROVAL_ROUTE_PTR={1}
            )
            insert into DATA0498_EXTENT(DATA0498_RKEY,CHILD_TYPE,AUTOJOIN,CHILDAPPROVAL_RKEY)
            values({2},{0},{3},{4})
            ", (int)approvalType,
                 Data0497_rkey,
                 Data0498_rkey,
                 AUTOJOIN,
                 CHILDAPPROVAL_RKEY);
            try
            {
                dbHelper.ExecuteCommand(save_sql);
                //dbHelper.ExecuteSql(save_sql);
            }
            catch (Exception ex)
            {
                throw new Exception("保存子流程失败!");
            }

            return 0;
        }

        //根据流程获取是否设置了子流程
        public DataTable GetChildApprovalById(decimal data0497_rkey)
        {
            string getApproval_sql = string.Format(@"
            select RKEY,DATA0498_RKEY,CHILD_TYPE,AUTOJOIN,CHILDAPPROVAL_RKEY  from DATA0498_EXTENT where DATA0498_RKEY in (
	            select RKEY from DATA0498 where APPROVAL_ROUTE_PTR={0}
            )", data0497_rkey);

            return this.dbHelper.GetDataSet(getApproval_sql);
            //return this.dbHelper.QueryGetDataTable(getApproval_sql);
        }

        //根据流程获取是否设置了子流程
        public DataTable GetChildApprovalById(decimal data0497_rkey, ChildApprovalType approvalType)
        {
            string getApproval_sql = string.Format(@"
            select RKEY,DATA0498_RKEY,CHILD_TYPE,AUTOJOIN,CHILDAPPROVAL_RKEY  from DATA0498_EXTENT where CHILD_TYPE={1} and  DATA0498_RKEY in (
	            select RKEY from DATA0498 where APPROVAL_ROUTE_PTR={0}
            )", data0497_rkey, (int)approvalType);

            return this.dbHelper.GetDataSet(getApproval_sql);
        }

        //根据流程rkey和子流程类型删除设置
        public int DeleteChildApprovalByID(decimal data0497_rkey, ChildApprovalType approvalType)
        {
            string delete_sql = string.Format(@"delete DATA0498_EXTENT where CHILD_TYPE={1} and  DATA0498_RKEY in (
	            select RKEY from DATA0498 where APPROVAL_ROUTE_PTR={0}
            )", data0497_rkey, (int)approvalType);

            try
            {
                dbHelper.ExecuteCommand(delete_sql);
            }
            catch (Exception ex)
            {
                throw new Exception("删除子流程失败!");
            }

            return 0;
        }
    }

    //子流程类型
    public enum ChildApprovalType
    {
        KL_APPENDTO_HF = 1  //开立流程, 回复流程自动附加开立流程
    }
}