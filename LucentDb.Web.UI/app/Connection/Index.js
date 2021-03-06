
(function() {
    "use strict";

    var controllerId = "connectionIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "connectionDataService", connectionIndexCtrl]);

    function connectionIndexCtrl(common, connectionDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "Connection List",
            description: "Connection List"
        };

        vm.pageableResults = [];
        vm.title = "ConnectionList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteConnection = deleteConnection;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated Connection List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return connectionDataService.getDataPageable(sortExpression, page, pageSize)
                .then(function(results) {
                    return vm.pageableResults = results.data;
                });
        }

        function deleteConnection(connectionId) {
            alert("test worked");
            //  return connectionDataService.deleteConnection(connectionId);
        };
    }
})();