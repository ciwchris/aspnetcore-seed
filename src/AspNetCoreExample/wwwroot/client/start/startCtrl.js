module.exports = function(app) {

    app.controller('StartController', StartCtrl);

    StartCtrl.$inject = ['startService'];

    function StartCtrl(startService) {
        var vm = this;

        vm.message = '';

        activate();

        //#region Exposed Functions

        //#endregion

        //#region Internal Functions

        function activate() {
            startService.getMessage()
                .then(function(response) {
                    vm.message = response.data;
                }).catch(function() {
                    vm.message = 'failed!';
                });
        }

        //#endregion
    }
};
