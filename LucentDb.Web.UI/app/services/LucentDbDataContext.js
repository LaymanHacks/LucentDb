(function () {
    "use strict";

    var serviceId = "lucentDbDataContext";
    angular.module("app").factory(serviceId, ["assertTypeDataService", "connectionDataService", "scriptDataService", lucentDbDataContext]);

    function lucentDbDataContext(assertTypeDataService, connectionDataService,  scriptDataService) {


        var service = {
            assertTypeDS: assertTypeDataService,
            connectionDS: connectionDataService,
            scriptDS: scriptDataService
        };

        return service;


    }
})();