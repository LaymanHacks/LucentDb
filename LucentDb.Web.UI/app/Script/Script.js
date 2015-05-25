(function() {
    "use strict";

    var controllerId = "scriptCtrl";
    angular.module("app").controller(controllerId, ["common", "lucentDbDataContext", scriptCtrl]);

    function scriptCtrl(common, lucentDbDataContext) {

        var vm = this;
        vm.title = "script";

        vm.onAssertTypeSelect = function($item) {
            vm.assertTypeId = angular.copy($item.id);
        };
    }
})();