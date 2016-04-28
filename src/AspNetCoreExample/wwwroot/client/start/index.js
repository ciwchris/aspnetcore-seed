module.exports = function (app) {
    require('./startCtrl')(app);
    require('./startService')(app);
};
