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

    var serviceId = "test_ScriptDataService";
    angular.module("app").service(serviceId, ["$http", test_ScriptDataService]);

    function test_ScriptDataService($http) {
        var urlBase = "/api/test_Script";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateTest_Script = function(test_Script) {
            return $http.put(urlBase, test_Script);
        };

        this.deleteTest_Script = function(testId, scriptId) {
            return $http.Delete(urlBase, testId, scriptId);
        };

        this.insertTest_Script = function(test_Script) {
            return $http.post(urlBase, test_Script);
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

        this.getDataByTestIdScriptId = function(testId, scriptId) {
            return $http.get(urlBase + "/all");
        };

        this.getDataByScriptId = function(scriptId) {
            return $http.get(urlBase + "/all");
        };

        this.getDataByScriptIdPageable = function(scriptId, sortExpression, page, pageSize) {
            return $http({
                url: urlBase,
                method: "GET",
                params: {
                    scriptId: scriptId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getDataByTestId = function(testId) {
            return $http.get(urlBase + "/all");
        };

        this.getDataByTestIdPageable = function(testId, sortExpression, page, pageSize) {
            return $http({
                url: urlBase,
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