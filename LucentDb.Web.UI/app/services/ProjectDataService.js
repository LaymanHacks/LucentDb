
(function() {
    "use strict";

    var serviceId = "projectDataService";
    angular.module("app").service(serviceId, ["$http", projectDataService]);

    function projectDataService($http) {
        var urlBase = "/api/projects";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateProject = function(project) {
            return $http.put(urlBase, project);
        };

        this.deleteProject = function(projectId) {
            return $http.Delete(urlBase, projectId);
        };

        this.insertProject = function(project) {
            return $http.post(urlBase, project);
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

        this.getDataByProjectId = function(projectId) {
            return $http.get("/api/projects/" + projectId);
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

        this.getProjectsForConnectionByConnectionId = function(connectionId) {
            return $http.get("/api/connections/" + connectionId + "/projects/all");
        };

        this.getProjectsForConnectionByConnectionIdPageable = function(connectionId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/connections/" + connectionId + "/projects",
                method: "GET",
                params: {
                    connectionId: connectionId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };


    }
})();