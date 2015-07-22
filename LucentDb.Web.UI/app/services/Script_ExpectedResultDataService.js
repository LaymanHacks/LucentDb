
(function() {
    "use strict";

    var serviceId = "script_ExpectedResultDataService";
    angular.module("app").service(serviceId, ["$http", script_ExpectedResultDataService]);

    function script_ExpectedResultDataService($http) {
        var urlBase = "/api/script_ExpectedResult";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateScript_ExpectedResult = function(script_ExpectedResult) {
            return $http.put(urlBase, script_ExpectedResult);
        };

        this.deleteScript_ExpectedResult = function(scriptId, expectedResultId) {
            return $http.Delete(urlBase, scriptId, expectedResultId);
        };

        this.insertScript_ExpectedResult = function(script_ExpectedResult) {
            return $http.post(urlBase, script_ExpectedResult);
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

        this.getDataByScriptIdExpectedResultId = function(scriptId, expectedResultId) {
            return $http.get(urlBase + "/all");
        };

        this.getDataByExpectedResultId = function(expectedResultId) {
            return $http.get("/api/expectedResults/" + expectedResultId + "/script_ExpectedResult/all");
        };

        this.getDataByExpectedResultIdPageable = function(expectedResultId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/expectedResults/" + expectedResultId + "/script_ExpectedResult",
                method: "GET",
                params: {
                    expectedResultId: expectedResultId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getDataByScriptId = function(scriptId) {
            return $http.get("/api/scripts/" + scriptId + "/script_ExpectedResult/all");
        };

        this.getDataByScriptIdPageable = function(scriptId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/scripts/" + scriptId + "/script_ExpectedResult",
                method: "GET",
                params: {
                    scriptId: scriptId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };


    }
})();