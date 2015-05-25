//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
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

        this.deleteConnection = function(id) {
            return $http.Delete(urlBase, id);
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

        this.getDataById = function(assertTypeId) {
            return $http.get("/api/expectedResults/" + assertTypeId + "/connections/all");
        };

        this.getActiveData = function() {
            return $http.get(urlBase + "/all");
        };

        this.getActiveDataPageable = function(sortExpression, page, pageSize) {
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

        this.getConnectionsByProjectId = function(projectId) {
            return $http.get("/api/projects/" + projectId + "/connections/all");
        };


    }
})();