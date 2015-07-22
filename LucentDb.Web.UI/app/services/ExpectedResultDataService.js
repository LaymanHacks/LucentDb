
(function() {
    "use strict";

    var serviceId = "expectedResultDataService";
    angular.module("app").service(serviceId, ["$http", expectedResultDataService]);

    function expectedResultDataService($http) {
        var urlBase = "/api/expectedResults";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateExpectedResult = function(expectedResult) {
            return $http.put(urlBase, expectedResult);
        };

        this.deleteExpectedResult = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertExpectedResult = function(expectedResult) {
            return $http.post(urlBase, expectedResult);
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
            return $http.get("/api/expectedResults/" + id);
        };

        this.getDataByAssertTypeId = function(assertTypeId) {
            return $http.get("/api/assertTypes/" + assertTypeId + "/expectedResults/all");
        };

        this.getDataByAssertTypeIdPageable = function(assertTypeId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/assertTypes/" + assertTypeId + "/expectedResults",
                method: "GET",
                params: {
                    assertTypeId: assertTypeId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };


    }
})();