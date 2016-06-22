
(function() {
    "use strict";

    var controllerId = "testIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "testDataService", testIndexCtrl]);

    function testIndexCtrl(common, testDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "Test List",
            description: "Test List"
        };

        vm.pageableResults = [];
        vm.title = "TestList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteTest = deleteTest;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated Test List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return testDataService.getDataPageable(sortExpression, page, pageSize)
                .then(function(results) {
                    return vm.pageableResults = results.data;
                });
        }

        function deleteTest(testId) {
            alert("test worked");
            //  return testDataService.deleteTest(testId);
        };
    }
})();