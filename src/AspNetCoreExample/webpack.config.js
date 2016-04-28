var WebpackNotifierPlugin = require('webpack-notifier');
var path = require('path');
var node_modules_dir = path.resolve(__dirname, 'node_modules');

var deps = [
    'angular/angular.min.js',
    'angular/angular-route.min.js'
];

var config = {
    context: path.join(__dirname, '/wwwroot'),
    entry: ['angular', './client/app.js'],
    output: {
        path: __dirname + '/wwwroot',
        filename: 'bundle.js'
    },
    resolve: {
        alias: {}
    },
    plugins: [
        new WebpackNotifierPlugin()
    ],
    module: {
        preLoaders: [
          {
            test: /\.js$/,
            loader: 'eslint-loader',
            exclude: [
                /node_modules/,
                'bundle.js'
            ]
          }
        ],
        loaders: [
            {
                test: /\.js$/,
                loader: 'babel',
                exclude: /node_modules/,
                query: {
                    presets: ['es2015']
                }
            },
            {
                test: /\.html$/,
                loader: 'raw-loader',
                exclude: /node_modules/
            }
        ],
        noParse: []
    }
};

deps.forEach(function (dep) {
  var depPath = path.resolve(node_modules_dir, dep);
  config.resolve.alias[dep.split(path.sep)[0]] = depPath;
  config.module.noParse.push(depPath);
});

module.exports = config;
