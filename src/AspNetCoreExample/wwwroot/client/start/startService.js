module.exports = function(app) {
    app.factory('startService', startService);

    startService.$inject = ['$http'];

    function startService($http) {

        var service = {
            getMessage: getMessage
        };
        return service;

        //#region Exposed Functions

        function getMessage() {
            return $http.get('api/message');
        }

        //#endregion

        //#region Internal Functions


        //#endregion
    }
};
