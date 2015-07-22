
(function() {
    "use strict";

    var controllerId = "testTypeIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "testTypeDataService", testTypeIndexCtrl]);

    function testTypeIndexCtrl(common, testTypeDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "TestType List",
            description: "TestType List"
        };

        vm.pageableResults = [];
        vm.title = "TestTypeList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteTestType = deleteTestType;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated TestType List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return testTypeDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteTestType(testTypeId) {
            alert("test worked");
            //  return testTypeDataService.deleteTestType(testTypeId);
        };
    }
})();