(function() {
    "use strict";

    var controllerId = "testGroupIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "testGroupDataService", testGroupIndexCtrl]);

    function testGroupIndexCtrl(common, testGroupDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "TestGroup List",
            description: "TestGroup List"
        };

        vm.pageableResults = [];
        vm.title = "TestGroupList";
        vm.sortExpression = "Id";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteTestGroup = deleteTestGroup;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated TestGroup List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return testGroupDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteTestGroup(testGroupId) {
            return testGroupDataService.deleteTestGroup(testGroupId);
        };
    }
})();