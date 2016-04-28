require('angular-route');

var app = angular.module('test', ['ngRoute'])
    .config(config)
    .run(run);

require('./start')(app);

config.$inject = ['$routeProvider'];

function config($routeProvider) {
    $routeProvider
        .when('/start', {
            template: require('./start/start.html'),
            controller: 'StartController',
            controllerAs: 'vm'
        })
        .otherwise({
            redirectTo: '/start'
        });
}

run.$inject = [];

function run() {
}
