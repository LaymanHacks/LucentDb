
(function() {
    "use strict";

    var serviceId = "runHistoryDataService";
    angular.module("app").service(serviceId, ["$http", runHistoryDataService]);

    function runHistoryDataService($http) {
        var urlBase = "/api/runHistories";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateRunHistory = function(runHistory) {
            return $http.put(urlBase, runHistory);
        };

        this.deleteRunHistory = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertRunHistory = function(runHistory) {
            return $http.post(urlBase, runHistory);
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
            return $http.get(urlBase + "/all");
        };

        this.getDataByScriptId = function(scriptId) {
            return $http.get("/api/scripts/" + scriptId + "/runHistories/all");
        };

        this.getDataByScriptIdPageable = function(scriptId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/scripts/" + scriptId + "/runHistories",
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