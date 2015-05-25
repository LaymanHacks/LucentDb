
(function() {
    "use strict";

    var controllerId = "testDetailsCtrl";
    angular.module("app").controller(controllerId, ["common", "lucentDbDataContext", "$scope", testDetailsCtrl]);

    function testDetailsCtrl(common, lucentDbDataContext, $scope) {


        var vm = this;

        vm.test = {};
        vm.test.validationScripts = [];
        vm.assertTypes = [];
        vm.title = "Test Details";

        activate();

        function activate() {
            var promises = [getTestById(1), getValidationScriptsByTestId(1), getAssertTypes()];
            common.activateController(promises, controllerId)
                .then(function() {
                    if (!$scope.$$phase) {
                        scope.$apply();
                    }
                });
        }

// getDataById
        function getTestById(id) {

            return lucentDbDataContext.testDS.getDataById(id).then(function(results) {
                return vm.test = results.data;

            });
        }

        function getAssertTypes() {
            return lucentDbDataContext.assertTypeDS.getData().then(function(results) {
                return vm.assertTypes = results.data;

            });
        };

        function getValidationScriptsByTestId(id) {

            return lucentDbDataContext.scriptDS.getDataByTestId(id).then(function(results) {
                return vm.test.validationScripts = results.data;

            });
        }
    }
})();