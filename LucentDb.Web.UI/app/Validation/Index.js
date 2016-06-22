
(function() {
    "use strict";

    var controllerId = "validationIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "validationDataService", validationIndexCtrl]);

    function validationIndexCtrl(common, validationDataService) {


        var vm = this;

        vm.title = "Validation Result";

        vm.validateProject = validateProject;
        vm.validateTest = validateTest;
        vm.validateTestGroup = validateTestGroup;

        activate();

        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function() {});
        }

        function validateProject(projectId, connectionId) {
            return validationDataService.validateProject(projectId, connectionId);
        };

        function validateTestGroup(testGroupId, connectionId) {
            return validationDataService.validateTestGroup(testGroupId, connectionId);
        };

        function validateTest(testId, connectionId) {
            return validationDataService.validateTest(testId, connectionId);
        };
    }
})();