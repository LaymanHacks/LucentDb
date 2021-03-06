
(function() {
    "use strict";

    var serviceId = "testTypeDataService";
    angular.module("app").service(serviceId, ["$http", testTypeDataService]);

    function testTypeDataService($http) {
        var urlBase = "/api/testTypes";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateTestType = function(testType) {
            return $http.put(urlBase, testType);
        };

        this.deleteTestType = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertTestType = function(testType) {
            return $http.post(urlBase, testType);
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
            return $http.get("/api/testTypes/" + id);
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