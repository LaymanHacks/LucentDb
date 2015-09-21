
(function() {
    "use strict";

    var controllerId = "assertTypeIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "assertTypeDataService", "$filter", assertTypeIndexCtrl]);

    function assertTypeIndexCtrl(common, assertTypeDataService, $filter) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);


        var vm = this;
        vm.news = {
            title: "AssertType List",
            description: "AssertType List"
        };
        vm.filter = $filter;
        vm.pageableResults = [];
        vm.title = "AssertTypeList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteAssertType = deleteAssertType;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated AssertType List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return assertTypeDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteAssertType(assertTypeId) {
            alert("test worked");
            //  return assertTypeDataService.deleteAssertType(assertTypeId);
        };
    }
})();