using ServerInfo.Domain.Interfaces;
using ServerInfo.DomainEntities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ServerInfo.Infrastructure.Data
{
    public class ServerRecordRepository : RepositoryBase, IServerRecordRepository
    {
        private DAL _dal; 

        public ServerRecordRepository(string connectionString) 
            : base(connectionString)
        {
            _dal = new DAL(_connectionString); 
        }



        public IQueryable<ServerRecord> GetServerRecordSet()
        {
            var res = _dal.LoadRecords<ServerRecord>("usp_GetServerInformation", CommandType.StoredProcedure);
            return res.AsQueryable();
        }

        public IQueryable<ServerConnection> GetServerSet()
        {

            List<ServerConnection> res = new List<ServerConnection>();
            System.Data.DataTable table =  _dal.GetDataTable("select ServerDomain,ServerIP,DomainAlias From Servers");

            foreach (System.Data.DataRow row in table.Rows)
            {
                ServerConnection rec = new ServerConnection
                {
                    ServerDomain = row["ServerDomain"].ToString(),
                    ServerIP = row["ServerIP"].ToString(),
                    DomainAlias = row["DomainAlias"].ToString()
                };

                res.Add(rec);
            }

            return res.AsQueryable();
        }

        
        public void GetServerInfo(string ServerIP, ServerEnums.Domain DomainLogin, List<Login> Logins, DateTime RunTime)
        {
            ServerRecord sr = new ServerRecord();
            sr.ServerIP = ServerIP;

            string WMIObject = "";
            SysInformation si = new SysInformation();

            string ServerUsername = "";
            string ServerPassword = "";

            if (DomainLogin == ServerEnums.Domain.Domain_C)
            {
                Login result = Logins.Find(x => x.DomainType == ServerEnums.Domain.Domain_C);
                ServerUsername = result.Domain + "\\" + result.UserName;
                ServerPassword = result.Password;
            }
            else
            {
                Login result = Logins.Find(x => x.DomainType == ServerEnums.Domain.Domain_O);
                ServerUsername = result.Domain + "\\" + result.UserName;
                ServerPassword = result.Password;
            }


            int DriveDeviceIDcount = 1;
            int DriveDescriptioncount = 1;
            int DriveFreeSpacecount = 1;
            int DriveSizecount = 1;

            WMIObject = "Win32_OperatingSystem";
            List<String> sysinfo = si.GetInfo(ServerUsername, ServerPassword, ServerIP, WMIObject);

            foreach (string value in sysinfo)
            {
                System.Diagnostics.Debug.WriteLine(value);
                if (value.ToUpper().StartsWith("CAPTION:"))
                {
                    sr.OperatingSystem_Caption = value.ToUpper().Replace("CAPTION:", "").Trim();
                }

                if (value.ToUpper().StartsWith("BUILDNUMBER:"))
                {
                    sr.BuildNumber = value.ToUpper().Replace("BUILDNUMBER:", "").Trim();
                }

                if (value.ToUpper().StartsWith("CURRENTTIMEZONE:"))
                {
                    sr.CurrentTimeZone = value.ToUpper().Replace("CURRENTTIMEZONE:", "").Trim();
                }

                if (value.ToUpper().StartsWith("FREEPHYSICALMEMORY:"))
                {
                    sr.FreePhysicalMemory = value.ToUpper().Replace("FREEPHYSICALMEMORY:", "").Trim();
                }

                if (value.ToUpper().StartsWith("NUMBEROFPROCESSES:"))
                {
                    sr.NumberOfProcesses = value.ToUpper().Replace("NUMBEROFPROCESSES:", "").Trim();
                }

                if (value.ToUpper().StartsWith("NUMBEROFUSERS:"))
                {
                    sr.NumberOfUsers = value.ToUpper().Replace("NUMBEROFUSERS:", "").Trim();
                }

                if (value.ToUpper().StartsWith("OSARCHITECTURE:"))
                {
                    sr.OSArchitecture = value.ToUpper().Replace("OSARCHITECTURE:", "").Trim();
                }

                if (value.ToUpper().StartsWith("SERIALNUMBER:"))
                {
                    sr.SerialNumber = value.ToUpper().Replace("SERIALNUMBER:", "").Trim();
                }

                if (value.ToUpper().StartsWith("TOTALVIRTUALMEMORYSIZE:"))
                {
                    sr.TotalVirtualMemorySize = value.ToUpper().Replace("TOTALVIRTUALMEMORYSIZE:", "").Trim();
                }

                if (value.ToUpper().StartsWith("VERSIONNUMBER:"))
                {
                    sr.VersionNumber = value.ToUpper().Replace("VERSIONNUMBER:", "").Trim();
                }

                if (value.ToUpper().StartsWith("CSNAME:"))
                {
                    sr.ComputerName = value.ToUpper().Replace("CSNAME:", "").Trim();
                }

                if (value.ToUpper().StartsWith("LASTBOOTUPTIME:"))
                {
                    string value_formatted = value.ToUpper().Replace("LASTBOOTUPTIME:", "").Trim();
                    DateTime dt = ManagementDateTimeConverter.ToDateTime(value_formatted);
                    sr.LastBootUpTime = string.Format("{0}", dt);
                }

            }


            WMIObject = "Win32_LogicalDisk";
            sysinfo = si.GetInfo(ServerUsername, ServerPassword, ServerIP, WMIObject);
            foreach (string value in sysinfo)
            {
                System.Diagnostics.Debug.WriteLine(value);
                #region drivestuff
                if (value.ToUpper().StartsWith("DEVICEID:"))
                {
                    string value_formatted = value.ToUpper().Replace("DEVICEID:", "").Trim();
                    if (DriveDeviceIDcount == 1)
                    {
                        sr.DriveDeviceID_1 = value_formatted;
                    }

                    if (DriveDeviceIDcount == 2)
                    {
                        sr.DriveDeviceID_2 = value_formatted;
                    }

                    if (DriveDeviceIDcount == 3)
                    {
                        sr.DriveDeviceID_3 = value_formatted;
                    }

                    if (DriveDeviceIDcount == 4)
                    {
                        sr.DriveDeviceID_4 = value_formatted;
                    }
                    DriveDeviceIDcount = DriveDeviceIDcount + 1;
                }

                if (value.ToUpper().StartsWith("DESCRIPTION:"))
                {
                    string value_formatted = value.ToUpper().Replace("DESCRIPTION:", "").Trim();
                    if (DriveDescriptioncount == 1)
                    {
                        sr.DriveDescription_1 = value_formatted;
                    }

                    if (DriveDescriptioncount == 2)
                    {
                        sr.DriveDescription_2 = value_formatted;
                    }

                    if (DriveDescriptioncount == 3)
                    {
                        sr.DriveDescription_3 = value_formatted;
                    }

                    if (DriveDescriptioncount == 4)
                    {
                        sr.DriveDescription_4 = value_formatted;
                    }
                    DriveDescriptioncount = DriveDescriptioncount + 1;
                }


                if (value.ToUpper().StartsWith("FREESPACE:"))
                {
                    string value_formatted = value.ToUpper().Replace("FREESPACE:", "").Trim();
                    if (DriveFreeSpacecount == 1)
                    {
                        sr.DriveFreeSpace_1 = value_formatted;
                    }

                    if (DriveFreeSpacecount == 2)
                    {
                        sr.DriveFreeSpace_2 = value_formatted;
                    }

                    if (DriveFreeSpacecount == 3)
                    {
                        sr.DriveFreeSpace_3 = value_formatted;
                    }

                    if (DriveFreeSpacecount == 4)
                    {
                        sr.DriveFreeSpace_4 = value_formatted;
                    }
                    DriveFreeSpacecount = DriveFreeSpacecount + 1;
                }

                if (value.ToUpper().StartsWith("SIZE:"))
                {
                    string value_formatted = value.ToUpper().Replace("SIZE:", "").Trim();
                    if (DriveSizecount == 1)
                    {
                        sr.DriveSize_1 = value_formatted;
                    }

                    if (DriveSizecount == 2)
                    {
                        sr.DriveSize_2 = value_formatted;
                    }

                    if (DriveSizecount == 3)
                    {
                        sr.DriveSize_3 = value_formatted;
                    }

                    if (DriveSizecount == 4)
                    {
                        sr.DriveSize_4 = value_formatted;
                    }
                    DriveSizecount = DriveSizecount + 1;
                }
                #endregion
            }

            WMIObject = "Win32_LocalTime";
            List<String> sysinfo2 = si.GetInfo(ServerUsername, ServerPassword, ServerIP, WMIObject);

            string sServerTime = "";
            foreach (string value in sysinfo2)
            {
                System.Diagnostics.Debug.WriteLine(value);
                if (value.ToUpper().StartsWith("HOUR:"))
                {
                    sServerTime = value.ToUpper().Replace("HOUR:", "");
                }

                if (value.ToUpper().StartsWith("MINUTE:"))
                {
                    sServerTime = sServerTime + ":" + value.ToUpper().Replace("MINUTE:", "");
                }
            }
            sr.ServerTime = sServerTime.Replace(" ", "");

            string sqlstmt = String.Format(@"insert into ServerInformation ( ServerIP,OperatingSystem_Caption
                        , BuildNumber , CurrentTimeZone , FreePhysicalMemory
                        , NumberOfProcesses , NumberOfUsers ,OSArchitecture
                        , SerialNumber , TotalVirtualMemorySize , VersionNumber , LASTBOOTUPTIME
                        , ComputerName
                        , DriveDeviceID_1,DriveDescription_1,DriveFreeSpace_1,DriveSize_1
                        , DriveDeviceID_2,DriveDescription_2,DriveFreeSpace_2,DriveSize_2
                        , DriveDeviceID_3,DriveDescription_3,DriveFreeSpace_3,DriveSize_3
                        , DriveDeviceID_4,DriveDescription_4,DriveFreeSpace_4,DriveSize_4
                        , DriveDeviceID_5,DriveDescription_5,DriveFreeSpace_5,DriveSize_5
                        , ServerTime, RunTime)
            values ('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}' ,'{11}' , '{12}' , '{13}', '{14}', '{15}' , '{16}' , '{17}' , '{18}' 
                    , '{19}' , '{20}' , '{21}', '{22}', '{23}' , '{24}', '{25}' 
                    , '{26}' , '{27}' , '{28}'  , '{29}' , '{30}' , '{31}', '{32}'   , '{33}' , '{34}'     )
            ", sr.ServerIP
             , sr.OperatingSystem_Caption
             , sr.BuildNumber
             , sr.CurrentTimeZone
             , sr.FreePhysicalMemory
             , sr.NumberOfProcesses, sr.NumberOfUsers, sr.OSArchitecture
             , sr.SerialNumber, sr.TotalVirtualMemorySize, sr.VersionNumber
             , sr.LastBootUpTime, sr.ComputerName
             , sr.DriveDeviceID_1, sr.DriveDescription_1, sr.DriveFreeSpace_1, sr.DriveSize_1
             , sr.DriveDeviceID_2, sr.DriveDescription_2, sr.DriveFreeSpace_2, sr.DriveSize_2
             , sr.DriveDeviceID_3, sr.DriveDescription_3, sr.DriveFreeSpace_3, sr.DriveSize_3
             , sr.DriveDeviceID_4, sr.DriveDescription_4, sr.DriveFreeSpace_4, sr.DriveSize_4
             , sr.DriveDeviceID_5, sr.DriveDescription_5, sr.DriveFreeSpace_5, sr.DriveSize_5
             , sr.ServerTime, RunTime);

            _dal.InsertIntoDB(sqlstmt);



        }
    }
}
