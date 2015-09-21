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
            return $http.get(urlBase + "/all");
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

        this.getDataByExpectedResultTypeId = function(expectedResultTypeId) {
            return $http.get("/api/expectedResultTypes/" + expectedResultTypeId + "/expectedResults/all");
        };

        this.getDataByExpectedResultTypeIdPageable = function(expectedResultTypeId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/expectedResultTypes/" + expectedResultTypeId + "/expectedResults",
                method: "GET",
                params: {
                    expectedResultTypeId: expectedResultTypeId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getDataByTestId = function(testId) {
            return $http.get("/api/tests/" + testId + "/expectedResults/all");
        };

        this.getDataByTestIdPageable = function(testId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/tests/" + testId + "/expectedResults",
                method: "GET",
                params: {
                    testId: testId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };


    }
})();