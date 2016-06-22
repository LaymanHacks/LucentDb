
(function() {
    "use strict";

    var controllerId = "projectDetailsViewIndexCtrl";
    angular.module("app")
        .controller(controllerId, ["common", "projectDetailsViewDataService", projectDetailsViewIndexCtrl]);

    function projectDetailsViewIndexCtrl(common, projectDetailsViewDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "ProjectDetailsView List",
            description: "ProjectDetailsView List"
        };

        vm.pageableResults = [];
        vm.title = "ProjectDetailsViewList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;


        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated ProjectDetailsView List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return projectDetailsViewDataService.getDataPageable(sortExpression, page, pageSize)
                .then(function(results) {
                    return vm.pageableResults = results.data;
                });
        }


    }
})();