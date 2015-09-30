
# ServerInfo

This project uses the WMI to gather server info.
### Features
-  


### Database Table Definitions
            
            CREATE TABLE ServerInformation
            (	RecordId int identity (1,1),
				ServerName varchar(100),
				ServerIP varchar(100),

				LastBootUpTime varchar(100),
				ComputerName  varchar(100),

				OperatingSystem_Caption varchar(255), /*Win32_OperatingSystem*/
				BuildNumber varchar(255),  /*Win32_OperatingSystem*/
				CurrentTimeZone varchar(255),  /*Win32_OperatingSystem*/
				FreePhysicalMemory varchar(255),  /*Win32_OperatingSystem*/
				FreeVirtualMemory varchar(255),  /*Win32_OperatingSystem*/
				NumberOfProcesses varchar(255),  /*Win32_OperatingSystem*/
				NumberOfUsers varchar(255),  /*Win32_OperatingSystem*/
				OSArchitecture varchar(255),  /*Win32_OperatingSystem*/
				SerialNumber varchar(255),  /*Win32_OperatingSystem*/
				TotalVirtualMemorySize varchar(255),  /*Win32_OperatingSystem*/
				VersionNumber  varchar(255),  /*Win32_OperatingSystem*/

				DriveDeviceID_1 varchar(100),  /*Win32_LogicalDisk*/
				DriveDescription_1 varchar(100),  
				DriveFreeSpace_1 varchar(25),  
				DriveSize_1  varchar(25),  

				DriveDeviceID_2 varchar(100),
				DriveDescription_2 varchar(100),  
				DriveFreeSpace_2 varchar(25),  
				DriveSize_2  varchar(25),  

				DriveDeviceID_3 varchar(100),
				DriveDescription_3 varchar(100),  
				DriveFreeSpace_3 varchar(25),  
				DriveSize_3  varchar(25), 

				DriveDeviceID_4 varchar(100),
				DriveDescription_4 varchar(100),  
				DriveFreeSpace_4 varchar(25),  
				DriveSize_4  varchar(25), 

				DriveDeviceID_5 varchar(100),
				DriveDescription_5 varchar(100),  
				DriveFreeSpace_5 varchar(25),  
				DriveSize_5  varchar(25),

				ServerTime varchar(100) /*Win32_LocalTime*/,
				RunNumber int /*Win32_LocalTime*/
            ) 
			
			

			create table Servers (RecordId int identity (1,1)
			,DateRecordAdded datetime not null  default(getdate()) 
			,ServerDomain varchar(100)
			,DomainAlias varchar(100)
			,ServerIP varchar(100) ) 

			
			


			alter  view vw_ServerInformation as 
			select    
			RecordId,RunTime
			--,ServerName
			,ServerIP,LastBootUpTime,ComputerName,OperatingSystem_Caption,BuildNumber,CurrentTimeZone,FreePhysicalMemory,FreeVirtualMemory,NumberOfProcesses,NumberOfUsers,OSArchitecture,SerialNumber,TotalVirtualMemorySize,VersionNumber
			,ServerTime
			--,DriveDescription_1
			--,DriveFreeSpace_1 = CAST(case when DriveFreeSpace_1='NULL' then '0' else DriveFreeSpace_1 end    / 1073741824.0E AS DECIMAL(10, 2))
			--,DriveSize_1 = CAST(case when DriveSize_1='NULL' then '0' else DriveSize_1 end    / 1073741824.0E AS DECIMAL(10, 2))
			,DriveDeviceID_2
			,DriveDescription_2
			,DriveFreeSpace_2 = CAST(case when DriveFreeSpace_2='NULL' then '0' else DriveFreeSpace_2 end    / 1073741824.0E AS DECIMAL(10, 2))
			,DriveSize_2 = CAST(case when DriveSize_2='NULL' then '0' else DriveSize_2 end    / 1073741824.0E AS DECIMAL(10, 2))
			,DriveDeviceID_3
			,DriveDescription_3
			,DriveFreeSpace_3 = CAST(case when DriveFreeSpace_3='NULL' then '0' else DriveFreeSpace_3 end    / 1073741824.0E AS DECIMAL(10, 2))
			,DriveSize_3 = CAST(case when DriveSize_3='NULL' then '0' else DriveSize_3 end    / 1073741824.0E AS DECIMAL(10, 2))
			,DriveDeviceID_4
			,DriveDescription_4
			,DriveFreeSpace_4 = CAST(case when DriveFreeSpace_4='NULL' then '0' else DriveFreeSpace_4 end    / 1073741824.0E AS DECIMAL(10, 2))
			,DriveSize_4= CAST(case when DriveSize_4='NULL' then '0' else DriveSize_4 end    / 1073741824.0E AS DECIMAL(10, 2))
			,DriveDeviceID_5
			,DriveDescription_5
			,DriveFreeSpace_5= CAST(case when DriveFreeSpace_5='NULL' then '0' else DriveFreeSpace_5 end    / 1073741824.0E AS DECIMAL(10, 2))
			,DriveSize_5= CAST(case when DriveSize_5='NULL' then '0' else DriveSize_5 end    / 1073741824.0E AS DECIMAL(10, 2))
			,DateRecordAdded 
			from ServerInformation
						   
						   