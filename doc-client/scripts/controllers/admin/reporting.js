angular.module('adminApp')
    .controller('ReportingCtrl', function ($scope, $rootScope, $modal, Modal, Report) {

        var refreshReports = function () {
            Report.getReports(function (data) {
                $scope.reports = data;
            });
        };
        refreshReports();
        $scope.deleteReport = function (report) {
            Modal.openYesNoModal('Warning!', 'Are you sure want to delete this report?', function () {
                Report.deleteReport(report.id, function () {
                    refreshReports();
                })
            });
        };
        $scope.createReportDialog = function () {
            var modalInstance = $modal.open({
                templateUrl: '/views/templates/create-report.html',
                controller: 'CreateReportCtrl'
            });
            modalInstance.result.then(function () {
                refreshReports();
            }, function () {
//                if (noCallback) noCallback()
            });
        };


    })
    .controller('CreateReportCtrl', function ($scope, $modalInstance, Report) {
        $scope.dataSources = { vals: ['Users', 'BusinessProcesses']};
        $scope.report = {
            name: '',
            description: '',
            dataSourceType: $scope.dataSources.vals[0]
        };
        $scope.ok = function () {
            if (!$scope.isCreated) {
                Report.addReport($scope.report, function (data) {
                    $scope.editUrl = '/reports/Editor.aspx?reportId=' + data.id;
                    $scope.isCreated = true;
                });
            } else {
                $modalInstance.close();
            }
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });