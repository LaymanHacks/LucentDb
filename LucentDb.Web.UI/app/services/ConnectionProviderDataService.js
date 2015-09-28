
(function() {
    "use strict";

    var serviceId = "connectionProviderDataService";
    angular.module("app").service(serviceId, ["$http", connectionProviderDataService]);

    function connectionProviderDataService($http) {
        var urlBase = "/api/connectionProviders";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateConnectionProvider = function(connectionProvider) {
            return $http.put(urlBase, connectionProvider);
        };

        this.deleteConnectionProvider = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertConnectionProvider = function(connectionProvider) {
            return $http.post(urlBase, connectionProvider);
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
            return $http.get("/api/connectionProviders/" + id);
        };


    }
})();