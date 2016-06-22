(function() {
    "use strict";

    var serviceId = "lucentDbDataContext";
    angular.module("app")
        .factory(serviceId,
        [
            "assertTypeDataService", "connectionDataService", "testDataService", "expectedResultDataService",
            lucentDbDataContext
        ]);

    function lucentDbDataContext(assertTypeDataService,
        connectionDataService,
        testDataService,
        expectedResultDataService) {


        var service = {
            assertTypeDS: assertTypeDataService,
            connectionDS: connectionDataService,
            testDS: testDataService,
            expectedResultDS: expectedResultDataService
        };

        return service;


    }
})();