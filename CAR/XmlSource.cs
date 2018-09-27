using System;
using System.Xml;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.IO;

namespace FounderTecInfoSys.Addin.CAR
{
    public class XmlSource 
    {
        public static string userRightFileName = System.Web.HttpContext.Current.Request.MapPath(".") + @"\File\RightList.xml";
        public static string userConfigFileName = System.Web.HttpContext.Current.Request.MapPath(".") + @"\File\UserConfig.xml";
        /// <summary>
        /// ����ĳȨ�޵�����ֵ
        /// </summary>
        /// <param name="rightName"></param>
        /// <returns></returns>
        public static int GetRightIndex(string rightName)
        {
            XmlDocument xmDoc = new XmlDocument();
            xmDoc.Load(userRightFileName);

            XmlNode rightList = xmDoc.SelectSingleNode("RightList");

            XmlNode rightItem = rightList.SelectSingleNode(rightName);

            //////û�����Ӧ��Ȩ����!
            if (rightItem == null)
            {
                return 0;
            }

            return Convert.ToInt32(rightItem.Attributes["index"].Value);
        }
        /// <summary>
        /// ��ͬ��DomainMasterPage�����hasRight,���ǲ�����admin��Ȩ��
        /// </summary>
        /// <param name="rightName"></param>
        /// <returns></returns>
        public static bool HasRight(string UserAD,string rightName)
        {
            bool flag = false;
            int rightIndexID = GetRightIndex(rightName);

            if (rightIndexID == 0)
            {
                flag = false;
            }
            XmlDocument xmDoc = new XmlDocument();
            xmDoc.Load(userConfigFileName);
            XmlNode parentNode = xmDoc.SelectSingleNode("UserConfig");

            XmlNode aimNode = null;
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.Attributes["UserAD"].Value == UserAD)
                {
                    aimNode = node;
                    break;
                }
            }
            if (aimNode == null)
            {
                flag = false;
            }
            //if (aimNode.Attributes["ConfigString"].Value.Contains(rightIndexID.ToString() + ","))
            //{
            //    flag = true;
            //}
            try
            {
                string a = aimNode.Attributes["ConfigString"].Value.Substring(rightIndexID, 1);
                if (a == "1")
                {
                    flag = true;
                }
            }
            catch
            {
                flag = false;
            }

            return flag;
        }
        /// <summary>
        /// �����û�Ȩ������ -1:����ʧ��   0:����ɹ�
        /// </summary>
        public static int SetUserConfig(string userAD,string configString)
        {
            int flag = 0;
            XmlDocument xmDoc = new XmlDocument();
            xmDoc.Load(userConfigFileName);
            XmlNode parentNode = xmDoc.SelectSingleNode("UserConfig");

            XmlNode aimNode = null;
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.Attributes["UserAD"].Value == userAD)
                {
                    aimNode = node;
                    break;
                }
            }
            if (aimNode == null)
            {
                aimNode = parentNode.ChildNodes[0].Clone();
            }
            try
            {
                parentNode.AppendChild(aimNode);
            }
            catch
            {
                flag = -1;
            }
            aimNode.Attributes["UserAD"].Value = userAD;
            aimNode.Attributes["ConfigString"].Value = configString;
            try
            {
                xmDoc.Save(userConfigFileName);
            }
            catch
            {
                flag = -1;
            }
            return flag;
        }
        /// <summary>
        /// ��ȡ�û�Ȩ�޵��ַ���
        /// </summary>
        /// <param name="userAD"></param>
        /// <returns></returns>
        public static string GetUserConfig(string userAD)
        { 
            XmlDocument xmDoc = new XmlDocument();
            xmDoc.Load(userConfigFileName);
            XmlNode parentNode = xmDoc.SelectSingleNode("UserConfig");

            XmlNode aimNode = null;
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.Attributes["UserAD"].Value == userAD)
                {
                    aimNode = node;
                    break;
                }
            }
            if (aimNode == null)
            {
                return "";
            }
            return aimNode.Attributes["ConfigString"].Value;

        }
        public static int DeleteUserConfig(string userAD)
        {
            int a = 0;
            XmlDocument xmDoc = new XmlDocument();
            xmDoc.Load(userConfigFileName);
            XmlNode parentNode = xmDoc.SelectSingleNode("UserConfig");

            XmlNode aimNode = null;
            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.Attributes["UserAD"].Value == userAD)
                {
                    aimNode = node;
                    break;
                }
            }
            if (aimNode == null)
            {
                a = 0;
            }
            else
            {
                parentNode.RemoveChild(aimNode);
                try
                {
                    xmDoc.Save(userConfigFileName);
                }
                catch
                {
                    a = -1;
                }
            }
            return a;
        }
        #region ���͵����ʼ���sql��ʽ public void SendEmail(string userad,string subject, string body)
        /// <summary>
        /// ���͵����ʼ���sql��ʽ
        /// </summary>
        /// <param name="userad">���͵�</param>
        /// <param name="subject">����</param>
        /// <param name="body">����</param>        
        public static void SendEmail(string userad, string subject, string body)
        {
            int start = userad.IndexOf("\\");
            string user = userad.Substring(start);
            user += "@founderpcb.com";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = "Proc_FS_sendmail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["0"].ConnectionString);

            cmd.Parameters.Add("@From", SqlDbType.VarChar);
            cmd.Parameters.Add("@To", SqlDbType.VarChar);
            cmd.Parameters.Add("@Bcc", SqlDbType.VarChar);
            cmd.Parameters.Add("@Subject", SqlDbType.VarChar);
            cmd.Parameters.Add("@Body", SqlDbType.VarChar);
            cmd.Parameters.Add("@stmp_server", SqlDbType.NVarChar);
            cmd.Parameters.Add("@email_user", SqlDbType.NVarChar);
            cmd.Parameters.Add("@email_pass", SqlDbType.NVarChar);

            System.Data.SqlClient.SqlParameterCollection parameters = cmd.Parameters;

            parameters[0].Value = "QSM_Admin";
            parameters[1].Value = user;
            parameters[2].Value = "";
            parameters[3].Value = subject;  //����
            parameters[4].Value = body;  //��������
            parameters[5].Value = "pcbmail01.founderpcb.com";
            parameters[6].Value = "pcbsql@founderpcb.com";
            parameters[7].Value = "windows";

            FounderTecInfoSys.Common.SQLBase.ERPSQLManager.GetInstance().ExecuteStoredProcedure(cmd);
        }
        #endregion
        

    }
}
