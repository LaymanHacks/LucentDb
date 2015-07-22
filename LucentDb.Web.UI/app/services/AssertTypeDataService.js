
(function() {
    "use strict";

    var serviceId = "assertTypeDataService";
    angular.module("app").service(serviceId, ["$http", assertTypeDataService]);

    function assertTypeDataService($http) {
        var urlBase = "/api/assertTypes";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateAssertType = function(assertType) {
            return $http.put(urlBase, assertType);
        };

        this.deleteAssertType = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertAssertType = function(assertType) {
            return $http.post(urlBase, assertType);
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
            return $http.get("/api/assertTypes/" + id);
        };


    }
})();