
(function() {
    "use strict";

    var serviceId = "testDataService";
    angular.module("app").service(serviceId, ["$http", testDataService]);

    function testDataService($http) {
        var urlBase = "/api/tests";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateTest = function(test) {
            return $http.put(urlBase, test);
        };

        this.deleteTest = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertTest = function(test) {
            return $http.post(urlBase, test);
        };

        this.getDataPageable = function(sortExpression, page, pageSize) {
            return $http({
                url: urlBase,
                method: "GET",
                params: {
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getDataById = function(id) {
            return $http.get("/api/tests/" + id);
        };

        this.getActiveData = function() {
            return $http.get(urlBase + "/all/active");
        };

        this.getActiveDataPageable = function(sortExpression, page, pageSize) {
            return $http({
                url: urlBase + "/active",
                method: "GET",
                params: {
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getTestsForScriptByScriptId = function(scriptId) {
            return $http.get("/api/scripts/" + scriptId + "/tests/all");
        };

        this.getDataByProjectId = function(projectId) {
            return $http.get("/api/projects/" + projectId + "/tests/all");
        };

        this.getDataByProjectIdPageable = function(projectId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/projects/" + projectId + "/tests",
                method: "GET",
                params: {
                    projectId: projectId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getActiveDataByProjectId = function(projectId) {
            return $http.get("/api/projects/" + projectId + "/tests/all/active");
        };

        this.getActiveDataByProjectIdPageable = function(projectId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/projects/" + projectId + "/tests/active",
                method: "GET",
                params: {
                    projectId: projectId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getDataByTestTypeId = function(testTypeId) {
            return $http.get("/api/testTypes/" + testTypeId + "/tests/all");
        };

        this.getDataByTestTypeIdPageable = function(testTypeId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/testTypes/" + testTypeId + "/tests",
                method: "GET",
                params: {
                    testTypeId: testTypeId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getActiveDataByTestTypeId = function(testTypeId) {
            return $http.get("/api/testTypes/" + testTypeId + "/tests/all/active");
        };

        this.getActiveDataByTestTypeIdPageable = function(testTypeId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/testTypes/" + testTypeId + "/tests/active",
                method: "GET",
                params: {
                    testTypeId: testTypeId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };


    }
})();