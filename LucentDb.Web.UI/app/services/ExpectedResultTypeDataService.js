
(function() {
    "use strict";

    var serviceId = "expectedResultTypeDataService";
    angular.module("app").service(serviceId, ["$http", expectedResultTypeDataService]);

    function expectedResultTypeDataService($http) {
        var urlBase = "/api/expectedResultTypes";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateExpectedResultType = function(expectedResultType) {
            return $http.put(urlBase, expectedResultType);
        };

        this.deleteExpectedResultType = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertExpectedResultType = function(expectedResultType) {
            return $http.post(urlBase, expectedResultType);
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
            return $http.get("/api/expectedResultTypes/" + id);
        };


    }
})();