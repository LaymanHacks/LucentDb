
(function() {
    "use strict";

    var controllerId = "projectIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "projectDataService", projectIndexCtrl]);

    function projectIndexCtrl(common, projectDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "Project List",
            description: "Project List"
        };

        vm.pageableResults = [];
        vm.title = "ProjectList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deleteProject = deleteProject;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated Project List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return projectDataService.getDataPageable(sortExpression, page, pageSize)
                .then(function(results) {
                    return vm.pageableResults = results.data;
                });
        }

        function deleteProject(projectId) {
            alert("test worked");
            //  return projectDataService.deleteProject(projectId);
        };
    }
})();