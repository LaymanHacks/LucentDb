
(function () {
    "use strict";

    var controllerId = "validateTestIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "validationDataService", validationIndexCtrl]);

    function validationIndexCtrl(common, validationDataService) {
        var vm = this;
        vm.title = "Validate Test Result";
        vm.validateTest = validateTest;
        
        activate();

        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function () { });
        }
   
        function validateTest(testId, connectionId) {
            return validationDataService.validateTest(testId, connectionId);
        };
    }
})();