
(function() {
    "use strict";

    var controllerId = "test_ScriptIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "test_ScriptDataService", test_ScriptIndexCtrl]);

    function test_ScriptIndexCtrl(common, test_ScriptDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "Test_Script List",
            description: "Test_Script List"
        };

        vm.pageableResults = [];
        vm.title = "Test_ScriptList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteTest_Script = deleteTest_Script;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated Test_Script List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return test_ScriptDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteTest_Script(test_ScriptId) {
            alert("test worked");
            //  return test_ScriptDataService.deleteTest_Script(test_ScriptId);
        };
    }
})();