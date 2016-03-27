(function () {
    "use strict";

    var controllerId = "validateTestCtrl";
    angular.module("app").controller(controllerId, ["common", "validationDataService", validationIndexCtrl]);

    function validationIndexCtrl(common, validationDataService) {
        var vm = this;
        vm.title = "Validate Test Result";
        vm.validateTest = validateTest;
        vm.testId = window.testId | 0;
        vm.connectionId = window.connectionId | 0;
        vm.validationResult = {};

        activate();

        function activate() {
            var promises = [validateTest(vm.testId, vm.connectionId)];
            common.activateController(promises, controllerId)
                .then(function () { });
        }

        function validateTest(testId, connectionId) {
            return validationDataService.validateTest(testId, connectionId).then(function (results) {
                return vm.validationResult = results.data[0]
                ;
            });
        };

    }
})();