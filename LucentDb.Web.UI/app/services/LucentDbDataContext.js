(function() {
    "use strict";

    var serviceId = "lucentDbDataContext";
    angular.module("app").factory(serviceId, ["assertTypeDataService", "connectionDataService", "testDataService", "scriptDataService", lucentDbDataContext]);

    function lucentDbDataContext(assertTypeDataService, connectionDataService, testDataService, scriptDataService) {


        var service = {
            assertTypeDS: assertTypeDataService,
            connectionDS: connectionDataService,
            testDS: testDataService,
            scriptDS: scriptDataService
        };

        return service;


    }
})();