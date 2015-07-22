
(function() {
    "use strict";

    var controllerId = "project_ConnectionIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "project_ConnectionDataService", project_ConnectionIndexCtrl]);

    function project_ConnectionIndexCtrl(common, project_ConnectionDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "Project_Connection List",
            description: "Project_Connection List"
        };

        vm.pageableResults = [];
        vm.title = "Project_ConnectionList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteProject_Connection = deleteProject_Connection;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated Project_Connection List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return project_ConnectionDataService.getDataPageable(sortExpression, page, pageSize).then(function(results) {
                return vm.pageableResults = results.data;
            });
        }

        function deleteProject_Connection(project_ConnectionId) {
            alert("test worked");
            //  return project_ConnectionDataService.deleteProject_Connection(project_ConnectionId);
        };
    }
})();