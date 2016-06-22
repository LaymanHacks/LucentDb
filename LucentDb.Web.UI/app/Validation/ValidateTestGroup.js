
(function() {
    "use strict";

    var controllerId = "validateTestGroupCtrl";
    angular.module("app").controller(controllerId, ["common", "validationDataService", validationIndexCtrl]);

    function validationIndexCtrl(common, validationDataService) {
        var vm = this;
        vm.title = "Validate Test Result";
        vm.validateTestGroup = validateTestGroup;
        vm.testGroupId = window.testGroupId | 0;
        vm.connectionId = window.connectionId | 0;
        vm.validationResult = {};

        activate();

        function activate() {
            var promises = [validateTestGroup(vm.testGroupId, vm.connectionId)];
            common.activateController(promises, controllerId)
                .then(function() {});
        }

        function validateTestGroup(testGroupId, connectionId) {
            return validationDataService.validateTestGroup(testGroupId, connectionId)
                .then(function(results) {
                    return vm.validationResult = results.data;
                });
        };

    }
})();