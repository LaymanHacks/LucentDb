
(function() {
    "use strict";

    var controllerId = "validateProjectCtrl";
    angular.module("app").controller(controllerId, ["common", "validationDataService", validationIndexCtrl]);

    function validationIndexCtrl(common, validationDataService) {
        var vm = this;
        vm.title = "Validate Test Result";
        vm.validateProject = validateProject;
        vm.projectId = window.projectId | 0;
        vm.connectionId = window.connectionId | 0;
        vm.validationResult = {};

        activate();

        function activate() {
            var promises = [validateProject(vm.projectId, vm.connectionId)];
            common.activateController(promises, controllerId)
                .then(function() {});
        }

        function validateProject(projectId, connectionId) {
            return validationDataService.validateProject(projectId, connectionId)
                .then(function(results) {
                    return vm.validationResult = results.data;
                });
        };

    }
})();