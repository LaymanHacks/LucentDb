(function() {
    "use strict";

    var controllerId = "connectionProviderIndexCtrl";
    angular.module("app")
        .controller(controllerId, ["common", "connectionProviderDataService", connectionProviderIndexCtrl]);

    function connectionProviderIndexCtrl(common, connectionProviderDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "ConnectionProvider List",
            description: "ConnectionProvider List"
        };

        vm.pageableResults = [];
        vm.title = "ConnectionProviderList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteConnectionProvider = deleteConnectionProvider;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated ConnectionProvider List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return connectionProviderDataService.getDataPageable(sortExpression, page, pageSize)
                .then(function(results) {
                    return vm.pageableResults = results.data;
                });
        }

        function deleteConnectionProvider(connectionProviderId) {
            alert("test worked");
            //  return connectionProviderDataService.deleteConnectionProvider(connectionProviderId);
        };
    }
})();