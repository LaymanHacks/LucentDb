
(function() {
    "use strict";

    var controllerId = "scriptIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "scriptDataService", scriptIndexCtrl]);

    function scriptIndexCtrl(common, scriptDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "Script List",
            description: "Script List"
        };

        vm.pageableResults = [];
        vm.title = "ScriptList";
        vm.sortExpression = "Id";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteScript = deleteScript;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated Script List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return scriptDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteScript(scriptId) {
            alert("test worked");
            //  return scriptDataService.deleteScript(scriptId);
        };
    }
})();