
(function() {
    "use strict";

    var controllerId = "script_ExpectedResultIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "script_ExpectedResultDataService", script_ExpectedResultIndexCtrl]);

    function script_ExpectedResultIndexCtrl(common, script_ExpectedResultDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "Script_ExpectedResult List",
            description: "Script_ExpectedResult List"
        };

        vm.pageableResults = [];
        vm.title = "Script_ExpectedResultList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteScript_ExpectedResult = deleteScript_ExpectedResult;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated Script_ExpectedResult List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return script_ExpectedResultDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteScript_ExpectedResult(script_ExpectedResultId) {
            alert("test worked");
            //  return script_ExpectedResultDataService.deleteScript_ExpectedResult(script_ExpectedResultId);
        };
    }
})();