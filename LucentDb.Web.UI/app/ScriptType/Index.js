
(function() {
    "use strict";

    var controllerId = "scriptTypeIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "scriptTypeDataService", scriptTypeIndexCtrl]);

    function scriptTypeIndexCtrl(common, scriptTypeDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "ScriptType List",
            description: "ScriptType List"
        };

        vm.pageableResults = [];
        vm.title = "ScriptTypeList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteScriptType = deleteScriptType;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated ScriptType List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return scriptTypeDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteScriptType(scriptTypeId) {
            alert("test worked");
            //  return scriptTypeDataService.deleteScriptType(scriptTypeId);
        };
    }
})();