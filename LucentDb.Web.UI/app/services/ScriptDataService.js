
(function() {
    "use strict";

    var serviceId = "scriptDataService";
    angular.module("app").service(serviceId, ["$http", scriptDataService]);

    function scriptDataService($http) {
        var urlBase = "/api/scripts";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateScript = function(script) {
            return $http.put(urlBase, script);
        };

        this.deleteScript = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertScript = function(script) {
            return $http.post(urlBase, script);
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
            return $http.get("/api/scripts/" + id);
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

        this.getScriptsForTestByTestId = function(testId) {
            return $http.get("/api/tests/" + testId + "/scripts/all");
        };

        this.getDataByScriptTypeId = function(scriptTypeId) {
            return $http.get("/api/scriptTypes/" + scriptTypeId + "/scripts/all");
        };

        this.getDataByScriptTypeIdPageable = function(scriptTypeId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/scriptTypes/" + scriptTypeId + "/scripts",
                method: "GET",
                params: {
                    scriptTypeId: scriptTypeId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getActiveDataByScriptTypeId = function(scriptTypeId) {
            return $http.get("/api/scriptTypes/" + scriptTypeId + "/scripts/all/active");
        };

        this.getActiveDataByScriptTypeIdPageable = function(scriptTypeId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/scriptTypes/" + scriptTypeId + "/scripts/active",
                method: "GET",
                params: {
                    scriptTypeId: scriptTypeId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };


    }
})();