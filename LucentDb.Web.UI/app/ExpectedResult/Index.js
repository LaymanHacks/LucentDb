
(function() {
    "use strict";

    var controllerId = "expectedResultIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "expectedResultDataService", expectedResultIndexCtrl]);

    function expectedResultIndexCtrl(common, expectedResultDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "ExpectedResult List",
            description: "ExpectedResult List"
        };

        vm.pageableResults = [];
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
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated ExpectedResult List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return expectedResultDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteExpectedResult(expectedResultId) {
            alert("test worked");
            //  return expectedResultDataService.deleteExpectedResult(expectedResultId);
        };
    }
})();