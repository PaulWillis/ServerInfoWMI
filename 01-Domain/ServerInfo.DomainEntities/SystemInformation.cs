using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace ServerInfo.DomainEntities
{

    public class DontInclude
    {
        public static List<String> DontIncludeList()
        {
            List<String> res = new List<String>();
            res.Add("COMPRESSED");


            return res;
        }

    }
    public class SysInformation
    {

        public List<String> GetInfo(string Username, string Password, string IP, string Win32class)
        {
            return RemoteComputerInfo(Username, Password, IP, Win32class);

        }


        private List<String> RemoteComputerInfo(string Username, string Password, string IP, string sWin32class)
        {
            List<String> resultList = new List<String>();

            ConnectionOptions options = new ConnectionOptions();
            options.Username = Username;
            options.Password = Password;
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;
            try
            {
                ManagementScope mgtScope = new ManagementScope(string.Format("\\\\{0}\\root\\cimv2", IP), options);
                mgtScope.Connect();

                ObjectGetOptions objectGetOptions = new ObjectGetOptions();
                ManagementPath mgtPath = new ManagementPath(sWin32class);
                ManagementClass mgtClass = new ManagementClass(mgtScope, mgtPath, objectGetOptions);

                PropertyDataCollection prptyDataCollection = mgtClass.Properties;

                foreach (ManagementObject mgtObject in mgtClass.GetInstances())
                {
                    foreach (PropertyData property in prptyDataCollection)
                    {
                        try
                        {
                            string mobjvalue = "";
                            if (mgtObject.Properties[property.Name].Value == null)
                            {
                                mobjvalue = "null";
                            }
                            else
                            {
                                mobjvalue = mgtObject.Properties[property.Name].Value.ToString();
                            }

                            if (ShouldInclude(property.Name))
                            {
                                resultList.Add(string.Format(property.Name + ":  " + mobjvalue));
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultList.Add(string.Format("Can't Connect to Server: {0}\n{1}", IP, ex.Message));
            }

            return resultList;
        }

        private bool ShouldInclude(string p)
        {
            bool res = true;
            if (DontInclude.DontIncludeList().Contains(p.ToUpper()))
            {
                res = false;
            }

            return res;
        }

    }
}
