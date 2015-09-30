using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerInfo.DomainEntities
{
    public class ServerRecord
    { 
        public string RecordId { get; set; }
        public string RunTime { get; set; }

        public string ServerIP { get; set; }
        public string OperatingSystem_Caption { get; set; }
        public string BuildNumber { get; set; }
        public string CurrentTimeZone { get; set; }
        public string FreePhysicalMemory { get; set; }
        public string NumberOfProcesses { get; set; }
        public string NumberOfUsers { get; set; }
        public string OSArchitecture { get; set; }
        public string SerialNumber { get; set; }
        public string TotalVirtualMemorySize { get; set; }
        public string VersionNumber { get; set; }

        public string LastBootUpTime { get; set; }
        public string ComputerName { get; set; }


        public string DriveDeviceID_1 { get; set; }
        public string DriveDescription_1 { get; set; }
        public string DriveFreeSpace_1 { get; set; }
        public string DriveSize_1 { get; set; }

        public string DriveDeviceID_2 { get; set; }
        public string DriveDescription_2 { get; set; }
        public string DriveFreeSpace_2 { get; set; }
        public string DriveSize_2 { get; set; }

        public string DriveDeviceID_3 { get; set; }
        public string DriveDescription_3 { get; set; }
        public string DriveFreeSpace_3 { get; set; }
        public string DriveSize_3 { get; set; }

        public string DriveDeviceID_4 { get; set; }
        public string DriveDescription_4 { get; set; }
        public string DriveFreeSpace_4 { get; set; }
        public string DriveSize_4 { get; set; }

        public string DriveDeviceID_5 { get; set; }
        public string DriveDescription_5 { get; set; }
        public string DriveFreeSpace_5 { get; set; }
        public string DriveSize_5 { get; set; }

        public string ServerTime { get; set; }
    }
}
