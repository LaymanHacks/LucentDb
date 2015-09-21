
(function() {
    "use strict";

    var serviceId = "projectDetailsViewDataService";
    angular.module("app").service(serviceId, ["$http", projectDetailsViewDataService]);

    function projectDetailsViewDataService($http) {
        var urlBase = "/api/projectDetailsViews";

        this.getData = function() {
            return $http.get(urlBase + "/all");
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