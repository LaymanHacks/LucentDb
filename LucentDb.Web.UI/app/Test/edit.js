
(function () {
    "use strict";

    var controllerId = "testEditCtrl";
    angular.module("app").controller(controllerId, ["common", "lucentDbDataContext", "$scope", testEditCtrl]);

    function testEditCtrl(common, lucentDbDataContext, $scope) {


        var vm = this;
        vm.id = window.testId;
        vm.test = {};
        vm.test.validationScripts = [];
        vm.assertTypes = [];
        vm.title = "Edit Test";

        activate();

        function activate() {
            var promises = [getTestById(vm.id), getExpectedResultByTestId(vm.id), getAssertTypes()];
           
            common.activateController(promises, controllerId)
                .then(function () {
                    if (!$scope.$$phase) {
                        scope.$apply();
                    }
                });
        }

        // getDataById
        function getTestById(id) {

            return lucentDbDataContext.testDS.getDataById(id).then(function (results) {
                return vm.test = results.data;

            });
        }

        function getAssertTypes() {
            return lucentDbDataContext.assertTypeDS.getData().then(function (results) {
                return vm.assertTypes = results.data;

            });
        };

        function getExpectedResultByTestId(id) {

            return lucentDbDataContext.expectedResultDS.getDataByTestId(id).then(function (results) {
                return vm.test.validationScripts = results.data;

            });
        }
    }
})();