angular.module('resources.reports', [])
    .factory('Report', ['$http', function ($http) {
        var service = {
            getReports: function (callback) {
                $http.get('/api/report').success(callback);
            },
            addReport: function (report, callback) {
                $http.post('/api/report', report).success(callback);
            },
            deleteReport: function (id, callback) {
                $http.delete('/api/report/' + id).success(callback);
            }
        };
        return service;
    }]);
