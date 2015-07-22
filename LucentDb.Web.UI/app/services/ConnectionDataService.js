
(function() {
    "use strict";

    var serviceId = "connectionDataService";
    angular.module("app").service(serviceId, ["$http", connectionDataService]);

    function connectionDataService($http) {
        var urlBase = "/api/connections";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateConnection = function(connection) {
            return $http.put(urlBase, connection);
        };

        this.deleteConnection = function(connectionId) {
            return $http.Delete(urlBase, connectionId);
        };

        this.insertConnection = function(connection) {
            return $http.post(urlBase, connection);
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

        this.getDataByConnectionId = function(connectionId) {
            return $http.get("/api/connections/" + connectionId);
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

        this.getConnectionsForProjectByProjectId = function(projectId) {
            return $http.get("/api/projects/" + projectId + "/connections/all");
        };

        this.getConnectionsForProjectByProjectIdPageable = function(projectId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/projects/" + projectId + "/connections",
                method: "GET",
                params: {
                    projectId: projectId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };


    }
})();