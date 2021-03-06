
(function() {
    "use strict";

    var serviceId = "scriptTypeDataService";
    angular.module("app").service(serviceId, ["$http", scriptTypeDataService]);

    function scriptTypeDataService($http) {
        var urlBase = "/api/scriptTypes";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateScriptType = function(scriptType) {
            return $http.put(urlBase, scriptType);
        };

        this.deleteScriptType = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertScriptType = function(scriptType) {
            return $http.post(urlBase, scriptType);
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
            return $http.get("/api/scriptTypes/" + id);
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


    }
})();