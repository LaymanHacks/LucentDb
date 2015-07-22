
(function() {
    "use strict";

    var serviceId = "project_ConnectionDataService";
    angular.module("app").service(serviceId, ["$http", project_ConnectionDataService]);

    function project_ConnectionDataService($http) {
        var urlBase = "/api/project_Connection";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateProject_Connection = function(project_Connection) {
            return $http.put(urlBase, project_Connection);
        };

        this.deleteProject_Connection = function(projectId, connectionId) {
            return $http.Delete(urlBase, projectId, connectionId);
        };

        this.insertProject_Connection = function(project_Connection) {
            return $http.post(urlBase, project_Connection);
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

        this.getDataByProjectIdConnectionId = function(projectId, connectionId) {
            return $http.get(urlBase + "/all");
        };

        this.getDataByConnectionId = function(connectionId) {
            return $http.get(urlBase + "/project_Connection/all");
        };

        this.getDataByConnectionIdPageable = function(connectionId, sortExpression, page, pageSize) {
            return $http({
                url: urlBase + "/project_Connection",
                method: "GET",
                params: {
                    connectionId: connectionId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getDataByProjectId = function(projectId) {
            return $http.get(urlBase + "/project_Connection/all");
        };

        this.getDataByProjectIdPageable = function(projectId, sortExpression, page, pageSize) {
            return $http({
                url: urlBase + "/project_Connection",
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