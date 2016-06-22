
(function() {
    "use strict";

    var serviceId = "validationDataService";
    angular.module("app").service(serviceId, ["$http", validationDataService]);

    function validationDataService($http) {
        var urlBase = "/api";

        this.validateProject = function(projectId, connectionId) {
            if (connectionId !== 0) {
                return $http.get(urlBase + "/connections/" + connectionId + "/projects/" + projectId + "/validate");
            } else {
                return $http.get(urlBase + "/projects/" + projectId + "/validate");
            }
        };

        this.validateTestGroup = function(testGroupId, connectionId) {
            if (connectionId !== 0) {
                return $http.get(urlBase + "/connections/" + connectionId + "/testgroups/" + testGroupId + "/validate");
            } else {
                return $http.get(urlBase + "/testgroups/" + testGroupId + "/validate");
            }
        };


        this.validateTest = function(testId, connectionId) {
            if (connectionId !== 0) {
                return $http.get(urlBase + "/connections/" + connectionId + "/tests/" + testId + "/validate");
            } else {
                return $http.get(urlBase + "/tests/" + testId + "/validate");
            }
        };
    }
})();