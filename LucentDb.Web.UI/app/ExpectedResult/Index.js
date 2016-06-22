
(function() {
    "use strict";

    var controllerId = "expectedResultIndexCtrl";
    angular.module("app")
        .controller(controllerId,
        ["common", "expectedResultDataService", "assertTypeDataService", expectedResultIndexCtrl]);

    function expectedResultIndexCtrl(common, expectedResultDataService, assertTypeDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "ExpectedResult List",
            description: "ExpectedResult List"
        };

        vm.pageableResults = [];
        vm.assertTypes = [];
        vm.title = "ExpectedResultList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteExpectedResult = deleteExpectedResult;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize), getAssertTypes()];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated ExpectedResult List View"); });
        }

        function getAssertTypes() {
            return assertTypeDataService.getData()
                .then(function(results) {
                    return vm.assertTypes = results.data;
                });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return expectedResultDataService.getDataPageable(sortExpression, page, pageSize)
                .then(function(results) {
                    return vm.pageableResults = results.data;
                });
        }

        function deleteExpectedResult(expectedResultId) {
            alert("Simulated Delete");
            //  return expectedResultDataService.deleteExpectedResult(expectedResultId);
        };
    }
})();