 
(function () {
    "use strict"; 
    var module = angular.module("example", ["angularGrid"]);
     

    module.controller("exampleCtrl", function ($scope, $http) {
         
        var columnDefs = [          
             { headerName: "RecordId", field: "recordId", width: 90 }
             ,
             { headerName: "RunTime", field: "runTime", width: 90 }
             ,
             { headerName: "ServerIP", field: "serverIP", width: 90 },
             { headerName: "LastBootUpTime", field: "lastBootUpTime", width: 90 },
             { headerName: "ComputerName", field: "computerName", width: 90 },
             { headerName: "OperatingSystem_Caption", field: "operatingSystem_Caption", width: 90 },
             { headerName: "BuildNumber", field: "buildNumber", width: 90 },
             { headerName: "CurrentTimeZone", field: "currentTimeZone", width: 90 },
             { headerName: "FreePhysicalMemory", field: "freePhysicalMemory", width: 90 },
             { headerName: "FreeVirtualMemory", field: "freeVirtualMemory", width: 90 },
             { headerName: "NumberOfProcesses", field: "numberOfProcesses", width: 90 },
             { headerName: "NumberOfUsers", field: "numberOfUsers", width: 90 },
             { headerName: "OSArchitecture", field: "oSArchitecture", width: 90 },
             { headerName: "SerialNumber", field: "serialNumber", width: 90 },
             { headerName: "TotalVirtualMemorySize", field: "totalVirtualMemorySize", width: 90 },
             { headerName: "VersionNumber", field: "versionNumber", width: 90 },
             { headerName: "ServerTime", field: "serverTime", width: 90 },
             { headerName: "DriveDeviceID_2", field: "driveDeviceID_2", width: 90 },
             { headerName: "DriveDescription_2", field: "driveDescription_2", width: 90 },
             { headerName: "DriveFreeSpace_2", field: "driveFreeSpace_2", width: 90 },
             { headerName: "DriveSize_2", field: "driveSize_2", width: 90 },
             { headerName: "DriveDeviceID_3", field: "driveDeviceID_3", width: 90 },
             { headerName: "DriveDescription_3", field: "driveDescription_3", width: 90 },
             { headerName: "DriveFreeSpace_3", field: "driveFreeSpace_3", width: 90 },
             { headerName: "DriveSize_3", field: "driveSize_3", width: 90 },
             { headerName: "DriveDeviceID_4", field: "driveDeviceID_4", width: 90 },
             { headerName: "DriveDescription_4", field: "driveDescription_4", width: 90 },
             { headerName: "DriveFreeSpace_4", field: "driveFreeSpace_4", width: 90 },
             { headerName: "DriveSize_4", field: "driveSize_4", width: 90 },
             { headerName: "DriveDeviceID_5", field: "driveDeviceID_5", width: 90 },
             { headerName: "DriveDescription_5", field: "driveDescription_5", width: 90 },
             { headerName: "DriveFreeSpace_5", field: "driveFreeSpace_5", width: 90 },
             { headerName: "DriveSize_5", field: "driveSize_5", width: 90 },
             { headerName: "DateRecordAdded", field: "dateRecordAdded", width: 90 } 
        ];

        $scope.gridOptions = {
            columnDefs: columnDefs,
            rowData: null // set rowData to null or undefined to show loading panel by default
        };

        //http://10.0.6.147/serverinfowebservice/api/serverinfoset
        //"http://localhost:60667/api/serverinfoset"
        $http.get("http://localhost:60667/api/serverinfoset")
            .then(function (res) {
                $scope.gridOptions.rowData = res.data;
                $scope.gridOptions.api.onNewRows();

                if ($scope.gridOptions.api) {
                    $scope.gridOptions.api.onNewRows();
                }


            });

    });


         
    //var module = angular.module("example", ["angularGrid"]);

    //module.controller("exampleCtrl", function($scope, $http) {

    //    var columnDefs = [
    //        {headerName: "Athlete", field: "athlete", width: 150},
    //        {headerName: "Age", field: "age", width: 90},
    //        {headerName: "Country", field: "country", width: 120},
    //        {headerName: "Year", field: "year", width: 90},
    //        {headerName: "Date", field: "date", width: 110},
    //        {headerName: "Sport", field: "sport", width: 110},
    //        {headerName: "Gold", field: "gold", width: 100},
    //        {headerName: "Silver", field: "silver", width: 100},
    //        {headerName: "Bronze", field: "bronze", width: 100},
    //        {headerName: "Total", field: "total", width: 100}
    //    ];

    //    $scope.gridOptions = {
    //        columnDefs: columnDefs,
    //        rowData: null
    //    };

    //    $http.get("http://localhost:60667/api/serverinfoset")
    //        .then(function(res){
    //            $scope.gridOptions.rowData = res.data;
    //            $scope.gridOptions.api.onNewRows();
    //        });
    //});


        





}());