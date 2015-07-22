
(function() {
    "use strict";

    var controllerId = "runHistoryIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "runHistoryDataService", runHistoryIndexCtrl]);

    function runHistoryIndexCtrl(common, runHistoryDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "RunHistory List",
            description: "RunHistory List"
        };

        vm.pageableResults = [];
        vm.title = "RunHistoryList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteRunHistory = deleteRunHistory;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated RunHistory List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return runHistoryDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteRunHistory(runHistoryId) {
            alert("test worked");
            //  return runHistoryDataService.deleteRunHistory(runHistoryId);
        };
    }
})();